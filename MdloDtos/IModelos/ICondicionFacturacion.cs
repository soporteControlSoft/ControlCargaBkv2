using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICondicionFacturacion
    {
        public Task<List<MdloDtos.DTO.CondicionFacturacionDTO>> ListarCondicionFacturacion();

        public Task<List<MdloDtos.DTO.CondicionFacturacionDTO>> FiltrarCondicionFacturacionGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.CondicionFacturacionDTO>> FiltrarCondicionFacturacionEspecifico(String Codigo);

        public Task<dynamic> IngresarCondicionFacturacion(MdloDtos.DTO.CondicionFacturacionDTO ObjCondicionFacturacion);

        public Task<MdloDtos.DTO.CondicionFacturacionDTO> EditarCondicionFacturacion(MdloDtos.DTO.CondicionFacturacionDTO ObjCondicionFacturacion);

        public Task<dynamic> EliminarCondicionFacturacion(String Codigo);
    }
}
