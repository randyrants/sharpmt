namespace SharpMT.Forms
{
  partial class InsertPlugInDataForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertPlugInDataForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.goButton = new System.Windows.Forms.Button();
      this.textBoxThree = new System.Windows.Forms.TextBox();
      this.textBoxTwo = new System.Windows.Forms.TextBox();
      this.textBoxOne = new System.Windows.Forms.TextBox();
      this.labelThree = new System.Windows.Forms.Label();
      this.labelTwo = new System.Windows.Forms.Label();
      this.labelOne = new System.Windows.Forms.Label();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.listBoxResults = new System.Windows.Forms.ListBox();
      this.textBoxResults = new System.Windows.Forms.TextBox();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusStripPanelMain = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.statusStripPanelVersion = new System.Windows.Forms.ToolStripStatusLabel();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.goButton);
      this.groupBox1.Controls.Add(this.textBoxThree);
      this.groupBox1.Controls.Add(this.textBoxTwo);
      this.groupBox1.Controls.Add(this.textBoxOne);
      this.groupBox1.Controls.Add(this.labelThree);
      this.groupBox1.Controls.Add(this.labelTwo);
      this.groupBox1.Controls.Add(this.labelOne);
      this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.groupBox1.Location = new System.Drawing.Point(13, 13);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(512, 103);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Plug-In parameters";
      // 
      // goButton
      // 
      this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.goButton.Location = new System.Drawing.Point(449, 71);
      this.goButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.goButton.Name = "goButton";
      this.goButton.Size = new System.Drawing.Size(57, 23);
      this.goButton.TabIndex = 6;
      this.goButton.Text = "Go";
      this.goButton.Click += new System.EventHandler(this.goButton_Click);
      // 
      // textBoxThree
      // 
      this.textBoxThree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxThree.Location = new System.Drawing.Point(93, 74);
      this.textBoxThree.Name = "textBoxThree";
      this.textBoxThree.Size = new System.Drawing.Size(349, 20);
      this.textBoxThree.TabIndex = 5;
      this.textBoxThree.Visible = false;
      // 
      // textBoxTwo
      // 
      this.textBoxTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxTwo.Location = new System.Drawing.Point(93, 47);
      this.textBoxTwo.Name = "textBoxTwo";
      this.textBoxTwo.Size = new System.Drawing.Size(349, 20);
      this.textBoxTwo.TabIndex = 3;
      this.textBoxTwo.Visible = false;
      // 
      // textBoxOne
      // 
      this.textBoxOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxOne.Location = new System.Drawing.Point(93, 20);
      this.textBoxOne.Name = "textBoxOne";
      this.textBoxOne.Size = new System.Drawing.Size(349, 20);
      this.textBoxOne.TabIndex = 1;
      this.textBoxOne.Visible = false;
      // 
      // labelThree
      // 
      this.labelThree.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.labelThree.Location = new System.Drawing.Point(7, 78);
      this.labelThree.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.labelThree.Name = "labelThree";
      this.labelThree.Size = new System.Drawing.Size(79, 16);
      this.labelThree.TabIndex = 4;
      this.labelThree.Text = "labelThree";
      this.labelThree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelThree.Visible = false;
      // 
      // labelTwo
      // 
      this.labelTwo.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.labelTwo.Location = new System.Drawing.Point(7, 51);
      this.labelTwo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
      this.labelTwo.Name = "labelTwo";
      this.labelTwo.Size = new System.Drawing.Size(79, 16);
      this.labelTwo.TabIndex = 2;
      this.labelTwo.Text = "labelTwo";
      this.labelTwo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelTwo.Visible = false;
      // 
      // labelOne
      // 
      this.labelOne.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.labelOne.Location = new System.Drawing.Point(7, 24);
      this.labelOne.Name = "labelOne";
      this.labelOne.Size = new System.Drawing.Size(79, 16);
      this.labelOne.TabIndex = 0;
      this.labelOne.Text = "labelOne";
      this.labelOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelOne.Visible = false;
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(450, 318);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 3;
      this.cancelButton.Text = "Cancel";
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(368, 318);
      this.okButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 2;
      this.okButton.Text = "OK";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.listBoxResults);
      this.groupBox2.Controls.Add(this.textBoxResults);
      this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.groupBox2.Location = new System.Drawing.Point(13, 123);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(512, 187);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Results";
      // 
      // listBoxResults
      // 
      this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.listBoxResults.FormattingEnabled = true;
      this.listBoxResults.HorizontalScrollbar = true;
      this.listBoxResults.IntegralHeight = false;
      this.listBoxResults.Location = new System.Drawing.Point(7, 20);
      this.listBoxResults.Name = "listBoxResults";
      this.listBoxResults.Size = new System.Drawing.Size(499, 161);
      this.listBoxResults.TabIndex = 0;
      this.listBoxResults.DoubleClick += new System.EventHandler(this.listBoxResults_DoubleClick);
      // 
      // textBoxResults
      // 
      this.textBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxResults.Location = new System.Drawing.Point(7, 20);
      this.textBoxResults.Multiline = true;
      this.textBoxResults.Name = "textBoxResults";
      this.textBoxResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxResults.Size = new System.Drawing.Size(499, 161);
      this.textBoxResults.TabIndex = 0;
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripPanelMain,
            this.toolStripProgressBar,
            this.statusStripPanelVersion});
      this.statusStrip.Location = new System.Drawing.Point(0, 348);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(537, 22);
      this.statusStrip.TabIndex = 4;
      this.statusStrip.Text = "statusStrip1";
      // 
      // statusStripPanelMain
      // 
      this.statusStripPanelMain.AutoSize = false;
      this.statusStripPanelMain.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.statusStripPanelMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.statusStripPanelMain.Name = "statusStripPanelMain";
      this.statusStripPanelMain.Size = new System.Drawing.Size(522, 17);
      this.statusStripPanelMain.Spring = true;
      this.statusStripPanelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripProgressBar
      // 
      this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripProgressBar.AutoSize = false;
      this.toolStripProgressBar.Name = "toolStripProgressBar";
      this.toolStripProgressBar.Size = new System.Drawing.Size(110, 16);
      this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.toolStripProgressBar.Visible = false;
      // 
      // statusStripPanelVersion
      // 
      this.statusStripPanelVersion.AutoSize = false;
      this.statusStripPanelVersion.Name = "statusStripPanelVersion";
      this.statusStripPanelVersion.Size = new System.Drawing.Size(110, 17);
      // 
      // InsertPlugInDataForm
      // 
      this.AcceptButton = this.goButton;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(537, 370);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.statusStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InsertPlugInDataForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Insert Plug-In Data";
      this.Load += new System.EventHandler(this.InsertPlugInDataForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    internal System.Windows.Forms.TextBox textBoxOne;
    internal System.Windows.Forms.TextBox textBoxThree;
    internal System.Windows.Forms.TextBox textBoxTwo;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button goButton;
    internal System.Windows.Forms.Label labelOne;
    internal System.Windows.Forms.Label labelThree;
    internal System.Windows.Forms.Label labelTwo;
    internal System.Windows.Forms.ListBox listBoxResults;
    internal System.Windows.Forms.TextBox textBoxResults;
    private System.Windows.Forms.StatusStrip statusStrip;
    internal System.Windows.Forms.ToolStripStatusLabel statusStripPanelMain;
    internal System.Windows.Forms.ToolStripStatusLabel statusStripPanelVersion;
    private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
  }
}