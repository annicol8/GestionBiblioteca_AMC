using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPSala : ILNPersonal
    {
        int AltaPrestamo(Prestamo prestamo);
        //bool BajaPrestamo(Prestamo p);
        Usuario GetUsuarioPrestamo(int idPrestamo); // Puede devolver null si no se encuentra el prestamo (no deja hacer lo de nullables)
        EstadoPrestamo? GetEstadoPrestamo(int idPrestamo);
        List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo);
        Prestamo GetPrestamo(int idPrestamo);


        void DevolverEjemplar(int idPrestamo, int codigoEjemplar);
        List<Prestamo> GetPrestamosFueraDePlazo();

        List<Prestamo> GetTodosPrestamos();
        List<Ejemplar> GetEjemplaresDePrestamo(int id);



        //bool HayEjemplaresDisponibles(string isbn);
        //DateTime? GetFechaDisponibilidadDocumento(string isbn);


        // AÑAADIDOS

        List<Ejemplar> GetEjemplaresActivos();
        List<Ejemplar> GetEjemplaresDisponibles(List<int> codigosExcluidos);
        int CrearPrestamoCompleto(Prestamo prestamo, List<int> codigosEjemplares);
        bool PuedeRealizarPrestamo(string dni);
    }
}
