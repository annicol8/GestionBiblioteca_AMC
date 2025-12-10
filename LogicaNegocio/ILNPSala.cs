using System;
using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPSala : ILNPersonal
    {
        int AltaPrestamo(Prestamo prestamo);
        Prestamo GetPrestamo(int idPrestamo);
        Usuario GetUsuarioPrestamo(int idPrestamo);
        EstadoPrestamo GetEstadoPrestamo(int idPrestamo);
        List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo);
        List<Prestamo> GetPrestamosPorDocumento(string isbn);
        List<Prestamo> GetPrestamosPorUsuario(string dni);
        void DevolverEjemplar(int idPrestamo, string codigoEjemplar);
        List<Prestamo> GetPrestamosFueraDePlazo();
        bool HayEjemplaresDisponibles(string isbn);
        DateTime? GetFechaDisponibilidadDocumento(string isbn);
    }
}
