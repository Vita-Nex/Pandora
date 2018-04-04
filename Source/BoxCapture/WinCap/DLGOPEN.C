//**************************************************************************
//
// MODULE  : DLGOPEN.C 
//
// Routine to display a standard COMMDLG File/Save dialog box.
//
// Defines the following functions:
// 
// GetFileName()     - Calls up common dialog file/save, and returns
//                     selected file
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
//**************************************************************************/

#include <windows.h>
#include "wincap.h"
#include "dialogs.h"
#include "commdlg.h"  // For common dialogs
#include "dlgs.h"     // For common dialog hook proc

#define MAXFILENAMELEN 144

extern HANDLE ghInst;

BOOL FAR PASCAL FileSaveHookProc (HWND hDlg, WORD msg, WORD wParam, LONG lParam);

//************************************************************************
// Function:  GetFileName (HWND, LPSTR, LPDWORD)
//
//   Purpose:  Prompts user for a filename through the use of a Windows 3.1
//             FileOpen common dialog box.
//
//Parameters:  HWND hWndOwner      Owner who is calling this funciton
//
//             LPSTR szFileName    Buffer where selected filename will
//                                 be placed.  Must be at least MAXFILENAMELEN
//                                 characters large
//
//             LPDWORD dwFlags     HIWORD is the bits per pixel, LOWORD
//                                 is compression type.
//
//   Returns:  TRUE if a filename is selected.
//             FALSE if no filename is selected.
//
//  Comments:  Filename is put into the string passed to the routine.
//             If a filename is not selected, NULL is returned.
//  History: 
//    Date      Author            Reason
//   06/01/91  Garrett McAuliffe  Created         
//   06/27/91  Eric Flo           Changed OPENFILENAME structure to      
//                                support customized common dialog box      
//   11/21/91  Eric Flo           Changed szFilter to work for NT.      
//   03/09/92  Mark Bader         Added wFlags Parameter so we don't      
//                                have to use globals, changed for WINCAP.      
//
//************************************************************************/

BOOL GetFileName (HWND hWndOwner, LPSTR szFileName, LPDWORD dwFlags)
{
   OPENFILENAME   of;
   FARPROC        fpDlgFunc;           // far proc to dlg function
   DWORD          flags;
   static char    szTitle[50];         // Dialog Box title
   static char    szFile[MAXFILENAMELEN];         // File name
   DWORD          dw = 0;               // Local copy of flags for validation
   BOOL           bReturn;             // Return code
   DWORD          dwLocalOpt;

   // Parameter validation -- try to recover gracefully if LPWORD
   // is NULL, so we don't die when we try to do a *wFlags = x below

   if (dwFlags == NULL)
     dwFlags = &dw;

   dwLocalOpt = *dwFlags;  // Make local copy of options

   // Initialize the OPENFILENAME members

   lstrcpy(szFile, "*.BMP");

   LoadString(ghInst, IDS_SAVEASTITLE, (LPSTR)szTitle, 50);

   fpDlgFunc = (FARPROC) MakeProcInstance(FileSaveHookProc, ghInst);

   flags = OFN_ENABLEHOOK | OFN_ENABLETEMPLATE | OFN_HIDEREADONLY |
           OFN_OVERWRITEPROMPT;

   of.lStructSize       = sizeof (OPENFILENAME);
   of.hwndOwner         = hWndOwner;
   of.hInstance         = ghInst;
   of.lpstrFilter       = (LPSTR)"Bitmaps (*.BMP)\0*.TXT\0";
   of.lpstrCustomFilter = NULL;
   of.nMaxCustFilter    = 0L;
   of.nFilterIndex      = 1L;
   of.lpstrFile         = (LPSTR)szFile;
   of.nMaxFile          = MAXFILENAMELEN;
   of.lpstrFileTitle    = NULL;
   of.nMaxFileTitle     = 0;
   of.lpstrInitialDir   = NULL;
   of.lpstrTitle        = szTitle;
   of.Flags             = flags;
   of.nFileOffset       = 0;
   of.nFileExtension    = 0;
   of.lpstrDefExt       = "bmp";
   of.lpfnHook          = fpDlgFunc;
   of.lpTemplateName    = (LPSTR)"FILESAVE";

   // Place our flags in the lCustData parameter
   of.lCustData         = dwLocalOpt;

   // Call the GetSaveFilename function

    if (GetSaveFileName (&of))
      {

      // User pressed OK, continue on
      bReturn = TRUE;

      // Copy filename out
      lstrcpy (szFileName, of.lpstrFile);

      // Copy flags out
      *dwFlags = of.lCustData;

      }
      else
      {
        bReturn = FALSE;
        szFileName[0] = '\0';
        *dwFlags = 0;
        }

    FreeProcInstance (fpDlgFunc);
    return bReturn;

}


