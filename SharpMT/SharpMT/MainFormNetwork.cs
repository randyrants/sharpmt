#region Using directives

using System;
using SharpMT.Forms;
using System.IO;
using System.Net;
using System.Windows.Forms;

#endregion

namespace SharpMT
{
  partial class MainForm
  {
    private void SetupProxyInformation()
    {
      // Create a proxy, if I'm supposed to
      if (m_proxy)
      {
        try
        {
          m_webProxy = new WebProxy();

          // Create a new Uri object.
          Uri proxyAddress = new Uri(string.Format("http://{0}:{1}", m_proxyUrl, m_proxyPort));

          // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
          m_webProxy.Address = proxyAddress;

          // Create a NetworkCredential object and associate it with the Proxy property of request object.
          if (m_proxyAuthentication)
          {
            NetworkCredential credentials = new NetworkCredential(m_proxyUserName, m_proxyPassword);
            CredentialCache cache = new CredentialCache();
            cache.Add(proxyAddress, "Basic", credentials);
            cache.Add(proxyAddress, "Digest", credentials);
            cache.Add(proxyAddress, "NTLM", credentials);
            m_webProxy.Credentials = cache;
          }
        }
        catch
        {
          MessageBox.Show("Error configuring for your proxy server!\n\nPlease verify your proxy information on the Options dialog.", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          m_webProxy = null;
        }
      }
      else
        m_webProxy = null;
    }

    private string GetOtherData(string command, string blogId, string userName, string password)
    {
      // any other command
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>{0}</methodName><params>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><string>{3}</string></value></param>" +
        "</params></methodCall>", command, blogId, userName, password);
      string webData = GetWebData(xml);
      return webData;
    }

    private string GetTextFilterData(string command) {
      // any other command
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>{0}</methodName>" +
        "</methodCall>", command);
      return GetWebData(xml);
    }

    private string GetSinglePostData(string blogId, string userName, string password)
    {
      // only get the latest post to check to see whats there
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>mt.getRecentPostTitles</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><string>{3}</string></value></param>" +
        "</params></methodCall>", blogId, userName, password, "1");
      return GetWebData(xml);
    }

    private string GetRecentPostData(string blogId, string userName, string password, string maxLinksToRefresh)
    {
      // get all of the post data
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>metaWeblog.getRecentPosts</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "<param><value><int>{3}</int></value></param>" +
        "</params></methodCall>", blogId, userName, password, maxLinksToRefresh);
      return GetWebData(xml);
    }

    private string GetEditPostData()
    {
      // get all of the post data
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>metaWeblog.getPost</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "</params></methodCall>", m_linkId, m_userName, m_password);
      return GetWebData(xml);
    }

    private string GetEditCategoryData()
    {
      // get all of the post data
      string xml;
      xml = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>metaWeblog.getPostCategories</methodName><params>" +
        "<param><value><string>{0}</string></value></param>" +
        "<param><value><string>{1}</string></value></param>" +
        "<param><value><string>{2}</string></value></param>" +
        "</params></methodCall>", m_linkId, m_userName, m_password);
      return GetWebData(xml);
    }

    private string GetWebData(string strCommand)
    {
      Uri address = null;
      string str = "", ssl = "", port = "";
      if (m_useSsl) {
        ssl = "s";
      }
      if (m_port != 80) {
        port = string.Format(":{0}", m_port);
      }

      try {
        str = string.Format("http{0}://{1}{2}{3}", ssl, m_hostName, port, m_cgiPath);
        address = new Uri(str);
      }
      catch {
        str = string.Format("http://{0}{1}", m_hostName, m_cgiPath);
        address = new Uri("http://{0}{1}");
      }

      //string str = string.Format("http://{0}{1}", m_hostName, m_cgiPath);
      string xml = strCommand;
      byte[] bytes = null;
      bytes = System.Text.Encoding.UTF8.GetBytes(xml);

      Invoke((MethodInvoker)delegate
      {
        if (m_tracing)
        {
          if (m_tracingForm == null)
          {
            m_tracingForm = new TracingForm();
            m_tracingForm.Show();
          }
          if (m_tracingForm != null)
          {
            //m_tracingForm.Log.Focus();
            m_tracingForm.Log.Text = m_tracingForm.Log.Text + "Outbound: " + xml + "\r\n\r\n";
            m_tracingForm.Log.SelectionStart = m_tracingForm.Log.Text.Length + 1;
            m_tracingForm.Log.ScrollToCaret();
            //m_dlgTracing.ebLog.SelectionLength = 0;
          }
        }
      });

      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(address);
/*      if (m_netProxy == null)
        wbRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();
      else
        wbRequest.Proxy = m_netProxy;
*/
      if (m_webProxy != null)
        webRequest.Proxy = m_webProxy;

      webRequest.UserAgent = UserAgent;
      webRequest.Method = "POST";
      webRequest.ContentType = "text/xml";
      webRequest.ContentLength = bytes.Length;
      webRequest.Timeout = 900000; // 15 minutes
      try
      {
        Stream outStream = webRequest.GetRequestStream();
        outStream.Write(bytes, 0, bytes.Length);
        outStream.Close();
      }
      catch (ProtocolViolationException e)
      {
        MessageBox.Show(e.Message, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
      }
      catch (WebException e)
      {
        MessageBox.Show(e.Message, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
      }
      catch (InvalidOperationException e)
      {
        MessageBox.Show(e.Message, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
      }
      catch
      {
        MessageBox.Show("Error connecting to host!", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
      }

      HttpWebResponse webResponse = null;
      try
      {
        webResponse = (HttpWebResponse)webRequest.GetResponse();
      }
      catch (WebException we)
      {
        MessageBox.Show(we.Message, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
      }

      if (webResponse.StatusCode != HttpStatusCode.OK)
      {
        return "";
      }

      // Get the response stream.
      Stream readStream = webResponse.GetResponseStream();
      StreamReader streamReader = new StreamReader(readStream, System.Text.Encoding.ASCII);
      xml = streamReader.ReadToEnd();
      readStream.Close();
      webResponse.Close();

      Invoke((MethodInvoker)delegate { 
        if (m_tracing)
        {
          if (m_tracingForm == null)
          {
            m_tracingForm = new TracingForm();
            m_tracingForm.Show();
          }
          if (m_tracingForm != null)
          {
            //m_tracingForm.Log.Focus();
            m_tracingForm.Log.Text = m_tracingForm.Log.Text + "Inbound: " + xml + "\r\n\r\n";
            m_tracingForm.Log.SelectionStart = m_tracingForm.Log.Text.Length + 1;
            m_tracingForm.Log.ScrollToCaret();
            //m_dlgTracing.ebLog.SelectionLength = 0;
          }
        }
      });

      return xml;
    }
  }
}
