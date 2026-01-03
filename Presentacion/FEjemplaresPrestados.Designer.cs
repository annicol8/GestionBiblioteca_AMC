namespace Presentacion
{
    partial class FEjemplaresPrestados
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
            this.lb_infoUsuario = new System.Windows.Forms.Label();
            this.dgv_Ejemplares = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ejemplares)).BeginInit();
            this.Activated += new System.EventHandler(this.FEjemplaresPrestados_Activated);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario: ";
            // 
            // lb_infoUsuario
            // 
            this.lb_infoUsuario.AutoSize = true;
            this.lb_infoUsuario.Location = new System.Drawing.Point(225, 57);
            this.lb_infoUsuario.Name = "lb_infoUsuario";
            this.lb_infoUsuario.Size = new System.Drawing.Size(13, 20);
            this.lb_infoUsuario.TabIndex = 1;
            this.lb_infoUsuario.Text = ".";
            // 
            // dgv_Ejemplares
            // 
            this.dgv_Ejemplares.AllowUserToAddRows = false;
            this.dgv_Ejemplares.AllowUserToDeleteRows = false;
            this.dgv_Ejemplares.AllowUserToResizeColumns = false;
            this.dgv_Ejemplares.AllowUserToResizeRows = false;
            this.dgv_Ejemplares.ColumnHeadersHeight = 34;
            this.dgv_Ejemplares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Ejemplares.Location = new System.Drawing.Point(75, 114);
            this.dgv_Ejemplares.Name = "dgv_Ejemplares";
            this.dgv_Ejemplares.ReadOnly = true;
            this.dgv_Ejemplares.RowHeadersVisible = false;
            this.dgv_Ejemplares.RowHeadersWidth = 62;
            this.dgv_Ejemplares.RowTemplate.Height = 28;
            this.dgv_Ejemplares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Ejemplares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Ejemplares.Size = new System.Drawing.Size(546, 147);
            this.dgv_Ejemplares.TabIndex = 2;
            // 
            // FEjemplaresPrestados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 301);
            this.Controls.Add(this.dgv_Ejemplares);
            this.Controls.Add(this.lb_infoUsuario);
            this.Controls.Add(this.label1);
            this.Name = "FEjemplaresPrestados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.Load += new System.EventHandler(this.FEjemplaresPrestados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ejemplares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_infoUsuario;
        private System.Windows.Forms.DataGridView dgv_Ejemplares;
    }
}