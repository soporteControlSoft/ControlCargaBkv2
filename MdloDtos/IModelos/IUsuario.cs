using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IUsuario
    {
        public Task<List<MdloDtos.Usuario>> ListarUsuario();

        public Task<List<MdloDtos.Usuario>> FiltrarUsuarioGeneral(String Codigo); 

        public Task<List<MdloDtos.Usuario>> FiltrarUsuarioEspecifico(String Codigo);


        public Task<MdloDtos.Usuario> IngresarUsuario(MdloDtos.Usuario ObjUsuario);

        public Task<MdloDtos.Usuario> EditarUsuario(MdloDtos.Usuario ObjUsuario);

        public Task<MdloDtos.Usuario> EliminarUsuario(String Codigo);
    }
}
