// dmc2610_demo.h : PROJECT_NAME Ӧ�ó������ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// Cdmc2610_demoApp:
// �йش����ʵ�֣������ dmc2610_demo.cpp
//

class Cdmc2610_demoApp : public CWinApp
{
public:
	Cdmc2610_demoApp();

// ��д
	public:
	virtual BOOL InitInstance();

// ʵ��

	DECLARE_MESSAGE_MAP()
};

extern Cdmc2610_demoApp theApp;