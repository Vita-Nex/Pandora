//***********************************************************************
//
// Wincap.c
//
// Windows Screen Capture Utility
// Version 3.10 (Second version)
//
// Description:
// ------------
//
// Captures portions of the screen, specific windows, or the entire screen
// and saves it to a file or prints it.  Uses DIBAPI functions to do most
// of the capture/printing/saving work.  See the file DIBAPI.TXT for a
// description of the DIB api functions.
//
// Development Team: Mark Bader
//                   Patrick Schreiber
//                   Garrett McAuliffe
//                   Eric Flo
//                   Tony Claflin
//                   Dan Ruder
//
//
// Changes from first version:
//
// - Updated to use 3.1 Common Dialogs and 3.1 hook functions
// - New user interface displays window which was captured in client
//      area of Wincap, complete with scroll bars
// - Hot new hotkeys allow more versatile capturing of windows (e.g. you
//      can now capture windows with menu items pulled down)
// - New APIs to draw bitmaps and DIBs on the screen
// - Nifty startup bitmap
// - All DIB API functions are now in a DLL, which can be used
//      by any application
// 
// Written by Microsoft Product Support Services, Developer Support.
// COPYRIGHT:
//
//   (C) Copyright Microsoft Corp. 1993.  All rights reserved.
//
//   You have a royalty-free right to use, modify, reproduce and
//   distribute the Sample Files (and/or any modified version) in
//   any way you find useful, provided that you agree that
//   Microsoft has no warranty obligations or liability for any
//   Sample Application Files which are modified.
//
//***********************************************************************

#include <windows.h>
#include <string.h>
#include "commdlg.h"
#include "wincap.h"
#include "dialogs.h"
#include "dibapi.h"

char szAppName[20];     // Name of application - used in dialog boxes

/* Global variables */
HWND     ghInst;         // Handle to instance
HWND     ghWndMain;      // Handle to main window
FARPROC  lpfnKeyHook;    // Used in keyboard hook
FARPROC  lpfnOldHook;    // Used for keyboard hook
HWND     hModelessDlg;   // Handle to modeless "Saving to file..." dialog box

BOOL     bStartup=TRUE;  // Startup flag for WM_PAINT/logo
BOOL     bViewFull=FALSE;// Full view flag
HBITMAP  ghbmLogo;       // Handle to logo bitmap
HBITMAP  ghBitmap=NULL;  // Handle to captured bitmap
HPALETTE ghPal=NULL;     // Handle to our bitmap's palette
char     gszWindowText[100];// Text which tells what we captured

#define WM_DOCAPTURE WM_USER+101 // Used for screen capture messages

/* Macro to swap two values */
#define SWAP(x,y)   ((x)^=(y)^=(x)^=(y))
#define SCROLL_RATIO    4


//************************************************************************
//
// WinMain()
//
// Entry point of the Application.
//
// History:   
//            
//   Date      Author       Reason         
//   9/15/91   Mark Bader   Created         
//   12/11/91  Mark Bader   Made main window be normal rather
//                            than keep iconic
//   03/04/92  Mark Bader   Changed keyboard hook to 3.1 spec - e.g. put
//                            system-wide hook func in a DLL
//
//************************************************************************

int PASCAL WinMain(HANDLE hInstance, HANDLE hPrevInstance, LPSTR lpszCmdLine,
                   int nCmdShow)
{
   MSG msg;
   WNDCLASS wndclass;
   HWND hWnd;

   strcpy(szAppName, "WinCap");     // Name of our App
   hModelessDlg = NULL;             // Set handle to modeless dialog to NULL because
                                    // we haven't created it yet
   if (!hPrevInstance)
   {
      wndclass.style = 0;
      wndclass.lpfnWndProc = (WNDPROC)WndProc;
      wndclass.cbClsExtra = 0;
      wndclass.cbWndExtra = 0;
      wndclass.hInstance = hInstance;
      wndclass.hIcon = LoadIcon(hInstance, "WINCAP");
      wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);

      // Use black for background for better contrast
      wndclass.hbrBackground = GetStockObject(GRAY_BRUSH);

      wndclass.lpszMenuName = (LPSTR)"MAINMENU";
      wndclass.lpszClassName = (LPSTR)szAppName;
      if (!RegisterClass(&wndclass))
         return FALSE;
      ghInst = hInstance;  // Set Global variable

      // Create a main window for this application instance.

      hWnd = CreateWindow(szAppName,            // Name of the window's class
                          "Screen Capture",     // Text for window caption
                          WS_OVERLAPPEDWINDOW,  // Window Style
                          CW_USEDEFAULT,        // Default horizontal position
                          CW_USEDEFAULT,        // Default vertical position
                          450,        // Default width & height -- this is
                          345,        // big enough to contain startup bitmap
                          NULL,                 // Overlapped windows have no parent
                          NULL,                 // Use the window class menu
                          hInstance,            // This instance owns this window
                          NULL);                // Pointer (not used)
      ghWndMain = hWnd;      // Set global variable

      ShowWindow(hWnd, nCmdShow);
      UpdateWindow(hWnd);

      /*
       * Set up the Keyboard hook for our hotkeys
       */

      InstallHook(hWnd, TRUE);  // Function resides in DIBAPI.DLL

      /* Create our full-screen view class */

      wndclass.style = 0;
      wndclass.lpfnWndProc = (WNDPROC)FullViewWndProc;
      wndclass.cbClsExtra = 0;
      wndclass.cbWndExtra = 0;
      wndclass.hInstance = hInstance;
      wndclass.hIcon = NULL;
      wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);
      wndclass.hbrBackground = GetStockObject(GRAY_BRUSH);
      wndclass.lpszMenuName = (LPSTR)NULL;
      wndclass.lpszClassName = (LPSTR)"ViewClass";
      if (!RegisterClass(&wndclass))
         return FALSE;

   }

   /*
    * Let's make this a single-instance app -- we can get into hotkey
    * conflicts (e.g. windows won't know which instance of WINCAP to 
    * send the message to).  
    */
   if (hPrevInstance)
   {
      MessageBox(NULL, "WinCap is already running.  "
                       "You cannot start multiple copies of WinCap.", szAppName,
                 MB_OK | MB_ICONHAND);
      return FALSE;
   }

   /* Polling messages from event queue -- we have a modeless dialog
      box, so we have to take care of the messages here also */

   while (GetMessage(&msg, NULL, 0, 0))
   {
      if (hModelessDlg == NULL || !IsDialogMessage(hModelessDlg, &msg))
      {
         TranslateMessage(&msg);
         DispatchMessage(&msg);
      }
   }
   return msg.wParam;
}



