#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace SharpMT
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      
      #region Single Session Stuff
      // Begin:SPELLCHECK_REM
      //// Check for OCX
      //RegistryKey applicationKey = Registry.ClassesRoot.OpenSubKey(@"CLSID\{CEAFFE29-A377-49FA-AB38-B4441888FC81}");
      //if (applicationKey != null)
      //{
      //  applicationKey.Close();
      //}
      //else
      //{
      //  System.Diagnostics.Process proc = new System.Diagnostics.Process();
      //  proc.StartInfo.UseShellExecute = true;
      //  proc.StartInfo.FileName = "regsvr32.exe";
      //  proc.StartInfo.Arguments = "spellictrl.ocx /s";
      //  proc.Start();
      //  while (!proc.HasExited)
      //  {
      //  }
      //  applicationKey = Registry.ClassesRoot.OpenSubKey(@"CLSID\{CEAFFE29-A377-49FA-AB38-B4441888FC81}");
      //  if (applicationKey != null)
      //  {
      //    applicationKey.Close();
      //  }
      //  else
      //  {
      //    MessageBox.Show("The Spell Checker cannot be found!\r\n\r\nPlease reinstall " + MainForm.ApplicationName, MainForm.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      //    return;
      //  }
      //}
      // End:SPELLCHECK_REM

      MainForm.m_mainMutex = new System.Threading.Mutex(false, Application.UserAppDataPath.Replace(@"\", "_"));
      if (MainForm.m_mainMutex.WaitOne(1, true))
      {
        MainForm mainForm = new MainForm();

        if (args.Length == 0)
        {
          mainForm.m_launchParameters = "";
          mainForm.m_validFileAndBlog = false;
        }
        else if (args.Length == 1)
        {
          if (args[0].StartsWith("sharpmt://"))
          {
            mainForm.m_launchParameters = args[0].Replace("sharpmt://", "");
            mainForm.m_validFileAndBlog = false;
          }
          else
          {
            mainForm.m_launchParameters = args[0];
            mainForm.m_validFileAndBlog = true;
          }
        }
        else
        {
          if (args[0] == "/plug-in")
          {
            mainForm.m_launchParameters = args[1];
            mainForm.m_validFileAndBlog = false;
          }
        }
        Application.Run(mainForm);
        MainForm.m_mainMutex.Close();
        System.IO.Directory.Delete(Application.UserAppDataPath);
      }
      else
      {
        string externalCommand = "";
        if (args.Length == 0)
        {
          externalCommand = "ShartpMT.OpenNewWindow";
        }
        else if (args.Length == 1)
        {
          externalCommand = string.Format("{0}", args[0]);
        }
        else
        {
          if (args[0] == "/plug-in")
          {
            externalCommand = string.Format("{0}:{1}", args[0], args[1]);
          }
        }

        RegistryKey applicationKey = Registry.CurrentUser.CreateSubKey(MainForm.RegistryKeyName + @"\DataLocker");
        applicationKey.SetValue("Argument", externalCommand);
        applicationKey.Close();
      }
      #endregion
    }
  }
}