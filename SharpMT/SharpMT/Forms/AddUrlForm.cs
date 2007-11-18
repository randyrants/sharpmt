#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpMT.Classes;
#endregion

namespace SharpMT.Forms
{
  partial class AddUrlForm : Form
  {
    public string m_url, m_text, m_prefix, m_title, m_currentDirectory, m_target;
    public int m_columnTitle = 700;
    public int m_columnId = 1;
    public int m_sortingColumn = 1;
    public bool m_ascending = false;

    public AddUrlForm()
    {
      InitializeComponent();

      m_url = "http://";
      m_text = "";
      m_title = "";
      m_currentDirectory = "";
      m_ascending = false;
      m_prefix = "";
      m_target = "";
    }

    private void AddUrlForm_Load(object sender, EventArgs e)
    {
      m_prefix = m_url;
      urlTyped.Text = m_url;
      linkText.Text = m_text;
      linkTarget.Text = m_target;
      urlTyped.Focus();

      linksTitleColumn.Width = m_columnTitle;
      linksIdColumn.Width = m_columnId;

      if (m_sortingColumn == 0)
        linksListView.ListViewItemSorter = new ListViewItemStringComparer(m_ascending);
      else
        linksListView.ListViewItemSorter = new ListViewItemIntComparer(m_ascending);

      linksListView.Sort();

      LoadFavorites(Environment.GetFolderPath(Environment.SpecialFolder.Favorites), true);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      if (DialogResult == DialogResult.OK)
      {
        if (tabs.SelectedIndex == 1)
        {
          ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
          if (indexCollection.Count <= 0)
          {
            e.Cancel = true;
            MessageBox.Show("Please select a Blog Link to insert!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            linksListView.Focus();
          }
        }
        else if (tabs.SelectedIndex == 2)
        {
          ListView.SelectedIndexCollection indexCollection = favoritesListView.SelectedIndices;
          if (indexCollection.Count > 0)
          {
            int position = indexCollection[0];
            if (favoritesListView.Items[position].ImageIndex == 4)
            { //folder
              string directory = favoritesListView.Items[position].Text;
              if (directory == "..")
              {
                directory = m_currentDirectory.Substring(0, m_currentDirectory.LastIndexOf(@"\"));
                if (directory == Environment.GetFolderPath(Environment.SpecialFolder.Favorites))
                  LoadFavorites(directory, true);
                else
                  LoadFavorites(directory, false);
              }
              else
              {
                LoadFavorites(m_currentDirectory + @"\" + favoritesListView.Items[position].Text, false);
              }
              e.Cancel = true;
              return;
            }
            else
            {
              if (linkText.Text.Length == 0)
              {
                linkText.Text = favoritesListView.Items[position].Text;
              }
              m_url = favoritesListView.Items[position].SubItems[1].Text;
              m_text = linkText.Text;
              m_title = linkTitle.Text;
              m_target = linkTarget.Text;
            }
          }
          else
          {
            e.Cancel = true;
            MessageBox.Show("Please select a Favorite to insert!", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            favoritesListView.Focus();
            return;
          }
        }
        else
        {
          m_url = urlTyped.Text;
          m_text = linkText.Text;
          m_title = linkTitle.Text;
          m_target = linkTarget.Text;

          urlTyped.Items.Insert(0, m_url);
          if (urlTyped.Items.Count > 20)
            urlTyped.Items.RemoveAt(20);
        }
      }
      m_columnTitle = linksTitleColumn.Width;
      m_columnId = linksIdColumn.Width;
    }

    private void LoadFavorites(string directory, bool isRoot)
    {
      favoritesListView.Items.Clear();
      m_currentDirectory = directory;
      directory += @"\*";

      FindData findData = new FindData();
      IntPtr hFindFiles = FindFiles.FindFirstFile(directory, findData);
      IntPtr hFindNext = IntPtr.Zero;

      if (hFindFiles.ToInt32() == -1)
        return;

      int directoryPostion = 0;
      do
      {
        if (findData.fileName == ".")
        {
        }
        else if (findData.fileName == "..")
        {
        }
        else
        {
          int attributes = (findData.fileAttributes ^ FindFiles.FILE_ATTRIBUTE_DIRECTORY);
          if (attributes == 0)
          {
            ListViewItem listViewItem = new ListViewItem(findData.fileName, 4);
            listViewItem.SubItems.Add("(directory)");
            favoritesListView.Items.Insert(directoryPostion, listViewItem);
            directoryPostion++;
          }
          else
          {
            if ((findData.fileName.Length > 4) && (findData.fileName.Substring(findData.fileName.Length - 4, 4) == ".url"))
            {
              StringBuilder urlString = new StringBuilder(255);
              string str = m_currentDirectory + @"\" + findData.fileName;
              IniFiles.GetPrivateProfileString("InternetShortcut", "URL", "", urlString, (uint)urlString.Capacity, str);

              ListViewItem listViewItem = new ListViewItem(findData.fileName.Substring(0, findData.fileName.Length - 4), 3);
              listViewItem.SubItems.Add(urlString.ToString());
              favoritesListView.Items.Add(listViewItem);
            }
          }
        }

        findData = new FindData();
        hFindNext = FindFiles.FindNextFile(hFindFiles, findData);
      } while (hFindNext.ToInt32() > 0);

      FindFiles.FindClose(hFindFiles);

      // add a go back
      if (!isRoot)
      {
        ListViewItem listViewItem = new ListViewItem("..", 4);
        listViewItem.SubItems.Add("(parent directory)");
        favoritesListView.Items.Insert(0, listViewItem);
      }
    }

    private void tabs_Enter(object sender, EventArgs e)
    {
      if (tabs.SelectedIndex == 0)
        urlTyped.Focus();
      else if (tabs.SelectedIndex == 1)
        linksListView.Focus();
      else
        favoritesListView.Focus();
    }

    private void linksList_DoubleClick(object sender, EventArgs e)
    {
      ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
      if (indexCollection.Count > 0)
      {
        okButton.PerformClick();
      }
    }

    private void favoritesList_DoubleClick(object sender, EventArgs e)
    {
      ListView.SelectedIndexCollection indexCollection = favoritesListView.SelectedIndices;
      if (indexCollection.Count > 0)
      {
        okButton.PerformClick();
      }
    }

    private void linksList_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column == m_sortingColumn)
        m_ascending = !m_ascending;
      else
      {
        m_sortingColumn = e.Column;
        m_ascending = true;
      }

      if (e.Column == 0)
        linksListView.ListViewItemSorter = new ListViewItemStringComparer(m_ascending);
      else
        linksListView.ListViewItemSorter = new ListViewItemIntComparer(m_ascending);

      linksListView.Sort();
    }
  }
}