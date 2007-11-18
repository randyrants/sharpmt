#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace SharpMT.Classes
{
  public class PostItem
  {
    private string title;
    private string entry;
    private string extended;
    private string excerpt;
    private List<String> categories;
    private string postStatus;
    private string textFormatting;
    private string allowComments;
    private string allowPings;
    private string keyword;
    private string pings;
    private bool posted;
    private string dateTime;
    private string postId;
    private bool newDraft;
    private int currentIndex;

    public PostItem()
    {
      title = "";
      entry = "";
      extended = "";
      excerpt = "";
      categories = new System.Collections.Generic.List<String>();
      postStatus = "0";
      textFormatting = "0";
      allowComments = "0";
      allowPings = "0";
      keyword = "";
      pings = "";
      posted = false;
      dateTime = "";
      postId = "";
      newDraft = false;
      currentIndex = -1;
    }

    #region Properties
    public string Title
    {
      get { return title; }
      set { title = value; }
    }
    public string Entry
    {
      get { return entry; }
      set { entry = value; }
    }
    public string Extended
    {
      get { return extended; }
      set { extended = value; }
    }
    public string Excerpt
    {
      get { return excerpt; }
      set { excerpt = value; }
    }
    public List<String> Categories
    {
      get { return categories; }
      set { categories = value; }
    }
    public string PostStatus
    {
      get { return postStatus; }
      set { postStatus = value; }
    }
    public string TextFormatting
    {
      get { return textFormatting; }
      set { textFormatting = value; }
    }
    public string AllowComments
    {
      get { return allowComments; }
      set { allowComments = value; }
    }
    public string AllowPings
    {
      get { return allowPings; }
      set { allowPings = value; }
    }
    public string Keyword
    {
      get { return keyword; }
      set { keyword = value; }
    }
    public string Pings
    {
      get { return pings; }
      set { pings = value; }
    }
    public bool IsPosted
    {
      get { return posted; }
      set { posted = value; }
    }
    public string DateTime
    {
      get { return dateTime; }
      set { dateTime = value; }
    }
    public string PostId
    {
      get { return postId; }
      set { postId = value; }
    }
    public bool NewDraft
    {
      get { return newDraft; }
      set { newDraft = value; }
    }
    public int CurrentIndex
    {
      get { return currentIndex; }
      set { currentIndex = value; }
    }
    #endregion

    internal void EncodeHTML()
    {
      title = ConvertHack(title);
      entry = ConvertHack(entry);
      extended = ConvertHack(extended);
      excerpt = ConvertHack(excerpt);
      keyword = ConvertHack(keyword);
    }

    private string ConvertHack(string input)
    {
      int encodedChar;
      string output = "";
      foreach (char c in input)
      {
        encodedChar = c;
        if (!((encodedChar >= 160) && (encodedChar < 256)))
        {
          switch (encodedChar) {
            case 8211:
            case 8212:
            case 8213:
            case 8216:
            case 8217:
            case 8220:
            case 8221:
              // convert to entity format ?
              output += string.Format("&#{0};", encodedChar);
              break;
            default:
              // if in 'ascii' range - *THINK* this works....
              output += c; // leave as-is
              break;
          }
        }
        else
        { // convert to entity format ?
          output += string.Format("&#{0};", encodedChar);
        }
      }
      return output;
    }
  }
}
