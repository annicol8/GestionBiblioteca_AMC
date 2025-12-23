namespace Presentacion
{
    partial class FBuscarDocumento
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
            this.lbAno = new System.Windows.Forms.Label();
            this.lbEditorial = new System.Windows.Forms.Label();
            this.lbAutor = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbIsbn = new System.Windows.Forms.Label();
            this.gbTipoDocumento = new System.Windows.Forms.GroupBox();
            this.rbAudioLibro = new System.Windows.Forms.RadioButton();
            this.rbLibro = new System.Windows.Forms.RadioButton();
            this.gbAudioLibro = new System.Windows.Forms.GroupBox();
            this.lbFormatoDigital = new System.Windows.Forms.Label();
            this.lbDuracion = new System.Windows.Forms.Label();
            this.btCerrar = new System.Windows.Forms.Button();
            this.gbTipoDocumento.SuspendLayout();
            this.gbAudioLibro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Location = new System.Drawing.Point(97, 259);
            this.lbAno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(167, 25);
            this.lbAno.TabIndex = 20;
            this.lbAno.Text = "Año de edicion: ";
            // 
            // lbEditorial
            // 
            this.lbEditorial.AutoSize = true;
            this.lbEditorial.Location = new System.Drawing.Point(97, 207);
            this.lbEditorial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEditorial.Name = "lbEditorial";
            this.lbEditorial.Size = new System.Drawing.Size(96, 25);
            this.lbEditorial.TabIndex = 19;
            this.lbEditorial.Text = "Editorial:";
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(97, 155);
            this.lbAutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(69, 25);
            this.lbAutor.TabIndex = 18;
            this.lbAutor.Text = "Autor:";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(97, 103);
            this.lbTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(71, 25);
            this.lbTitulo.TabIndex = 17;
            this.lbTitulo.Text = "Título:";
            // 
            // lbIsbn
            // 
            this.lbIsbn.AutoSize = true;
            this.lbIsbn.Location = new System.Drawing.Point(97, 51);
            this.lbIsbn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIsbn.Name = "lbIsbn";
            this.lbIsbn.Size = new System.Drawing.Size(66, 25);
            this.lbIsbn.TabIndex = 16;
            this.lbIsbn.Text = "ISBN:";
            // 
            // gbTipoDocumento
            // 
            this.gbTipoDocumento.Controls.Add(this.rbAudioLibro);
            this.gbTipoDocumento.Controls.Add(this.rbLibro);
            this.gbTipoDocumento.Controls.Add(this.gbAudioLibro);
            this.gbTipoDocumento.Location = new System.Drawing.Point(102, 334);
            this.gbTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.gbTipoDocumento.Name = "gbTipoDocumento";
            this.gbTipoDocumento.Padding = new System.Windows.Forms.Padding(2);
            this.gbTipoDocumento.Size = new System.Drawing.Size(643, 170);
            this.gbTipoDocumento.TabIndex = 21;
            this.gbTipoDocumento.TabStop = false;
            this.gbTipoDocumento.Text = "Tipo de Documento";
            // 
            // rbAudioLibro
            // 
            this.rbAudioLibro.AutoSize = true;
            this.rbAudioLibro.Enabled = false;
            this.rbAudioLibro.Location = new System.Drawing.Point(20, 106);
            this.rbAudioLibro.Margin = new System.Windows.Forms.Padding(2);
            this.rbAudioLibro.Name = "rbAudioLibro";
            this.rbAudioLibro.Size = new System.Drawing.Size(146, 29);
            this.rbAudioLibro.TabIndex = 10;
            this.rbAudioLibro.TabStop = true;
            this.rbAudioLibro.Text = "AudioLibro";
            this.rbAudioLibro.UseVisualStyleBackColor = true;
            // 
            // rbLibro
            // 
            this.rbLibro.AutoSize = true;
            this.rbLibro.Enabled = false;
            this.rbLibro.Location = new System.Drawing.Point(20, 49);
            this.rbLibro.Margin = new System.Windows.Forms.Padding(2);
            this.rbLibro.Name = "rbLibro";
            this.rbLibro.Size = new System.Drawing.Size(91, 29);
            this.rbLibro.TabIndex = 9;
            this.rbLibro.TabStop = true;
            this.rbLibro.Text = "Libro";
            this.rbLibro.UseVisualStyleBackColor = true;
            // 
            // gbAudioLibro
            // 
            this.gbAudioLibro.Controls.Add(this.lbFormatoDigital);
            this.gbAudioLibro.Controls.Add(this.lbDuracion);
            this.gbAudioLibro.Location = new System.Drawing.Point(314, 24);
            this.gbAudioLibro.Margin = new System.Windows.Forms.Padding(2);
            this.gbAudioLibro.Name = "gbAudioLibro";
            this.gbAudioLibro.Padding = new System.Windows.Forms.Padding(2);
            this.gbAudioLibro.Size = new System.Drawing.Size(289, 128);
            this.gbAudioLibro.TabIndex = 15;
            this.gbAudioLibro.TabStop = false;
            // 
            // lbFormatoDigital
            // 
            this.lbFormatoDigital.AutoSize = true;
            this.lbFormatoDigital.Location = new System.Drawing.Point(24, 37);
            this.lbFormatoDigital.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFormatoDigital.Name = "lbFormatoDigital";
            this.lbFormatoDigital.Size = new System.Drawing.Size(166, 25);
            this.lbFormatoDigital.TabIndex = 11;
            this.lbFormatoDigital.Text = "Formato digital: ";
            // 
            // lbDuracion
            // 
            this.lbDuracion.AutoSize = true;
            this.lbDuracion.Location = new System.Drawing.Point(24, 74);
            this.lbDuracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDuracion.Name = "lbDuracion";
            this.lbDuracion.Size = new System.Drawing.Size(110, 25);
            this.lbDuracion.TabIndex = 12;
            this.lbDuracion.Text = "Duración: ";
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(638, 527);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(107, 44);
            this.btCerrar.TabIndex = 22;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // FBuscarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 583);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.gbTipoDocumento);
            this.Controls.Add(this.lbAno);
            this.Controls.Add(this.lbEditorial);
            this.Controls.Add(this.lbAutor);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbIsbn);
            this.Name = "FBuscarDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FBuscarDocumento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBuscarDocumento_FormClosing);
            this.Load += new System.EventHandler(this.FBuscarDocumento_Load);
            this.gbTipoDocumento.ResumeLayout(false);
            this.gbTipoDocumento.PerformLayout();
            this.gbAudioLibro.ResumeLayout(false);
            this.gbAudioLibro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAno;
        private System.Windows.Forms.Label lbEditorial;
        private System.Windows.Forms.Label lbAutor;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbIsbn;
        private System.Windows.Forms.GroupBox gbTipoDocumento;
        private System.Windows.Forms.RadioButton rbAudioLibro;
        private System.Windows.Forms.RadioButton rbLibro;
        private System.Windows.Forms.GroupBox gbAudioLibro;
        private System.Windows.Forms.Label lbFormatoDigital;
        private System.Windows.Forms.Label lbDuracion;
        private System.Windows.Forms.Button btCerrar;
    }
}