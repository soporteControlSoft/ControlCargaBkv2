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

namespace AccsoDtos.SituacionPortuaria
{
    /// <summary>
    /// CRUD para el manejo de situación portuaria detalle
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class SituacionPortuariaDetalle : MdloDtos.IModelos.ISituacionPortuariaDetalle
    {
        #region ingreso de datos a la entidad SituacionPortuariaDetalle
        public async Task<MdloDtos.SituacionPortuariaDetalle> IngresarSituacionPortuariaDetalle(MdloDtos.SituacionPortuariaDetalle _SituacionPortuariaDetalle)
        {
            var ObjSituacionPortuariaDetalle = new MdloDtos.SituacionPortuariaDetalle();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    ObjSituacionPortuariaDetalle.SpdRowidStcionPrtria = _SituacionPortuariaDetalle.SpdRowidStcionPrtria;
                    ObjSituacionPortuariaDetalle.SpdRowidTrcro = _SituacionPortuariaDetalle.SpdRowidTrcro;
                    ObjSituacionPortuariaDetalle.SdpCdgoPrdcto = _SituacionPortuariaDetalle.SdpCdgoPrdcto;
                    ObjSituacionPortuariaDetalle.SdpTmBl = _SituacionPortuariaDetalle.SdpTmBl;
                    ObjSituacionPortuariaDetalle.SpdCdgoUndadMdda = _SituacionPortuariaDetalle.SpdCdgoUndadMdda;
                    ObjSituacionPortuariaDetalle.SpdCntdad = _SituacionPortuariaDetalle.SpdCntdad;
                    ObjSituacionPortuariaDetalle.SpdRowidOprdorPrtrio = _SituacionPortuariaDetalle.SpdRowidOprdorPrtrio;

                    var res = await _dbContex.SituacionPortuariaDetalles.AddAsync(ObjSituacionPortuariaDetalle);
                    await _dbContex.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSituacionPortuariaDetalle;
            }
        }
        #endregion

        #region verificar la existencia de una SituacionPortuariaDetalle validando idSituacionPortuaria, idTercero, CodigoProducto los cuales deben ser unicos
        public async Task<bool> VerificarSituacionPortuariaDetalle(MdloDtos.SituacionPortuariaDetalle _SituacionPortuariaDetalle)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjSituacionPortuariaDetalles = await (from spd in _dbContex.SituacionPortuariaDetalles
                                                               where spd.SpdRowidTrcro == _SituacionPortuariaDetalle.SpdRowidTrcro &&
                                                                      spd.SdpCdgoPrdcto == _SituacionPortuariaDetalle.SdpCdgoPrdcto &&
                                                                      spd.SpdRowidStcionPrtria == _SituacionPortuariaDetalle.SpdRowidStcionPrtria
                                                               select spd
                                 ).ToListAsync();
                    if (ObjSituacionPortuariaDetalles.Count == 0)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        respuesta = true;
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

        #region verificar la existencia de una SituacionPortuariaDetalle validando idSituacionPortuaria, idTercero, CodigoProducto los cuales deben ser unicos
        public async Task<bool> ValidarExistenciaSituacionPortuariaDetalleEspecifico(MdloDtos.SituacionPortuariaDetalle _SituacionPortuariaDetalle)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjSituacionPortuariaDetalles = await (from spd in _dbContex.SituacionPortuariaDetalles
                                                               where spd.SpdRowid == _SituacionPortuariaDetalle.SpdRowid
                                                               select spd
                    ).ToListAsync();
                    if (ObjSituacionPortuariaDetalles.Count == 0)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        respuesta = true;
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

        #region verificar las relaciones de SituacionPortuariaDetalle validando  SpdRowidTrcro, SdpCdgoPrdcto , SpdRowidStcionPrtria
        public async Task<bool> VerificarSituacionPortuariaDetalleRelaciones(MdloDtos.SituacionPortuariaDetalle _SituacionPortuariaDetalle)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TercerosExiste = await _dbContex.Terceros.FindAsync(_SituacionPortuariaDetalle.SpdRowidTrcro);
                    var ProductosExiste = await _dbContex.Productos.FindAsync(_SituacionPortuariaDetalle.SdpCdgoPrdcto);
                    var SituacionPortuariaExiste = await _dbContex.SituacionPortuaria.FindAsync(_SituacionPortuariaDetalle.SpdRowidStcionPrtria);
                    if (TercerosExiste == null || ProductosExiste == null || SituacionPortuariaExiste == null)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        respuesta = true;
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

