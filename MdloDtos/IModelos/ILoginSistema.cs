using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ILoginSistema
    {
        public Task<int> ValidacionUsuario(string CompaniaCodigo, string UsuarioCodigo, string UsuarioClave);

        public Task<int> ValidacionUsuarioCodigoTemporal(string CompaniaCodigo, string UsuarioCodigo, string UsuarioClave);

        public Task<int> ActualizarUsuarioClave(MdloDtos.AutenticacionUsuario ObjautenticacionUsuario);

        public List<MdloDtos.PerfilUsuario> ObtenerPerfilPorUsuario(string CodigoCompania, string CodigoUsuario);

        public List<string> ObtenerPermisosPousuario(string CompaniaCodigo, string UsuarioCodigo, string CodigoPerfil);

        public  List<MdloDtos.Companium>  FiltrarCompaniaEspecifico(string Codigo);

        public List<MdloDtos.Usuario> FiltrarUsuarioEspecifico(string Codigo);

        public bool ValidarCorreoUsuario(string UsEmail, string UsCdgo);

        public bool enviarCorreo(string UsuarioCodigo);
        public bool ValidarCodigoEnviadoCorreo(string Codigo, string UsuarioCodigo);

        public bool NecesitaDobleAututentificacion(string UsuarioCodigo);

        public bool enviarCorreoConCodigo(string UsuarioCodigo);

        //public List<MdloDtos.RutaAccion> ObtenerRutasAccionesPorUsuario(string CompaniaCodigo, string UsuarioCodigo, string CodigoPerfil);

        public string ObtenerRutasAccionesPorUsuario(string CompaniaCodigo, string UsuarioCodigo, string CodigoPerfil);

    }
}
