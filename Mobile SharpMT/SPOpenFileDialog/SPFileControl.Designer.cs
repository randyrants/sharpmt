namespace SPFileDialog {
  partial class SPFileControl {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPFileControl));
      this.folderList = new System.Windows.Forms.ListView();
      this.nameColumn = new System.Windows.Forms.ColumnHeader();
      this.imageList = new System.Windows.Forms.ImageList();
      this.currentDirectory = new System.Windows.Forms.Label();
      this.filenamePanel = new System.Windows.Forms.Panel();
      this.fileName = new System.Windows.Forms.TextBox();
      this.filenamePanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // folderList
      // 
      this.folderList.Columns.Add(this.nameColumn);
      this.folderList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.folderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.folderList.Location = new System.Drawing.Point(0, 15);
      this.folderList.Name = "folderList";
      this.folderList.Size = new System.Drawing.Size(150, 113);
      this.folderList.SmallImageList = this.imageList;
      this.folderList.TabIndex = 1;
      this.folderList.View = System.Windows.Forms.View.List;
      this.folderList.SelectedIndexChanged += new System.EventHandler(this.folderList_SelectedIndexChanged);
      // 
      // nameColumn
      // 
      this.nameColumn.Text = "Name";
      this.nameColumn.Width = 500;
      this.imageList.Images.Clear();
      this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
      this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
      // 
      // currentDirectory
      // 
      this.currentDirectory.Dock = System.Windows.Forms.DockStyle.Top;
      this.currentDirectory.Location = new System.Drawing.Point(0, 0);
      this.currentDirectory.Name = "currentDirectory";
      this.currentDirectory.Size = new System.Drawing.Size(150, 15);
      // 
      // filenamePanel
      // 
      this.filenamePanel.Controls.Add(this.fileName);
      this.filenamePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.filenamePanel.Location = new System.Drawing.Point(0, 128);
      this.filenamePanel.Name = "filenamePanel";
      this.filenamePanel.Size = new System.Drawing.Size(150, 22);
      // 
      // fileName
      // 
      this.fileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.fileName.Location = new System.Drawing.Point(0, 0);
      this.fileName.Name = "fileName";
      this.fileName.Size = new System.Drawing.Size(150, 22);
      this.fileName.TabIndex = 0;
      this.fileName.LostFocus += new System.EventHandler(this.fileName_LostFocus);
      this.fileName.GotFocus += new System.EventHandler(this.fileName_GotFocus);
      // 
      // SPFileControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.folderList);
      this.Controls.Add(this.filenamePanel);
      this.Controls.Add(this.currentDirectory);
      this.Name = "SPFileControl";
      this.filenamePanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ColumnHeader nameColumn;
    private System.Windows.Forms.ImageList imageList;
    internal System.Windows.Forms.ListView folderList;
    private System.Windows.Forms.Label currentDirectory;
    private System.Windows.Forms.Panel filenamePanel;
    internal System.Windows.Forms.TextBox fileName;
  }
}
