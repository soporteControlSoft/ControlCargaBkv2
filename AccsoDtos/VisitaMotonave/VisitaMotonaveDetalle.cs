using AccsoDtos.Parametrizacion;
using AccsoDtos.SituacionPortuaria;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccsoDtos.VisitaMotonave
{
    /// <summary>
    /// CRUD para el manejo de visita motonave detalle
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class VisitaMotonaveDetalle : MdloDtos.IModelos.IVisitaMotonaveDetalle
    {
       
        #region Consultar todos los datos de Visita Motonave Detalle  mediante un parametro (IdVisitaMotonave) para buscar todos los detalle de una visita motonave en especifico.
        public async Task<List<MdloDtos.VisitaMotonaveDetalle>> FiltrarVisitaMotonaveDetallePorIdVisitaMotonave(int IdVisitaMotonave)
        {
            List<MdloDtos.VisitaMotonaveDetalle> listVisitaMotonaveDetalle = new List<MdloDtos.VisitaMotonaveDetalle>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from vstaMtnveDtlle in _dbContex.VisitaMotonaveDetalles

                                 join agnciaAdna in _dbContex.Terceros on vstaMtnveDtlle.VmdRowidAgnciaAdna equals agnciaAdna.TeRowid into agnciaAdnaJoin
                                    from agnciaAdna in agnciaAdnaJoin.DefaultIfEmpty()

                                 join stcionPrtriaDtlle in _dbContex.SituacionPortuariaDetalles on vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle equals stcionPrtriaDtlle.SpdRowid into stcionPrtriaDtlleJoin
                                    from stcionPrtriaDtlle in stcionPrtriaDtlleJoin.DefaultIfEmpty()

                                 join trcro in _dbContex.Terceros on stcionPrtriaDtlle.SpdRowidTrcro equals trcro.TeRowid into trcroJoin
                                    from trcro in trcroJoin.DefaultIfEmpty()

                                 join prdcto in _dbContex.Productos on stcionPrtriaDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo into prdctoJoin
                                    from prdcto in prdctoJoin.DefaultIfEmpty()

                                 join oprdorPrtrioSPDtlle in _dbContex.Terceros on stcionPrtriaDtlle.SpdRowidOprdorPrtrio equals oprdorPrtrioSPDtlle.TeRowid into oprdorPrtrioSPDtlleJoin
                                    from oprdorPrtrioSPDtlle in oprdorPrtrioSPDtlleJoin.DefaultIfEmpty()

                                 join undadMdda in _dbContex.UnidadMedida on stcionPrtriaDtlle.SpdCdgoUndadMdda  equals undadMdda.UmCdgo   into undadMddaJoin
                                    from undadMdda in undadMddaJoin.DefaultIfEmpty()

                                 where vstaMtnveDtlle.VmdRowidVstaMtnve == IdVisitaMotonave
                                 select new
                                 {
                                    vstaMtnveDtlle.VmdRowid,
                                    vstaMtnveDtlle.VmdRowidVstaMtnve,
                                    vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle,
                                    vstaMtnveDtlle.VmdRowidAgnciaAdna,
                                     
                                    TeRowidAgnciaAdna = agnciaAdna.TeRowid,
                                    TeCdgoCiaAgnciaAdna = agnciaAdna.TeCdgoCia,
                                    TeCdgoAgnciaAdna = agnciaAdna.TeCdgo,
                                    TeNmbreAgnciaAdna = agnciaAdna.TeNmbre,
                                    TeIdntfccionAgnciaAdna = agnciaAdna.TeIdntfccion,
                                    TeTpoIdntfccionAgnciaAdna = agnciaAdna.TeTpoIdntfccion,
                                    TeDvAgnciaAdna = agnciaAdna.TeDv,
                                    TeCdgoGrpoTrcroAgnciaAdna = agnciaAdna.TeCdgoGrpoTrcro,

                                    stcionPrtriaDtlle.SpdRowid,
                                    stcionPrtriaDtlle.SpdRowidStcionPrtria,
                                    stcionPrtriaDtlle.SpdRowidTrcro,
                                    stcionPrtriaDtlle.SdpCdgoPrdcto,
                                    stcionPrtriaDtlle.SdpTmBl,
                                    stcionPrtriaDtlle.SpdCdgoUndadMdda,
                                    stcionPrtriaDtlle.SpdCntdad,
                                    stcionPrtriaDtlle.SpdRowidOprdorPrtrio,

                                    TeRowidTrcro = trcro.TeRowid,
                                    TeCdgoCiaTrcro = trcro.TeCdgoCia,
                                    TeCdgoTrcro = trcro.TeCdgo,
                                    TeNmbreTrcro = trcro.TeNmbre,
                                    TeIdntfccionTrcro = trcro.TeIdntfccion,
                                    TeTpoIdntfccionTrcro = trcro.TeTpoIdntfccion,
                                    TeDvTrcro = trcro.TeDv,
                                    TeCdgoGrpoTrcroTrcro = trcro.TeCdgoGrpoTrcro,
                                     
                                    prdcto.PrCdgo,
                                    prdcto.PrNmbre,

                                    TeRowidTrcroOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeRowid,
                                    TeCdgoCiaOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgoCia,
                                    TeCdgoOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgo,
                                    TeNmbreOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeNmbre,
                                    TeIdntfccionOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeIdntfccion,
                                    TeTpoIdntfccionOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeTpoIdntfccion,
                                    TeDvOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeDv,
                                    TeCdgoGrpoTrcroOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgoGrpoTrcro,

                                    undadMdda.UmCdgo,
                                    undadMdda.UmNmbre,
                                    undadMdda.UmGrnel,
                                    undadMdda.UmActvo
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    listVisitaMotonaveDetalle.Add(new MdloDtos.VisitaMotonaveDetalle
                    {
                        VmdRowid= item.VmdRowid,
                        VmdRowidVstaMtnve= item.VmdRowidVstaMtnve,
                        VmdRowidStcionPrtriaDtlle = item.VmdRowidStcionPrtriaDtlle,
                        VmdRowidAgnciaAdna = item.VmdRowidAgnciaAdna,
                        VmdRowidAgnciaAdnaNavigation= new MdloDtos.Tercero 
                        {
                            TeRowid= item.TeRowidAgnciaAdna ,
                            TeCdgoCia = item.TeCdgoCiaAgnciaAdna ,
                            TeCdgo = item.TeCdgoAgnciaAdna ,
                            TeNmbre = item.TeNmbreAgnciaAdna,
                            TeIdntfccion = item.TeIdntfccionAgnciaAdna,
                            TeTpoIdntfccion = item.TeTpoIdntfccionAgnciaAdna,
                            TeDv = item.TeDvAgnciaAdna,
                            TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroAgnciaAdna
                        },
                        VmdRowidStcionPrtriaDtlleNavigation = new MdloDtos.SituacionPortuariaDetalle
                        {
                            SpdRowid= item.SpdRowid,
                            SpdRowidStcionPrtria = item.SpdRowidStcionPrtria,
                            SpdRowidTrcro = item.SpdRowidTrcro,
                            SdpCdgoPrdcto = item.SdpCdgoPrdcto,
                            SdpTmBl = item.SdpTmBl,
                            SpdCdgoUndadMdda = item.SpdCdgoUndadMdda,
                            SpdCntdad = item.SpdCntdad,
                            SpdRowidOprdorPrtrio = item.SpdRowidOprdorPrtrio,
                            SpdRowidTrcroNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.TeRowidTrcro,
                                TeCdgoCia = item.TeCdgoCiaTrcro,
                                TeCdgo = item.TeCdgoTrcro,
                                TeNmbre = item.TeNmbreTrcro,
                                TeIdntfccion = item.TeIdntfccionTrcro,
                                TeTpoIdntfccion = item.TeTpoIdntfccionTrcro,
                                TeDv = item.TeDvTrcro,
                                TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroTrcro
                            },
                            SdpCdgoPrdctoNavigation = new MdloDtos.Producto
                            {
                                PrCdgo = item.PrCdgo,
                                PrNmbre = item.PrNmbre,
                            },
                            SpdRowidOprdorPrtrioNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.TeRowidTrcroOprdorPrtrioSPDtlle,
                                TeCdgoCia = item.TeCdgoCiaOprdorPrtrioSPDtlle,
                                TeCdgo = item.TeCdgoOprdorPrtrioSPDtlle,
                                TeNmbre = item.TeNmbreOprdorPrtrioSPDtlle,
                                TeIdntfccion = item.TeIdntfccionOprdorPrtrioSPDtlle,
                                TeTpoIdntfccion = item.TeTpoIdntfccionOprdorPrtrioSPDtlle,
                                TeDv = item.TeDvOprdorPrtrioSPDtlle,
                                TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroOprdorPrtrioSPDtlle
                            },
                            SpdCdgoUndadMddaNavigation =new MdloDtos.UnidadMedidum
                            {
                                UmCdgo = item.UmCdgo,
                                UmNmbre = item.UmNmbre,
                                UmGrnel = item.UmGrnel,
                                UmActvo = item.UmActvo
                            },
                            ProductoCodigo= item.PrCdgo,
                            ProductoNombre = item.PrNmbre,
                            TerceroCodigo =item.TeRowidTrcro != null ? ""+ item.TeRowidTrcro : "",
                            TerceroNombre = item.TeNmbreTrcro,
                            UnidadMedidaCodigo = item.UmCdgo,
                            UnidadMedidaDescripcion = item.UmNmbre
                        }
                    });
                }
                _dbContex.Dispose();
                return listVisitaMotonaveDetalle;
            }
        }
        #endregion

        #region consulta una visita motonave detalle especifica según el RowId
        public async Task<List<MdloDtos.VisitaMotonaveDetalle>> FiltrarVisitaMotonaveDetalleEspecifico(int IdVisitaMotonaveDetalle)
        {
            List<MdloDtos.VisitaMotonaveDetalle> listaVisitaMotonaveDetalle = new List<MdloDtos.VisitaMotonaveDetalle>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from vstaMtnveDtlle in _dbContex.VisitaMotonaveDetalles

                                 join agnciaAdna in _dbContex.Terceros on vstaMtnveDtlle.VmdRowidAgnciaAdna equals agnciaAdna.TeRowid into agnciaAdnaJoin
                                 from agnciaAdna in agnciaAdnaJoin.DefaultIfEmpty()

                                 join stcionPrtriaDtlle in _dbContex.SituacionPortuariaDetalles on vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle equals stcionPrtriaDtlle.SpdRowid into stcionPrtriaDtlleJoin
                                 from stcionPrtriaDtlle in stcionPrtriaDtlleJoin.DefaultIfEmpty()

                                 join trcro in _dbContex.Terceros on stcionPrtriaDtlle.SpdRowidTrcro equals trcro.TeRowid into trcroJoin
                                 from trcro in trcroJoin.DefaultIfEmpty()

                                 join prdcto in _dbContex.Productos on stcionPrtriaDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo into prdctoJoin
                                 from prdcto in prdctoJoin.DefaultIfEmpty()

                                 join oprdorPrtrioSPDtlle in _dbContex.Terceros on stcionPrtriaDtlle.SpdRowidOprdorPrtrio equals oprdorPrtrioSPDtlle.TeRowid into oprdorPrtrioSPDtlleJoin
                                 from oprdorPrtrioSPDtlle in oprdorPrtrioSPDtlleJoin.DefaultIfEmpty()

                                 join undadMdda in _dbContex.UnidadMedida on stcionPrtriaDtlle.SpdCdgoUndadMdda equals undadMdda.UmCdgo into undadMddaJoin
                                 from undadMdda in undadMddaJoin.DefaultIfEmpty()

                                 where vstaMtnveDtlle.VmdRowid == IdVisitaMotonaveDetalle
                                 select new
                                 {
                                     vstaMtnveDtlle.VmdRowid,
                                     vstaMtnveDtlle.VmdRowidVstaMtnve,
                                     vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle,
                                     vstaMtnveDtlle.VmdRowidAgnciaAdna,

                                     TeRowidAgnciaAdna = agnciaAdna.TeRowid,
                                     TeCdgoCiaAgnciaAdna = agnciaAdna.TeCdgoCia,
                                     TeCdgoAgnciaAdna = agnciaAdna.TeCdgo,
                                     TeNmbreAgnciaAdna = agnciaAdna.TeNmbre,
                                     TeIdntfccionAgnciaAdna = agnciaAdna.TeIdntfccion,
                                     TeTpoIdntfccionAgnciaAdna = agnciaAdna.TeTpoIdntfccion,
                                     TeDvAgnciaAdna = agnciaAdna.TeDv,
                                     TeCdgoGrpoTrcroAgnciaAdna = agnciaAdna.TeCdgoGrpoTrcro,

                                     stcionPrtriaDtlle.SpdRowid,
                                     stcionPrtriaDtlle.SpdRowidStcionPrtria,
                                     stcionPrtriaDtlle.SpdRowidTrcro,
                                     stcionPrtriaDtlle.SdpCdgoPrdcto,
                                     stcionPrtriaDtlle.SdpTmBl,
                                     stcionPrtriaDtlle.SpdCdgoUndadMdda,
                                     stcionPrtriaDtlle.SpdCntdad,
                                     stcionPrtriaDtlle.SpdRowidOprdorPrtrio,

                                     TeRowidTrcro = trcro.TeRowid,
                                     TeCdgoCiaTrcro = trcro.TeCdgoCia,
                                     TeCdgoTrcro = trcro.TeCdgo,
                                     TeNmbreTrcro = trcro.TeNmbre,
                                     TeIdntfccionTrcro = trcro.TeIdntfccion,
                                     TeTpoIdntfccionTrcro = trcro.TeTpoIdntfccion,
                                     TeDvTrcro = trcro.TeDv,
                                     TeCdgoGrpoTrcroTrcro = trcro.TeCdgoGrpoTrcro,

                                     prdcto.PrCdgo,
                                     prdcto.PrNmbre,

                                     TeRowidTrcroOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeRowid,
                                     TeCdgoCiaOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgoCia,
                                     TeCdgoOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgo,
                                     TeNmbreOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeNmbre,
                                     TeIdntfccionOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeIdntfccion,
                                     TeTpoIdntfccionOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeTpoIdntfccion,
                                     TeDvOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeDv,
                                     TeCdgoGrpoTrcroOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgoGrpoTrcro,

                                     undadMdda.UmCdgo,
                                     undadMdda.UmNmbre,
                                     undadMdda.UmGrnel,
                                     undadMdda.UmActvo
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                if(lst.Count > 0) 
                {
                    foreach (var item in lst)
                    {
                        listaVisitaMotonaveDetalle.Add(new MdloDtos.VisitaMotonaveDetalle
                        {
                            VmdRowid = item.VmdRowid,
                            VmdRowidVstaMtnve = item.VmdRowidVstaMtnve,
                            VmdRowidStcionPrtriaDtlle = item.VmdRowidStcionPrtriaDtlle,
                            VmdRowidAgnciaAdna = item.VmdRowidAgnciaAdna,
                            VmdRowidAgnciaAdnaNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.TeRowidAgnciaAdna,
                                TeCdgoCia = item.TeCdgoCiaAgnciaAdna,
                                TeCdgo = item.TeCdgoAgnciaAdna,
                                TeNmbre = item.TeNmbreAgnciaAdna,
                                TeIdntfccion = item.TeIdntfccionAgnciaAdna,
                                TeTpoIdntfccion = item.TeTpoIdntfccionAgnciaAdna,
                                TeDv = item.TeDvAgnciaAdna,
                                TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroAgnciaAdna

                            },
                            VmdRowidStcionPrtriaDtlleNavigation = new MdloDtos.SituacionPortuariaDetalle
                            {
                                SpdRowid = item.SpdRowid,
                                SpdRowidStcionPrtria = item.SpdRowidStcionPrtria,
                                SpdRowidTrcro = item.SpdRowidTrcro,
                                SdpCdgoPrdcto = item.SdpCdgoPrdcto,
                                SdpTmBl = item.SdpTmBl,
                                SpdCdgoUndadMdda = item.SpdCdgoUndadMdda,
                                SpdCntdad = item.SpdCntdad,
                                SpdRowidOprdorPrtrio = item.SpdRowidOprdorPrtrio,
                                SpdRowidTrcroNavigation = new MdloDtos.Tercero
                                {
                                    TeRowid = item.TeRowidTrcro,
                                    TeCdgoCia = item.TeCdgoCiaTrcro,
                                    TeCdgo = item.TeCdgoTrcro,
                                    TeNmbre = item.TeNmbreTrcro,
                                    TeIdntfccion = item.TeIdntfccionTrcro,
                                    TeTpoIdntfccion = item.TeTpoIdntfccionTrcro,
                                    TeDv = item.TeDvTrcro,
                                    TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroTrcro
                                },
                                SdpCdgoPrdctoNavigation = new MdloDtos.Producto
                                {
                                    PrCdgo = item.PrCdgo,
                                    PrNmbre = item.PrNmbre,
                                },
                                SpdRowidOprdorPrtrioNavigation = new MdloDtos.Tercero
                                {
                                    TeRowid = item.TeRowidTrcroOprdorPrtrioSPDtlle,
                                    TeCdgoCia = item.TeCdgoCiaOprdorPrtrioSPDtlle,
                                    TeCdgo = item.TeCdgoOprdorPrtrioSPDtlle,
                                    TeNmbre = item.TeNmbreOprdorPrtrioSPDtlle,
                                    TeIdntfccion = item.TeIdntfccionOprdorPrtrioSPDtlle,
                                    TeTpoIdntfccion = item.TeTpoIdntfccionOprdorPrtrioSPDtlle,
                                    TeDv = item.TeDvOprdorPrtrioSPDtlle,
                                    TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroOprdorPrtrioSPDtlle
                                },
                                SpdCdgoUndadMddaNavigation = new MdloDtos.UnidadMedidum
                                {
                                    UmCdgo = item.UmCdgo,
                                    UmNmbre = item.UmNmbre,
                                    UmGrnel = item.UmGrnel,
                                    UmActvo = item.UmActvo
                                },
                                ProductoCodigo = item.PrCdgo,
                                ProductoNombre = item.PrNmbre,
                                TerceroCodigo = item.TeRowidTrcro != null ? "" + item.TeRowidTrcro : "",
                                TerceroNombre = item.TeNmbreTrcro,
                                UnidadMedidaCodigo = item.UmCdgo,
                                UnidadMedidaDescripcion = item.UmNmbre
                            }
                        });
                    }
                }
                return listaVisitaMotonaveDetalle;
            }
        }
        #endregion

        #region consulta todas las visitas de motonave detalle creadas
        public async Task<List<MdloDtos.VisitaMotonaveDetalle>> consultarVisitaMotonaveDetalle()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List <MdloDtos.VisitaMotonaveDetalle> listVisitaMotonaveDetalle = new  List<MdloDtos.VisitaMotonaveDetalle>();

                var lst = await (from vstaMtnveDtlle in _dbContex.VisitaMotonaveDetalles

                                 join agnciaAdna in _dbContex.Terceros on vstaMtnveDtlle.VmdRowidAgnciaAdna equals agnciaAdna.TeRowid into agnciaAdnaJoin
                                 from agnciaAdna in agnciaAdnaJoin.DefaultIfEmpty()

                                 join stcionPrtriaDtlle in _dbContex.SituacionPortuariaDetalles on vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle equals stcionPrtriaDtlle.SpdRowid into stcionPrtriaDtlleJoin
                                 from stcionPrtriaDtlle in stcionPrtriaDtlleJoin.DefaultIfEmpty()

                                 join trcro in _dbContex.Terceros on stcionPrtriaDtlle.SpdRowidTrcro equals trcro.TeRowid into trcroJoin
                                 from trcro in trcroJoin.DefaultIfEmpty()

                                 join prdcto in _dbContex.Productos on stcionPrtriaDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo into prdctoJoin
                                 from prdcto in prdctoJoin.DefaultIfEmpty()

                                 join oprdorPrtrioSPDtlle in _dbContex.Terceros on stcionPrtriaDtlle.SpdRowidOprdorPrtrio equals oprdorPrtrioSPDtlle.TeRowid into oprdorPrtrioSPDtlleJoin
                                 from oprdorPrtrioSPDtlle in oprdorPrtrioSPDtlleJoin.DefaultIfEmpty()

                                 join undadMdda in _dbContex.UnidadMedida on stcionPrtriaDtlle.SpdCdgoUndadMdda equals undadMdda.UmCdgo into undadMddaJoin
                                 from undadMdda in undadMddaJoin.DefaultIfEmpty()

                                 select new
                                  {
                                     vstaMtnveDtlle.VmdRowid,
                                     vstaMtnveDtlle.VmdRowidVstaMtnve,
                                     vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle,
                                     vstaMtnveDtlle.VmdRowidAgnciaAdna,

                                     TeRowidAgnciaAdna = agnciaAdna.TeRowid,
                                     TeCdgoCiaAgnciaAdna = agnciaAdna.TeCdgoCia,
                                     TeCdgoAgnciaAdna = agnciaAdna.TeCdgo,
                                     TeNmbreAgnciaAdna = agnciaAdna.TeNmbre,
                                     TeIdntfccionAgnciaAdna = agnciaAdna.TeIdntfccion,
                                     TeTpoIdntfccionAgnciaAdna = agnciaAdna.TeTpoIdntfccion,
                                     TeDvAgnciaAdna = agnciaAdna.TeDv,
                                     TeCdgoGrpoTrcroAgnciaAdna = agnciaAdna.TeCdgoGrpoTrcro,

                                     stcionPrtriaDtlle.SpdRowid,
                                     stcionPrtriaDtlle.SpdRowidStcionPrtria,
                                     stcionPrtriaDtlle.SpdRowidTrcro,
                                     stcionPrtriaDtlle.SdpCdgoPrdcto,
                                     stcionPrtriaDtlle.SdpTmBl,
                                     stcionPrtriaDtlle.SpdCdgoUndadMdda,
                                     stcionPrtriaDtlle.SpdCntdad,
                                     stcionPrtriaDtlle.SpdRowidOprdorPrtrio,

                                     TeRowidTrcro = trcro.TeRowid,
                                     TeCdgoCiaTrcro = trcro.TeCdgoCia,
                                     TeCdgoTrcro = trcro.TeCdgo,
                                     TeNmbreTrcro = trcro.TeNmbre,
                                     TeIdntfccionTrcro = trcro.TeIdntfccion,
                                     TeTpoIdntfccionTrcro = trcro.TeTpoIdntfccion,
                                     TeDvTrcro = trcro.TeDv,
                                     TeCdgoGrpoTrcroTrcro = trcro.TeCdgoGrpoTrcro,

                                     prdcto.PrCdgo,
                                     prdcto.PrNmbre,

                                     TeRowidTrcroOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeRowid,
                                     TeCdgoCiaOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgoCia,
                                     TeCdgoOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgo,
                                     TeNmbreOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeNmbre,
                                     TeIdntfccionOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeIdntfccion,
                                     TeTpoIdntfccionOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeTpoIdntfccion,
                                     TeDvOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeDv,
                                     TeCdgoGrpoTrcroOprdorPrtrioSPDtlle = oprdorPrtrioSPDtlle.TeCdgoGrpoTrcro,

                                     undadMdda.UmCdgo,
                                     undadMdda.UmNmbre,
                                     undadMdda.UmGrnel,
                                     undadMdda.UmActvo
                                 }
                                ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {

                    listVisitaMotonaveDetalle.Add(new MdloDtos.VisitaMotonaveDetalle
                    {
                        VmdRowid = item.VmdRowid,
                        VmdRowidVstaMtnve = item.VmdRowidVstaMtnve,
                        VmdRowidStcionPrtriaDtlle = item.VmdRowidStcionPrtriaDtlle,
                        VmdRowidAgnciaAdna = item.VmdRowidAgnciaAdna,
                        VmdRowidAgnciaAdnaNavigation = new MdloDtos.Tercero
                        {
                            TeRowid = item.TeRowidAgnciaAdna,
                            TeCdgoCia = item.TeCdgoCiaAgnciaAdna,
                            TeCdgo = item.TeCdgoAgnciaAdna,
                            TeNmbre = item.TeNmbreAgnciaAdna,
                            TeIdntfccion = item.TeIdntfccionAgnciaAdna,
                            TeTpoIdntfccion = item.TeTpoIdntfccionAgnciaAdna,
                            TeDv = item.TeDvAgnciaAdna,
                            TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroAgnciaAdna
                        },
                        VmdRowidStcionPrtriaDtlleNavigation = new MdloDtos.SituacionPortuariaDetalle
                        {
                            SpdRowid = item.SpdRowid,
                            SpdRowidStcionPrtria = item.SpdRowidStcionPrtria,
                            SpdRowidTrcro = item.SpdRowidTrcro,
                            SdpCdgoPrdcto = item.SdpCdgoPrdcto,
                            SdpTmBl = item.SdpTmBl,
                            SpdCdgoUndadMdda = item.SpdCdgoUndadMdda,
                            SpdCntdad = item.SpdCntdad,
                            SpdRowidOprdorPrtrio = item.SpdRowidOprdorPrtrio,
                            SpdRowidTrcroNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.TeRowidTrcro,
                                TeCdgoCia = item.TeCdgoCiaTrcro,
                                TeCdgo = item.TeCdgoTrcro,
                                TeNmbre = item.TeNmbreTrcro,
                                TeIdntfccion = item.TeIdntfccionTrcro,
                                TeTpoIdntfccion = item.TeTpoIdntfccionTrcro,
                                TeDv = item.TeDvTrcro,
                                TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroTrcro
                            },
                            SdpCdgoPrdctoNavigation = new MdloDtos.Producto
                            {
                                PrCdgo = item.PrCdgo,
                                PrNmbre = item.PrNmbre,
                            },
                            SpdRowidOprdorPrtrioNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.TeRowidTrcroOprdorPrtrioSPDtlle,
                                TeCdgoCia = item.TeCdgoCiaOprdorPrtrioSPDtlle,
                                TeCdgo = item.TeCdgoOprdorPrtrioSPDtlle,
                                TeNmbre = item.TeNmbreOprdorPrtrioSPDtlle,
                                TeIdntfccion = item.TeIdntfccionOprdorPrtrioSPDtlle,
                                TeTpoIdntfccion = item.TeTpoIdntfccionOprdorPrtrioSPDtlle,
                                TeDv = item.TeDvOprdorPrtrioSPDtlle,
                                TeCdgoGrpoTrcro = item.TeCdgoGrpoTrcroOprdorPrtrioSPDtlle
                            },
                            SpdCdgoUndadMddaNavigation = new MdloDtos.UnidadMedidum
                            {
                                UmCdgo = item.UmCdgo,
                                UmNmbre = item.UmNmbre,
                                UmGrnel = item.UmGrnel,
                                UmActvo = item.UmActvo
                            },
                            ProductoCodigo = item.PrCdgo,
                            ProductoNombre = item.PrNmbre,
                            TerceroCodigo = item.TeRowidTrcro != null ? "" + item.TeRowidTrcro : "",
                            TerceroNombre = item.TeNmbreTrcro,
                            UnidadMedidaCodigo = item.UmCdgo,
                            UnidadMedidaDescripcion = item.UmNmbre
                        }
                    });
                }
                _dbContex.Dispose();
                return listVisitaMotonaveDetalle;
            }
        }
        #endregion

        #region  elimina una visita Motonave detalle especifica según el id del mismo
        public async Task<MdloDtos.VisitaMotonaveDetalle> EliminarVisitaMotonaveDetalleEspecifico(MdloDtos.VisitaMotonaveDetalle _VisitaMotonaveDetalle)
        {
            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveDetalleExiste = await _dbContext.VisitaMotonaveDetalles.FindAsync(_VisitaMotonaveDetalle.VmdRowid);
                    if (VisitaMotonaveDetalleExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContext.Remove(VisitaMotonaveDetalleExiste);
                        await _dbContext.SaveChangesAsync();
                    }
                    _dbContext.Dispose();
                    return VisitaMotonaveDetalleExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }
        #endregion

        #region elimina todas las visita motonave detalles  según el id de la visita motonave (encabezado)
        public async Task<bool> EliminarVisitaMotonaveDetallePorIdVisitaMotonave(MdloDtos.VisitaMotonave ObjVisitaMotonave)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonavesExiste = await _dbContext.VisitaMotonaves.FindAsync(ObjVisitaMotonave.VmRowid);
                    if (VisitaMotonavesExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        var resultado = (from vstaMtnveDtlle in _dbContext.VisitaMotonaveDetalles
                                         where vstaMtnveDtlle.VmdRowidVstaMtnve == ObjVisitaMotonave.VmRowid
                                         select vstaMtnveDtlle).Count();
                        if (resultado > 0)
                        {
                            var VisitaMotonaveDetallesExiste_ = (from vstaMtnveDtlle in _dbContext.VisitaMotonaveDetalles
                                                                where vstaMtnveDtlle.VmdRowidVstaMtnve == ObjVisitaMotonave.VmRowid
                                                                select vstaMtnveDtlle).ToList();
                            foreach (var item in VisitaMotonaveDetallesExiste_)
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

        #region Actualizar VisitaMotonaveDetalle pasando el objeto _VisitaMotonaveDetalle
        public async Task<MdloDtos.VisitaMotonaveDetalle> EditarVisitaMotonaveDetalle(MdloDtos.VisitaMotonaveDetalle _VisitaMotonaveDetalle)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.VisitaMotonaveDetalle VisitaMotonaveDetalleExiste = await _dbContex.VisitaMotonaveDetalles.FindAsync(_VisitaMotonaveDetalle.VmdRowid);
                    if (VisitaMotonaveDetalleExiste != null)
                    {  
                        VisitaMotonaveDetalleExiste.VmdRowidAgnciaAdna = _VisitaMotonaveDetalle.VmdRowidAgnciaAdna;
                        VisitaMotonaveDetalleExiste.VmdActvo = _VisitaMotonaveDetalle.VmdActvo;

                        _dbContex.Entry(VisitaMotonaveDetalleExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return VisitaMotonaveDetalleExiste;
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
