using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IConfiguracionVehicular
    {
        public Task<List<MdloDtos.DTO.ConfiguracionVehicularDTO>> ListarConfiguracionVehicular();

        public Task<List<MdloDtos.DTO.ConfiguracionVehicularDTO>> FiltrarConfiguracionVehicularGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.ConfiguracionVehicularDTO>> FiltrarConfiguracionVehicularEspecifico(String Codigo);

        public Task<dynamic> IngresarConfiguracionVehicular(MdloDtos.DTO.ConfiguracionVehicularDTO ObjConfiguracionVehicular);

        public Task<MdloDtos.DTO.ConfiguracionVehicularDTO> EditarConfiguracionVehicular(MdloDtos.DTO.ConfiguracionVehicularDTO ObjConfiguracionVehicular);

        public Task<dynamic> EliminarConfiguracionVehicular(int Codigo);
    }
}
