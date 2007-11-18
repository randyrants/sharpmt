// Version 3.0.0.0

#region Using directives

using System;
using System.Collections;
using RandyRants.SharpMTExtension;

#endregion

namespace ExamplePlugIn
{
  /// <summary>
  /// Summary description for Class1.
  /// </summary>
  public class ExamplePlugIn : ISharpMTExtension
  {
    // Create three string values to hold the three parameters
    string[] Params = { "", "", "" };

    public ExamplePlugIn()
    {
      // Any initalization could be put here
    }

    // Tell the #MT that there will be three parameters used (all optional)
    public int ParametersPassed
    {
      get
      {
        return Params.Length;
      }
    }

    // This is the name that will be shown on behalf of the plug-in
    public string DisplayName
    {
      get
      {
        return "#MT Calculator";
      }
    }

    // This is the description that will be shown in the add dialog
    public string DisplayDescription
    {
      get
      {
        return "This Plug-In will take two numbers and return the values if they are added together or subtracted from each other.";
      }
    }

    // If this Plug-In had its own GUI for collecting input, this should return true
    public bool HasInputGUI
    {
      get
      {
        return false;
      }
    }

    // the first parameter - the get value will be used a label
    public string ParamOne
    {
      get
      {
        return "First number";
      }
      set
      {
        Params[0] = value;
      }
    }

    // the second parameter - the get value will be used a label
    public string ParamTwo
    {
      get
      {
        return "Second number";
      }
      set
      {
        Params[1] = value;
      }
    }

    // the third parameter - the get value will be used a label
    public string ParamThree
    {
      get
      {
        return "Optional";
      }
      set
      {
        Params[2] = value;
      }
    }

    // the guts of the plug-in:
    // This Plug-In will return a List when it is called
    public bool ReturnsList
    {
      get
      {
        return true;
      }
    }

    // calling ExecuteList will return an array of strings in the form of: object []
    public object[] ExecuteList()
    {
      ArrayList Results = new ArrayList();
      // convert and verify that a number was passed in
      decimal NumberOne = 0;
      try
      {
        NumberOne = Convert.ToDecimal(Params[0]);
      }
      catch
      {
        Results.Add(String.Format("{0} is not a number!", Params[0]));
        return Results.ToArray();
      }

      // convert and verify that a number was passed in
      decimal NumberTwo = 0;
      try
      {
        NumberTwo = Convert.ToDecimal(Params[1]);
      }
      catch
      {
        Results.Add(String.Format("{0} is not a number!", Params[1]));
        return Results.ToArray();
      }

      Results.Add(String.Format("{0} + {1} = {2} --- {3}", NumberOne, NumberTwo, NumberOne + NumberTwo, Params[2]));
      Results.Add(String.Format("{0} - {1} = {2} --- {3}", NumberOne, NumberTwo, NumberOne - NumberTwo, Params[2]));
      Results.Add(String.Format("{0} - {1} = {2} --- {3}", NumberTwo, NumberOne, NumberTwo - NumberOne, Params[2]));
      Results.Add(String.Format("<a href=\"http://www.randyrants.com/\">Sample Link Example - {3}</a>", NumberTwo, NumberOne, NumberTwo - NumberOne, Params[2]));
      return Results.ToArray();
    }

    // ExecuteString isn't used in this Plug-In
    // but if it was, you'd have your UI in here...
    public string ExecuteString()
    {
      return "";
    }

    // This tells SharpMT that any select text will be replaced
    public bool ReplaceSelectedText {
      get {
        return false;
      }
    }
  }
}
