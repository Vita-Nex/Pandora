// -----------------------------------------------------------------
// File name:  DLLINIT.C
//
// This is the DLL's initialization source file.  It contains LibMain,
// the DLL's entry point.
//
// Description of functions:
//
//    LibMain     -     This DLL's entry point.  Analogous to WinMain.
//
//
// Development Team:  Dan Ruder
//
// Written by Microsoft Product Support Services, Windows Developer Support.
//
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
//
// History:
//          Date        Author         Reason
//          1/30/92     Dan Ruder      Created
//
// -----------------------------------------------------------------


#include <windows.h>
#include "dibdll.h"

HANDLE ghDLLInst;       // Handle to the DLL's instance.

// -----------------------------------------------------------------
//
// LibMain ()
//
// Purpose:  This is the DLL's entry point.  It is analogous to WinMain
//           for applications.
//
// Parameters: HANDLE   hInstance   -  The handle to the DLL's instance.
//             WORD     wDataSeg    -  Basically it is a pointer to the DLL's
//                                     data segment.
//             WORD     wHeapSize   -  Size of the DLL's heap in bytes.
//             LPSTR    lpszCmdLine -  The command line passed to the DLL
//                                     by Windows.  This is rarely used.
//
// Return Value:  1 indicating DLL initialization is successful.
//
// Comments:   LibMain is called by Windows.  Do not call it in your
//             application!
// -----------------------------------------------------------------

int FAR PASCAL LibMain (HANDLE hInstance,
                        WORD   wDataSeg,
                        WORD   wHeapSize,
                        LPSTR  lpszCmdLine)
   {
   ghDLLInst = hInstance;  // Save the instance handle for later use.

   if (wHeapSize != 0)   // Unlock the data segment
      UnlockData (0);

   return (1);
   }

