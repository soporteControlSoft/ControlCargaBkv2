using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IReserva
    {
        public Task<List<MdloDtos.DTO.VwMdloRsrvaLstarVstaMtnveDTO>> ConsultarVisitaMotonave(String codigoCompania);

        public Task<List<MdloDtos.DTO.VwMdloRsrvaLstarDpstoDTO>> ConsultarDeposito(int idVisitaMotonave);

        public Task<List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>> ConsultarSolicitudRetiroModal(int idDeposito, int idTransportadora);

        public  Task<List<MdloDtos.DTO.SpMdloRsrvaDtlleSlctudRtroDTO>> ListarDetalleSolicitudRetiro(int IdSolicitudRetiro, int idTransportadora);

        public Task<List<MdloDtos.DTO.SpMdloRsrvaDtlleOrdenDTO>> ListarDetalleOrden(int cdgoOrden);

        public Task<bool> VerificarSolicitudRetiro(int IdSolicitudRetiro);

        public Task<bool> VerificarOrden(int CodigoOrden);

        public Task<dynamic> RegistrarOrden(MdloDtos.DTO.OrdenDTO orden);

        public Task<int> ConsultarOrdenEspecifica(int IdTransportadora, DateTime FechaReserva, DateTime FechaRegistroReserva, String Placa, String Manifiesto);

        public Task<List<MdloDtos.Mensaje>> IngresarObservacion(int CodigoOrden, string CodigoUsuario, string Observacion);

        public Task<List<MdloDtos.Mensaje>> ConsultarObservaciones(int CodigoOrden);

    }
}
