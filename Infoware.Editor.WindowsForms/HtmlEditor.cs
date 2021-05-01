using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Infoware.Editor.WindowsForms.Enums;
using mshtml;

namespace Infoware.Editor.WindowsForms
{
    public partial class HtmlEditor : UserControl
    {
        private WebBrowser webBrowser1;

        public delegate void TickDelegate();
        public event TickDelegate Tick;

        public event MethodInvoker BoldChanged;
        public event MethodInvoker ItalicChanged;
        public event MethodInvoker UnderlineChanged;
        public event MethodInvoker OrderedListChanged;
        public event MethodInvoker UnorderedListChanged;
        public event MethodInvoker JustifyLeftChanged;
        public event MethodInvoker JustifyCenterChanged;
        public event MethodInvoker JustifyRightChanged;
        public event MethodInvoker JustifyFullChanged;
        public event MethodInvoker IsLinkChanged;
        public event MethodInvoker HtmlFontChanged;
        public event MethodInvoker HtmlFontSizeChanged;

        public HtmlEditor()
        {
            Load += Editor_Load;
            InitializeComponent();
            InitBrowser();
            InitComboFonts();
            InitComboFontSize();
            InitTimer();
            InitButtonsHandlers();
            InitInsertFields();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        #region result
        public string BodyText
        {
            get => (webBrowser1.Document?.Body) is null ? string.Empty : webBrowser1.Document.Body.InnerText;
            set
            {
                Document.OpenNew(false);
                if (webBrowser1.Document.Body != null)
                {
                    webBrowser1.Document.Body.InnerText = HttpUtility.HtmlEncode(value);
                }
            }
        }

        public string BodyHtml
        {
            get => (webBrowser1.Document?.Body) is null ? string.Empty : webBrowser1.Document.Body.InnerHtml;
            set
            {
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerHtml = value;
            }
        }

        public string Html
        {
            get => (webBrowser1.Document?.Body) is null ? string.Empty : webBrowser1.Document.Body.InnerHtml;
            set
            {
                Document.OpenNew(false);
                var dom = Document.DomDocument as IHTMLDocument2;
                try
                {
                    if (value == null)
                        dom.clear();
                    else
                        dom.write(value);
                }
                finally
                {
                    dom.close();
                }
            }
        }

        public HtmlDocument Document => webBrowser1.Document;
        #endregion

        #region Fields
        private List<string> fields;
        public List<string> Fields
        {
            get => fields;
            set
            {
                fields = value;
                SetFields();
            }
        }

        private void SetFields()
        {
            cboInsert.DropDownItems.Clear();
            if (fields is null)
            {
                cboInsert.Visible = false;
            }
            else
            {
                cboInsert.Visible = true;
                fields.ForEach(item =>
                {
                    cboInsert.DropDownItems.Add(
                        item
                    );
                });
            }
        }

        private void InitInsertFields()
        {
            cboInsert.DropDownItemClicked += CboInsert_DropDownItemClicked;
        }

        private void CboInsert_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Clipboard.SetText(e.ClickedItem.Text);
            Paste();
        }
        #endregion

        #region Color
        public Color EditorForeColor
        {
            get
            {
                if (ReadyState != EnumReadyState.Complete)
                {
                    return Color.Black;
                }

                return ConvertToColor(doc.queryCommandValue("ForeColor").ToString());
            }
            set
            {
                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("ForeColor", false, colorstr);
            }
        }

        public Color EditorBackColor
        {
            get => ReadyState is EnumReadyState.Complete ? ConvertToColor(doc.queryCommandValue("BackColor").ToString()) : Color.White;
            set
            {
                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("BackColor", false, colorstr);
            }
        }

        public Color BodyBackgroundColor
        {
            get => (doc.body?.style?.backgroundColor) is null ? Color.White : ConvertToColor(doc.body.style.backgroundColor.ToString());
            set
            {
                if (ReadyState == EnumReadyState.Complete)
                {
                    if (doc.body?.style != null)
                    {
                        string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                        doc.body.style.backgroundColor = colorstr;
                    }
                }
            }
        }

