namespace Presentacion
{
    partial class FListaUsuarios
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
            this.bt_OrdenDni = new System.Windows.Forms.Button();
            this.bt_OrdenNombre = new System.Windows.Forms.Button();
            this.listBox_Dni = new System.Windows.Forms.ListBox();
            this.listBox_Nombre = new System.Windows.Forms.ListBox();
            this.bt_Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_OrdenDni
            // 
            this.bt_OrdenDni.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_OrdenDni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_OrdenDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_OrdenDni.Location = new System.Drawing.Point(80, 92);
            this.bt_OrdenDni.Name = "bt_OrdenDni";
            this.bt_OrdenDni.Size = new System.Drawing.Size(190, 27);
            this.bt_OrdenDni.TabIndex = 0;
            this.bt_OrdenDni.Text = "DNI";
            this.bt_OrdenDni.UseVisualStyleBackColor = false;
            this.bt_OrdenDni.Click += new System.EventHandler(this.bt_OrdenDni_Click);
            // 
            // bt_OrdenNombre
            // 
            this.bt_OrdenNombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_OrdenNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_OrdenNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_OrdenNombre.Location = new System.Drawing.Point(347, 92);
            this.bt_OrdenNombre.Name = "bt_OrdenNombre";
            this.bt_OrdenNombre.Size = new System.Drawing.Size(191, 27);
            this.bt_OrdenNombre.TabIndex = 1;
            this.bt_OrdenNombre.Text = "Nombre";
            this.bt_OrdenNombre.UseVisualStyleBackColor = false;
            this.bt_OrdenNombre.Click += new System.EventHandler(this.bt_OrdenNombre_Click);
            // 
            // listBox_Dni
            // 
            this.listBox_Dni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Dni.FormattingEnabled = true;
            this.listBox_Dni.IntegralHeight = false;
            this.listBox_Dni.ItemHeight = 20;
            this.listBox_Dni.Location = new System.Drawing.Point(80, 151);
            this.listBox_Dni.Name = "listBox_Dni";
            this.listBox_Dni.Size = new System.Drawing.Size(190, 284);
            this.listBox_Dni.TabIndex = 2;
            this.listBox_Dni.SelectedIndexChanged += new System.EventHandler(this.listBox_Dni_SelectedIndexChanged);
            // 
            // listBox_Nombre
            // 
            this.listBox_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Nombre.FormattingEnabled = true;
            this.listBox_Nombre.IntegralHeight = false;
            this.listBox_Nombre.ItemHeight = 20;
            this.listBox_Nombre.Location = new System.Drawing.Point(347, 151);
            this.listBox_Nombre.Name = "listBox_Nombre";
            this.listBox_Nombre.Size = new System.Drawing.Size(191, 284);
            this.listBox_Nombre.TabIndex = 3;
            this.listBox_Nombre.SelectedIndexChanged += new System.EventHandler(this.listBox_Nombre_SelectedIndexChanged);
            // 
            // bt_Cerrar
            // 
            this.bt_Cerrar.Location = new System.Drawing.Point(255, 484);
            this.bt_Cerrar.Name = "bt_Cerrar";
            this.bt_Cerrar.Size = new System.Drawing.Size(103, 27);
            this.bt_Cerrar.TabIndex = 4;
            this.bt_Cerrar.Text = "Cerrar";
            this.bt_Cerrar.UseVisualStyleBackColor = true;
            this.bt_Cerrar.Click += new System.EventHandler(this.bt_Cerrar_Click);
            // 
            // FListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 633);
            this.Controls.Add(this.bt_Cerrar);
            this.Controls.Add(this.listBox_Nombre);
            this.Controls.Add(this.listBox_Dni);
            this.Controls.Add(this.bt_OrdenNombre);
            this.Controls.Add(this.bt_OrdenDni);
            this.Name = "FListaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de usuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_OrdenDni;
        private System.Windows.Forms.Button bt_OrdenNombre;
        private System.Windows.Forms.ListBox listBox_Dni;
        private System.Windows.Forms.ListBox listBox_Nombre;
        private System.Windows.Forms.Button bt_Cerrar;
    }
}