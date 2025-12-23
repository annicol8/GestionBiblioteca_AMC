namespace Presentacion
{
    partial class FBuscarEjemplar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Codigo = new System.Windows.Forms.TextBox();
            this.tb_Isbn = new System.Windows.Forms.TextBox();
            this.tb_DniPersonal = new System.Windows.Forms.TextBox();
            this.check_Activo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Activo: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dni Personal: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "ISBN Documento:";
            // 
            // tb_Codigo
            // 
            this.tb_Codigo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_Codigo.Location = new System.Drawing.Point(341, 58);
            this.tb_Codigo.Name = "tb_Codigo";
            this.tb_Codigo.ReadOnly = true;
            this.tb_Codigo.Size = new System.Drawing.Size(261, 26);
            this.tb_Codigo.TabIndex = 4;
            this.tb_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_Isbn
            // 
            this.tb_Isbn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_Isbn.Location = new System.Drawing.Point(341, 228);
            this.tb_Isbn.Name = "tb_Isbn";
            this.tb_Isbn.ReadOnly = true;
            this.tb_Isbn.Size = new System.Drawing.Size(261, 26);
            this.tb_Isbn.TabIndex = 6;
            this.tb_Isbn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_DniPersonal
            // 
            this.tb_DniPersonal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_DniPersonal.Location = new System.Drawing.Point(341, 170);
            this.tb_DniPersonal.Name = "tb_DniPersonal";
            this.tb_DniPersonal.ReadOnly = true;
            this.tb_DniPersonal.Size = new System.Drawing.Size(261, 26);
            this.tb_DniPersonal.TabIndex = 7;
            this.tb_DniPersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // check_Activo
            // 
            this.check_Activo.AutoSize = true;
            this.check_Activo.Enabled = false;
            this.check_Activo.Location = new System.Drawing.Point(580, 116);
            this.check_Activo.Name = "check_Activo";
            this.check_Activo.Size = new System.Drawing.Size(22, 21);
            this.check_Activo.TabIndex = 8;
            this.check_Activo.UseVisualStyleBackColor = true;
            // 
            // FBuscarEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 340);
            this.Controls.Add(this.check_Activo);
            this.Controls.Add(this.tb_DniPersonal);
            this.Controls.Add(this.tb_Isbn);
            this.Controls.Add(this.tb_Codigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FBuscarEjemplar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos ejemplar";
            this.Load += new System.EventHandler(this.FBuscarEjemplar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Codigo;
        private System.Windows.Forms.TextBox tb_Isbn;
        private System.Windows.Forms.TextBox tb_DniPersonal;
        private System.Windows.Forms.CheckBox check_Activo;
    }
}