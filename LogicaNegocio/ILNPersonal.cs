using System;
using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNPersonal
    {
        Personal Personal { get; }
        
        void AltaUsuario(Usuario usuario);
        void BajaUsuario(Usuario usuario);
        Usuario GetUsuario(string dni);
        List<Usuario> GetUsuariosActivos();
        List<Usuario> GetTodosUsuarios();
        List<Ejemplar> GetEjemplaresPrestadosPorUsuario(string dni);
        bool UsuarioTieneDocumentosFueraDePlazo(string dni);
    }
}
