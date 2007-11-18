using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SPFileDialog {
  public partial class SPFileControl : UserControl {
    private String Filter = "*.smt";
    internal String Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    internal bool ReadyToSave = false;

    public SPFileControl() {
      InitializeComponent();

      this.filenamePanel.Visible = false;
      this.fileName.Enabled = false;
    }

		internal void RefreshList()
		{
			Cursor.Current = Cursors.WaitCursor;

			//clear the list
			folderList.Items.Clear();

			//suspend events during updating
      folderList.BeginUpdate();

      if (Path != @"\") {
        ListViewItem lviNew = new ListViewItem(new string[] { "..", ".."});
        lviNew.ImageIndex = 0;

        //add to list
        folderList.Items.Add(lviNew);
      }

      //get all files of specified type in specified folder
      List<string> list = new List<string>();
      foreach (string folder in System.IO.Directory.GetDirectories(Path)) {
        list.Add(folder);
      }
      list.Sort();

      for (int i = 0; i < list.Count; i++) {
        //get info on file
        DirectoryInfo di = new DirectoryInfo(list[i]);

        //don't add hidden files to the list
        if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden) {
          //create new item with filename minus extension
          ListViewItem lviNew = new ListViewItem(new string[] { di.Name, di.FullName });
          lviNew.ImageIndex = 0;

          //add to list
          folderList.Items.Add(lviNew);
        }
      }

      list.Clear();


      //get all files of specified type in specified folder
      foreach (string filename in System.IO.Directory.GetFiles(Path, Filter))
			{
        list.Add(filename);
      }
      list.Sort();

      for (int i = 0; i < list.Count; i++) {
				//get info on file
				FileInfo fi = new FileInfo(list[i]);

				//don't add hidden files to the list
				if((fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
				{
					//create new item with filename minus extension
          ListViewItem lviNew = new ListViewItem(new string[] { fi.Name, fi.FullName });
          lviNew.ImageIndex = 1;

					//add to list
          folderList.Items.Add(lviNew);
				}
			}

			//set focus to list
      folderList.Focus();
      if (folderList.Items.Count > 0) {
        folderList.Items[0].Selected = true;
        folderList.Items[0].Focused = true;
      }

      //restore events to list
      folderList.EndUpdate();
      Cursor.Current = Cursors.Default;
		}

    private void folderList_SelectedIndexChanged(object sender, EventArgs e) {
      if (!this.filenamePanel.Visible) {
        if (folderList.SelectedIndices.Count > 0) {
          this.currentDirectory.Text = Path;
          this.fileName.Text = folderList.Items[folderList.SelectedIndices[0]].Text;
        }
      }
    }

    protected override void OnResize(EventArgs e) {
      base.OnResize(e);

      this.folderList.Columns[0].Width = this.folderList.Width - 4;
    }

    public void IsSave(bool value) {
      this.filenamePanel.Visible = value;
      this.fileName.Enabled = value;
    }

    private void fileName_GotFocus(object sender, EventArgs e) {
      ReadyToSave = true;
    }

    private void fileName_LostFocus(object sender, EventArgs e) {
      ReadyToSave = false;
    }
  }
}