//**********************************************************************
//
// WndProc()
//
// This is our main window procedure.  It receives all the messages destined
// for our application's main window.
//
// When we capture a window, we capture it into a Device-Dependent bitmap,
// and at the same time, we get a copy of the current system palette.  This
// makes displaying the bitmap on the screen very fast.  And when we want
// to print or save the captured window, we need to use this palette to
// convert the DDB to a DIB.
//
// History:   
// 
//   Date      Author          Reason
//   9/15/91   Mark Bader      Created
//   12/12/91  Mark Bader      Added code for new menu items
//   12/13/91  Pat Schreiber   Added painting of captured DIB in
//                                client area
//   12/16/91  Pat Schreiber   Added support for full-screen view
//   12/20/91  Pat Schreiber   Added support for palette changes
//                               and scroll bars
//   01/03/92  Mark Bader      Added bunches of comments
//
//*********************************************************************

long FAR PASCAL WndProc(HWND hWnd, WORD wMessage, WORD wParam, LONG lParam)
{
   /*
    * The bNowCapturing variable is set to TRUE if we are in the middle of
    * printing.  This takes care of the case when the user presses the hotkey
    * during capturing
    */

   static BOOL bNowCapturing = FALSE;
   static BOOL bCapturedYet = FALSE;  // TRUE if window contains captured screen
   HWND   hViewWnd;                   // Handle to our view window

   switch (wMessage)
      {

   case WM_CREATE:
      ghbmLogo = LoadBitmap(ghInst, "STARTBMP");
      break;


   // Gray out the "File.Save" menu item if we haven't
   // captured anything yet.

   case WM_INITMENU:
     EnableMenuItem(GetMenu(hWnd),
                    IDM_SAVE,
                    MF_BYCOMMAND |
                    (bCapturedYet ? MF_ENABLED : MF_DISABLED | MF_GRAYED));
     EnableMenuItem(GetMenu(hWnd),
                    IDM_PRINT,
                    MF_BYCOMMAND |
                    (bCapturedYet ? MF_ENABLED : MF_DISABLED | MF_GRAYED));
     return 0;


   // The WM_PALETTECHANGED message informs all windows that the window with
   // input focus has realized its logical palette, thereby changing the
   // system palette. This message allows a window without input focus that
   // uses a color palette to realize its logical palettes and update its
   // client area.
   //
   // This message is sent to all windows, including the one that changed
   // the system palette and caused this message to be sent. The wParam of
   // this message contains the handle of the window that caused the system
   // palette to change. To avoid an infinite loop, care must be taken to
   // check that the wParam of this message does not match the window's
   // handle.

   case WM_PALETTECHANGED:
      {
      HDC      hDC;      // Handle to device context
      HPALETTE hOldPal;  // Handle to previous logical palette

      // Before processing this message, make sure we
      // are indeed using a palette
      if (ghPal)
         {
         // If this application did not change the palette, select
         // and realize this application's palette
         if (wParam != hWnd)
            {
            // Need the window's DC for SelectPalette/RealizePalette
            hDC = GetDC(hWnd);

            // Select and realize our palette
            hOldPal = SelectPalette(hDC, ghPal, FALSE);
            RealizePalette(hDC);

            // WHen updating the colors for an inactive window,
            // UpdateColors can be called because it is faster than
            // redrawing the client area (even though the results are
            // not as good)
            UpdateColors(hDC);

            // Clean up
            if (hOldPal)
               SelectPalette(hDC, hOldPal, FALSE);
            ReleaseDC(hWnd, hDC);
            }
         }
      }
      break;


   // The WM_QUERYNEWPALETTE message informs a window that it is about to
   // receive input focus. In response, the window receiving focus should
   // realize its palette as a foreground palette and update its client
   // area. If the window realizes its palette, it should return TRUE;
   // otherwise, it should return FALSE.

   case WM_QUERYNEWPALETTE:
      {
      HDC      hDC;      // Handle to device context
      HPALETTE hOldPal;  // Handle to previous logical palette

      // Before processing this message, make sure we
      // are indeed using a palette
      if (ghPal)
         {
         // Need the window's DC for SelectPalette/RealizePalette
         hDC = GetDC(hWnd);

         // Select and realize our palette
         hOldPal = SelectPalette(hDC, ghPal, FALSE);
         RealizePalette(hDC);

         // Redraw the entire client area
         InvalidateRect(hWnd, NULL, TRUE);
         UpdateWindow(hWnd);

         // Clean up
         if (hOldPal)
            SelectPalette(hDC, hOldPal, FALSE);
         ReleaseDC(hWnd, hDC);

         // Message processed, return TRUE
         return TRUE;
         }
      // Message not processed, return FALSE
      return FALSE;
      }
      break;


   case WM_SIZE:
      {
      static BOOL bSizing=FALSE;

      // Check if we are already sizing
      if (bSizing)
         return NULL;

      bSizing = TRUE;
      DoSize(hWnd);
      bSizing = FALSE;
      }
      break;


   case WM_HSCROLL:
   case WM_VSCROLL:
      DoScroll(hWnd, wMessage, LOWORD(lParam), wParam);
      break;


   case WM_PAINT:
      DoPaint(hWnd);
      break;


   case WM_COMMAND:
      switch (wParam)
         {
         case IDM_ABOUT:

      /*
       * Display "About" Box
       */
      {
         FARPROC lpfnDIALOGSMsgProc;

         lpfnDIALOGSMsgProc = MakeProcInstance((FARPROC)AboutDlgProc, ghInst);
         DialogBox(ghInst, (LPSTR)"About", hWnd, lpfnDIALOGSMsgProc);
         FreeProcInstance(lpfnDIALOGSMsgProc);
      }
         break;

      case IDM_SAVE:
        SaveMe();
        break;

      case IDM_PRINT:
        PrintMe();
        break;

      case IDM_VIEWFULL:
         if (!bViewFull && (ghBitmap || bStartup))
            {
            HDC hDC;
            int ScreenX, ScreenY;

            hDC = CreateDC("DISPLAY", NULL, NULL, NULL);
            ScreenX = GetDeviceCaps(hDC, HORZRES);
            ScreenY = GetDeviceCaps(hDC, VERTRES);
            DeleteDC(hDC);

            hViewWnd = CreateWindow((LPSTR)"ViewClass",
                                   (LPSTR)NULL,
                                   WS_POPUP | WS_VISIBLE,
                                   0,
                                   0,
                                   ScreenX,
                                   ScreenY,
                                   hWnd,
                                   NULL,
                                   ghInst,
                                   NULL);

            ShowWindow(hViewWnd, SW_SHOW);
            UpdateWindow(hViewWnd);
            }
         else
            MessageBox(hWnd, (LPSTR)"No image to view!",
                       (LPSTR)"View Full Screen", MB_OK);
         break;

      case IDM_VIEWCLEAR:
         {
         // If we are just displaying logo, don't
         // display it anymore
         if (bStartup)
            bStartup = FALSE;

         // Delete captured bitmap if we have one
         if (ghBitmap)
            {
            DeleteObject(ghBitmap);
            ghBitmap = NULL;
            }

         // Delete our captured bitmap's palette if we have one
         if (ghPal)
            {
            DeleteObject(ghPal);
            ghPal = NULL;
            }

         /* Now update display to reflect fact that we
          * nuked the captured bitmap or don't want to
          * look at the cool logo
          */
         InvalidateRect(hWnd, NULL, TRUE);
         UpdateWindow(hWnd);

         bCapturedYet = FALSE;  // Gray out "File.Save" menu item
         }
         break;

      case IDM_CAPTWINDOW:
      case IDM_CAPTCLIENT:
      case IDM_CAPTRECT:
      case IDM_ACTIVEWINDOW:
      case IDM_DESKTOP:

         /*
          * User selected one of the window capture items
          */

         /* Check to see that we aren't already in the middle of capturing
          * This could happen if the user presses our hotkey in the middle of
          * one of our dialog boxes.
          */

          if (bNowCapturing)
          {
             MessageBox(NULL, "Already capturing.  Try again later.",
                        szAppName, MB_OK | MB_ICONEXCLAMATION);
          }
          else
          {
             // User wants to capture screen.  One problem we may
             // run into here is that we might have a popup menu pulled
             // down in our own application when we get to this point
             // (because of the hotkey feature of this app).
             //
             // Normally, we'd just enter a message loop after calling
             // ShowWindow(SW_HIDE) to take care of any menu messages
             // which may have been posted as we hide our application's
             // window, and *then* call our screen capture routine.
             // But unfortunately, we can't do that here and be 100% safe.
             //
             // If we *have* been sent here on a hotkey, and a menu of
             // our own app is currently down, then we are currently running
             // inside of a PeekMessage() loop in the Windows Menu
             // manager. We should *not* enter another PeekMessage loop,
             // but should return from this message case right away.
             // The Windows Menu manager code relies on checking messages
             // in it's queue via it's own PeekMessage loop, and if we
             // entered one, it would confuse the menu manager.
             //
             // So what we do instead is just post ourselves a private
             // message, and when we get this message (see below), then
             // do the screen capture.
             //
             // Note: Under the 3.1 Debug Kernel, if we get here when
             // a menu is down in our app, you should expect the following
             // warning:
             //
             // wn WINCAP USER: Exiting menu mode: another window activated
             //

             // Commence screen capture!
             bNowCapturing = TRUE;

             ShowWindow(hWnd, SW_HIDE);  // Hide main app's window

             // Allow this message case to return right away.  We'll
             // capture screen down below.
             PostMessage(hWnd, WM_DOCAPTURE, wParam, 0L);
         }
         break;

      case IDM_EXIT:
          PostMessage(hWnd, WM_CLOSE, 0, 0L);
          break;

      default:
          return DefWindowProc(hWnd, wMessage, wParam, lParam);
          break;
        }
        break;


     // Message case for doing screen capture.  This message is posted to
     // us from the IDM_CAPT* code above.  wParam should be equal to the
     // ID of the message which we got sent here for (it is used in the
     // call to DoCapture()).
     case WM_DOCAPTURE:
     {
     // We're going to capture a new screen, get rid of
     // previous captured image

     if (ghBitmap) {
        DeleteObject(ghBitmap);
        ghBitmap = NULL;
        }
     if (ghPal) {
        DeleteObject(ghPal);
        ghPal = NULL;
        }

     // Save captured screen as bitmap
     DoCapture(hWnd, wParam);

     // Un-hide Window
     ShowWindow(hWnd, SW_SHOW);

     bNowCapturing = FALSE;
     bCapturedYet = TRUE; // Enable "File.Save" menu item
     }
     break;


   case WM_DESTROY:
      /*
       * Clean up
       */

      InstallHook(hWnd, FALSE);  // Remove keyboard hook

      DeleteObject(ghbmLogo);
      if (ghBitmap)
         DeleteObject(ghBitmap);
      if (ghPal)
         DeleteObject(ghPal);

      PostQuitMessage(0);
      break;

   default:
      return DefWindowProc(hWnd, wMessage, wParam, lParam);
      }
   return 0L;
}


