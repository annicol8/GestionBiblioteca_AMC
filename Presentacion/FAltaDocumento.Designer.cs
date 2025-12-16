namespace Presentacion
{
    partial class FAltaDocumento
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
            this.tbIsbn = new System.Windows.Forms.TextBox();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.tbEditorial = new System.Windows.Forms.TextBox();
            this.rbLibro = new System.Windows.Forms.RadioButton();
            this.rbAudioLibro = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbAudioLibro = new System.Windows.Forms.GroupBox();
            this.tbDuracion = new System.Windows.Forms.TextBox();
            this.lbFormatoDigital = new System.Windows.Forms.Label();
            this.tbFormatoDigital = new System.Windows.Forms.TextBox();
            this.lbDuracion = new System.Windows.Forms.Label();
            this.btAñadirEjemplares = new System.Windows.Forms.Button();
            this.btDarAlta = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.tbAnoEdicion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbAudioLibro.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ISBN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Título:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Autor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Editorial:";
            // 
            // tbIsbn
            // 
            this.tbIsbn.Location = new System.Drawing.Point(379, 66);
            this.tbIsbn.Name = "tbIsbn";
            this.tbIsbn.Size = new System.Drawing.Size(239, 31);
            this.tbIsbn.TabIndex = 5;
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(379, 131);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(552, 31);
            this.tbTitulo.TabIndex = 6;
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(379, 196);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(552, 31);
            this.tbAutor.TabIndex = 7;
            // 
            // tbEditorial
            // 
            this.tbEditorial.Location = new System.Drawing.Point(379, 261);
            this.tbEditorial.Name = "tbEditorial";
            this.tbEditorial.Size = new System.Drawing.Size(552, 31);
            this.tbEditorial.TabIndex = 8;
            // 
            // rbLibro
            // 
            this.rbLibro.AutoSize = true;
            this.rbLibro.Location = new System.Drawing.Point(27, 61);
            this.rbLibro.Name = "rbLibro";
            this.rbLibro.Size = new System.Drawing.Size(91, 29);
            this.rbLibro.TabIndex = 9;
            this.rbLibro.TabStop = true;
            this.rbLibro.Text = "Libro";
            this.rbLibro.UseVisualStyleBackColor = true;
            this.rbLibro.CheckedChanged += new System.EventHandler(this.rbLibro_CheckedChanged);
            // 
            // rbAudioLibro
            // 
            this.rbAudioLibro.AutoSize = true;
            this.rbAudioLibro.Location = new System.Drawing.Point(27, 133);
            this.rbAudioLibro.Name = "rbAudioLibro";
            this.rbAudioLibro.Size = new System.Drawing.Size(146, 29);
            this.rbAudioLibro.TabIndex = 10;
            this.rbAudioLibro.TabStop = true;
            this.rbAudioLibro.Text = "AudioLibro";
            this.rbAudioLibro.UseVisualStyleBackColor = true;
            this.rbAudioLibro.CheckedChanged += new System.EventHandler(this.rbAudioLibro_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAudioLibro);
            this.groupBox1.Controls.Add(this.rbLibro);
            this.groupBox1.Controls.Add(this.gbAudioLibro);
            this.groupBox1.Location = new System.Drawing.Point(128, 405);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 213);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Documento";
            // 
            // gbAudioLibro
            // 
            this.gbAudioLibro.Controls.Add(this.tbDuracion);
            this.gbAudioLibro.Controls.Add(this.lbFormatoDigital);
            this.gbAudioLibro.Controls.Add(this.tbFormatoDigital);
            this.gbAudioLibro.Controls.Add(this.lbDuracion);
            this.gbAudioLibro.Location = new System.Drawing.Point(418, 30);
            this.gbAudioLibro.Name = "gbAudioLibro";
            this.gbAudioLibro.Size = new System.Drawing.Size(385, 160);
            this.gbAudioLibro.TabIndex = 15;
            this.gbAudioLibro.TabStop = false;
            // 
            // tbDuracion
            // 
            this.tbDuracion.Location = new System.Drawing.Point(217, 93);
            this.tbDuracion.Name = "tbDuracion";
            this.tbDuracion.Size = new System.Drawing.Size(140, 31);
            this.tbDuracion.TabIndex = 14;
            // 
            // lbFormatoDigital
            // 
            this.lbFormatoDigital.AutoSize = true;
            this.lbFormatoDigital.Location = new System.Drawing.Point(32, 46);
            this.lbFormatoDigital.Name = "lbFormatoDigital";
            this.lbFormatoDigital.Size = new System.Drawing.Size(154, 25);
            this.lbFormatoDigital.TabIndex = 11;
            this.lbFormatoDigital.Text = "Formato digital";
            // 
            // tbFormatoDigital
            // 
            this.tbFormatoDigital.Location = new System.Drawing.Point(217, 40);
            this.tbFormatoDigital.Name = "tbFormatoDigital";
            this.tbFormatoDigital.Size = new System.Drawing.Size(140, 31);
            this.tbFormatoDigital.TabIndex = 13;
            // 
            // lbDuracion
            // 
            this.lbDuracion.AutoSize = true;
            this.lbDuracion.Location = new System.Drawing.Point(32, 93);
            this.lbDuracion.Name = "lbDuracion";
            this.lbDuracion.Size = new System.Drawing.Size(98, 25);
            this.lbDuracion.TabIndex = 12;
            this.lbDuracion.Text = "Duración";
            // 
            // btAñadirEjemplares
            // 
            this.btAñadirEjemplares.Location = new System.Drawing.Point(129, 681);
            this.btAñadirEjemplares.Name = "btAñadirEjemplares";
            this.btAñadirEjemplares.Size = new System.Drawing.Size(320, 45);
            this.btAñadirEjemplares.TabIndex = 12;
            this.btAñadirEjemplares.Text = "Añadir ejemplares";
            this.btAñadirEjemplares.UseVisualStyleBackColor = true;
            this.btAñadirEjemplares.Click += new System.EventHandler(this.btAñadirEjemplares_Click);
            // 
            // btDarAlta
            // 
            this.btDarAlta.Location = new System.Drawing.Point(583, 681);
            this.btDarAlta.Name = "btDarAlta";
            this.btDarAlta.Size = new System.Drawing.Size(189, 45);
            this.btDarAlta.TabIndex = 13;
            this.btDarAlta.Text = "Dar alta";
            this.btDarAlta.UseVisualStyleBackColor = true;
            this.btDarAlta.Click += new System.EventHandler(this.btDarAlta_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(796, 681);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(189, 45);
            this.btCancelar.TabIndex = 14;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // tbAnoEdicion
            // 
            this.tbAnoEdicion.Location = new System.Drawing.Point(379, 326);
            this.tbAnoEdicion.Name = "tbAnoEdicion";
            this.tbAnoEdicion.Size = new System.Drawing.Size(552, 31);
            this.tbAnoEdicion.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Año de edicion: ";
            // 
            // FAltaDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 782);
            this.Controls.Add(this.tbAnoEdicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btDarAlta);
            this.Controls.Add(this.btAñadirEjemplares);
            this.Controls.Add(this.tbEditorial);
            this.Controls.Add(this.tbAutor);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.tbIsbn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FAltaDocumento";
            this.Text = "Alta de Documento";
            this.Load += new System.EventHandler(this.FAltaDocumento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAudioLibro.ResumeLayout(false);
            this.gbAudioLibro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIsbn;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.TextBox tbEditorial;
        private System.Windows.Forms.RadioButton rbLibro;
        private System.Windows.Forms.RadioButton rbAudioLibro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAñadirEjemplares;
        private System.Windows.Forms.Button btDarAlta;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.TextBox tbDuracion;
        private System.Windows.Forms.TextBox tbFormatoDigital;
        private System.Windows.Forms.Label lbDuracion;
        private System.Windows.Forms.Label lbFormatoDigital;
        private System.Windows.Forms.GroupBox gbAudioLibro;
        private System.Windows.Forms.TextBox tbAnoEdicion;
        private System.Windows.Forms.Label label5;
    }
}