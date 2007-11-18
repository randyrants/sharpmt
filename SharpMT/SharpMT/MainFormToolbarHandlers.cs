#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Crownwood.Magic.Docking;
using SharpMT.Forms;
using SharpMT.Classes;

#endregion

namespace SharpMT
{
  partial class MainForm
  {
    private void updateCategoriesToolStripButton_Click(object sender, EventArgs e)
    {
      updateCategoriesToolStripMenuItem_Click(sender, e);
    }

    private void updateTextFiltersToolStripButton_Click(object sender, EventArgs e)
    {
      updateTextFiltersToolStripMenuItem_Click(sender, e);
    }

    private void updateLinksToolStripButton_Click(object sender, EventArgs e)
    {
      updateBlogLinksToolStripMenuItem_Click(sender, e);
    }

    private void findToolStripButton_Click(object sender, EventArgs e)
    {
      findToolStripMenuItem_Click(sender, e);
    }

    private void openDraftToolStripButton_Click(object sender, EventArgs e)
    {
      openDraftToolStripMenuItem_Click(sender, e);
    }

    private void saveDraftToolStripButton_Click(object sender, EventArgs e)
    {
      saveDraftToolStripMenuItem_Click(sender, e);
    }

    private void cutToolStripButton_Click(object sender, EventArgs e)
    {
      cutToolStripMenuItem_Click(sender, e);
    }

    private void copyToolStripButton_Click(object sender, EventArgs e)
    {
      copyToolStripMenuItem_Click(sender, e);
    }

    private void pasteToolStripButton_Click(object sender, EventArgs e)
    {
      pasteToolStripMenuItem_Click(sender, e);
    }

    private void deleteToolStripButton_Click(object sender, EventArgs e)
    {
      deleteToolStripMenuItem_Click(sender, e);
    }

    private void boldToolStripButton_Click(object sender, EventArgs e)
    {
      boldToolStripMenuItem_Click(sender, e);
    }

    private void italicToolStripButton_Click(object sender, EventArgs e)
    {
      italicToolStripMenuItem_Click(sender, e);
    }

    private void underlineToolStripButton_Click(object sender, EventArgs e)
    {
      underlineToolStripMenuItem_Click(sender, e);
    }

    private void urlToolStripButton_Click(object sender, EventArgs e)
    {
      urlToolStripMenuItem_Click(sender, e);
    }

    private void nowPlayingToolStripButton_Click(object sender, EventArgs e)
    {
      nowPlayingToolStripMenuItem_Click(sender, e);
    }

    private void spellCheckToolStripButton_Click(object sender, EventArgs e)
    {
      spellCheckToolStripMenuItem_Click(sender, e);
    }

    private void postToServerToolStripButton_Click(object sender, EventArgs e)
    {
      postToServerToolStripMenuItem_Click(sender, e);
    }

    private void uploadImageToolStripButton_Click(object sender, EventArgs e)
    {
      uploadImageToolStripMenuItem_Click(sender, e);
    }

    private void viewSiteToolStripButton_Click(object sender, EventArgs e)
    {
      viewSiteToolStripMenuItem_Click(sender, e);
    }

    private void customTagToolStripButton_Click(object sender, EventArgs e)
    {
      customTagToolStripMenuItem_Click(sender, e);
    }

    private void plugInToolStripButton_Click(object sender, System.EventArgs e)
    {
      plugInToolStripMenuItem_Click(sender, e);
    }
  }
}
