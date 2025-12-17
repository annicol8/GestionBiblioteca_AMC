using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FPrestamosUnoAUno : FComun
    {
        private ILNPSala lnps;
        private BindingSource bindingSourcePrest;
        public FPrestamosUnoAUno(ILNPSala lnps)
        {
            InitializeComponent();
            this.lnps = lnps;
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            try
            {
                bindingSourcePrest = new BindingSource();
                bindingSourcePrest.DataSource = lnps.GetTodosPrestamos();

                bindingNavigator1.BindingSource = bindingSourcePrest;

                bindingSourcePrest.CurrentChanged += BindingSource_CurrentChanged;
                
                MostrarPrestamoActual();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al inicializar el formulario: {ex.Message}");
            }
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MostrarPrestamoActual();
        }

        private void MostrarPrestamoActual()
        {
            if (bindingSourcePrest.Current != null)
            {
                Prestamo prestamo = bindingSourcePrest.Current as Prestamo;
                if (prestamo != null)
                {
                    textBox_Id.Text = prestamo.Id.ToString();
                    textBox_FechaPrest.Text = prestamo.FechaPrestamo.ToString("dddd, d 'de' MMMM 'de' yyyy 'a las' HH:mm");

                    //verificamos si esta devuelto o no 
                    if (prestamo.Estado == EstadoPrestamo.finalizado)
                    {
                        textBox_FechaDevolucion.Text = prestamo.FechaDevolucion.ToString("dddd, d 'de' MMMM 'de' yyyy 'a las' HH:mm");
                    }
                    else
                    {
                        textBox_FechaDevolucion.Text = "No devuelto todavía";
                    }

                    Usuario usuario = lnps.GetUsuario(prestamo.DniUsuario);
                    textBox_Usuario.Text = usuario.Dni + ", " + usuario.Nombre;

                    // Estado
                    EstadoPrestamo estado = prestamo.Estado;
                    textBox_Estado.Text = estado.ToString();

                    // Prestador (Personal) con nombre
                    Personal personal = lnps.GetPersonal(prestamo.DniPersonal); 
                    textBox_Personal.Text = personal.Dni + ", " + personal.Nombre;

                    // Cargar documentos/ejemplares en el ListBox
                    CargarEjemplaresPrestamo(prestamo.Id);
                }
            }
        }

        private void CargarEjemplaresPrestamo(int idPrestamo)
        {
            try
            {
                listBox_Doc.Items.Clear();

                // Obtener ejemplares del préstamo
                List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresDePrestamo(idPrestamo);

                int contador = 1;
                foreach (Ejemplar ejemplar in ejemplares)
                {
                    // Obtener el documento asociado al ejemplar
                    Documento doc = Persistencia.Persistencia.GetDocumento(ejemplar.IsbnDocumento);

                    if (doc != null)
                    {
                        listBox_Doc.Items.Add($"{contador}. \"{doc.Titulo}\"");
                        contador++;
                    }
                }
            }
            catch (Exception ex)
            {
                listBox_Doc.Items.Clear();
                listBox_Doc.Items.Add($"Error: {ex.Message}");
            }
        }



    }
}