//**********************************************************************
//
// FullViewWndProc()
//
// This is our full-screen popup window procedure. It is used to display an
// image using the entire screen. Clicking the left mouse button restores
// to the main app window.
//
//
// History:   Date      Author              Reason
//            12/16/91  Patrick Schreiber   Created
//
//*********************************************************************

long FAR PASCAL FullViewWndProc(HWND  hWnd,
                                WORD  wMessage,
                                WORD  wParam,
                                LONG  lParam)
{
   switch (wMessage)
      {
      case WM_PAINT:
         {
         PAINTSTRUCT ps;
         HDC         hMemDC;
         BITMAP      bm;
         HBITMAP     hOldBm;
         RECT        rect, rectClient;
         int         x, y;

         BeginPaint(hWnd, &ps);

         // Check to see if we are displaying a bitmap
         if (!ghBitmap)
            {

            // No bitmap yet, are we in start mode?
            if (bStartup)
               {
               GetClientRect(hWnd, &rectClient);

               hMemDC = CreateCompatibleDC(ps.hdc);

               // Select our logo bitmap
               hOldBm = SelectObject(hMemDC, ghbmLogo);

               GetObject(ghbmLogo, sizeof(BITMAP), (VOID FAR *)&bm);

               x = (rectClient.right - bm.bmWidth) / 2;
               y = (rectClient.bottom - bm.bmHeight) / 2;

               // Now bitblt our logo to client area
               BitBlt(ps.hdc, x, y, bm.bmWidth, bm.bmHeight,
                      hMemDC, 0, 0, SRCCOPY);

               // Clean up
               SelectObject(hMemDC,hOldBm);
               DeleteDC(hMemDC);
               }
            }
         else
            {
            /* Get info for captured bitmap */
            GetObject(ghBitmap, sizeof(BITMAP), (LPSTR)&bm);

            /* Fill in src/dest rectangle with width and height
             * of captured bitmap
             */
            rect.left = 0;
            rect.top = 0;
            rect.right = bm.bmWidth;
            rect.bottom = bm.bmHeight;

            /* Paint the captured bitmap in the client area */
            PaintBitmap(ps.hdc, &rect, ghBitmap, &rect, ghPal);
            }

         EndPaint(hWnd, &ps);
         }
         break;

      case WM_KEYDOWN:
      case WM_LBUTTONDOWN:
         DestroyWindow(hWnd);
         break;

      default:
         return DefWindowProc(hWnd, wMessage, wParam, lParam);
      }
}


