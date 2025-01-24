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

        public  Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiroDeposito(int? Deposito, int idvisita, string CodigoProducto, int? SolicitidRetiro);

        public Task<MdloDtos.SolicitudRetiro> IngresarSolicitudRetiros(MdloDtos.SolicitudRetiro _SolicitudRetiro);


        public Task<dynamic> EditarSolicitudRetiro(MdloDtos.SolicitudRetiro _SolicitudRetiro);

        public Task<int> CerrarSolicitudRetiro(int sr_rowid);

        public Task<dynamic> IngresarSolicitudRetirosAutorizacionCerrada(MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion);

        public Task<dynamic> IngresarSolicitudRetirosAutorizacionAbierta(MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion);


        public Task<List<MdloDtos.SolicitudRetiroAutorizacion>> ConsultarSolicitudRetiroAutorizacionIdRetiro(int IdSolicitudRetiro);

        public  Task<MdloDtos.SolicitudRetiroAutorizacionHistorial> IngresarSolicitudAutorizacionHistorial(MdloDtos.SolicitudRetiroAutorizacionHistorial _SolicitudRetiroAutorizacionHistorial);

        public  Task<List<MdloDtos.SolicitudRetiroAutorizacion>> ConsultarSolicitudRetiroAutorizacionIdRetiroAutorizacion(int IdSolicitudRetiroAutorizacion);

        public  Task<MdloDtos.SolicitudRetiroTransportadora> IngresarSolicitudRetiroTrasnportadora(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora);

        public  Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroTrasnportadoraIdRetiro(int IdSolicitudRetiroTrasnportadora);

        public  Task<MdloDtos.SolicitudRetiroTransportadoraHistorial> IngresarSolicitudRetirosTrasnsportadoraHistorico(MdloDtos.SolicitudRetiroTransportadoraHistorial _SolicitudRetiroTransportadoraHistorial);

        public  Task<List<MdloDtos.SolicitudRetiroTransportadoraHistorial>> ConsultarSolicitudRetiroTrasnportadoraHistorialIdRetiro(int IdSolicitudRetiroTrasnportadora);
        public Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroIdRetiroTrasnportadora(int IdSolicitudRetiro);

        public Task<MdloDtos.SolicitudRetiroTransportadora> ActualizarSolicitudRetiroTrasnportadora(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora);


        //Version 2
        public Task<dynamic> IngresarTrasnportadoraCerrada(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora);

        public Task<dynamic> IngresarTrasnportadoraAbierta(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora);

    }
}
