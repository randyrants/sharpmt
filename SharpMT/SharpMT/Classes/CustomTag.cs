#region Using directives

using System;

#endregion

namespace SharpMT.Classes
{
  public struct CustomTag
  {
    private string tag;
    private bool closed;

    public CustomTag(string Tag, bool Closed)
    {
      tag = Tag;
      closed = Closed;
    }

    public CustomTag(string Tag, int Closed) {
      tag = Tag;
      if (Closed == 1)
        closed = true;
      else
        closed = false;
    }

    #region Properties
    public string Tag
    {
      get { return tag; }
      set { tag = value; }
    }
    public bool Closed
    {
      get { return closed; }
      set { closed = value; }
    }

    #endregion
  }
}
