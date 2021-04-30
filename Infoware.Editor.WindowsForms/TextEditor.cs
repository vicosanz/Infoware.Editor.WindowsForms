using System.Collections.Generic;
using System.Windows.Forms;

namespace Infoware.Editor.WindowsForms
{
    public partial class TextEditor : UserControl
    {
        private List<string> fields;

        public bool MultiLine
        {
            get => textBox1.Multiline;
            set => textBox1.Multiline = value;
        }
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

        private void CboInsert_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int selectionStart = textBox1.SelectionStart;
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Text = textBox1.Text.Remove(selectionStart, textBox1.SelectionLength);
            }
            textBox1.Text = textBox1.Text.Insert(selectionStart, e.ClickedItem.Text);
            textBox1.SelectionStart = selectionStart + e.ClickedItem.Text.Length;
        }

        public new string Text
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public TextEditor()
        {
            InitializeComponent();
            cboInsert.DropDownItemClicked += CboInsert_DropDownItemClicked;
        }


    }
}
