using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal interface ILNPSala
    {
        int AltaPrestamo(Prestamo prestamo);
        //bool BajaPrestamo(Prestamo p);
        Usuario GetUsuarioPrestamo(int idPrestamo);
        EstadoPrestamo GetEstadoPrestamo(int idPrestamo);
        List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo);
        Prestamo GetPrestamo(int idPrestamo);

        List<Prestamo> GetPrestamosPorDocumento(string isbn);
        //List<Prestamo> GetPrestamosPorUsuario(string dni);
        void DevolverEjemplar(int idPrestamo, string codigoEjemplar);
        List<Prestamo> GetPrestamosFueraDePlazo();
        //bool HayEjemplaresDisponibles(string isbn);
        //DateTime? GetFechaDisponibilidadDocumento(string isbn);
    }
}