//**********************************************************************
//
// SaveMe()
//
// This procedure calls up the common dialog "File.Save" box, then 
// saves the current hBitmap as a DIB in the specified file, in the
// file format specified by the user in the dialog.
//
// History:   
//
//    Date      Author         Reason        
//    12/19/91  Mark Bader     Created       
//    03/05/92  Mark Bader     Changed to use File/Save Common Dialog
//
//*********************************************************************

void SaveMe()

{
    char szFileBuf[255];    // Buffer to hold returned file name
    DWORD dwFlags;          // used to pass in / get out file type
    HDC hDC;                // HDC for getting info
    int iBits;              // Bits per pixel of the display adapter
    DWORD dCompression;     // Compression that the user specifies
    WORD wBitCount;         // Bits per pixel that the user specifies
    WORD wCompression;      // Compression
    HDIB hDIB;              // A handle to our dib
    FARPROC lpfnDIALOGSMsgProc; // procedure for "Saving" dialog
    BOOL bResult;           // Result of dialog box - TRUE if OK was pressed

    // Set up default compression to display in dialog box

    wCompression = IDD_RGB;

    // Depending on bits/pixel type for current display,
    // set the appropriate bit in the fFileOptions flag
    //
    // NOTE that we don't just assign wBitCount to iBits.  The reason
    // for this is some displays aren't 1,4,8 or 24 bits.  Some are
    // 15 bits, which isn't valid for a DIB, so in this case, we would
    // set the bits to 24. 

    hDC = CreateDC("DISPLAY",NULL,NULL,NULL);
    iBits = GetDeviceCaps(hDC, BITSPIXEL) * GetDeviceCaps(hDC, PLANES);
    DeleteDC(hDC);

    if (iBits <= 1)
       wBitCount = 1;

    else if (iBits <= 4)
       wBitCount = 4;

    else if (iBits <= 8)
       wBitCount = 8;

    else if (iBits <= 24)
       wBitCount = 24;

    // Our dwFlags parameter to GetFileName is made up of the
    // bits per pixel in the HIWORD (1, 2, 4, or 24), and the compression
    // type in the LOWORD (IDD_RGB, IDD_RLE4, or IDD_RLE8).

    dwFlags = MAKELONG(wCompression, wBitCount);


    // Bring up File/Save... dialog and get info. about filename,
    // compression, and bits/pix. of DIB to be written.

    bResult = GetFileName(ghWndMain, (LPSTR)szFileBuf, &dwFlags);

    // Extract DIB specs and save to file (if the user did not 
    // press cancel)

      if (bResult) {
         switch(LOWORD(dwFlags)) {
            case IDD_RLE4:
                dCompression = BI_RLE4;
                break;
            case IDD_RLE8:
                dCompression = BI_RLE8;
                break;
            case IDD_RGB:
            default:
                dCompression = BI_RGB;
                break;
            }

        // First, call up a modeless dialog box which tells that we are
        // saving this to a file...

        if (!hModelessDlg) {
            lpfnDIALOGSMsgProc = MakeProcInstance((FARPROC)SavingDlgProc,
                                                  ghInst);
            hModelessDlg = CreateDialogParam(ghInst,
                    (LPSTR)"Saving",ghWndMain,lpfnDIALOGSMsgProc,
                    (DWORD)(LPSTR)szFileBuf);
            }

        // Now, write out the DIB in the proper format.  The following
        // API ChangeBitmapFormat() will convert the specified bitmap
        // to a DIB with the specified Bit Count, Compression and
        // Palette.  Remember that the HIWORD of dwFlags specifies the
        // bits per pixel.

        hDIB = ChangeBitmapFormat(ghBitmap, HIWORD(dwFlags), 
                        dCompression, ghPal);

        if (hDIB) {
          if (SaveDIB(hDIB, szFileBuf))
              MessageBox(NULL, "Could not save bitmap", "SaveDIB error",
                         MB_ICONEXCLAMATION);

          DestroyDIB(hDIB);
          }

        DestroyWindow(hModelessDlg);
        FreeProcInstance(lpfnDIALOGSMsgProc);
        hModelessDlg = NULL;
      }

}

//*********************************************************************
//
// PrintMe()
//
// This procedure calls up the "File.Print" dialog, then prints the
// current hBitmap as a DIB on the default printer.
//
// History:   Date      Author       Reason
//            12/19/91  Mark Bader   Created
//            03/12/92  Mark Bader   Couldn't convert to PrintDlg() common
//                                   dialog, because of the API we use
//
//*********************************************************************

void PrintMe() {
  static OPTIONSTRUCT opts;
  FARPROC lpMsgProc;
  int iReturn;
  HDIB hDIB;
  WORD wReturn;

  /*
   * Display "Print Options" Box
   */

   lpMsgProc = MakeProcInstance((FARPROC)PrintDlgProc, ghInst);
   iReturn = DialogBoxParam(ghInst, (LPSTR)"Print",
                            ghWndMain, lpMsgProc, (LONG)(LPSTR)&opts);
   FreeProcInstance(lpMsgProc);

   if (iReturn) {

     // User pressed "OK" -- do the printing

     hDIB = BitmapToDIB(ghBitmap, ghPal);

     if (hDIB) {

       // Print the dib using PrintDIB() API

       if (opts.iOption == IDC_STRETCHTOPAGE)
         wReturn = PrintDIB(hDIB, PW_STRETCHTOPAGE,
                            0, 0, (LPSTR)gszWindowText);

       else if (opts.iOption == IDC_SCALE)
         wReturn = PrintDIB(hDIB, PW_SCALE,
                            opts.iXScale, opts.iYScale,
                            (LPSTR)gszWindowText);
       else
         wReturn = PrintDIB(hDIB, PW_BESTFIT,
                            0, 0, (LPSTR)gszWindowText);

       if (wReturn)
           DIBError(wReturn);

       DestroyDIB(hDIB);
       }
    }


}



