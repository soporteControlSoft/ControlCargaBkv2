using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPuertoOrigen
    {
        public Task<List<MdloDtos.PuertoOrigen>> ListarPuertoOrigen();

        public Task<List<MdloDtos.PuertoOrigen>> FiltrarPuertoOrigenGeneral(String Codigo);

        public Task<List<MdloDtos.PuertoOrigen>> FiltrarPuertoOrigenEspecifico(String Codigo);

        public Task<MdloDtos.PuertoOrigen> IngresarPuertoOrigen(MdloDtos.PuertoOrigen ObjPuertoOrigen);

        public Task<MdloDtos.PuertoOrigen> EditarPuertoOrigen(MdloDtos.PuertoOrigen ObjPuertoOrigen);

        public Task<MdloDtos.PuertoOrigen> EliminarPuertoOrigen(String Codigo);
    }
}
