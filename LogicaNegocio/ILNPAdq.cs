using System;
using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPAdq : ILNPersonal
    {

        bool AltaLibroPapel(LibroPapel libro);

        bool AltaAudioLibro(AudioLibro audioLibro);

        bool BajaDocumento(string isbn);

        Documento getDocumento(string isbn);

        bool AltaEjemplar(int codigo, string isbnDocumento);

        bool BajaEjemplar(int codigo);

        Ejemplar GetEjemplar(int codigo);

        bool EstaPrestadoEjemplar(int codigo);

        bool HayEjemplaresDisponibles(string isbn);

        string GetDocumentoMasPrestadoUltimoMes();

        List<Documento> getDocumentos();

        List<Ejemplar> ejemplaresPorDocumento(string isbn);

        DateTime? GetFechaProximaDisponibilidad(string isbn);

    }
}
