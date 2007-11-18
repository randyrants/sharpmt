using System;

namespace SharpMTClasses
{
	/// <summary>
	/// Summary description for CAdvSettings.
	/// </summary>
	public class CAdvSettings
	{
    public int nStatus;
    public int nComments;
    public int nFormat;
    public bool   bAllowPings;
    public bool   bUseServerTime;

    public CAdvSettings()
		{
      nStatus = 0;
      nComments = 0;
      nFormat = 0;
      bAllowPings = false;		
      bUseServerTime = true;
    }
	}
}
