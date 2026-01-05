namespace Presentacion
{
    partial class FPrestamosPorDocumento
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
            this.groupBoxPrestamos = new System.Windows.Forms.GroupBox();
            this.listBoxPrestamos = new System.Windows.Forms.ListBox();
            this.buttonVer = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.groupBoxPrestamos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPrestamos
            // 
            this.groupBoxPrestamos.Controls.Add(this.listBoxPrestamos);
            this.groupBoxPrestamos.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPrestamos.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPrestamos.Name = "groupBoxPrestamos";
            this.groupBoxPrestamos.Size = new System.Drawing.Size(800, 285);
            this.groupBoxPrestamos.TabIndex = 0;
            this.groupBoxPrestamos.TabStop = false;
            this.groupBoxPrestamos.Text = "Préstamos encontrados";
            // 
            // listBoxPrestamos
            // 
            this.listBoxPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPrestamos.FormattingEnabled = true;
            this.listBoxPrestamos.ItemHeight = 20;
            this.listBoxPrestamos.Location = new System.Drawing.Point(3, 22);
            this.listBoxPrestamos.Name = "listBoxPrestamos";
            this.listBoxPrestamos.Size = new System.Drawing.Size(794, 260);
            this.listBoxPrestamos.TabIndex = 0;
            this.listBoxPrestamos.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.listBoxPrestamos_Format);
            // 
            // buttonVer
            // 
            this.buttonVer.Location = new System.Drawing.Point(57, 322);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(131, 47);
            this.buttonVer.TabIndex = 1;
            this.buttonVer.Text = "Ver información";
            this.buttonVer.UseVisualStyleBackColor = true;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(315, 322);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(129, 47);
            this.buttonCerrar.TabIndex = 2;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // FPrestamosPorDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonVer);
            this.Controls.Add(this.groupBoxPrestamos);
            this.Name = "FPrestamosPorDocumento";
            this.Text = "Préstamos por documento";
            this.Load += new System.EventHandler(this.FPrestamosPorDocumento_Load);
            this.groupBoxPrestamos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPrestamos;
        private System.Windows.Forms.ListBox listBoxPrestamos;
        private System.Windows.Forms.Button buttonVer;
        private System.Windows.Forms.Button buttonCerrar;
    }
}