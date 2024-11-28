using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IClasificacion
    {
        public Task<MdloDtos.Clasificacion> IngresarClasificacion(MdloDtos.Clasificacion ObjClasificacion);
        public Task<List<MdloDtos.Clasificacion>> ListarClasificacion(bool estado);

        public Task<MdloDtos.Clasificacion> EditarClasificacion(MdloDtos.Clasificacion ObjClasificacion);

        public Task<List<MdloDtos.Clasificacion>> FiltrarClasificacionGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.Clasificacion>> FiltrarClasificacionEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.Clasificacion> InactivarClasificacion(MdloDtos.Clasificacion ObjClasificacion);
        public Task<bool> VerificarClasificacion(int Codigo);

    }
}
