using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IVehiculo
    {
        public Task<dynamic> IngresarVehiculo(MdloDtos.DTO.VehiculoDTO _Vehiculo);

        public Task<List<MdloDtos.DTO.VehiculoDTO>> ListarVehiculo();

        public Task<MdloDtos.DTO.VehiculoDTO> EditarVehiculo(MdloDtos.DTO.VehiculoDTO _Vehiculo);

        public Task<List<MdloDtos.DTO.VehiculoDTO>> FiltrarVehiculoEspecifico(String Codigo);

        public Task<List<MdloDtos.DTO.VehiculoDTO>> FiltrarVehiculoGeneral(String Codigo);

        public Task<dynamic> EliminarVehiculo(string Codigo);
    }
}