        #region Consultar todos los datos de Situacion Portuaria Detalle  mediante un parametro (IdSituacionPortuaria) para buscar todos los detalle de una Situacion Portuaria en especifico.
        public async Task<List<MdloDtos.SituacionPortuariaDetalle>> FiltrarSituacionPortuariaDetallePorIdSituacionPortuaria(int IdSituacionPortuaria)
        {
            List<MdloDtos.SituacionPortuariaDetalle> listSituacionPortuariaDetalle = new List<MdloDtos.SituacionPortuariaDetalle>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from stcionPortuariaDtlle in _dbContex.SituacionPortuariaDetalles
                                 join trcro in _dbContex.Terceros on stcionPortuariaDtlle.SpdRowidTrcro equals trcro.TeRowid into trcroJoin
                                    from trcro in trcroJoin.DefaultIfEmpty()
                                 join prdcto in _dbContex.Productos on stcionPortuariaDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo into prdctoJoin
                                    from prdcto in prdctoJoin.DefaultIfEmpty()
                                 join undad in _dbContex.UnidadMedida on stcionPortuariaDtlle.SpdCdgoUndadMdda equals undad.UmCdgo into undadJoin
                                    from undad in undadJoin.DefaultIfEmpty()
                                 join oprdorPrtrio in _dbContex.Terceros on stcionPortuariaDtlle.SpdRowidOprdorPrtrio equals oprdorPrtrio.TeRowid into oprdorPrtrioJoin
                                    from oprdorPrtrio in oprdorPrtrioJoin.DefaultIfEmpty()

                                 where stcionPortuariaDtlle.SpdRowidStcionPrtria == IdSituacionPortuaria
                                 select new
                                 {
                                     //SituacionPortuariaDetalle
                                     stcionPortuariaDtlle.SpdRowid,
                                     stcionPortuariaDtlle.SpdRowidStcionPrtria,
                                     stcionPortuariaDtlle.SpdRowidTrcro,
                                     stcionPortuariaDtlle.SdpCdgoPrdcto,
                                     stcionPortuariaDtlle.SdpTmBl,
                                     stcionPortuariaDtlle.SpdCdgoUndadMdda,
                                     stcionPortuariaDtlle.SpdCntdad,
                                     stcionPortuariaDtlle.SpdRowidOprdorPrtrio,

                                     // Datos de Terceros
                                     RowidTercero= trcro.TeRowid,
                                     CdgoTercero = trcro.TeCdgo,
                                     NombreTercero =trcro.TeNmbre,

                                     // Datos de Productos
                                     prdcto.PrCdgo,
                                     prdcto.PrNmbre,

                                     // Datos de Unidad de Medida
                                     undad.UmCdgo,
                                     undad.UmNmbre,

                                     //OperadorPortuario
                                     RowIdOprdorPrtrio = oprdorPrtrio.TeRowid,
                                     CdgoOprdorPrtrio = oprdorPrtrio.TeCdgo,
                                     NmbrOprdorPrtrio = oprdorPrtrio.TeNmbre,
                                     MnjoPrpioOprdorPrtrio = oprdorPrtrio.TeMnjoPrpio,

                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    listSituacionPortuariaDetalle.Add(
                        new MdloDtos.SituacionPortuariaDetalle
                        {
                            SpdRowid = (int)item.SpdRowid,
                            SpdRowidStcionPrtria = item.SpdRowidStcionPrtria,
                            SpdRowidTrcro = item.SpdRowidTrcro,
                            SdpCdgoPrdcto = item.SdpCdgoPrdcto,
                            SdpTmBl = item.SdpTmBl,
                            SpdCdgoUndadMdda = item.SpdCdgoUndadMdda,
                            SpdCntdad = item.SpdCntdad,
                            SpdRowidOprdorPrtrio = item.SpdRowidOprdorPrtrio,
                            UnidadMedidaCodigo = item.UmCdgo != null ? item.UmCdgo : string.Empty,
                            UnidadMedidaDescripcion = item.UmNmbre != null ? item.UmNmbre : string.Empty,
                            ProductoCodigo = item.PrCdgo != null ? item.UmNmbre : string.Empty,
                            ProductoNombre = item.PrNmbre != null ? item.PrNmbre : string.Empty,
                            TerceroCodigo = item.RowidTercero.ToString() != null ? item.RowidTercero.ToString() : string.Empty,
                            TerceroNombre = item.NombreTercero != null ? item.NombreTercero : string.Empty,
                            SdpCdgoPrdctoNavigation = new MdloDtos.Producto
                            {
                                PrCdgo = item.PrCdgo,
                                PrNmbre = item.PrNmbre
                            },
                            SpdCdgoUndadMddaNavigation = new MdloDtos.UnidadMedidum
                            {
                                UmCdgo = item.UmCdgo,
                                UmNmbre = item.UmNmbre
                            },
                            SpdRowidOprdorPrtrioNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.RowIdOprdorPrtrio,
                                TeCdgo = item.CdgoOprdorPrtrio,
                                TeNmbre = item.NmbrOprdorPrtrio,
                                TeMnjoPrpio = item.MnjoPrpioOprdorPrtrio
                            },
                            SpdRowidTrcroNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.RowidTercero,
                                TeCdgo = item.CdgoTercero,
                                TeNmbre = item.NombreTercero
                                
                            }
                        });
                }
                _dbContex.Dispose();
                return listSituacionPortuariaDetalle;
            }
        }
        #endregion

        #region consulta una situacion portuaria detalle especifica según el id 
        public async Task<MdloDtos.SituacionPortuariaDetalle> FiltrarSituacionPortuariaDetalleEspecifico(int IdSituacionPortuariaDetalle)
        {
            var situacionPortuariaDetalle = new MdloDtos.SituacionPortuariaDetalle();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from stcionPortuariaDtlle in _dbContex.SituacionPortuariaDetalles
                                 join trcro in _dbContex.Terceros on stcionPortuariaDtlle.SpdRowidTrcro equals trcro.TeRowid into trcroJoin
                                    from trcro in trcroJoin.DefaultIfEmpty()
                                 join prdcto in _dbContex.Productos on stcionPortuariaDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo into prdctoJoin
                                    from prdcto in prdctoJoin.DefaultIfEmpty()
                                 join undad in _dbContex.UnidadMedida on stcionPortuariaDtlle.SpdCdgoUndadMdda equals undad.UmCdgo into undadJoin
                                    from undad in undadJoin.DefaultIfEmpty()
                                 join oprdorPrtrio in _dbContex.Terceros on stcionPortuariaDtlle.SpdRowidOprdorPrtrio equals oprdorPrtrio.TeRowid into oprdorPrtrioJoin
                                    from oprdorPrtrio in oprdorPrtrioJoin.DefaultIfEmpty()

                                 where stcionPortuariaDtlle.SpdRowid == IdSituacionPortuariaDetalle
                                 select new
                                 {
                                     //SituacionPortuariaDetalle
                                     stcionPortuariaDtlle.SpdRowid,
                                     stcionPortuariaDtlle.SpdRowidStcionPrtria,
                                     stcionPortuariaDtlle.SpdRowidTrcro,
                                     stcionPortuariaDtlle.SdpCdgoPrdcto,
                                     stcionPortuariaDtlle.SdpTmBl,
                                     stcionPortuariaDtlle.SpdCdgoUndadMdda,
                                     stcionPortuariaDtlle.SpdCntdad,
                                     stcionPortuariaDtlle.SpdRowidOprdorPrtrio,

                                     // Datos de Terceros
                                     RowidTercero = trcro.TeRowid,
                                     CdgoTercero = trcro.TeCdgo,
                                     NombreTercero = trcro.TeNmbre,

                                     // Datos de Productos
                                     prdcto.PrCdgo,
                                     prdcto.PrNmbre,

                                     // Datos de Unidad de Medida
                                     undad.UmCdgo,
                                     undad.UmNmbre,

                                     //OperadorPortuario
                                     RowIdOprdorPrtrio = oprdorPrtrio.TeRowid,
                                     CdgoOprdorPrtrio = oprdorPrtrio.TeCdgo,
                                     NmbrOprdorPrtrio = oprdorPrtrio.TeNmbre,
                                     MnjoPrpioOprdorPrtrio = oprdorPrtrio.TeMnjoPrpio,
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {

                    situacionPortuariaDetalle = new MdloDtos.SituacionPortuariaDetalle
                                                {
                                                    SpdRowid = (int)item.SpdRowid,
                                                    SpdRowidStcionPrtria = item.SpdRowidStcionPrtria,
                                                    SpdRowidTrcro = item.SpdRowidTrcro,
                                                    SdpCdgoPrdcto = item.SdpCdgoPrdcto,
                                                    SdpTmBl = item.SdpTmBl,
                                                    SpdCdgoUndadMdda = item.SpdCdgoUndadMdda,
                                                    SpdCntdad = item.SpdCntdad,
                                                    SpdRowidOprdorPrtrio = item.SpdRowidOprdorPrtrio,
                                                    UnidadMedidaCodigo = item.UmCdgo != null ? item.UmCdgo : string.Empty,
                                                    UnidadMedidaDescripcion = item.UmNmbre != null ? item.UmNmbre : string.Empty,
                                                    ProductoCodigo = item.PrCdgo != null ? item.UmNmbre : string.Empty,
                                                    ProductoNombre = item.PrNmbre != null ? item.PrNmbre : string.Empty,
                                                    TerceroCodigo = item.RowidTercero.ToString() != null ? item.RowidTercero.ToString() : string.Empty,
                                                    TerceroNombre = item.NombreTercero != null ? item.NombreTercero : string.Empty,
                                                    SdpCdgoPrdctoNavigation = new MdloDtos.Producto
                                                    {
                                                        PrCdgo = item.PrCdgo,
                                                        PrNmbre = item.PrNmbre
                                                    },
                                                    SpdCdgoUndadMddaNavigation = new MdloDtos.UnidadMedidum
                                                    {
                                                        UmCdgo = item.UmCdgo,
                                                        UmNmbre = item.UmNmbre
                                                    },
                                                    SpdRowidOprdorPrtrioNavigation = new MdloDtos.Tercero
                                                    {
                                                        TeRowid = item.RowIdOprdorPrtrio,
                                                        TeCdgo = item.CdgoOprdorPrtrio,
                                                        TeNmbre = item.NmbrOprdorPrtrio,
                                                        TeMnjoPrpio = item.MnjoPrpioOprdorPrtrio
                                                    },
                                                    SpdRowidTrcroNavigation = new MdloDtos.Tercero
                                                    {
                                                        TeRowid = item.RowidTercero,
                                                        TeCdgo = item.CdgoTercero,
                                                        TeNmbre = item.NombreTercero
                                                    }
                                                };
                }
                return situacionPortuariaDetalle;
            }
        }
        #endregion

        #region consulta todas las  situacion portuaria detalle creadas
        public async Task<List<MdloDtos.SituacionPortuariaDetalle>> consultarSituacionPortuariaDetalle()
        {


            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuariaDetalle> listaSituacionPortuariaDetalle = new List<MdloDtos.SituacionPortuariaDetalle>();

                var lst = await (from stcionPortuariaDtlle in _dbContex.SituacionPortuariaDetalles
                                 join trcro in _dbContex.Terceros on stcionPortuariaDtlle.SpdRowidTrcro equals trcro.TeRowid into trcroJoin
                                    from trcro in trcroJoin.DefaultIfEmpty()
                                 join prdcto in _dbContex.Productos on stcionPortuariaDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo into prdctoJoin
                                    from prdcto in prdctoJoin.DefaultIfEmpty()
                                 join undad in _dbContex.UnidadMedida on stcionPortuariaDtlle.SpdCdgoUndadMdda equals undad.UmCdgo into undadJoin
                                    from undad in undadJoin.DefaultIfEmpty()
                                 join oprdorPrtrio in _dbContex.Terceros on stcionPortuariaDtlle.SpdRowidOprdorPrtrio equals oprdorPrtrio.TeRowid into oprdorPrtrioJoin
                                    from oprdorPrtrio in oprdorPrtrioJoin.DefaultIfEmpty()
                                 select new
                                 {
                                     //SituacionPortuariaDetalle
                                     stcionPortuariaDtlle.SpdRowid,
                                     stcionPortuariaDtlle.SpdRowidStcionPrtria,
                                     stcionPortuariaDtlle.SpdRowidTrcro,
                                     stcionPortuariaDtlle.SdpCdgoPrdcto,
                                     stcionPortuariaDtlle.SdpTmBl,
                                     stcionPortuariaDtlle.SpdCdgoUndadMdda,
                                     stcionPortuariaDtlle.SpdCntdad,
                                     stcionPortuariaDtlle.SpdRowidOprdorPrtrio,

                                     // Datos de Terceros
                                     RowidTercero = trcro.TeRowid,
                                     CdgoTercero = trcro.TeCdgo,
                                     NombreTercero = trcro.TeNmbre,

                                     // Datos de Productos
                                     prdcto.PrCdgo,
                                     prdcto.PrNmbre,

                                     // Datos de Unidad de Medida
                                     undad.UmCdgo,
                                     undad.UmNmbre,

                                     //OperadorPortuario
                                     RowIdOprdorPrtrio = oprdorPrtrio.TeRowid,
                                     CdgoOprdorPrtrio = oprdorPrtrio.TeCdgo,
                                     NmbrOprdorPrtrio = oprdorPrtrio.TeNmbre,
                                     MnjoPrpioOprdorPrtrio = oprdorPrtrio.TeMnjoPrpio
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    listaSituacionPortuariaDetalle.Add(
                                           new MdloDtos.SituacionPortuariaDetalle
                                           {
                                               SpdRowid = (int)item.SpdRowid,
                                               SpdRowidStcionPrtria = item.SpdRowidStcionPrtria,
                                               SpdRowidTrcro = item.SpdRowidTrcro,
                                               SdpCdgoPrdcto = item.SdpCdgoPrdcto,
                                               SdpTmBl = item.SdpTmBl,
                                               SpdCdgoUndadMdda = item.SpdCdgoUndadMdda,
                                               SpdCntdad = item.SpdCntdad,
                                               SpdRowidOprdorPrtrio = item.SpdRowidOprdorPrtrio,
                                               UnidadMedidaCodigo = item.UmCdgo != null ? item.UmCdgo : string.Empty,
                                               UnidadMedidaDescripcion = item.UmNmbre != null ? item.UmNmbre : string.Empty,
                                               ProductoCodigo = item.PrCdgo != null ? item.UmNmbre : string.Empty,
                                               ProductoNombre = item.PrNmbre != null ? item.PrNmbre : string.Empty,
                                               TerceroCodigo = item.RowidTercero.ToString() != null ? item.RowidTercero.ToString() : string.Empty,
                                               TerceroNombre = item.NombreTercero != null ? item.NombreTercero : string.Empty,
                                               SdpCdgoPrdctoNavigation = new MdloDtos.Producto
                                               {
                                                   PrCdgo = item.PrCdgo,
                                                   PrNmbre = item.PrNmbre
                                               },
                                               SpdCdgoUndadMddaNavigation = new MdloDtos.UnidadMedidum
                                               {
                                                   UmCdgo = item.UmCdgo,
                                                   UmNmbre = item.UmNmbre,
                                               },
                                               SpdRowidOprdorPrtrioNavigation = new MdloDtos.Tercero
                                               {
                                                   TeRowid = item.RowIdOprdorPrtrio,
                                                   TeCdgo = item.CdgoOprdorPrtrio,
                                                   TeNmbre = item.NmbrOprdorPrtrio,
                                                   TeMnjoPrpio = item.MnjoPrpioOprdorPrtrio
                                               },
                                               SpdRowidTrcroNavigation = new MdloDtos.Tercero
                                               {
                                                   TeRowid = item.RowidTercero,
                                                   TeCdgo = item.CdgoTercero,
                                                   TeNmbre = item.NombreTercero
                                               }
                                           });
                }
                _dbContex.Dispose();
                return listaSituacionPortuariaDetalle;
            }
        }
        #endregion

        #region  elimina una situacion portuaria detalle especifica según el id del mismo
        public async Task<MdloDtos.SituacionPortuariaDetalle> EliminarSituacionPortuariaDetalleEspecifico(MdloDtos.SituacionPortuariaDetalle _SituacionPortuariaDetalle)
        {
            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var SituacionPortuariaDetalleExiste = await _dbContext.SituacionPortuariaDetalles.FindAsync(_SituacionPortuariaDetalle.SpdRowid);
                    if (SituacionPortuariaDetalleExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContext.Remove(SituacionPortuariaDetalleExiste);
                        await _dbContext.SaveChangesAsync();
                    }
                    _dbContext.Dispose();
                    return SituacionPortuariaDetalleExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }
        #endregion

        #region elimina todas las situaciones portuarias detalles  según el id de la situacion portuaria (encabezado)
        public async Task<bool> EliminarSituacionPortuariaDetallePorIdSituacionPortuaria(MdloDtos.SituacionPortuarium ObjSituacionPortuarium)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var situacionPortuariumExiste = await _dbContext.SituacionPortuaria.FindAsync(ObjSituacionPortuarium.SpRowid);
                    if (situacionPortuariumExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        var resultado = (from p in _dbContext.SituacionPortuariaDetalles
                                         where p.SpdRowidStcionPrtria == ObjSituacionPortuarium.SpRowid
                                         select p).Count();
                        if (resultado > 0)
                        {
                            var SituacionPortuariaDetallesExiste_ = (from p in _dbContext.SituacionPortuariaDetalles
                                                                     where p.SpdRowidStcionPrtria == ObjSituacionPortuarium.SpRowid
                                                                     select p).ToList();
                            foreach (var item in SituacionPortuariaDetallesExiste_)
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

        #region Actualizar SituacionPortuariaDetalle pasando el objeto _SituacionPortuariaDetalle
        public async Task<MdloDtos.SituacionPortuariaDetalle> EditarSituacionPortuariaDetalle(MdloDtos.SituacionPortuariaDetalle _SituacionPortuariaDetalle)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SituacionPortuariaDetalle SituacionPortuariaDetalleExiste = await _dbContex.SituacionPortuariaDetalles.FindAsync(_SituacionPortuariaDetalle.SpdRowid);
                    if (SituacionPortuariaDetalleExiste != null)
                    {
                        SituacionPortuariaDetalleExiste.SpdRowid = _SituacionPortuariaDetalle.SpdRowid;
                        SituacionPortuariaDetalleExiste.SpdRowidStcionPrtria = _SituacionPortuariaDetalle.SpdRowidStcionPrtria;
                        SituacionPortuariaDetalleExiste.SpdRowidTrcro = _SituacionPortuariaDetalle.SpdRowidTrcro;
                        SituacionPortuariaDetalleExiste.SdpCdgoPrdcto = _SituacionPortuariaDetalle.SdpCdgoPrdcto;
                        SituacionPortuariaDetalleExiste.SdpTmBl = _SituacionPortuariaDetalle.SdpTmBl;
                        SituacionPortuariaDetalleExiste.SpdCdgoUndadMdda = _SituacionPortuariaDetalle.SpdCdgoUndadMdda;
                        SituacionPortuariaDetalleExiste.SpdCntdad = _SituacionPortuariaDetalle.SpdCntdad;
                        SituacionPortuariaDetalleExiste.SpdRowidOprdorPrtrio = _SituacionPortuariaDetalle.SpdRowidOprdorPrtrio;
                        _dbContex.Entry(SituacionPortuariaDetalleExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return SituacionPortuariaDetalleExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

    }
}
