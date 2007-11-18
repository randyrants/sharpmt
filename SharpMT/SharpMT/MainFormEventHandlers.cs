#region Using directives

using System;
using System.Windows.Forms;
using Crownwood.Magic.Docking;
using SharpMT.Forms;
using SharpMT.Classes;

#endregion

namespace SharpMT
{
  partial class MainForm
  {

    #region Tabs Handlers
    private void draftTabs_SelectionChanged(object sender, System.EventArgs e)
    {
      if (draftTabs.TabPages.Count > 0)
      {
        m_currentDraft = (DraftControl)draftTabs.SelectedTab.Controls[0];
        m_currentDraft.title.Focus();
        if (!m_currentDraft.m_editMode)
        {
          saveDraftToolStripMenuItem.Enabled = true;
          saveDraftToolStripButton.Enabled = true;
        }
        else
        {
          saveDraftToolStripMenuItem.Enabled = false;
          saveDraftToolStripButton.Enabled = false;
        }
        saveAllDraftsToolStripMenuItem.Enabled = true;
        closeDraftToolStripMenuItem.Enabled = true;
        if (m_blogId == "-1")
        {
          postToServerToolStripMenuItem.Enabled = false;
          postToServerToolStripButton.Enabled = false;
          postAllOpenDraftsToolStripMenuItem.Enabled = false;
        }
        else
        {
          postToServerToolStripMenuItem.Enabled = true;
          postToServerToolStripButton.Enabled = true;
          if (draftTabs.TabPages.Count > 1)
          {
            postAllOpenDraftsToolStripMenuItem.Enabled = true;
          }
          else
          {
            postAllOpenDraftsToolStripMenuItem.Enabled = false;
          }
        }
        uploadImageToolStripMenuItem.Enabled = true;
        uploadImageToolStripButton.Enabled = true;

        //spellCheckToolStripMenuItem.Enabled = true;
        //spellCheckToolStripButton.Enabled = true;
      }
      else
      {
        closeDraftToolStripMenuItem.Enabled = false;
        saveDraftToolStripMenuItem.Enabled = false;
        saveDraftToolStripButton.Enabled = false;
        saveAllDraftsToolStripMenuItem.Enabled = false;
        postToServerToolStripMenuItem.Enabled = false;
        postToServerToolStripButton.Enabled = false;
        postAllOpenDraftsToolStripMenuItem.Enabled = false;

        uploadImageToolStripMenuItem.Enabled = false;
        uploadImageToolStripButton.Enabled = false;
        //spellCheckToolStripMenuItem.Enabled = false;
        //spellCheckToolStripButton.Enabled = false;
      }
    }

    private void draftTabs_ClosePressed(object sender, System.EventArgs e)
    {
      if (draftTabs.TabPages.Count == 0)
        return;
      m_currentDraft = (DraftControl)draftTabs.SelectedTab.Controls[0];
      m_headerHeight = m_currentDraft.header.Height;
      m_bodyHeight = m_currentDraft.body.Height;
      m_footerHeight = m_currentDraft.footer.Height;

      if (m_currentDraft.CloseDraft())
      {
        draftTabs.TabPages.RemoveAt(draftTabs.SelectedIndex);
      }
    }
    #endregion

    #region Panel Handlers
    private void formPanel_Resize(object sender, EventArgs e)
    {
      //ResizeStatusBarPanel();
    }
    #endregion

    #region ListView Procs
    internal void linksListView_SizeChanged(object sender, System.EventArgs e)
    {
      //lvcLinks.Width = lvLinks.Width - 4 - (lvLinks.Scrollable ? 17 : 0);
      if (m_splashScreen == null)
      {
        m_titleColumnWidth = linksTitleColumn.Width;
        m_idColumnWidth = linksIdColumn.Width;
      }
    }

    private void linksListView_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      ListView.SelectedIndexCollection indexCollection = linksListView.SelectedIndices;
      string body = "";
      string bodyDate = "";
      if (indexCollection.Count > 0)
      {
        EntryItem entryItem = (EntryItem)linksListView.Items[indexCollection[0]].Tag;
        body = entryItem.Body;
        bodyDate = entryItem.DateTime;
      }
      if (bodyDate.Length > 0)
      {
        DateTime dateTime = DateTime.Parse(bodyDate);
        linksBody.Text = dateTime.ToString("ddd, MMM d yyyy HH:mm:ss") + " - " + body;
      }
      else
      {
        linksBody.Text = body;
      }
    }


    private void linksListView_DoubleClick(object sender, System.EventArgs e)
    {
      OpenLinkInEditMode();
    }

    private void linksListView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
      if (e.Column == m_currentSortedColumn)
        m_ascendingSortForLinks = !m_ascendingSortForLinks;
      else
      {
        m_currentSortedColumn = e.Column;
        m_ascendingSortForLinks = true;
      }

      if (e.Column == 0)
        this.linksListView.ListViewItemSorter = new ListViewItemStringComparer(m_ascendingSortForLinks);
      else
        this.linksListView.ListViewItemSorter = new ListViewItemIntComparer(m_ascendingSortForLinks);

      linksListView.Sort();
    }
    #endregion

    #region LinksBody Handlers
    private void linksBody_DoubleClick(object sender, System.EventArgs e)
    {
      if (linksBody.Text == "")
        return;
      EntryBodyForm entryBodyForm = new EntryBodyForm();
      entryBodyForm.Text = "Blog Link Story";
      entryBodyForm.story.Text = linksBody.Text;
      entryBodyForm.ShowDialog();
    }

    private void linksBody_GotFocus(object sender, System.EventArgs e)
    {
      copyToolStripMenuItem.Enabled = true;
      copyToolStripButton.Enabled = true;

      findToolStripMenuItem.Enabled = true;
      findToolStripButton.Enabled = true;

      selectAllToolStripMenuItem.Enabled = true;
    }

    private void linksBody_LostFocus(object sender, System.EventArgs e)
    {
      copyToolStripMenuItem.Enabled = false;
      copyToolStripButton.Enabled = false;

      findToolStripMenuItem.Enabled = false;
      findToolStripButton.Enabled = false;

      selectAllToolStripMenuItem.Enabled = false;

      if (m_findForm != null)
        m_findForm.findWhat = (TextBox)sender;
    }
    #endregion

    private void mainNotifyIcon_MouseUp(object sender, MouseEventArgs e)
    {
      this.Visible = true;
      this.WindowState = (FormWindowState)m_windowState;
      if (m_tracingForm != null)
        m_tracingForm.Visible = true;
    }
  }
}
