namespace ImageEditor.Gui
{
    partial class frmImageEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrirEscalaCinza = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold5 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstatisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistograma = new System.Windows.Forms.ToolStripMenuItem();
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.mnuAbrirColorida = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.visualizarToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(845, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbrirColorida,
            this.mnuAbrirEscalaCinza});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // mnuAbrirEscalaCinza
            // 
            this.mnuAbrirEscalaCinza.Name = "mnuAbrirEscalaCinza";
            this.mnuAbrirEscalaCinza.Size = new System.Drawing.Size(181, 22);
            this.mnuAbrirEscalaCinza.Text = "Abrir escala de cinza";
            this.mnuAbrirEscalaCinza.Click += new System.EventHandler(this.mnuAbrirEscalaCinza_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThreshold1,
            this.mnuThreshold2,
            this.mnuThreshold3,
            this.mnuThreshold4,
            this.mnuThreshold5});
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.thresholdToolStripMenuItem.Text = "Threshold";
            // 
            // mnuThreshold1
            // 
            this.mnuThreshold1.Name = "mnuThreshold1";
            this.mnuThreshold1.Size = new System.Drawing.Size(492, 22);
            this.mnuThreshold1.Text = "Valores maiores ou iguais a média recebem preto";
            this.mnuThreshold1.Click += new System.EventHandler(this.mnuThreshold1_Click);
            // 
            // mnuThreshold2
            // 
            this.mnuThreshold2.Name = "mnuThreshold2";
            this.mnuThreshold2.Size = new System.Drawing.Size(492, 22);
            this.mnuThreshold2.Text = "Valores maiores ou iguais a moda recebem 100";
            this.mnuThreshold2.Click += new System.EventHandler(this.mnuThreshold2_Click);
            // 
            // mnuThreshold3
            // 
            this.mnuThreshold3.Name = "mnuThreshold3";
            this.mnuThreshold3.Size = new System.Drawing.Size(492, 22);
            this.mnuThreshold3.Text = "Valores maiores ou iguais a mediana recebem branco";
            this.mnuThreshold3.Click += new System.EventHandler(this.mnuThreshold3_Click);
            // 
            // mnuThreshold4
            // 
            this.mnuThreshold4.Name = "mnuThreshold4";
            this.mnuThreshold4.Size = new System.Drawing.Size(492, 22);
            this.mnuThreshold4.Text = "Valores menores que a média recebem 50";
            this.mnuThreshold4.Click += new System.EventHandler(this.mnuThreshold4_Click);
            // 
            // mnuThreshold5
            // 
            this.mnuThreshold5.Name = "mnuThreshold5";
            this.mnuThreshold5.Size = new System.Drawing.Size(492, 22);
            this.mnuThreshold5.Text = "Valores maiores que a mediana recebem 255 e menores que a média recebem 0";
            this.mnuThreshold5.Click += new System.EventHandler(this.mnuThreshold5_Click);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEstatisticas,
            this.mnuHistograma});
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // mnuEstatisticas
            // 
            this.mnuEstatisticas.Name = "mnuEstatisticas";
            this.mnuEstatisticas.Size = new System.Drawing.Size(136, 22);
            this.mnuEstatisticas.Text = "Estatísticas";
            this.mnuEstatisticas.Click += new System.EventHandler(this.mnuEstatisticas_Click);
            // 
            // mnuHistograma
            // 
            this.mnuHistograma.Name = "mnuHistograma";
            this.mnuHistograma.Size = new System.Drawing.Size(136, 22);
            this.mnuHistograma.Text = "Histograma";
            this.mnuHistograma.Click += new System.EventHandler(this.mnuHistograma_Click);
            // 
            // picImagem
            // 
            this.picImagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImagem.Location = new System.Drawing.Point(12, 37);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(821, 358);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picImagem.TabIndex = 1;
            this.picImagem.TabStop = false;
            // 
            // mnuAbrirColorida
            // 
            this.mnuAbrirColorida.Name = "mnuAbrirColorida";
            this.mnuAbrirColorida.Size = new System.Drawing.Size(181, 22);
            this.mnuAbrirColorida.Text = "Abrir colorida";
            this.mnuAbrirColorida.Click += new System.EventHandler(this.mnuAbrirColorida_Click);
            // 
            // frmImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 407);
            this.Controls.Add(this.picImagem);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "frmImageEditor";
            this.Text = "ImageEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrirEscalaCinza;
        private System.Windows.Forms.PictureBox picImagem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHistograma;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuThreshold1;
        private System.Windows.Forms.ToolStripMenuItem mnuThreshold2;
        private System.Windows.Forms.ToolStripMenuItem mnuThreshold3;
        private System.Windows.Forms.ToolStripMenuItem mnuThreshold4;
        private System.Windows.Forms.ToolStripMenuItem mnuThreshold5;
        private System.Windows.Forms.ToolStripMenuItem mnuEstatisticas;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrirColorida;

    }
}

