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
            this.mnuAbrirColorida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrirEscalaCinza = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFechar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThreshold5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTranslacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedimensionar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRotacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspelhamento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.filtrosPassaBaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFiltroMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFiltroGauss = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrosPassaAltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFiltroSobel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAplicarOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstatisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistograma = new System.Windows.Forms.ToolStripMenuItem();
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.mnuFiltroRoberts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFiltroMarrHildreth = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuAbrirEscalaCinza,
            this.mnuFechar,
            this.toolStripSeparator2,
            this.mnuSair});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // mnuAbrirColorida
            // 
            this.mnuAbrirColorida.Name = "mnuAbrirColorida";
            this.mnuAbrirColorida.Size = new System.Drawing.Size(181, 22);
            this.mnuAbrirColorida.Text = "Abrir colorida";
            this.mnuAbrirColorida.Click += new System.EventHandler(this.mnuAbrirColorida_Click);
            // 
            // mnuAbrirEscalaCinza
            // 
            this.mnuAbrirEscalaCinza.Name = "mnuAbrirEscalaCinza";
            this.mnuAbrirEscalaCinza.Size = new System.Drawing.Size(181, 22);
            this.mnuAbrirEscalaCinza.Text = "Abrir escala de cinza";
            this.mnuAbrirEscalaCinza.Click += new System.EventHandler(this.mnuAbrirEscalaCinza_Click);
            // 
            // mnuFechar
            // 
            this.mnuFechar.Name = "mnuFechar";
            this.mnuFechar.Size = new System.Drawing.Size(181, 22);
            this.mnuFechar.Text = "Fechar";
            this.mnuFechar.Click += new System.EventHandler(this.mnuFechar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuSair
            // 
            this.mnuSair.Name = "mnuSair";
            this.mnuSair.Size = new System.Drawing.Size(181, 22);
            this.mnuSair.Text = "Sair";
            this.mnuSair.Click += new System.EventHandler(this.mnuSair_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem,
            this.toolStripSeparator1,
            this.mnuTranslacao,
            this.mnuRedimensionar,
            this.mnuRotacao,
            this.mnuEspelhamento,
            this.toolStripSeparator4,
            this.filtrosPassaBaixaToolStripMenuItem,
            this.filtrosPassaAltaToolStripMenuItem,
            this.toolStripSeparator3,
            this.mnuAplicarOriginal});
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
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(270, 6);
            // 
            // mnuTranslacao
            // 
            this.mnuTranslacao.Name = "mnuTranslacao";
            this.mnuTranslacao.Size = new System.Drawing.Size(273, 22);
            this.mnuTranslacao.Text = "Translação";
            this.mnuTranslacao.Click += new System.EventHandler(this.mnuTranslacao_Click);
            // 
            // mnuRedimensionar
            // 
            this.mnuRedimensionar.Name = "mnuRedimensionar";
            this.mnuRedimensionar.Size = new System.Drawing.Size(273, 22);
            this.mnuRedimensionar.Text = "Redimensionar";
            this.mnuRedimensionar.Click += new System.EventHandler(this.mnuRedimensionar_Click);
            // 
            // mnuRotacao
            // 
            this.mnuRotacao.Name = "mnuRotacao";
            this.mnuRotacao.Size = new System.Drawing.Size(273, 22);
            this.mnuRotacao.Text = "Rotação";
            this.mnuRotacao.Click += new System.EventHandler(this.mnuRotacao_Click);
            // 
            // mnuEspelhamento
            // 
            this.mnuEspelhamento.Name = "mnuEspelhamento";
            this.mnuEspelhamento.Size = new System.Drawing.Size(273, 22);
            this.mnuEspelhamento.Text = "Espelhamento";
            this.mnuEspelhamento.Click += new System.EventHandler(this.mnuEspelhamento_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(270, 6);
            // 
            // filtrosPassaBaixaToolStripMenuItem
            // 
            this.filtrosPassaBaixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFiltroMedia,
            this.mnuFiltroGauss});
            this.filtrosPassaBaixaToolStripMenuItem.Name = "filtrosPassaBaixaToolStripMenuItem";
            this.filtrosPassaBaixaToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.filtrosPassaBaixaToolStripMenuItem.Text = "Filtros Passa Baixa";
            // 
            // mnuFiltroMedia
            // 
            this.mnuFiltroMedia.Name = "mnuFiltroMedia";
            this.mnuFiltroMedia.Size = new System.Drawing.Size(107, 22);
            this.mnuFiltroMedia.Text = "Média";
            this.mnuFiltroMedia.Click += new System.EventHandler(this.mnuFiltroMedia_Click);
            // 
            // mnuFiltroGauss
            // 
            this.mnuFiltroGauss.Name = "mnuFiltroGauss";
            this.mnuFiltroGauss.Size = new System.Drawing.Size(107, 22);
            this.mnuFiltroGauss.Text = "Gauss";
            this.mnuFiltroGauss.Click += new System.EventHandler(this.mnuFiltroGauss_Click);
            // 
            // filtrosPassaAltaToolStripMenuItem
            // 
            this.filtrosPassaAltaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFiltroRoberts,
            this.mnuFiltroSobel,
            this.mnuFiltroMarrHildreth});
            this.filtrosPassaAltaToolStripMenuItem.Name = "filtrosPassaAltaToolStripMenuItem";
            this.filtrosPassaAltaToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.filtrosPassaAltaToolStripMenuItem.Text = "Filtros Passa Alta";
            // 
            // mnuFiltroSobel
            // 
            this.mnuFiltroSobel.Name = "mnuFiltroSobel";
            this.mnuFiltroSobel.Size = new System.Drawing.Size(152, 22);
            this.mnuFiltroSobel.Text = "Sobel";
            this.mnuFiltroSobel.Click += new System.EventHandler(this.mnuFiltroSobel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(270, 6);
            // 
            // mnuAplicarOriginal
            // 
            this.mnuAplicarOriginal.CheckOnClick = true;
            this.mnuAplicarOriginal.Name = "mnuAplicarOriginal";
            this.mnuAplicarOriginal.Size = new System.Drawing.Size(273, 22);
            this.mnuAplicarOriginal.Text = "Aplicar alterações na imagem original";
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
            this.mnuEstatisticas.Size = new System.Drawing.Size(152, 22);
            this.mnuEstatisticas.Text = "Estatísticas";
            this.mnuEstatisticas.Click += new System.EventHandler(this.mnuEstatisticas_Click);
            // 
            // mnuHistograma
            // 
            this.mnuHistograma.Name = "mnuHistograma";
            this.mnuHistograma.Size = new System.Drawing.Size(152, 22);
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
            // mnuFiltroRoberts
            // 
            this.mnuFiltroRoberts.Name = "mnuFiltroRoberts";
            this.mnuFiltroRoberts.Size = new System.Drawing.Size(152, 22);
            this.mnuFiltroRoberts.Text = "Roberts";
            this.mnuFiltroRoberts.Click += new System.EventHandler(this.mnuFiltroRoberts_Click);
            // 
            // mnuFiltroMarrHildreth
            // 
            this.mnuFiltroMarrHildreth.Name = "mnuFiltroMarrHildreth";
            this.mnuFiltroMarrHildreth.Size = new System.Drawing.Size(152, 22);
            this.mnuFiltroMarrHildreth.Text = "Marr-Hildreth";
            this.mnuFiltroMarrHildreth.Click += new System.EventHandler(this.mnuFiltroMarrHildreth_Click);
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
        private System.Windows.Forms.ToolStripMenuItem mnuTranslacao;
        private System.Windows.Forms.ToolStripMenuItem mnuEspelhamento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRotacao;
        private System.Windows.Forms.ToolStripMenuItem mnuFechar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuSair;
        private System.Windows.Forms.ToolStripMenuItem mnuRedimensionar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuAplicarOriginal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem filtrosPassaBaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFiltroMedia;
        private System.Windows.Forms.ToolStripMenuItem mnuFiltroGauss;
        private System.Windows.Forms.ToolStripMenuItem filtrosPassaAltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFiltroSobel;
        private System.Windows.Forms.ToolStripMenuItem mnuFiltroRoberts;
        private System.Windows.Forms.ToolStripMenuItem mnuFiltroMarrHildreth;

    }
}