//*********************************************************************
//
// DoCapture()
//
// This procedure gets called when the user wants to capture the
// screen.  The wCommand parameter tells us which capture operation
// we want to perform.
//
// History:   Date      Author         Reason
//            9/15/91   Mark Bader     Created
//
//*********************************************************************


void DoCapture(HWND hWnd, WORD wCommand)
{
   HBITMAP hBitmap;                // Handle to our temporary bitmap
   HPALETTE hPal;                  // Handle to our palette


   switch (wCommand) {

      case IDM_DESKTOP:

      /*
       * Copy Entire screen to DIB
       */

      {
         RECT rScreen;       // Rect containing entire screen coordinates
         HDC hDC;            // DC to screen
         MSG msg;            // Message for the PeekMessage()

         hDC = CreateDC("DISPLAY", NULL, NULL, NULL);
         rScreen.left = rScreen.top = 0;
         rScreen.right = GetDeviceCaps(hDC, HORZRES);
         rScreen.bottom = GetDeviceCaps(hDC, VERTRES);

         /* Delete our DC */
         DeleteDC(hDC);

         strcpy(gszWindowText, "Entire screen");

         // Wait until everybody repaints themselves

         while (PeekMessage(&msg,NULL,0,0,PM_REMOVE) != 0) {
                TranslateMessage(&msg);
                DispatchMessage(&msg);
                }


         hBitmap = CopyScreenToBitmap(&rScreen);

         if (hBitmap)
            hPal = GetSystemPalette();
         else
            hPal = NULL;
      }
         break;


      case IDM_CAPTRECT:
      /*
       * Copy user-selected portion of screen to DIB
       */

      {
         RECT rRubberBand;       // Region to capture (screen coordinates)

         /*
          * Allow user to "rubberband" a section of the screen for
          * us to capture
          */

         RubberBandScreen(&rRubberBand);
         strcpy(gszWindowText, "User selected portion");

         hBitmap = CopyScreenToBitmap(&rRubberBand);

         if (hBitmap)
            hPal = GetSystemPalette();
         else
            hPal = NULL;
      }
         break;



      case IDM_CAPTWINDOW:
      case IDM_CAPTCLIENT:
      case IDM_ACTIVEWINDOW:
      {
         HWND hWndSelect;       // The current active window
         HWND hWndDesktop;      // Window to desktop
         MSG msg;               // For our peekmessage loop

         if (wCommand == IDM_ACTIVEWINDOW)

            // Just capture the current active window, whatever it is

            hWndSelect = GetActiveWindow();

         else

            // Allow the user to click on a single window to capture

            hWndSelect = SelectWindow();


          // If they try to capture the desktop window, then just
          // capture the entire screen.

         hWndDesktop = GetDesktopWindow();

         if (hWndSelect == hWndDesktop)
         {
             RECT rScreen;       // Rect containing entire screen coordinates
             HDC hDC;            // DC to screen
             MSG msg;            // Message for the PeekMessage()

             hDC = CreateDC("DISPLAY", NULL, NULL, NULL);
             rScreen.left = rScreen.top = 0;
             rScreen.right = GetDeviceCaps(hDC, HORZRES);
             rScreen.bottom = GetDeviceCaps(hDC, VERTRES);

             /* Delete our DC */
             DeleteDC(hDC);

             strcpy(gszWindowText, "Entire screen");

             // Wait until everybody repaints themselves

             while (PeekMessage(&msg,NULL,0,0,PM_REMOVE) != 0) {
                    TranslateMessage(&msg);
                    DispatchMessage(&msg);
                    }

             ghBitmap = CopyScreenToBitmap(&rScreen);

             if (ghBitmap)
                ghPal = GetSystemPalette();
             else
                ghPal = NULL;

            return;
         }

         // Check to see that the hWnd is not NULL

         if (!hWndSelect)
         {
            MessageBox(NULL, "Cannot capture that window!", szAppName,
                       MB_ICONEXCLAMATION | MB_OK);

            hBitmap = NULL;
            hPal = NULL;
            break;
         }

         /*
          * Make sure it's not a hidden window.  Hmm, capturing a hidden
          * window would certainly be a cool trick, wouldn't it?
          */

         if (!IsWindowVisible(hWndSelect))
         {
            MessageBox(NULL, "Window is not visible.  Can't capture",
                       szAppName, MB_ICONEXCLAMATION | MB_OK);

            hBitmap = NULL;
            hPal = NULL;
            break;
         }

         // Move window which was selected to top of Z-order for
         // the capture, and make it redraw itself

         SetWindowPos(hWndSelect, NULL, 0, 0, 0, 0,
                      SWP_DRAWFRAME | SWP_NOSIZE | SWP_NOMOVE);

         UpdateWindow(hWndSelect);

         // Wait until everybody repaints themselves

         while (PeekMessage(&msg,NULL,0,0,PM_REMOVE) != 0) {
                TranslateMessage(&msg);
                DispatchMessage(&msg);
                }

         // Get the caption
         GetWindowText(hWndSelect, gszWindowText, 100);

         // Capture the screen -- if we selected CLIENT only capture, then
         // select that open when calling our API.  Otherwise, get the
         // entire window.

         hBitmap = CopyWindowToBitmap(hWndSelect,
                    (wCommand == IDM_CAPTCLIENT) ? PW_CLIENT : PW_WINDOW);

         if (hBitmap)
            hPal = GetSystemPalette();
         else
            hPal = NULL;
      }
         break;

      default:
         /*
          * Oops, something went wrong
          */
         MessageBox(NULL, "INTERNAL ERROR 23: Invalid command",
                    szAppName, MB_ICONHAND | MB_OK);
         break;
         }

      if (hBitmap)
      {
         ghBitmap = hBitmap;
         hBitmap = NULL;
      }
      if (hPal)
      {
         ghPal = hPal;
         hPal = NULL;
      }

      // Now, paint our bitmap in the client area
      if (bStartup)
         bStartup = FALSE;
      InvalidateRect(hWnd, NULL, FALSE);
      UpdateWindow(hWnd);

      return;

}


//*********************************************************************
//
// SelectWindow()
//
// This function allows the user to select a window on the screen.  The
// cursor is changed to a custom cursor, then the user clicks on the title
// bar of a window to capture, and the handle to this window is returned.
//
// History:   Date      Author         Reason
//            9/15/91   Mark Bader     Created based on DIBVIEW code
//
//*********************************************************************

