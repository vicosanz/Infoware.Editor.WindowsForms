
namespace Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textEditor1 = new Infoware.Editor.WindowsForms.TextEditor();
            this.button1 = new System.Windows.Forms.Button();
            this.htmlEditor1 = new Infoware.Editor.WindowsForms.HtmlEditor();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textEditor1
            // 
            this.textEditor1.Fields = null;
            this.textEditor1.Location = new System.Drawing.Point(12, 29);
            this.textEditor1.MultiLine = false;
            this.textEditor1.Name = "textEditor1";
            this.textEditor1.Size = new System.Drawing.Size(513, 84);
            this.textEditor1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.BodyBackgroundColor = System.Drawing.Color.White;
            this.htmlEditor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.htmlEditor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.htmlEditor1.Fields = null;
            this.htmlEditor1.FontSize = Infoware.Editor.WindowsForms.Enums.EnumFontSize.Three;
            this.htmlEditor1.Location = new System.Drawing.Point(12, 116);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.Size = new System.Drawing.Size(982, 322);
            this.htmlEditor1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 454);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "html";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 550);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.htmlEditor1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textEditor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Infoware.Editor.WindowsForms.TextEditor textEditor1;
        private System.Windows.Forms.Button button1;
        private Infoware.Editor.WindowsForms.HtmlEditor htmlEditor1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

