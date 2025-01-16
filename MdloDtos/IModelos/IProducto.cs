using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IProducto
    {
        public Task<List<MdloDtos.DTO.ProductoDTO>> ListarProducto();

        public Task<List<MdloDtos.DTO.ProductoDTO>> FiltrarProductoGeneral(String Codigo);
        public Task<List<MdloDtos.DTO.ProductoDTO>> FiltrarProductoEspecifico(String Codigo);

        public Task<MdloDtos.DTO.ProductoDTO> IngresarProducto (MdloDtos.DTO.ProductoDTO ObjProducto);   

        public Task<MdloDtos.DTO.ProductoDTO> EditarProducto(MdloDtos.DTO.ProductoDTO ObjProducto);

        public Task<dynamic> EliminarProducto(String codigo);

    }
}
