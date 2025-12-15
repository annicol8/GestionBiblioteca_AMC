namespace Presentacion
{
    partial class FListaDocumentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Doc = new System.Windows.Forms.DataGridView();
            this.dataGridView_Ejemplares = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ejemplares)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Doc
            // 
            this.dataGridView_Doc.AllowUserToAddRows = false;
            this.dataGridView_Doc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.dataGridView_Doc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Doc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Doc.EnableHeadersVisualStyles = false;
            this.dataGridView_Doc.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_Doc.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView_Doc.MultiSelect = false;
            this.dataGridView_Doc.Name = "dataGridView_Doc";
            this.dataGridView_Doc.ReadOnly = true;
            this.dataGridView_Doc.RowHeadersWidth = 62;
            this.dataGridView_Doc.RowTemplate.Height = 28;
            this.dataGridView_Doc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Doc.Size = new System.Drawing.Size(763, 185);
            this.dataGridView_Doc.TabIndex = 0;
            this.dataGridView_Doc.SelectionChanged += new System.EventHandler(this.dataGridView_Doc_SelectionChanged);
            // 
            // dataGridView_Ejemplares
            // 
            this.dataGridView_Ejemplares.AllowUserToAddRows = false;
            this.dataGridView_Ejemplares.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView_Ejemplares.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Ejemplares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Ejemplares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Ejemplares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Ejemplares.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_Ejemplares.Location = new System.Drawing.Point(-1, 264);
            this.dataGridView_Ejemplares.Name = "dataGridView_Ejemplares";
            this.dataGridView_Ejemplares.ReadOnly = true;
            this.dataGridView_Ejemplares.RowHeadersWidth = 62;
            this.dataGridView_Ejemplares.RowTemplate.Height = 28;
            this.dataGridView_Ejemplares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Ejemplares.Size = new System.Drawing.Size(763, 189);
            this.dataGridView_Ejemplares.TabIndex = 1;
            // 
            // FListaDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_Ejemplares);
            this.Controls.Add(this.dataGridView_Doc);
            this.Name = "FListaDocumentos";
            this.Text = "Listado de documentos con ejemplares";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ejemplares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Doc;
        private System.Windows.Forms.DataGridView dataGridView_Ejemplares;
    }
}