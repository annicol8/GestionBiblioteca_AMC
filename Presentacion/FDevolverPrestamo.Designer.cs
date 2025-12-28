namespace Presentacion
{
    partial class FDevolverPrestamo
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
            this.groupBoxEjemplares = new System.Windows.Forms.GroupBox();
            this.listBoxEjemplares = new System.Windows.Forms.ListBox();
            this.botonDevolver = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.groupBoxEjemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEjemplares
            // 
            this.groupBoxEjemplares.Controls.Add(this.listBoxEjemplares);
            this.groupBoxEjemplares.Location = new System.Drawing.Point(114, 12);
            this.groupBoxEjemplares.Name = "groupBoxEjemplares";
            this.groupBoxEjemplares.Size = new System.Drawing.Size(468, 392);
            this.groupBoxEjemplares.TabIndex = 0;
            this.groupBoxEjemplares.TabStop = false;
            this.groupBoxEjemplares.Text = "Ejemplares pendientes de devolución";
            // 
            // listBoxEjemplares
            // 
            this.listBoxEjemplares.DisplayMember = "InfoCompleta";
            this.listBoxEjemplares.FormattingEnabled = true;
            this.listBoxEjemplares.ItemHeight = 20;
            this.listBoxEjemplares.Location = new System.Drawing.Point(27, 49);
            this.listBoxEjemplares.Name = "listBoxEjemplares";
            this.listBoxEjemplares.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxEjemplares.Size = new System.Drawing.Size(404, 304);
            this.listBoxEjemplares.TabIndex = 0;
            // 
            // botonDevolver
            // 
            this.botonDevolver.Location = new System.Drawing.Point(644, 166);
            this.botonDevolver.Name = "botonDevolver";
            this.botonDevolver.Size = new System.Drawing.Size(109, 43);
            this.botonDevolver.TabIndex = 1;
            this.botonDevolver.Text = "Devolver";
            this.botonDevolver.UseVisualStyleBackColor = true;
            this.botonDevolver.Click += new System.EventHandler(this.botonDevolver_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(644, 265);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(109, 40);
            this.botonCancelar.TabIndex = 2;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // FDevolverPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonDevolver);
            this.Controls.Add(this.groupBoxEjemplares);
            this.Name = "FDevolverPrestamo";
            this.Text = "FDevolverPrestamo";
            this.Load += new System.EventHandler(this.FDevolverPrestamo_Load);
            this.groupBoxEjemplares.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEjemplares;
        private System.Windows.Forms.ListBox listBoxEjemplares;
        private System.Windows.Forms.Button botonDevolver;
        private System.Windows.Forms.Button botonCancelar;
    }
}