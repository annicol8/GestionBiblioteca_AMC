namespace Presentacion
{
    partial class FAltaPersonal
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
            this.lb_Dni = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_Tipo = new System.Windows.Forms.GroupBox();
            this.check_Adq = new System.Windows.Forms.CheckBox();
            this.check_Sala = new System.Windows.Forms.CheckBox();
            this.tb_Dni = new System.Windows.Forms.TextBox();
            this.tb_Nombre = new System.Windows.Forms.TextBox();
            this.tb_Contraseña = new System.Windows.Forms.TextBox();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.groupBox_Tipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Dni
            // 
            this.lb_Dni.AutoSize = true;
            this.lb_Dni.Location = new System.Drawing.Point(108, 77);
            this.lb_Dni.Name = "lb_Dni";
            this.lb_Dni.Size = new System.Drawing.Size(45, 20);
            this.lb_Dni.TabIndex = 0;
            this.lb_Dni.Text = "DNI: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña: ";
            // 
            // groupBox_Tipo
            // 
            this.groupBox_Tipo.Controls.Add(this.check_Adq);
            this.groupBox_Tipo.Controls.Add(this.check_Sala);
            this.groupBox_Tipo.Location = new System.Drawing.Point(112, 239);
            this.groupBox_Tipo.Name = "groupBox_Tipo";
            this.groupBox_Tipo.Size = new System.Drawing.Size(367, 147);
            this.groupBox_Tipo.TabIndex = 4;
            this.groupBox_Tipo.TabStop = false;
            this.groupBox_Tipo.Text = "Tipo de personal";
            // 
            // check_Adq
            // 
            this.check_Adq.AutoSize = true;
            this.check_Adq.Location = new System.Drawing.Point(61, 83);
            this.check_Adq.Name = "check_Adq";
            this.check_Adq.Size = new System.Drawing.Size(219, 24);
            this.check_Adq.TabIndex = 1;
            this.check_Adq.Text = "Personal de adquisiciones";
            this.check_Adq.UseVisualStyleBackColor = true;
            this.check_Adq.CheckedChanged += new System.EventHandler(this.chkAdquisiciones_CheckedChanged);
            // 
            // check_Sala
            // 
            this.check_Sala.AutoSize = true;
            this.check_Sala.Location = new System.Drawing.Point(61, 44);
            this.check_Sala.Name = "check_Sala";
            this.check_Sala.Size = new System.Drawing.Size(130, 24);
            this.check_Sala.TabIndex = 0;
            this.check_Sala.Text = "Personal sala";
            this.check_Sala.UseVisualStyleBackColor = true;
            this.check_Sala.CheckedChanged += new System.EventHandler(this.chkSala_CheckedChanged);
            // 
            // tb_Dni
            // 
            this.tb_Dni.Location = new System.Drawing.Point(261, 71);
            this.tb_Dni.Name = "tb_Dni";
            this.tb_Dni.ReadOnly = true;
            this.tb_Dni.Size = new System.Drawing.Size(218, 26);
            this.tb_Dni.TabIndex = 5;
            // 
            // tb_Nombre
            // 
            this.tb_Nombre.Location = new System.Drawing.Point(261, 128);
            this.tb_Nombre.Name = "tb_Nombre";
            this.tb_Nombre.Size = new System.Drawing.Size(218, 26);
            this.tb_Nombre.TabIndex = 6;
            // 
            // tb_Contraseña
            // 
            this.tb_Contraseña.Location = new System.Drawing.Point(261, 185);
            this.tb_Contraseña.Name = "tb_Contraseña";
            this.tb_Contraseña.Size = new System.Drawing.Size(218, 26);
            this.tb_Contraseña.TabIndex = 7;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(165, 414);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(103, 34);
            this.button_Aceptar.TabIndex = 8;
            this.button_Aceptar.Text = "Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(321, 414);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 34);
            this.button_Cancelar.TabIndex = 9;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // FAltaPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 500);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.tb_Contraseña);
            this.Controls.Add(this.tb_Nombre);
            this.Controls.Add(this.tb_Dni);
            this.Controls.Add(this.groupBox_Tipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_Dni);
            this.Name = "FAltaPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta personal";
            this.groupBox_Tipo.ResumeLayout(false);
            this.groupBox_Tipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Dni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox_Tipo;
        private System.Windows.Forms.CheckBox check_Adq;
        private System.Windows.Forms.CheckBox check_Sala;
        private System.Windows.Forms.TextBox tb_Dni;
        private System.Windows.Forms.TextBox tb_Nombre;
        private System.Windows.Forms.TextBox tb_Contraseña;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Button button_Cancelar;
    }
}