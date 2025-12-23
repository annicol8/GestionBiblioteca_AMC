namespace Presentacion
{
    partial class FBajaDocumento
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
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblFormatoDigital = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.tbAnoEdicion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEditorial = new System.Windows.Forms.TextBox();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.tbIsbn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(651, 548);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(89, 34);
            this.btCancelar.TabIndex = 31;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(480, 549);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(121, 34);
            this.btAceptar.TabIndex = 30;
            this.btAceptar.Text = "Dar de baja";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(202, 482);
            this.lblDuracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(300, 20);
            this.lblDuracion.TabIndex = 29;
            this.lblDuracion.Text = "No se ha detectado el tipo de documento";
            // 
            // lblFormatoDigital
            // 
            this.lblFormatoDigital.AutoSize = true;
            this.lblFormatoDigital.Location = new System.Drawing.Point(202, 440);
            this.lblFormatoDigital.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormatoDigital.Name = "lblFormatoDigital";
            this.lblFormatoDigital.Size = new System.Drawing.Size(300, 20);
            this.lblFormatoDigital.TabIndex = 28;
            this.lblFormatoDigital.Text = "No se ha detectado el tipo de documento";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(134, 402);
            this.lblTipoDocumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(300, 20);
            this.lblTipoDocumento.TabIndex = 27;
            this.lblTipoDocumento.Text = "No se ha detectado el tipo de documento";
            // 
            // tbAnoEdicion
            // 
            this.tbAnoEdicion.Location = new System.Drawing.Point(326, 299);
            this.tbAnoEdicion.Margin = new System.Windows.Forms.Padding(2);
            this.tbAnoEdicion.Name = "tbAnoEdicion";
            this.tbAnoEdicion.Size = new System.Drawing.Size(415, 26);
            this.tbAnoEdicion.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 304);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Año de edicion: ";
            // 
            // tbEditorial
            // 
            this.tbEditorial.Location = new System.Drawing.Point(326, 247);
            this.tbEditorial.Margin = new System.Windows.Forms.Padding(2);
            this.tbEditorial.Name = "tbEditorial";
            this.tbEditorial.Size = new System.Drawing.Size(415, 26);
            this.tbEditorial.TabIndex = 24;
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(326, 195);
            this.tbAutor.Margin = new System.Windows.Forms.Padding(2);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(415, 26);
            this.tbAutor.TabIndex = 23;
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(326, 143);
            this.tbTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(415, 26);
            this.tbTitulo.TabIndex = 22;
            // 
            // tbIsbn
            // 
            this.tbIsbn.Location = new System.Drawing.Point(326, 91);
            this.tbIsbn.Margin = new System.Windows.Forms.Padding(2);
            this.tbIsbn.Name = "tbIsbn";
            this.tbIsbn.Size = new System.Drawing.Size(180, 26);
            this.tbIsbn.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 253);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Editorial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Autor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Título:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "ISBN:";
            // 
            // FBajaDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 635);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblFormatoDigital);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.tbAnoEdicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbEditorial);
            this.Controls.Add(this.tbAutor);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.tbIsbn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FBajaDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Baja de Documento";
            this.Load += new System.EventHandler(this.FBajaDocumento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAnoEdicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEditorial;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.TextBox tbIsbn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblFormatoDigital;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
    }
}