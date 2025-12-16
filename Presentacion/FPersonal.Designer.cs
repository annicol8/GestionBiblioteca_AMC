namespace Presentacion
{
    partial class FPersonal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuariosAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuariosBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuariosBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuListado = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecorrerUnoAUno = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocumentosAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocumentosBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocumentosBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEjemplaresAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEjemplaresBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEjemplaresBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.préstamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrestamosNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrestamosBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrestamosDevolver = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaPorDniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.documentosToolStripMenuItem,
            this.ejemplaresToolStripMenuItem,
            this.préstamosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuariosAlta,
            this.menuUsuariosBaja,
            this.menuUsuariosBuscar,
            this.busquedaPorDniToolStripMenuItem,
            this.menuListado,
            this.menuRecorrerUnoAUno});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // menuUsuariosAlta
            // 
            this.menuUsuariosAlta.Name = "menuUsuariosAlta";
            this.menuUsuariosAlta.Size = new System.Drawing.Size(276, 34);
            this.menuUsuariosAlta.Text = "Alta ";
            this.menuUsuariosAlta.Click += new System.EventHandler(this.menuUsuariosAlta_Click);
            // 
            // menuUsuariosBaja
            // 
            this.menuUsuariosBaja.Name = "menuUsuariosBaja";
            this.menuUsuariosBaja.Size = new System.Drawing.Size(276, 34);
            this.menuUsuariosBaja.Text = "Baja";
            this.menuUsuariosBaja.Click += new System.EventHandler(this.menuUsuariosBaja_Click);
            // 
            // menuUsuariosBuscar
            // 
            this.menuUsuariosBuscar.Name = "menuUsuariosBuscar";
            this.menuUsuariosBuscar.Size = new System.Drawing.Size(276, 34);
            this.menuUsuariosBuscar.Text = "Buscar";
            this.menuUsuariosBuscar.Click += new System.EventHandler(this.menuUsuariosBuscar_Click);
            // 
            // menuListado
            // 
            this.menuListado.Name = "menuListado";
            this.menuListado.Size = new System.Drawing.Size(276, 34);
            this.menuListado.Text = "Listado";
            this.menuListado.Click += new System.EventHandler(this.menuListado_Click);
            // 
            // menuRecorrerUnoAUno
            // 
            this.menuRecorrerUnoAUno.Name = "menuRecorrerUnoAUno";
            this.menuRecorrerUnoAUno.Size = new System.Drawing.Size(276, 34);
            this.menuRecorrerUnoAUno.Text = "Recorrido uno a uno";
            this.menuRecorrerUnoAUno.Click += new System.EventHandler(this.menuRecorrerUnoAUno_Click);
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDocumentosAlta,
            this.menuDocumentosBaja,
            this.menuDocumentosBuscar});
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(130, 29);
            this.documentosToolStripMenuItem.Text = "Documentos";
            // 
            // menuDocumentosAlta
            // 
            this.menuDocumentosAlta.Name = "menuDocumentosAlta";
            this.menuDocumentosAlta.Size = new System.Drawing.Size(165, 34);
            this.menuDocumentosAlta.Text = "Alta";
            this.menuDocumentosAlta.Click += new System.EventHandler(this.menuDocumentosAlta_Click);
            // 
            // menuDocumentosBaja
            // 
            this.menuDocumentosBaja.Name = "menuDocumentosBaja";
            this.menuDocumentosBaja.Size = new System.Drawing.Size(165, 34);
            this.menuDocumentosBaja.Text = "Baja";
            // 
            // menuDocumentosBuscar
            // 
            this.menuDocumentosBuscar.Name = "menuDocumentosBuscar";
            this.menuDocumentosBuscar.Size = new System.Drawing.Size(165, 34);
            this.menuDocumentosBuscar.Text = "Buscar";
            // 
            // ejemplaresToolStripMenuItem
            // 
            this.ejemplaresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEjemplaresAlta,
            this.menuEjemplaresBaja,
            this.menuEjemplaresBuscar});
            this.ejemplaresToolStripMenuItem.Name = "ejemplaresToolStripMenuItem";
            this.ejemplaresToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.ejemplaresToolStripMenuItem.Text = "Ejemplares";
            // 
            // menuEjemplaresAlta
            // 
            this.menuEjemplaresAlta.Name = "menuEjemplaresAlta";
            this.menuEjemplaresAlta.Size = new System.Drawing.Size(165, 34);
            this.menuEjemplaresAlta.Text = "Alta";
            // 
            // menuEjemplaresBaja
            // 
            this.menuEjemplaresBaja.Name = "menuEjemplaresBaja";
            this.menuEjemplaresBaja.Size = new System.Drawing.Size(165, 34);
            this.menuEjemplaresBaja.Text = "Baja";
            // 
            // menuEjemplaresBuscar
            // 
            this.menuEjemplaresBuscar.Name = "menuEjemplaresBuscar";
            this.menuEjemplaresBuscar.Size = new System.Drawing.Size(165, 34);
            this.menuEjemplaresBuscar.Text = "Buscar";
            // 
            // préstamosToolStripMenuItem
            // 
            this.préstamosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrestamosNuevo,
            this.menuPrestamosBuscar,
            this.menuPrestamosDevolver});
            this.préstamosToolStripMenuItem.Name = "préstamosToolStripMenuItem";
            this.préstamosToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.préstamosToolStripMenuItem.Text = "Préstamos";
            // 
            // menuPrestamosNuevo
            // 
            this.menuPrestamosNuevo.Name = "menuPrestamosNuevo";
            this.menuPrestamosNuevo.Size = new System.Drawing.Size(184, 34);
            this.menuPrestamosNuevo.Text = "Nuevo";
            // 
            // menuPrestamosBuscar
            // 
            this.menuPrestamosBuscar.Name = "menuPrestamosBuscar";
            this.menuPrestamosBuscar.Size = new System.Drawing.Size(184, 34);
            this.menuPrestamosBuscar.Text = "Buscar";
            // 
            // menuPrestamosDevolver
            // 
            this.menuPrestamosDevolver.Name = "menuPrestamosDevolver";
            this.menuPrestamosDevolver.Size = new System.Drawing.Size(184, 34);
            this.menuPrestamosDevolver.Text = "Devolver";
            // 
            // busquedaPorDniToolStripMenuItem
            // 
            this.busquedaPorDniToolStripMenuItem.Name = "busquedaPorDniToolStripMenuItem";
            this.busquedaPorDniToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.busquedaPorDniToolStripMenuItem.Text = "Búsqueda por dni";
            this.busquedaPorDniToolStripMenuItem.Click += new System.EventHandler(this.busquedaPorDniToolStripMenuItem_Click);
            // 
            // FPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FPersonal";
            this.Text = "Gestión de biblioteca";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemplaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem préstamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuUsuariosAlta;
        private System.Windows.Forms.ToolStripMenuItem menuUsuariosBaja;
        private System.Windows.Forms.ToolStripMenuItem menuUsuariosBuscar;
        private System.Windows.Forms.ToolStripMenuItem menuDocumentosAlta;
        private System.Windows.Forms.ToolStripMenuItem menuDocumentosBaja;
        private System.Windows.Forms.ToolStripMenuItem menuDocumentosBuscar;
        private System.Windows.Forms.ToolStripMenuItem menuEjemplaresAlta;
        private System.Windows.Forms.ToolStripMenuItem menuEjemplaresBaja;
        private System.Windows.Forms.ToolStripMenuItem menuEjemplaresBuscar;
        private System.Windows.Forms.ToolStripMenuItem menuPrestamosNuevo;
        private System.Windows.Forms.ToolStripMenuItem menuPrestamosBuscar;
        private System.Windows.Forms.ToolStripMenuItem menuPrestamosDevolver;
        private System.Windows.Forms.ToolStripMenuItem menuListado;
        private System.Windows.Forms.ToolStripMenuItem menuRecorrerUnoAUno;
        private System.Windows.Forms.ToolStripMenuItem busquedaPorDniToolStripMenuItem;
    }
}