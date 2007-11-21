namespace RandyRants.SharpMTExtension
{
  public interface ISharpMTExtension
  {
    /// <summary>
    /// Tells SharpMT whether or not to expect a List or a String as a result
    /// If true, ExecuteList() is called
    /// If false, ExecuteString() is called
    /// </summary>
    bool ReturnsList
    {
      get;
    }

    /// <summary>
    /// This command will be called by SharpMT to request the information and return an array of strings as a response.
    /// </summary>
    object[] ExecuteList();

    /// <summary>
    /// This command will be called by SharpMT to request the information and return a single string as a response.
    /// </summary>
    string ExecuteString();

    /// <summary>
    /// The name that SharpMT will use to offer this items as a menu item
    /// </summary>
    string DisplayName
    {
      get;
    }

    /// <summary>
    /// An optional description that SharpMT can show while entering parameters
    /// </summary>
    string DisplayDescription
    {
      get;
    }

    /// <summary>
    /// Return true if the Plug-In will hand its own UI and SharpMT can skip it's Input Dialog
    /// which means that only DisplayName, DisplayDescription, and ExecuteString() will be used
    /// and ParametersPassed, ParamOne, ParamTwo, ParamThree, ReturnsList, and ExecuteList() are ignored
    /// </summary>
    bool HasInputGUI
    {
      get;
    }

    /// <summary>
    /// The maximum number of parameters that SharpMT should collect and pass to the extension
    /// </summary>
    int ParametersPassed
    {
      get;
    }

    /// <summary>
    /// Get: The label to be displayed for the first parameter (optional)
    /// Set: The first parameter that is passed in from SharpMT
    /// </summary>
    string ParamOne
    {
      get;
      set;
    }

    /// <summary>
    /// Get: The label to be displayed for the second parameter (optional)
    /// Set: The second parameter that is passed in from SharpMT
    /// </summary>
    string ParamTwo
    {
      get;
      set;
    }

    /// <summary>
    /// Get: The label to be displayed for the third parameter (optional)
    /// Set: The third parameter that is passed in from SharpMT
    /// </summary>
    string ParamThree
    {
      get;
      set;
    }
  
    /// <summary>
    /// Tells SharpMT whether or not a resulting string should replace any selected text
    /// If true, SharpMT will replace any text that's selected
    /// If false, SharpMT will insert the text at the current cursor position
    /// </summary>
    bool ReplaceSelectedText {
      get;
    }
  }
}
