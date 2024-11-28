using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISolicitudRetiros
    {
        public Task<List<WvConsultaDepositosSubdeposito>> ConsultarDepositoProducto(int idvisita, string CodigoProducto);
        public Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiro();

        public  Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiroDeposito(int Deposito, int idvisita, string CodigoProducto, int? SolicitidRetiro);

        public Task<MdloDtos.SolicitudRetiro> IngresarSolicitudRetiros(MdloDtos.SolicitudRetiro _SolicitudRetiro);




        public Task<int> CerrarSolicitudRetiro(int sr_rowid);

        public Task<MdloDtos.SolicitudRetiroAutorizacion> IngresarSolicitudRetirosAutorizacion(MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion);

        public Task<List<MdloDtos.SolicitudRetiroAutorizacion>> ConsultarSolicitudRetiroAutorizacionIdRetiro(int IdSolicitudRetiro);

        public  Task<MdloDtos.SolicitudRetiroAutorizacionHistorial> IngresarSolicitudAutorizacionHistorial(MdloDtos.SolicitudRetiroAutorizacionHistorial _SolicitudRetiroAutorizacionHistorial);

        public  Task<List<MdloDtos.SolicitudRetiroAutorizacionHistorial>> ConsultarSolicitudRetiroAutorizacionHistorialIdRetiro(int IdSolicitudRetiroAutorizacion);

        public  Task<MdloDtos.SolicitudRetiroTransportadora> IngresarSolicitudRetiroTrasnportadora(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora);

        public  Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroTrasnportadoraIdRetiro(int IdSolicitudRetiroTrasnportadora);

        public  Task<MdloDtos.SolicitudRetiroTransportadoraHistorial> IngresarSolicitudRetirosTrasnsportadoraHistorico(MdloDtos.SolicitudRetiroTransportadoraHistorial _SolicitudRetiroTransportadoraHistorial);

        public  Task<List<MdloDtos.SolicitudRetiroTransportadoraHistorial>> ConsultarSolicitudRetiroTrasnportadoraHistorialIdRetiro(int IdSolicitudRetiroTrasnportadora);


    }
}
