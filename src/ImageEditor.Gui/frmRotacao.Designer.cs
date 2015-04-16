namespace ImageEditor.Gui
{
    partial class frmRotacao
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rad180 = new System.Windows.Forms.RadioButton();
            this.rad90 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rad270 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(171, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(252, 125);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // rad180
            // 
            this.rad180.AutoSize = true;
            this.rad180.Location = new System.Drawing.Point(15, 74);
            this.rad180.Name = "rad180";
            this.rad180.Size = new System.Drawing.Size(47, 17);
            this.rad180.TabIndex = 1;
            this.rad180.TabStop = true;
            this.rad180.Text = "180°";
            this.rad180.UseVisualStyleBackColor = true;
            // 
            // rad90
            // 
            this.rad90.AutoSize = true;
            this.rad90.Checked = true;
            this.rad90.Location = new System.Drawing.Point(15, 51);
            this.rad90.Name = "rad90";
            this.rad90.Size = new System.Drawing.Size(41, 17);
            this.rad90.TabIndex = 0;
            this.rad90.TabStop = true;
            this.rad90.Text = "90°";
            this.rad90.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Informe em quantos graus a imagem deve ser rotacionada:";
            // 
            // rad270
            // 
            this.rad270.AutoSize = true;
            this.rad270.Location = new System.Drawing.Point(15, 97);
            this.rad270.Name = "rad270";
            this.rad270.Size = new System.Drawing.Size(47, 17);
            this.rad270.TabIndex = 2;
            this.rad270.TabStop = true;
            this.rad270.Text = "270°";
            this.rad270.UseVisualStyleBackColor = true;
            // 
            // frmRotacao
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(339, 160);
            this.Controls.Add(this.rad270);
            this.Controls.Add(this.rad180);
            this.Controls.Add(this.rad90);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRotacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rotação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton rad180;
        private System.Windows.Forms.RadioButton rad90;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rad270;
    }
}