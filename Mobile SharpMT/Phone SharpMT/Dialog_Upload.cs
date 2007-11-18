using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Forms;

namespace Phone_SharpMT {
  public partial class Dialog_Upload : Form {
    public string m_strUploadPath;

    public Dialog_Upload() {
      InitializeComponent();

      m_strUploadPath = "";

      DialogResult = DialogResult.OK;
    }

    private void Dialog_Upload_Closing(object sender, CancelEventArgs e) {
      if (DialogResult == DialogResult.OK) {
        if (ebLocal.Text.Length == 0) {
          e.Cancel = true;
          MessageBox.Show("Please select an image to upload!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          ebLocal.Focus();
          return;
        }
        if (ebRemote.Text.Length == 0) {
          e.Cancel = true;
          MessageBox.Show("Please enter a remote name for this image!", Dialog_Main.m_strAppName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          ebRemote.Focus();
        }
      }      
    }

    private void btnOK_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.OK;
      //this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      //this.Close();
    }

    private void btnBrowse_Click(object sender, EventArgs e) {
      SelectPictureDialog dlgOpen = new SelectPictureDialog();
      if (dlgOpen.ShowDialog() == DialogResult.OK) {
        ebLocal.Text = dlgOpen.FileName;
        if (ebRemote.Text.Length == 0) {
          ebRemote.Text = dlgOpen.FileName.Substring(dlgOpen.FileName.LastIndexOf("\\") + 1);
          ebRemote.Focus();
          ebRemote.SelectionStart = ebRemote.Text.Length;
          ebRemote.SelectionLength = 0;
        }
        else if (ebRemote.Text == m_strUploadPath) {
          ebRemote.Text += dlgOpen.FileName.Substring(dlgOpen.FileName.LastIndexOf("\\") + 1);
          ebRemote.Focus();
          ebRemote.SelectionStart = ebRemote.Text.Length;
          ebRemote.SelectionLength = 0;
        }
      }
    }
  }
}