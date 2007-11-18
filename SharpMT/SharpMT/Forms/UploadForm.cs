#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace SharpMT.Forms
{
  partial class UploadForm : Form
  {
    public string m_uploadPath;

    public UploadForm()
    {
      InitializeComponent();

      m_uploadPath = "";
    }

    private void urlLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start(urlLink.Text);
    }

    private void browse_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        localFileName.Text = openFileDialog.FileName;
        if (remoteFileName.Text.Length == 0)
        {
          remoteFileName.Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf(@"\") + 1);
          remoteFileName.Focus();
          remoteFileName.SelectionStart = remoteFileName.Text.Length;
          remoteFileName.SelectionLength = 0;
        }
        else if (remoteFileName.Text == m_uploadPath)
        {
          remoteFileName.Text += openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf(@"\") + 1);
          remoteFileName.Focus();
          remoteFileName.SelectionStart = remoteFileName.Text.Length;
          remoteFileName.SelectionLength = 0;
        }
      }
    }

    protected override void OnClosing(CancelEventArgs e) 
    {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK)
      {
        if (localFileName.Text.Length == 0)
        {
          e.Cancel = true;
          MessageBox.Show("Please select an image to upload!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          browse.Focus();
          return;
        }
        if (remoteFileName.Text.Length == 0)
        {
          e.Cancel = true;
          MessageBox.Show("Please enter a remote name for this image!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
          remoteFileName.Focus();
        }
      }
    }      
  }
}