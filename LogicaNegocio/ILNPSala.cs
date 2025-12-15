using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public interface ILNPSala: ILNPersonal
    {
        int AltaPrestamo(Prestamo prestamo);
        //bool BajaPrestamo(Prestamo p);
        Usuario GetUsuarioPrestamo(int idPrestamo); // Puede devolver null si no se encuentra el prestamo (no deja hacer lo de nullables)
        EstadoPrestamo? GetEstadoPrestamo(int idPrestamo);
        List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo);
        Prestamo GetPrestamo(int idPrestamo);

        List<Prestamo> GetPrestamosPorDocumento(string isbn);
        //List<Prestamo> GetPrestamosPorUsuario(string dni);
        void DevolverEjemplar(int idPrestamo, int codigoEjemplar); // Codigo ejemplar es int?
        List<Prestamo> GetPrestamosFueraDePlazo();
        //bool HayEjemplaresDisponibles(string isbn);
        //DateTime? GetFechaDisponibilidadDocumento(string isbn);
    }
}
