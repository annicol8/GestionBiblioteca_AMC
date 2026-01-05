namespace Presentacion
{
    partial class FPrestamosFueraDdePlazo
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
            this.dataGridViewPrestamos = new System.Windows.Forms.DataGridView();
            this.listBoxEjemplares = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPrestamos
            // 
            this.dataGridViewPrestamos.AllowUserToAddRows = false;
            this.dataGridViewPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrestamos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewPrestamos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPrestamos.MultiSelect = false;
            this.dataGridViewPrestamos.Name = "dataGridViewPrestamos";
            this.dataGridViewPrestamos.ReadOnly = true;
            this.dataGridViewPrestamos.RowHeadersWidth = 62;
            this.dataGridViewPrestamos.RowTemplate.Height = 28;
            this.dataGridViewPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrestamos.Size = new System.Drawing.Size(800, 223);
            this.dataGridViewPrestamos.TabIndex = 0;
            // 
            // listBoxEjemplares
            // 
            this.listBoxEjemplares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEjemplares.FormattingEnabled = true;
            this.listBoxEjemplares.ItemHeight = 20;
            this.listBoxEjemplares.Location = new System.Drawing.Point(0, 223);
            this.listBoxEjemplares.Name = "listBoxEjemplares";
            this.listBoxEjemplares.Size = new System.Drawing.Size(800, 227);
            this.listBoxEjemplares.TabIndex = 1;
            // 
            // FPrestamosFueraDdePlazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxEjemplares);
            this.Controls.Add(this.dataGridViewPrestamos);
            this.Name = "FPrestamosFueraDdePlazo";
            this.Text = "FPrestamosFueraDdePlazo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPrestamos;
        private System.Windows.Forms.ListBox listBoxEjemplares;
    }
}