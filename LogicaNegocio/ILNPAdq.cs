using System;
using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPAdq : ILNPSala
    {
        void AltaLibroPapel(LibroPapel libro);
        void AltaAudioLibro(AudioLibro audioLibro);
        void BajaLibroPapel(LibroPapel libro);
        void BajaAudioLibro(AudioLibro audioLibro);
        LibroPapel GetLibroPapel(string isbn);
        AudioLibro GetAudioLibro(string isbn);
        List<Documento> GetTodosDocumentos();
        
        void AltaEjemplar(Ejemplar ejemplar);
        void BajaEjemplar(Ejemplar ejemplar);
        Ejemplar GetEjemplar(string codigo);
        List<Ejemplar> GetEjemplaresPorDocumento(string isbn);
        List<Ejemplar> GetEjemplaresActivos();
        
        Documento GetDocumentoMasLeidoUltimoMes();
    }
}
