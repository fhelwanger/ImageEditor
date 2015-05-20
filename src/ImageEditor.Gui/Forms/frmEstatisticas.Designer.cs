namespace ImageEditor.Gui
{
    partial class frmEstatisticas
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
            this.dgvEstatisticas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstatisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstatisticas
            // 
            this.dgvEstatisticas.AllowUserToAddRows = false;
            this.dgvEstatisticas.AllowUserToDeleteRows = false;
            this.dgvEstatisticas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvEstatisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstatisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstatisticas.Location = new System.Drawing.Point(0, 0);
            this.dgvEstatisticas.Name = "dgvEstatisticas";
            this.dgvEstatisticas.ReadOnly = true;
            this.dgvEstatisticas.RowHeadersVisible = false;
            this.dgvEstatisticas.Size = new System.Drawing.Size(239, 373);
            this.dgvEstatisticas.TabIndex = 3;
            // 
            // frmEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 373);
            this.Controls.Add(this.dgvEstatisticas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmEstatisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estatísticas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmEstatisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstatisticas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstatisticas;
    }
}