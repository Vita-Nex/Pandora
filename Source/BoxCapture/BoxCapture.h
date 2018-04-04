// BoxCapture.h : main header file for the BoxCapture DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols


// CBoxCaptureApp
// See BoxCapture.cpp for the implementation of this class
//

class CBoxCaptureApp : public CWinApp
{
public:
	CBoxCaptureApp();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
	static HBITMAP CaptureScreen(HWND handle);
	int Test(void);
};
