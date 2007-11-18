namespace SharpMT.Forms
{
  partial class AddUrlForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.tabs = new System.Windows.Forms.TabControl();
      this.urlPage = new System.Windows.Forms.TabPage();
      this.urlTyped = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.linksPage = new System.Windows.Forms.TabPage();
      this.linksListView = new System.Windows.Forms.ListView();
      this.linksTitleColumn = new System.Windows.Forms.ColumnHeader("");
      this.linksIdColumn = new System.Windows.Forms.ColumnHeader("");
      this.favoritesPage = new System.Windows.Forms.TabPage();
      this.favoritesListView = new System.Windows.Forms.ListView();
      this.nameColumn = new System.Windows.Forms.ColumnHeader("");
      this.urlColumn = new System.Windows.Forms.ColumnHeader("");
      this.linkTitle = new System.Windows.Forms.TextBox();
      this.linkText = new System.Windows.Forms.TextBox();
      this.linkTarget = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tabs.SuspendLayout();
      this.urlPage.SuspendLayout();
      this.linksPage.SuspendLayout();
      this.favoritesPage.SuspendLayout();
      this.SuspendLayout();
// 
// cancelButton
// 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.cancelButton.Location = new System.Drawing.Point(391, 328);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.TabIndex = 8;
      this.cancelButton.Text = "Cancel";
// 
// okButton
// 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.okButton.Location = new System.Drawing.Point(309, 328);
      this.okButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
      this.okButton.Name = "okButton";
      this.okButton.TabIndex = 7;
      this.okButton.Text = "OK";
// 
// tabs
// 
      this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.tabs.Controls.Add(this.urlPage);
      this.tabs.Controls.Add(this.linksPage);
      this.tabs.Controls.Add(this.favoritesPage);
      this.tabs.Location = new System.Drawing.Point(13, 13);
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Size = new System.Drawing.Size(453, 227);
      this.tabs.TabIndex = 0;
      this.tabs.Enter += new System.EventHandler(this.tabs_Enter);
// 
// urlPage
// 
      this.urlPage.Controls.Add(this.urlTyped);
      this.urlPage.Controls.Add(this.label4);
      this.urlPage.Location = new System.Drawing.Point(4, 22);
      this.urlPage.Name = "urlPage";
      this.urlPage.Padding = new System.Windows.Forms.Padding(3);
      this.urlPage.Size = new System.Drawing.Size(445, 201);
      this.urlPage.TabIndex = 0;
      this.urlPage.Text = "URL";
// 
// urlTyped
// 
      this.urlTyped.AutoCompleteMode = ((System.Windows.Forms.AutoCompleteMode)((System.Windows.Forms.AutoCompleteMode.Suggest | System.Windows.Forms.AutoCompleteMode.Append)));
      this.urlTyped.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
      this.urlTyped.FormattingEnabled = true;
      this.urlTyped.Location = new System.Drawing.Point(71, 7);
      this.urlTyped.Name = "urlTyped";
      this.urlTyped.Size = new System.Drawing.Size(368, 21);
      this.urlTyped.TabIndex = 1;
// 
// label4
// 
      this.label4.AutoSize = true;
      this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label4.Location = new System.Drawing.Point(9, 10);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(28, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "&URL:";
// 
// linksPage
// 
      this.linksPage.Controls.Add(this.linksListView);
      this.linksPage.Location = new System.Drawing.Point(4, 22);
      this.linksPage.Name = "linksPage";
      this.linksPage.Padding = new System.Windows.Forms.Padding(3);
      this.linksPage.Size = new System.Drawing.Size(445, 201);
      this.linksPage.TabIndex = 1;
      this.linksPage.Text = "Blog Links";
// 
// linksListView
// 
      this.linksListView.AutoArrange = false;
      this.linksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.linksTitleColumn,
            this.linksIdColumn});
      this.linksListView.FullRowSelect = true;
      this.linksListView.HideSelection = false;
      this.linksListView.Location = new System.Drawing.Point(3, 3);
      this.linksListView.MultiSelect = false;
      this.linksListView.Name = "linksListView";
      this.linksListView.Size = new System.Drawing.Size(439, 195);
      this.linksListView.TabIndex = 0;
      this.linksListView.View = System.Windows.Forms.View.Details;
      this.linksListView.DoubleClick += new System.EventHandler(this.linksList_DoubleClick);
      this.linksListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.linksList_ColumnClick);
