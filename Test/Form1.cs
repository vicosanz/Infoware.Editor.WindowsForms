using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var fields = new List<string>() { "{name}", "{value}" };
            textEditor1.Fields = fields;
            htmlEditor1.Fields = fields;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = textEditor1.Text;
            result = result.Replace("{name}", "John").Replace("{value}", "Sr");
            MessageBox.Show(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(htmlEditor1.BodyText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(htmlEditor1.BodyHtml);

        }
    }

}