        private static Color ConvertToColor(string clrs)
        {
            int red, green, blue;
            // sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            if (clrs.StartsWith("#"))
            {
                int clrn = Convert.ToInt32(clrs.Substring(1), 16);
                red = (clrn >> 16) & 255;
                green = (clrn >> 8) & 255;
                blue = clrn & 255;
            }
            else // otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
            {
                int clrn = Convert.ToInt32(clrs);
                red = clrn & 255;
                green = (clrn >> 8) & 255;
                blue = (clrn >> 16) & 255;
            }
            Color incolor = Color.FromArgb(red, green, blue);
            return incolor;
        }

        public void SelectForeColor()
        {
            Color color = EditorForeColor;
            if (ShowColorDialog(ref color))
                EditorForeColor = color;
        }

        public void SelectBackColor()
        {
            Color color = EditorBackColor;
            if (ShowColorDialog(ref color))
                EditorBackColor = color;
        }

        private bool ShowColorDialog(ref Color color)
        {
            bool selected;
            using (ColorDialog dlg = new())
            {
                dlg.SolidColorOnly = true;
                dlg.AllowFullOpen = false;
                dlg.AnyColor = false;
                dlg.FullOpen = false;
                dlg.CustomColors = null;
                dlg.Color = color;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    selected = true;
                    color = dlg.Color;
                }
                else
                {
                    selected = false;
                }
            }
            return selected;
        }

        public void SelectBodyColor()
        {
            Color color = BodyBackgroundColor;
            if (ShowColorDialog(ref color))
                BodyBackgroundColor = color;
        }
        #endregion

        #region Link
        public void SelectLink()
        {
            string url = string.Empty;
            switch (SelectionType)
            {
                case EnumSelectionType.Control:
                    {
                        if (doc.selection.createRange() is IHTMLControlRange range && range.length > 0)
                        {
                            var elem = range.item(0);
                            if (elem != null && string.Compare(elem.tagName, "img", true) == 0)
                            {
                                elem = elem.parentElement;
                                if (elem != null && string.Compare(elem.tagName, "a", true) == 0)
                                {
                                    url = elem.getAttribute("href") as string;
                                }
                            }
                        }
                    }
                    break;
                case EnumSelectionType.Text:
                    {
                        IHTMLTxtRange txtRange = (IHTMLTxtRange)doc.selection.createRange();
                        if (txtRange != null && !string.IsNullOrEmpty(txtRange.htmlText))
                        {
                            Regex regex = new("^\\s*<a href=\"([^\"]+)\">[^<]+</a>\\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                            Match match = regex.Match(txtRange.htmlText);

                            if (match.Success)
                                url = match.Groups[1].Value;
                        }
                    }
                    break;
                case EnumSelectionType.None:
                    return;
            }
            using FrmInsertLink dlg = new("Inserta enlace","Enlace");
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                dlg.URL = $"{uri.Host}{uri?.PathAndQuery.TrimEnd('/')}";
                dlg.Scheme = $"{uri.Scheme}://";
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string link = $"{dlg.Scheme}{dlg.URL}";
                if (string.IsNullOrWhiteSpace(link))
                {
                    MessageBox.Show("Invalid URL");
                    return;
                }
                InsertLink(link);
            }
        }

        #endregion

