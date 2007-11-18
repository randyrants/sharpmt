#region Using directives

using System;

#endregion

namespace SharpMT.Classes
{
  public class PlugInItem
  {
    private string name;
    private string path;

    public PlugInItem():this("PlugIn", "") {}
    public PlugInItem(string Name, string Path) {
      name = Name;
      path = Path;
    }

    #region Properties
    public string Name
    {
      get { return name; }
      set { name = value; }
    }
    public string Path
    {
      get { return path; }
      set { path = value; }
    }
    #endregion

  }
}
