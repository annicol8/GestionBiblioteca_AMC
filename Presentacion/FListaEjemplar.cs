using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FListaEjemplar : FComun
    {
        private ILNPAdq lnpa;

        //PRE:
        //POST: El formulario queda inicializado sin cargar datos
        public FListaEjemplar()
        {
            InitializeComponent();
        }

        //PRE: lnpa != null
        //POST: El formulario queda inicializado. Se cargan los documentos y sus ejemplares en el TreeView
        public FListaEjemplar(ILNPAdq lnpa) : this() 
        {  
            this.lnpa = lnpa;
            CargarEjemplares();
        }

        //PRE: lnpa ha sido inicializado correctamente
        //POST: El TreeView queda limpio antes de cargar datos
        //      Si no hay documentos, se muestra una advertencia y no se cargan nodo.
        //      Para cada documento se añade un nodo con sus ejemplares. Cada ejemplar se muestra con su estado y personal asociado
        //      Los ejemplares activos se muestran en verde y los inactivos en rojo. El TreeView queda completamente expandido
        private void CargarEjemplares()
        {
            try
            {
                treeView_Ejemplares.Nodes.Clear();

                List<Documento> documentos = lnpa.getDocumentos();

                if (documentos == null || documentos.Count == 0)
                {
                    MostrarAdvertencia(
                        "No hay documentos en el sistema.",
                        "Sin datos");
                    return;
                }

                foreach (Documento doc in documentos)
                {
                    List<Ejemplar> ejemplares = lnpa.ejemplaresPorDocumento(doc.Isbn);

                    TreeNode nodoDocumento = new TreeNode(
                        $" * {doc.Titulo} [{ejemplares.Count} ejemplares]");
                    nodoDocumento.Tag = doc;
                    
                    foreach (Ejemplar ej in ejemplares)
                    {
                        Personal personal = lnpa.GetPersonal(ej.DniPAdq);
                        string nombrePersonal = personal != null ? personal.Nombre : "Desconocido";

                        string textoEjemplar = $"Código: {ej.Codigo} - " +
                                              $"{(ej.Activo ? "Activo" : "Inactivo")} - " +
                                              $"Personal: {nombrePersonal}";

                        TreeNode nodoEjemplar = new TreeNode(textoEjemplar);
                        nodoEjemplar.Tag = ej;

                        if (ej.Activo)
                            nodoEjemplar.ForeColor = Color.Green;
                        else
                            nodoEjemplar.ForeColor = Color.Red;

                        nodoDocumento.Nodes.Add(nodoEjemplar);
                    }

                    treeView_Ejemplares.Nodes.Add(nodoDocumento);
                }

                treeView_Ejemplares.ExpandAll();
            } catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los ejemplares");
            }
        }

        //PRE: El nodo pulsado pertenece al TreeView de ejemplares
        //PRE: Si el nodo representa un Ejemplar, se muestran sus detalles en un mensaje
        private void treeView_Ejemplares_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is Ejemplar ejemplar)
            {
                MostrarInformacion(
                    $"Código: {ejemplar.Codigo}\n" +
                    $"ISBN: {ejemplar.IsbnDocumento}\n" +
                    $"Estado: {(ejemplar.Activo ? "Activo" : "Inactivo")}",
                    "Detalles del Ejemplar");
            }
        }

    }
}
