using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IProducto
    {
        public Task<List<MdloDtos.Producto>> ListarProducto();

        public Task<List<MdloDtos.Producto>> FiltrarProductoGeneral(String Codigo);
        public Task<List<MdloDtos.Producto>> FiltrarProductoEspecifico(String Codigo);

        public Task<MdloDtos.Producto> IngresarProducto (MdloDtos.Producto ObjProducto);   

        public Task<MdloDtos.Producto> EditarProducto(MdloDtos.Producto ObjProducto);

        public Task<MdloDtos.Producto> EliminarProducto(String codigo);

    }
}
