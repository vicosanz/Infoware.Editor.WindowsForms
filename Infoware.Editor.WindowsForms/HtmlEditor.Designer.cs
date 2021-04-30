
namespace Infoware.Editor.WindowsForms
{
    partial class HtmlEditor
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fontComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fontSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFontColor = new System.Windows.Forms.ToolStripButton();
            this.btnBackColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnJustifyLeft = new System.Windows.Forms.ToolStripButton();
            this.btnJustifyCenter = new System.Windows.Forms.ToolStripButton();
            this.btnJustifyRight = new System.Windows.Forms.ToolStripButton();
            this.btnJustifyFull = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOrdererList = new System.Windows.Forms.ToolStripButton();
            this.btnUnordererList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOutdent = new System.Windows.Forms.ToolStripButton();
            this.btnIndent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cboInsert = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnLink = new System.Windows.Forms.ToolStripButton();
            this.btnimage = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontComboBox,
            this.fontSizeComboBox,
            this.toolStripSeparator1,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.toolStripSeparator2,
            this.btnFontColor,
            this.btnBackColor,
            this.toolStripSeparator3,
            this.btnJustifyLeft,
            this.btnJustifyCenter,
            this.btnJustifyRight,
            this.btnJustifyFull,
            this.toolStripSeparator4,
            this.btnOrdererList,
            this.btnUnordererList,
            this.toolStripSeparator5,
            this.btnOutdent,
            this.btnIndent,
            this.toolStripSeparator6,
            this.cboInsert,
            this.btnLink,
            this.btnimage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1013, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fontComboBox
            // 
            this.fontComboBox.DropDownWidth = 200;
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(200, 28);
            // 
            // fontSizeComboBox
            // 
            this.fontSizeComboBox.Name = "fontSizeComboBox";
            this.fontSizeComboBox.Size = new System.Drawing.Size(75, 28);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnBold
            // 
            this.btnBold.CheckOnClick = true;
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.bold;
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(29, 25);
            this.btnBold.Text = "Negrita";
            // 
            // btnItalic
            // 
            this.btnItalic.CheckOnClick = true;
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.italic;
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(29, 25);
            this.btnItalic.Text = "Cursiva";
            // 
            // btnUnderline
            // 
            this.btnUnderline.CheckOnClick = true;
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.underscore;
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(29, 25);
            this.btnUnderline.Text = "Subrayado";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // btnFontColor
            // 
            this.btnFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFontColor.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.color;
            this.btnFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.Size = new System.Drawing.Size(29, 25);
            this.btnFontColor.Text = "Color de fuente";
            // 
            // btnBackColor
            // 
            this.btnBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBackColor.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.backcolor;
            this.btnBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(29, 25);
            this.btnBackColor.Text = "Color de resaltado de texto";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // btnJustifyLeft
            // 
            this.btnJustifyLeft.CheckOnClick = true;
            this.btnJustifyLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJustifyLeft.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.lj;
            this.btnJustifyLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJustifyLeft.Name = "btnJustifyLeft";
            this.btnJustifyLeft.Size = new System.Drawing.Size(29, 25);
            this.btnJustifyLeft.Text = "Justificar a la izquierda";
            this.btnJustifyLeft.ToolTipText = "Alinear a la izquierda";
            // 
            // btnJustifyCenter
            // 
            this.btnJustifyCenter.CheckOnClick = true;
            this.btnJustifyCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJustifyCenter.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.cj;
            this.btnJustifyCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJustifyCenter.Name = "btnJustifyCenter";
            this.btnJustifyCenter.Size = new System.Drawing.Size(29, 25);
            this.btnJustifyCenter.Text = "Justificar al centro";
            this.btnJustifyCenter.ToolTipText = "Centrar";
            // 
            // btnJustifyRight
            // 
            this.btnJustifyRight.CheckOnClick = true;
            this.btnJustifyRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJustifyRight.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.rj;
            this.btnJustifyRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJustifyRight.Name = "btnJustifyRight";
            this.btnJustifyRight.Size = new System.Drawing.Size(29, 25);
            this.btnJustifyRight.Text = "Justificar a la derecha";
            this.btnJustifyRight.ToolTipText = "Alinear a la derecha";
            // 
            // btnJustifyFull
            // 
            this.btnJustifyFull.CheckOnClick = true;
            this.btnJustifyFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJustifyFull.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.fj;
            this.btnJustifyFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJustifyFull.Name = "btnJustifyFull";
            this.btnJustifyFull.Size = new System.Drawing.Size(29, 25);
            this.btnJustifyFull.Text = "Justificado";
            this.btnJustifyFull.ToolTipText = "Justificar";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnOrdererList
            // 
            this.btnOrdererList.CheckOnClick = true;
            this.btnOrdererList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrdererList.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.ol;
            this.btnOrdererList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrdererList.Name = "btnOrdererList";
            this.btnOrdererList.Size = new System.Drawing.Size(29, 25);
            this.btnOrdererList.Text = "Lista ordenada";
            // 
            // btnUnordererList
            // 
            this.btnUnordererList.CheckOnClick = true;
            this.btnUnordererList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnordererList.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.uol;
            this.btnUnordererList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnordererList.Name = "btnUnordererList";
            this.btnUnordererList.Size = new System.Drawing.Size(29, 25);
            this.btnUnordererList.Text = "Lista no ordenada";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // btnOutdent
            // 
            this.btnOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutdent.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.outdent;
            this.btnOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutdent.Name = "btnOutdent";
            this.btnOutdent.Size = new System.Drawing.Size(29, 25);
            this.btnOutdent.Text = "Disminuir sangría";
            // 
            // btnIndent
            // 
            this.btnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIndent.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.indent;
            this.btnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIndent.Name = "btnIndent";
            this.btnIndent.Size = new System.Drawing.Size(29, 25);
            this.btnIndent.Text = "Aumentar sangría";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
            // 
            // cboInsert
            // 
            this.cboInsert.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.copy_content;
            this.cboInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cboInsert.Name = "cboInsert";
            this.cboInsert.Size = new System.Drawing.Size(92, 25);
            this.cboInsert.Text = "Insertar";
            // 
            // btnLink
            // 
            this.btnLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLink.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.link;
            this.btnLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(29, 25);
            this.btnLink.Text = "Enlace";
            // 
            // btnimage
            // 
            this.btnimage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnimage.Image = global::Infoware.Editor.WindowsForms.Properties.Resources.image;
            this.btnimage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnimage.Name = "btnimage";
            this.btnimage.Size = new System.Drawing.Size(29, 25);
            this.btnimage.Text = "Imágen";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 437);
            this.panel1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator7,
            this.btnDelete,
            this.toolStripSeparator8,
            this.btnBackgroundColor});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(198, 136);
            // 
            // btnCut
            // 
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(197, 24);
            this.btnCut.Text = "Cortar";
            // 
            // btnCopy
            // 
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(197, 24);
            this.btnCopy.Text = "Copiar";
            // 
            // btnPaste
            // 
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(197, 24);
            this.btnPaste.Text = "Pegar";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(194, 6);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(197, 24);
            this.btnDelete.Text = "Borrar";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(194, 6);
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(197, 24);
            this.btnBackgroundColor.Text = "Background Color";
            // 
            // HtmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HtmlEditor";
            this.Size = new System.Drawing.Size(1013, 465);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton cboInsert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripComboBox fontComboBox;
        private System.Windows.Forms.ToolStripComboBox fontSizeComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFontColor;
        private System.Windows.Forms.ToolStripButton btnBackColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnJustifyLeft;
        private System.Windows.Forms.ToolStripButton btnJustifyCenter;
        private System.Windows.Forms.ToolStripButton btnJustifyRight;
        private System.Windows.Forms.ToolStripButton btnJustifyFull;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnOrdererList;
        private System.Windows.Forms.ToolStripButton btnUnordererList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnOutdent;
        private System.Windows.Forms.ToolStripButton btnIndent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCut;
        private System.Windows.Forms.ToolStripMenuItem btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem btnBackgroundColor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton btnLink;
        private System.Windows.Forms.ToolStripButton btnimage;
    }
}
