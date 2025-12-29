namespace Presentacion
{
    partial class FBuscarPrestamo
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
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.groupBoxEjemplares = new System.Windows.Forms.GroupBox();
            this.listBoxEjemplares = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.groupBoxEjemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(98, 84);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.ReadOnly = true;
            this.textBoxCodigo.Size = new System.Drawing.Size(246, 26);
            this.textBoxCodigo.TabIndex = 0;
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Location = new System.Drawing.Point(98, 137);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.ReadOnly = true;
            this.textBoxFecha.Size = new System.Drawing.Size(246, 26);
            this.textBoxFecha.TabIndex = 1;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(98, 192);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.ReadOnly = true;
            this.textBoxUsuario.Size = new System.Drawing.Size(246, 26);
            this.textBoxUsuario.TabIndex = 2;
            // 
            // groupBoxEjemplares
            // 
            this.groupBoxEjemplares.Controls.Add(this.listBoxEjemplares);
            this.groupBoxEjemplares.Location = new System.Drawing.Point(362, 23);
            this.groupBoxEjemplares.Name = "groupBoxEjemplares";
            this.groupBoxEjemplares.Size = new System.Drawing.Size(401, 403);
            this.groupBoxEjemplares.TabIndex = 3;
            this.groupBoxEjemplares.TabStop = false;
            this.groupBoxEjemplares.Text = "Ejemplares del préstamo";
            // 
            // listBoxEjemplares
            // 
            this.listBoxEjemplares.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxEjemplares.FormattingEnabled = true;
            this.listBoxEjemplares.ItemHeight = 20;
            this.listBoxEjemplares.Location = new System.Drawing.Point(17, 43);
            this.listBoxEjemplares.Name = "listBoxEjemplares";
            this.listBoxEjemplares.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxEjemplares.Size = new System.Drawing.Size(368, 344);
            this.listBoxEjemplares.TabIndex = 0;
            this.listBoxEjemplares.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxEjemplares_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estado:";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(178, 284);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(0, 20);
            this.labelEstado.TabIndex = 5;
            // 
            // FBuscarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxEjemplares);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.textBoxFecha);
            this.Controls.Add(this.textBoxCodigo);
            this.Name = "FBuscarPrestamo";
            this.Text = "Buscar préstamo";
            this.Load += new System.EventHandler(this.FBuscarPrestamo_Load);
            this.groupBoxEjemplares.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.GroupBox groupBoxEjemplares;
        private System.Windows.Forms.ListBox listBoxEjemplares;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEstado;
    }
}