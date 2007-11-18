#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RandyRants.SharpMTExtension;

#endregion

namespace SharpMT.Forms
{
  partial class InsertPlugInDataForm : Form
  {
    public static InsertPlugInDataForm m_this = null;
    internal ISharpMTExtension m_extension = null;
    internal string m_version = "";
    internal bool m_showList = false;

    public InsertPlugInDataForm()
    {
      InitializeComponent();

      m_this = this;
    }

    private void InsertPlugInDataForm_Load(object sender, EventArgs e)
    {

      statusStripPanelMain.Text = m_extension.DisplayName;
      statusStripPanelVersion.Text = m_version;

      listBoxResults.Visible = m_showList;
      textBoxResults.Visible = !m_showList;

      statusStripPanelMain.Width = statusStripPanelVersion.Bounds.Left - statusStripPanelMain.Bounds.Left;
    }

    private void goButton_Click(object sender, EventArgs e)
    {
      statusStripPanelVersion.Visible = false;
      toolStripProgressBar.Visible = true;

      listBoxResults.Items.Clear();

      m_extension.ParamOne = textBoxOne.Text;
      m_extension.ParamTwo = textBoxTwo.Text;
      m_extension.ParamThree = textBoxThree.Text;

      groupBox1.Enabled = false;
      groupBox2.Enabled = false;

      Thread t = new Thread(new ThreadStart(ExecuteThread));
      t.Start();
    }

    public void ExecuteThread()
    {
      Invoke((MethodInvoker)delegate
      {
        if (m_showList)
        {
          object[] results = m_extension.ExecuteList();

          if (results != null)
          {
            for (int i = 0; i < results.Length; i++)
            {
              listBoxResults.Items.Add(results[i].ToString());
            }
          }

          if (listBoxResults.Items.Count == 0)
            okButton.Enabled = false;
          else
          {
            okButton.Enabled = true;
            listBoxResults.SelectedIndex = 0;
          }
        }
        else
        {
          string result = m_extension.ExecuteString();
          textBoxResults.Text = result;

          okButton.Enabled = true;
        }

        // end the progress bar
        statusStripPanelVersion.Visible = true;
        toolStripProgressBar.Visible = false;

        groupBox1.Enabled = true;
        groupBox2.Enabled = true;
      });
    }

    private void listBoxResults_DoubleClick(object sender, EventArgs e)
    {
      okButton.PerformClick();
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      if (WindowState == FormWindowState.Normal)
      {
        statusStripPanelMain.Width = statusStripPanelVersion.Bounds.Left - statusStripPanelMain.Bounds.Left;
      }
      else if (WindowState == FormWindowState.Maximized)
      {
        statusStripPanelMain.Width = statusStripPanelVersion.Bounds.Left - statusStripPanelMain.Bounds.Left;
      }
    }
  }
}