HWND SelectWindow()
{
   HCURSOR hOldCursor;     // Handle to old cursor
   POINT pt;               // Stores mouse position on a mouse click
   HWND hWndClicked;       // Window we clicked on
   MSG msg;

   /*
    * Capture all mouse messages
    */
   SetCapture(ghWndMain);

   /*
    * Load custom Cursor
    */
   hOldCursor = SetCursor(LoadCursor(ghInst, "SELECT"));

   /*
    * Eat mouse messages until a WM_LBUTTONUP is encountered.
    */
   for (;;)
   {
      WaitMessage();
      if (PeekMessage(&msg, NULL, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
      {
         if (msg.message == WM_LBUTTONUP)
         {
            /*
             * Get mouse position
             */
            pt.x = LOWORD(msg.lParam);
            pt.y = HIWORD(msg.lParam);

            /*
             * Convert to screen coordinates
             */
            ClientToScreen(ghWndMain, &pt);

            /*
             * Get Window that we clicked on
             */
            hWndClicked = WindowFromPoint(pt);

            /*
             * If it's not a valid window, just return NULL
             */
            if (!hWndClicked)
            {
               ReleaseCapture();
               SetCursor(hOldCursor);
               return NULL;
            }
            break;
         }
      }
      else
         continue;
   }
   ReleaseCapture();
   SetCursor(hOldCursor);
   return (hWndClicked);
}


//**********************************************************************
//
// RubberBandScreen()
//
// This function allows the user to rubber-band a portion of the screen.
// When the left button is released, the rect that the user selected
// (in screen coordinates) is returned in lpRect.
//
// History:   Date      Author         Reason
//            9/15/91   Mark Bader     Created from SHOWDIB code
//
//*********************************************************************

void RubberBandScreen(LPRECT lpRect)
{
   POINT pt;           // Temporary POINT
   MSG msg;            // Used in our PeekMessage() loop
   POINT ptOrigin;     // Point where the user pressed left mouse button down
   RECT rcClip;        // Current selection
   HDC hScreenDC;      // DC to the screen (so we can draw on it)
   HCURSOR hOldCursor; // Saves old cursor
   BOOL bCapturing = FALSE;    // TRUE if we are rubber-banding

   hScreenDC = CreateDC("DISPLAY", NULL, NULL, NULL);

   /*
    * Make cursor our custom cursor
    */
   hOldCursor = SetCursor(LoadCursor(NULL, IDC_CROSS));

   /*
    * Capture all mouse messages
    */
   SetCapture(ghWndMain);

   /* Eat mouse messages until a WM_LBUTTONUP is encountered. Meanwhile
    * continue to draw a rubberbanding rectangle and display it's dimensions
    */
   for (;;)
   {
      WaitMessage();
      if (PeekMessage(&msg, NULL, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
      {
         /*
          * If the message is a WM_LBUTTONDOWN, begin drawing the
          * rubber-band box.
          */
         if (msg.message == WM_LBUTTONDOWN)
         {
            /*
             * User pressed left button, initialize selection
             * Set origin to current mouse position (in window coords)
             */
            ptOrigin.x = LOWORD(msg.lParam);
            ptOrigin.y = HIWORD(msg.lParam);

            /*
             * Convert to screen coordinates
             */
            ClientToScreen(ghWndMain, &ptOrigin);

            /*
             * rcClip is the current rectangle that the user
             * has selected.  Since user just pressed left button down,
             * initialize this rect very small
             */
            rcClip.left = rcClip.right = ptOrigin.x;
            rcClip.top = rcClip.bottom = ptOrigin.y;
            NormalizeRect(&rcClip);     // Make sure it is a normal rect
            DrawSelect(hScreenDC, TRUE, &rcClip); // Draw the rubber-band box
            bCapturing = TRUE;
         }
         /*
          * Any messages that make it into the next statement are mouse
          * messages, and we are capturing, so let's update the rubber-band
          * box
          */
         if (bCapturing)
         {
            DrawSelect(hScreenDC, FALSE, &rcClip);    // erase old rubber-band
            rcClip.left = ptOrigin.x;     // Update rect with new mouse info
            rcClip.top = ptOrigin.y;
            pt.x = LOWORD(msg.lParam);
            pt.y = HIWORD(msg.lParam);

            /*
             * Convert to screen coordinates
             */
            ClientToScreen(ghWndMain, &pt);
            rcClip.right = pt.x;
            rcClip.bottom = pt.y;
            NormalizeRect(&rcClip);
            DrawSelect(hScreenDC, TRUE, &rcClip); // And draw the new rubber-band
         }

         // If the message is WM_LBUTTONUP, then we stop the selection
         // process.
         if (msg.message == WM_LBUTTONUP)
         {
            DrawSelect(hScreenDC, FALSE, &rcClip);    // erase rubber-band
            SetCursor(hOldCursor);
            break;
         }
      }
      else
         continue;
   }
   ReleaseCapture();
   DeleteDC(hScreenDC);

   /*
    * Assign rect user selected to lpRect parameter
    */
   CopyRect(lpRect, &rcClip);
}


//***************************************************************************
//
// DrawSelect
//
// Draws the selected clip rectangle with its dimensions on the DC
//
// History:   Date      Author      Reason
//            9/15/91   Mark Bader  Created from SHOWDIB code
//
//***************************************************************************


void DrawSelect(HDC hdc,           // DC to draw on
                BOOL fDraw,        // TRUE to draw, FALSE to erase
                LPRECT lprClip)    // rect to draw
{
   char sz[80];
   DWORD dw;
   int x, y, len, dx, dy;
   HDC hdcBits;
   HBITMAP hbm;
   RECT rcClip;

   rcClip = *lprClip;
   if (!IsRectEmpty(&rcClip))
   {

      /* If a rectangular clip region has been selected, draw it */
      PatBlt(hdc, rcClip.left, rcClip.top, rcClip.right - rcClip.left, 1,
             DSTINVERT);
      PatBlt(hdc, rcClip.left, rcClip.bottom, 1, -(rcClip.bottom - rcClip.top)
             , DSTINVERT);
      PatBlt(hdc, rcClip.right - 1, rcClip.top, 1, rcClip.bottom - rcClip.top,
             DSTINVERT);
      PatBlt(hdc, rcClip.right, rcClip.bottom - 1, -(rcClip.right -
             rcClip.left), 1, DSTINVERT);

      /* Format the dimensions string ...*/
      wsprintf(sz, "%dx%d", rcClip.right - rcClip.left, rcClip.bottom -
               rcClip.top);
      len = lstrlen(sz);

      /* ... and center it in the rectangle */
      dw = GetTextExtent(hdc, sz, len);
      dx = LOWORD (dw);
      dy = HIWORD (dw);
      x = (rcClip.right + rcClip.left - dx) / 2;
      y = (rcClip.bottom + rcClip.top - dy) / 2;
      hdcBits = CreateCompatibleDC(hdc);
      SetTextColor(hdcBits, 0xFFFFFFL);
      SetBkColor(hdcBits, 0x000000L);

      /* Output the text to the DC */
      if (hbm = CreateBitmap(dx, dy, 1, 1, NULL))
      {
         hbm = SelectObject(hdcBits, hbm);
         ExtTextOut(hdcBits, 0, 0, 0, NULL, sz, len, NULL);
         BitBlt(hdc, x, y, dx, dy, hdcBits, 0, 0, SRCINVERT);
         hbm = SelectObject(hdcBits, hbm);
         DeleteObject(hbm);
      }
      DeleteDC(hdcBits);
   }
}


//*************************************************************************
//
//  FUNCTION   : NormalizeRect(RECT *prc)
//
//  PURPOSE    : If the rectangle coordinates are reversed, swaps them.
//               This is used to make sure that the first coordinate of
//               our rect is the upper left, and the second is lower right.
//
// History:   Date      Author      Reason
//            9/15/91   Mark Bader  Created from SHOWDIB code
//
//*************************************************************************

void PASCAL NormalizeRect(LPRECT prc)
{
   if (prc->right  < prc->left) SWAP(prc->right,  prc->left);
   if (prc->bottom < prc->top)  SWAP(prc->bottom, prc->top);
}


//***************************************************************************
//
// Function: DoSize
//
// Purpose:  Called by WndProc() on WM_SIZE
//
//           When the window is sized -- set up the scroll bars.
//
//           The window will be repainted if the new size, combined
//           with the current scroll bar positions would create blank
//           space at the left or bottom of the window.
//
// History:  Date      Author               Reason
//           10/15/91  Garrett McAuliffe    Cut code out from WM_SIZE case.
//           12/20/91  Patrick Schreiber    Modified for WinCap (bitmap instead
//                                          of DIB)
//
//***************************************************************************

void DoSize(HWND hWnd)
{
   BITMAP      bm;                     // Bitmap info structure
   int         cxBitmap=0, cyBitmap=0; // Bitmap width and height
   int         cxScroll, cyScroll;     // Scroll positions
   RECT        rect;                   // Client rectangle

   // Check to see we are displaying a bitmap,
   // if so, then repaint if necessary
   if (ghBitmap)
      {
      // Get info about bitmap
      GetObject(ghBitmap, sizeof(BITMAP), (LPSTR)&bm);

      // Get the width and height of the bitmap
      cxBitmap = bm.bmWidth;
      cyBitmap = bm.bmHeight;

      // Find out the dimensions of the window, and the current
      // thumb positions
      GetClientRect(hWnd, &rect);

      cxScroll = GetScrollPos (hWnd, SB_HORZ);
      cyScroll = GetScrollPos (hWnd, SB_VERT);

      // If current thumb positions would cause blank space
      // at right or bottom of client area, repaint
      if (cxScroll + rect.right > cxBitmap ||
          cyScroll + rect.bottom > cyBitmap)
         InvalidateRect(hWnd, NULL, FALSE);

      // Make sure scroll bars are updated
      SetupScrollBars(hWnd, cxBitmap, cyBitmap);
      }
   else if (bStartup)
      {
      // Need to update entire client area for cool logo
      InvalidateRect(hWnd, NULL, TRUE);
      }
}


//***************************************************************************
//
// Function: ReallyGetClientRect
//
// Purpose:  Gets the rectangular area of the client rect including
//           the area underneath visible scroll bars.  Stolen from
//           ShowDIB.
//
// History:   Date      Author      Reason
//            6/1/91    Garrett McAuliffe    Created.
//
//***************************************************************************

void ReallyGetClientRect(HWND hWnd, LPRECT lpRect)
{
   DWORD dwWinStyle;

   dwWinStyle = GetWindowLong (hWnd, GWL_STYLE);

   GetClientRect (hWnd, lpRect);

   if (dwWinStyle & WS_HSCROLL)
      lpRect->bottom += (GetSystemMetrics (SM_CYHSCROLL) - 1);

   if (dwWinStyle & WS_VSCROLL)
      lpRect->right  += (GetSystemMetrics (SM_CXVSCROLL) - 1);
}


//***************************************************************************
//
// Function: SetupScrollBars
//
// Purpose:  Sets up scroll bars.
//
// History:  Date       Author                Reason
//           6/1/91     Garrett McAuliffe     Created
//           12/20/91   Patrick Schreiber     Modified for WinCap
//
//***************************************************************************

void SetupScrollBars(HWND hWnd, WORD cxBitmap, WORD cyBitmap)
{
   RECT        rect;                         // Client Rectangle
   BOOL        bNeedScrollBars=FALSE;        // Need Scroll bars?
   unsigned    cxWindow, cyWindow;           // Width and height of client area
   int         cxRange=0, cyRange=0;         // Range needed for horz and vert

   // Do some initialization
   ReallyGetClientRect(hWnd, &rect);

   cxWindow = rect.right - rect.left;
   cyWindow = rect.bottom - rect.top;

   // Now determine if we need the scroll bars
   if ((cxWindow < (unsigned)cxBitmap) || (cyWindow < (unsigned)cyBitmap))
      bNeedScrollBars = TRUE;


   /* Setup the scroll bar ranges.  We want to be able to
    * scroll the window so that all the bitmap can appear
    * within the client area.  Take into account that
    * if the opposite scroll bar is activated, it eats
    * up some client area.
    */

   if (bNeedScrollBars)
      {
      cyRange = (unsigned)cyBitmap - cyWindow - 1 +
                GetSystemMetrics (SM_CYHSCROLL);
      cxRange = (unsigned)cxBitmap - cxWindow - 1 +
                GetSystemMetrics (SM_CXVSCROLL);
      }

   // Set the ranges we've calculated (0 to 0 means invisible scrollbar)
   SetScrollRange(hWnd, SB_VERT, 0, cyRange, TRUE);
   SetScrollRange(hWnd, SB_HORZ, 0, cxRange, TRUE);
}


//**********************************************************************
//
// Function:   DoScroll()
//
// Purpose:    Called by ChildWndProc() on WM_HSCROLL and WM_VSCROLL.
//             Window needs to be scrolled (user has clicked on one
//             of the scroll bars.
//
//             Does scrolling in both horiziontal and vertical directions.
//             Note that the variables are all named as if we were
//             doing a horizontal scroll.  However, if we're doing a
//             vertical scroll, they are initialized to the appropriate
//             values for a vertical scroll.
//
//             If we scroll by one (i.e. user clicks on one of the
//             scrolling arrows), we scroll the window by 1/SCROLL_RATIO
//             of the client area.  In other words, if SCROLL_RATION==4,
//             then we move the client area over a 1/4 of the width/height
//             of the screen.
//
//             If the user is paging up/down we move a full client area's
//             worth.
//
//             If the user moves the thumb to an absolute position, we
//             just move there.
//
//             ScrollWindow/re-painting do the actual work of scrolling.
//
// History:   Date      Author               Reason
//            10/15/91  Garrett McAuliffe    Cut code out from WM_?SCROLL case.
//
//**********************************************************************

void DoScroll(HWND hWnd, int message, WORD wPos, WORD wScrollType)
{
   int  xBar;                       // Where scrollbar is now.
   int  nMin;                       // Minumum scroll bar value.
   int  nMax;                       // Maximum scroll bar value.
   int  dx;                         // How much to move.
   int  nOneUnit;                   // # of pixels for LINEUP/LINEDOWN
   int  cxClient;                   // Width of client area.
   int  nHorzOrVert;                // Doing the horizontal or vertical?
   RECT rect;                       // Client area.

   GetClientRect (hWnd, &rect);

   if (message == WM_HSCROLL)
      {
      nHorzOrVert = SB_HORZ;
      cxClient    = rect.right - rect.left;
      }
   else
      {
      nHorzOrVert = SB_VERT;
      cxClient    = rect.bottom - rect.top;
      }

      // One a SB_LINEUP/SB_LINEDOWN we will move the DIB by
      //  1/SCROLL_RATIO of the client area (i.e. if SCROLL_RATIO
      //  is 4, it will scroll the DIB a quarter of the client
      //  area's height or width.

   nOneUnit = cxClient / SCROLL_RATIO;
   if (!nOneUnit)
      nOneUnit = 1;

   xBar = GetScrollPos (hWnd, nHorzOrVert);
   GetScrollRange (hWnd, nHorzOrVert, &nMin, &nMax);

   switch (wScrollType)
      {
      case SB_LINEDOWN:             // One line right.
         dx = nOneUnit;
         break;

      case SB_LINEUP:               // One line left.
         dx = -nOneUnit;
         break;

      case SB_PAGEDOWN:             // One page right.
         dx = cxClient;
         break;

      case SB_PAGEUP:               // One page left.
         dx = -cxClient;
         break;

      case SB_THUMBPOSITION:        // Absolute position.
         dx = wPos - xBar;
         break;

      default:                      // No change.
         dx = 0;
         break;
      }

   if (dx)
      {
      xBar += dx;

      if (xBar < nMin)
         {
         dx  -= xBar - nMin;
         xBar = nMin;
         }

      if (xBar > nMax)
         {
         dx  -= xBar - nMax;
         xBar = nMax;
         }

      if (dx)
         {
         SetScrollPos (hWnd, nHorzOrVert, xBar, TRUE);

         if (nHorzOrVert == SB_HORZ)
            ScrollWindow (hWnd, -dx, 0, NULL, NULL);
         else
            ScrollWindow (hWnd, 0, -dx, NULL, NULL);

         UpdateWindow (hWnd);
         }
      }
}

//****************************************************************************
//
// Function: DoPaint()
//
// Purpose:  Called by WndProc. Does painting for client area.
//
//
// History:  Date      Author      Reason
//
//           12/20/91  Patrick Schreiber      Created
//
//***************************************************************************

void DoPaint(HWND hWnd)
{
   HDC         hDC, hMemDC;         // Handle to DC, memory DC
   PAINTSTRUCT ps;                  // Painting structure
   BITMAP      bm;                  // BITMAP structure
   HBITMAP     hOldBm;              // Handle to previous bitmap
   RECT        rectClient, rectDDB; // Client and bitmap rectangles
   int         xScroll, yScroll;    // Scroll positions
   int         x, y;                // Logo origin


   // Begin painting
   hDC = BeginPaint(hWnd, &ps);

   // Check to see if we are displaying a bitmap
   if (!ghBitmap)
      {

      // No bitmap yet, are we in start mode?
      if (bStartup)
         {
         GetClientRect(hWnd, &rectClient);

         hMemDC = CreateCompatibleDC(ps.hdc);

         // Select our logo bitmap
         hOldBm = SelectObject(hMemDC, ghbmLogo);

         GetObject(ghbmLogo, sizeof(BITMAP), (VOID FAR *)&bm);

         x = (rectClient.right - bm.bmWidth) / 2;
         y = (rectClient.bottom - bm.bmHeight) / 2;

         // Now bitblt our logo to client area
         BitBlt(ps.hdc, x, y, bm.bmWidth, bm.bmHeight,
                hMemDC, 0, 0, SRCCOPY);

         // Clean up
         SelectObject(hMemDC,hOldBm);
         DeleteDC(hMemDC);
         }
      else
         {
         // Turn off scroll bars in case they were on
         SetScrollRange (hWnd, SB_VERT, 0, 0, TRUE);
         SetScrollRange (hWnd, SB_HORZ, 0, 0, TRUE);
         }
      }
   else // We are displaying a bitmap
      {
      // Get bitmap info
      GetObject(ghBitmap, sizeof(BITMAP), (LPSTR)&bm);

      // Get scroll bar positions
      xScroll  = GetScrollPos  (hWnd, SB_HORZ);
      yScroll  = GetScrollPos  (hWnd, SB_VERT);

      // Set up the scroll bars appropriately.
      SetupScrollBars(hWnd, bm.bmWidth, bm.bmHeight);

      // Set up the necessary rectangles -- i.e. the rectangle
      //  we're rendering into, and the rectangle in the bitmap
      GetClientRect (hWnd, &rectClient);

      rectDDB.left   = xScroll;
      rectDDB.top    = yScroll;
      rectDDB.right  = xScroll + rectClient.right - rectClient.left;
      rectDDB.bottom = yScroll + rectClient.bottom - rectClient.top;

      if (rectDDB.right > bm.bmWidth)
         {
         int dx;

         dx = bm.bmWidth - rectDDB.right;

         rectDDB.right     += dx;
         rectClient.right  += dx;
         }

      if (rectDDB.bottom > bm.bmHeight)
         {
         int dy;

         dy = bm.bmHeight - rectDDB.bottom;

         rectDDB.bottom    += dy;
         rectClient.bottom += dy;
         }


      // Go do the actual painting.
      PaintBitmap(hDC, &rectClient, ghBitmap, &rectDDB, ghPal);
      }


   EndPaint(hWnd, &ps);
}
