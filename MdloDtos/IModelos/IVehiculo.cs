using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IVehiculo
    {
        public Task<MdloDtos.Vehiculo> IngresarVehiculo(MdloDtos.Vehiculo _Vehiculo);

        public Task<List<MdloDtos.Vehiculo>> ListarVehiculo();

        public Task<MdloDtos.Vehiculo> EditarVehiculo(MdloDtos.Vehiculo _Vehiculo);

        public Task<List<MdloDtos.Vehiculo>> FiltrarVehiculoEspecifico(String Codigo);

        public Task<List<MdloDtos.Vehiculo>> FiltrarVehiculoGeneral(String Codigo);

        public Task<MdloDtos.Vehiculo> EliminarVehiculo(string Codigo);
    }
}