        #region Buttons
        private void InitButtonsHandlers()
        {
            btnBold.CheckedChanged += (s, e) => BoldChanged?.Invoke();
            btnItalic.CheckedChanged += (s, e) => ItalicChanged?.Invoke();
            btnUnderline.CheckedChanged += (s, e) => UnderlineChanged?.Invoke();
            btnOrdererList.CheckedChanged += (s, e) => OrderedListChanged?.Invoke();
            btnUnordererList.CheckedChanged += (s, e) => UnorderedListChanged.Invoke();
            btnJustifyLeft.CheckedChanged += (s, e) => JustifyLeftChanged?.Invoke();
            btnJustifyCenter.CheckedChanged += (s, e) => JustifyCenterChanged?.Invoke();
            btnJustifyRight.CheckedChanged += (s, e) => JustifyRightChanged?.Invoke();
            btnJustifyFull.CheckedChanged += (s, e) => JustifyFullChanged?.Invoke();
            btnLink.CheckedChanged += (s, e) => IsLinkChanged?.Invoke();

            btnBold.Click += (s, e) => Bold();
            btnItalic.Click += (s, e) => Italic();
            btnUnderline.Click += (s, e) => Underline();

            btnCut.Click += (s, e) => Cut();
            btnCopy.Click += (s, e) => Copy();
            btnPaste.Click += (s, e) => Paste();
            btnDelete.Click += (s, e) => Delete();

            btnFontColor.Click += (s, e) => SelectForeColor();
            btnBackColor.Click += (s, e) => SelectBackColor();

            btnLink.Click += (s, e) => SelectLink();
            btnimage.Click += (s, e) => InsertImage();

            btnJustifyLeft.Click += (s, e) => JustifyLeft();
            btnJustifyCenter.Click += (s, e) => JustifyCenter();
            btnJustifyRight.Click += (s, e) => JustifyRight();
            btnJustifyFull.Click += (s, e) => JustifyFull();

            btnOrdererList.Click += (s, e) => OrdererList();
            btnUnordererList.Click += (s, e) => UnOrdererList();

            btnOutdent.Click += (s, e) => Outdent();
            btnIndent.Click += (s, e) => Indent();

            btnBackgroundColor.Click+= (s,e) => SelectBodyColor();
        }

        public void InsertImage() => webBrowser1.Document.ExecCommand("InsertImage", true, null);

        public void InsertLink(string url) => webBrowser1.Document.ExecCommand("CreateLink", false, url);

        public void Bold() => webBrowser1.Document.ExecCommand("Bold", false, null);

        public void Italic() => webBrowser1.Document.ExecCommand("Italic", false, null);

        public void Underline() => webBrowser1.Document.ExecCommand("Underline", false, null);

        public void Cut() => webBrowser1.Document.ExecCommand("Cut", false, null);

        public void Copy() => webBrowser1.Document.ExecCommand("Copy", false, null);

        public void Paste() => webBrowser1.Document.ExecCommand("Paste", false, null);

        public void Delete() => webBrowser1.Document.ExecCommand("Delete", false, null);

        public void Indent() => webBrowser1.Document.ExecCommand("Indent", false, null);

        public void Outdent() => webBrowser1.Document.ExecCommand("Outdent", false, null);

        public void UnOrdererList() => webBrowser1.Document.ExecCommand("InsertUnorderedList", false, null);

        public void OrdererList() => webBrowser1.Document.ExecCommand("InsertOrderedList", false, null);

        public void JustifyFull() => webBrowser1.Document.ExecCommand("JustifyFull", false, null);

        public void JustifyRight() => webBrowser1.Document.ExecCommand("JustifyRight", false, null);

        public void JustifyLeft() => webBrowser1.Document.ExecCommand("JustifyLeft", false, null);

        public void JustifyCenter() => webBrowser1.Document.ExecCommand("JustifyCenter", false, null);

        #endregion

        #region Timer
        private void InitTimer()
        {
            timer1.Interval = 200;
            timer1.Tick += new EventHandler(Timer1_Tick);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ReadyState != EnumReadyState.Complete) return;
            SetupKeyListener();

            btnBold.Checked = IsBold();
            btnItalic.Checked = IsItalic();
            btnUnderline.Checked = IsUnderline();
            btnOrdererList.Checked = IsOrderedList();
            btnUnordererList.Checked = IsUnorderedList();
            btnJustifyLeft.Checked = IsJustifyLeft();
            btnJustifyCenter.Checked = IsJustifyCenter();
            btnJustifyRight.Checked = IsJustifyRight();
            btnJustifyFull.Checked = IsJustifyFull();

            btnLink.Enabled = CanInsertLink();

            UpdateFontComboBox();
            UpdateFontSizeComboBox();
            UpdateImageSizes();

