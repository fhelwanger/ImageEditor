namespace ImageEditor.Gui
{
    partial class frmHistograma
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.crtHistograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtHistograma)).BeginInit();
            this.SuspendLayout();
            // 
            // crtHistograma
            // 
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.crtHistograma.ChartAreas.Add(chartArea3);
            this.crtHistograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtHistograma.Location = new System.Drawing.Point(0, 0);
            this.crtHistograma.Name = "crtHistograma";
            this.crtHistograma.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.crtHistograma.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black};
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.crtHistograma.Series.Add(series3);
            this.crtHistograma.Size = new System.Drawing.Size(757, 394);
            this.crtHistograma.TabIndex = 0;
            this.crtHistograma.Text = "crtHistograma";
            // 
            // frmHistograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 394);
            this.Controls.Add(this.crtHistograma);
            this.MinimizeBox = false;
            this.Name = "frmHistograma";
            this.Text = "Histograma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistograma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtHistograma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtHistograma;
    }
}