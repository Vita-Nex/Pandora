/*
 *  dibdll.h
 *
 *  Copyright (c) 1991 Microsoft Corporation. All rights reserved
 *
 *  Header file for dllinit.c, print.c, and dibapi.rc.  It includes 
 *  the declaration for ghDLLInst, a global variable which stores the 
 *  DLL's instance handle.  It also defines constants for the DLL's 
 *  printing dialog.
 */

/* Defines for the DLL's printing dialog. */

#define IDC_BOX1                    123
#define IDC_PRINTTEXT1              401
#define IDC_PRINTTEXT2              402
#define IDC_PERCENTAGE              403


/* Global variable used by the DIB API DLL */

extern HANDLE ghDLLInst;        // Initialized in dllinit.c
