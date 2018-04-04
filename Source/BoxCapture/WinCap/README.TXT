WINCAP Windows Screen Capture Sample Application
------------------------------------------------

Wincap Version 3.10 (second version) requires Windows 3.1 to run and the
Windows 3.1 SDK to compile and build.

DESCRIPTION:
------------

WINCAP demonstrates how to capture portions of the screen, specific windows,
or the entire screen and save it to a file or print it. This sample also
defines routines that accomplish common DIB functions, and are referred to as
the DIB API. Wincap uses the DIB API functions to do most of the
capture/printing/saving work. See the file DIBAPI.TXT for a description of the
DIB api functions.

This is the second version, which adds the following:

	- New API for displaying DIBs and Bitmaps
  - Bug Fixes:
        - Fixed calculation of bits for 15-bit display drivers
        - Fixed size of output file problem (too many bytes written out)
	- Checks for capabilities of display driver
	- Can now capture windows with menus pulled-down
	- Easier to use interface
  - Uses Windows 3.1 Common Dialogs

3.1 specific features: uses new 3.1 keyboard hook functions

OVERVIEW OF TECHNIQUE
---------------------

The preferred way to capture a screen under Windows is to copy the screen
pixels into a device-independent bitmap (DIB), and then to use this DIB in
subsequent operations (for example, to save the bitmap to a file or print the
bitmap).

If a DIB is not used in the intermediate step, the results of the screen print
may be less than desirable.

By using a DIB to hold the screen image, device-dependent information is
removed from the bitmap. This simplifies the process of displaying the image
on devices with different display capabilities. For instance, capturing a
screen from a 24-bit display adapter and printing it on a 1-bit (monochrome)
printer can be done with exceptional results if DIBs are used. Additionally,
many printer drivers implement gray scale dithering; the output on these
printers is also exceptional when DIBs are used.

    [Side Note: The BitBlt function should be avoided when printing bitmaps
    due to the device-dependency of bitmaps. The type of bitmaps that the
    BitBlt function requires are normally in the format of the display driver
    rather than the printer driver. Depending on the drivers involved, the
    results of using BitBlt to print a bitmap can vary from extrememly poor
    output quality to no output at all.

    Although all printer drivers are able to BitBlt a monochrome bitmap to
    the printer, this technique normally produces poor results because the
    printer cannot apply grayscaling to the image.]

This technique of using a DIB to convert a bitmap between display devices with
different capabilities can also be used to convert bitmaps while preserving
the original color information (for example, loading a 256-color bitmap from a
.BMP file and printing it to a 3-color printer or displaying it on a 24-bit
display).

SPECIFICS FOR THIS SAMPLE
-------------------------

This sample is an illustration of the following Windows techniques:

    - Capturing the screen (or a specific window) into a DIB
    - Capturing the screen to a Bitmap (device-dependent bitmap)
    - Printing a DIB using banding
    - Loading and Saving a DIB to a disk file (.BMP file)
    - Converting between DIBs and DDBs
    - Displaying the captured screen DDB

All of these are accomplished with calls to a simple-to-use DIB API. The DIB
API provides the following functions:

BitmapToDIB()        - Creates a DIB from a bitmap
ChangeBitmapFormat() - Changes a bitmap to a specified DIB format
ChangeDIBFormat()    - Changes a DIB's BPP and/or compression format
CopyScreenToBitmap() - Copies entire screen to a standard Bitmap
CopyScreenToDIB()    - Copies entire screen to a DIB
CopyWindowToBitmap() - Copies a window to a standard Bitmap
CopyWindowToDIB()    - Copies a window to a DIB
CreateDIBPalette()   - Creates a palette from a DIB
CreateDIB()          - Creates a new DIB
DestroyDIB()         - Deletes DIB when finished using it
DIBError()           - Displays message box with error message
DIBHeight()          - Gets the DIB height
DIBNumColors()       - Calculates number of colors in the DIB's color table
DIBToBitmap()        - Creates a bitmap from a DIB
DIBWidth()           - Gets the DIB width
FindDIBBits()        - Sets pointer to the DIB bits
GetSystemPalette()   - Gets the current palette
LoadDIB()            - Loads a DIB from a file
PaintBitmap()        - Displays standard bitmap in the specified DC
PaintDIB()           - Displays DIB in the specified DC
PalEntriesOnDevice() - Gets the number of palette entries
PaletteSize()        - Calculates the buffer size required by a palette
PrintDIB()           - Prints the specified DIB
PrintScreen()        - Prints the entire screen
PrintWindow()        - Prints all or part of a window
SaveDIB()            - Saves the specified dib in a file

The source code to these functions are included in this sample.  You can 
easily call these functions from a different application by simply compiling 
the enclosed DIBAPI.DLL, and linking with the DIBAPI.LIB import library.  
The file DIBAPI.TXT contains more information on the parameters/usage of 
these functions. A Windows Help file for the DIB APIs is also included.

NOTE: The above DIB API were not written to support OS/2-style DIBs, although
some of the utility functions (see DIBUTIL.C) will work with either Windows or
OS/2 DIBs.

SOURCE FILE LISTING
-------------------

The following files are a part of the DIB API DLL:

    copy.c      - CopyWindowToDIB, CopyScreenToDIB, CopyWindowToBitmap,
                  CopyScreenToBitmap, PaintDIB, PaintBitmap plus
                  misc utility functions
    dibapi.def  - DEF file for DIB API DLL
    dibapi.h    - Header containing constants for DIB errors and
                  prototypes for the DIB API functions
    dibapi.hlp  - Windows help file containing full DIB API reference
    dibapi.mak  - NMAKE Makefile for DIBAPI.DLL
    dibapi.rc   - Resource file for DIB API DLL
    dibapi.txt  - Documentation for DIB API functions
    dibdll.h    - Constants for DLL printing dialog
    dibutil.c   - More DIB utility functions
    dibutil.h   - DIB utility constants and macros
    dllinit.c   - Contains LibMain for DIB API DLL
    errors.c    - Defines all errors which can be returned from DIB
                  API functions
    file.c      - SaveDIB, LoadDIB, and DestroyDIB
    print.c     - PrintDIB, PrintWindow, and PrintScreen
    wepcode.c   - Contains WEP for DIB API DLL
                
The following files are for the WINCAP sample, which uses the DIB API DLL.
                
    dialogs.c   - Contains dialog routines for dialog boxes in WINCAP
    dialogs.dlg - Dialog templates for WINCAP
    dialogs.h   - Dialog constants for WINCAP
    dlgopen.c   - Contains code for "File/Save" dialog box
    hook.c      - Contains code for keyboard hook
    makefile    - NMAKE Makefile for WINCAP
    wincap.c    - Contains WinMain - this is the main program file for
                  the WINCAP sample
    wincap.def  - DEF file for WINCAP
    wincap.h    - Contains WINCAP constants
    wincap.rc   - Resource file for WINCAP

CREDITS:
--------

Development Team: Mark Bader       
                  Patrick Schreiber
                  Garrett McAuliffe  
                  Eric Flo
                  Tony Claflin
                  Dan Ruder

Written by Microsoft Product Support Services, Developer Support.
Copyright (c) 1991 Microsoft Corporation. All rights reserved.
