using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IListadoClientesDetalle
    {
        
        //consulta del listado de clientes Detalle por id visita
        public Task<List<MdloDtos.VwListadoClientesDetalle>> ListarClientesDetalle(int IdVisita);

        //Listar Escotillas de la motonave
        public Task<List<string>> ListarMotonaveEscotillas(int IdVisita);

        //Actualizar tablas relacionadas al listado de clientes detalle
        public Task<bool> EditarDetalleClientes(MdloDtos.VwListadoClientesDetalle _VwListadoClientesDetalle);


        //consulta del listado de clientes Detalle por id visita (Resumen)
        public Task<List<MdloDtos.VwResumenListadoCliente>> ListarClientesResumen(int IdVisita);

        //consulta del listado de clientes Grafico Torta por id visita
        public Task<List<MdloDtos.WmGraficoListadoCliente>> ListarClientesGrafico(int IdVisita);

        //consulta del listado de clientes Grafico Barco por id visita
        public Task<List<MdloDtos.BarcoListadoCliente>> ListarClientesBarco(int IdVisita);
    }
}
