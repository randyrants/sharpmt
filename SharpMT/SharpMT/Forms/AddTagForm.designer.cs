namespace SharpMT.Forms
{
  partial class AddTagForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.tagText = new System.Windows.Forms.TextBox();
      this.enclose = new System.Windows.Forms.CheckBox();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(10, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Tag text:";
// 
// tagText
// 
      this.tagText.Location = new System.Drawing.Point(68, 10);
      this.tagText.Name = "tagText";
      this.tagText.Size = new System.Drawing.Size(273, 20);
      this.tagText.TabIndex = 1;
      this.tagText.TextChanged += new System.EventHandler(this.tagText_TextChanged);
// 
// enclose
// 
      this.enclose.AutoSize = true;
      this.enclose.Checked = true;
      this.enclose.CheckState = System.Windows.Forms.CheckState.Checked;
      this.enclose.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.enclose.Location = new System.Drawing.Point(68, 37);
      this.enclose.Name = "enclose";
      this.enclose.Size = new System.Drawing.Size(157, 18);
      this.enclose.TabIndex = 2;
      this.enclose.Text = "Enclosing tag <tag> </tag>";
      this.enclose.CheckedChanged += new System.EventHandler(this.enclose_CheckedChanged);
// 
// cancelButton
// 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(266, 61);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 4;
      this.cancelButton.Text = "Cancel";
// 
// okButton
// 
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(184, 61);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 3;
      this.okButton.Text = "OK";
// 
// AddTagForm
// 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(353, 96);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.enclose);
      this.Controls.Add(this.tagText);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddTagForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add/Edit Custom Tag";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    internal System.Windows.Forms.TextBox tagText;
    internal System.Windows.Forms.CheckBox enclose;
  }
}