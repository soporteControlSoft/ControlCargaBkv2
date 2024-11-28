using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IListadoClientesEncabezado
    {


        //consulta del listado de clientes encabezado por id visita
        public Task<List<MdloDtos.VwListadoClientesEncabezado>> ListarClientesEncabezado(int IdVisita);

        //Actualizar tablas relacionadas al listado de clientes Encabezado
        public Task<bool> EditarEncabezadoClientes(MdloDtos.VwListadoClientesEncabezado _VwListadoClientesEncabezado);

  
    }
}
