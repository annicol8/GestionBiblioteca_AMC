using ModeloDominio;

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
            this.components = new System.ComponentModel.Container();
            this.tbAnoEdicion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btDarAlta = new System.Windows.Forms.Button();
            this.tbEditorial = new System.Windows.Forms.TextBox();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.tbIsbn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTipoDocumento = new System.Windows.Forms.GroupBox();
            this.rbAudioLibro = new System.Windows.Forms.RadioButton();
            this.rbLibro = new System.Windows.Forms.RadioButton();
            this.gbAudioLibro = new System.Windows.Forms.GroupBox();
            this.tbDuracion = new System.Windows.Forms.TextBox();
            this.lbFormatoDigital = new System.Windows.Forms.Label();
            this.tbFormatoDigital = new System.Windows.Forms.TextBox();
            this.lbDuracion = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbTipoDocumento.SuspendLayout();
            this.gbAudioLibro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAnoEdicion
            // 
            this.tbAnoEdicion.Location = new System.Drawing.Point(284, 261);
            this.tbAnoEdicion.Margin = new System.Windows.Forms.Padding(2);
            this.tbAnoEdicion.Name = "tbAnoEdicion";
            this.tbAnoEdicion.Size = new System.Drawing.Size(415, 31);
            this.tbAnoEdicion.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbAnoEdicion, "Año de edición (formato: YYYY)");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 266);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Año de edicion: ";
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(597, 523);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(142, 49);
            this.btCancelar.TabIndex = 10;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btDarAlta
            // 
            this.btDarAlta.Location = new System.Drawing.Point(437, 523);
            this.btDarAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btDarAlta.Name = "btDarAlta";
            this.btDarAlta.Size = new System.Drawing.Size(142, 49);
            this.btDarAlta.TabIndex = 9;
            this.btDarAlta.Text = "Dar alta";
            this.btDarAlta.UseVisualStyleBackColor = true;
            this.btDarAlta.Click += new System.EventHandler(this.btDarAlta_Click);
            // 
            // tbEditorial
            // 
            this.tbEditorial.Location = new System.Drawing.Point(284, 209);
            this.tbEditorial.Margin = new System.Windows.Forms.Padding(2);
            this.tbEditorial.Name = "tbEditorial";
            this.tbEditorial.Size = new System.Drawing.Size(415, 31);
            this.tbEditorial.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbEditorial, "Editorial del documento");
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(284, 157);
            this.tbAutor.Margin = new System.Windows.Forms.Padding(2);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(415, 31);
            this.tbAutor.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbAutor, "Autor del documento");
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(284, 105);
            this.tbTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(415, 31);
            this.tbTitulo.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbTitulo, "Título del documento");
            // 
            // tbIsbn
            // 
            this.tbIsbn.Location = new System.Drawing.Point(284, 53);
            this.tbIsbn.Margin = new System.Windows.Forms.Padding(2);
            this.tbIsbn.Name = "tbIsbn";
            this.tbIsbn.Size = new System.Drawing.Size(231, 31);
            this.tbIsbn.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tbIsbn, "ISBN del documento (solo lectura)");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 214);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Editorial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Autor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Título:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ISBN:";
            // 
            // gbTipoDocumento
            // 
            this.gbTipoDocumento.Controls.Add(this.rbAudioLibro);
            this.gbTipoDocumento.Controls.Add(this.rbLibro);
            this.gbTipoDocumento.Controls.Add(this.gbAudioLibro);
            this.gbTipoDocumento.Location = new System.Drawing.Point(96, 324);
            this.gbTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.gbTipoDocumento.Name = "gbTipoDocumento";
            this.gbTipoDocumento.Padding = new System.Windows.Forms.Padding(2);
            this.gbTipoDocumento.Size = new System.Drawing.Size(643, 170);
            this.gbTipoDocumento.TabIndex = 11;
            this.gbTipoDocumento.TabStop = false;
            this.gbTipoDocumento.Text = "Tipo de Documento";
            // 
            // rbAudioLibro
            // 
            this.rbAudioLibro.AutoSize = true;
            this.rbAudioLibro.Location = new System.Drawing.Point(20, 106);
            this.rbAudioLibro.Margin = new System.Windows.Forms.Padding(2);
            this.rbAudioLibro.Name = "rbAudioLibro";
            this.rbAudioLibro.Size = new System.Drawing.Size(146, 29);
            this.rbAudioLibro.TabIndex = 6;
            this.rbAudioLibro.TabStop = true;
            this.rbAudioLibro.Text = "AudioLibro";
            this.rbAudioLibro.UseVisualStyleBackColor = true;
            this.rbAudioLibro.CheckedChanged += new System.EventHandler(this.rbAudioLibro_CheckedChanged);
            // 
            // rbLibro
            // 
            this.rbLibro.AutoSize = true;
            this.rbLibro.Location = new System.Drawing.Point(20, 49);
            this.rbLibro.Margin = new System.Windows.Forms.Padding(2);
            this.rbLibro.Name = "rbLibro";
            this.rbLibro.Size = new System.Drawing.Size(91, 29);
            this.rbLibro.TabIndex = 5;
            this.rbLibro.TabStop = true;
            this.rbLibro.Text = "Libro";
            this.rbLibro.UseVisualStyleBackColor = true;
            this.rbLibro.CheckedChanged += new System.EventHandler(this.rbLibro_CheckedChanged);
            // 
            // gbAudioLibro
            // 
            this.gbAudioLibro.Controls.Add(this.tbDuracion);
            this.gbAudioLibro.Controls.Add(this.lbFormatoDigital);
            this.gbAudioLibro.Controls.Add(this.tbFormatoDigital);
            this.gbAudioLibro.Controls.Add(this.lbDuracion);
            this.gbAudioLibro.Location = new System.Drawing.Point(314, 24);
            this.gbAudioLibro.Margin = new System.Windows.Forms.Padding(2);
            this.gbAudioLibro.Name = "gbAudioLibro";
            this.gbAudioLibro.Padding = new System.Windows.Forms.Padding(2);
            this.gbAudioLibro.Size = new System.Drawing.Size(310, 128);
            this.gbAudioLibro.TabIndex = 15;
            this.gbAudioLibro.TabStop = false;
            // 
            // tbDuracion
            // 
            this.tbDuracion.Location = new System.Drawing.Point(190, 74);
            this.tbDuracion.Margin = new System.Windows.Forms.Padding(2);
            this.tbDuracion.Name = "tbDuracion";
            this.tbDuracion.Size = new System.Drawing.Size(106, 31);
            this.tbDuracion.TabIndex = 8;
            this.toolTip1.SetToolTip(this.tbDuracion, "Duración en segundos");
            // 
            // lbFormatoDigital
            // 
            this.lbFormatoDigital.AutoSize = true;
            this.lbFormatoDigital.Location = new System.Drawing.Point(24, 37);
            this.lbFormatoDigital.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFormatoDigital.Name = "lbFormatoDigital";
            this.lbFormatoDigital.Size = new System.Drawing.Size(154, 25);
            this.lbFormatoDigital.TabIndex = 11;
            this.lbFormatoDigital.Text = "Formato digital";
            // 
            // tbFormatoDigital
            // 
            this.tbFormatoDigital.Location = new System.Drawing.Point(190, 32);
            this.tbFormatoDigital.Margin = new System.Windows.Forms.Padding(2);
            this.tbFormatoDigital.Name = "tbFormatoDigital";
            this.tbFormatoDigital.Size = new System.Drawing.Size(106, 31);
            this.tbFormatoDigital.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbFormatoDigital, "Formato digital del audiolibro (mp3, aac, wav, etc.)");
            // 
            // lbDuracion
            // 
            this.lbDuracion.AutoSize = true;
            this.lbDuracion.Location = new System.Drawing.Point(24, 74);
            this.lbDuracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDuracion.Name = "lbDuracion";
            this.lbDuracion.Size = new System.Drawing.Size(98, 25);
            this.lbDuracion.TabIndex = 12;
            this.lbDuracion.Text = "Duración";
            // 
            // FAltaDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 583);
            this.Controls.Add(this.tbAnoEdicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btDarAlta);
            this.Controls.Add(this.tbEditorial);
            this.Controls.Add(this.tbAutor);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.tbIsbn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbTipoDocumento);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FAltaDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de Documento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FAltaDocumento_FormClosing);
            this.Load += new System.EventHandler(this.FAltaDocumento_Load);
            this.gbTipoDocumento.ResumeLayout(false);
            this.gbTipoDocumento.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbTipoDocumento;
        private System.Windows.Forms.Button btDarAlta;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.TextBox tbDuracion;
        private System.Windows.Forms.TextBox tbFormatoDigital;
        private System.Windows.Forms.Label lbDuracion;
        private System.Windows.Forms.Label lbFormatoDigital;
        private System.Windows.Forms.GroupBox gbAudioLibro;
        private System.Windows.Forms.TextBox tbAnoEdicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}