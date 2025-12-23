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
            this.groupB_TipoEmp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Nombre
            // 
            this.lb_Nombre.AutoSize = true;
            this.lb_Nombre.Location = new System.Drawing.Point(85, 75);
            this.lb_Nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Nombre.Name = "lb_Nombre";
            this.lb_Nombre.Size = new System.Drawing.Size(93, 25);
            this.lb_Nombre.TabIndex = 0;
            this.lb_Nombre.Text = "Nombre:";
            // 
            // lb_Contraseña
            // 
            this.lb_Contraseña.AutoSize = true;
            this.lb_Contraseña.Location = new System.Drawing.Point(85, 150);
            this.lb_Contraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Contraseña.Name = "lb_Contraseña";
            this.lb_Contraseña.Size = new System.Drawing.Size(129, 25);
            this.lb_Contraseña.TabIndex = 1;
            this.lb_Contraseña.Text = "Contraseña:";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(288, 71);
            this.textBox_Nombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(193, 31);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Location = new System.Drawing.Point(288, 150);
            this.textBox_Contraseña.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.Size = new System.Drawing.Size(193, 31);
            this.textBox_Contraseña.TabIndex = 1;
            this.textBox_Contraseña.UseSystemPasswordChar = true;
            // 
            // bt_Entrar
            // 
            this.bt_Entrar.Location = new System.Drawing.Point(372, 426);
            this.bt_Entrar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Entrar.Name = "bt_Entrar";
            this.bt_Entrar.Size = new System.Drawing.Size(111, 39);
            this.bt_Entrar.TabIndex = 4;
            this.bt_Entrar.Text = "Entrar";
            this.bt_Entrar.UseVisualStyleBackColor = true;
            this.bt_Entrar.Click += new System.EventHandler(this.bt_Entrar_Click);
            // 
            // groupB_TipoEmp
            // 
            this.groupB_TipoEmp.Controls.Add(this.radioButton_PAdq);
            this.groupB_TipoEmp.Controls.Add(this.radioButton_PSala);
            this.groupB_TipoEmp.Location = new System.Drawing.Point(91, 244);
            this.groupB_TipoEmp.Margin = new System.Windows.Forms.Padding(4);
            this.groupB_TipoEmp.Name = "groupB_TipoEmp";
            this.groupB_TipoEmp.Padding = new System.Windows.Forms.Padding(4);
            this.groupB_TipoEmp.Size = new System.Drawing.Size(392, 145);
            this.groupB_TipoEmp.TabIndex = 5;
            this.groupB_TipoEmp.TabStop = false;
            this.groupB_TipoEmp.Text = "Tipo empleado";
            // 
            // radioButton_PAdq
            // 
            this.radioButton_PAdq.AutoSize = true;
            this.radioButton_PAdq.Location = new System.Drawing.Point(56, 86);
            this.radioButton_PAdq.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_PAdq.Name = "radioButton_PAdq";
            this.radioButton_PAdq.Size = new System.Drawing.Size(266, 29);
            this.radioButton_PAdq.TabIndex = 1;
            this.radioButton_PAdq.TabStop = true;
            this.radioButton_PAdq.Text = "Personal adquisiciones";
            this.radioButton_PAdq.UseVisualStyleBackColor = true;
            // 
            // radioButton_PSala
            // 
            this.radioButton_PSala.AutoSize = true;
            this.radioButton_PSala.Location = new System.Drawing.Point(56, 49);
            this.radioButton_PSala.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_PSala.Name = "radioButton_PSala";
            this.radioButton_PSala.Size = new System.Drawing.Size(174, 29);
            this.radioButton_PSala.TabIndex = 0;
            this.radioButton_PSala.TabStop = true;
            this.radioButton_PSala.Text = "Personal sala";
            this.radioButton_PSala.UseVisualStyleBackColor = true;
            // 
            // FLogin
            // 
            this.AcceptButton = this.bt_Entrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 538);
            this.Controls.Add(this.groupB_TipoEmp);
            this.Controls.Add(this.bt_Entrar);
            this.Controls.Add(this.textBox_Contraseña);
            this.Controls.Add(this.textBox_Nombre);
            this.Controls.Add(this.lb_Contraseña);
            this.Controls.Add(this.lb_Nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolTip toolTip5;
    }
}