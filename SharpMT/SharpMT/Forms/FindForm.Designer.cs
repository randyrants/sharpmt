namespace SharpMT.Forms
{
  partial class FindForm
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
      this.cancelButton = new System.Windows.Forms.Button();
      this.findButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.findWhat = new System.Windows.Forms.TextBox();
      this.matchWholeWord = new System.Windows.Forms.CheckBox();
      this.matchCase = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.findDown = new System.Windows.Forms.RadioButton();
      this.findUp = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
// 
// cancelButton
// 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(220, 94);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 4;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
// 
// findButton
// 
      this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.findButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.findButton.Location = new System.Drawing.Point(138, 94);
      this.findButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.findButton.Name = "findButton";
      this.findButton.TabIndex = 3;
      this.findButton.Text = "Find";
      this.findButton.Click += new System.EventHandler(this.findButton_Click);
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(13, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Fi&nd what:";
// 
// findWhat
// 
      this.findWhat.Location = new System.Drawing.Point(72, 16);
      this.findWhat.Name = "findWhat";
      this.findWhat.Size = new System.Drawing.Size(223, 20);
      this.findWhat.TabIndex = 1;
// 
// matchWholeWord
// 
      this.matchWholeWord.AutoSize = true;
      this.matchWholeWord.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.matchWholeWord.Location = new System.Drawing.Point(13, 43);
      this.matchWholeWord.Name = "matchWholeWord";
      this.matchWholeWord.Size = new System.Drawing.Size(143, 18);
      this.matchWholeWord.TabIndex = 2;
      this.matchWholeWord.Text = "Match &whole word only";
// 
// matchCase
// 
      this.matchCase.AutoSize = true;
      this.matchCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.matchCase.Location = new System.Drawing.Point(13, 67);
      this.matchCase.Name = "matchCase";
      this.matchCase.Size = new System.Drawing.Size(90, 18);
      this.matchCase.TabIndex = 3;
      this.matchCase.Text = "Match &case";
// 
// groupBox1
// 
      this.groupBox1.Controls.Add(this.findDown);
      this.groupBox1.Controls.Add(this.findUp);
      this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.groupBox1.Location = new System.Drawing.Point(151, 43);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(144, 41);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Direction";
// 
// findDown
// 
      this.findDown.AutoSize = true;
      this.findDown.Checked = true;
      this.findDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.findDown.Location = new System.Drawing.Point(69, 18);
      this.findDown.Name = "findDown";
      this.findDown.Size = new System.Drawing.Size(61, 18);
      this.findDown.TabIndex = 1;
      this.findDown.TabStop = true;
      this.findDown.Text = "&Down";
// 
// findUp
// 
      this.findUp.AutoSize = true;
      this.findUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.findUp.Location = new System.Drawing.Point(12, 18);
      this.findUp.Name = "findUp";
      this.findUp.Size = new System.Drawing.Size(47, 18);
      this.findUp.TabIndex = 0;
      this.findUp.Text = "&Up";
// 
// FindForm
// 
      this.AcceptButton = this.findButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(307, 124);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.matchCase);
      this.Controls.Add(this.matchWholeWord);
      this.Controls.Add(this.findWhat);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.findButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FindForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Find";
      this.Deactivate += new System.EventHandler(this.FindForm_Deactivate);
      this.Activated += new System.EventHandler(this.FindForm_Activated);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FindForm_KeyUp);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button findButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox matchWholeWord;
    private System.Windows.Forms.CheckBox matchCase;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton findUp;
    private System.Windows.Forms.RadioButton findDown;
    internal System.Windows.Forms.TextBox findWhat;
  }
}