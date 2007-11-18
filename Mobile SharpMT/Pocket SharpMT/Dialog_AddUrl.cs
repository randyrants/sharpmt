using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Pocket_SharpMT._Objects.code;

namespace Pocket_SharpMT
{
	/// <summary>
	/// Summary description for Dialog_AddUrl.
	/// </summary>
	public class Dialog_AddUrl : System.Windows.Forms.Form
	{
    public string m_strUrl, m_strText, m_strPrefix, m_strTitle;
    private Control m_ctrlCurrent; 

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox ebText;
    private System.Windows.Forms.TextBox ebUrl;
    private System.Windows.Forms.MainMenu mainMenu1;
    private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
    public System.Windows.Forms.TextBox ebTitle;
    public System.Windows.Forms.TextBox ebTarget;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel pnlMain;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.ContextMenu mnuContext;
    private System.Windows.Forms.MenuItem mniCutPopup;
    private System.Windows.Forms.MenuItem mniCopyPopup;
    private System.Windows.Forms.MenuItem mniPastePopup;
    private System.Windows.Forms.MenuItem mniDeletePopup;
    private System.Windows.Forms.Label label1;
  
		public Dialog_AddUrl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
      
      m_ctrlCurrent = null;

      DialogResult = DialogResult.OK;
      btnOK.DialogResult = DialogResult.OK;
      btnCancel.DialogResult = DialogResult.Cancel;