// 
// linksTitleColumn
// 
      this.linksTitleColumn.Text = "Title";
      this.linksTitleColumn.Width = 700;
// 
// linksIdColumn
// 
      this.linksIdColumn.Text = "ID";
      this.linksIdColumn.Width = 40;
// 
// favoritesPage
// 
      this.favoritesPage.Controls.Add(this.favoritesListView);
      this.favoritesPage.Location = new System.Drawing.Point(4, 22);
      this.favoritesPage.Name = "favoritesPage";
      this.favoritesPage.Size = new System.Drawing.Size(445, 201);
      this.favoritesPage.TabIndex = 2;
      this.favoritesPage.Text = "Favorites";
// 
// favoritesListView
// 
      this.favoritesListView.AutoArrange = false;
      this.favoritesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.urlColumn});
      this.favoritesListView.FullRowSelect = true;
      this.favoritesListView.HideSelection = false;
      this.favoritesListView.Location = new System.Drawing.Point(4, 3);
      this.favoritesListView.MultiSelect = false;
      this.favoritesListView.Name = "favoritesListView";
      this.favoritesListView.Size = new System.Drawing.Size(439, 195);
      this.favoritesListView.TabIndex = 0;
      this.favoritesListView.View = System.Windows.Forms.View.Details;
      this.favoritesListView.DoubleClick += new System.EventHandler(this.favoritesList_DoubleClick);
// 
// nameColumn
// 
      this.nameColumn.Text = "Name";
      this.nameColumn.Width = 250;
// 
// urlColumn
// 
      this.urlColumn.Text = "URL";
      this.urlColumn.Width = 500;
// 
// linkTitle
// 
      this.linkTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.linkTitle.Location = new System.Drawing.Point(77, 274);
      this.linkTitle.Name = "linkTitle";
      this.linkTitle.Size = new System.Drawing.Size(389, 20);
      this.linkTitle.TabIndex = 4;
// 
// linkText
// 
      this.linkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.linkText.Location = new System.Drawing.Point(77, 247);
      this.linkText.Name = "linkText";
      this.linkText.Size = new System.Drawing.Size(389, 20);
      this.linkText.TabIndex = 2;
// 
// linkTarget
// 
      this.linkTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.linkTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.linkTarget.FormattingEnabled = true;
      this.linkTarget.Items.AddRange(new object[] {
            "_self",
            "_parent",
            "_top",
            "_blank"});
      this.linkTarget.Location = new System.Drawing.Point(77, 301);
      this.linkTarget.Name = "linkTarget";
      this.linkTarget.Size = new System.Drawing.Size(179, 21);
      this.linkTarget.TabIndex = 6;
// 
// label1
// 
      this.label1.AutoSize = true;
      this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label1.Location = new System.Drawing.Point(17, 250);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "&Text:";
// 
// label2
// 
      this.label2.AutoSize = true;
      this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label2.Location = new System.Drawing.Point(17, 277);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "T&itle:";
// 
// label3
// 
      this.label3.AutoSize = true;
      this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.label3.Location = new System.Drawing.Point(17, 304);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "T&arget:";
// 
// AddUrlForm
// 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(478, 363);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.linkTarget);
      this.Controls.Add(this.linkText);
      this.Controls.Add(this.linkTitle);
      this.Controls.Add(this.tabs);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddUrlForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add URL";
      this.Load += new System.EventHandler(this.AddUrlForm_Load);
      this.tabs.ResumeLayout(false);
      this.urlPage.ResumeLayout(false);
      this.urlPage.PerformLayout();
      this.linksPage.ResumeLayout(false);
      this.favoritesPage.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.TabPage urlPage;
    private System.Windows.Forms.TabPage linksPage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TabPage favoritesPage;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ColumnHeader linksTitleColumn;
    private System.Windows.Forms.ColumnHeader linksIdColumn;
    internal System.Windows.Forms.ListView linksListView;
    internal System.Windows.Forms.ListView favoritesListView;
    private System.Windows.Forms.ColumnHeader nameColumn;
    private System.Windows.Forms.ColumnHeader urlColumn;
    internal System.Windows.Forms.TabControl tabs;
    private System.Windows.Forms.TextBox linkTitle;
    private System.Windows.Forms.TextBox linkText;
    private System.Windows.Forms.ComboBox linkTarget;
    internal System.Windows.Forms.ComboBox urlTyped;
  }
}