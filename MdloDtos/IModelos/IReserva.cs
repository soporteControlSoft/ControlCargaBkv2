using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IReserva
    {
        public Task<List<MdloDtos.VwMdloRsrvaLstarVstaMtnve>> ConsultarVisitaMotonave(String codigoCompania);

        public Task<List<MdloDtos.VwMdloRsrvaLstarDpsto>> ConsultarDeposito(int idVisitaMotonave);

        public Task<List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>> ConsultarSolicitudRetiroModal(int idDeposito, int idTransportadora);

        public  Task<List<MdloDtos.SpMdloRsrvaDtlleSlctudRtro>> ListarDetalleSolicitudRetiro(int IdSolicitudRetiro, int idTransportadora);

        public Task<List<MdloDtos.SpMdloRsrvaDtlleOrden>> ListarDetalleOrden(int cdgoOrden);

        public Task<bool> VerificarSolicitudRetiro(int IdSolicitudRetiro);

        public Task<bool> VerificarOrden(int CodigoOrden);

        public Task<dynamic> RegistrarOrden(MdloDtos.Orden orden);

        public Task<int> ConsultarOrdenEspecifica(int IdTransportadora, DateTime FechaReserva, DateTime FechaRegistroReserva, String Placa, String Manifiesto);

        public Task<List<MdloDtos.Mensaje>> IngresarObservacion(int CodigoOrden, string CodigoUsuario, string Observacion);

        public Task<List<MdloDtos.Mensaje>> ConsultarObservaciones(int CodigoOrden);

    }
}
