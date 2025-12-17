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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.lb_Prestamos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prest)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Prest
            // 
            this.dataGridView_Prest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Prest.Location = new System.Drawing.Point(21, 34);
            this.dataGridView_Prest.Name = "dataGridView_Prest";
            this.dataGridView_Prest.RowHeadersWidth = 62;
            this.dataGridView_Prest.RowTemplate.Height = 28;
            this.dataGridView_Prest.Size = new System.Drawing.Size(740, 210);
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
            this.listBox_Doc.Size = new System.Drawing.Size(740, 144);
            this.listBox_Doc.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(725, 34);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(26, 214);
            this.vScrollBar1.TabIndex = 2;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(725, 289);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(26, 144);
            this.vScrollBar2.TabIndex = 3;
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
            // FListaPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_Prestamos);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.listBox_Doc);
            this.Controls.Add(this.dataGridView_Prest);
            this.Name = "FListaPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de préstamos con sus documentos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Prest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Prest;
        private System.Windows.Forms.ListBox listBox_Doc;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.Label lb_Prestamos;
    }
}