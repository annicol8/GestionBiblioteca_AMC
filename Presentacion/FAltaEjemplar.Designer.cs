namespace Presentacion
{
    partial class FAltaEjemplar
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
            this.textBoxCodigoEj = new System.Windows.Forms.TextBox();
            this.comboBoxISBN = new System.Windows.Forms.ComboBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelIsbn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxCodigoEj
            // 
            this.textBoxCodigoEj.Location = new System.Drawing.Point(548, 79);
            this.textBoxCodigoEj.Name = "textBoxCodigoEj";
            this.textBoxCodigoEj.Size = new System.Drawing.Size(121, 26);
            this.textBoxCodigoEj.TabIndex = 0;
            // 
            // comboBoxISBN
            // 
            this.comboBoxISBN.FormattingEnabled = true;
            this.comboBoxISBN.Location = new System.Drawing.Point(548, 160);
            this.comboBoxISBN.Name = "comboBoxISBN";
            this.comboBoxISBN.Size = new System.Drawing.Size(121, 28);
            this.comboBoxISBN.TabIndex = 1;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(158, 293);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(129, 35);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(438, 293);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(129, 35);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(158, 85);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(59, 20);
            this.labelCodigo.TabIndex = 4;
            this.labelCodigo.Text = "Código";
            // 
            // labelIsbn
            // 
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Location = new System.Drawing.Point(158, 167);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(144, 20);
            this.labelIsbn.TabIndex = 5;
            this.labelIsbn.Text = "Documento (ISBN)";
            // 
            // FAltaEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelIsbn);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.comboBoxISBN);
            this.Controls.Add(this.textBoxCodigoEj);
            this.Name = "FAltaEjemplar";
            this.Text = "FAltaEjemplar";
            this.Load += new System.EventHandler(this.FAltaEjemplar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCodigoEj;
        private System.Windows.Forms.ComboBox comboBoxISBN;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelIsbn;
    }
}