namespace SPFileDialog  {
  partial class SPSaveFileDialog {
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
      this.mniSave = new System.Windows.Forms.MenuItem();
      this.mniMain = new System.Windows.Forms.MenuItem();
      this.mniHome = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.btnCancel = new System.Windows.Forms.MenuItem();
      this.spFileControl = new SPFileDialog.SPFileControl();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.mniSave);
      this.mainMenu1.MenuItems.Add(this.mniMain);
      // 
      // mniSave
      // 
      this.mniSave.Text = "Save";
      this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
      // 
      // mniMain
      // 
      this.mniMain.MenuItems.Add(this.mniHome);
      this.mniMain.MenuItems.Add(this.menuItem2);
      this.mniMain.MenuItems.Add(this.menuItem1);
      this.mniMain.MenuItems.Add(this.btnCancel);
      this.mniMain.Text = "Menu";
      this.mniMain.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // mniHome
      // 
      this.mniHome.Text = "Mark Current Home";
      this.mniHome.Click += new System.EventHandler(this.mniHome_Click);
      // 
      // menuItem2
      // 
      this.menuItem2.Text = "Refresh";
      this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
      // 
      // menuItem1
      // 
      this.menuItem1.Text = "-";
      // 
      // btnCancel
      // 
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // spFileControl
      // 
      this.spFileControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spFileControl.Location = new System.Drawing.Point(0, 0);
      this.spFileControl.Name = "spFileControl";
      this.spFileControl.Size = new System.Drawing.Size(176, 180);
      this.spFileControl.TabIndex = 0;
      // 
      // SPSaveFileDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(176, 180);
      this.Controls.Add(this.spFileControl);
      this.KeyPreview = true;
      this.Menu = this.mainMenu1;
      this.Name = "SPSaveFileDialog";
      this.Text = "Save Draft";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SPSaveFileDialog_KeyDown);
      this.Load += new System.EventHandler(this.SPSaveFileDialog_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.MenuItem mniSave;
    private System.Windows.Forms.MenuItem mniMain;
    private SPFileControl spFileControl;
    private System.Windows.Forms.MenuItem mniHome;
    private System.Windows.Forms.MenuItem btnCancel;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem menuItem1;

  }
}