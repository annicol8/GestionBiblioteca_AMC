namespace Presentacion
{
    partial class FListaPrestamos
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
            this.dataGridView_Prest = new System.Windows.Forms.DataGridView();
            this.listBox_Doc = new System.Windows.Forms.ListBox();
            this.lb_Prestamos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prest)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Prest
            // 
            this.dataGridView_Prest.AllowUserToAddRows = false;
            this.dataGridView_Prest.AllowUserToDeleteRows = false;
            this.dataGridView_Prest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Prest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Prest.Location = new System.Drawing.Point(21, 32);
            this.dataGridView_Prest.MultiSelect = false;
            this.dataGridView_Prest.Name = "dataGridView_Prest";
            this.dataGridView_Prest.ReadOnly = true;
            this.dataGridView_Prest.RowHeadersVisible = false;
            this.dataGridView_Prest.RowHeadersWidth = 62;
            this.dataGridView_Prest.RowTemplate.Height = 28;
            this.dataGridView_Prest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Prest.Size = new System.Drawing.Size(1111, 210);
            this.dataGridView_Prest.TabIndex = 0;
            this.dataGridView_Prest.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvPrestamos_CellFormatting);
            this.dataGridView_Prest.SelectionChanged += new System.EventHandler(this.DgvPrestamos_SelectionChanged);
            // 
            // listBox_Doc
            // 
            this.listBox_Doc.FormattingEnabled = true;
            this.listBox_Doc.ItemHeight = 20;
            this.listBox_Doc.Location = new System.Drawing.Point(21, 289);
            this.listBox_Doc.Name = "listBox_Doc";
            this.listBox_Doc.Size = new System.Drawing.Size(1111, 144);
            this.listBox_Doc.TabIndex = 1;
            // 
            // lb_Prestamos
            // 
            this.lb_Prestamos.AutoSize = true;
            this.lb_Prestamos.Location = new System.Drawing.Point(17, 9);
            this.lb_Prestamos.Name = "lb_Prestamos";
            this.lb_Prestamos.Size = new System.Drawing.Size(85, 20);
            this.lb_Prestamos.TabIndex = 4;
            this.lb_Prestamos.Text = "Préstamos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ejemplares del préstamo";
            // 
            // FListaPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Prestamos);
            this.Controls.Add(this.listBox_Doc);
            this.Controls.Add(this.dataGridView_Prest);
            this.Name = "FListaPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de préstamos con sus ejemplares";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Prest;
        private System.Windows.Forms.ListBox listBox_Doc;
        private System.Windows.Forms.Label lb_Prestamos;
        private System.Windows.Forms.Label label1;
    }
}