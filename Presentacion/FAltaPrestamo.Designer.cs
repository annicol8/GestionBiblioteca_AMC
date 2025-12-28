namespace Presentacion
{
    partial class FAltaPrestamo
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.btAñadirEjemplar = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.gbEjemplares = new System.Windows.Forms.GroupBox();
            this.panelEjemplares = new System.Windows.Forms.Panel();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.gbEjemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(176, 103);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(189, 26);
            this.dtpFecha.TabIndex = 3;
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarios.FormattingEnabled = true;
            this.cbUsuarios.Location = new System.Drawing.Point(176, 158);
            this.cbUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(189, 28);
            this.cbUsuarios.TabIndex = 4;
            // 
            // btAñadirEjemplar
            // 
            this.btAñadirEjemplar.Location = new System.Drawing.Point(79, 223);
            this.btAñadirEjemplar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAñadirEjemplar.Name = "btAñadirEjemplar";
            this.btAñadirEjemplar.Size = new System.Drawing.Size(286, 38);
            this.btAñadirEjemplar.TabIndex = 5;
            this.btAñadirEjemplar.Text = "Añadir ejemplar";
            this.btAñadirEjemplar.UseVisualStyleBackColor = true;
            this.btAñadirEjemplar.Click += new System.EventHandler(this.btAñadirEjemplar_Click);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(176, 47);
            this.tbId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(189, 26);
            this.tbId.TabIndex = 6;
            // 
            // gbEjemplares
            // 
            this.gbEjemplares.Controls.Add(this.panelEjemplares);
            this.gbEjemplares.Location = new System.Drawing.Point(446, 50);
            this.gbEjemplares.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbEjemplares.Name = "gbEjemplares";
            this.gbEjemplares.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbEjemplares.Size = new System.Drawing.Size(526, 410);
            this.gbEjemplares.TabIndex = 7;
            this.gbEjemplares.TabStop = false;
            this.gbEjemplares.Text = "Ejemplares añadidos";
            // 
            // panelEjemplares
            // 
            this.panelEjemplares.AutoScroll = true;
            this.panelEjemplares.Location = new System.Drawing.Point(38, 42);
            this.panelEjemplares.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelEjemplares.Name = "panelEjemplares";
            this.panelEjemplares.Size = new System.Drawing.Size(455, 337);
            this.panelEjemplares.TabIndex = 0;
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(446, 501);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(105, 37);
            this.btAceptar.TabIndex = 8;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(574, 501);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(105, 37);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click_1);
            // 
            // FAltaPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 581);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.gbEjemplares);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.btAñadirEjemplar);
            this.Controls.Add(this.cbUsuarios);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FAltaPrestamo";
            this.Text = "Alta de un prestamo";
            this.Load += new System.EventHandler(this.FAltaPrestamo_Load);
            this.gbEjemplares.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.Button btAñadirEjemplar;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.GroupBox gbEjemplares;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Panel panelEjemplares;
    }
}