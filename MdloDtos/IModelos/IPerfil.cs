using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPerfil
    {
        public Task<List<MdloDtos.Perfil>> ListarPerfil();
        public Task<List<MdloDtos.Perfil>> FiltrarPerfilCodigoGeneral(String Codigo);
        public Task<List<MdloDtos.Perfil>> FiltrarPerfilEspecifico(String Codigo);
        public Task<MdloDtos.Perfil> IngresarPerfil(MdloDtos.Perfil ObjPerfil);
        public Task<MdloDtos.Perfil> EditarPerfil(MdloDtos.Perfil ObjPerfil);
        public Task<MdloDtos.Perfil> EliminarPerfil(String Codigo);
    }
}
