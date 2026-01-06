using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPSala : ILNPersonal
    {
        int AltaPrestamo(Prestamo prestamo);
        Usuario GetUsuarioPrestamo(int idPrestamo); 
        EstadoPrestamo? GetEstadoPrestamo(int idPrestamo);
        List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo);
        Prestamo GetPrestamo(int idPrestamo);
        void DevolverEjemplar(int idPrestamo, int codigoEjemplar);
        List<Prestamo> GetPrestamosFueraDePlazo();
        List<Prestamo> GetTodosPrestamos();
        List<Ejemplar> GetEjemplaresDePrestamo(int id);
        List<Ejemplar> GetEjemplaresActivos();
        List<Ejemplar> GetEjemplaresDisponibles(List<int> codigosExcluidos);
        int CrearPrestamoCompleto(Prestamo prestamo, List<int> codigosEjemplares);
        bool PuedeRealizarPrestamo(string dni);
    }
}
