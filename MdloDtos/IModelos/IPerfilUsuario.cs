using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPerfilUsuario
    {

        public Task<MdloDtos.PerfilUsuario> IngresarPerfilUsuario(List<MdloDtos.PerfilUsuario> ObjPerfilUsuario);

        //public Task<MdloDtos.PerfilUsuario> EditarPerfilUsuario(List<MdloDtos.PerfilUsuario> _PerfilUsuario);

       // public  Task<bool> EliminarPerfilUsuario(string codigoCompania, string codigoPerfil, string codigoUsuario);

        public Task<List<MdloDtos.PerfilUsuario>> FiltrarPerfilUsuarioPorUsuario(String Codigo);

        public Task<List<string>> FiltrarPerfilUsuarioPorCompania(string Codigo);

        public Task<List<MdloDtos.PerfilUsuario>> FiltrarPerfilUsuarioPorPerfil(string Codigo);

        public Task<List<MdloDtos.PerfilUsuario>> ListarPerfilUsuario();

    }
}
