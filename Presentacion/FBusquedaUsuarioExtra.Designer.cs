namespace Presentacion
{
    partial class FBusquedaUsuarioExtra
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
            this.lb_Dni = new System.Windows.Forms.Label();
            this.comboBox_Dnis = new System.Windows.Forms.ComboBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.lb_PrestamosActivos = new System.Windows.Forms.Label();
            this.lb_EjemplaresUltMes = new System.Windows.Forms.Label();
            this.lb_PrestVencidos = new System.Windows.Forms.Label();
            this.textBox_PrestamosActivos = new System.Windows.Forms.TextBox();
            this.textBox_EjemUltMes = new System.Windows.Forms.TextBox();
            this.textBox_PrestVencidos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre: ";
            // 
            // lb_Dni
            // 
            this.lb_Dni.AutoSize = true;
            this.lb_Dni.Location = new System.Drawing.Point(176, 43);
            this.lb_Dni.Name = "lb_Dni";
            this.lb_Dni.Size = new System.Drawing.Size(41, 20);
            this.lb_Dni.TabIndex = 1;
            this.lb_Dni.Text = "DNI:";
            // 
            // comboBox_Dnis
            // 
            this.comboBox_Dnis.FormattingEnabled = true;
            this.comboBox_Dnis.Location = new System.Drawing.Point(262, 40);
            this.comboBox_Dnis.Name = "comboBox_Dnis";
            this.comboBox_Dnis.Size = new System.Drawing.Size(230, 28);
            this.comboBox_Dnis.TabIndex = 2;
            this.comboBox_Dnis.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Dnis_SelectedIndexChanged);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_Nombre.Location = new System.Drawing.Point(277, 33);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.ReadOnly = true;
            this.textBox_Nombre.Size = new System.Drawing.Size(230, 26);
            this.textBox_Nombre.TabIndex = 3;
            this.textBox_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_PrestamosActivos
            // 
            this.lb_PrestamosActivos.AutoSize = true;
            this.lb_PrestamosActivos.Location = new System.Drawing.Point(24, 41);
            this.lb_PrestamosActivos.Name = "lb_PrestamosActivos";
            this.lb_PrestamosActivos.Size = new System.Drawing.Size(182, 20);
            this.lb_PrestamosActivos.TabIndex = 4;
            this.lb_PrestamosActivos.Text = "Num. prestamos activos:";
            // 
            // lb_EjemplaresUltMes
            // 
            this.lb_EjemplaresUltMes.AutoSize = true;
            this.lb_EjemplaresUltMes.Location = new System.Drawing.Point(86, 299);
            this.lb_EjemplaresUltMes.Name = "lb_EjemplaresUltMes";
            this.lb_EjemplaresUltMes.Size = new System.Drawing.Size(324, 20);
            this.lb_EjemplaresUltMes.TabIndex = 5;
            this.lb_EjemplaresUltMes.Text = "Num. ejemplares prestados en el último mes:";
            // 
            // lb_PrestVencidos
            // 
            this.lb_PrestVencidos.AutoSize = true;
            this.lb_PrestVencidos.Location = new System.Drawing.Point(86, 354);
            this.lb_PrestVencidos.Name = "lb_PrestVencidos";
            this.lb_PrestVencidos.Size = new System.Drawing.Size(195, 20);
            this.lb_PrestVencidos.TabIndex = 6;
            this.lb_PrestVencidos.Text = "Num. préstamos vencidos:";
            // 
            // textBox_PrestamosActivos
            // 
            this.textBox_PrestamosActivos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_PrestamosActivos.Location = new System.Drawing.Point(407, 35);
            this.textBox_PrestamosActivos.Name = "textBox_PrestamosActivos";
            this.textBox_PrestamosActivos.ReadOnly = true;
            this.textBox_PrestamosActivos.Size = new System.Drawing.Size(100, 26);
            this.textBox_PrestamosActivos.TabIndex = 7;
            this.textBox_PrestamosActivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_EjemUltMes
            // 
            this.textBox_EjemUltMes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_EjemUltMes.Location = new System.Drawing.Point(407, 90);
            this.textBox_EjemUltMes.Name = "textBox_EjemUltMes";
            this.textBox_EjemUltMes.ReadOnly = true;
            this.textBox_EjemUltMes.Size = new System.Drawing.Size(100, 26);
            this.textBox_EjemUltMes.TabIndex = 8;
            this.textBox_EjemUltMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_PrestVencidos
            // 
            this.textBox_PrestVencidos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_PrestVencidos.Location = new System.Drawing.Point(407, 145);
            this.textBox_PrestVencidos.Name = "textBox_PrestVencidos";
            this.textBox_PrestVencidos.ReadOnly = true;
            this.textBox_PrestVencidos.Size = new System.Drawing.Size(100, 26);
            this.textBox_PrestVencidos.TabIndex = 9;
            this.textBox_PrestVencidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Nombre);
            this.groupBox1.Location = new System.Drawing.Point(62, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 83);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_PrestVencidos);
            this.groupBox2.Controls.Add(this.lb_PrestamosActivos);
            this.groupBox2.Controls.Add(this.textBox_EjemUltMes);
            this.groupBox2.Controls.Add(this.textBox_PrestamosActivos);
            this.groupBox2.Location = new System.Drawing.Point(62, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 200);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos prestamos";
            // 
            // FBusquedaUsuarioExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 449);
            this.Controls.Add(this.lb_PrestVencidos);
            this.Controls.Add(this.lb_EjemplaresUltMes);
            this.Controls.Add(this.comboBox_Dnis);
            this.Controls.Add(this.lb_Dni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FBusquedaUsuarioExtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Búsqueda de usuarios por dni";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Dni;
        private System.Windows.Forms.ComboBox comboBox_Dnis;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label lb_PrestamosActivos;
        private System.Windows.Forms.Label lb_EjemplaresUltMes;
        private System.Windows.Forms.Label lb_PrestVencidos;
        private System.Windows.Forms.TextBox textBox_PrestamosActivos;
        private System.Windows.Forms.TextBox textBox_EjemUltMes;
        private System.Windows.Forms.TextBox textBox_PrestVencidos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}