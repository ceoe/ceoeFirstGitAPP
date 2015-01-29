// d2610_vcnetDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "dmc2610_demo.h"
#include "dmc2610_demoDlg.h"

#include "DMC2610.h"  //包含ｄｍｃ头文件

#pragma comment(lib,"DMC2610.lib")

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define XAXIS 0
#define YAXIS 1
#define ZAXIS 2
#define UAXIS 3



// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 对话框数据
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	

}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// Cd2610_vcnetDlg 对话框


Cdmc2610_demoDlg::Cdmc2610_demoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(Cdmc2610_demoDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	m_nUseAxis = 0; 
	m_nStartSpeed = 500;
	m_nSpeed = 1000;
	m_fAcc = 0.1;
	m_nDist = 500;
}

void Cdmc2610_demoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);

	DDX_Text(pDX, IDC_EDIT_RUNSPD, m_nSpeed);
	DDX_Text(pDX,IDC_Edit_STRSPD, m_nStartSpeed);
	DDX_Text(pDX, IDC_EDIT_Tacc, m_fAcc);
	DDX_Text(pDX, IDC_EDIT_Dist, m_nDist);
}

BEGIN_MESSAGE_MAP(Cdmc2610_demoDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON_MOVE, &Cdmc2610_demoDlg::OnBnClickedButtonMove)
	ON_BN_CLICKED(IDC_BUTTON_DelStop, &Cdmc2610_demoDlg::OnBnClickedButtonDelstop)
	ON_BN_CLICKED(IDC_BUTTON_EmgStop, &Cdmc2610_demoDlg::OnBnClickedButtonEmgstop)
	ON_BN_CLICKED(IDC_BUTTON_CLEAN, &Cdmc2610_demoDlg::OnBnClickedButtonClean)
	ON_BN_CLICKED(IDC_BUTTON_Close, &Cdmc2610_demoDlg::OnBnClickedButtonClose)
	ON_BN_CLICKED(IDC_RADIO_OptionMoveAxis1, &Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis1)
	ON_BN_CLICKED(IDC_RADIO_OptionMoveAxis2, &Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis2)
	ON_BN_CLICKED(IDC_RADIO_OptionMoveAxis3, &Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis3)
	ON_BN_CLICKED(IDC_RADIO_OptionMoveAxis4, &Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis4)
	ON_WM_TIMER()
END_MESSAGE_MAP()


// Cd2610_vcnetDlg 消息处理程序

BOOL Cdmc2610_demoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	//SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码
	WORD i=0;

	((CButton *)GetDlgItem(IDC_RADIO_OptionMoveAxis1))->SetCheck(TRUE);

	i = d2610_board_init();
	if (0 == i)
	{
		MessageBox( _T("初始化2610卡失败 !"),_T("Error"));		
	}
	else
    {	
        //设置控制卡的参数
        for (i=0; i<4; i++)
        {
             d2610_config_EL_MODE(i, 0);
             d2610_config_SD_PIN (i, 1, 0, 0);
			 d2610_set_position(i, 0);             
        }

    }

	SetTimer( 1, 100, NULL );
	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void Cdmc2610_demoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void Cdmc2610_demoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标显示。
//
HCURSOR Cdmc2610_demoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void Cdmc2610_demoDlg::OnBnClickedButtonMove()
{
	// TODO: Add your control notification handler code here

	UpdateData( true );

    d2610_set_profile(m_nUseAxis, m_nStartSpeed, m_nSpeed, m_fAcc, m_fAcc);   //设置速度、加速度

    d2610_t_pmove(m_nUseAxis, m_nDist, 0);            //作相对t型运动
}

void Cdmc2610_demoDlg::OnBnClickedButtonDelstop()
{
	// TODO: Add your control notification handler code here
	UpdateData( true );

	d2610_decel_stop(m_nUseAxis, m_fAcc);
}

void Cdmc2610_demoDlg::OnBnClickedButtonEmgstop()
{
	// TODO: Add your control notification handler code here
	 d2610_emg_stop();
}

void Cdmc2610_demoDlg::OnBnClickedButtonClean()
{
	// TODO: Add your control notification handler code here
	d2610_set_position(m_nUseAxis, 0);
}

void Cdmc2610_demoDlg::OnBnClickedButtonClose()
{
	// TODO: Add your control notification handler code here
	OnCancel();

    d2610_emg_stop();
	d2610_board_close();
}

void Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis1()
{
	// TODO: Add your control notification handler code here
	m_nUseAxis = XAXIS;
}

void Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis2()
{
	// TODO: Add your control notification handler code here
	m_nUseAxis = YAXIS;
}

void Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis3()
{
	// TODO: Add your control notification handler code here
	m_nUseAxis = ZAXIS;
}

void Cdmc2610_demoDlg::OnBnClickedRadioOptionmoveaxis4()
{
	// TODO: Add your control notification handler code here
	m_nUseAxis = UAXIS;
}

void Cdmc2610_demoDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call default

	CDialog::OnTimer(nIDEvent);
	CString string;
	CString strpos;

	long position = d2610_get_position( 0 );
	string.Format("X=%ld  ", position );
	//GetDlgItem( IDC_STATIC_XPOSITION )->SetWindowText( string );
	strpos = strpos + string;

	position = d2610_get_position( 1 );
	string.Format("Y=%ld  ", position );
	//GetDlgItem( IDC_STATIC_YPOSITION )->SetWindowText( string );
	strpos = strpos + string;

	position = d2610_get_position( 2 );
	string.Format("Z=%ld  ", position );
	//GetDlgItem( IDC_STATIC_ZPOSITION )->SetWindowText( string );
	strpos = strpos + string;
	
	position = d2610_get_position( 3 );
	string.Format("U=%ld", position );
	//GetDlgItem( IDC_STATIC_UPOSITION )->SetWindowText( string );
	strpos = strpos + string;

	GetDlgItem( IDC_STATIC_POSITION )->SetWindowText( strpos );
}
