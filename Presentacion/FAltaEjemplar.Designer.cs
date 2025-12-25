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
            this.labelIsbn = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.comboBoxISBN = new System.Windows.Forms.ComboBox();
            this.textBoxCodigoEj = new System.Windows.Forms.TextBox();
            this.lb_Personal = new System.Windows.Forms.Label();
            this.rb_Prestado = new System.Windows.Forms.RadioButton();
            this.textBox_Personal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelIsbn
            // 
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Location = new System.Drawing.Point(98, 160);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(148, 20);
            this.labelIsbn.TabIndex = 5;
            this.labelIsbn.Text = "Documento (ISBN):";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(98, 85);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(63, 20);
            this.labelCodigo.TabIndex = 4;
            this.labelCodigo.Text = "Código:";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(347, 389);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(129, 35);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(136, 389);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(129, 35);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // comboBoxISBN
            // 
            this.comboBoxISBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxISBN.FormattingEnabled = true;
            this.comboBoxISBN.Location = new System.Drawing.Point(347, 152);
            this.comboBoxISBN.Name = "comboBoxISBN";
            this.comboBoxISBN.Size = new System.Drawing.Size(240, 28);
            this.comboBoxISBN.TabIndex = 1;
            // 
            // textBoxCodigoEj
            // 
            this.textBoxCodigoEj.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxCodigoEj.Location = new System.Drawing.Point(347, 79);
            this.textBoxCodigoEj.Name = "textBoxCodigoEj";
            this.textBoxCodigoEj.ReadOnly = true;
            this.textBoxCodigoEj.Size = new System.Drawing.Size(240, 26);
            this.textBoxCodigoEj.TabIndex = 0;
            this.textBoxCodigoEj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Personal
            // 
            this.lb_Personal.AutoSize = true;
            this.lb_Personal.Location = new System.Drawing.Point(98, 228);
            this.lb_Personal.Name = "lb_Personal";
            this.lb_Personal.Size = new System.Drawing.Size(79, 20);
            this.lb_Personal.TabIndex = 6;
            this.lb_Personal.Text = "Personal: ";
            // 
            // rb_Prestado
            // 
            this.rb_Prestado.AutoSize = true;
            this.rb_Prestado.Enabled = false;
            this.rb_Prestado.Location = new System.Drawing.Point(102, 302);
            this.rb_Prestado.Name = "rb_Prestado";
            this.rb_Prestado.Size = new System.Drawing.Size(98, 24);
            this.rb_Prestado.TabIndex = 8;
            this.rb_Prestado.TabStop = true;
            this.rb_Prestado.Text = "Prestado";
            this.rb_Prestado.UseVisualStyleBackColor = true;
            // 
            // textBox_Personal
            // 
            this.textBox_Personal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_Personal.Location = new System.Drawing.Point(347, 222);
            this.textBox_Personal.Name = "textBox_Personal";
            this.textBox_Personal.ReadOnly = true;
            this.textBox_Personal.Size = new System.Drawing.Size(240, 26);
            this.textBox_Personal.TabIndex = 2;
            this.textBox_Personal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FAltaEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 498);
            this.Controls.Add(this.textBox_Personal);
            this.Controls.Add(this.rb_Prestado);
            this.Controls.Add(this.lb_Personal);
            this.Controls.Add(this.labelIsbn);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.comboBoxISBN);
            this.Controls.Add(this.textBoxCodigoEj);
            this.Name = "FAltaEjemplar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de Ejemplar";
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
        private System.Windows.Forms.Label lb_Personal;
        private System.Windows.Forms.RadioButton rb_Prestado;
        private System.Windows.Forms.TextBox textBox_Personal;
    }
}