#region Using directives

using System;

#endregion

namespace SharpMT.Classes
{
  public class BlogItem
  {
    private string id;
    private string name;
    private string url;

    public BlogItem():this("", "", "") {}
    public BlogItem(string ID, string Name, string Url) {
      id = ID;
      name = Name;
      url = Url;
    }
    #region Properties
    public string ID
    {
      get { return id; }
      set { id = value; }
    }
    public string Name
    {
      get { return name; }
      set { name = value; }
    }
    public string Url
    {
      get { return url; }
      set { url = value; }
    }
    #endregion
  }
}
