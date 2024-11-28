using AccsoDtos.AccesoSistema;
using AccsoDtos.Parametrizacion;
using AccsoDtos.SituacionPortuaria;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.VisitaMotonave
{
    /// <summary>
    /// CRUD para el manejo de visita motonave bl
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class VisitaMotonaveBl : MdloDtos.IModelos.IVisitaMotonaveBI
    {
        AccesoSistema.EnvioCorreoElectronico ObjEnvio = new EnvioCorreoElectronico();

        #region ingreso de datos a la entidad VisitaMotonaveBl
        public async Task<MdloDtos.VisitaMotonaveBl> IngresarVisitaMotonaveBl(MdloDtos.VisitaMotonaveBl _VisitaMotonaveBl)
        {
            var ObjVisitaMotonaveBl = new MdloDtos.VisitaMotonaveBl();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    DateTime hoy = DateTime.Now;
                    ObjVisitaMotonaveBl.VmblRowid = _VisitaMotonaveBl.VmblRowid;
                    ObjVisitaMotonaveBl.VmblRowidVstaMtnveDtlle = _VisitaMotonaveBl.VmblRowidVstaMtnveDtlle;
                    ObjVisitaMotonaveBl.VmblNmro = _VisitaMotonaveBl.VmblNmro;
                    ObjVisitaMotonaveBl.VmblCdgoUndadMdda = _VisitaMotonaveBl.VmblCdgoUndadMdda;
                    ObjVisitaMotonaveBl.VmblCntdad = _VisitaMotonaveBl.VmblCntdad;
                    ObjVisitaMotonaveBl.VmblTnldasMtrcas = _VisitaMotonaveBl.VmblTnldasMtrcas;
                    ObjVisitaMotonaveBl.VmblEstdo = _VisitaMotonaveBl.VmblEstdo;
                    ObjVisitaMotonaveBl.VmblRta = _VisitaMotonaveBl.VmblRta;
                    ObjVisitaMotonaveBl.VmblFchaCrgue = hoy;
                    ObjVisitaMotonaveBl.VmblFchaAprbcion = _VisitaMotonaveBl.VmblFchaAprbcion;
                    ObjVisitaMotonaveBl.VmblCdgoUsrioCrgue = _VisitaMotonaveBl.VmblCdgoUsrioCrgue;
                    ObjVisitaMotonaveBl.VmblCdgoUsrioAprbdo = _VisitaMotonaveBl.VmblCdgoUsrioAprbdo;
                    ObjVisitaMotonaveBl.VmblRowidStcionPrtriaDtlle = _VisitaMotonaveBl.VmblRowidStcionPrtriaDtlle;
                    var res = await _dbContex.VisitaMotonaveBls.AddAsync(ObjVisitaMotonaveBl);
                    await _dbContex.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjVisitaMotonaveBl;
            }
        }
        #endregion

        #region verificar las relaciones de VisitaMotonaveBl validando  VmblCdgoUndadMdda, VisitaMotonaveDetalles
        public async Task<bool> VerificarVisitaMotonaveBlRelaciones(MdloDtos.VisitaMotonaveBl _VisitaMotonaveBl)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveDetalleExiste = await _dbContex.VisitaMotonaveDetalles.FindAsync(_VisitaMotonaveBl.VmblRowidVstaMtnveDtlle);
                    var UnidadMedidaExiste = new List<MdloDtos.UnidadMedidum>();
                    if (_VisitaMotonaveBl.VmblCdgoUndadMdda != null)
                    { //validamos que la relación de Unidad Medida Exista, si el código es diferente de null
                        UnidadMedidaExiste = await (from unidadMedida in _dbContex.UnidadMedida
                                                    where unidadMedida.UmCdgo == _VisitaMotonaveBl.VmblCdgoUndadMdda
                                                    select unidadMedida
                                                  ).ToListAsync();
                    }
                    if (VisitaMotonaveDetalleExiste == null)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        if (_VisitaMotonaveBl.VmblCdgoUndadMdda != null && UnidadMedidaExiste.Count == 0)
                        {
                            respuesta = false;
                        }
                        else
                        {
                            respuesta = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                _dbContex.Dispose();
                return respuesta;
            }
        }
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonaveDetalle) para buscar todos los VisitaMotonaveBl de una visita motonave detalle en especifico.
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorIdVisitaMotonaveDetalle(int IdVisitaMotonaveDetalle)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from visitaMotonaveBl in _dbContex.VisitaMotonaveBls
                                 join unidadMedida in _dbContex.UnidadMedida on visitaMotonaveBl.VmblCdgoUndadMdda equals unidadMedida.UmCdgo into unidadMedidaJoin
                                 from unidadMedida in unidadMedidaJoin.DefaultIfEmpty()

                                 join usuarioCargue in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioCrgue equals usuarioCargue.UsCdgo into usuarioCargueJoin
                                 from usuarioCargue in usuarioCargueJoin.DefaultIfEmpty()
                                 join usuarioAprobacion in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioAprbdo equals usuarioAprobacion.UsCdgo into usuarioAprobacionJoin
                                 from usuarioAprobacion in usuarioAprobacionJoin.DefaultIfEmpty()
                                 where visitaMotonaveBl.VmblRowidVstaMtnveDtlle == IdVisitaMotonaveDetalle
                                 select new
                                 {
                                     //visitaMotonaveBl
                                     visitaMotonaveBl.VmblRowid,
                                     visitaMotonaveBl.VmblRowidVstaMtnveDtlle,
                                     visitaMotonaveBl.VmblRowidStcionPrtriaDtlle,
                                     visitaMotonaveBl.VmblNmro,
                                     visitaMotonaveBl.VmblCdgoUndadMdda,
                                     visitaMotonaveBl.VmblCntdad,
                                     visitaMotonaveBl.VmblTnldasMtrcas,
                                     visitaMotonaveBl.VmblEstdo,
                                     visitaMotonaveBl.VmblRta,
                                     visitaMotonaveBl.VmblFchaCrgue,
                                     visitaMotonaveBl.VmblFchaAprbcion,
                                     visitaMotonaveBl.VmblCdgoUsrioCrgue,
                                     visitaMotonaveBl.VmblCdgoUsrioAprbdo,


                                     // Datos de la unidadMedida
                                     unidadMedida.UmCdgo,
                                     unidadMedida.UmNmbre,
                                     unidadMedida.UmGrnel,

                                     //Datos del usuario que crea
                                     usuarioCargueCdgo = usuarioCargue.UsCdgo,
                                     usuarioCargueNmbre = usuarioCargue.UsNmbre,
                                     usuarioCargueEmail = usuarioCargue.UsEmail,

                                     //Datos del usuario que aprueba
                                     usuarioAprobacionCdgo = usuarioAprobacion.UsCdgo,
                                     usuarioAprobacionNmbre = usuarioAprobacion.UsNmbre,
                                     usuarioAprobacionEmail = usuarioAprobacion.UsEmail,
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad visitaMotonaveBl para agregar a la lista
                    MdloDtos.VisitaMotonaveBl visitaMotonaveBl = new MdloDtos.VisitaMotonaveBl(
                                            //visitaMotonaveBl
                                            item.VmblRowid != null ? (int)item.VmblRowid : 0,
                                            item.VmblRowidVstaMtnveDtlle != null ? (int)item.VmblRowidVstaMtnveDtlle : 0,
                                            item.VmblRowidStcionPrtriaDtlle != null ? (int)item.VmblRowidStcionPrtriaDtlle : 0,
                                            item.VmblNmro != null ? item.VmblNmro : string.Empty,
                                            item.VmblCdgoUndadMdda != null ? item.VmblCdgoUndadMdda : string.Empty,
                                            item.VmblCntdad != null ? (int)item.VmblCntdad : 0,
                                            item.VmblTnldasMtrcas != null ? (int)item.VmblTnldasMtrcas : 0,
                                            item.VmblEstdo != null ? item.VmblEstdo : string.Empty,
                                            item.VmblRta != null ? item.VmblRta : string.Empty,
                                            item.VmblFchaCrgue != null ? item.VmblFchaCrgue : null,
                                            item.VmblFchaAprbcion != null ? item.VmblFchaAprbcion : null,
                                            item.VmblCdgoUsrioCrgue != null ? item.VmblCdgoUsrioCrgue : null,
                                            item.VmblCdgoUsrioAprbdo != null ? item.VmblCdgoUsrioAprbdo : null,

                                            //Datos de la unidad
                                            item.UmCdgo != null ? item.UmCdgo.ToString() : string.Empty,
                                            item.UmNmbre != null ? item.UmNmbre.ToString() : string.Empty,
                                            item.UmGrnel != null ? item.UmGrnel.ToString() : string.Empty,

                                            //Datos del usuario que crea
                                            item.usuarioCargueCdgo != null ? item.usuarioCargueCdgo.ToString() : string.Empty,
                                            item.usuarioCargueNmbre != null ? item.usuarioCargueNmbre.ToString() : string.Empty,
                                            item.usuarioCargueEmail != null ? item.usuarioCargueEmail.ToString() : string.Empty,

                                            //Datos del usuario que aprueba
                                            item.usuarioAprobacionCdgo != null ? item.usuarioAprobacionCdgo.ToString() : string.Empty,
                                            item.usuarioAprobacionNmbre != null ? item.usuarioAprobacionNmbre.ToString() : string.Empty,
                                            item.usuarioAprobacionEmail != null ? item.usuarioAprobacionEmail.ToString() : string.Empty
                                             );

                    //Agregamos la visitaMotonaveBl a la lista 
                    listaVisitaMotonaveBl.Add(visitaMotonaveBl);
                }
                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonaveDetalle) para buscar todos los VisitaMotonaveBl de una visita motonave detalle en especifico.
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorFiltros(int? IdVisitaMotonaveBl, int? IdVisitaMotonaveDetalle, DateTime? fechaInicio, DateTime? fechaFinal)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from visitaMotonaveBl in _dbContex.VisitaMotonaveBls
                                 join unidadMedida in _dbContex.UnidadMedida on visitaMotonaveBl.VmblCdgoUndadMdda equals unidadMedida.UmCdgo into unidadMedidaJoin
                                 from unidadMedida in unidadMedidaJoin.DefaultIfEmpty()
                                 join usuarioCargue in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioCrgue equals usuarioCargue.UsCdgo into usuarioCargueJoin
                                 from usuarioCargue in usuarioCargueJoin.DefaultIfEmpty()
                                 join usuarioAprobacion in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioAprbdo equals usuarioAprobacion.UsCdgo into usuarioAprobacionJoin
                                 from usuarioAprobacion in usuarioAprobacionJoin.DefaultIfEmpty()
                                 where (IdVisitaMotonaveBl == null || visitaMotonaveBl.VmblRowid == IdVisitaMotonaveBl) &&
                                        (IdVisitaMotonaveDetalle == null || visitaMotonaveBl.VmblRowidVstaMtnveDtlle == IdVisitaMotonaveDetalle) &&
                                        (fechaInicio == null || visitaMotonaveBl.VmblFchaCrgue >= fechaInicio) &&
                                        (fechaFinal == null || visitaMotonaveBl.VmblFchaCrgue <= fechaFinal)
                                 select new
                                 {
                                     //visitaMotonaveBl
                                     visitaMotonaveBl.VmblRowid,
                                     visitaMotonaveBl.VmblRowidVstaMtnveDtlle,
                                     visitaMotonaveBl.VmblRowidStcionPrtriaDtlle,
                                     visitaMotonaveBl.VmblNmro,
                                     visitaMotonaveBl.VmblCdgoUndadMdda,
                                     visitaMotonaveBl.VmblCntdad,
                                     visitaMotonaveBl.VmblTnldasMtrcas,
                                     visitaMotonaveBl.VmblEstdo,
                                     visitaMotonaveBl.VmblRta,
                                     visitaMotonaveBl.VmblFchaCrgue,
                                     visitaMotonaveBl.VmblFchaAprbcion,
                                     visitaMotonaveBl.VmblCdgoUsrioCrgue,
                                     visitaMotonaveBl.VmblCdgoUsrioAprbdo,


                                     // Datos de la unidadMedida
                                     unidadMedida.UmCdgo,
                                     unidadMedida.UmNmbre,
                                     unidadMedida.UmGrnel,

                                     //Datos del usuario que crea
                                     usuarioCargueCdgo = usuarioCargue.UsCdgo,
                                     usuarioCargueNmbre = usuarioCargue.UsNmbre,
                                     usuarioCargueEmail = usuarioCargue.UsEmail,

                                     //Datos del usuario que aprueba
                                     usuarioAprobacionCdgo = usuarioAprobacion.UsCdgo,
                                     usuarioAprobacionNmbre = usuarioAprobacion.UsNmbre,
                                     usuarioAprobacionEmail = usuarioAprobacion.UsEmail,
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad visitaMotonaveBl para agregar a la lista
                    MdloDtos.VisitaMotonaveBl visitaMotonaveBl = new MdloDtos.VisitaMotonaveBl(
                                            //visitaMotonaveBl
                                            item.VmblRowid != null ? (int)item.VmblRowid : 0,
                                            item.VmblRowidVstaMtnveDtlle != null ? (int)item.VmblRowidVstaMtnveDtlle : 0,
                                            item.VmblRowidStcionPrtriaDtlle != null ? (int)item.VmblRowidStcionPrtriaDtlle : 0,
                                            item.VmblNmro != null ? item.VmblNmro : string.Empty,
                                            item.VmblCdgoUndadMdda != null ? item.VmblCdgoUndadMdda : string.Empty,
                                            item.VmblCntdad != null ? (int)item.VmblCntdad : 0,
                                            item.VmblTnldasMtrcas != null ? (int)item.VmblTnldasMtrcas : 0,
                                            item.VmblEstdo != null ? item.VmblEstdo : string.Empty,
                                            item.VmblRta != null ? item.VmblRta : string.Empty,
                                            item.VmblFchaCrgue != null ? item.VmblFchaCrgue : null,
                                            item.VmblFchaAprbcion != null ? item.VmblFchaAprbcion : null,
                                            item.VmblCdgoUsrioCrgue != null ? item.VmblCdgoUsrioCrgue : null,
                                            item.VmblCdgoUsrioAprbdo != null ? item.VmblCdgoUsrioAprbdo : null,

                                            //Datos de la unidad
                                            item.UmCdgo != null ? item.UmCdgo.ToString() : string.Empty,
                                            item.UmNmbre != null ? item.UmNmbre.ToString() : string.Empty,
                                            item.UmGrnel != null ? item.UmGrnel.ToString() : string.Empty,

                                            //Datos del usuario que crea
                                            item.usuarioCargueCdgo != null ? item.usuarioCargueCdgo.ToString() : string.Empty,
                                            item.usuarioCargueNmbre != null ? item.usuarioCargueNmbre.ToString() : string.Empty,
                                            item.usuarioCargueEmail != null ? item.usuarioCargueEmail.ToString() : string.Empty,

                                            //Datos del usuario que aprueba
                                            item.usuarioAprobacionCdgo != null ? item.usuarioAprobacionCdgo.ToString() : string.Empty,
                                            item.usuarioAprobacionNmbre != null ? item.usuarioAprobacionNmbre.ToString() : string.Empty,
                                            item.usuarioAprobacionEmail != null ? item.usuarioAprobacionEmail.ToString() : string.Empty
                                             );

                    //Agregamos la visitaMotonaveBl a la lista 
                    listaVisitaMotonaveBl.Add(visitaMotonaveBl);
                }
                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }
        #endregion

        #region consulta una VisitaMotonaveBl especifica según el RowId
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlEspecifico(int IdVisitaMotonaveBl)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from visitaMotonaveBl in _dbContex.VisitaMotonaveBls
                                 join unidadMedida in _dbContex.UnidadMedida on visitaMotonaveBl.VmblCdgoUndadMdda equals unidadMedida.UmCdgo into unidadMedidaJoin
                                 from unidadMedida in unidadMedidaJoin.DefaultIfEmpty()

                                 join usuarioCargue in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioCrgue equals usuarioCargue.UsCdgo into usuarioCargueJoin
                                 from usuarioCargue in usuarioCargueJoin.DefaultIfEmpty()
                                 join usuarioAprobacion in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioAprbdo equals usuarioAprobacion.UsCdgo into usuarioAprobacionJoin
                                 from usuarioAprobacion in usuarioAprobacionJoin.DefaultIfEmpty()
                                 where visitaMotonaveBl.VmblRowid == IdVisitaMotonaveBl
                                 select new
                                 {
                                     //visitaMotonaveBl
                                     visitaMotonaveBl.VmblRowid,
                                     visitaMotonaveBl.VmblRowidVstaMtnveDtlle,
                                     visitaMotonaveBl.VmblRowidStcionPrtriaDtlle,
                                     visitaMotonaveBl.VmblNmro,
                                     visitaMotonaveBl.VmblCdgoUndadMdda,
                                     visitaMotonaveBl.VmblCntdad,
                                     visitaMotonaveBl.VmblTnldasMtrcas,
                                     visitaMotonaveBl.VmblEstdo,
                                     visitaMotonaveBl.VmblRta,
                                     visitaMotonaveBl.VmblFchaCrgue,
                                     visitaMotonaveBl.VmblFchaAprbcion,
                                     visitaMotonaveBl.VmblCdgoUsrioCrgue,
                                     visitaMotonaveBl.VmblCdgoUsrioAprbdo,


                                     // Datos de la unidadMedida
                                     unidadMedida.UmCdgo,
                                     unidadMedida.UmNmbre,
                                     unidadMedida.UmGrnel,

                                     //Datos del usuario que crea
                                     usuarioCargueCdgo = usuarioCargue.UsCdgo,
                                     usuarioCargueNmbre = usuarioCargue.UsNmbre,
                                     usuarioCargueEmail = usuarioCargue.UsEmail,

                                     //Datos del usuario que aprueba
                                     usuarioAprobacionCdgo = usuarioAprobacion.UsCdgo,
                                     usuarioAprobacionNmbre = usuarioAprobacion.UsNmbre,
                                     usuarioAprobacionEmail = usuarioAprobacion.UsEmail,
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        //Creamos una entidad visitaMotonaveBl para agregar a la lista
                        MdloDtos.VisitaMotonaveBl visitaMotonaveBl = new MdloDtos.VisitaMotonaveBl(
                                                //visitaMotonaveBl
                                                item.VmblRowid != null ? (int)item.VmblRowid : 0,
                                                item.VmblRowidVstaMtnveDtlle != null ? (int)item.VmblRowidVstaMtnveDtlle : 0,
                                                item.VmblRowidStcionPrtriaDtlle != null ? (int)item.VmblRowidStcionPrtriaDtlle : 0,
                                                item.VmblNmro != null ? item.VmblNmro : string.Empty,
                                                item.VmblCdgoUndadMdda != null ? item.VmblCdgoUndadMdda : string.Empty,
                                                item.VmblCntdad != null ? (int)item.VmblCntdad : 0,
                                                item.VmblTnldasMtrcas != null ? (int)item.VmblTnldasMtrcas : 0,
                                                item.VmblEstdo != null ? item.VmblEstdo : string.Empty,
                                                item.VmblRta != null ? item.VmblRta : string.Empty,
                                                item.VmblFchaCrgue != null ? item.VmblFchaCrgue : null,
                                                item.VmblFchaAprbcion != null ? item.VmblFchaAprbcion : null,
                                                item.VmblCdgoUsrioCrgue != null ? item.VmblCdgoUsrioCrgue : null,
                                                item.VmblCdgoUsrioAprbdo != null ? item.VmblCdgoUsrioAprbdo : null,

                                                //Datos de la unidad
                                                item.UmCdgo != null ? item.UmCdgo.ToString() : string.Empty,
                                                item.UmNmbre != null ? item.UmNmbre.ToString() : string.Empty,
                                                item.UmGrnel != null ? item.UmGrnel.ToString() : string.Empty,

                                                //Datos del usuario que crea
                                                item.usuarioCargueCdgo != null ? item.usuarioCargueCdgo.ToString() : string.Empty,
                                                item.usuarioCargueNmbre != null ? item.usuarioCargueNmbre.ToString() : string.Empty,
                                                item.usuarioCargueEmail != null ? item.usuarioCargueEmail.ToString() : string.Empty,

                                                //Datos del usuario que aprueba
                                                item.usuarioAprobacionCdgo != null ? item.usuarioAprobacionCdgo.ToString() : string.Empty,
                                                item.usuarioAprobacionNmbre != null ? item.usuarioAprobacionNmbre.ToString() : string.Empty,
                                                item.usuarioAprobacionEmail != null ? item.usuarioAprobacionEmail.ToString() : string.Empty
                                                 );

                        //Agregamos la visitaMotonaveBl a la lista 
                        listaVisitaMotonaveBl.Add(visitaMotonaveBl);
                    }

                }

                return listaVisitaMotonaveBl;
            }
        }
        #endregion

        #region consulta todas las VisitaMotonaveBl creadas
        public async Task<List<MdloDtos.VisitaMotonaveBl>> ConsultarVisitaMotonaveBl()
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from visitaMotonaveBl in _dbContex.VisitaMotonaveBls
                                 join unidadMedida in _dbContex.UnidadMedida on visitaMotonaveBl.VmblCdgoUndadMdda equals unidadMedida.UmCdgo into unidadMedidaJoin
                                 from unidadMedida in unidadMedidaJoin.DefaultIfEmpty()

                                 join usuarioCargue in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioCrgue equals usuarioCargue.UsCdgo into usuarioCargueJoin
                                 from usuarioCargue in usuarioCargueJoin.DefaultIfEmpty()
                                 join usuarioAprobacion in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioAprbdo equals usuarioAprobacion.UsCdgo into usuarioAprobacionJoin
                                 from usuarioAprobacion in usuarioAprobacionJoin.DefaultIfEmpty()
                                 select new
                                 {
                                     //visitaMotonaveBl
                                     visitaMotonaveBl.VmblRowid,
                                     visitaMotonaveBl.VmblRowidVstaMtnveDtlle,
                                     visitaMotonaveBl.VmblRowidStcionPrtriaDtlle,
                                     visitaMotonaveBl.VmblNmro,
                                     visitaMotonaveBl.VmblCdgoUndadMdda,
                                     visitaMotonaveBl.VmblCntdad,
                                     visitaMotonaveBl.VmblTnldasMtrcas,
                                     visitaMotonaveBl.VmblEstdo,
                                     visitaMotonaveBl.VmblRta,
                                     visitaMotonaveBl.VmblFchaCrgue,
                                     visitaMotonaveBl.VmblFchaAprbcion,
                                     visitaMotonaveBl.VmblCdgoUsrioCrgue,
                                     visitaMotonaveBl.VmblCdgoUsrioAprbdo,


                                     // Datos de la unidadMedida
                                     unidadMedida.UmCdgo,
                                     unidadMedida.UmNmbre,
                                     unidadMedida.UmGrnel,

                                     //Datos del usuario que crea
                                     usuarioCargueCdgo = usuarioCargue.UsCdgo,
                                     usuarioCargueNmbre = usuarioCargue.UsNmbre,
                                     usuarioCargueEmail = usuarioCargue.UsEmail,

                                     //Datos del usuario que aprueba
                                     usuarioAprobacionCdgo = usuarioAprobacion.UsCdgo,
                                     usuarioAprobacionNmbre = usuarioAprobacion.UsNmbre,
                                     usuarioAprobacionEmail = usuarioAprobacion.UsEmail,
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad visitaMotonaveBl para agregar a la lista
                    MdloDtos.VisitaMotonaveBl visitaMotonaveBl = new MdloDtos.VisitaMotonaveBl(
                                            //visitaMotonaveBl
                                            item.VmblRowid != null ? (int)item.VmblRowid : 0,
                                            item.VmblRowidVstaMtnveDtlle != null ? (int)item.VmblRowidVstaMtnveDtlle : 0,
                                            item.VmblRowidStcionPrtriaDtlle != null ? (int)item.VmblRowidStcionPrtriaDtlle : 0,
                                            item.VmblNmro != null ? item.VmblNmro : string.Empty,
                                            item.VmblCdgoUndadMdda != null ? item.VmblCdgoUndadMdda : string.Empty,
                                            item.VmblCntdad != null ? (int)item.VmblCntdad : 0,
                                            item.VmblTnldasMtrcas != null ? (int)item.VmblTnldasMtrcas : 0,
                                            item.VmblEstdo != null ? item.VmblEstdo : string.Empty,
                                            item.VmblRta != null ? item.VmblRta : string.Empty,
                                            item.VmblFchaCrgue != null ? item.VmblFchaCrgue : null,
                                            item.VmblFchaAprbcion != null ? item.VmblFchaAprbcion : null,
                                            item.VmblCdgoUsrioCrgue != null ? item.VmblCdgoUsrioCrgue : null,
                                            item.VmblCdgoUsrioAprbdo != null ? item.VmblCdgoUsrioAprbdo : null,

                                            //Datos de la unidad
                                            item.UmCdgo != null ? item.UmCdgo.ToString() : string.Empty,
                                            item.UmNmbre != null ? item.UmNmbre.ToString() : string.Empty,
                                            item.UmGrnel != null ? item.UmGrnel.ToString() : string.Empty,

                                            //Datos del usuario que crea
                                            item.usuarioCargueCdgo != null ? item.usuarioCargueCdgo.ToString() : string.Empty,
                                            item.usuarioCargueNmbre != null ? item.usuarioCargueNmbre.ToString() : string.Empty,
                                            item.usuarioCargueEmail != null ? item.usuarioCargueEmail.ToString() : string.Empty,

                                            //Datos del usuario que aprueba
                                            item.usuarioAprobacionCdgo != null ? item.usuarioAprobacionCdgo.ToString() : string.Empty,
                                            item.usuarioAprobacionNmbre != null ? item.usuarioAprobacionNmbre.ToString() : string.Empty,
                                            item.usuarioAprobacionEmail != null ? item.usuarioAprobacionEmail.ToString() : string.Empty
                                             );

                    //Agregamos la visitaMotonaveBl a la lista 
                    listaVisitaMotonaveBl.Add(visitaMotonaveBl);
                }
                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }
        #endregion

        #region  elimina una VisitaMotonaveBl especifica según el id del mismo
        public async Task<MdloDtos.VisitaMotonaveBl> EliminarVisitaMotonaveBlEspecifico(MdloDtos.VisitaMotonaveBl _VisitaMotonaveBl)
        {
            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveBlExiste = await _dbContext.VisitaMotonaveBls.FindAsync(_VisitaMotonaveBl.VmblRowid);
                    if (VisitaMotonaveBlExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContext.Remove(VisitaMotonaveBlExiste);
                        await _dbContext.SaveChangesAsync();
                    }
                    _dbContext.Dispose();
                    return VisitaMotonaveBlExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }
        #endregion

        #region elimina todas las VisitaMotonaveBl  según el id de la visita motonave detalle
        public async Task<bool> EliminarVisitaMotonaveBlPorIdVisitaMotonaveDetalle(MdloDtos.VisitaMotonaveDetalle ObjVisitaMotonaveDetalle)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveDetalleExiste = await _dbContext.VisitaMotonaveDetalles.FindAsync(ObjVisitaMotonaveDetalle.VmdRowid);
                    if (VisitaMotonaveDetalleExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        var resultado = (from visitaMotonaveBl in _dbContext.VisitaMotonaveBls
                                         where visitaMotonaveBl.VmblRowidVstaMtnveDtlle == ObjVisitaMotonaveDetalle.VmdRowid
                                         select visitaMotonaveBl).Count();
                        if (resultado > 0)
                        {
                            var VisitaMotonaveBlExiste_ = (from visitaMotonaveBl in _dbContext.VisitaMotonaveBls
                                                           where visitaMotonaveBl.VmblRowidVstaMtnveDtlle == ObjVisitaMotonaveDetalle.VmdRowid
                                                           select visitaMotonaveBl).ToList();
                            foreach (var item in VisitaMotonaveBlExiste_)
                            {
                                _dbContext.Remove(item);
                                await _dbContext.SaveChangesAsync();
                            }

                            respuesta = true;
                        }
                        _dbContext.Dispose();
                        return respuesta;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region Actualizar VisitaMotonaveBl pasando el objeto _VisitaMotonaveBl
        public async Task<MdloDtos.VisitaMotonaveBl> EditarVisitaMotonaveBl(MdloDtos.VisitaMotonaveBl _VisitaMotonaveBl)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.VisitaMotonaveBl VisitaMotonaveBlExiste = await _dbContex.VisitaMotonaveBls.FindAsync(_VisitaMotonaveBl.VmblRowid);
                    if (VisitaMotonaveBlExiste != null)
                    {
                        //VisitaMotonaveBlExiste.VmblRowid = _VisitaMotonaveBl.VmblRowid;
                        //VisitaMotonaveBlExiste.VmblRowidVstaMtnveDtlle = _VisitaMotonaveBl.VmblRowidVstaMtnveDtlle;
                        VisitaMotonaveBlExiste.VmblNmro = _VisitaMotonaveBl.VmblNmro;
                        VisitaMotonaveBlExiste.VmblCdgoUndadMdda = _VisitaMotonaveBl.VmblCdgoUndadMdda;
                        VisitaMotonaveBlExiste.VmblCntdad = _VisitaMotonaveBl.VmblCntdad;
                        VisitaMotonaveBlExiste.VmblTnldasMtrcas = _VisitaMotonaveBl.VmblTnldasMtrcas;
                        //VisitaMotonaveBlExiste.VmblEstdo = _VisitaMotonaveBl.VmblEstdo;
                        VisitaMotonaveBlExiste.VmblRta = _VisitaMotonaveBl.VmblRta;
                        //VisitaMotonaveBlExiste.VmblFchaCrgue = _VisitaMotonaveBl.VmblFchaCrgue;
                        //VisitaMotonaveBlExiste.VmblFchaAprbcion = _VisitaMotonaveBl.VmblFchaAprbcion;
                        //VisitaMotonaveBlExiste.VmblCdgoUsrioCrgue = _VisitaMotonaveBl.VmblCdgoUsrioCrgue;
                        //VisitaMotonaveBlExiste.VmblCdgoUsrioAprbdo = _VisitaMotonaveBl.VmblCdgoUsrioAprbdo;

                        _dbContex.Entry(VisitaMotonaveBlExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return VisitaMotonaveBlExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Actualiza estado de la visitaMotonaveBl.
        public async Task<MdloDtos.VisitaMotonaveBl> actualizarEstadoVisitaMotonaveBl(MdloDtos.VisitaMotonaveBl _VisitaMotonaveBl)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //actualizar en visita motonave documentos.
                    var VisitaMotonaveBlExiste = await _dbContex.VisitaMotonaveBls.FindAsync(_VisitaMotonaveBl.VmblRowid);
                    if (VisitaMotonaveBlExiste != null)
                    {
                        string correoUsuario = "";
                        MdloDtos.CorreoElectronico ObjModeloCorreo = new CorreoElectronico();

                        var usuarioRegistro = (from visitaMotonaveBl in _dbContex.VisitaMotonaveBls
                                             join usuarioCargue in _dbContex.Usuarios on visitaMotonaveBl.VmblCdgoUsrioCrgue equals usuarioCargue.UsCdgo
                                             where visitaMotonaveBl.VmblRowid == _VisitaMotonaveBl.VmblRowid
                                             select usuarioCargue).ToList();

                        foreach (var item in usuarioRegistro)
                        {
                            correoUsuario = item.UsEmail;
                        }

                        if (VisitaMotonaveBlExiste.VmblEstdo == "C" && _VisitaMotonaveBl.VmblEstdo == "A")
                        {
                            //Se procede a enviar el correo
                            var correo = (from l in _dbContex.Parametros select l).ToList();
                            if (correo.Count > 0 || correo != null)
                            {
                                foreach (var item in correo)
                                {
                                    ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                                    ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                                    ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                                    ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                                    ObjModeloCorreo.Para = correoUsuario;
                                    ObjModeloCorreo.Asunto = "Cambio de estado por aprobado";
                                    ObjModeloCorreo.Mensaje = "Cambio de estado por aprobado";
                                    ObjModeloCorreo.Nombre_Archivo = "";
                                    ObjModeloCorreo.Msg_error = "";
                                }
                            }
                        }
                        if (VisitaMotonaveBlExiste.VmblEstdo == "C" && _VisitaMotonaveBl.VmblEstdo == "R")
                        {
                            var correo = (from l in _dbContex.Parametros select l).ToList();
                            if (correo.Count > 0 || correo != null)
                            {
                                foreach (var item in correo)
                                {
                                    ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                                    ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                                    ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                                    ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                                    ObjModeloCorreo.Para = correoUsuario;
                                    ObjModeloCorreo.Asunto = "Cambio de estado por Rechazado";
                                    ObjModeloCorreo.Mensaje = "Cambio de estado por Rechazado";
                                    ObjModeloCorreo.Nombre_Archivo = "";
                                    ObjModeloCorreo.Msg_error = "";
                                }
                            }
                        }

                        
                        ObjEnvio.Enviar_Correo_Directo(ObjModeloCorreo);


                        DateTime hoy = DateTime.Now;
                        VisitaMotonaveBlExiste.VmblEstdo = _VisitaMotonaveBl.VmblEstdo;
                        VisitaMotonaveBlExiste.VmblFchaAprbcion = hoy;
                        VisitaMotonaveBlExiste.VmblCdgoUsrioAprbdo = _VisitaMotonaveBl.VmblCdgoUsrioAprbdo;

                        _dbContex.VisitaMotonaveBls.Update(VisitaMotonaveBlExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return VisitaMotonaveBlExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonave) para buscar todos los VisitaMotonaveBl de una visita motonave en particular.
        /*public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorIdVisitaMotonave_Borrar(int IdVisitaMotonave)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = from vm in _dbContex.VisitaMotonaves
                            join vmd in _dbContex.VisitaMotonaveDetalles on vm.VmRowid equals vmd.VmdRowidVstaMtnve
                            join te in _dbContex.Terceros on vmd.VmdRowidImprtdor equals te.TeRowid
                            join pr in _dbContex.Productos on vmd.VmdCdgoPrdcto equals pr.PrCdgo
                            join vmbl in _dbContex.VisitaMotonaveBls on vmd.VmdRowid equals vmbl.VmblRowidVstaMtnveDtlle
                            join umTemp in _dbContex.UnidadMedida on vmbl.VmblCdgoUndadMdda equals umTemp.UmCdgo into umj
                            from um in umj.DefaultIfEmpty()
                            join vmdo in _dbContex.VisitaMotonaveDocumentos on vmbl.VmblRowid equals vmdo.VmdoRowidVstaMtnveBl
                            join td in _dbContex.TipoDocumentos on vmdo.VmdoCdgoTpoDcmnto equals td.TdCdgo
                            join agrupacion in (
                                from vmdoinner in _dbContex.VisitaMotonaveDocumentos
                                join tdinner in _dbContex.TipoDocumentos on vmdoinner.VmdoCdgoTpoDcmnto equals tdinner.TdCdgo
                                where tdinner.TdOrgen == "A"
                                group vmdoinner by new { vmdoinner.VmdoCdgoTpoDcmnto, vmdoinner.VmdoRowidVstaMtnveBl, vmdoinner.VmdoLnea } into g
                                select new
                                {
                                    DocVmdoRowid = g.Max(x => x.VmdoRowid),
                                    VmdoCdgoTpoDcmnto = g.Key.VmdoCdgoTpoDcmnto,
                                    VmdoRowidVstaMtnveBl = g.Key.VmdoRowidVstaMtnveBl,
                                    VmdoLnea = g.Key.VmdoLnea
                                }
                            ) on new { VmdoRowid = (int?)vmdo.VmdoRowid, VmdoLnea = (int?)vmdo.VmdoLnea } equals new { VmdoRowid = (int?)agrupacion.DocVmdoRowid, VmdoLnea = (int?)agrupacion.VmdoLnea }
                            join lvnte in (
                                from vmbl1 in _dbContex.VisitaMotonaveBl1s
                                join levante in (
                                    from vmbl1inner in _dbContex.VisitaMotonaveBl1s
                                    group vmbl1inner by new { vmbl1inner.Vmbl1RowidVstaMtnveBl, vmbl1inner.Vmbl1Lnea } into g
                                    select new
                                    {
                                        LevanteVmbl1Rowid = g.Max(x => x.Vmbl1Rowid)
                                    }
                                ) on vmbl1.Vmbl1Rowid equals levante.LevanteVmbl1Rowid
                                select new
                                {
                                    vmbl1.Vmbl1Rowid,
                                    vmbl1.Vmbl1RowidVstaMtnveBl,
                                    vmbl1.Vmbl1NmroLvnte,
                                    vmbl1.Vmbl1Lnea
                                }
                            ) on new { VmblRowid = (int?)vmbl.VmblRowid, VmdoLnea = (int?)vmdo.VmdoLnea } equals new { VmblRowid = (int?)lvnte.Vmbl1RowidVstaMtnveBl, VmdoLnea = (int?)lvnte.Vmbl1Lnea }
                            where vm.VmRowid == IdVisitaMotonave
                            group new { vm, vmbl, vmd, te, pr, um, vmdo, td, lvnte } by new
                            {
                                vm.VmRowid,
                                vmbl.VmblRowid,
                                vmd.VmdRowidVstaMtnve,
                                vmdo.VmdoCdgoTpoDcmnto,
                                td.TdNmbre,
                                vmdo.VmdoRowid,
                                vmdo.VmdoLnea,
                                lvnte.Vmbl1Rowid,
                                lvnte.Vmbl1RowidVstaMtnveBl,
                                lvnte.Vmbl1NmroLvnte,
                                lvnte.Vmbl1Lnea,
                                te.TeRowid,
                                te.TeCdgoCia,
                                te.TeCdgo,
                                te.TeNmbre,
                                pr.PrCdgo,
                                pr.PrNmbre,
                                vmbl.VmblNmro,
                                vmbl.VmblRta,
                                vmbl.VmblEstdo,
                                um.UmCdgo,
                                um.UmNmbre,
                                um.UmGrnel,
                                um.UmActvo,
                                vmbl.VmblCntdad,
                                vmbl.VmblTnldasMtrcas,
                                vmdo.VmdoNmro,
                                vmdo.VmdoRta,
                                vmdo.VmdoEstdo
                            } into g
                            orderby g.Key.VmblRowid
                            select new
                            {
                                g.Key.VmblRowid,
                                g.Key.VmdoRowid,
                                g.Key.TeRowid,
                                g.Key.TeCdgoCia,
                                g.Key.TeCdgo,
                                g.Key.TeNmbre,
                                g.Key.PrCdgo,
                                g.Key.PrNmbre,
                                g.Key.VmblNmro,
                                g.Key.VmblRta,
                                g.Key.VmblEstdo,
                                g.Key.UmCdgo,
                                g.Key.UmNmbre,
                                g.Key.UmGrnel,
                                g.Key.UmActvo,
                                g.Key.VmblCntdad,
                                g.Key.VmblTnldasMtrcas,
                                g.Key.Vmbl1NmroLvnte,
                                g.Key.VmdoNmro,
                                g.Key.VmdoCdgoTpoDcmnto,
                                g.Key.TdNmbre,
                                g.Key.VmdoRta,
                                g.Key.VmdoEstdo,
                                g.Key.VmdoLnea
                            };
                var lst = await query.ToListAsync();             
                int validadorRowId = 0;

                foreach (var item in lst)
                {
                    if (validadorRowId != item.VmblRowid)
                    {
                        // Es un nuevo registro
                        var objVisitaMotonaveBl = new MdloDtos.VisitaMotonaveBl
                        {
                            VmblRowid = item.VmblRowid,
                            VmblRowidVstaMtnveDtlle = item.VmblRowid,
                            VmblNmro = item.VmblNmro,
                            VmblRta = item.VmblRta,
                            VmblEstdo = item.VmblEstdo,
                            VmblCntdad = item.VmblCntdad,
                            VmblTnldasMtrcas = item.VmblTnldasMtrcas,
                            UnidadMedidaCodigo = item.UmCdgo?.ToString(),
                            UnidadMedidaNombre = item.UmNmbre?.ToString(),
                            VisitaMotonaveDetalle = new MdloDtos.VisitaMotonaveDetalle
                            {
                                ImportadorRowId = item.TeRowid?.ToString(),
                                ImportadorNombre = item.TeNmbre?.ToString(),
                                ProductoCodigo = item.PrCdgo?.ToString(),
                                ProductoNombre = item.PrNmbre?.ToString(),
                                VmdRowidVstaMtnve = IdVisitaMotonave
                            },
                            ListaVisitaMotonaveDocumentos = new List<VisitaMotonaveDocumento>
                            {
                                new MdloDtos.VisitaMotonaveDocumento
                                {
                                    VmdoRowid = item.VmdoRowid,
                                    VmdoCdgoTpoDcmnto = item.VmdoCdgoTpoDcmnto,
                                    VmdoNmro = item.VmdoNmro,
                                    VmdoRta = item.VmdoRta,
                                    VmdoEstdo = item.VmdoEstdo,
                                    VmdoLnea = item.VmdoLnea,
                                    TipoDocumento = new MdloDtos.TipoDocumento
                                    {
                                        TdCdgo = item.VmdoCdgoTpoDcmnto,
                                        TdNmbre = item.TdNmbre
                                    },
                                    VisitaMotonaveBl1 = new MdloDtos.VisitaMotonaveBl1
                                    {
                                        Vmbl1NmroLvnte = item.Vmbl1NmroLvnte,
                                        Vmbl1Lnea = item.VmdoLnea
                                    }
                                }
                            }
                        };
                        listaVisitaMotonaveBl.Add(objVisitaMotonaveBl);
                        validadorRowId = item.VmblRowid; // Asignamos el identificador al validador
                    }
                    else
                    {
                        // Agregamos un nuevo VisitaMotonaveDocumento a la lista 
                        var objVisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveDocumento
                        {
                            VmdoRowid = item.VmdoRowid,
                            VmdoCdgoTpoDcmnto = item.VmdoCdgoTpoDcmnto,
                            VmdoNmro = item.VmdoNmro,
                            VmdoRta = item.VmdoRta,
                            VmdoEstdo = item.VmdoEstdo,
                            VmdoLnea = item.VmdoLnea,
                            TipoDocumento = new MdloDtos.TipoDocumento
                            {
                                TdCdgo = item.VmdoCdgoTpoDcmnto,
                                TdNmbre = item.TdNmbre
                            },
                            VisitaMotonaveBl1 = new MdloDtos.VisitaMotonaveBl1
                            {
                                Vmbl1NmroLvnte = item.Vmbl1NmroLvnte,
                                Vmbl1Lnea = item.VmdoLnea
                            }
                        };
                        listaVisitaMotonaveBl.Last().ListaVisitaMotonaveDocumentos.Add(objVisitaMotonaveDocumento);
                    }
                }
                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }*/
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonave) para buscar todos los VisitaMotonaveBl de una visita motonave en particular.
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorIdVisitaMotonave(int IdVisitaMotonave)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.ListarDocumentosAprobarPorVisitaMotonave(IdVisitaMotonave);
                int validadorRowId = 0;
                bool saltarSiquienteIteraccion = false;
                foreach (var item in query)
                {
                    //validamos salto de iteracciones
                    if (saltarSiquienteIteraccion)
                    {
                        saltarSiquienteIteraccion = false;
                        continue;
                    }
                    if (validadorRowId != item.Vmbl_rowid)
                    {
                        var objVisitaMotonaveBl = new MdloDtos.VisitaMotonaveBl
                        {
                            VmblRowid = (int)item.Vmbl_rowid,
                            VmblRowidVstaMtnveDtlle = item.Vmd_rowid,
                            VmblNmro = item.Vmbl_nmro,
                            VmblRta = item.Vmbl_rta,
                            VmblEstdo = item.Vmbl_estdo,
                            VmblCntdad = item.Vmbl_cntdad,
                            VmblTnldasMtrcas = item.Vmbl_tnldas_mtrcas,
                            UnidadMedidaCodigo = item.Um_cdgo?.ToString(),
                            UnidadMedidaNombre = item.Um_nmbre?.ToString(),
                            VisitaMotonaveDetalle = new MdloDtos.VisitaMotonaveDetalle
                            {
                                ImportadorRowId = item.Te_rowid?.ToString(),
                                ImportadorNombre = item.Te_nmbre?.ToString(),
                                ProductoCodigo = item.Pr_cdgo?.ToString(),
                                ProductoNombre = item.Pr_nmbre?.ToString(),
                                VmdRowidVstaMtnve = IdVisitaMotonave
                            }
                        };
                        //Recorremos todas las lineas
                        int? identificadorLevante = item.Lvnte_vmbl1_rowid;
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveBl1 levante = new MdloDtos.VisitaMotonaveBl1();
                        int contadorDocumento = 0;
                        if (identificadorLevante != null)
                        {
                            foreach (var linea in query)
                            {
                                if (identificadorLevante == linea.Lvnte_vmbl1_rowid)
                                {
                                    if (contadorDocumento == 0)
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };

                                        ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            //VisitaMotonaveBl1 = levante
                                        };

                                        contadorDocumento++;
                                    }
                                    else
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };
                                        ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            //VisitaMotonaveBl1 = levante
                                        };
                                        contadorDocumento++;
                                    }
                                }
                            }
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl = new List<LineaVisitaMotonaveBl>();
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl.Add(
                                new LineaVisitaMotonaveBl
                                {
                                    VisitaMotonaveDocumentoUno = ObjDocumento1,
                                    VisitaMotonaveDocumentoDos = ObjDocumento2,
                                    VisitaMotonaveBl1 = levante
                                });
                            saltarSiquienteIteraccion = true;
                        }
                        else {
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl = new List<LineaVisitaMotonaveBl>();
                        }
                        listaVisitaMotonaveBl.Add(objVisitaMotonaveBl);
                        validadorRowId = (int)item.Vmbl_rowid;
                    }
                    else
                    {
                        int? identificadorLevante = item.Lvnte_vmbl1_rowid;
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveBl1 levante = new MdloDtos.VisitaMotonaveBl1();
                        int contadorDocumento = 0;
                        if (identificadorLevante != null)
                        {
                            foreach (var linea in query)
                            {
                                if (identificadorLevante == linea.Lvnte_vmbl1_rowid)
                                {
                                    if (contadorDocumento == 0)
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };

                                        ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VisitaMotonaveBl1 = levante
                                        };

                                        contadorDocumento++;
                                    }
                                    else
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };
                                        ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VisitaMotonaveBl1 = levante
                                        };
                                        contadorDocumento++;
                                    }
                                }
                            }
                            listaVisitaMotonaveBl.Last().ListaLineasVisitaMotonaveBl.Add(
                                new LineaVisitaMotonaveBl
                                {
                                    VisitaMotonaveDocumentoUno = ObjDocumento1,
                                    VisitaMotonaveDocumentoDos = ObjDocumento2,
                                    VisitaMotonaveBl1 = levante
                                });
                            saltarSiquienteIteraccion = true;
                        }
                        validadorRowId = (int)item.Vmbl_rowid;
                    }
                }

                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonave,codigoUsuario) para buscar todos los VisitaMotonaveBl de una visita motonave en particular.
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlAduanas(int IdVisitaMotonave, string codigoUsuario)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.ListarDocumentosAduanasDeCarguePorVisitaMotonave(IdVisitaMotonave, codigoUsuario);
                int validadorRowId = 0;
                bool saltarSiquienteIteraccion = false;
                foreach (var item in query)
                {
                    //validamos salto de iteracciones
                    if (saltarSiquienteIteraccion)
                    {
                        saltarSiquienteIteraccion = false;
                        continue;
                    }
                    if (validadorRowId != item.Vmbl_rowid)
                    {
                        var objVisitaMotonaveBl = new MdloDtos.VisitaMotonaveBl
                        {
                            VmblRowid = (int)item.Vmbl_rowid,
                            VmblRowidVstaMtnveDtlle = item.Vmd_rowid,
                            VmblNmro = item.Vmbl_nmro,
                            VmblRta = item.Vmbl_rta,
                            VmblEstdo = item.Vmbl_estdo,
                            VmblCntdad = item.Vmbl_cntdad,
                            VmblTnldasMtrcas = item.Vmbl_tnldas_mtrcas,
                            UnidadMedidaCodigo = item.Um_cdgo?.ToString(),
                            UnidadMedidaNombre = item.Um_nmbre?.ToString(),
                            VisitaMotonaveDetalle = new MdloDtos.VisitaMotonaveDetalle
                            {

                                ImportadorRowId = item.Te_rowid?.ToString(),
                                ImportadorNombre = item.Te_nmbre?.ToString(),
                                ProductoCodigo = item.Pr_cdgo?.ToString(),
                                ProductoNombre = item.Pr_nmbre?.ToString(),
                                VmdRowidVstaMtnve = IdVisitaMotonave
                            }
                        };
                        //Recorremos todas las lineas
                        int? identificadorLevante = item.Lvnte_vmbl1_rowid;
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveBl1 levante = new MdloDtos.VisitaMotonaveBl1();
                        int contadorDocumento = 0;
                        if (identificadorLevante != null)
                        {
                            foreach (var linea in query)
                            {
                                if (identificadorLevante == linea.Lvnte_vmbl1_rowid)
                                {
                                    if (contadorDocumento == 0)
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };

                                        ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            //VisitaMotonaveBl1 = levante
                                        };

                                        contadorDocumento++;
                                    }
                                    else
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };
                                        ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            //VisitaMotonaveBl1 = levante
                                        };
                                        contadorDocumento++;
                                    }
                                }
                            }
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl = new List<LineaVisitaMotonaveBl>();
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl.Add(
                                new LineaVisitaMotonaveBl
                                {
                                    VisitaMotonaveDocumentoUno = ObjDocumento1,
                                    VisitaMotonaveDocumentoDos = ObjDocumento2,
                                    VisitaMotonaveBl1 = levante
                                });
                            saltarSiquienteIteraccion = true;
                        }
                        else
                        {
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl = new List<LineaVisitaMotonaveBl>();
                        }
                        listaVisitaMotonaveBl.Add(objVisitaMotonaveBl);
                        validadorRowId = (int)item.Vmbl_rowid;
                    }
                    else
                    {
                        int? identificadorLevante = item.Lvnte_vmbl1_rowid;
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveBl1 levante = new MdloDtos.VisitaMotonaveBl1();
                        int contadorDocumento = 0;
                        if (identificadorLevante != null)
                        {
                            foreach (var linea in query)
                            {
                                if (identificadorLevante == linea.Lvnte_vmbl1_rowid)
                                {
                                    if (contadorDocumento == 0)
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };

                                        ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VisitaMotonaveBl1 = levante
                                        };

                                        contadorDocumento++;
                                    }
                                    else
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };
                                        ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VisitaMotonaveBl1 = levante
                                        };
                                        contadorDocumento++;
                                    }
                                }
                            }
                            listaVisitaMotonaveBl.Last().ListaLineasVisitaMotonaveBl.Add(
                                new LineaVisitaMotonaveBl
                                {
                                    VisitaMotonaveDocumentoUno = ObjDocumento1,
                                    VisitaMotonaveDocumentoDos = ObjDocumento2,
                                    VisitaMotonaveBl1 = levante
                                });
                            saltarSiquienteIteraccion = true;
                        }
                        validadorRowId = (int)item.Vmbl_rowid;
                    }
                }

                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonave,codigoUsuario) para buscar todos los VisitaMotonaveBl de una visita motonave en particular.
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlDepositoCreacion(int IdVisitaMotonave, int IdTercero, string codigoProducto)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.ListarVisitaMotonaveBlCrearDepositos(IdVisitaMotonave, IdTercero, codigoProducto);
                int validadorRowId = 0;
                bool saltarSiquienteIteraccion = false;
                foreach (var item in query)
                {
                    //validamos salto de iteracciones
                    if (saltarSiquienteIteraccion)
                    {
                        saltarSiquienteIteraccion = false;
                        continue;
                    }
                    if (validadorRowId != item.Vmbl_rowid)
                    {
                        var objVisitaMotonaveBl = new MdloDtos.VisitaMotonaveBl
                        {
                            VmblRowid = (int)item.Vmbl_rowid,
                            VmblRowidVstaMtnveDtlle = item.Vmd_rowid,
                            VmblNmro = item.Vmbl_nmro,
                            VmblRta = item.Vmbl_rta,
                            VmblEstdo = item.Vmbl_estdo,
                            VmblCntdad = item.Vmbl_cntdad,
                            VmblTnldasMtrcas = item.Vmbl_tnldas_mtrcas,
                            UnidadMedidaCodigo = item.Um_cdgo?.ToString(),
                            UnidadMedidaNombre = item.Um_nmbre?.ToString(),
                            VisitaMotonaveDetalle = new MdloDtos.VisitaMotonaveDetalle
                            {

                                ImportadorRowId = item.Te_rowid?.ToString(),
                                ImportadorNombre = item.Te_nmbre?.ToString(),
                                ProductoCodigo = item.Pr_cdgo?.ToString(),
                                ProductoNombre = item.Pr_nmbre?.ToString(),
                                VmdRowidVstaMtnve = IdVisitaMotonave
                            }
                        };
                        //Recorremos todas las lineas
                        int? identificadorLevante = item.Lvnte_vmbl1_rowid;
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveBl1 levante = new MdloDtos.VisitaMotonaveBl1();
                        int contadorDocumento = 0;
                        if (identificadorLevante != null)
                        {
                            foreach (var linea in query)
                            {
                                if (identificadorLevante == linea.Lvnte_vmbl1_rowid)
                                {
                                    if (contadorDocumento == 0)
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };

                                        ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VmdoTrm = linea.Vmdo_trm,
                                            VmdoCstoSgroFlte = linea.Vmdo_csto_sgro_flte,
                                            VmdoArncelImprtcion = linea.Vmdo_arncel_imprtcion
                                            //VisitaMotonaveBl1 = levante
                                        };

                                        contadorDocumento++;
                                    }
                                    else
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };
                                        ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VmdoTrm = linea.Vmdo_trm,
                                            VmdoCstoSgroFlte = linea.Vmdo_csto_sgro_flte,
                                            VmdoArncelImprtcion = linea.Vmdo_arncel_imprtcion
                                            //VisitaMotonaveBl1 = levante
                                        };
                                        contadorDocumento++;
                                    }
                                }
                            }
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl = new List<LineaVisitaMotonaveBl>();
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl.Add(
                                new LineaVisitaMotonaveBl
                                {
                                    VisitaMotonaveDocumentoUno = ObjDocumento1,
                                    VisitaMotonaveDocumentoDos = ObjDocumento2,
                                    VisitaMotonaveBl1 = levante
                                });
                            saltarSiquienteIteraccion = true;
                        }
                        else
                        {
                            objVisitaMotonaveBl.ListaLineasVisitaMotonaveBl = new List<LineaVisitaMotonaveBl>();
                        }
                        listaVisitaMotonaveBl.Add(objVisitaMotonaveBl);
                        validadorRowId = (int)item.Vmbl_rowid;
                    }
                    else
                    {
                        int? identificadorLevante = item.Lvnte_vmbl1_rowid;
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveDocumento ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento();
                        MdloDtos.VisitaMotonaveBl1 levante = new MdloDtos.VisitaMotonaveBl1();
                        int contadorDocumento = 0;
                        if (identificadorLevante != null)
                        {
                            foreach (var linea in query)
                            {
                                if (identificadorLevante == linea.Lvnte_vmbl1_rowid)
                                {
                                    if (contadorDocumento == 0)
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };

                                        ObjDocumento1 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VisitaMotonaveBl1 = levante,
                                            VmdoTrm = linea.Vmdo_trm,
                                            VmdoCstoSgroFlte = linea.Vmdo_csto_sgro_flte,
                                            VmdoArncelImprtcion = linea.Vmdo_arncel_imprtcion
                                        };

                                        contadorDocumento++;
                                    }
                                    else
                                    {
                                        levante = new MdloDtos.VisitaMotonaveBl1
                                        {
                                            Vmbl1Rowid = linea.Lvnte_vmbl1_rowid,
                                            Vmbl1NmroLvnte = linea.Lvnte_vmbl1_nmro_lvnte,
                                            Vmbl1Lnea = linea.Vmdo_lnea
                                        };
                                        ObjDocumento2 = new MdloDtos.VisitaMotonaveDocumento
                                        {
                                            VmdoRowid = linea.Vmdo_rowid,
                                            VmdoCdgoTpoDcmnto = linea.Vmdo_cdgo_tpo_dcmnto,
                                            VmdoNmro = linea.Vmdo_nmro,
                                            VmdoRta = linea.Vmdo_rta,
                                            VmdoEstdo = linea.Vmdo_estdo,
                                            VmdoLnea = linea.Vmdo_lnea,
                                            VmdoCntdad = linea.Vmdo_cntdad,
                                            TipoDocumento = new MdloDtos.TipoDocumento
                                            {
                                                TdCdgo = linea.Vmdo_cdgo_tpo_dcmnto,
                                                TdNmbre = linea.Td_nmbre
                                            },
                                            VisitaMotonaveBl1 = levante,
                                            VmdoTrm = linea.Vmdo_trm,
                                            VmdoCstoSgroFlte = linea.Vmdo_csto_sgro_flte,
                                            VmdoArncelImprtcion = linea.Vmdo_arncel_imprtcion
                                        };
                                        contadorDocumento++;
                                    }
                                }
                            }
                            listaVisitaMotonaveBl.Last().ListaLineasVisitaMotonaveBl.Add(
                                new LineaVisitaMotonaveBl
                                {
                                    VisitaMotonaveDocumentoUno = ObjDocumento1,
                                    VisitaMotonaveDocumentoDos = ObjDocumento2,
                                    VisitaMotonaveBl1 = levante
                                });
                            saltarSiquienteIteraccion = true;
                        }
                        validadorRowId = (int)item.Vmbl_rowid;
                    }
                }

                _dbContex.Dispose();
                return listaVisitaMotonaveBl;
            }
        }
        #endregion
    }
}
