#region Using directives

using System;
using Syndication.Extensibility;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using Microsoft.Win32;

#endregion

namespace SharpMTPlugIn2
{
  /// <summary>
  /// Summary description for Plugin.
  /// </summary>
  public class PlugIn : IBlogExtension
  {
    public const string ApplicationName = "SharpMT Plug-in";
    public const string RegistryKeyName = "Software\\RandyRants\\SharpMT";
    public static string m_dataHome = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RandyRants.com\\SharpMT\\";
    public static string m_IBlogFile = m_dataHome + "RSSFormat.txt";

    public static string styleSheet = @"<xsl:stylesheet version='1.0' 
  xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
  <xsl:output method='xml' /> 
  <xsl:variable name='feed-title' select='/rss/channel/title' />
  <xsl:variable xmlns:xhtml='http://www.w3.org/1999/xhtml' name='descr' select='/rss/channel/item/xhtml:body' />
  
  <xsl:template match='/'>
  <rssBlogInfo>
    <xsl:apply-templates select='//item' />
  </rssBlogInfo>
  </xsl:template>

  <xsl:template match='/rss/channel/item'>
    <title>RE: <xsl:value-of select='title' /></title>
    <link><xsl:value-of select='link'/></link>
    <xsl:choose>
      <xsl:when test='description'>
      	<description>
  	      <xsl:value-of disable-output-escaping='yes' select='description' />
      	</description>
      </xsl:when>
      <xsl:otherwise>
	      <description>
	        <xsl:value-of select='$descr' />
	      </description>
	    </xsl:otherwise> 
    </xsl:choose> 
  </xsl:template> 
</xsl:stylesheet>";
    /*      <xsl:otherwise  xmlns:xhtml='http://www.w3.org/1999/xhtml'>
      <description>
        <xsl:copy-of select='xhtml:body' />
*/
    public PlugIn()
    {
      // set up directories
      Directory.CreateDirectory(m_dataHome);
    }

    // IBlogExtension
    public string DisplayName
    {
      get
      {
        Version version = System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version;
        return string.Format("SharpMT ({0})", version.ToString());
      }
    }

    // return true if plug-in has configuration settings
    public bool HasConfiguration
    {
      get
      {
        return false;
      }
    }

    // Return true if an editing GUI will be shown to the 
    // user when BlogItem is called. In this case, the 
    // aggregator will not display its own editing UI. 
    public bool HasEditingGUI
    {
      get
      {
        return true;
      }
    }

    // Display configuration dialog to user, if applicable 
    public void Configure(IWin32Window parent) { }

    // Post item to weblog. If plug-in is going to show a 
    // GUI for editing, it should return true to HasEditingGUI(). 
    public void BlogItem(IXPathNavigable rssFragment, bool edited)
    {
      if (rssFragment == null)
      {
        MessageBox.Show("Error: rssFragment was sent as null", PlugIn.ApplicationName);
        return;
      }

      /*      XPathNavigator xpNav = rssFragment.CreateNavigator();
            string strUrl = (string)xpNav.Evaluate("string(//item/link/text())");
            string strTitle = (string)xpNav.Evaluate("string(//item/title/text())");
            string strDescription = (string)xpNav.Evaluate("string(//item/description/text())");
      */
      string output = string.Format(m_dataHome + "temp{0}.xml", DateTime.Now.Ticks);

      StreamWriter streamWriter = new StreamWriter(output);
      System.Xml.Xsl.XslCompiledTransform transform = new System.Xml.Xsl.XslCompiledTransform();
      transform.Transform(rssFragment, null, streamWriter);
      streamWriter.Close();

      string xml = "";
      try
      {
        StreamReader streamReader = new StreamReader(output);
        xml = streamReader.ReadToEnd();
        streamReader.Close();
        File.Delete(output);
      }
      catch
      {
      }

      if (xml.Length == 0)
      {
        MessageBox.Show("Error: rssFragment was sent as null", PlugIn.ApplicationName);
        return;
      }

      string title = xml.Substring(xml.IndexOf("<title>") + 7);
      title = title.Substring(0, title.IndexOf("</title>"));
      string url = xml.Substring(xml.IndexOf("<link>") + 6);
      url = url.Substring(0, url.IndexOf("</link>"));
      string description = xml.Substring(xml.IndexOf("<description>") + 13);
      description = description.Substring(0, description.IndexOf("</description>"));

      string format = "";
      if (File.Exists(m_IBlogFile))
      {
        using (FileStream fileStream = new FileStream(m_IBlogFile, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
          byte[] byteArray = new byte[1024];
          int n = fileStream.Read(byteArray, 0, byteArray.Length);
          System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
          while (n > 0)
          {
            format += encoding.GetString(byteArray, 0, n);
            n = fileStream.Read(byteArray, 0, byteArray.Length);
          }
          fileStream.Close();
        }
      }

      if (format.Length == 0)
      {
        format = "<a href=\"[RSSLINK]\">[RSSTITLE]</a>: [RSSDESCRIPTION]";
      }

      format = format.Replace("[RSSLINK]", url);
      format = format.Replace("[RSSTITLE]", title);
      format = format.Replace("[RSSDESCRIPTION]", description);

      output = string.Format(m_dataHome + "temp{0}.txt", DateTime.Now.Ticks);
      using (StreamWriter outputWriter = new StreamWriter(output, false, System.Text.Encoding.ASCII))
      {
        outputWriter.Write(format);
        outputWriter.Close();
      }

      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PlugIn.RegistryKeyName);
      string exeDirectory = "";
      if (registryKey != null)
      {
        // Load draft directory
        exeDirectory = (string)registryKey.GetValue("InstallDirectory", "");

        registryKey.Close();
      }

      if ((exeDirectory.Length == 0) && (!File.Exists(exeDirectory)))
      {
        MessageBox.Show("Error: SharpMT cannot be found", PlugIn.ApplicationName);
        File.Delete(output);
        return;
      }

      try
      {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = exeDirectory;
        process.StartInfo.Arguments = "/plug-in \"" + output + "\"";
        process.Start();
      }
      catch
      {
        MessageBox.Show("Error: SharpMT cannot be launch", PlugIn.ApplicationName);
        File.Delete(output);
      }
    }
  }
}
