using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IConfiguracionVehicular
    {
        public Task<List<MdloDtos.ConfiguracionVehicular>> ListarConfiguracionVehicular();

        public Task<List<MdloDtos.ConfiguracionVehicular>> FiltrarConfiguracionVehicularGeneral(String Codigo);

        public Task<List<MdloDtos.ConfiguracionVehicular>> FiltrarConfiguracionVehicularEspecifico(String Codigo);

        public Task<MdloDtos.ConfiguracionVehicular> IngresarConfiguracionVehicular(MdloDtos.ConfiguracionVehicular ObjConfiguracionVehicular);

        public Task<MdloDtos.ConfiguracionVehicular> EditarConfiguracionVehicular(MdloDtos.ConfiguracionVehicular ObjConfiguracionVehicular);

        public Task<MdloDtos.ConfiguracionVehicular> EliminarConfiguracionVehicular(int Codigo);
    }
}
