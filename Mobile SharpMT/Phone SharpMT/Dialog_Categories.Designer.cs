namespace Phone_SharpMT {
  partial class Dialog_Categories {
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
      this.lblLabel = new System.Windows.Forms.Label();
      this.lblPrimary = new System.Windows.Forms.Label();
      this.lvCategories = new System.Windows.Forms.ListView();
      this.lvcDrafts = new System.Windows.Forms.ColumnHeader();
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
      // lblLabel
      // 
      this.lblLabel.Location = new System.Drawing.Point(3, 0);
      this.lblLabel.Name = "lblLabel";
      this.lblLabel.Size = new System.Drawing.Size(50, 15);
      this.lblLabel.Text = "Primary:";
      // 
      // lblPrimary
      // 
      this.lblPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPrimary.Location = new System.Drawing.Point(59, 0);
      this.lblPrimary.Name = "lblPrimary";
      this.lblPrimary.Size = new System.Drawing.Size(114, 15);
      // 
      // lvCategories
      // 
      this.lvCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lvCategories.CheckBoxes = true;
      this.lvCategories.Columns.Add(this.lvcDrafts);
      this.lvCategories.FullRowSelect = true;
      this.lvCategories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvCategories.Location = new System.Drawing.Point(3, 18);
      this.lvCategories.Name = "lvCategories";
      this.lvCategories.Size = new System.Drawing.Size(170, 159);
      this.lvCategories.TabIndex = 3;
      this.lvCategories.View = System.Windows.Forms.View.Details;
      // 
      // lvcDrafts
      // 
      this.lvcDrafts.Text = "Categories";
      this.lvcDrafts.Width = 167;
      // 
      // Dialog_Categories
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(176, 180);
      this.Controls.Add(this.lvCategories);
      this.Controls.Add(this.lblPrimary);
      this.Controls.Add(this.lblLabel);
      this.Menu = this.mainMenu1;
      this.Name = "Dialog_Categories";
      this.Text = "Select Categories";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblLabel;
    public System.Windows.Forms.Label lblPrimary;
    public System.Windows.Forms.ListView lvCategories;
    private System.Windows.Forms.ColumnHeader lvcDrafts;
    private System.Windows.Forms.MenuItem btnOK;
    private System.Windows.Forms.MenuItem btnCancel;
  }
}