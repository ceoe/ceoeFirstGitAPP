// d2610_vcnetDlg.h : 头文件
//

#pragma once


// Cd2610_vcnetDlg 对话框
class Cdmc2610_demoDlg : public CDialog
{
// 构造
public:
	Cdmc2610_demoDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_D2610_VCNET_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持

public:
	int		m_nUseAxis;
	long m_nStartSpeed;
	long	m_nSpeed;
	double	m_fAcc;
	int m_nDist;
// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonMove();
public:
	afx_msg void OnBnClickedButtonDelstop();
public:
	afx_msg void OnBnClickedButtonEmgstop();
public:
	afx_msg void OnBnClickedButtonClean();
public:
	afx_msg void OnBnClickedButtonClose();
public:
	afx_msg void OnBnClickedRadioOptionmoveaxis1();
public:
	afx_msg void OnBnClickedRadioOptionmoveaxis2();
public:
	afx_msg void OnBnClickedRadioOptionmoveaxis3();
public:
	afx_msg void OnBnClickedRadioOptionmoveaxis4();
public:
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};
