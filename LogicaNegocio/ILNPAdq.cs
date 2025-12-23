using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPAdq: ILNPersonal
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


    }
}
