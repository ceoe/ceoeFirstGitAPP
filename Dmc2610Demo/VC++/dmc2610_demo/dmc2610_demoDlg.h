// d2610_vcnetDlg.h : ͷ�ļ�
//

#pragma once


// Cd2610_vcnetDlg �Ի���
class Cdmc2610_demoDlg : public CDialog
{
// ����
public:
	Cdmc2610_demoDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_D2610_VCNET_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��

public:
	int		m_nUseAxis;
	long m_nStartSpeed;
	long	m_nSpeed;
	double	m_fAcc;
	int m_nDist;
// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
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
