// BoxCapture.cpp : Defines the initialization routines for the DLL.
//

#include "stdafx.h"
#include "BoxCapture.h"
#include ".\boxcapture.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

//
//	Note!
//
//		If this DLL is dynamically linked against the MFC
//		DLLs, any functions exported from this DLL which
//		call into MFC must have the AFX_MANAGE_STATE macro
//		added at the very beginning of the function.
//
//		For example:
//
//		extern "C" BOOL PASCAL EXPORT ExportedFunction()
//		{
//			AFX_MANAGE_STATE(AfxGetStaticModuleState());
//			// normal function body here
//		}
//
//		It is very important that this macro appear in each
//		function, prior to any calls into MFC.  This means that
//		it must appear as the first statement within the 
//		function, even before any object variable declarations
//		as their constructors may generate calls into the MFC
//		DLL.
//
//		Please see MFC Technical Notes 33 and 58 for additional
//		details.
//

// CBoxCaptureApp

BEGIN_MESSAGE_MAP(CBoxCaptureApp, CWinApp)
END_MESSAGE_MAP()


// CBoxCaptureApp construction

CBoxCaptureApp::CBoxCaptureApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CBoxCaptureApp object

CBoxCaptureApp theApp;


// CBoxCaptureApp initialization

BOOL CBoxCaptureApp::InitInstance()
{
	CWinApp::InitInstance();

	return TRUE;
}

// Create a copy of the current system palette.
   HPALETTE GetSystemPalette()
   {
       HDC hDC;
       HPALETTE hPal;
       HANDLE hLogPal;
       LPLOGPALETTE lpLogPal;


       // Get a DC for the desktop.
       hDC = GetDC(NULL);

       // Check to see if you are a running in a palette-based video mode.
       if (!(GetDeviceCaps(hDC, RASTERCAPS) & RC_PALETTE)) {
           ReleaseDC(NULL, hDC);
           return NULL;
       }

       // Allocate memory for the palette.
       lpLogPal = (LPLOGPALETTE) GlobalAlloc(GPTR, sizeof(LOGPALETTE) + 256 *
                              sizeof(PALETTEENTRY));
       if (!lpLogPal)
         return NULL;

       // Initialize.
       lpLogPal->palVersion = 0x300;
       lpLogPal->palNumEntries = 256;

       // Copy the current system palette into the logical palette.
       GetSystemPaletteEntries(hDC, 0, 256,
           (LPPALETTEENTRY)(lpLogPal->palPalEntry));

       // Create the palette.
       hPal = CreatePalette(lpLogPal);

       // Clean up.
       GlobalFree(lpLogPal);
       ReleaseDC(NULL, hDC);

       return hPal;
   }

HBITMAP CaptureWindow( HWND handle )
{
	if ( ! IsWindow( handle ) )
	{
		return 0;
	}

   RECT rect;
   HDC hDC = GetWindowDC( handle );
   GetWindowRect(handle, (LPRECT) &rect);

   BITMAPINFO bmi;
       HBITMAP hbm;
       LPBYTE pBits;

       // Initialize to 0s.
       ZeroMemory(&bmi, sizeof(bmi));

       // Initialize the header.
       bmi.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
       bmi.bmiHeader.biWidth = rect.right;
       bmi.bmiHeader.biHeight = rect.bottom;
       bmi.bmiHeader.biPlanes = 1;
       bmi.bmiHeader.biBitCount = 24;
       bmi.bmiHeader.biCompression = BI_RGB;

	   SetForegroundWindow( handle );
	   UpdateWindow( handle );

       // Create the surface.
       hbm = CreateDIBSection(hDC, &bmi, DIB_RGB_COLORS, (void**) &pBits, NULL, 0);

	   HDC memDC = CreateCompatibleDC( hDC );
	   SelectObject( memDC, hbm );

	   HPALETTE hPal = GetSystemPalette();

	   if ( hPal )
	   {
		   // Apply the palette to the source DC.
           SelectPalette(hDC, hPal, FALSE);
           RealizePalette(hDC);

           // Apply the palette to the destination DC.
           SelectPalette(memDC, hPal, FALSE);
           RealizePalette(memDC);
	   }

	   // Copy the window contents to the memory surface.
       BitBlt(memDC, 0, 0, rect.right, rect.bottom,
           hDC, 0, 0, SRCCOPY);

	   DeleteDC(memDC);
       ReleaseDC(handle, hDC);

	   if (hPal)
           DeleteObject(hPal);

	   return hbm;
}
