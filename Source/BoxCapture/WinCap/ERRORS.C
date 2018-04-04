//
// Errors.c
//
// Contains error messages for DIBAPI.DLL
//
// These error messages all have constants associated with
// them, contained in dibapi.h.
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


#include <windows.h>
#include "dibapi.h"

static char *szErrors[] =
{
   "Not a Windows DIB file!",
   "Couldn't allocate memory!",
   "Error reading file!",
   "Error locking memory!",
   "Error opening file!",
   "Error creating palette!",
   "Error getting a DC!",
   "Error creating Device Dependent Bitmap",
   "StretchBlt() failed!",
   "StretchDIBits() failed!",
   "SetDIBitsToDevice() failed!",
   "Printer: StartDoc failed!",
   "Printing: GetModuleHandle() couldn't find GDI!",
   "Printer: SetAbortProc failed!",
   "Printer: StartPage failed!",
   "Printer: NEWFRAME failed!",
   "Printer: EndPage failed!",
   "Printer: EndDoc failed!",
   "SetDIBits() failed!",
   "File Not Found!",
   "Invalid Handle",
   "General Error on call to DIB function"
};


void FAR DIBError(int ErrNo)
{
   if ((ErrNo < ERR_MIN) || (ErrNo >= ERR_MAX))
      MessageBox(NULL, "Undefined Error!", NULL, MB_OK | MB_ICONHAND);
   else
      MessageBox(NULL, szErrors[ErrNo], NULL, MB_OK | MB_ICONHAND);
}
