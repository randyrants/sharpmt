using System;
using System.Collections;
using SharpMTClasses;

namespace Phone_SharpMT
{
  /// <summary>
  /// Summary description for sortObjects.
  /// </summary>
  public class sortObjects : IComparer
  {
    public sortObjects()
    {
    }
  
    // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
    int IComparer.Compare( Object x, Object y )  
    {
      return( (new CaseInsensitiveComparer()).Compare( ((CCatItem)x).strName, ((CCatItem)y).strName ) );
    }
  }
}
