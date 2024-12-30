using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdloDtos.DTO;

namespace MdloDtos.IModelos
{
    public interface IConsecutivo
    {
        //Consultar toda la tabla
        public Task<List<ConsecutivoDTO>> ConsultarConsecutivo();

        //ingresar consecutivos
        public Task<dynamic> IngresarConsecutivo(ConsecutivoDTO ObjConsecutivo);

        //Actualizar consecutivos
        public Task<dynamic> EditarConsecutivo(ConsecutivoDTO ObjConsecutivo);

        //Eliminar un consecutivo.
        public Task<dynamic> EliminarConsecutivo(Int32 Id);

        //Filtrar un consecutivo por el codigo de la compañia
         public Task<List<ConsecutivoDTO>> FiltrarConsecutivoPorCompania(string CodigoCompania);

        //Filtrar consectivo por el ID
        public Task<List<ConsecutivoDTO>> FiltrarConsecutivoId(Int32 Id);

    }
}
