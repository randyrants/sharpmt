#region Using directives

using System;

#endregion

namespace SharpMT.Classes
{
  public class EntryItem
  {
    private string title;
    private string url;
    private string id;
    private string body;
    private string dateTime;
    public EntryItem()
    {
      title = "";
      url = "";
      id = "";
      body = "";
      dateTime = "";
    }

    #region Properties
    public string Title
    {
      get { return title; }
      set { title = value; }
    }
    public string Url
    {
      get { return url; }
      set { url = value; }
    }
    public string ID
    {
      get { return id; }
      set { id = value; }
    }
    public string Body
    {
      get { return body; }
      set { body = value; }
    }
    public string DateTime
    {
      get { return dateTime; }
      set { dateTime = value; }
    }

    #endregion
  }
}