/*************************************************************************

  Function:  FileSaveHookProc (HWND, WORD, WORD, LONG)

   Purpose:  Hook procedure for FileSave common dialog box.

   Returns:  TRUE if message was processed.
             FALSE if the system needs to process the message.

  Comments:

   History: 

      Date      Author          Reason

     07/08/91   Eric Flo        Created (SHOWDIB sample)
     11/20/91   Eric Flo        Fixed bug in save.as radio buttons        
     03/09/92   Mark Bader      Used lCustData rather than global DIB info

*************************************************************************/

BOOL FAR PASCAL FileSaveHookProc (HWND hDlg, WORD msg, WORD wParam, LONG lParam)
{
  HWND      hGroup;
  RECT      rect, DlgRect;
  static LPOPENFILENAME lpOpenFn;

  static    DWORD dwFlags;

  switch (msg)
    {
    case WM_INITDIALOG:

        //  Get the memory handle stored in the extra words.
        //  From this, insert the filename, and the file format

        // Retrieve flags which we passed in in lCustData
        lpOpenFn = (LPOPENFILENAME)lParam;
        dwFlags = lpOpenFn->lCustData; 

        // Our dwFlags field contains the following:
        //
        // HIWORD: Bits per pixel specification.  Should be set to
        //    one of the following: 1, 4, 8, or 24
        //
        // LOWORD: Compression specification:  Should be set to one of
        //    the following:   IDD_RGB, IDD_RLE4, IDD_RLE8

        switch (LOWORD(dwFlags))
          {
          case IDD_RGB:
            SendDlgItemMessage (hDlg, IDD_RGB,  BM_SETCHECK, 1, 0L);
            SendMessage (hDlg, WM_COMMAND, IDD_RGB, 0L);
            break;

          case IDD_RLE4:
            SendDlgItemMessage (hDlg, IDD_RLE4, BM_SETCHECK, 1, 0L);
            SendMessage (hDlg, WM_COMMAND, IDD_RLE4, 0L);
            break;

          case IDD_RLE8:
          default:
            SendDlgItemMessage (hDlg, IDD_RLE8, BM_SETCHECK, 1, 0L);
            SendMessage (hDlg, WM_COMMAND, IDD_RLE8, 0L);
            break;
          }

        switch (HIWORD(dwFlags))
          {

          case 4:
            SendDlgItemMessage (hDlg, IDD_4,   BM_SETCHECK, 1, 0L);
            break;

          case 8:
            SendDlgItemMessage (hDlg, IDD_8,   BM_SETCHECK, 1, 0L);
            break;

          case 24:
            SendDlgItemMessage (hDlg, IDD_24,  BM_SETCHECK, 1, 0L);
            break;

          case 1:
          default:
            SendDlgItemMessage (hDlg, IDD_1,   BM_SETCHECK, 1, 0L);
            break;
          }

        // Return 1 so Windows sets focus on a control in our
        // dialog.
        return 1;

        break;

    case WM_COMMAND:
        switch (wParam)
          {
          case IDOK:
            {
            WORD biStyle, biBits;

            if (SendDlgItemMessage (hDlg, IDD_RGB, BM_GETCHECK, 0, 0L))
               biStyle = IDD_RGB;

            else if (SendDlgItemMessage (hDlg, IDD_RLE4, BM_GETCHECK, 0, 0L))
               biStyle = IDD_RLE4;

            else 
               biStyle = IDD_RLE8;

            if (SendDlgItemMessage (hDlg, IDD_1, BM_GETCHECK, 0, 0L))
               biBits = 1;

            else if (SendDlgItemMessage (hDlg, IDD_4, BM_GETCHECK, 0, 0L))
               biBits = 4;

            else if (SendDlgItemMessage (hDlg, IDD_8, BM_GETCHECK, 0, 0L))
               biBits = 8;

            else
               biBits = 24;

            // Copy result of user input to our lCustData field, which
            // will pass it back to the calling function.

            lpOpenFn->lCustData = MAKELONG(biStyle, biBits);
            }

            break;

          case IDD_FILETYPE:
            hGroup = GetDlgItem (hDlg, IDD_FILETYPEGROUP);
            GetWindowRect (hGroup, &rect);
            GetWindowRect (hDlg, &DlgRect);
            SetWindowPos (hDlg,0, DlgRect.left, DlgRect.top,
                         (DlgRect.right-DlgRect.left),
                          (rect.bottom+(rect.left-DlgRect.left)-DlgRect.top),
                          SWP_NOMOVE | SWP_NOZORDER);
            EnableWindow (GetDlgItem (hDlg, IDD_FILETYPE), 0);
            SetFocus (hGroup);
            break;

          case IDD_RLE4:
            if (SendDlgItemMessage (hDlg, IDD_1, BM_GETCHECK, 0, 0L))
               SendDlgItemMessage (hDlg, IDD_1, BM_SETCHECK, 0,0L);
            if (SendDlgItemMessage (hDlg, IDD_8, BM_GETCHECK, 0, 0L))
               SendDlgItemMessage (hDlg, IDD_8, BM_SETCHECK, 0,0L);
            if (SendDlgItemMessage (hDlg, IDD_24, BM_GETCHECK, 0, 0L))
               SendDlgItemMessage (hDlg, IDD_24, BM_SETCHECK, 0,0L);

            EnableWindow (GetDlgItem(hDlg, IDD_4), 1);
            SendDlgItemMessage (hDlg, IDD_4, BM_SETCHECK, 1, 0L);
            EnableWindow (GetDlgItem(hDlg, IDD_1), 0);
            EnableWindow (GetDlgItem(hDlg, IDD_8), 0);
            EnableWindow (GetDlgItem(hDlg, IDD_24), 0);
            break;

          case IDD_RLE8:
            if (SendDlgItemMessage (hDlg, IDD_1, BM_GETCHECK, 0, 0L))
               SendDlgItemMessage (hDlg, IDD_1, BM_SETCHECK, 0,0L);
            if (SendDlgItemMessage (hDlg, IDD_4, BM_GETCHECK, 0, 0L))
               SendDlgItemMessage (hDlg, IDD_4, BM_SETCHECK, 0,0L);
            if (SendDlgItemMessage (hDlg, IDD_24, BM_GETCHECK, 0, 0L))
               SendDlgItemMessage (hDlg, IDD_24, BM_SETCHECK, 0,0L);

            EnableWindow (GetDlgItem(hDlg, IDD_8), 1);
            SendDlgItemMessage (hDlg, IDD_8, BM_SETCHECK, 1, 0L);
            EnableWindow (GetDlgItem(hDlg, IDD_1), 0);
            EnableWindow (GetDlgItem(hDlg, IDD_4), 0);
            EnableWindow (GetDlgItem(hDlg, IDD_24), 0);
            break;

          case IDD_RGB:
            EnableWindow (GetDlgItem(hDlg, IDD_1), 1);
            EnableWindow (GetDlgItem(hDlg, IDD_4), 2);
            EnableWindow (GetDlgItem(hDlg, IDD_8), 3);
            EnableWindow (GetDlgItem(hDlg, IDD_24), 1);
            break;
          }
        break;

    default:
      break;
    }
  return FALSE;
}
