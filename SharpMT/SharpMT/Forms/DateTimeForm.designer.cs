namespace SharpMT.Forms
{
  partial class DateTimeForm
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
      this.label2 = new System.Windows.Forms.Label();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.datePicker = new System.Windows.Forms.DateTimePicker();
      this.timePicker = new System.Windows.Forms.DateTimePicker();
      this.useServerTime = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(13, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Date:";
      this.label1.Click += new System.EventHandler(this.label1_Click);
// 
// label2
// 
      this.label2.AutoSize = true;
      this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label2.Location = new System.Drawing.Point(13, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "&Time:";
      this.label2.Click += new System.EventHandler(this.label1_Click);
// 
// cancelButton
// 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(112, 90);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 6;
      this.cancelButton.Text = "Cancel";
// 
// okButton
// 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(30, 90);
      this.okButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 5;
      this.okButton.Text = "OK";
// 
// datePicker
// 
      this.datePicker.CustomFormat = "MMM/dd/yyyy";
      this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.datePicker.Location = new System.Drawing.Point(67, 13);
      this.datePicker.Name = "datePicker";
      this.datePicker.Size = new System.Drawing.Size(120, 20);
      this.datePicker.TabIndex = 1;
// 
// timePicker
// 
      this.timePicker.CustomFormat = "";
      this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.timePicker.Location = new System.Drawing.Point(67, 40);
      this.timePicker.Name = "timePicker";
      this.timePicker.ShowUpDown = true;
      this.timePicker.Size = new System.Drawing.Size(120, 20);
      this.timePicker.TabIndex = 3;
// 
// useServerTime
// 
      this.useServerTime.AutoSize = true;
      this.useServerTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.useServerTime.Location = new System.Drawing.Point(67, 67);
      this.useServerTime.Name = "useServerTime";
      this.useServerTime.Size = new System.Drawing.Size(113, 18);
      this.useServerTime.TabIndex = 4;
      this.useServerTime.Text = "&Use Server Time";
      this.useServerTime.CheckedChanged += new System.EventHandler(this.useServerTime_CheckedChanged);
// 
// DateTimeForm
// 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(199, 125);
      this.Controls.Add(this.useServerTime);
      this.Controls.Add(this.timePicker);
      this.Controls.Add(this.datePicker);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DateTimeForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Set Authored On Date";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    internal System.Windows.Forms.DateTimePicker datePicker;
    internal System.Windows.Forms.DateTimePicker timePicker;
    internal System.Windows.Forms.CheckBox useServerTime;
  }
}