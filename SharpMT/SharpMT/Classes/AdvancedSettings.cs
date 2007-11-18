#region Using directives

using System;

#endregion

namespace SharpMT.Classes
{
  public class AdvancedSettings
  {
    private int status;
    private int comments;
    private int format;
    private bool allowPings;
    private bool useServerTime;

    public AdvancedSettings()
    {
      status = 0;
      comments = 0;
      format = 0;
      allowPings = false;
      useServerTime = true;
    }

    #region Properties
    public int Status
    {
      get { return status; }
      set { status = value; }
    }
    public int Comments
    {
      get { return comments; }
      set { comments = value; }
    }
    public int Format
    {
      get { return format; }
      set { format = value; }
    }
    public bool AllowPings
    {
      get { return allowPings; }
      set { allowPings = value; }
    }
    public bool UseServerTime
    {
      get { return useServerTime; }
      set { useServerTime = value; }
    }
	
    #endregion
  }
}
