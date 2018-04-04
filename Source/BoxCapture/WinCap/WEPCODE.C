// -----------------------------------------------------------------
// File name:  WEPCODE.C
//
// This is the source file that contains the DLL's Windows Exit
// Procedure (WEP).
//
// Description of functions:
//
//    WEP         -     The Windows Exit Procedure.  Every DLL must have
//                      one of these.
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
// -----------------------------------------------------------------

#include <windows.h>

// -----------------------------------------------------------------
//
// WEP()
//
// Purpose:  Called by Windows just before Windows unloads the DLL.
//
// Parameters:  int  nParameter     -  This is a dummy parameter.
//                                     Windows expects this parameter
//                                     so be sure to include it.
//
// Return Value:  Always returns 1 to indicate success.
//
// Comments:  Every DLL MUST have a WEP.  WEP, as defined here, is the
//            proper way to define a WEP; do not do anything else
//            except return 1 because the WEP is called on the Windows
//            Kernel's stack, which is very small.
//
// History:
//          Date        Author            Reason
//          1/30/92     Dan Ruder         Created
//
// -----------------------------------------------------------------

int FAR PASCAL WEP (int nParameter)
    {
    return (1);
    }
