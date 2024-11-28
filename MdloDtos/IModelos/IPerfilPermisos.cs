using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPerfilPermisos
    {
       
        public Task<List<MdloDtos.PerfilPermiso>> ListarPerfilPermiso();

        public Task<MdloDtos.PerfilPermiso> IngresarPerfilPermisoCatalogo(MdloDtos.PerfilPermiso _PerfilPermiso);

        public Task<MdloDtos.PerfilPermiso> EditarPerfilPermisoCatalogo(MdloDtos.PerfilPermiso _PerfilPermiso);

        public Task<MdloDtos.PerfilPermiso> IngresarPerfilPermisoMenu(MdloDtos.PerfilPermiso _PerfilPermiso);

        public Task<MdloDtos.PerfilPermiso> EditarPerfilPermisoMenu(MdloDtos.PerfilPermiso _PerfilPermiso);

        public Task<bool> EliminarPerfilPermiso(String Codigo);
    }
}
