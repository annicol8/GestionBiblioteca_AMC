using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPersonal
    {
        Personal Personal { get; }

        //USUARIOS
        void AltaUsuario(Usuario usuario);
        void ModificarUsuario(Usuario usuario);
        void BajaUsuario(Usuario usuario);
        Usuario GetUsuario(string dni);
        List<Usuario> GetUsuariosActivos();
        List<Usuario> GetTodosUsuarios();
        List<Ejemplar> GetEjemplaresPrestadosPorUsuario(string dni);
        bool TieneDocumentosFueraPlazo(string dniUsuario);

        List<Prestamo> GetPrestamosPorUsuario(string dni);

        int GetNumPrestamosActivosPorUsuario(string dni);
        int GetNumEjemplaresUltimoMes(string dni);

        int GetNumPrestamosVencidos(string dni);
        Personal GetPersonal(string dni);
    }
}
