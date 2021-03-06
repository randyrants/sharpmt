using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPFileDialog {
  public partial class SPOpenFileDialog : Form {
    private string MainMemory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Drafts";
    public string Path = @"\";
    public string FileName = "";
    public bool MakeHome = false;

    public SPOpenFileDialog() {
      InitializeComponent();
    }

    private void SPOpenFileDialog_KeyDown(object sender, KeyEventArgs e) {
      if ((e.KeyCode == System.Windows.Forms.Keys.F1)) {
        // Soft Key 1
        // Not handled when menu is present.
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F2)) {
        // Soft Key 2
        // Not handled when menu is present.
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Up)) {
        // Up
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Down)) {
        // Down
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Left)) {
        // Left
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Right)) {
        // Right
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
        if (mniOpen.Enabled) {
          clickedOK();
        }
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D1)) {
        // 1
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D2)) {
        // 2
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D3)) {
        // 3
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D4)) {
        // 4
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D5)) {
        // 5
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D6)) {
        // 6
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D7)) {
        // 7
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D8)) {
        // 8
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D9)) {
        // 9
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F8)) {
        // *
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.D0)) {
        // 0
      }
      if ((e.KeyCode == System.Windows.Forms.Keys.F9)) {
        // #
      }

    }

    private void SPOpenFileDialog_Load(object sender, EventArgs e) {
      Cursor.Current = Cursors.WaitCursor;
      spFileControl.Path = Path;
      spFileControl.RefreshList();

      //disable open menu item when there are no files
      if (spFileControl.folderList.Items.Count == 0) {
        mniOpen.Enabled = false;
      }
      else {
        mniOpen.Enabled = true;
      }
      Cursor.Current = Cursors.Default;
    }

    private void mniOpen_Click(object sender, EventArgs e) {
      clickedOK();
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      //this.Close();
    }

    private void clickedOK() {
      // Check for folder
      ListViewItem selected = spFileControl.folderList.Items[spFileControl.folderList.SelectedIndices[0]];
      if (selected.ImageIndex == 0) {
        if (selected.Text == "..") {
          spFileControl.Path = spFileControl.Path.Substring(0, spFileControl.Path.LastIndexOf(@"\"));
          if (spFileControl.Path == "") {
            spFileControl.Path = @"\";
          }
        }
        else {
          if (spFileControl.Path == @"\") {
            spFileControl.Path = @"\" + selected.Text;
          }
          else {
            spFileControl.Path = spFileControl.Path + @"\" + selected.Text;
          }
        }
        spFileControl.RefreshList();
        return;
      }

      this.FileName = spFileControl.Path + @"\" + spFileControl.fileName.Text;
      this.Path = spFileControl.Path;
      this.DialogResult = DialogResult.OK;
      //this.Close();
    }

    private void mniHome_Click(object sender, EventArgs e) {
      mniHome.Checked = !mniHome.Checked;
      MakeHome = mniHome.Checked;
    }

    private void menuItem2_Click(object sender, EventArgs e) {
      spFileControl.RefreshList();
    }
  }
}