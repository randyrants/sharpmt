namespace Phone_SharpMT {
  partial class Dialog_Upload {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MainMenu mainMenu1;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.btnOK = new System.Windows.Forms.MenuItem();
      this.btnCancel = new System.Windows.Forms.MenuItem();
      this.lblLocal = new System.Windows.Forms.Label();
      this.ebLocal = new System.Windows.Forms.TextBox();
      this.btnBrowse = new System.Windows.Forms.LinkLabel();
      this.lblRemote = new System.Windows.Forms.Label();
      this.ebRemote = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.urlLabel = new System.Windows.Forms.Label();
      this.ckbInsert = new System.Windows.Forms.CheckBox();
      this.lblAltTag = new System.Windows.Forms.Label();
      this.ebAltTag = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.btnOK);
      this.mainMenu1.MenuItems.Add(this.btnCancel);
      // 
      // btnOK
      // 
      this.btnOK.Text = "Done";
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // lblLocal
      // 
      this.lblLocal.Location = new System.Drawing.Point(3, 0);
      this.lblLocal.Name = "lblLocal";
      this.lblLocal.Size = new System.Drawing.Size(170, 15);
      this.lblLocal.Text = "Select an image to upload:";
      // 
      // ebLocal
      // 
      this.ebLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebLocal.Location = new System.Drawing.Point(3, 17);
      this.ebLocal.Name = "ebLocal";
      this.ebLocal.Size = new System.Drawing.Size(146, 22);
      this.ebLocal.TabIndex = 0;
      // 
      // btnBrowse
      // 
      this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowse.BackColor = System.Drawing.SystemColors.Control;
      this.btnBrowse.Location = new System.Drawing.Point(155, 17);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(18, 22);
      this.btnBrowse.TabIndex = 1;
      this.btnBrowse.Text = "...";
      this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // lblRemote
      // 
      this.lblRemote.Location = new System.Drawing.Point(3, 42);
      this.lblRemote.Name = "lblRemote";
      this.lblRemote.Size = new System.Drawing.Size(170, 15);
      this.lblRemote.Text = "The path of the remote image:";
      // 
      // ebRemote
      // 
      this.ebRemote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebRemote.Location = new System.Drawing.Point(3, 59);
      this.ebRemote.Name = "ebRemote";
      this.ebRemote.Size = new System.Drawing.Size(170, 22);
      this.ebRemote.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 84);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(170, 15);
      this.label1.Text = "Relative path, to the Blog URL:";
      // 
      // urlLabel
      // 
      this.urlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.urlLabel.Location = new System.Drawing.Point(3, 98);
      this.urlLabel.Name = "urlLabel";
      this.urlLabel.Size = new System.Drawing.Size(170, 31);
      // 
      // ckbInsert
      // 
      this.ckbInsert.Checked = true;
      this.ckbInsert.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbInsert.Location = new System.Drawing.Point(3, 132);
      this.ckbInsert.Name = "ckbInsert";
      this.ckbInsert.Size = new System.Drawing.Size(152, 22);
      this.ckbInsert.TabIndex = 3;
      this.ckbInsert.Text = "Insert IMG tag with SRC";
      // 
      // lblAltTag
      // 
      this.lblAltTag.Location = new System.Drawing.Point(0, 162);
      this.lblAltTag.Name = "lblAltTag";
      this.lblAltTag.Size = new System.Drawing.Size(33, 14);
      this.lblAltTag.Text = "ALT:";
      // 
      // ebAltTag
      // 
      this.ebAltTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ebAltTag.Location = new System.Drawing.Point(39, 158);
      this.ebAltTag.Name = "ebAltTag";
      this.ebAltTag.Size = new System.Drawing.Size(134, 22);
      this.ebAltTag.TabIndex = 4;
      // 
      // Dialog_Upload
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(176, 180);
      this.Controls.Add(this.ckbInsert);
      this.Controls.Add(this.ebRemote);
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.ebAltTag);
      this.Controls.Add(this.ebLocal);
      this.Controls.Add(this.urlLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblAltTag);
      this.Controls.Add(this.lblRemote);
      this.Controls.Add(this.lblLocal);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Upload";
      this.Text = "Dialog_Upload";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.Dialog_Upload_Closing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblLocal;
    public System.Windows.Forms.TextBox ebLocal;
    private System.Windows.Forms.LinkLabel btnBrowse;
    private System.Windows.Forms.Label lblRemote;
    public System.Windows.Forms.TextBox ebRemote;
    private System.Windows.Forms.Label label1;
    public System.Windows.Forms.Label urlLabel;
    public System.Windows.Forms.TextBox ebAltTag;
    private System.Windows.Forms.MenuItem btnOK;
    private System.Windows.Forms.MenuItem btnCancel;
    public System.Windows.Forms.CheckBox ckbInsert;
    public System.Windows.Forms.Label lblAltTag;
  }
}