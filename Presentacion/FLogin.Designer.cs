namespace Presentacion
{
    partial class FLogin
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
            this.lb_Nombre = new System.Windows.Forms.Label();
            this.lb_Contraseña = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Contraseña = new System.Windows.Forms.TextBox();
            this.bt_Entrar = new System.Windows.Forms.Button();
            this.groupB_TipoEmp = new System.Windows.Forms.GroupBox();
            this.radioButton_PAdq = new System.Windows.Forms.RadioButton();
            this.radioButton_PSala = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.groupB_TipoEmp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Nombre
            // 
            this.lb_Nombre.AutoSize = true;
            this.lb_Nombre.Location = new System.Drawing.Point(64, 60);
            this.lb_Nombre.Name = "lb_Nombre";
            this.lb_Nombre.Size = new System.Drawing.Size(69, 20);
            this.lb_Nombre.TabIndex = 0;
            this.lb_Nombre.Text = "Nombre:";
            // 
            // lb_Contraseña
            // 
            this.lb_Contraseña.AutoSize = true;
            this.lb_Contraseña.Location = new System.Drawing.Point(64, 120);
            this.lb_Contraseña.Name = "lb_Contraseña";
            this.lb_Contraseña.Size = new System.Drawing.Size(96, 20);
            this.lb_Contraseña.TabIndex = 1;
            this.lb_Contraseña.Text = "Contraseña:";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(216, 57);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(146, 26);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Location = new System.Drawing.Point(216, 120);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.Size = new System.Drawing.Size(146, 26);
            this.textBox_Contraseña.TabIndex = 1;
            this.textBox_Contraseña.UseSystemPasswordChar = true;
            // 
            // bt_Entrar
            // 
            this.bt_Entrar.Location = new System.Drawing.Point(279, 341);
            this.bt_Entrar.Name = "bt_Entrar";
            this.bt_Entrar.Size = new System.Drawing.Size(83, 31);
            this.bt_Entrar.TabIndex = 4;
            this.bt_Entrar.Text = "Entrar";
            this.bt_Entrar.UseVisualStyleBackColor = true;
            this.bt_Entrar.Click += new System.EventHandler(this.bt_Entrar_Click);
            // 
            // groupB_TipoEmp
            // 
            this.groupB_TipoEmp.Controls.Add(this.radioButton_PAdq);
            this.groupB_TipoEmp.Controls.Add(this.radioButton_PSala);
            this.groupB_TipoEmp.Location = new System.Drawing.Point(68, 195);
            this.groupB_TipoEmp.Name = "groupB_TipoEmp";
            this.groupB_TipoEmp.Size = new System.Drawing.Size(294, 116);
            this.groupB_TipoEmp.TabIndex = 5;
            this.groupB_TipoEmp.TabStop = false;
            this.groupB_TipoEmp.Text = "Tipo empleado";
            // 
            // radioButton_PAdq
            // 
            this.radioButton_PAdq.AutoSize = true;
            this.radioButton_PAdq.Location = new System.Drawing.Point(42, 69);
            this.radioButton_PAdq.Name = "radioButton_PAdq";
            this.radioButton_PAdq.Size = new System.Drawing.Size(196, 24);
            this.radioButton_PAdq.TabIndex = 1;
            this.radioButton_PAdq.TabStop = true;
            this.radioButton_PAdq.Text = "Personal adquisiciones";
            this.radioButton_PAdq.UseVisualStyleBackColor = true;
            // 
            // radioButton_PSala
            // 
            this.radioButton_PSala.AutoSize = true;
            this.radioButton_PSala.Location = new System.Drawing.Point(42, 39);
            this.radioButton_PSala.Name = "radioButton_PSala";
            this.radioButton_PSala.Size = new System.Drawing.Size(132, 24);
            this.radioButton_PSala.TabIndex = 0;
            this.radioButton_PSala.TabStop = true;
            this.radioButton_PSala.Text = "Personal Sala";
            this.radioButton_PSala.UseVisualStyleBackColor = true;
            // 
            // FLogin
            // 
            this.AcceptButton = this.bt_Entrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 430);
            this.Controls.Add(this.groupB_TipoEmp);
            this.Controls.Add(this.bt_Entrar);
            this.Controls.Add(this.textBox_Contraseña);
            this.Controls.Add(this.textBox_Nombre);
            this.Controls.Add(this.lb_Contraseña);
            this.Controls.Add(this.lb_Nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loguearse";
            this.groupB_TipoEmp.ResumeLayout(false);
            this.groupB_TipoEmp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lb_Nombre;
        private System.Windows.Forms.Label lb_Contraseña;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Contraseña;
        private System.Windows.Forms.Button bt_Entrar;
        private System.Windows.Forms.GroupBox groupB_TipoEmp;
        private System.Windows.Forms.RadioButton radioButton_PAdq;
        private System.Windows.Forms.RadioButton radioButton_PSala;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
    }
}