      m_strUrl = "http://";
      m_strText = "";
      m_strTitle = "";
    }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.ebTitle = new System.Windows.Forms.TextBox();
      this.mnuContext = new System.Windows.Forms.ContextMenu();
      this.mniCutPopup = new System.Windows.Forms.MenuItem();
      this.mniCopyPopup = new System.Windows.Forms.MenuItem();
      this.mniPastePopup = new System.Windows.Forms.MenuItem();
      this.mniDeletePopup = new System.Windows.Forms.MenuItem();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ebText = new System.Windows.Forms.TextBox();
      this.ebUrl = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
      this.ebTarget = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.pnlMain = new System.Windows.Forms.Panel();
      this.pnlMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(165, 244);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(72, 20);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(89, 244);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(72, 20);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      // 
      // ebTitle
      // 
      this.ebTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebTitle.ContextMenu = this.mnuContext;
      this.ebTitle.Location = new System.Drawing.Point(3, 113);
      this.ebTitle.Name = "ebTitle";
      this.ebTitle.Size = new System.Drawing.Size(234, 21);
      this.ebTitle.TabIndex = 2;
      this.ebTitle.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // mnuContext
      // 
      this.mnuContext.MenuItems.Add(this.mniCutPopup);
      this.mnuContext.MenuItems.Add(this.mniCopyPopup);
      this.mnuContext.MenuItems.Add(this.mniPastePopup);
      this.mnuContext.MenuItems.Add(this.mniDeletePopup);
      this.mnuContext.Popup += new System.EventHandler(this.mnuContext_Popup);
      // 
      // mniCutPopup
      // 
      this.mniCutPopup.Text = "Cut";
      this.mniCutPopup.Click += new System.EventHandler(this.mniCutPopup_Click);
      // 
      // mniCopyPopup
      // 
      this.mniCopyPopup.Text = "Copy";
      this.mniCopyPopup.Click += new System.EventHandler(this.mniCopyPopup_Click);
      // 
      // mniPastePopup
      // 
      this.mniPastePopup.Text = "Paste";
      this.mniPastePopup.Click += new System.EventHandler(this.mniPastePopup_Click);
      // 
      // mniDeletePopup
      // 
      this.mniDeletePopup.Text = "Delete";
      this.mniDeletePopup.Click += new System.EventHandler(this.mniDeletePopup_Click);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(3, 94);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(100, 14);
      this.label3.Text = "Title:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 14);
      this.label2.Text = "Text:";
      // 
      // ebText
      // 
      this.ebText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebText.ContextMenu = this.mnuContext;
      this.ebText.Location = new System.Drawing.Point(3, 67);
      this.ebText.Name = "ebText";
      this.ebText.Size = new System.Drawing.Size(234, 21);
      this.ebText.TabIndex = 1;
      this.ebText.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // ebUrl
      // 
      this.ebUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebUrl.ContextMenu = this.mnuContext;
      this.ebUrl.Location = new System.Drawing.Point(3, 21);
      this.ebUrl.Name = "ebUrl";
      this.ebUrl.Size = new System.Drawing.Size(234, 21);
      this.ebUrl.TabIndex = 0;
      this.ebUrl.Text = "http://";
      this.ebUrl.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 2);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 14);
      this.label1.Text = "URL:";
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.menuItem1);
      // 
      // menuItem1
      // 
      this.menuItem1.Text = "";
      // 
      // ebTarget
      // 
      this.ebTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebTarget.ContextMenu = this.mnuContext;
      this.ebTarget.Location = new System.Drawing.Point(3, 159);
      this.ebTarget.Name = "ebTarget";
      this.ebTarget.Size = new System.Drawing.Size(234, 21);
      this.ebTarget.TabIndex = 3;
      this.ebTarget.GotFocus += new System.EventHandler(this.ebGeneric_GotFocus);
      this.ebTarget.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ebGeneric_KeyUp);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(3, 140);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(100, 14);
      this.label4.Text = "Target:";
      // 
      // pnlMain
      // 
      this.pnlMain.AutoScroll = true;
      this.pnlMain.Controls.Add(this.ebTitle);
      this.pnlMain.Controls.Add(this.ebText);
      this.pnlMain.Controls.Add(this.label3);
      this.pnlMain.Controls.Add(this.ebUrl);
      this.pnlMain.Controls.Add(this.label1);
      this.pnlMain.Controls.Add(this.label4);
      this.pnlMain.Controls.Add(this.ebTarget);
      this.pnlMain.Controls.Add(this.label2);
      this.pnlMain.Controls.Add(this.btnOK);
      this.pnlMain.Controls.Add(this.btnCancel);
      this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMain.Location = new System.Drawing.Point(0, 0);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(240, 268);
      // 
      // Dialog_AddUrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.pnlMain);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_AddUrl";
      this.Text = "Add URL";
      this.Load += new System.EventHandler(this.Dialog_AddUrl_Load);
      this.pnlMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
    private void Dialog_AddUrl_Load(object sender, System.EventArgs e) {
      m_strPrefix = m_strUrl;
      ebUrl.Text = m_strUrl;
      ebText.Text = m_strText;
      ebUrl.Focus();
      ebUrl.SelectionStart = m_strUrl.Length;
    }

    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK) {
        m_strUrl = ebUrl.Text;
        m_strText = ebText.Text;
        m_strTitle = ebTitle.Text;
      }      
    }

    private void ebGeneric_GotFocus(object sender, System.EventArgs e) {
      if (Dialog_Main.m_bShowSIP == true) {
        inputPanel.Enabled = true;
      }
      m_ctrlCurrent = (Control)sender;
    }

    private void ebGeneric_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) {
      // trap for control keys
      if (e.Control) {
        switch(e.KeyCode) {
          case Keys.C:
            if (mniCopyPopup.Enabled)
              EditMenuHelper.Copy();
            break;
          case Keys.X:
            if (mniCutPopup.Enabled)
              EditMenuHelper.Cut();
            break;
          case Keys.V:
            if (mniPastePopup.Enabled)
              EditMenuHelper.Paste();
            break;
        }
      }
    }

    private void mnuContext_Popup(object sender, System.EventArgs e) {
      // Find control with focus
      if (m_ctrlCurrent == null) {
        return;
      }

      TextBox activeTextBox = ((TextBox)m_ctrlCurrent);
    
      if (activeTextBox != null) {
        if (activeTextBox.SelectionLength > 0) {
          mniCutPopup.Enabled = true;
          mniCopyPopup.Enabled = true;
          mniDeletePopup.Enabled = true;
        }
        else {
          mniCutPopup.Enabled = false;
          mniCopyPopup.Enabled = false;
          mniDeletePopup.Enabled = false;
        }
        if (EditMenuHelper.ClipboardHasText()) {
          mniPastePopup.Enabled = true;
        }
        else {
          mniPastePopup.Enabled = false;
        }
      }
      else {
        mniCutPopup.Enabled = false;
        mniCopyPopup.Enabled = false;
        mniDeletePopup.Enabled = false;
        mniPastePopup.Enabled = false;
      }    
    }
    private void mniCutPopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Cut();
    }

    private void mniCopyPopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Copy();
    }

    private void mniPastePopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Paste();
    }

    private void mniDeletePopup_Click(object sender, System.EventArgs e) {
      EditMenuHelper.Clear();
    }

  }
}
