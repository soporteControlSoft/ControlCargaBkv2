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

        public Task<List<MdloDtos.DTO.VisitaMotonaveBlDTO>> FiltrarVisitaMotonaveBlCrearDeposito(int IdVisitaMotonave, string codigoUsuario, string codigoProducto);
        
        public Task<dynamic> IngresarDeposito(MdloDtos.DTO.DepositoDTO _Deposito);

        //Aprobacion Depositos
        public Task<List<MdloDtos.DTO.VwMdloDpstoAprbcionLstarClntesPorVstaMtnveDTO>> ConsultarClientesPorVisitaMotonave(int IdVisitaMotonave);

        public Task<List<MdloDtos.DTO.DepositoDTO>> FiltrarDepositosPendienteAprobacion(int IdVisitaMotonave, int? idCliente);

        public Task<List<MdloDtos.Mensaje>> IngresarComentario(int Codigo, string codigoUsuario, string comentario);

        public Task<List<MdloDtos.Mensaje>> ConsultarComentario(int CodigoDeposito);

        //public Task<bool> AprobacionDeposito(MdloDtos.Deposito objDeposito);

        public Task<List<MdloDtos.DTO.SpDtlleDpstoAprbcionDTO>> ListarDetalleDepositoAprobacion(int rowIdDeposito);

        public Task<bool> AprobacionDeposito(MdloDtos.DTO.SpDpstoAprbcionDTO objDpstoAprbcion);

        public Task<bool> RechazarDeposito(MdloDtos.DTO.SpDpstoRchzoDTO objDpstoRchzon);

        public Task<List<MdloDtos.Mensaje>> IngresarObservacion(int CodigoDeposito, string codigoUsuario, string observaciones);

        public Task<List<MdloDtos.Mensaje>> ConsultarObservaciones(int CodigoDeposito);

        public Task<List<int>> CantidadCopiasImpresion();

        public Task<List<MdloDtos.DTO.ProductoDTO>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave, int? idCliente);

        public Task<List<MdloDtos.DTO.SpDtlleDpstoAprbcionDTO>> IngresarDepositoColaboradorInterno(MdloDtos.DTO.DepositoDTO _Deposito);

        public Task<List<MdloDtos.DTO.SpDepositoDTO>> ListarDepositosAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia);

        public Task<List<MdloDtos.DTO.SpDepositoDetalleDTO>> ListarDepositosDetalleAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia, bool estadoDeposito);

        public Task<List<MdloDtos.DTO.SpSubDepositoDTO>> ListarSubDepositosAdministracion(string cdgoDpstoPdre);

        public Task<MdloDtos.DTO.DepositoDTO> ListarDetalleDepositoAdministracion(int rowIdDeposito);

        public Task<dynamic> ActualizarDeposito(MdloDtos.DTO.DepositoDTO DepositoInput);

        public Task<MdloDtos.DTO.DepositoDTO> ListarDetalleDepositoFacturacion(int rowIdDeposito);

        public Task<dynamic> ActualizarCondicionesFacturacion(MdloDtos.DTO.DepositoDTO _Deposito);

        public Task<MdloDtos.DTO.DepositoDTO> ProcesarValoresCif(int rowIdDeposito);

        public Task<List<MdloDtos.SpInvntrioBdgaDpsto>> InventarioBodega(int rowIdDeposito);

        public Task<MdloDtos.DTO.DepositoDTO> CerrarDeposito(int rowIdDeposito);

    }
        
}