            Tick?.Invoke();
        }
        private void SetupKeyListener()
        {
            if (!setup)
            {
                webBrowser1.Document.Body.KeyDown += Body_KeyDown;
                setup = true;
            }
        }

        public event EventHandler<EnterKeyEventArgs> EnterKeyEvent;

        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            if (e.KeyPressedCode == 13 && !e.ShiftKeyPressed)
            {
                // handle enter code cancellation
                bool cancel = false;
                if (EnterKeyEvent != null)
                {
                    EnterKeyEventArgs args = new();
                    EnterKeyEvent(this, args);
                    cancel = args.Cancel;
                }
                e.ReturnValue = !cancel;
            }
        }

        private void UpdateImageSizes()
        {
            foreach (HTMLImg image in doc.images)
            {
                if (image != null)
                {
                    if (image.height != image.style.pixelHeight && image.style.pixelHeight != 0)
                        image.height = image.style.pixelHeight;
                    if (image.width != image.style.pixelWidth && image.style.pixelWidth != 0)
                        image.width = image.style.pixelWidth;
                }
            }
        }
        #endregion

        #region Browser
        private IHTMLDocument2 doc;

        public EnumReadyState ReadyState => doc.readyState.ToLower() switch
        {
            "uninitialized" => EnumReadyState.Uninitialized,
            "loading" => EnumReadyState.Loading,
            "loaded" => EnumReadyState.Loaded,
            "interactive" => EnumReadyState.Interactive,
            "complete" => EnumReadyState.Complete,
            _ => EnumReadyState.Uninitialized,
        };

        private void InitBrowser()
        {
            webBrowser1 = new()
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(webBrowser1);

            webBrowser1.DocumentText = "<html><body></body></html>";
            doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";
            webBrowser1.Document.ContextMenuShowing += Document_ContextMenuShowing;
        }

        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
            btnCut.Enabled = CanCut();
            btnCopy.Enabled = CanCopy();
            btnPaste.Enabled = CanPaste();
            btnDelete.Enabled = CanDelete();
            contextMenuStrip1.Show(this, e.ClientMousePosition);
        }


        public EnumSelectionType SelectionType => doc.selection.type.ToLower() switch
        {
            "text" => EnumSelectionType.Text,
            "control" => EnumSelectionType.Control,
            "none" => EnumSelectionType.None,
            _ => EnumSelectionType.None,
        };

        private bool LinksInSelection()
        {
            if (SelectionType != EnumSelectionType.Text) return false;
            bool twoOrMoreLinksInSelection = false;
            IHTMLTxtRange txtRange = (IHTMLTxtRange)doc.selection.createRange();

            if (txtRange != null && !string.IsNullOrEmpty(txtRange.htmlText))
            {
                Regex regex = new("<a href=\"[^\"]+\">[^<]+</a>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                MatchCollection matchCollection = regex.Matches(txtRange.htmlText);

                twoOrMoreLinksInSelection = (matchCollection.Count > 1); // true if more than one link is selected
            }
            return twoOrMoreLinksInSelection;
        }

        #endregion

        #region font
        private bool updatingFontName = false;
        public FontFamily FontName
        {
            get => ReadyState != EnumReadyState.Complete || doc.queryCommandValue("FontName") is not string name ? null : new FontFamily(name);
            set
            {
                if (value is null)
                    return;
                webBrowser1.Document.ExecCommand("FontName", false, value.Name);
            }
        }

        private void InitComboFonts()
        {
            AutoCompleteStringCollection ac = new();
            foreach (FontFamily fam in FontFamily.Families)
            {
                fontComboBox.Items.Add(fam.Name);
                ac.Add(fam.Name);
            }
            fontComboBox.Leave += FontComboBox_TextChanged;
            fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            fontComboBox.AutoCompleteCustomSource = ac;
        }

        private void FontComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontName) return;
            FontFamily ff;
            try
            {
                ff = new FontFamily(fontComboBox.Text);
            }
            catch (Exception)
            {
                updatingFontName = true;
                fontComboBox.Text = FontName.GetName(0);
                updatingFontName = false;
                return;
            }
            FontName = ff;
        }

        private void UpdateFontComboBox()
        {
            if (!fontComboBox.Focused)
            {
                FontFamily fam = FontName;
                if (fam != null)
                {
                    string fontname = fam.Name;
                    if (fontname != fontComboBox.Text)
                    {
                        updatingFontName = true;
                        fontComboBox.Text = fontname;
                        HtmlFontChanged?.Invoke();
                        updatingFontName = false;
                    }
                }
            }
        }
        #endregion

        #region FontSize
        private bool updatingFontSize;
        private bool setup;

        public EnumFontSize FontSize
        {
            get => ReadyState != EnumReadyState.Complete
                    ? EnumFontSize.NA
                    : doc.queryCommandValue("FontSize").ToString() switch
                    {
                        "1" => EnumFontSize.One,
                        "2" => EnumFontSize.Two,
                        "3" => EnumFontSize.Three,
                        "4" => EnumFontSize.Four,
                        "5" => EnumFontSize.Five,
                        "6" => EnumFontSize.Six,
                        "7" => EnumFontSize.Seven,
                        _ => EnumFontSize.NA,
                    };
            set
            {
                var sz = value switch
                {
                    EnumFontSize.One => 1,
                    EnumFontSize.Two => 2,
                    EnumFontSize.Three => 3,
                    EnumFontSize.Four => 4,
                    EnumFontSize.Five => 5,
                    EnumFontSize.Six => 6,
                    EnumFontSize.Seven => 7,
                    _ => 7,
                };
                webBrowser1.Document.ExecCommand("FontSize", false, sz.ToString());
            }
        }

        private void InitComboFontSize()
        {
            Enumerable.Range(1, 7).ToList().ForEach(x =>
                fontSizeComboBox.Items.Add(x.ToString())
            );
            fontSizeComboBox.TextChanged += fontSizeComboBox_TextChanged;
            fontSizeComboBox.KeyPress += fontSizeComboBox_KeyPress;
        }

        private void fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                {
                    fontSizeComboBox.Text = e.KeyChar.ToString();
                }
            }
            else if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontSize) return;
            FontSize = fontSizeComboBox.Text.Trim() switch
            {
                "1" => EnumFontSize.One,
                "2" => EnumFontSize.Two,
                "3" => EnumFontSize.Three,
                "4" => EnumFontSize.Four,
                "5" => EnumFontSize.Five,
                "6" => EnumFontSize.Six,
                "7" => EnumFontSize.Seven,
                _ => EnumFontSize.Seven,
            };
        }

        private void UpdateFontSizeComboBox()
        {
            if (!fontSizeComboBox.Focused)
            {
                var foo = FontSize switch
                {
                    EnumFontSize.One => 1,
                    EnumFontSize.Two => 2,
                    EnumFontSize.Three => 3,
                    EnumFontSize.Four => 4,
                    EnumFontSize.Five => 5,
                    EnumFontSize.Six => 6,
                    EnumFontSize.Seven => 7,
                    EnumFontSize.NA => 0,
                    _ => 7,
                };
                string fontsize = Convert.ToString(foo);
                if (fontsize != fontSizeComboBox.Text)
                {
                    updatingFontSize = true;
                    fontSizeComboBox.Text = fontsize;
                    HtmlFontSizeChanged?.Invoke();
                    updatingFontSize = false;
                }
            }
        }
        #endregion

        #region queries
        public bool CanInsertLink() => (!LinksInSelection());
        public bool CanUndo() => doc.queryCommandEnabled("Undo");
        public bool CanRedo() => doc.queryCommandEnabled("Redo");
        public bool CanCut() => doc.queryCommandEnabled("Cut");
        public bool CanCopy() => doc.queryCommandEnabled("Copy");
        public bool CanPaste() => doc.queryCommandEnabled("Paste");
        public bool CanDelete() => doc.queryCommandEnabled("Delete");
        public bool IsJustifyLeft() => doc.queryCommandState("JustifyLeft");
        public bool IsJustifyRight() => doc.queryCommandState("JustifyRight");
        public bool IsJustifyCenter() => doc.queryCommandState("JustifyCenter");
        public bool IsJustifyFull() => doc.queryCommandState("JustifyFull");
        public bool IsBold() => doc.queryCommandState("Bold");
        public bool IsItalic() => doc.queryCommandState("Italic");
        public bool IsUnderline() => doc.queryCommandState("Underline");
        public bool IsOrderedList() => doc.queryCommandState("InsertOrderedList");
        public bool IsUnorderedList() => doc.queryCommandState("InsertUnorderedList");
        #endregion
    }
}
