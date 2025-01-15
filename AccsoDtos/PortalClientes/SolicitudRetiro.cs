using AccsoDtos.Auditoria;
using AccsoDtos.Parametrizacion;
using AccsoDtos.SituacionPortuaria;
using AccsoDtos.VisitaMotonave;
using MdloDtos;
using MdloDtos.IModelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiroDeposito(int? Deposito, int idvisita, string CodigoProducto,int? SolicitidRetiro)
        {

            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.WmDepositosSolicitudRetiros
                                 where ((p.IdVisita== idvisita && p.CodigoProducto== CodigoProducto)) || (((p.IdDeposito == Deposito) || (p.IdRetiro==SolicitidRetiro)))
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        #region ingreso de datos a la entidad solitcitud de retiros
        public async Task<MdloDtos.SolicitudRetiro> IngresarSolicitudRetiros(MdloDtos.SolicitudRetiro _SolicitudRetiro)
        {
            var ObjSolicitudRetiro = new MdloDtos.SolicitudRetiro();
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                try
                {
                    DateTime dat = DateTime.Today;
                    string? sr_cia = _SolicitudRetiro.SrCia;
                    string? sr_cdgo = "";
                    int? sr_rowid_dpsto = _SolicitudRetiro.SrRowidDpsto;
                    int? DeRowisr_rowid_cdaddTrcro = _SolicitudRetiro.SrRowidCdad;
                    string? sr_plnta_dstno = _SolicitudRetiro.SrPlntaDstno;
                    DateTime? sr_fcha_aprtra = dat;
                    int? sr_autrzdo_klos = _SolicitudRetiro.SrAutrzdoKlos;
                    int? sr_autrzdo_cntdad = _SolicitudRetiro.SrAutrzdoCntdad;
                    int? sr_dspchdo_klos = 0;
                    int? sr_dspchdo_cntdad = 0;
                    bool? sr_actva = _SolicitudRetiro.SrActva;
                    bool? sr_entrga_sspndda = false;
                    bool? sr_abrta = _SolicitudRetiro.SrAbrta;
                    string? sr_obsrvcnes = _SolicitudRetiro.SrObsrvcnes;
                    string? sr_cmpo_prsnlzdo1 = _SolicitudRetiro.SrCmpoPrsnlzdo1;
                    string? SrCmpoPrsnlzdo2 = _SolicitudRetiro.SrCmpoPrsnlzdo2;
                    string? SrCmpoPrsnlzdo3 = _SolicitudRetiro.SrCmpoPrsnlzdo3;
                    int? sr_rowid_zna_cd = _SolicitudRetiro.SrRowidZnaCd;
                    bool? sr_entrgar_pso_excto = false;

   
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

        #endregion
        #region Actualiza Solicitud de retiro ( abierta o cerrada)
        public async Task<MdloDtos.SolicitudRetiro> EditarSolicitudRetiro(MdloDtos.SolicitudRetiro _SolicitudRetiro)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudRetiro.SrRowid);
                    if (SolicitudRetiroExiste != null)
                    {
                        SolicitudRetiroExiste.SrCia = _SolicitudRetiro.SrCia;
                        SolicitudRetiroExiste.SrRowidDpsto = _SolicitudRetiro.SrRowidDpsto;
                        SolicitudRetiroExiste.SrRowidCdad = _SolicitudRetiro.SrRowidCdad;
                        SolicitudRetiroExiste.SrPlntaDstno = _SolicitudRetiro.SrPlntaDstno;
                        SolicitudRetiroExiste.SrAutrzdoKlos = _SolicitudRetiro.SrAutrzdoKlos;
                        SolicitudRetiroExiste.SrAutrzdoCntdad = _SolicitudRetiro.SrAutrzdoCntdad;
                        SolicitudRetiroExiste.SrDspchdoKlos = 0;
                        SolicitudRetiroExiste.SrDspchdoCntdad = 0;
                        SolicitudRetiroExiste.SrActva = _SolicitudRetiro.SrActva;
                        SolicitudRetiroExiste.SrAbrta = _SolicitudRetiro.SrAbrta;
                        SolicitudRetiroExiste.SrObsrvcnes = _SolicitudRetiro.SrObsrvcnes;
                        SolicitudRetiroExiste.SrCmpoPrsnlzdo1 = _SolicitudRetiro.SrCmpoPrsnlzdo1;
                        SolicitudRetiroExiste.SrCmpoPrsnlzdo2 = _SolicitudRetiro.SrCmpoPrsnlzdo2;
                        SolicitudRetiroExiste.SrCmpoPrsnlzdo3 = _SolicitudRetiro.SrCmpoPrsnlzdo3;
                        SolicitudRetiroExiste.SrRowidZnaCd = _SolicitudRetiro.SrRowidZnaCd;
                        _dbContex.SolicitudRetiros.Entry(SolicitudRetiroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return SolicitudRetiroExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion



        #region ingresar solicitud de retiros Transportadora version 1
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

                    var ObjSolicituAutorizacion = new MdloDtos.SolicitudRetiroAutorizacion();
                    ObjSolicituAutorizacion.SraRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                    ObjSolicituAutorizacion.SraRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                    ObjSolicituAutorizacion.SraAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                    ObjSolicituAutorizacion.SraAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                    ObjSolicituAutorizacion.SraFcha = System.DateTime.Now;
                    ObjSolicituAutorizacion.SraCdgoUsrio = "andres";
                    var prueba = IngresarSolicitudRetirosAutorizacion(ObjSolicituAutorizacion);

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


        #region ingresar solicitud de retiros Transportadora version 2 . cerrada.
        public async Task<MdloDtos.SolicitudRetiroTransportadora> IngresarTrasnportadoraCerrada(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
            var ObjPSolicitudRetiroTransportadora = new MdloDtos.SolicitudRetiroTransportadora();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudRetiroTransportadora.SrtRowidSlctudRtro);
                    int? kilos = SolicitudRetiroExiste.SrAutrzdoKlos;
                    int? unidades = SolicitudRetiroExiste.SrAutrzdoCntdad;

                    if ((  _SolicitudRetiroTransportadora.SrtAutrzdoKlos <= kilos) || (_SolicitudRetiroTransportadora.SrtAutrzdoUnddes <= unidades )) {

                        ObjPSolicitudRetiroTransportadora.SrtRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                        ObjPSolicitudRetiroTransportadora.SrtRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                        ObjPSolicitudRetiroTransportadora.SrtAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                        ObjPSolicitudRetiroTransportadora.SrtAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                        ObjPSolicitudRetiroTransportadora.SrtDspchdoKlos = 0;
                        ObjPSolicitudRetiroTransportadora.SrtDspchdoUnddes = 0;
                        ObjPSolicitudRetiroTransportadora.SrtActva = _SolicitudRetiroTransportadora.SrtActva;

                        await _dbContex.SolicitudRetiroTransportadoras.AddAsync(ObjPSolicitudRetiroTransportadora);
                        await _dbContex.SaveChangesAsync();

                        //actualizart la solicitud , re caulculando las cantidades y kilos. abierta
                        if (SolicitudRetiroExiste != null)
                        {
                            var lst = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                            where (p.SrtRowidSlctudRtro == ObjPSolicitudRetiroTransportadora.SrtRowidSlctudRtro) 
                                            select p).ToListAsync();
                            int? sumaKilos = 0;
                            int? sumaUnidades = 0;

                            foreach (var item in lst) {
                                if (lst.Count == 1)
                                {
                                    sumaKilos = ObjPSolicitudRetiroTransportadora.SrtAutrzdoKlos;
                                    sumaUnidades = ObjPSolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                                }
                                else {

                                    sumaKilos = item.SrtAutrzdoKlos + sumaKilos;
                                    sumaUnidades = item.SrtAutrzdoUnddes + sumaUnidades;

                                }

                             

                            }

                            SolicitudRetiroExiste.SrAutrzdoKlos = sumaKilos;
                            SolicitudRetiroExiste.SrAutrzdoCntdad = sumaUnidades;
                           
                            _dbContex.SolicitudRetiros.Entry(SolicitudRetiroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            await _dbContex.SaveChangesAsync();

                            //actualizar solicitud de autorizacion.
                            MdloDtos.SolicitudRetiroAutorizacion SolicitudAutorizacion_ = new MdloDtos.SolicitudRetiroAutorizacion();


                            var pr = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                                                       where (p.SraRowidSlctudRtro == ObjPSolicitudRetiroTransportadora.SrtRowidSlctudRtro)
                                                                       select p).ToListAsync();

                            SolicitudAutorizacion_.SraRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                            SolicitudAutorizacion_.SraAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                            SolicitudAutorizacion_.SraAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                            SolicitudAutorizacion_.SraFcha = System.DateTime.Now;
                            SolicitudAutorizacion_.SraCdgoUsrio = "100";
                            await _dbContex.SolicitudRetiroAutorizacions.AddAsync(SolicitudAutorizacion_);
                            await _dbContex.SaveChangesAsync();
                            /*
                            if (pr.Count > 0)
                            {
                                foreach (var item in pr)
                                {

                                    SolicitudAutorizacion_.SraRowid = item.SraRowid;
                                    SolicitudAutorizacion_.SraRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                                    SolicitudAutorizacion_.SraAutrzdoKlos = SolicitudRetiroExiste.SrAutrzdoKlos;
                                    SolicitudAutorizacion_.SraAutrzdoUnddes = SolicitudRetiroExiste.SrAutrzdoCntdad;
                                    SolicitudAutorizacion_.SraFcha = System.DateTime.Now;
                                    SolicitudAutorizacion_.SraCdgoUsrio = "100";
                                    _dbContex.SolicitudRetiroAutorizacions.Entry(SolicitudAutorizacion_).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    await _dbContex.SaveChangesAsync();
                                }
                            }
                            else {


                                SolicitudAutorizacion_.SraRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                                SolicitudAutorizacion_.SraAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                                SolicitudAutorizacion_.SraAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                                SolicitudAutorizacion_.SraFcha = System.DateTime.Now;
                                SolicitudAutorizacion_.SraCdgoUsrio = "100";
                                await _dbContex.SolicitudRetiroAutorizacions.AddAsync(SolicitudAutorizacion_);
                                await _dbContex.SaveChangesAsync();
                            }
                            */

                        }
                    }
                    
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

        #region ingresar solicitud de retiros Transportadora version 2 . abierta.
        public async Task<MdloDtos.SolicitudRetiroTransportadora> IngresarTrasnportadoraAbierta(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
            var ObPSolicitudTransportadora = new MdloDtos.SolicitudRetiroTransportadora();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudRetiroTransportadora.SrtRowidSlctudRtro);
                    int? kilos = SolicitudRetiroExiste.SrAutrzdoKlos;
                    int? unidades = SolicitudRetiroExiste.SrAutrzdoCntdad;


                    ObPSolicitudTransportadora.SrtRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                    ObPSolicitudTransportadora.SrtRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                    ObPSolicitudTransportadora.SrtAutrzdoKlos = kilos;
                    ObPSolicitudTransportadora.SrtAutrzdoUnddes = unidades;
                    ObPSolicitudTransportadora.SrtDspchdoKlos = 0;
                    ObPSolicitudTransportadora.SrtDspchdoUnddes = 0;
                    ObPSolicitudTransportadora.SrtActva = _SolicitudRetiroTransportadora.SrtActva;

                    var res = await _dbContex.SolicitudRetiroTransportadoras.AddAsync(ObPSolicitudTransportadora);
                    await _dbContex.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObPSolicitudTransportadora;
            }
        }
        #endregion

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
                    DateTime dat = DateTime.Today;
                    ObjSolicituAutorizacion.SraRowidSlctudRtro = _SolicitudAutorizacion.SraRowidSlctudRtro;
                    ObjSolicituAutorizacion.SraRowidTrnsprtdra = _SolicitudAutorizacion.SraRowidTrnsprtdra;
                    ObjSolicituAutorizacion.SraAutrzdoKlos = _SolicitudAutorizacion.SraAutrzdoKlos;
                    ObjSolicituAutorizacion.SraAutrzdoUnddes = _SolicitudAutorizacion.SraAutrzdoUnddes;
                    ObjSolicituAutorizacion.SraFcha = dat;
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
                List<MdloDtos.SolicitudRetiroAutorizacion> listadoSede = new List<MdloDtos.SolicitudRetiroAutorizacion>();

                var lst = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                 join r in _dbContex.SolicitudRetiros on p.SraRowidSlctudRtro equals r.SrRowid
                                 join s in _dbContex.Terceros on p.SraRowidTrnsprtdra equals s.TeRowid
                                 where (p.SraRowidSlctudRtro == IdSolicitudRetiro && s.TeTrnsprtdra == true)
                                 select new { 
                                 
                                     p.SraRowid,
                                     p.SraRowidSlctudRtro,
                                     p.SraRowidTrnsprtdra,
                                     p.SraAutrzdoKlos,
                                     p.SraAutrzdoUnddes,
                                     p.SraFcha,
                                     p.SraCdgoUsrio,
                                     s.TeNmbre
                                 
                                 }).ToListAsync();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.SolicitudRetiroAutorizacion objSolicitudRetiroAutorizacion = new MdloDtos.SolicitudRetiroAutorizacion(
                                                                //Atributos Sede
                                                                item.SraRowid != null ? item.SraRowid : 0,
                                                                item.SraRowidSlctudRtro != null ? item.SraRowidSlctudRtro : 0,
                                                                item.SraRowidTrnsprtdra != null ? item.SraRowidTrnsprtdra : 0,
                                                                item.SraAutrzdoKlos != null ? item.SraAutrzdoKlos : 0,
                                                                item.SraAutrzdoUnddes != null ? item.SraAutrzdoUnddes : 0,
                                                                item.SraFcha,
                                                                item.SraCdgoUsrio != null ? item.SraCdgoUsrio : String.Empty,

                                                                //Atributos Compañia
                                                                item.TeNmbre != null ? item.TeNmbre.ToString() : String.Empty
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoSede.Add(objSolicitudRetiroAutorizacion);
                }
                _dbContex.Dispose();
                return listadoSede;
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

        #region Consultar solicitud de retiros autorizacion  por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroAutorizacion>> ConsultarSolicitudRetiroAutorizacionHistorialIdRetiro(int IdSolicitudRetiroAutorizacion)
        {
            List<MdloDtos.SolicitudRetiroAutorizacion> listado = new List<MdloDtos.SolicitudRetiroAutorizacion>();
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                 join r in _dbContex.Terceros on p.SraRowidTrnsprtdra equals r.TeRowid
                                 where (p.SraRowid == IdSolicitudRetiroAutorizacion && r.TeTrnsprtdra == true)
                                 select new
                                 {

                                     p.SraRowid,
                                     p.SraRowidSlctudRtro,
                                     p.SraRowidTrnsprtdra,
                                     p.SraAutrzdoKlos,
                                     p.SraAutrzdoUnddes,
                                     p.SraFcha,
                                     p.SraCdgoUsrio,
                                     r.TeNmbre

                                 }).ToListAsync();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.SolicitudRetiroAutorizacion objSolicitudRetiroTrasmportadora = new MdloDtos.SolicitudRetiroAutorizacion(
                                                                item.SraRowid != null ? item.SraRowid : 0,
                                                                item.SraRowidSlctudRtro != null ? item.SraRowidSlctudRtro : 0,
                                                                item.SraRowidTrnsprtdra != null ? item.SraRowidTrnsprtdra : 0,
                                                                item.SraAutrzdoKlos != null ? item.SraAutrzdoKlos : 0,
                                                                item.SraAutrzdoUnddes != null ? item.SraAutrzdoUnddes : 0,
                                                                item.SraFcha,
                                                                item.SraCdgoUsrio != null ? item.SraCdgoUsrio : String.Empty,
                                                                item.TeNmbre != null ? item.TeNmbre : String.Empty

                                                               );
                    //Agregamnos la Sede a la lista
                    listado.Add(objSolicitudRetiroTrasmportadora);
                }
                _dbContex.Dispose();
                return listado;
            }

        }
        #endregion


        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroIdRetiroTrasnportadora(int IdSolicitudRetiro)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                List<MdloDtos.SolicitudRetiroTransportadora> listado = new List<MdloDtos.SolicitudRetiroTransportadora>();
                var lst = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                 join r in _dbContex.Terceros on p.SrtRowidTrnsprtdra equals r.TeRowid
                                 where (p.SrtRowidSlctudRtro == IdSolicitudRetiro && r.TeTrnsprtdra==true)
                                 select new
                                 {

                                     p.SrtRowid,
                                     p.SrtRowidSlctudRtro,
                                     p.SrtRowidTrnsprtdra,
                                     p.SrtAutrzdoKlos,
                                     p.SrtAutrzdoUnddes,
                                     p.SrtActva,
                                     r.TeCdgo,
                                     r.TeNmbre,
                                     r.TeIdntfccion,
                                     p.SrtDspchdoKlos,
                                     p.SrtDspchdoUnddes,

                                 }).ToListAsync();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.SolicitudRetiroTransportadora objSolicitudRetiroTrasmportadora = new MdloDtos.SolicitudRetiroTransportadora(
                                                                item.SrtRowid != null ? item.SrtRowid : 0,
                                                                item.SrtRowidSlctudRtro != null ? item.SrtRowidSlctudRtro : 0,
                                                                item.SrtRowidTrnsprtdra != null ? item.SrtRowidTrnsprtdra : 0,
                                                                item.SrtAutrzdoKlos != null ? item.SrtAutrzdoKlos : 0,
                                                                item.SrtAutrzdoUnddes != null ? item.SrtAutrzdoUnddes : 0,
                                                                item.SrtActva,
                                                                item.TeCdgo != null ? item.TeCdgo : String.Empty,
                                                                item.TeNmbre != null ? item.TeNmbre : String.Empty,
                                                                item.TeIdntfccion != null ? item.TeIdntfccion.ToString() : String.Empty,
                                                                item.SrtDspchdoKlos != null ? item.SrtDspchdoKlos : 0,
                                                                item.SrtDspchdoUnddes != null ? item.SrtDspchdoUnddes : 0

                                                               );
                    //Agregamnos la Sede a la lista
                    listado.Add(objSolicitudRetiroTrasmportadora);
                }
                _dbContex.Dispose();
                return listado;
            }

        }
        #endregion

        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Trasnportadora .
        public async Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroTrasnportadoraIdRetiro(int IdSolicitudRetiroTrasnportadora)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                List<MdloDtos.SolicitudRetiroTransportadora> listado = new List<MdloDtos.SolicitudRetiroTransportadora>();
                var lst = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                 join r in _dbContex.Terceros on p.SrtRowidTrnsprtdra equals r.TeRowid
                                 where (p.SrtRowid == IdSolicitudRetiroTrasnportadora && r.TeTrnsprtdra == true)
                                 select new
                                 {

                                     p.SrtRowid,
                                     p.SrtRowidSlctudRtro,
                                     p.SrtRowidTrnsprtdra,
                                     p.SrtAutrzdoKlos,
                                     p.SrtAutrzdoUnddes,
                                     p.SrtActva,
                                     r.TeCdgo,
                                     r.TeNmbre,
                                     r.TeIdntfccion,
                                     p.SrtDspchdoKlos,
                                     p.SrtDspchdoUnddes,

                                 }).ToListAsync();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.SolicitudRetiroTransportadora objSolicitudRetiroTrasmportadora = new MdloDtos.SolicitudRetiroTransportadora(
                                                                item.SrtRowid != null ? item.SrtRowid : 0,
                                                                item.SrtRowidSlctudRtro != null ? item.SrtRowidSlctudRtro : 0,
                                                                item.SrtRowidTrnsprtdra != null ? item.SrtRowidTrnsprtdra : 0,
                                                                item.SrtAutrzdoKlos != null ? item.SrtAutrzdoKlos : 0,
                                                                item.SrtAutrzdoUnddes != null ? item.SrtAutrzdoUnddes : 0,
                                                                item.SrtActva,
                                                                item.TeCdgo != null ? item.TeCdgo : String.Empty,
                                                                item.TeNmbre != null ? item.TeNmbre : String.Empty,
                                                                item.TeIdntfccion != null ? item.TeIdntfccion.ToString() : String.Empty,
                                                                item.SrtDspchdoKlos != null ? item.SrtDspchdoKlos : 0,
                                                                item.SrtDspchdoUnddes != null ? item.SrtDspchdoUnddes : 0

                                                               );
                    //Agregamnos la Sede a la lista
                    listado.Add(objSolicitudRetiroTrasmportadora);
                    
                }
                _dbContex.Dispose();
                return listado;
            }

        }
        #endregion


        #region Actualizar solicitud de retiros Transportadora 
        public async Task<MdloDtos.SolicitudRetiroTransportadora> ActualizarSolicitudRetiroTrasnportadora(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
           
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SolicitudRetiroTransportadora SolicitudRetiroExiste = await _dbContex.SolicitudRetiroTransportadoras.FindAsync(_SolicitudRetiroTransportadora.SrtRowid);
                    if (SolicitudRetiroExiste != null)
                    {

                        SolicitudRetiroExiste.SrtRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                        SolicitudRetiroExiste.SrtRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                        SolicitudRetiroExiste.SrtAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                        SolicitudRetiroExiste.SrtDspchdoKlos = _SolicitudRetiroTransportadora.SrtDspchdoKlos;
                        SolicitudRetiroExiste.SrtAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                        SolicitudRetiroExiste.SrtDspchdoUnddes = _SolicitudRetiroTransportadora.SrtDspchdoUnddes;
                        SolicitudRetiroExiste.SrtActva = _SolicitudRetiroTransportadora.SrtActva;
                        _dbContex.SolicitudRetiroTransportadoras.Entry(SolicitudRetiroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return SolicitudRetiroExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
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
