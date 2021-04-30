using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoware.Editor.WindowsForms
{
    public partial class FrmInsertLink : Form
    {
        public FrmInsertLink(string title, string caption)
        {
            InitializeComponent();
            Text ??= title;
            lblCaption.Text = caption;
            linkLabel1.Click += LinkLabel1_Click;
        }

        private void LinkLabel1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new()
            {
                FileName = linkLabel1.Text,
                UseShellExecute = true
            }; 
            Process.Start(sInfo);
        }

        public string Scheme { get => cboScheme.Text; set => cboScheme.Text = value; }
        public string URL { get => txtUrl.Text.Trim(); set => txtUrl.Text = value; }

        private void cboScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLink();
        }

        private void UpdateLink()
        {
            linkLabel1.Text = $"{cboScheme.Text}{txtUrl.Text}";
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            UpdateLink();
        }
    }
}
