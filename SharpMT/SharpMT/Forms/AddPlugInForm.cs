#region Using directives

using System;
using System.ComponentModel;
using System.Windows.Forms;
using RandyRants.SharpMTExtension;

#endregion

namespace SharpMT.Forms
{
  partial class AddPlugInForm : Form
  {
    public AddPlugInForm()
    {
      InitializeComponent();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
    } 
    
    private void browseDir_Click(object sender, EventArgs e)
    {
      formOpenDialog.InitialDirectory = MainForm.m_homeFolder + "PlugIns";
      formOpenDialog.RestoreDirectory = true;

      if (formOpenDialog.ShowDialog() == DialogResult.OK)
      {
        location.Text = formOpenDialog.FileName;
        try
        {
          // Load the assembly based on file name
          System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(location.Text);
          // Load in the list of available types
          Type[] typeList = asm.GetTypes();
          Type typePlugin = null;
          // Go through the list of types
          for (int i = 0; i < typeList.Length; i++)
          {
            // Check to see if the current class/type supports my Interface
            if (typeList[i].GetInterface(typeof(ISharpMTExtension).FullName) != null)
            {
              // if the interface is supported, break the search
              typePlugin = typeList[i];
              break;
            }
          }

          // if an interface was found in the plug in
          if (typePlugin != null)
          {
            // create an instance and set the crap up
            ISharpMTExtension obj = (ISharpMTExtension)Activator.CreateInstance(typePlugin);
            plugInName.Text = obj.DisplayName;
            if (plugInName.Text.Length <= 0)
              plugInName.Text = "(untitled)";
            description.Text = obj.DisplayDescription;
            version.Text = asm.GetName().Version.ToString();
          }
        }
        catch
        {
          MessageBox.Show("This DLL did not respond as a SharpMT Extension Plug-In should!\n\nPlease verify that it is a proper Plug-In and try again.", MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
      }
    }
  }
}