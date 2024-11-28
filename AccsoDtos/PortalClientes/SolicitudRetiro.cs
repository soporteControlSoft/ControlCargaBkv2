using AccsoDtos.Parametrizacion;
using AccsoDtos.SituacionPortuaria;
using AccsoDtos.VisitaMotonave;
using MdloDtos;
using MdloDtos.IModelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccsoDtos.PortalClientes
{
    public class SolicitudRetiro:MdloDtos.IModelos.ISolicitudRetiros
    {
        //consultar productos para filtrar y tener los depositos
        public async Task<List<WvConsultaDepositosSubdeposito>> ConsultarDepositoProducto(int idvisita,string CodigoProducto)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {

                var lst = await (from p in _dbContex.WvConsultaDepositosSubdepositos
                                 where (p.IdVisita == idvisita) && (p.CodigoProducto == CodigoProducto)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }


        //consultar solicitud de retiros para tener retiros.
        public async Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiro()
        {

            using (CcVenturaContext _dbContex = new CcVenturaContext()) { 
        
                var lst = await (from p in _dbContex.WmDepositosSolicitudRetiros
                               
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }


        //consultar solicitud de retiros para tener visita , producto.
        public async Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiroxProductoVisita(int idvisita, string CodigoProducto)
        {

          using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.WmDepositosSolicitudRetiros
                                 where (p.IdVisita == idvisita) && (p.CodigoProducto == CodigoProducto)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        //consultar solicitud de retiros para tener deposito.

        public async Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiroDeposito(int Deposito, int idvisita, string CodigoProducto,int? SolicitidRetiro)
        {

            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.WmDepositosSolicitudRetiros
                                 where ((p.IdDeposito == Deposito && p.IdVisita== idvisita && p.CodigoProducto== CodigoProducto) || (p.IdRetiro==SolicitidRetiro))
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        // ingreso de datos a la entidad solitcitud de retiros
        public async Task<MdloDtos.SolicitudRetiro> IngresarSolicitudRetiros(MdloDtos.SolicitudRetiro _SolicitudRetiro)
        {
            var ObjSolicitudRetiro = new MdloDtos.SolicitudRetiro();
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                try
                {
                    string? sr_cia = _SolicitudRetiro.SrCia;
                    string? sr_cdgo = _SolicitudRetiro.SrCdgo;
                    int? sr_rowid_dpsto = _SolicitudRetiro.SrRowidDpsto;
                    int? DeRowisr_rowid_cdaddTrcro = _SolicitudRetiro.SrRowidCdad;
                    string? sr_plnta_dstno = _SolicitudRetiro.SrPlntaDstno;
                    DateTime? sr_fcha_aprtra = _SolicitudRetiro.SrFchaAprtra;
                    int? sr_autrzdo_klos = _SolicitudRetiro.SrAutrzdoKlos;
                    int? sr_autrzdo_cntdad = _SolicitudRetiro.SrAutrzdoCntdad;
                    int? sr_dspchdo_klos = _SolicitudRetiro.SrDspchdoKlos;
                    int? sr_dspchdo_cntdad = _SolicitudRetiro.SrDspchdoCntdad;
                    bool? sr_actva = _SolicitudRetiro.SrActva;
                    bool? sr_entrga_sspndda = _SolicitudRetiro.SrEntrgaSspndda;
                    bool? sr_abrta = _SolicitudRetiro.SrAbrta;
                    string? sr_obsrvcnes = _SolicitudRetiro.SrObsrvcnes;
                    string? sr_cmpo_prsnlzdo1 = _SolicitudRetiro.SrCmpoPrsnlzdo1;
                    string? SrCmpoPrsnlzdo2 = _SolicitudRetiro.SrCmpoPrsnlzdo2;
                    string? SrCmpoPrsnlzdo3 = _SolicitudRetiro.SrCmpoPrsnlzdo3;
                    int? sr_rowid_zna_cd = _SolicitudRetiro.SrRowidZnaCd;
                    bool? sr_entrgar_pso_excto = _SolicitudRetiro.SrEntrgarPsoExcto;

   
                    var res = await _dbContex.Ingresar_SolicitudRetiro(sr_cia, sr_cdgo, sr_rowid_dpsto, DeRowisr_rowid_cdaddTrcro, sr_plnta_dstno, sr_fcha_aprtra,
                       sr_autrzdo_klos, sr_autrzdo_cntdad, sr_dspchdo_klos, sr_dspchdo_cntdad, sr_actva, sr_entrga_sspndda,
                       sr_abrta, sr_obsrvcnes, sr_cmpo_prsnlzdo1, SrCmpoPrsnlzdo2, SrCmpoPrsnlzdo3, sr_rowid_zna_cd, sr_entrgar_pso_excto);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSolicitudRetiro;

            }
        }

        
        
        
        
        
        
        //Cerrar Solicitud de Retiros.
        public async Task<int> CerrarSolicitudRetiro(int sr_rowid)
        {
          
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                int a = 0;
                try
                {
                     a = sr_rowid;
                    var res = await _dbContex.Cerrar_SolicitudRetiro(a);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return a;

            }
        }


        #region Ingresar solicitud de retiros autorizacion
        public async Task<MdloDtos.SolicitudRetiroAutorizacion> IngresarSolicitudRetirosAutorizacion(MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion)
        {
            var ObjSolicituAutorizacion = new MdloDtos.SolicitudRetiroAutorizacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    ObjSolicituAutorizacion.SraRowidSlctudRtro = _SolicitudAutorizacion.SraRowidSlctudRtro;
                    ObjSolicituAutorizacion.SraRowidTrnsprtdra = _SolicitudAutorizacion.SraRowidTrnsprtdra;
                    ObjSolicituAutorizacion.SraAutrzdoKlos = _SolicitudAutorizacion.SraAutrzdoKlos;
                    ObjSolicituAutorizacion.SraAutrzdoUnddes = _SolicitudAutorizacion.SraAutrzdoUnddes;
                    ObjSolicituAutorizacion.SraFcha = _SolicitudAutorizacion.SraFcha;
                    ObjSolicituAutorizacion.SraCdgoUsrio = _SolicitudAutorizacion.SraCdgoUsrio;
                    var res = await _dbContex.SolicitudRetiroAutorizacions.AddAsync(ObjSolicituAutorizacion);
                    await _dbContex.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSolicituAutorizacion;
            }

        }
        #endregion

        #region Consultar solicitud de retiros autorizacion por ID retiros.
        public async Task<List<MdloDtos.SolicitudRetiroAutorizacion>> ConsultarSolicitudRetiroAutorizacionIdRetiro(int IdSolicitudRetiro)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
  
                var lst = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                 join r in _dbContex.SolicitudRetiros on p.SraRowidSlctudRtro equals r.SrRowid
                                 where (p.SraRowidSlctudRtro == IdSolicitudRetiro)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Ingresar solicitud de retiros autorizacion historial por ID retiros.
        public async Task<MdloDtos.SolicitudRetiroAutorizacionHistorial> IngresarSolicitudAutorizacionHistorial(MdloDtos.SolicitudRetiroAutorizacionHistorial _SolicitudRetiroAutorizacionHistorial)
        {
            var ObjSolicitudRetiroAutorizacionHistorial = new MdloDtos.SolicitudRetiroAutorizacionHistorial();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    ObjSolicitudRetiroAutorizacionHistorial.SrahRowidSlctudRtroAutrzcion = _SolicitudRetiroAutorizacionHistorial.SrahRowidSlctudRtroAutrzcion;
                    ObjSolicitudRetiroAutorizacionHistorial.SrahAutrzdoKlos = _SolicitudRetiroAutorizacionHistorial.SrahAutrzdoKlos;
                    ObjSolicitudRetiroAutorizacionHistorial.SrahAutrzdoUnddes = _SolicitudRetiroAutorizacionHistorial.SrahAutrzdoUnddes;
                    ObjSolicitudRetiroAutorizacionHistorial.SrahFcha = _SolicitudRetiroAutorizacionHistorial.SrahFcha;
                    ObjSolicitudRetiroAutorizacionHistorial.SraCdgoUsrio = _SolicitudRetiroAutorizacionHistorial.SraCdgoUsrio;
                
                        var res = await _dbContex.SolicitudRetiroAutorizacionHistorials.AddAsync(ObjSolicitudRetiroAutorizacionHistorial);
                        await _dbContex.SaveChangesAsync();

                    


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSolicitudRetiroAutorizacionHistorial;
            }

        }
        #endregion

        #region Consultar solicitud de retiros autorizacion Historial por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroAutorizacionHistorial>> ConsultarSolicitudRetiroAutorizacionHistorialIdRetiro(int IdSolicitudRetiroAutorizacion)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.SolicitudRetiroAutorizacionHistorials
                                 where (p.SrahRowidSlctudRtroAutrzcion == IdSolicitudRetiroAutorizacion)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region ingresar solicitud de retiros Transportadora 
        public async Task<MdloDtos.SolicitudRetiroTransportadora> IngresarSolicitudRetiroTrasnportadora(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
            var ObjPSolicitudRetiroTransportadora = new MdloDtos.SolicitudRetiroTransportadora();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    ObjPSolicitudRetiroTransportadora.SrtRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                    ObjPSolicitudRetiroTransportadora.SrtRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                    ObjPSolicitudRetiroTransportadora.SrtAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                    ObjPSolicitudRetiroTransportadora.SrtDspchdoKlos = _SolicitudRetiroTransportadora.SrtDspchdoKlos;
                    ObjPSolicitudRetiroTransportadora.SrtAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                    ObjPSolicitudRetiroTransportadora.SrtDspchdoUnddes = _SolicitudRetiroTransportadora.SrtDspchdoUnddes;
                    ObjPSolicitudRetiroTransportadora.SrtActva = _SolicitudRetiroTransportadora.SrtActva;

                    var res = await _dbContex.SolicitudRetiroTransportadoras.AddAsync(ObjPSolicitudRetiroTransportadora);
                        await _dbContex.SaveChangesAsync();

                    


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjPSolicitudRetiroTransportadora;
            }

        }
        #endregion

        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroTrasnportadoraIdRetiro(int IdSolicitudRetiroTrasnportadora)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                 where (p.SrtRowidSlctudRtro == IdSolicitudRetiroTrasnportadora)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Ingresar solicitud de retiros autorizacion trasnportadora historial
        public async Task<MdloDtos.SolicitudRetiroTransportadoraHistorial> IngresarSolicitudRetirosTrasnsportadoraHistorico(MdloDtos.SolicitudRetiroTransportadoraHistorial _SolicitudRetiroTransportadoraHistoriall)
        {
            var tr = new MdloDtos.SolicitudRetiroTransportadoraHistorial();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    tr.SrthFcha = _SolicitudRetiroTransportadoraHistoriall.SrthFcha;
                    tr.SrthRowidSlctudRtroTrnsprtdra = _SolicitudRetiroTransportadoraHistoriall.SrthRowidSlctudRtroTrnsprtdra;
                    tr.SrthAutrzdoKlos = _SolicitudRetiroTransportadoraHistoriall.SrthAutrzdoKlos;
                    tr.SrthAutrzdoUnddes = _SolicitudRetiroTransportadoraHistoriall.SrthAutrzdoUnddes;
                    var res = await _dbContex.SolicitudRetiroTransportadoraHistorials.AddAsync(tr);
                        await _dbContex.SaveChangesAsync();

                    


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return tr;
            }

        }
        #endregion

        #region Consultar solicitud de retiros Trasnportadora Historial por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroTransportadoraHistorial>> ConsultarSolicitudRetiroTrasnportadoraHistorialIdRetiro(int IdSolicitudRetiroTrasnportadora)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.SolicitudRetiroTransportadoraHistorials
                                 where (p.SrthRowidSlctudRtroTrnsprtdra == IdSolicitudRetiroTrasnportadora)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

    }
}
