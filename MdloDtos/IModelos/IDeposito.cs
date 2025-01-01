using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IDeposito
    {
        public Task<List<MdloDtos.VwMdloDpstoLstarPrdctoPorVstaMtnve>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave);
        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlCrearDeposito(int IdVisitaMotonave, string codigoUsuario, string codigoProducto);
        public Task<MdloDtos.Deposito> IngresarDeposito(MdloDtos.Deposito _Deposito);

        //Aprobacion Depositos
        public Task<List<MdloDtos.VwMdloDpstoAprbcionLstarClntesPorVstaMtnve>> ConsultarClientesPorVisitaMotonave(int IdVisitaMotonave);

        public Task<List<MdloDtos.Deposito>> FiltrarDepositosPendienteAprobacion(int IdVisitaMotonave, int? idCliente);

        public Task<List<MdloDtos.Mensaje>> IngresarComentario(int Codigo, string codigoUsuario, string comentario);

        public Task<List<MdloDtos.Mensaje>> ConsultarComentario(int CodigoDeposito);

        //public Task<bool> AprobacionDeposito(MdloDtos.Deposito objDeposito);

        public Task<List<MdloDtos.SpDtlleDpstoAprbcion>> ListarDetalleDepositoAprobacion(int rowIdDeposito);

        public Task<bool> AprobacionDeposito(MdloDtos.SpDpstoAprbcion objDpstoAprbcion);

        public Task<bool> RechazarDeposito(MdloDtos.SpDpstoRchzo objDpstoRchzon);

        public Task<List<MdloDtos.Mensaje>> IngresarObservacion(int CodigoDeposito, string codigoUsuario, string observaciones);

        public Task<List<MdloDtos.Mensaje>> ConsultarObservaciones(int CodigoDeposito);

        public Task<List<int>> CantidadCopiasImpresion();

        public Task<List<MdloDtos.Producto>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave, int? idCliente);

        public Task<List<MdloDtos.SpDtlleDpstoAprbcion>> IngresarDepositoColaboradorInterno(MdloDtos.Deposito _Deposito);

        public Task<List<MdloDtos.SpDeposito>> ListarDepositosAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia);

        public Task<List<MdloDtos.SpDepositoDetalle>> ListarDepositosDetalleAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia, bool estadoDeposito);

        public Task<List<MdloDtos.SpSubDeposito>> ListarSubDepositosAdministracion(string cdgoDpstoPdre);

        public Task<MdloDtos.Deposito> ListarDetalleDepositoAdministracion(int rowIdDeposito);

        public Task<MdloDtos.Deposito> ActualizarDeposito(MdloDtos.Deposito DepositoInput);

        public Task<MdloDtos.Deposito> ListarDetalleDepositoFacturacion(int rowIdDeposito);

        public Task<MdloDtos.Deposito> ActualizarCondicionesFacturacion(MdloDtos.Deposito _Deposito);

        public Task<MdloDtos.Deposito> ProcesarValoresCif(int rowIdDeposito);

        public Task<List<MdloDtos.SpInvntrioBdgaDpsto>> InventarioBodega(int rowIdDeposito);

        public Task<MdloDtos.Deposito> CerrarDeposito(int rowIdDeposito);

    }
        
}
