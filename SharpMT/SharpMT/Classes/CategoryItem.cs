#region Using directives

using System;

#endregion

namespace SharpMT.Classes
{
  public class CategoryItem
  {
    private string id;
    private string name;

    public CategoryItem():this("","") {}
    public CategoryItem(string ID, string Name)
    {
      id = ID;
      name = Name;
    }
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
  }
}
