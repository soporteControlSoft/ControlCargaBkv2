using AccsoDtos.Parametrizacion;
using AccsoDtos.PortalClientes;
using AccsoDtos.SituacionPortuaria;
using AccsoDtos.VisitaMotonave;
using MdloDtos;
using MdloDtos.IModelos;
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
    public class Deposito : MdloDtos.IModelos.IDeposito
    {

        AccsoDtos.VisitaMotonave.VisitaMotonaveBl ObjVisitaMotonaveBl = new AccsoDtos.VisitaMotonave.VisitaMotonaveBl();

        #region verifica la existencia de un producto pasando como parámetro Codigo
        public async Task<List<MdloDtos.VwMdloDpstoLstarPrdctoPorVstaMtnve>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from lstaPrdcto in _dbContex.VwMdloDpstoLstarPrdctoPorVstaMtnves 
                                 where lstaPrdcto.VmRowid.Equals(IdVisitaMotonave)

                                select  lstaPrdcto).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consultar todos los datos de VisitaMotonaveBl  mediante un parametro (IdVisitaMotonave,codigoUsuario) para buscar todos los VisitaMotonaveBl de una visita motonave en particular.
        public async Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlCrearDeposito(int IdVisitaMotonave, string codigoUsuario, string codigoProducto)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                
                var query = (String.IsNullOrEmpty(codigoProducto)) ? 
                        await _dbContex.ListarBlsPorVisitaMotonaveCliente(IdVisitaMotonave, codigoUsuario) : 
                        await _dbContex.ListarBlsPorVisitaMotonaveClienteProducto(IdVisitaMotonave, codigoUsuario, codigoProducto);
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
                            },
                            blAsociadoDeposito = item.Vmd_dpsto_ascdo
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

        #region ingreso de datos a la entidad Deposito
        public async Task<MdloDtos.Deposito> IngresarDeposito(MdloDtos.Deposito _Deposito)
        {
            var ObjDeposito = new MdloDtos.Deposito();
            MdloDtos.Deposito dsptoDB = new MdloDtos.Deposito();
            bool validarInsert = false;
            DateTime hoy;
            List<MdloDtos.DepositoBl> listaDepositoBl;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    listaDepositoBl = (List<DepositoBl>)_Deposito.DepositoBls;

                    hoy = DateTime.Now;
                    ObjDeposito.DeCia = _Deposito.DeCia;
                    ObjDeposito.DeCdgo = "TEMP";
                    ObjDeposito.DeEstdo = "B";
                    ObjDeposito.DeRowidTrcro = _Deposito.DeRowidTrcro;
                    ObjDeposito.DeCdgoPrdcto = _Deposito.DeCdgoPrdcto;
                    ObjDeposito.DeFchaAgrpcion = hoy;
                    ObjDeposito.DeCdgoUsrioCrea = _Deposito.DeCdgoUsrioCrea;
                    ObjDeposito.DeActvo = false;
                    ObjDeposito.DeAprbdo = false;
                    ObjDeposito.DeCmun = false;
                    ObjDeposito.DeCntdad = 0;
                    ObjDeposito.DeKlos = 0;
                    ObjDeposito.DeEsSubdpsto = false;

                    // Agregamos el depósito al contexto
                    await _dbContex.Depositos.AddAsync(ObjDeposito);

                    // Guardamos los cambios y validamos si fue exitoso
                    var result = await _dbContex.SaveChangesAsync();

                    if (result > 0)// El registro fue exitoso, procedemos a consultas el Deposito para registrar los Bls
                    {
                        validarInsert= true;
                    }
                    else // El registro no fue exitoso
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
               
            }
            if (validarInsert)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = await (from dpsto in _dbContex.Depositos
                                         where
                                            dpsto.DeFchaAgrpcion == hoy &&
                                            dpsto.DeCia.Equals(_Deposito.DeCia) &&
                                            dpsto.DeCdgoUsrioCrea.Equals(_Deposito.DeCdgoUsrioCrea) &&
                                            dpsto.DeRowidTrcro.Equals(_Deposito.DeRowidTrcro) &&
                                            dpsto.DeCdgoPrdcto.Equals(_Deposito.DeCdgoPrdcto)
                                         select dpsto).ToListAsync();
                        MdloDtos.Deposito dsptoDBTemp = new MdloDtos.Deposito();
                        foreach (var item in lst)
                        {
                            dsptoDBTemp = new MdloDtos.Deposito
                            {
                                DeRowid = item.DeRowid,
                            };
                        }
                        dsptoDB = await _dbContex.Depositos.FindAsync(dsptoDBTemp.DeRowid);

                        if (dsptoDB.DeRowid != null)//Procedemos a registrar todos los Bls para el deposito
                        {
                            int CntdadTnldaMtrcasDpsto = 0;
                            int CntdadDpsto = 0;
                            foreach (var itemBl in listaDepositoBl)
                            {
                                MdloDtos.DepositoBl ObjDepositoBl = new MdloDtos.DepositoBl
                                {
                                    DblRowidDpsto = dsptoDB.DeRowid,
                                    DblRowidVstaMtnveBl = itemBl.DblRowidVstaMtnveBl,
                                };
                                // Agregamos el depositoBl al contexto
                                await _dbContex.DepositoBls.AddAsync(ObjDepositoBl);

                                // Guardamos los cambios y validamos si fue exitoso
                                var resultAddDespositoBl = await _dbContex.SaveChangesAsync();

                                if (resultAddDespositoBl > 0)// El registro fue exitoso, procedemos a consultar la sumatoria total de los Bls
                                {
                                    List<MdloDtos.VisitaMotonaveBl> ListVisitaMotonaveBl = await ObjVisitaMotonaveBl.FiltrarVisitaMotonaveBlEspecifico((int)ObjDepositoBl.DblRowidVstaMtnveBl);
                                    if (ListVisitaMotonaveBl[0].VmblTnldasMtrcas != null)
                                    {
                                        CntdadTnldaMtrcasDpsto = CntdadTnldaMtrcasDpsto + (int)ListVisitaMotonaveBl[0].VmblTnldasMtrcas;
                                    }
                                    if (ListVisitaMotonaveBl[0].VmblCntdad != null)
                                    {
                                        CntdadDpsto = CntdadDpsto + (int)ListVisitaMotonaveBl[0].VmblCntdad;
                                    }
                                }  
                            }
                            dsptoDB.DeCdgo = "T_" + dsptoDB.DeRowid;
                            dsptoDB.DeBlKlos = CntdadTnldaMtrcasDpsto /* 1000*/; //Convertimos de toneladas a Kilo.
                            dsptoDB.DeBlKlosOrgnal = CntdadTnldaMtrcasDpsto /* 1000*/; //Convertimos de toneladas a Kilo.

                            dsptoDB.DeBlUnddes = CntdadDpsto;
                            dsptoDB.DeBlUnddesOrgnal = CntdadDpsto;


                            //Hacemos una actualización del deposito con las toneladas obtenidas
                            _dbContex.Entry(dsptoDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            await _dbContex.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                    _dbContex.Dispose();
                }
            }
            return dsptoDB;
        }
        #endregion

        public async Task<bool> validarDisponibilidadAsociacionBlsADeposito(List<MdloDtos.DepositoBl> listaDepositoBl)
        {
            //Return true= si todos los Bls están disponible para el nuevo deposito
            //Return false=existe al menos un Bl que ya fue asociado a otro deposito por tal motivo no se puede asociar
            try
            {
                int contadorBlsDiponibleAAsociar = 0;
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    foreach(MdloDtos.DepositoBl item in listaDepositoBl)
                    {
                        var contador = await (from dpsto in _dbContex.Depositos
                                                          join dpstoBl in _dbContex.DepositoBls on dpsto.DeRowid equals dpstoBl.DblRowidDpsto
                                                          where dpstoBl.DblRowidVstaMtnveBl == item.DblRowidVstaMtnveBl && 
                                                                                                                 (dpsto.DeEstdo.Equals("B") ||
                                                                                                                 (dpsto.DeEstdo.Equals("A") && dpsto.DeAprbdo== true) ||
                                                                                                                 (dpsto.DeEstdo.Equals("C") && dpsto.DeAprbdo == true))
                                                          select new
                                                          {
                                                              dpstoBl.DblRowidVstaMtnveBl
                                                          }).ToListAsync();
                        contadorBlsDiponibleAAsociar = (contador.Count() <= 0) ?
                                                        (contadorBlsDiponibleAAsociar+1) :
                                                        contadorBlsDiponibleAAsociar;
                    }     
                    _dbContex.Dispose();
                }
                return (listaDepositoBl.Count == contadorBlsDiponibleAAsociar) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> validarProductosEnBLs(List<MdloDtos.DepositoBl> _listaDepositoBl)
        {
            bool validarProductosIguales = true;
            try
            {
                if (_listaDepositoBl.Count() == 1) {
                    return true;
                }
                else {
                    List<MdloDtos.DepositoBl> listaDepositoBl = _listaDepositoBl;
                    if (listaDepositoBl != null)
                    {
                        int RowIdVstaMtnveBl = (int)listaDepositoBl[0].DblRowidVstaMtnveBl;
                        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                        {
                            var lstaPrdcto = await (from vstaMtnveBl in _dbContex.VisitaMotonaveBls
                                                    join vstaMtnveDtlle in _dbContex.VisitaMotonaveDetalles on vstaMtnveBl.VmblRowidVstaMtnveDtlle equals vstaMtnveDtlle.VmdRowid
                                                    join stcionPrtrDtlle in _dbContex.SituacionPortuariaDetalles on vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle equals stcionPrtrDtlle.SpdRowid
                                                    join prdcto in _dbContex.Productos on stcionPrtrDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo
                                                    where vstaMtnveBl.VmblRowid == RowIdVstaMtnveBl
                                                    select prdcto).ToListAsync();
                            string cdgoProducto = lstaPrdcto[0].PrCdgo;

                            foreach (MdloDtos.DepositoBl item in listaDepositoBl)
                            {
                                var _lstaPrdcto = await (from vstaMtnveBl in _dbContex.VisitaMotonaveBls
                                                         join vstaMtnveDtlle in _dbContex.VisitaMotonaveDetalles on vstaMtnveBl.VmblRowidVstaMtnveDtlle equals vstaMtnveDtlle.VmdRowid
                                                         join stcionPrtrDtlle in _dbContex.SituacionPortuariaDetalles on vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle equals stcionPrtrDtlle.SpdRowid
                                                         join prdcto in _dbContex.Productos on stcionPrtrDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo
                                                         where vstaMtnveBl.VmblRowid == item.DblRowidVstaMtnveBl
                                                         select prdcto).ToListAsync();
                                string _cdgoProducto = _lstaPrdcto[0].PrCdgo;

                                if (!_cdgoProducto.Equals(cdgoProducto))
                                {
                                    validarProductosIguales = false;
                                    break;
                                }
                            }
                            _dbContex.Dispose();
                            return validarProductosIguales;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> validarProductosSustanciaControlada(List<MdloDtos.DepositoBl> _listaDepositoBl)
        {
            bool validar = true;
            try
            {
                List<MdloDtos.DepositoBl> listaDepositoBl = _listaDepositoBl;
                if (listaDepositoBl != null)
                {
                    int RowIdVstaMtnveBl = (int)listaDepositoBl[0].DblRowidVstaMtnveBl;
                   
                    using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                    {
                        var lstaPrdcto = await (from vstaMtnveBl in _dbContex.VisitaMotonaveBls
                                                join vstaMtnveDtlle in _dbContex.VisitaMotonaveDetalles on vstaMtnveBl.VmblRowidVstaMtnveDtlle equals vstaMtnveDtlle.VmdRowid
                                                join vstaMtnve in _dbContex.VisitaMotonaves on vstaMtnveDtlle.VmdRowidVstaMtnve equals vstaMtnve.VmRowid
                                                join stcionPrtrDtlle in _dbContex.SituacionPortuariaDetalles on vstaMtnveDtlle.VmdRowidStcionPrtriaDtlle equals stcionPrtrDtlle.SpdRowid
                                                join prdcto in _dbContex.Productos on stcionPrtrDtlle.SdpCdgoPrdcto equals prdcto.PrCdgo
                                                where vstaMtnveBl.VmblRowid == RowIdVstaMtnveBl
                                                select new
                                                {
                                                    prdcto.PrCdgo,
                                                    prdcto.PrSstnciaCntrlda,
                                                    stcionPrtrDtlle.SpdRowidTrcro,
                                                    vstaMtnve.VmCdgoCia

                                                }
                                                ).ToListAsync();
                        string cdgoProducto = lstaPrdcto[0].PrCdgo;
                        bool? esSustanciaControlada = lstaPrdcto[0].PrSstnciaCntrlda;
                        int cdgoTercero = Convert.ToInt32(lstaPrdcto[0].SpdRowidTrcro);
                        string cdgoCompania = lstaPrdcto[0].VmCdgoCia;


                        DateTime hoy = DateTime.Now;
                        if (esSustanciaControlada != null) 
                        {
                            //validamos que sea sustancia no controlada para validar la vigencia del certificado
                            if (esSustanciaControlada ==true)
                            {
                                var lstCertificados = await (from trcroCrtfccdos in _dbContex.TerceroCertificados
                                                        where trcroCrtfccdos.TcRowidTrcro == cdgoTercero && trcroCrtfccdos.TcCdgoPrdcto.Equals(cdgoProducto)
                                                                                                         && trcroCrtfccdos.TcFchaIncio <= hoy && hoy <=trcroCrtfccdos.TcFchaVncmnto 
                                                                                                         && trcroCrtfccdos.TcAprbdo==true
                                                                                                         && trcroCrtfccdos.TcCia.Equals(cdgoCompania)
                                                        select trcroCrtfccdos
                                                   ).ToListAsync();
                                validar=(lstCertificados.Count <= 0) ? false : true; // como es sustancia controlada, valida si está vigente el certificado
                            }
                            
                        }
                        _dbContex.Dispose();
                        return validar;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Aprobación depositos

        #region verifica todos los clientes asociado a una visita de motonave.
        public async Task<List<VwMdloDpstoAprbcionLstarClntesPorVstaMtnve>> ConsultarClientesPorVisitaMotonave(int IdVisitaMotonave)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from lstadoClntes in _dbContex.VwMdloDpstoAprbcionLstarClntesPorVstaMtnves
                                 where lstadoClntes.VmRowid.Equals(IdVisitaMotonave)

                                 select lstadoClntes).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consultar todos los depositos asociado con do, declaraciones, bls, asociado a una visita de motonave pasando como parametro (IdVisitaMotonave).
        public async Task<List<MdloDtos.Deposito>> FiltrarDepositosPendienteAprobacion(int IdVisitaMotonave, int? idCliente)
        {
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
            List<MdloDtos.Deposito> listaDeposito = new List<MdloDtos.Deposito>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var query = (idCliente !=null) ?
                                await _dbContex.ListarDepositosAprobacionPorVisitaCliente(IdVisitaMotonave, (int)idCliente):
                                await _dbContex.ListarDepositosAprobacionPorVisitaMotonave(IdVisitaMotonave);
                     //aqui vamos   
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
                            },
                            blAsociadoDeposito = item.Vmd_dpsto_ascdo,
                            DepositoBls = new List<MdloDtos.DepositoBl>
                            { 
                                new MdloDtos.DepositoBl
                                {
                                    DblRowidDpstoNavigation = new MdloDtos.Deposito
                                    {
                                        DeRowid =item.de_rowid,
                                        DeCdgo  =item.de_cdgo,
                                        DeEsSubdpsto  =item.de_es_subdpsto,
                                        DeBlKlosOrgnal  =item.de_bl_klos_orgnal,
                                        DeBlUnddesOrgnal  =item.de_bl_unddes_orgnal,
                                        DeBlKlos =item.de_bl_klos, 
                                        DeBlUnddes  =item.de_bl_unddes,
                                        DeEstdo  =item.de_estdo,
                                        DeActvo  =item.de_actvo,
                                        DeAprbdo  =item.de_aprbdo,
                                    }
                                }
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
                //Procesamos los lista de BL para agruparlo en lista de Depositos
                
                if(listaVisitaMotonaveBl.Count > 0)
                {

                    foreach(MdloDtos.VisitaMotonaveBl  item in listaVisitaMotonaveBl)
                    {
                        if(listaDeposito.Count > 0) 
                        {
                            bool validar = false;
                            int contador = 0;
                            //validamos si el deposito ya fue agregado

                            foreach(MdloDtos.Deposito depositoTem01 in listaDeposito)
                            {
                                var DepositoBl = item.DepositoBls.ToList();
                                if (DepositoBl[0].DblRowidDpstoNavigation.DeRowid== depositoTem01.DeRowid)//El deposito ya fue agregado a la lista añadimos un nuevo bl al mismo
                                {
                                    listaDeposito[contador].DepositoBls.Add(new MdloDtos.DepositoBl
                                                    {
                                                        DblRowidDpsto = DepositoBl[0].DblRowidDpstoNavigation.DeRowid,
                                                        DblRowidVstaMtnveBl = item.VmblRowid,
                                                        DblRowidVstaMtnveBlNavigation = item
                                                    });
                                    validar = true;
                                }
                                contador++;
                            }
                            if (!validar) //El deposito nunca fue encontrado se agrega como uno nuevo
                            {
                                var DepositoBl = item.DepositoBls.ToList();
                                MdloDtos.Deposito depositoTemp = new MdloDtos.Deposito
                                {
                                    DeRowid = DepositoBl[0].DblRowidDpstoNavigation.DeRowid,
                                    DeCdgo = DepositoBl[0].DblRowidDpstoNavigation.DeCdgo,
                                    DeEsSubdpsto = DepositoBl[0].DblRowidDpstoNavigation.DeEsSubdpsto,
                                    DeBlKlosOrgnal = DepositoBl[0].DblRowidDpstoNavigation.DeBlKlosOrgnal,
                                    DeBlUnddesOrgnal = DepositoBl[0].DblRowidDpstoNavigation.DeBlUnddesOrgnal,
                                    DeBlKlos = DepositoBl[0].DblRowidDpstoNavigation.DeBlKlos,
                                    DeBlUnddes = DepositoBl[0].DblRowidDpstoNavigation.DeBlUnddes,

                                    DeEstdo = DepositoBl[0].DblRowidDpstoNavigation.DeEstdo,
                                    DeActvo = DepositoBl[0].DblRowidDpstoNavigation.DeActvo,
                                    DeAprbdo = DepositoBl[0].DblRowidDpstoNavigation.DeAprbdo,
                                };
                                depositoTemp.DepositoBls.Add(
                                    new MdloDtos.DepositoBl
                                    {
                                        DblRowidDpsto = DepositoBl[0].DblRowidDpstoNavigation.DeRowid,
                                        DblRowidVstaMtnveBl = item.VmblRowid,
                                        DblRowidVstaMtnveBlNavigation = item
                                    });
                                listaDeposito.Add(depositoTemp);
                            }
                        }
                        else
                        {
                            var DepositoBl = item.DepositoBls.ToList();
                            MdloDtos.Deposito depositoTemp = new MdloDtos.Deposito
                            {
                                DeRowid = DepositoBl[0].DblRowidDpstoNavigation.DeRowid,
                                DeCdgo = DepositoBl[0].DblRowidDpstoNavigation.DeCdgo,
                                DeEsSubdpsto = DepositoBl[0].DblRowidDpstoNavigation.DeEsSubdpsto,
                                DeBlKlosOrgnal = DepositoBl[0].DblRowidDpstoNavigation.DeBlKlosOrgnal,
                                DeBlUnddesOrgnal = DepositoBl[0].DblRowidDpstoNavigation.DeBlUnddesOrgnal,
                                DeBlKlos = DepositoBl[0].DblRowidDpstoNavigation.DeBlKlos,
                                DeBlUnddes = DepositoBl[0].DblRowidDpstoNavigation.DeBlUnddes,
                                DeEstdo = DepositoBl[0].DblRowidDpstoNavigation.DeEstdo,
                                DeActvo = DepositoBl[0].DblRowidDpstoNavigation.DeActvo,
                                DeAprbdo = DepositoBl[0].DblRowidDpstoNavigation.DeAprbdo,
                            };
                            depositoTemp.DepositoBls.Add(
                                new MdloDtos.DepositoBl
                                {
                                    DblRowidDpsto = DepositoBl[0].DblRowidDpstoNavigation.DeRowid,
                                    DblRowidVstaMtnveBl= item.VmblRowid,
                                    DblRowidVstaMtnveBlNavigation= item
                                });
                            listaDeposito.Add(depositoTemp);
                        }
                    }

                }
                return listaDeposito;
            }
        }
        #endregion

        #region verificar la existencia de un deposito por su rowId
        public async Task<bool> VerificarDepositoEnEstadoCreacion(int RowIdDeposito)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjDeposito = await _dbContex.Depositos.FindAsync(RowIdDeposito);
                    if (ObjDeposito != null)
                    {
                        if (ObjDeposito.DeEstdo.Equals("B") && ObjDeposito.DeAprbdo == false)
                        {
                            respuesta = true;
                        }
                        else
                        {
                            respuesta = false;
                        }
                    }
                    else {
                        respuesta = false;
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
        #region verificar el estado de aprobado de un deposito en particular
        public async Task<bool> VerificarDepositoEnEstadoAprobado(int RowIdDeposito)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjDeposito = await _dbContex.Depositos.FindAsync(RowIdDeposito);
                    if (ObjDeposito != null)
                    {
                        respuesta= (ObjDeposito.DeEstdo.Equals("A") && ObjDeposito.DeAprbdo == true) ? true : false;
                    }
                    else
                    {
                        respuesta = false;
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

        #region verificar la existencia de un deposito por su rowId
        public async Task<bool> VerificarDeposito(int RowIdDeposito)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjDeposito = await _dbContex.Depositos.FindAsync(RowIdDeposito);
                    respuesta = ObjDeposito != null ? true : false;
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

        #region verificar la existencia de un deposito por su rowId
        public async Task<bool> VerificarDepositoParaCerrar(int RowIdDeposito)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjDeposito = await _dbContex.Depositos.FindAsync(RowIdDeposito);
                    respuesta = (ObjDeposito == null) ? false : ObjDeposito.DeEstdo.Equals("C") ? false : true;
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

        #region Ingresa un comentario a la visita motonave documento.
        public async Task<List<MdloDtos.Mensaje>> IngresarComentario(int Codigo, string codigoUsuario, string comentario)
        {
            List<MdloDtos.Mensaje> listaComentarios = new List<Mensaje>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var DepositosExiste = await _dbContex.Depositos.FindAsync(Codigo);
                    if (DepositosExiste != null)
                    {
                        DateTime Hoy = DateTime.Now;
                        comentario = comentario.Replace("]#&&#[", "").Replace("]#&&[", "").Replace("#&&#", "");//codigo para evitar que se registre un separador dentro del comentario.
                        if (DepositosExiste.DeCmntrios != null)
                        {
                            DepositosExiste.DeCmntrios = DepositosExiste.DeCmntrios + "#&&#[" + Hoy.ToString() + "]#&&[" + codigoUsuario + "]#&&[" + comentario + "]";
                        }
                        else
                        {
                            DepositosExiste.DeCmntrios = "[" + Hoy.ToString() + "]#&&[" + codigoUsuario + "]#&&[" + comentario + "]";
                        }
                        _dbContex.Depositos.Update(DepositosExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                        if (DepositosExiste.DeCmntrios != null)
                        {
                            foreach (var items in DepositosExiste.DeCmntrios.Split("#&&#"))
                            {
                                var item = items.Split("#&&");
                                //Intentamos extraer el nombre del usuario que ingresó el comentario con el codigo
                                try
                                {
                                    MdloDtos.Usuario usuario = new MdloDtos.Usuario();
                                    usuario.UsCdgo = item[1].Replace("[", "").Replace("]", "");
                                    usuario.UsNmbre = null;
                                    {
                                        var lstUsuario = await (from usr in _dbContex.Usuarios
                                                                where (usr.UsCdgo == item[1].Replace("[", "").Replace("]", ""))
                                                                select new
                                                                {
                                                                    usr.UsCdgo,
                                                                    usr.UsNmbre
                                                                }).ToListAsync();
                                        foreach (var itemUsr in lstUsuario)
                                        {
                                            usuario = new MdloDtos.Usuario
                                            {
                                                UsCdgo = itemUsr.UsCdgo,
                                                UsNmbre = itemUsr.UsNmbre
                                            };
                                        }
                                    }
                                    listaComentarios.Add(
                                        new MdloDtos.Mensaje
                                        {
                                            fechaHoraIngreso = Convert.ToDateTime(item[0].Replace("[", "").Replace("]", "")),
                                            usuario = usuario,
                                            comentario = item[2].Replace("[", "").Replace("]", "")
                                        }
                                    );
                                }
                                catch (Exception e){}
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return listaComentarios;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta un comentario de un deposito
        public async Task<List<MdloDtos.Mensaje>> ConsultarComentario(int CodigoDeposito)
        {
            List<MdloDtos.Mensaje> listaComentarios = new List<Mensaje>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var DepositosExiste = await _dbContex.Depositos.FindAsync(CodigoDeposito);
                    if (DepositosExiste != null)
                    {
                        if (DepositosExiste.DeCmntrios != null)
                        {
                            foreach (var items in DepositosExiste.DeCmntrios.Split("#&&#"))
                            {
                                var item = items.Split("#&&");

                                //Intentamos extraer el nombre del usuario que ingresó el comentario con el codigo
                                try
                                {
                                    MdloDtos.Usuario usuario = new MdloDtos.Usuario();
                                    usuario.UsCdgo = item[1].Replace("[", "").Replace("]", "");
                                    usuario.UsNmbre = null;
                                    {
                                        var lstUsuario = await (from usr in _dbContex.Usuarios
                                                                where (usr.UsCdgo == item[1].Replace("[", "").Replace("]", ""))
                                                                select new
                                                                {
                                                                    usr.UsCdgo,
                                                                    usr.UsNmbre
                                                                }).ToListAsync();
                                        foreach (var itemUsr in lstUsuario)
                                        {
                                            usuario = new MdloDtos.Usuario
                                            {
                                                UsCdgo = itemUsr.UsCdgo,
                                                UsNmbre = itemUsr.UsNmbre
                                            };
                                        }
                                    }
                                    listaComentarios.Add(
                                        new MdloDtos.Mensaje
                                        {
                                            fechaHoraIngreso = Convert.ToDateTime(item[0].Replace("[", "").Replace("]", "")),
                                            usuario = usuario,
                                            comentario = item[2].Replace("[", "").Replace("]", "")
                                        }
                                    );
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return listaComentarios;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion


        #region Ingresa una observacion al deposito
        public async Task<List<MdloDtos.Mensaje>> IngresarObservacion(int CodigoDeposito, string codigoUsuario, string observaciones)
        {
            List<MdloDtos.Mensaje> listaObservaciones = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var DepositosExiste = await _dbContex.Depositos.FindAsync(CodigoDeposito);
                    if (DepositosExiste != null)
                    {
                        DateTime Hoy = DateTime.Now;
                        observaciones = observaciones.Replace("]#&&#[", "").Replace("]#&&[", "").Replace("#&&#", "");//codigo para evitar que se registre un separador dentro del comentario.
                        if (DepositosExiste.DeObsrvcnes != null)
                        {
                            DepositosExiste.DeObsrvcnes = DepositosExiste.DeObsrvcnes + "#&&#[" + Hoy.ToString() + "]#&&[" + codigoUsuario + "]#&&[" + observaciones + "]";
                        }
                        else
                        {
                            DepositosExiste.DeObsrvcnes = "[" + Hoy.ToString() + "]#&&[" + codigoUsuario + "]#&&[" + observaciones + "]";
                        }

                        _dbContex.Depositos.Update(DepositosExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                        if (DepositosExiste.DeObsrvcnes != null)
                        {
                            listaObservaciones = new List<Mensaje>();
                            foreach (var items in DepositosExiste.DeObsrvcnes.Split("#&&#"))
                            {
                                var item = items.Split("#&&");
                                //Intentamos extraer el nombre del usuario que ingresó la observación con el codigo
                                try
                                {
                                    MdloDtos.Usuario usuario = new MdloDtos.Usuario();
                                    usuario.UsCdgo = item[1].Replace("[", "").Replace("]", "");
                                    usuario.UsNmbre = null;
                                    {
                                        var lstUsuario = await (from usr in _dbContex.Usuarios
                                                                where (usr.UsCdgo == item[1].Replace("[", "").Replace("]", ""))
                                                                select new
                                                                {
                                                                    usr.UsCdgo,
                                                                    usr.UsNmbre
                                                                }).ToListAsync();
                                        foreach (var itemUsr in lstUsuario)
                                        {
                                            usuario = new MdloDtos.Usuario
                                            {
                                                UsCdgo = itemUsr.UsCdgo,
                                                UsNmbre = itemUsr.UsNmbre
                                            };
                                        }
                                    }
                                    listaObservaciones.Add(
                                        new MdloDtos.Mensaje
                                        {
                                            fechaHoraIngreso = Convert.ToDateTime(item[0].Replace("[", "").Replace("]", "")),
                                            usuario = usuario,
                                            comentario = item[2].Replace("[", "").Replace("]", "")
                                        }
                                    );
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return listaObservaciones;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta un comentario de un deposito
        public async Task<List<MdloDtos.Mensaje>> ConsultarObservaciones(int CodigoDeposito)
        {
            List<MdloDtos.Mensaje> listaObservaciones = new List<Mensaje>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var DepositosExiste = await _dbContex.Depositos.FindAsync(CodigoDeposito);
                    if (DepositosExiste != null)
                    {
                        if (DepositosExiste.DeObsrvcnes != null)
                        {
                            foreach (var items in DepositosExiste.DeObsrvcnes.Split("#&&#"))
                            {
                                var item = items.Split("#&&");

                                //Intentamos extraer el nombre del usuario que ingresó el comentario con el codigo
                                try
                                {
                                    MdloDtos.Usuario usuario = new MdloDtos.Usuario();
                                    usuario.UsCdgo = item[1].Replace("[", "").Replace("]", "");
                                    usuario.UsNmbre = null;
                                    {
                                        var lstUsuario = await (from usr in _dbContex.Usuarios
                                                                where (usr.UsCdgo == item[1].Replace("[", "").Replace("]", ""))
                                                                select new
                                                                {
                                                                    usr.UsCdgo,
                                                                    usr.UsNmbre
                                                                }).ToListAsync();
                                        foreach (var itemUsr in lstUsuario)
                                        {
                                            usuario = new MdloDtos.Usuario
                                            {
                                                UsCdgo = itemUsr.UsCdgo,
                                                UsNmbre = itemUsr.UsNmbre
                                            };
                                        }
                                    }
                                    listaObservaciones.Add(
                                        new MdloDtos.Mensaje
                                        {
                                            fechaHoraIngreso = Convert.ToDateTime(item[0].Replace("[", "").Replace("]", "")),
                                            usuario = usuario,
                                            comentario = item[2].Replace("[", "").Replace("]", "")
                                        }
                                    );
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return listaObservaciones;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Lista los detalles de un deposito particular
        public async Task<List<MdloDtos.SpDtlleDpstoAprbcion>> ListarDetalleDepositoAprobacion(int rowIdDeposito)
        {
            List<MdloDtos.SpDtlleDpstoAprbcion> listadoDtlleDpstoAprbcion = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                listadoDtlleDpstoAprbcion = await _dbContex.ListarDetalleDepositoAprobacion(rowIdDeposito);

                return listadoDtlleDpstoAprbcion;
            }
        }
        #endregion

        #region Aprueba un deposito en particular.
        public async Task<bool> AprobacionDeposito(MdloDtos.SpDpstoAprbcion objDpstoAprbcion)
        {
            bool retorno = false;
            var DepositosExiste = new MdloDtos.Deposito();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                DepositosExiste = await _dbContex.Depositos.FindAsync(objDpstoAprbcion.rowIdDpsto);
                _dbContex.Dispose();
            }
            if (DepositosExiste != null)
            {
                if ((!string.IsNullOrEmpty(objDpstoAprbcion.obsrvcnes)) && (!string.IsNullOrEmpty(objDpstoAprbcion.cdgoUsrioAprba)))//se va a insertar una observación
                {
                    List<MdloDtos.Mensaje> listaObservaciones= await IngresarObservacion(objDpstoAprbcion.rowIdDpsto, objDpstoAprbcion.cdgoUsrioAprba, objDpstoAprbcion.obsrvcnes);
                    if (listaObservaciones != null)
                    {
                        var DepositosExisteTemp = new MdloDtos.Deposito();
                        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                        {
                            DepositosExisteTemp = await _dbContex.Depositos.FindAsync(objDpstoAprbcion.rowIdDpsto);
                            _dbContex.Dispose(); 
                        }
                        if (DepositosExisteTemp != null)
                        {
                            objDpstoAprbcion.obsrvcnes = DepositosExisteTemp.DeObsrvcnes;
                        }
                    }
                }
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    retorno = await _dbContex.DepositoAprobar(objDpstoAprbcion);
                    _dbContex.Dispose();
                  
                }
            }
            return retorno;
        }
        #endregion

        #region rechaza un deposito en particular.
        public async Task<bool> RechazarDeposito(MdloDtos.SpDpstoRchzo objDpstoRchzon)
        {
            bool retorno = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var DepositosExiste = await _dbContex.Depositos.FindAsync(objDpstoRchzon.rowIdDpsto);
                if (DepositosExiste != null)
                {
                    retorno = await _dbContex.DepositoRechazar(objDpstoRchzon);
                }
                _dbContex.Dispose();
                return retorno;
                
            }
        }
        #endregion

        #region Generar una lista de secuencia de números a partir de un procedimiento almacenado
        public async Task<List<int>> CantidadCopiasImpresion()
        {
            int retorno = 0;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                retorno = await _dbContex.CantidadCopiasImpresion();
                _dbContex.Dispose();

                List<int> listadoNumero = new List<int>();
                if (retorno != 0)
                {
                    for (int i = 0; i <= retorno; i++)
                    {
                        listadoNumero.Add(i);
                    }
                }
                else {
                    listadoNumero.Add(0);
                }
                return listadoNumero;
            }
           
        }
        #endregion

        #region verifica todos los productos asociado a una visita de motonave y un cliente en particular.
        public async Task<List<MdloDtos.Producto>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave, int? idCliente)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await _dbContex.ListarProductosCreacionDeposito(IdVisitaMotonave, idCliente);            
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region ingreso de datos a la entidad Deposito por colaborador interno
        public async Task<List<MdloDtos.SpDtlleDpstoAprbcion>> IngresarDepositoColaboradorInterno(MdloDtos.Deposito _Deposito)
        {
            List<MdloDtos.SpDtlleDpstoAprbcion> listadoDtlleDpstoAprbcion = null;
            var ObjDeposito = new MdloDtos.Deposito();  
            bool validarInsert = false;
            DateTime hoy;
            List<MdloDtos.DepositoBl> listaDepositoBl;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    listaDepositoBl = (List<DepositoBl>)_Deposito.DepositoBls;

                    hoy = DateTime.Now;

                    ObjDeposito.DeCdgo = "TEMP";
                    ObjDeposito.DeEstdo = "B";
                    ObjDeposito.DeRowidTrcro = _Deposito.DeRowidTrcro;
                    ObjDeposito.DeCdgoPrdcto = _Deposito.DeCdgoPrdcto;
                    ObjDeposito.DeFchaAgrpcion = hoy;
                    ObjDeposito.DeCdgoUsrioCrea = _Deposito.DeCdgoUsrioCrea;
                    ObjDeposito.DeActvo = _Deposito.DeActvo;
                    ObjDeposito.DeAprbdo = false;
                    ObjDeposito.DeCntdad = 0;
                    ObjDeposito.DeKlos = 0;
                    ObjDeposito.DeEsSubdpsto = false;
                    ObjDeposito.DeCia = _Deposito.DeCia;
                    ObjDeposito.DeCiaFctrcion = _Deposito.DeCiaFctrcion;
                    ObjDeposito.DeRowidSdeDspcho = _Deposito.DeRowidSdeDspcho;
                    ObjDeposito.DeCpiasTqte = _Deposito.DeCpiasTqte;
                    ObjDeposito.DeCntrolUnddes = _Deposito.DeCntrolUnddes;
                    ObjDeposito.DeCmun = _Deposito.DeCmun;
                    ObjDeposito.DeVlorCifClnte = _Deposito.DeVlorCifClnte;
                    ObjDeposito.DeRowidEmpque = _Deposito.DeRowidEmpque;
                    ObjDeposito.DeRowidVstaMtnve = _Deposito.DeRowidVstaMtnve;

                    // Agregamos el depósito al contexto
                    await _dbContex.Depositos.AddAsync(ObjDeposito);

                    // Guardamos los cambios y validamos si fue exitoso
                    var result = await _dbContex.SaveChangesAsync();

                    if (result > 0)// El registro fue exitoso, procedemos a consultas el Deposito para registrar los Bls
                    {
                        validarInsert = true;
                    }
                    else // El registro no fue exitoso
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();

            }
            if (validarInsert)
            {
                MdloDtos.Deposito dsptoDB = null;
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext()) //Consultamos el deposito creado con toda su información
                {
                    try
                    {
                        var lst = await (from dpsto in _dbContex.Depositos
                                            where
                                            dpsto.DeFchaAgrpcion == hoy &&
                                            dpsto.DeCia.Equals(_Deposito.DeCia) &&
                                            dpsto.DeCdgoUsrioCrea.Equals(_Deposito.DeCdgoUsrioCrea) &&
                                            dpsto.DeRowidTrcro.Equals(_Deposito.DeRowidTrcro) &&
                                            dpsto.DeCdgoPrdcto.Equals(_Deposito.DeCdgoPrdcto)
                                            select dpsto).ToListAsync();
                        MdloDtos.Deposito dsptoDBTemp = new MdloDtos.Deposito();
                        foreach (var item in lst)
                        {
                            dsptoDBTemp = new MdloDtos.Deposito
                            {
                                DeRowid = item.DeRowid,
                            };
                        }
                        dsptoDB = await _dbContex.Depositos.FindAsync(dsptoDBTemp.DeRowid);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                    _dbContex.Dispose();
                }
                if (dsptoDB.DeRowid != null)//Procedemos a registrar todos los Bls para el deposito
                {
                    if (listaDepositoBl != null && _Deposito.DeCmun == false)// no es deposito común y tiene Bls por asociar al deposito
                    {
                        int CntdadTnldaMtrcasDpsto = 0;
                        int CntdadDpsto = 0;
                        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext()) //Consultamos el deposito creado con toda su información
                        {
                            foreach (var itemBl in listaDepositoBl)
                            {
                                MdloDtos.DepositoBl ObjDepositoBl = new MdloDtos.DepositoBl
                                {
                                    DblRowidDpsto = dsptoDB.DeRowid,
                                    DblRowidVstaMtnveBl = itemBl.DblRowidVstaMtnveBl,
                                };
                                // Agregamos el depositoBl al contexto
                                await _dbContex.DepositoBls.AddAsync(ObjDepositoBl);

                                // Guardamos los cambios y validamos si fue exitoso
                                var resultAddDespositoBl = await _dbContex.SaveChangesAsync();

                                if (resultAddDespositoBl > 0)// El registro fue exitoso, procedemos a consultar la sumatoria total de los Bls
                                {
                                    List<MdloDtos.VisitaMotonaveBl> ListVisitaMotonaveBl = await ObjVisitaMotonaveBl.FiltrarVisitaMotonaveBlEspecifico((int)ObjDepositoBl.DblRowidVstaMtnveBl);
                                    if (ListVisitaMotonaveBl[0].VmblTnldasMtrcas != null)
                                    {
                                        CntdadTnldaMtrcasDpsto = CntdadTnldaMtrcasDpsto + (int)ListVisitaMotonaveBl[0].VmblTnldasMtrcas;
                                    }
                                    if (ListVisitaMotonaveBl[0].VmblCntdad != null)
                                    {
                                        CntdadDpsto = CntdadDpsto + (int)ListVisitaMotonaveBl[0].VmblCntdad;
                                    }
                                }
                            }
                            _dbContex.Dispose();
                        }

                        dsptoDB.DeCdgo = "T_" + dsptoDB.DeRowid;
                        dsptoDB.DeBlKlos = CntdadTnldaMtrcasDpsto /* 1000¨*/; //Convertimos de toneladas a Kilo.
                        dsptoDB.DeBlKlosOrgnal = CntdadTnldaMtrcasDpsto /* 1000*/; //Convertimos de toneladas a Kilo.
                        dsptoDB.DeBlUnddes = CntdadDpsto;
                        dsptoDB.DeBlUnddesOrgnal = CntdadDpsto;
                    }
                    else // Es deposito común y tiene no Bls por asociar al deposito
                    {
                        dsptoDB.DeCdgo = "T_" + dsptoDB.DeRowid;
                        dsptoDB.DeBlKlos = 0; 
                        dsptoDB.DeBlKlosOrgnal =0; 
                        dsptoDB.DeBlUnddes = 0;
                        dsptoDB.DeBlUnddesOrgnal = 0;
                    }
                    if (_Deposito.DeObsrvcnes != null)// procedemos a actualizar la observaciones en forma de chat
                    {
                        MdloDtos.Deposito DepositosExiste = null;
                        using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
                        {
                            DepositosExiste = await _dbContext.Depositos.FindAsync(dsptoDB.DeRowid);
                            _dbContext.Dispose();
                        }
                        if (DepositosExiste != null)
                        {
                            //Ingresamos la observacion en forma de chat
                            if ((!string.IsNullOrEmpty(_Deposito.DeObsrvcnes)) && (!string.IsNullOrEmpty(_Deposito.DeCdgoUsrioCrea)))//se va a insertar una observación
                            {
                                await IngresarObservacion((int)dsptoDB.DeRowid, _Deposito.DeCdgoUsrioCrea, _Deposito.DeObsrvcnes);
                            }
                            //buscamos los datos de la observaciones
                            var DepositosExisteTemp = new MdloDtos.Deposito();
                            using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
                            {
                                DepositosExisteTemp = await _dbContext.Depositos.FindAsync((int)dsptoDB.DeRowid);
                                _dbContext.Dispose();
                            }
                            if (DepositosExisteTemp != null)
                            {
                                dsptoDB.DeObsrvcnes = DepositosExisteTemp.DeObsrvcnes;
                            }                 
                        }
                    }
                    //Guardamos los cambios en la base de datos.
                    using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
                    {
                        _dbContext.Entry(dsptoDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContext.SaveChangesAsync();

                    }
                    if (dsptoDB.DeRowid != null) //procedemos a aprobar el deposito
                    {
                        using (MdloDtos.CcVenturaContext _dbContext = new MdloDtos.CcVenturaContext())
                        {
                            bool retorno = false;
                            SpDpstoAprbcion spDpstoAprbcion = new SpDpstoAprbcion
                            {
                                rowIdDpsto = (int)dsptoDB.DeRowid,
                                cdgoUsrioAprba = _Deposito.DeCdgoUsrioCrea
                            };
                            //Procedemos a aprobar el deposito creado
                            retorno = await _dbContext.DepositoAprobarColaboradorInterno(spDpstoAprbcion);
                            if (retorno) //Se realizó la aprobación exitosamente, se procede a extraer el detalle del deposito
                            {
                                listadoDtlleDpstoAprbcion = await _dbContext.ListarDetalleDepositoAprobacion((int)dsptoDB.DeRowid);
                            }
                        }
                    }
                }
            }   
            return listadoDtlleDpstoAprbcion;
        }
        #endregion

        #region consulta una lista de depositos
        public async Task<List<MdloDtos.SpDeposito>> ListarDepositosAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await _dbContex.DpsitoAdmnstrcion_LstarDpstos(rowIdVisitaMotonave, rowIdTercero, cdgoProducto, cdgoCmpnia);
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region consulta una lista de depositos
        public async Task<List<MdloDtos.SpDepositoDetalle>> ListarDepositosDetalleAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia, bool estadoDeposito)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await _dbContex.DpsitoAdmnstrcion_LstarDpstosDetalle(rowIdVisitaMotonave, rowIdTercero, cdgoProducto, cdgoCmpnia, estadoDeposito);
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region consulta una lista de subDepositos en base a un código
        public async Task<List<MdloDtos.SpSubDeposito>> ListarSubDepositosAdministracion(string cdgoDpstoPdre)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await _dbContex.DpsitoAdmnstrcion_LstarSubDpstos(cdgoDpstoPdre);
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Lista los detalles de un deposito particular incluyendo sus subdepositos, sus Bls, DO, Declaraciones.
        public async Task<MdloDtos.Deposito> ListarDetalleDepositoAdministracion(int rowIdDeposito)
        {
            MdloDtos.Deposito deposito = null;
            List<MdloDtos.SpDtlleDpstoAdministracion> listadoDtlleDpstoAprbcion = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                listadoDtlleDpstoAprbcion = await _dbContex.ListarDetalleDepositoAdmnstrcion(rowIdDeposito);
            }
            if (listadoDtlleDpstoAprbcion != null)
            {
                try
                {
                    deposito = new MdloDtos.Deposito();
                    deposito.DeRowid = listadoDtlleDpstoAprbcion[0].DeRowid;
                    deposito.DeCdgo = listadoDtlleDpstoAprbcion[0].DeCdgo;
                    deposito.DeEstdo = listadoDtlleDpstoAprbcion[0].DeEstdo;
                    deposito.DeCia = listadoDtlleDpstoAprbcion[0].DeCia;
                    deposito.DeRowidEmpque = listadoDtlleDpstoAprbcion[0].EmRowid;
                    deposito.DeCiaFctrcion = listadoDtlleDpstoAprbcion[0].CiaCdgoFacturacion;
                    deposito.DeRowidTrcro = listadoDtlleDpstoAprbcion[0].TeRowid;
                    deposito.DeCiaNavigation = new MdloDtos.Companium
                    {
                        CiaCdgo = listadoDtlleDpstoAprbcion[0].CiaCdgo,
                        CiaIdntfccion = listadoDtlleDpstoAprbcion[0].CiaIdntfccion,
                        CiaNmbre = listadoDtlleDpstoAprbcion[0].CiaNmbre
                    };
                    deposito.DeCiaFctrcionNavigation = new MdloDtos.Companium
                    {
                        CiaCdgo = listadoDtlleDpstoAprbcion[0].CiaCdgoFacturacion,
                        CiaIdntfccion = listadoDtlleDpstoAprbcion[0].CiaIdntfccionFacturacion,
                        CiaNmbre = listadoDtlleDpstoAprbcion[0].CiaNmbreFacturacion
                    };
                    deposito.DeRowidSdeDspcho = listadoDtlleDpstoAprbcion[0].DeRowidSdeDspcho;
                    deposito.DeRowidSdeDspchoNavigation = new MdloDtos.Sede
                    {
                        SeRowid = listadoDtlleDpstoAprbcion[0].SeRowid,
                        SeCdgo = listadoDtlleDpstoAprbcion[0].SeCdgo,
                        SeCdgoCia = listadoDtlleDpstoAprbcion[0].SeCdgoCia,
                        SeNmbre = listadoDtlleDpstoAprbcion[0].SeNmbre
                    };
                    deposito.DeCpiasTqte = listadoDtlleDpstoAprbcion[0].DeCpiasTqte;
                    deposito.DeFchaAgrpcion = listadoDtlleDpstoAprbcion[0].DeFchaAgrpcion;
                    deposito.DeBlKlosOrgnal = listadoDtlleDpstoAprbcion[0].DeBlKlosOrgnal;
                    deposito.DeBlUnddesOrgnal = listadoDtlleDpstoAprbcion[0].DeBlUnddesOrgnal;
                    deposito.DeBlKlos = listadoDtlleDpstoAprbcion[0].DeBlKlos;
                    deposito.DeBlUnddes = listadoDtlleDpstoAprbcion[0].DeBlUnddes;
                    deposito.DeNcnlzdoKlos = listadoDtlleDpstoAprbcion[0].DeNcnlzdoKlos;
                    deposito.DeNcnlzdoUnddes = listadoDtlleDpstoAprbcion[0].DeNcnlzdoUnddes;
                    deposito.DeRtndoKlos = listadoDtlleDpstoAprbcion[0].DeRtndoKlos;
                    deposito.DeRtndoUnddes = listadoDtlleDpstoAprbcion[0].DeRtndoUnddes;
                    deposito.DeEntrdasKlos = listadoDtlleDpstoAprbcion[0].DeEntrdasKlos;
                    deposito.DeEntrdasUnddes = listadoDtlleDpstoAprbcion[0].DeEntrdasUnddes;
                    deposito.DeSldasKlos = listadoDtlleDpstoAprbcion[0].DeSldasKlos;
                    deposito.DeSldasUnddes = listadoDtlleDpstoAprbcion[0].DeSldasUnddes;
                    deposito.DeSldoKlos = listadoDtlleDpstoAprbcion[0].DeSldoKlos;
                    deposito.DeSldoUnddes = listadoDtlleDpstoAprbcion[0].DeSldoUnddes;
                    deposito.DeActvo = listadoDtlleDpstoAprbcion[0].DeActvo;
                    deposito.DeAprbdo = listadoDtlleDpstoAprbcion[0].DeAprbdo;
                    deposito.DeCntrolUnddes = listadoDtlleDpstoAprbcion[0].DeCntrolUnddes;
                    deposito.DeObsrvcnes = listadoDtlleDpstoAprbcion[0].DeObsrvcnes;
                    deposito.DeCmun = listadoDtlleDpstoAprbcion[0].DeCmun;
                    deposito.DeSspnddo = listadoDtlleDpstoAprbcion[0].DeSspnddo;

                    deposito.DeVlorCifUs = listadoDtlleDpstoAprbcion[0].DeVlorCifUs;
                    deposito.DeVlorCifLo = listadoDtlleDpstoAprbcion[0].DeVlorCifLo;
                    deposito.DeVlorCifClnte = listadoDtlleDpstoAprbcion[0].DeVlorCifClnte;
                    deposito.DeRowidVstaMtnve = listadoDtlleDpstoAprbcion[0].VmRowid;
                    deposito.DeCdgoPrdcto = listadoDtlleDpstoAprbcion[0].PrCdgo;

                    deposito.DeRowidTrcroNavigation = new MdloDtos.Tercero
                    {
                        TeRowid = listadoDtlleDpstoAprbcion[0].TeRowid,
                        TeCdgo = listadoDtlleDpstoAprbcion[0].TeCdgo,
                        TeNmbre = listadoDtlleDpstoAprbcion[0].TeNmbre,
                        TeIdntfccion = listadoDtlleDpstoAprbcion[0].TeIdntfccion,
                        TeTpoIdntfccion = listadoDtlleDpstoAprbcion[0].TeTpoIdntfccion,
                        TeDv = listadoDtlleDpstoAprbcion[0].TeDv,
                        TeDrccion = listadoDtlleDpstoAprbcion[0].TeDrccion,
                        TeTlfno = listadoDtlleDpstoAprbcion[0].TeTlfno,
                        TeEmail = listadoDtlleDpstoAprbcion[0].TeEmail,
                        TeNmbreCntcto = listadoDtlleDpstoAprbcion[0].TeNmbreCntcto,
                    };
                    deposito.DeCdgoPrdctoNavigation = new MdloDtos.Producto
                    {
                        PrCdgo = listadoDtlleDpstoAprbcion[0].PrCdgo,
                        PrNmbre = listadoDtlleDpstoAprbcion[0].PrNmbre,
                        PrActvo = listadoDtlleDpstoAprbcion[0].PrActvo,
                        PrSlctarEmpque = listadoDtlleDpstoAprbcion[0].PrSlctarEmpque,
                        PrCdgoErp = listadoDtlleDpstoAprbcion[0].PrCdgoErp,
                        PrSstnciaCntrlda = listadoDtlleDpstoAprbcion[0].PrSstnciaCntrlda,
                    };
                   
                    MdloDtos.TerceroCertificado TerceroCertificado = new MdloDtos.TerceroCertificado(); 
                        TerceroCertificado.TcRowid = listadoDtlleDpstoAprbcion[0].TcRowid;
                        TerceroCertificado.TcFchaCrgue = listadoDtlleDpstoAprbcion[0].TcFchaCrgue;
                        TerceroCertificado.TcFchaIncio = listadoDtlleDpstoAprbcion[0].TcFchaIncio;
                        TerceroCertificado.TcFchaVncmnto = listadoDtlleDpstoAprbcion[0].TcFchaVncmnto;
                        TerceroCertificado.TcFchaAprbcion = listadoDtlleDpstoAprbcion[0].TcFchaAprbcion;
                        TerceroCertificado.TcAprbdo = listadoDtlleDpstoAprbcion[0].TcAprbdo;
                    deposito.TerceroCertificado = TerceroCertificado;
                    deposito.DeRowidEmpqueNavigation = new MdloDtos.Empaque
                    {
                        EmRowid = listadoDtlleDpstoAprbcion[0].EmRowid,
                        EmCdgo = listadoDtlleDpstoAprbcion[0].EmCdgo,
                        EmNmbre = listadoDtlleDpstoAprbcion[0].EmNmbre,
                        EmTra = listadoDtlleDpstoAprbcion[0].EmTra,
                        EmActvo = listadoDtlleDpstoAprbcion[0].EmActvo,
                    };
                    deposito.DeRowidVstaMtnveNavigation = new MdloDtos.VisitaMotonave
                    {
                        VmRowid = (int)listadoDtlleDpstoAprbcion[0].VmRowid,
                        VmFchaCrcion = listadoDtlleDpstoAprbcion[0].VmFchaCrcion,
                        VmFchaIncioOprcion = listadoDtlleDpstoAprbcion[0].VmFchaIncioOprcion,
                        VmFchaFinOprcion = listadoDtlleDpstoAprbcion[0].VmFchaFinOprcion,
                        VmFchaFndeo = listadoDtlleDpstoAprbcion[0].VmFchaFndeo,
                        VmScncia = listadoDtlleDpstoAprbcion[0].VmScncia,
                        VmDscrpcion = listadoDtlleDpstoAprbcion[0].VmDscrpcion,
                        VmCdgoMtnveNavigation = new MdloDtos.Motonave
                        {
                            MoCdgo = listadoDtlleDpstoAprbcion[0].MoCdgo,
                            MoNmbre = listadoDtlleDpstoAprbcion[0].MoNombre
                        },
                        VmRowidStcionPrtriaNavigation = new MdloDtos.SituacionPortuarium
                        {
                            SpRowid = listadoDtlleDpstoAprbcion[0].SpRowid,
                            SpFchaArrbo = listadoDtlleDpstoAprbcion[0].SpFchaArrbo,
                            SpFchaAtrque = listadoDtlleDpstoAprbcion[0].SpFchaAtrque,
                            SpFchaZrpe = listadoDtlleDpstoAprbcion[0].SpFchaZrpe,
                            SpFchaCrcion = listadoDtlleDpstoAprbcion[0].SpFchaCrcion,
                            SpCdgoMtnveNavigation = new MdloDtos.Motonave
                            {
                                MoCdgo = listadoDtlleDpstoAprbcion[0].MoCdgo,
                                MoNmbre = listadoDtlleDpstoAprbcion[0].MoNombre,
                            }
                        }
                    };
                    /*deposito = new MdloDtos.Deposito
                    {
                        DeRowid = listadoDtlleDpstoAprbcion[0].DeRowid,
                        DeCdgo = listadoDtlleDpstoAprbcion[0].DeCdgo,
                        DeEstdo = listadoDtlleDpstoAprbcion[0].DeEstdo,
                        DeCia = listadoDtlleDpstoAprbcion[0].DeCia,
                        DeCiaNavigation = new MdloDtos.Companium
                        {
                            CiaCdgo = listadoDtlleDpstoAprbcion[0].CiaCdgo,
                            CiaIdntfccion = listadoDtlleDpstoAprbcion[0].CiaIdntfccion,
                            CiaNmbre = listadoDtlleDpstoAprbcion[0].CiaNmbre
                        },
                        DeCiaFctrcionNavigation = new MdloDtos.Companium
                        {
                            CiaCdgo = listadoDtlleDpstoAprbcion[0].CiaCdgoFacturacion,
                            CiaIdntfccion = listadoDtlleDpstoAprbcion[0].CiaIdntfccionFacturacion,
                            CiaNmbre = listadoDtlleDpstoAprbcion[0].CiaNmbreFacturacion
                        },
                        DeRowidSdeDspcho = listadoDtlleDpstoAprbcion[0].DeRowidSdeDspcho,
                        DeRowidSdeDspchoNavigation = new MdloDtos.Sede
                        {
                            SeRowid = listadoDtlleDpstoAprbcion[0].SeRowid,
                            SeCdgo = listadoDtlleDpstoAprbcion[0].SeCdgo,
                            SeCdgoCia = listadoDtlleDpstoAprbcion[0].SeCdgoCia,
                            SeNmbre = listadoDtlleDpstoAprbcion[0].SeNmbre
                        },
                        DeCpiasTqte = listadoDtlleDpstoAprbcion[0].DeCpiasTqte,
                        DeFchaAgrpcion = listadoDtlleDpstoAprbcion[0].DeFchaAgrpcion,
                        DeBlKlosOrgnal = listadoDtlleDpstoAprbcion[0].DeBlKlosOrgnal,
                        DeBlUnddesOrgnal = listadoDtlleDpstoAprbcion[0].DeBlUnddesOrgnal,
                        DeBlKlos = listadoDtlleDpstoAprbcion[0].DeBlKlos,
                        DeBlUnddes = listadoDtlleDpstoAprbcion[0].DeBlUnddes,
                        DeNcnlzdoKlos = listadoDtlleDpstoAprbcion[0].DeNcnlzdoKlos,
                        DeNcnlzdoUnddes = listadoDtlleDpstoAprbcion[0].DeNcnlzdoUnddes,
                        DeRtndoKlos = listadoDtlleDpstoAprbcion[0].DeRtndoKlos,
                        DeRtndoUnddes = listadoDtlleDpstoAprbcion[0].DeRtndoUnddes,
                        DeEntrdasKlos = listadoDtlleDpstoAprbcion[0].DeEntrdasKlos,
                        DeEntrdasUnddes = listadoDtlleDpstoAprbcion[0].DeEntrdasUnddes,
                        DeSldasKlos = listadoDtlleDpstoAprbcion[0].DeSldasKlos,
                        DeSldasUnddes = listadoDtlleDpstoAprbcion[0].DeSldasUnddes,
                        DeSldoKlos = listadoDtlleDpstoAprbcion[0].DeSldoKlos,
                        DeSldoUnddes = listadoDtlleDpstoAprbcion[0].DeSldoUnddes,
                        DeActvo = listadoDtlleDpstoAprbcion[0].DeActvo,
                        DeAprbdo = listadoDtlleDpstoAprbcion[0].DeAprbdo,
                        DeCntrolUnddes = listadoDtlleDpstoAprbcion[0].DeCntrolUnddes,
                        DeObsrvcnes = listadoDtlleDpstoAprbcion[0].DeObsrvcnes,
                        DeCmun = listadoDtlleDpstoAprbcion[0].DeCmun,
                        DeSspnddo = listadoDtlleDpstoAprbcion[0].DeSspnddo,
                        DeRowidTrcroNavigation = new MdloDtos.Tercero
                        {
                            TeRowid = listadoDtlleDpstoAprbcion[0].TeRowid,
                            TeCdgo = listadoDtlleDpstoAprbcion[0].TeCdgo,
                            TeNmbre = listadoDtlleDpstoAprbcion[0].TeNmbre,
                            TeIdntfccion = listadoDtlleDpstoAprbcion[0].TeIdntfccion,
                            TeTpoIdntfccion = listadoDtlleDpstoAprbcion[0].TeTpoIdntfccion,
                            TeDv = listadoDtlleDpstoAprbcion[0].TeDv,
                            TeDrccion = listadoDtlleDpstoAprbcion[0].TeDrccion,
                            TeTlfno = listadoDtlleDpstoAprbcion[0].TeTlfno,
                            TeEmail = listadoDtlleDpstoAprbcion[0].TeEmail,
                            TeNmbreCntcto = listadoDtlleDpstoAprbcion[0].TeNmbreCntcto,
                        },
                        DeCdgoPrdctoNavigation = new MdloDtos.Producto
                        {
                            PrCdgo = listadoDtlleDpstoAprbcion[0].PrCdgo,
                            PrNmbre = listadoDtlleDpstoAprbcion[0].PrNmbre,
                            PrActvo = listadoDtlleDpstoAprbcion[0].PrActvo,
                            PrSlctarEmpque = listadoDtlleDpstoAprbcion[0].PrSlctarEmpque,
                            PrCdgoErp = listadoDtlleDpstoAprbcion[0].PrCdgoErp,
                            PrSstnciaCntrlda = listadoDtlleDpstoAprbcion[0].PrSstnciaCntrlda,
                        },
                        TerceroCertificado = new MdloDtos.TerceroCertificado
                        {
                            TcRowid = (int)listadoDtlleDpstoAprbcion[0].TcRowid,
                            TcFchaCrgue = listadoDtlleDpstoAprbcion[0].TcFchaCrgue,
                            TcFchaIncio = listadoDtlleDpstoAprbcion[0].TcFchaIncio,
                            TcFchaVncmnto = listadoDtlleDpstoAprbcion[0].TcFchaVncmnto,
                            TcFchaAprbcion = listadoDtlleDpstoAprbcion[0].TcFchaAprbcion,
                            TcAprbdo = listadoDtlleDpstoAprbcion[0].TcAprbdo,
                        },
                        DeRowidEmpqueNavigation = new MdloDtos.Empaque
                        {
                            EmRowid = listadoDtlleDpstoAprbcion[0].EmRowid,
                            EmCdgo = listadoDtlleDpstoAprbcion[0].EmCdgo,
                            EmNmbre = listadoDtlleDpstoAprbcion[0].EmNmbre,
                            EmTra = listadoDtlleDpstoAprbcion[0].EmTra,
                            EmActvo = listadoDtlleDpstoAprbcion[0].EmActvo,
                        },
                        DeRowidVstaMtnveNavigation = new MdloDtos.VisitaMotonave
                        {
                            VmRowid = (int)listadoDtlleDpstoAprbcion[0].VmRowid,
                            VmFchaCrcion = listadoDtlleDpstoAprbcion[0].VmFchaCrcion,
                            VmFchaIncioOprcion = listadoDtlleDpstoAprbcion[0].VmFchaIncioOprcion,
                            VmFchaFinOprcion = listadoDtlleDpstoAprbcion[0].VmFchaFinOprcion,
                            VmFchaFndeo = listadoDtlleDpstoAprbcion[0].VmFchaFndeo,
                            VmScncia = listadoDtlleDpstoAprbcion[0].VmScncia,
                            VmDscrpcion = listadoDtlleDpstoAprbcion[0].VmDscrpcion,
                            VmCdgoMtnveNavigation = new MdloDtos.Motonave
                            {
                                MoCdgo = listadoDtlleDpstoAprbcion[0].MoCdgo,
                                MoNmbre = listadoDtlleDpstoAprbcion[0].MoNombre
                            },
                            VmRowidStcionPrtriaNavigation = new MdloDtos.SituacionPortuarium
                            {
                                SpRowid = listadoDtlleDpstoAprbcion[0].SpRowid,
                                SpFchaArrbo = listadoDtlleDpstoAprbcion[0].SpFchaArrbo,
                                SpFchaAtrque = listadoDtlleDpstoAprbcion[0].SpFchaAtrque,
                                SpFchaZrpe = listadoDtlleDpstoAprbcion[0].SpFchaZrpe,
                                SpFchaCrcion = listadoDtlleDpstoAprbcion[0].SpFchaCrcion,
                                SpCdgoMtnveNavigation = new MdloDtos.Motonave
                                {
                                    MoCdgo = listadoDtlleDpstoAprbcion[0].MoCdgo,
                                    MoNmbre = listadoDtlleDpstoAprbcion[0].MoNombre,
                                }
                            }
                        }
                    };*/
                    //procedemos a buscar los subdepositos
                    deposito.SubDepositos = await ListarSubDepositosAdministracion(deposito.DeCdgo);
                    //procedemos a reconstruir los DepositoBl a partir de los Bls encontrados
                    List<MdloDtos.DepositoBl> listaDepositoBl = new List<MdloDtos.DepositoBl>();
                    using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                        {
                            //procedemos a buscar los Bls,DO, Declaraciones
                            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
                            var query = await _dbContex.DspstoAdmnstrcion_LstarBls(rowIdDeposito);
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
                                            //VmdRowidVstaMtnve = IdVisitaMotonave
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



                            if (listaVisitaMotonaveBl.Count() > 0)
                            {
                                foreach (MdloDtos.VisitaMotonaveBl item in listaVisitaMotonaveBl)
                                {
                                    MdloDtos.DepositoBl depositoBl = new MdloDtos.DepositoBl
                                    {
                                        DblRowidDpsto = deposito.DeRowid,
                                        DblRowidVstaMtnveBl = item.VmblRowid,
                                        DblRowidVstaMtnveBlNavigation = item
                                    };
                                    listaDepositoBl.Add(depositoBl);
                                }
                            }

                            deposito.DepositoBls = listaDepositoBl;

                            _dbContex.Dispose();

                        }
                }
                catch(Exception ex)
                {
                    ex.ToString();
                }


            }

            return deposito;

        }
        #endregion




        #region actualiza los datos de una entidad Deposito
        public async Task<MdloDtos.Deposito> ActualizarDeposito(MdloDtos.Deposito DepositoInput)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(DepositoInput.DeRowid);
                    if (DepositoExiste != null)
                    {
                        DepositoExiste.DeCiaFctrcion = DepositoInput.DeCiaFctrcion;
                        DepositoExiste.DeRowidSdeDspcho = DepositoInput.DeRowidSdeDspcho;
                        DepositoExiste.DeCpiasTqte = DepositoInput.DeCpiasTqte;
                        DepositoExiste.DeRowidEmpque = DepositoInput.DeRowidEmpque;
                        DepositoExiste.DeActvo = DepositoInput.DeActvo;
                        DepositoExiste.DeCntrolUnddes = DepositoInput.DeCntrolUnddes;
                        DepositoExiste.DeSspnddo = DepositoInput.DeSspnddo;
                        DepositoExiste.DeVlorCifClnte = DepositoInput.DeVlorCifClnte;
                        DepositoExiste.DeTrm = DepositoInput.DeTrm;
                        _dbContex.Entry(DepositoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        // Guarda los cambios y valida si se actualizó
                        int filasAfectadas = await _dbContex.SaveChangesAsync();
                        if (filasAfectadas > 0)
                        {
                            //Procedemos a actualizar los estados de los subdepositos
                            foreach (MdloDtos.SpSubDeposito item in DepositoInput.SubDepositos)
                            {
                                MdloDtos.Deposito DepositoTemp = await _dbContex.Depositos.FindAsync(item.De_rowid);
                                if (DepositoTemp != null)
                                {
                                    DepositoTemp.DeActvo = item.De_actvo;
                                    _dbContex.Entry(DepositoTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                     await _dbContex.SaveChangesAsync();
                                }
                                _dbContex.Dispose();
                            }
                        }
                        else
                        {
                            throw new Exception("No se pudo actualizar el depósito.");
                        }
                    }
                    _dbContex.Dispose();
                    return DepositoInput;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Lista los detalles de un deposito para parametrizar facturación.
        public async Task<MdloDtos.Deposito> ListarDetalleDepositoFacturacion(int rowIdDeposito)
        {
            MdloDtos.Deposito deposito = null;
            List<MdloDtos.SpDtlleDpstoAprbcion> listadoDtlleDpstoAprbcion = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(rowIdDeposito);
                if (DepositoExiste != null)
                {
                    listadoDtlleDpstoAprbcion = await _dbContex.ListarDetalleDepositoAprobacion(rowIdDeposito);
                    if (listadoDtlleDpstoAprbcion != null)
                    {
                        try
                        {
                            DepositoExiste.DeRowid = listadoDtlleDpstoAprbcion[0].DeRowid;
                            DepositoExiste.DeCdgo = listadoDtlleDpstoAprbcion[0].DeCdgo;
                            DepositoExiste.DeEstdo = listadoDtlleDpstoAprbcion[0].DeEstdo;
                            DepositoExiste.DeCia = listadoDtlleDpstoAprbcion[0].DeCia;
                            DepositoExiste.DeCiaNavigation = new MdloDtos.Companium
                            {
                                CiaCdgo = listadoDtlleDpstoAprbcion[0].CiaCdgo,
                                CiaIdntfccion = listadoDtlleDpstoAprbcion[0].CiaIdntfccion,
                                CiaNmbre = listadoDtlleDpstoAprbcion[0].CiaNmbre
                            };
                            DepositoExiste.DeCiaFctrcionNavigation = new MdloDtos.Companium
                            {
                                CiaCdgo = listadoDtlleDpstoAprbcion[0].CiaCdgoFacturacion,
                                CiaIdntfccion = listadoDtlleDpstoAprbcion[0].CiaIdntfccionFacturacion,
                                CiaNmbre = listadoDtlleDpstoAprbcion[0].CiaNmbreFacturacion
                            };
                            DepositoExiste.DeRowidSdeDspcho = listadoDtlleDpstoAprbcion[0].DeRowidSdeDspcho;
                            DepositoExiste.DeRowidSdeDspchoNavigation = new MdloDtos.Sede
                            {
                                SeRowid = listadoDtlleDpstoAprbcion[0].SeRowid,
                                SeCdgo = listadoDtlleDpstoAprbcion[0].SeCdgo,
                                SeCdgoCia = listadoDtlleDpstoAprbcion[0].SeCdgoCia,
                                SeNmbre = listadoDtlleDpstoAprbcion[0].SeNmbre
                            };
                            DepositoExiste.DeCpiasTqte = listadoDtlleDpstoAprbcion[0].DeCpiasTqte;
                            DepositoExiste.DeFchaAgrpcion = listadoDtlleDpstoAprbcion[0].DeFchaAgrpcion;
                            DepositoExiste.DeBlKlosOrgnal = listadoDtlleDpstoAprbcion[0].DeBlKlosOrgnal;
                            DepositoExiste.DeBlUnddesOrgnal = listadoDtlleDpstoAprbcion[0].DeBlUnddesOrgnal;
                            DepositoExiste.DeBlKlos = listadoDtlleDpstoAprbcion[0].DeBlKlos;
                            DepositoExiste.DeBlUnddes = listadoDtlleDpstoAprbcion[0].DeBlUnddes;
                            DepositoExiste.DeNcnlzdoKlos = listadoDtlleDpstoAprbcion[0].DeNcnlzdoKlos;
                            DepositoExiste.DeNcnlzdoUnddes = listadoDtlleDpstoAprbcion[0].DeNcnlzdoUnddes;
                            DepositoExiste.DeRtndoKlos = listadoDtlleDpstoAprbcion[0].DeRtndoKlos;
                            DepositoExiste.DeRtndoUnddes = listadoDtlleDpstoAprbcion[0].DeRtndoUnddes;
                            DepositoExiste.DeEntrdasKlos = listadoDtlleDpstoAprbcion[0].DeEntrdasKlos;
                            DepositoExiste.DeEntrdasUnddes = listadoDtlleDpstoAprbcion[0].DeEntrdasUnddes;
                            DepositoExiste.DeSldasKlos = listadoDtlleDpstoAprbcion[0].DeSldasKlos;
                            DepositoExiste.DeSldasUnddes = listadoDtlleDpstoAprbcion[0].DeSldasUnddes;
                            DepositoExiste.DeSldoKlos = listadoDtlleDpstoAprbcion[0].DeSldoKlos;
                            DepositoExiste.DeSldoUnddes = listadoDtlleDpstoAprbcion[0].DeSldoUnddes;
                            DepositoExiste.DeActvo = listadoDtlleDpstoAprbcion[0].DeActvo;
                            DepositoExiste.DeAprbdo = listadoDtlleDpstoAprbcion[0].DeAprbdo;
                            DepositoExiste.DeCntrolUnddes = listadoDtlleDpstoAprbcion[0].DeCntrolUnddes;
                            DepositoExiste.DeObsrvcnes = listadoDtlleDpstoAprbcion[0].DeObsrvcnes;
                            DepositoExiste.DeCmun = listadoDtlleDpstoAprbcion[0].DeCmun;
                            DepositoExiste.DeSspnddo = listadoDtlleDpstoAprbcion[0].DeSspnddo;
                            DepositoExiste.DeRowidTrcroNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = listadoDtlleDpstoAprbcion[0].TeRowid,
                                TeCdgo = listadoDtlleDpstoAprbcion[0].TeCdgo,
                                TeNmbre = listadoDtlleDpstoAprbcion[0].TeNmbre,
                                TeIdntfccion = listadoDtlleDpstoAprbcion[0].TeIdntfccion,
                                TeTpoIdntfccion = listadoDtlleDpstoAprbcion[0].TeTpoIdntfccion,
                                TeDv = listadoDtlleDpstoAprbcion[0].TeDv,
                                TeDrccion = listadoDtlleDpstoAprbcion[0].TeDrccion,
                                TeTlfno = listadoDtlleDpstoAprbcion[0].TeTlfno,
                                TeEmail = listadoDtlleDpstoAprbcion[0].TeEmail,
                                TeNmbreCntcto = listadoDtlleDpstoAprbcion[0].TeNmbreCntcto,
                            };
                            DepositoExiste.DeCdgoPrdctoNavigation = new MdloDtos.Producto
                            {
                                PrCdgo = listadoDtlleDpstoAprbcion[0].PrCdgo,
                                PrNmbre = listadoDtlleDpstoAprbcion[0].PrNmbre,
                                PrActvo = listadoDtlleDpstoAprbcion[0].PrActvo,
                                PrSlctarEmpque = listadoDtlleDpstoAprbcion[0].PrSlctarEmpque,
                                PrCdgoErp = listadoDtlleDpstoAprbcion[0].PrCdgoErp,
                                PrSstnciaCntrlda = listadoDtlleDpstoAprbcion[0].PrSstnciaCntrlda,
                            };

                            MdloDtos.TerceroCertificado TerceroCertificado = new MdloDtos.TerceroCertificado();
                            TerceroCertificado.TcRowid = listadoDtlleDpstoAprbcion[0].TcRowid;
                            TerceroCertificado.TcFchaCrgue = listadoDtlleDpstoAprbcion[0].TcFchaCrgue;
                            TerceroCertificado.TcFchaIncio = listadoDtlleDpstoAprbcion[0].TcFchaIncio;
                            TerceroCertificado.TcFchaVncmnto = listadoDtlleDpstoAprbcion[0].TcFchaVncmnto;
                            TerceroCertificado.TcFchaAprbcion = listadoDtlleDpstoAprbcion[0].TcFchaAprbcion;
                            TerceroCertificado.TcAprbdo = listadoDtlleDpstoAprbcion[0].TcAprbdo;
                            DepositoExiste.TerceroCertificado = TerceroCertificado;
                            DepositoExiste.DeRowidEmpqueNavigation = new MdloDtos.Empaque
                            {
                                EmRowid = listadoDtlleDpstoAprbcion[0].EmRowid,
                                EmCdgo = listadoDtlleDpstoAprbcion[0].EmCdgo,
                                EmNmbre = listadoDtlleDpstoAprbcion[0].EmNmbre,
                                EmTra = listadoDtlleDpstoAprbcion[0].EmTra,
                                EmActvo = listadoDtlleDpstoAprbcion[0].EmActvo,
                            };
                            DepositoExiste.DeRowidVstaMtnveNavigation = new MdloDtos.VisitaMotonave
                            {
                                VmRowid = (int)listadoDtlleDpstoAprbcion[0].VmRowid,
                                VmFchaCrcion = listadoDtlleDpstoAprbcion[0].VmFchaCrcion,
                                VmFchaIncioOprcion = listadoDtlleDpstoAprbcion[0].VmFchaIncioOprcion,
                                VmFchaFinOprcion = listadoDtlleDpstoAprbcion[0].VmFchaFinOprcion,
                                VmFchaFndeo = listadoDtlleDpstoAprbcion[0].VmFchaFndeo,
                                VmScncia = listadoDtlleDpstoAprbcion[0].VmScncia,
                                VmDscrpcion = listadoDtlleDpstoAprbcion[0].VmDscrpcion,
                                VmCdgoMtnveNavigation = new MdloDtos.Motonave
                                {
                                    MoCdgo = listadoDtlleDpstoAprbcion[0].MoCdgo,
                                    MoNmbre = listadoDtlleDpstoAprbcion[0].MoNombre
                                },
                                VmRowidStcionPrtriaNavigation = new MdloDtos.SituacionPortuarium
                                {
                                    SpRowid = listadoDtlleDpstoAprbcion[0].SpRowid,
                                    SpFchaArrbo = listadoDtlleDpstoAprbcion[0].SpFchaArrbo,
                                    SpFchaAtrque = listadoDtlleDpstoAprbcion[0].SpFchaAtrque,
                                    SpFchaZrpe = listadoDtlleDpstoAprbcion[0].SpFchaZrpe,
                                    SpFchaCrcion = listadoDtlleDpstoAprbcion[0].SpFchaCrcion,
                                    SpCdgoMtnveNavigation = new MdloDtos.Motonave
                                    {
                                        MoCdgo = listadoDtlleDpstoAprbcion[0].MoCdgo,
                                        MoNmbre = listadoDtlleDpstoAprbcion[0].MoNombre,
                                    }
                                }
                            };

                            //procedemos a buscar los subdepositos
                            DepositoExiste.SubDepositos = await ListarSubDepositosAdministracion(DepositoExiste.DeCdgo);
                            deposito = DepositoExiste;
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                }
                _dbContex.Dispose();
            }
            return deposito;

        }
        #endregion

        #region actualiza los datos de una entidad Deposito
        public async Task<MdloDtos.Deposito> ActualizarCondicionesFacturacion(MdloDtos.Deposito _Deposito)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(_Deposito.DeRowid);
                    if (DepositoExiste != null)
                    {
                        DepositoExiste.DeCdgoCndcionFctrcion = _Deposito.DeCdgoCndcionFctrcion;
                        DepositoExiste.DeCdgoPrdoFctrcion = _Deposito.DeCdgoPrdoFctrcion;
                        DepositoExiste.DeDiasGrcia = _Deposito.DeDiasGrcia;
                        DepositoExiste.DeVlorFjoXTnlda = _Deposito.DeVlorFjoXTnlda;
                        DepositoExiste.DeTrfaPrdo1 = _Deposito.DeTrfaPrdo1;
                        DepositoExiste.DeTrfaPrdo2 = _Deposito.DeTrfaPrdo2;
                        DepositoExiste.DeTrfaPrdo3 = _Deposito.DeTrfaPrdo3;
                        DepositoExiste.DeTrfaPrdo4 = _Deposito.DeTrfaPrdo4;
                        DepositoExiste.DeTrfaPrdo5 = _Deposito.DeTrfaPrdo5;
                        DepositoExiste.DeTrfaPrdo6 = _Deposito.DeTrfaPrdo6;
                        DepositoExiste.DeFctrcionFnlzda = _Deposito.DeFctrcionFnlzda;
                        DepositoExiste.DeFchaIncioFctrcion = _Deposito.DeFchaIncioFctrcion;
                        DepositoExiste.DeDiasPrdo = _Deposito.DeDiasPrdo;
                        DepositoExiste.DeDiasCbro = _Deposito.DeDiasCbro;
                        DepositoExiste.DeMdldadFctrcion = _Deposito.DeMdldadFctrcion;
                        DepositoExiste.DeLqdaDlar = _Deposito.DeLqdaDlar;
                        DepositoExiste.DeFchaUltmaFctra = _Deposito.DeFchaUltmaFctra;
                        DepositoExiste.DeNmroUltmaFctra = _Deposito.DeNmroUltmaFctra;
                        DepositoExiste.DeUltmoPrdoFctrdo = _Deposito.DeUltmoPrdoFctrdo;
                        DepositoExiste.DeFchaPrmerMvmnto = _Deposito.DeFchaPrmerMvmnto;
                        DepositoExiste.DeCndcionPgo = _Deposito.DeCndcionPgo;
                        DepositoExiste.DeRowidSubdpstoFac1 = _Deposito.DeRowidSubdpstoFac1;
                        DepositoExiste.DeRowidSubdpstoFac2 = _Deposito.DeRowidSubdpstoFac2;
                        DepositoExiste.DeRowidSubdpstoFac3 = _Deposito.DeRowidSubdpstoFac3;

                        _dbContex.Entry(DepositoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        // Guarda los cambios y valida si se actualizó
                        int filasAfectadas = await _dbContex.SaveChangesAsync();
                        if (filasAfectadas > 0)
                        {
                            //Procedemos a actualizar los estados de los subdepositos
                            foreach (MdloDtos.SpSubDeposito item in _Deposito.SubDepositos)
                            {
                                MdloDtos.Deposito DepositoTemp = await _dbContex.Depositos.FindAsync(item.De_rowid);
                                if (DepositoTemp != null)
                                {
                                    //DepositoTemp.DeActvo = item.De_actvo;
                                    //_dbContex.Entry(DepositoTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    //await _dbContex.SaveChangesAsync();
                                }  
                            }
                        }
                        else
                        {
                            throw new Exception("No se pudo actualizar el depósito.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _Deposito;
            }
        }
        #endregion

        #region Lista los detalles de un deposito particular incluyendo sus subdepositos, sus Bls, DO, Declaraciones.
        public async Task<MdloDtos.Deposito> ProcesarValoresCif(int rowIdDeposito)
        {
            MdloDtos.Deposito deposito = null;
            decimal smtriaCstoSgroFlte = 0;
            decimal smtriaCstSgroFltPrTRMmsArnce = 0;
            List<MdloDtos.SpDtlleDpstoAprbcion> listadoDtlleDpstoAprbcion = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(rowIdDeposito);
                if (DepositoExiste != null)
                {
                    deposito = DepositoExiste;
                }
                listadoDtlleDpstoAprbcion = await _dbContex.ListarDetalleDepositoAprobacion(rowIdDeposito);
                _dbContex.Dispose();
            }
            if (listadoDtlleDpstoAprbcion != null)
            {
                try
                {
                    deposito.DeRowid = listadoDtlleDpstoAprbcion[0].DeRowid;
                   
                    //procedemos a reconstruir los DepositoBl a partir de los Bls encontrados
                    List<MdloDtos.DepositoBl> listaDepositoBl = new List<MdloDtos.DepositoBl>();
                    using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                    {
                        //procedemos a buscar los Bls,DO, Declaraciones
                        List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
                        var query = await _dbContex.DspstoAdmnstrcion_LstarBls(rowIdDeposito);
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
                                        //VmdRowidVstaMtnve = IdVisitaMotonave
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
                                                if (linea.Vmdo_csto_sgro_flte != null) 
                                                {
                                                    smtriaCstoSgroFlte = smtriaCstoSgroFlte + (decimal)ObjDocumento1.VmdoCstoSgroFlte;
                                                    smtriaCstSgroFltPrTRMmsArnce = (smtriaCstSgroFltPrTRMmsArnce + (decimal)ObjDocumento1.VmdoCstoSgroFlte * (decimal)deposito.DeTrm) +
                                                                            (decimal)ObjDocumento1.VmdoArncelImprtcion;
                                                }
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
                                                if (linea.Vmdo_csto_sgro_flte != null)
                                                {
                                                    smtriaCstoSgroFlte = smtriaCstoSgroFlte + (decimal)ObjDocumento1.VmdoCstoSgroFlte;
                                                    smtriaCstSgroFltPrTRMmsArnce = (smtriaCstSgroFltPrTRMmsArnce + (decimal)ObjDocumento1.VmdoCstoSgroFlte * (decimal)deposito.DeTrm) +
                                                                            (decimal)ObjDocumento1.VmdoArncelImprtcion;
                                                }
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



                        if (listaVisitaMotonaveBl.Count() > 0)
                        {
                            foreach (MdloDtos.VisitaMotonaveBl item in listaVisitaMotonaveBl)
                            {
                                MdloDtos.DepositoBl depositoBl = new MdloDtos.DepositoBl
                                {
                                    DblRowidDpsto = deposito.DeRowid,
                                    DblRowidVstaMtnveBl = item.VmblRowid,
                                    DblRowidVstaMtnveBlNavigation = item
                                };
                                listaDepositoBl.Add(depositoBl);
                            }
                        }

                        deposito.DepositoBls = listaDepositoBl;

                        _dbContex.Dispose();

                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }


            }
            if(smtriaCstoSgroFlte != 0 && smtriaCstSgroFltPrTRMmsArnce != 0)
            { 
                deposito.DeVlorCifUs= smtriaCstoSgroFlte / 1000;
                deposito.DeVlorCifLo = smtriaCstSgroFltPrTRMmsArnce / 1000;

                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(rowIdDeposito);
                        if (DepositoExiste != null)
                        {
                            DepositoExiste.DeVlorCifUs = deposito.DeVlorCifUs;
                            DepositoExiste.DeVlorCifLo = deposito.DeVlorCifLo;
                            _dbContex.Entry(DepositoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            // Guarda los cambios y valida si se actualizó
                            int filasAfectadas = await _dbContex.SaveChangesAsync();
                            if (filasAfectadas > 0)
                            {
                                
                            }
                            else
                            {
                                throw new Exception("No se pudo actualizar el depósito.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                    _dbContex.Dispose();
                }
            }
            return deposito;
        }
        #endregion

        #region retorna una lista entradas y salidas para un deposito en las bodegas mediantes un rowId.
        public async Task<List<MdloDtos.SpInvntrioBdgaDpsto>> InventarioBodega(int rowIdDeposito)
        {
            List<MdloDtos.SpInvntrioBdgaDpsto> ListaInventarioDeposito = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                ListaInventarioDeposito = await _dbContex.DpsitoAdmnstrcion_InvntrioBdga(rowIdDeposito);
                
                _dbContex.Dispose();
            }
           
            return ListaInventarioDeposito;
        }
        #endregion

        #region actualiza los datos de una entidad Deposito
        public async Task<MdloDtos.Deposito> CerrarDeposito(int rowIdDeposito)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(rowIdDeposito);
                    if (DepositoExiste != null)
                    {
                        DepositoExiste.DeEstdo = "C";
                        _dbContex.Entry(DepositoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        // Guarda los cambios y valida si se actualizó
                        int filasAfectadas = await _dbContex.SaveChangesAsync();
                        if (filasAfectadas <= 0)
                        {
                            throw new Exception("No se pudo actualizar el depósito.");
                        } 
                    }
                    _dbContex.Dispose();
                    return DepositoExiste;
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
