﻿using AccsoDtos.Auditoria;
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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace AccsoDtos.PortalClientes
{

    public class SolicitudRetiro: MdloDtos.IModelos.ISolicitudRetiros
    {
        #region consultar productos para filtrar y tener los depositos
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
        #endregion

        #region consultar solicitud de retiros para tener retiros.
        public async Task<List<WmDepositosSolicitudRetiro>> ConsultarSolicitudRetiro()
        {

            using (CcVenturaContext _dbContex = new CcVenturaContext()) { 
        
                var lst = await (from p in _dbContex.WmDepositosSolicitudRetiros
                               
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region  consultar solicitud de retiros para tener visita , producto.
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
        #endregion

        #region consultar solicitud de retiros para tener deposito.
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
        #endregion

        #region ingreso de datos a la entidad solicitud de retiros
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
                       sr_autrzdo_klos, sr_autrzdo_cntdad, sr_dspchdo_klos, sr_dspchdo_cntdad, sr_actva,
                       sr_abrta, sr_entrga_sspndda, sr_obsrvcnes, sr_cmpo_prsnlzdo1, SrCmpoPrsnlzdo2, SrCmpoPrsnlzdo3, sr_rowid_zna_cd, sr_entrgar_pso_excto);
                    

                    var id = (from emp in _dbContex.SolicitudRetiros
                              select emp.SrRowid).Max();
                    var codigo =await (from emp in _dbContex.SolicitudRetiros
                                  where emp.SrRowid == id
                                  select emp.SrCdgo).FirstAsync();

                    ObjSolicitudRetiro.SrRowid = id;
                    ObjSolicitudRetiro.SrCia = _SolicitudRetiro.SrCia;
                    ObjSolicitudRetiro.SrCdgo = codigo;
                    ObjSolicitudRetiro.SrRowidDpsto = _SolicitudRetiro.SrRowidDpsto;
                    ObjSolicitudRetiro.SrRowidCdad = _SolicitudRetiro.SrRowidCdad;
                    ObjSolicitudRetiro.SrPlntaDstno = _SolicitudRetiro.SrPlntaDstno;
                    ObjSolicitudRetiro.SrFchaAprtra = dat;
                    ObjSolicitudRetiro.SrAutrzdoKlos = _SolicitudRetiro.SrAutrzdoKlos;
                    ObjSolicitudRetiro.SrAutrzdoCntdad = _SolicitudRetiro.SrAutrzdoCntdad;
                    ObjSolicitudRetiro.SrDspchdoKlos = 0;
                    ObjSolicitudRetiro.SrDspchdoCntdad = 0;
                    ObjSolicitudRetiro.SrActva = _SolicitudRetiro.SrActva;
                    ObjSolicitudRetiro.SrEntrgarPsoExcto = false;
                    ObjSolicitudRetiro.SrAbrta = _SolicitudRetiro.SrAbrta;
                    ObjSolicitudRetiro.SrObsrvcnes = _SolicitudRetiro.SrObsrvcnes;
                    ObjSolicitudRetiro.SrCmpoPrsnlzdo1 = _SolicitudRetiro.SrCmpoPrsnlzdo1;
                    ObjSolicitudRetiro.SrCmpoPrsnlzdo2 = _SolicitudRetiro.SrCmpoPrsnlzdo2;
                    ObjSolicitudRetiro.SrCmpoPrsnlzdo3 = _SolicitudRetiro.SrCmpoPrsnlzdo3;
                    ObjSolicitudRetiro.SrRowidZnaCd = _SolicitudRetiro.SrRowidZnaCd;
                    ObjSolicitudRetiro.SrEntrgarPsoExcto = false;



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
        
        #region ingresar solicitud de retiros Transportadora version 2 . Abierta.
        public async Task<dynamic> IngresarTrasnportadoraAbierta(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
            var ObjPSolicitudRetiroTransportadora = new MdloDtos.SolicitudRetiroTransportadora();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    int? Kilos_deposito = 0;
                    int? unidades_deposito = 0;

                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudRetiroTransportadora.SrtRowidSlctudRtro);

                    if (SolicitudRetiroExiste != null)
                    {
                        //validar si esa trasnportadora ya existe en la base de datos en esa solicitud de retiro
                        var SolicitudRetiroTrasnportadora = (from p in _dbContex.SolicitudRetiroTransportadoras
                                                             where p.SrtRowidTrnsprtdra == _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra && p.SrtRowidSlctudRtro == _SolicitudRetiroTransportadora.SrtRowidSlctudRtro
                                                             select p.SrtRowidTrnsprtdra).Count();

                        if (SolicitudRetiroTrasnportadora == 0)
                        {
                            MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(SolicitudRetiroExiste.SrRowidDpsto);
                            if (DepositoExiste != null)
                            {
                                //cantidad del deposito
                                Kilos_deposito = DepositoExiste.DeBlKlos;
                                unidades_deposito = DepositoExiste.DeBlUnddes;
                            }
                            //cantidad actuales de la solicitud de retiros
                            int? kilos = SolicitudRetiroExiste.SrAutrzdoKlos;
                            int? unidades = SolicitudRetiroExiste.SrAutrzdoCntdad;

                            if (SolicitudRetiroExiste.SrAbrta == true)
                            {

                                //si las cantidades ingresas son menores a la cantidad del deposito.
                                if ((Kilos_deposito >= _SolicitudRetiroTransportadora.SrtAutrzdoKlos + kilos) && (unidades_deposito >= _SolicitudRetiroTransportadora.SrtAutrzdoUnddes + unidades))
                                {
                                    ObjPSolicitudRetiroTransportadora.SrtRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                                    ObjPSolicitudRetiroTransportadora.SrtRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                                    ObjPSolicitudRetiroTransportadora.SrtAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                                    ObjPSolicitudRetiroTransportadora.SrtAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                                    ObjPSolicitudRetiroTransportadora.SrtDspchdoKlos = 0;
                                    ObjPSolicitudRetiroTransportadora.SrtDspchdoUnddes = 0;
                                    ObjPSolicitudRetiroTransportadora.SrtActva = _SolicitudRetiroTransportadora.SrtActva;


                                    await _dbContex.SolicitudRetiroTransportadoras.AddAsync(ObjPSolicitudRetiroTransportadora);
                                    await _dbContex.SaveChangesAsync();

                                    //para actualizar la solicitud de retiro.
                                    var lst = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                                     where (p.SrtRowidSlctudRtro == ObjPSolicitudRetiroTransportadora.SrtRowidSlctudRtro)
                                                     select p).ToListAsync();
                                    int? sumaKilos = 0;
                                    int? sumaUnidades = 0;

                                    foreach (var item in lst)
                                    {
                                        if (lst.Count == 1)
                                        {
                                            sumaKilos = ObjPSolicitudRetiroTransportadora.SrtAutrzdoKlos;
                                            sumaUnidades = ObjPSolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                                        }
                                        else
                                        {

                                            sumaKilos = item.SrtAutrzdoKlos + sumaKilos;
                                            sumaUnidades = item.SrtAutrzdoUnddes + sumaUnidades;

                                        }

                                    }
                                    //variables que deben ser actualizadas.
                                    SolicitudRetiroExiste.SrAutrzdoKlos = sumaKilos;
                                    SolicitudRetiroExiste.SrAutrzdoCntdad = sumaUnidades;

                                    _dbContex.SolicitudRetiros.Entry(SolicitudRetiroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    await _dbContex.SaveChangesAsync();

                                    //ingresar de forma automatica la autorizacion
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
                                }
                                else
                                {

                                    //error la cantidad y kilos no puede ser superior a la del deposito.
                                    return 2;
                                }
                            }
                            else
                            {

                                //la solicitud no es abierta.
                                return 5;
                            }

                        }
                        else {
                            //ya existe esa trasnportadora para esa solicitud de retiro;
                            return 6;
                        }
                       
                    }
                    else {

                        //id de solicitud de retiro no existe;
                        return 1;
                    }
                    

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                    return 3;
                }
                _dbContex.Dispose();
                return 4;
            }
        }
        #endregion

        #region ingresar solicitud de retiros Transportadora version 2 . Cerrada.
        public async Task<dynamic> IngresarTrasnportadoraCerrada(MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
            var ObPSolicitudTransportadora = new MdloDtos.SolicitudRetiroTransportadora();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    int? Kilos_deposito = 0;
                    int? unidades_deposito = 0;
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudRetiroTransportadora.SrtRowidSlctudRtro);
                    if (SolicitudRetiroExiste != null)
                    {

                        var SolicitudRetiroTrasnportadora = (from p in _dbContex.SolicitudRetiroTransportadoras
                                                             where p.SrtRowidTrnsprtdra == _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra && p.SrtRowidSlctudRtro == _SolicitudRetiroTransportadora.SrtRowidSlctudRtro
                                                             select p.SrtRowidTrnsprtdra).Count();
                        if (SolicitudRetiroTrasnportadora == 0)
                        {
                            if (SolicitudRetiroExiste.SrAbrta == false)
                            {
                                MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(SolicitudRetiroExiste.SrRowidDpsto);
                                if (DepositoExiste != null)
                                {
                                    //cantidad del deposito
                                    Kilos_deposito = DepositoExiste.DeBlKlos;//no se utilizan , ya la validacion esta en la solicitud inicial de retiro
                                    unidades_deposito = DepositoExiste.DeBlUnddes;//no se utilizan , ya la validacion esta en la solicitud inicial de retiro
                                    var SolicitudRetiroTrasnportadoraSum = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                                                                  where p.SrtRowidSlctudRtro == _SolicitudRetiroTransportadora.SrtRowidSlctudRtro
                                                                                  select p).ToListAsync();
                                    int? kilosTrasnportadora = 0;
                                    int? unidadesTrasnportadora = 0;
                                    foreach (var item in SolicitudRetiroTrasnportadoraSum)
                                    {
                                        kilosTrasnportadora = kilosTrasnportadora + item.SrtAutrzdoKlos;
                                        unidadesTrasnportadora = unidadesTrasnportadora + item.SrtAutrzdoUnddes;
                                    }

                                    //validacion de cantidad con el deposito
                                    if ((SolicitudRetiroExiste.SrAutrzdoKlos >= kilosTrasnportadora + _SolicitudRetiroTransportadora.SrtAutrzdoKlos) && (SolicitudRetiroExiste.SrAutrzdoCntdad >= unidadesTrasnportadora + _SolicitudRetiroTransportadora.SrtAutrzdoUnddes))
                                    {
                                        ObPSolicitudTransportadora.SrtRowidSlctudRtro = _SolicitudRetiroTransportadora.SrtRowidSlctudRtro;
                                        ObPSolicitudTransportadora.SrtRowidTrnsprtdra = _SolicitudRetiroTransportadora.SrtRowidTrnsprtdra;
                                        ObPSolicitudTransportadora.SrtAutrzdoKlos = _SolicitudRetiroTransportadora.SrtAutrzdoKlos;
                                        ObPSolicitudTransportadora.SrtAutrzdoUnddes = _SolicitudRetiroTransportadora.SrtAutrzdoUnddes;
                                        ObPSolicitudTransportadora.SrtDspchdoKlos = 0;
                                        ObPSolicitudTransportadora.SrtDspchdoUnddes = 0;
                                        ObPSolicitudTransportadora.SrtActva = _SolicitudRetiroTransportadora.SrtActva;
                                        var res = await _dbContex.SolicitudRetiroTransportadoras.AddAsync(ObPSolicitudTransportadora);
                                        await _dbContex.SaveChangesAsync();

                                    }
                                    else
                                    {

                                        //la cantidad supera a la del deposito
                                        return 1;
                                    }


                                }
                                else
                                {

                                    //deposito no existe
                                    return 2;
                                }


                            }
                            else
                            {

                                //la solicitud no es cerrada
                                return 3;
                            }

                        }
                        else
                        {

                            //ya existe una trasnportadora para esa solicitud.
                            return 4;

                        }
                    }
                    else { 
                    
                        //solicitud de retiro no existe
                        return 5;   
                    }
                               
                }
                catch (Exception ex)
                {
                    return 6;
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return 7;
            }
        }
        #endregion

        #region Cerrar solicitud de retiro
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
        #endregion

        #region Ingresar solicitud de retiros autorizacion Cerrada
        public async Task<dynamic> IngresarSolicitudRetirosAutorizacionCerrada(MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion)
        {
            var ObjSolicituAutorizacion = new MdloDtos.SolicitudRetiroAutorizacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudAutorizacion.SraRowidSlctudRtro);
                    if (SolicitudRetiroExiste != null)
                    {
                        if (SolicitudRetiroExiste.SrAbrta == false)
                        {

                            var solicitudAutorizacion = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                                               where p.SraRowidSlctudRtro == _SolicitudAutorizacion.SraRowidSlctudRtro
                                                               select p).ToListAsync();
                            int? kilosTrasnportadora = 0;
                            int? unidadesTrasnportadora = 0;
                            foreach (var item in solicitudAutorizacion)
                            {
                                kilosTrasnportadora = kilosTrasnportadora + item.SraAutrzdoKlos;
                                unidadesTrasnportadora = unidadesTrasnportadora + item.SraAutrzdoUnddes;
                            }
                            //validacion de cantidad de la solicitud
                            if ((SolicitudRetiroExiste.SrAutrzdoKlos >= kilosTrasnportadora + _SolicitudAutorizacion.SraAutrzdoKlos) && (SolicitudRetiroExiste.SrAutrzdoCntdad >= unidadesTrasnportadora + SolicitudRetiroExiste.SrAutrzdoCntdad))
                            {
                                int? kilosSolicitidTrasnportadora = 0;
                                int? cantidadesolicitidTrasnportadora = 0;
                                var solicitudTrasnportadora = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                                                     where p.SrtRowidSlctudRtro == _SolicitudAutorizacion.SraRowidSlctudRtro && p.SrtRowidTrnsprtdra == _SolicitudAutorizacion.SraRowidTrnsprtdra
                                                                     select p).ToListAsync();
                                foreach (var item in solicitudTrasnportadora)
                                {
                                    kilosSolicitidTrasnportadora = item.SrtAutrzdoKlos + kilosSolicitidTrasnportadora;
                                    cantidadesolicitidTrasnportadora = item.SrtAutrzdoUnddes + cantidadesolicitidTrasnportadora;
                                }
                                //validacion de cantidad de de la trasmportadora versus lo autorizado
                                if ((SolicitudRetiroExiste.SrAutrzdoKlos >= _SolicitudAutorizacion.SraAutrzdoKlos+ kilosTrasnportadora) && (SolicitudRetiroExiste.SrAutrzdoCntdad >= _SolicitudAutorizacion.SraAutrzdoUnddes+ unidadesTrasnportadora))
                                {
                                    DateTime actual = DateTime.Today;
                                    ObjSolicituAutorizacion.SraRowidSlctudRtro = _SolicitudAutorizacion.SraRowidSlctudRtro;
                                    ObjSolicituAutorizacion.SraRowidTrnsprtdra = _SolicitudAutorizacion.SraRowidTrnsprtdra;
                                    ObjSolicituAutorizacion.SraAutrzdoKlos = _SolicitudAutorizacion.SraAutrzdoKlos;
                                    ObjSolicituAutorizacion.SraAutrzdoUnddes = _SolicitudAutorizacion.SraAutrzdoUnddes;
                                    ObjSolicituAutorizacion.SraFcha = actual;
                                    ObjSolicituAutorizacion.SraCdgoUsrio = _SolicitudAutorizacion.SraCdgoUsrio;
                                    var res = await _dbContex.SolicitudRetiroAutorizacions.AddAsync(ObjSolicituAutorizacion);
                                    await _dbContex.SaveChangesAsync();
                                }
                                else {
                                    //kilos y unidades autorizado a la trasmportadora es mayor a lo solicitado
                                    return 6;
                                }
                            }
                            else
                            {

                                //kilos y unidades mayores que la solicitud de retiro.
                                return 1;
                            }


                        }
                        else
                        {
                            //la solicitud no es cerrada
                            return 2;
                        }

                    }
                    else { 
                    
                        //solicitud de retiro no existe;
                        return 3;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                    return 4;
                }
                _dbContex.Dispose();
                return 5;
            }

        }
        #endregion

        #region Ingresar solicitud de retiros autorizacion Abierta
        public async Task<dynamic> IngresarSolicitudRetirosAutorizacionAbierta(MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion)
        {
            var ObjSolicituAutorizacion = new MdloDtos.SolicitudRetiroAutorizacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    int? Kilos_deposito = 0;
                    int? unidades_deposito = 0;
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudAutorizacion.SraRowidSlctudRtro);
                    if (SolicitudRetiroExiste != null)
                    {
                        if (SolicitudRetiroExiste.SrAbrta == true)
                        {
                            var solicitudAutorizacion = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                                               where p.SraRowidSlctudRtro == _SolicitudAutorizacion.SraRowidSlctudRtro
                                                               select p).ToListAsync();
                            int? kilosTrasnportadora = 0;
                            int? unidadesTrasnportadora = 0;
                            foreach (var item in solicitudAutorizacion)
                            {
                                kilosTrasnportadora = kilosTrasnportadora + item.SraAutrzdoKlos;
                                unidadesTrasnportadora = unidadesTrasnportadora + item.SraAutrzdoUnddes;
                            }
                            //validacion contatidad del deposito.
                            MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(SolicitudRetiroExiste.SrRowidDpsto);
                            if (DepositoExiste != null)
                            {
                                //cantidad del deposito
                                Kilos_deposito = DepositoExiste.DeBlKlos;
                                unidades_deposito = DepositoExiste.DeBlUnddes;
                                if ((Kilos_deposito >= _SolicitudAutorizacion.SraAutrzdoKlos + kilosTrasnportadora) && (unidades_deposito >= _SolicitudAutorizacion.SraAutrzdoUnddes + unidadesTrasnportadora))
                                {
                                    DateTime actual = DateTime.Today;
                                    ObjSolicituAutorizacion.SraRowidSlctudRtro = _SolicitudAutorizacion.SraRowidSlctudRtro;
                                    ObjSolicituAutorizacion.SraRowidTrnsprtdra = null;
                                    ObjSolicituAutorizacion.SraAutrzdoKlos = _SolicitudAutorizacion.SraAutrzdoKlos;
                                    ObjSolicituAutorizacion.SraAutrzdoUnddes = _SolicitudAutorizacion.SraAutrzdoUnddes;
                                    ObjSolicituAutorizacion.SraFcha = actual;
                                    ObjSolicituAutorizacion.SraCdgoUsrio = _SolicitudAutorizacion.SraCdgoUsrio;
                                    var res = await _dbContex.SolicitudRetiroAutorizacions.AddAsync(ObjSolicituAutorizacion);
                                    await _dbContex.SaveChangesAsync();

                                    //actualiza la data de la solicitud.
                                    SolicitudRetiroExiste.SrAutrzdoKlos = kilosTrasnportadora + _SolicitudAutorizacion.SraAutrzdoKlos;
                                    SolicitudRetiroExiste.SrAutrzdoCntdad = kilosTrasnportadora + _SolicitudAutorizacion.SraAutrzdoUnddes;
                                    _dbContex.SolicitudRetiros.Entry(SolicitudRetiroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    await _dbContex.SaveChangesAsync();
                                }
                                else
                                {
                                    //unidades y kilos superan a las del deposito
                                    return 1;
                                }

                            }
                            else {

                                //deposito no existe
                                return 2;
                            }

                        }
                        else
                        {
                            //la solicitud no es abierta
                            return 3;
                        }
                    }
                    else {

                        return 4;
                        //la solicitud no existe
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                    return 5;
                }
                _dbContex.Dispose();
                return 6;
            }

        }
        #endregion

        #region Actualiza Solicitud de retiro ( abierta o cerrada)
        public async Task<dynamic> EditarSolicitudRetiro(MdloDtos.SolicitudRetiro _SolicitudRetiro)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    int? Kilos_deposito = 0;
                    int? unidades_deposito = 0;
                    MdloDtos.SolicitudRetiro SolicitudRetiroExiste = await _dbContex.SolicitudRetiros.FindAsync(_SolicitudRetiro.SrRowid);
                    if (SolicitudRetiroExiste != null)
                    {
                        //validar que no se mayor a la cantidad del deposito.
                        MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(SolicitudRetiroExiste.SrRowidDpsto);
                        if (DepositoExiste != null)
                        {
                            //cantidad del deposito
                            Kilos_deposito = DepositoExiste.DeBlKlos;
                            unidades_deposito = DepositoExiste.DeBlUnddes;
                            //cantidad actuales de la solicitud de retiros
                            int? kilos = SolicitudRetiroExiste.SrAutrzdoKlos;
                            int? unidades = SolicitudRetiroExiste.SrAutrzdoCntdad;
                            //si las cantidades ingresas son menores a la cantidad del deposito.
                            if ((Kilos_deposito >= _SolicitudRetiro.SrAutrzdoKlos ) && (unidades_deposito >= _SolicitudRetiro.SrAutrzdoCntdad ))
                            {
                                //calcular las cantidades si tienen solicitudes ya creadas
                                    var cantidadestrasnspotadoras = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                                                           where p.SraRowidSlctudRtro == _SolicitudRetiro.SrRowid
                                                                           select p).ToListAsync();
                                    int? CantidadTrasnportadora = 0;
                                    int? KilosTrasnportadora = 0;
                                    foreach (var item in cantidadestrasnspotadoras)
                                    {
                                        KilosTrasnportadora = KilosTrasnportadora + item.SraAutrzdoKlos;
                                        CantidadTrasnportadora = CantidadTrasnportadora + item.SraAutrzdoUnddes;
                                    }
                                    //si lo que esta registrando es mayor a lo que esta ya autorizado para las transportadoras
                                    if (_SolicitudRetiro.SrAutrzdoKlos >= KilosTrasnportadora && _SolicitudRetiro.SrAutrzdoCntdad >= CantidadTrasnportadora)
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
                                        //SolicitudRetiroExiste.SrAbrta = _SolicitudRetiro.SrAbrta;
                                        SolicitudRetiroExiste.SrObsrvcnes = _SolicitudRetiro.SrObsrvcnes;
                                        SolicitudRetiroExiste.SrCmpoPrsnlzdo1 = _SolicitudRetiro.SrCmpoPrsnlzdo1;
                                        SolicitudRetiroExiste.SrCmpoPrsnlzdo2 = _SolicitudRetiro.SrCmpoPrsnlzdo2;
                                        SolicitudRetiroExiste.SrCmpoPrsnlzdo3 = _SolicitudRetiro.SrCmpoPrsnlzdo3;
                                        SolicitudRetiroExiste.SrRowidZnaCd = _SolicitudRetiro.SrRowidZnaCd;
                                        _dbContex.SolicitudRetiros.Entry(SolicitudRetiroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                        await _dbContex.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        //ya hay cantidades autorizadas mayores a lo editado 
                                        return 6;

                                    }
                                

                            }
                            else
                            {
                                //las cantidades y killos son mayores a las registradas en el deposito
                                return 1;
                            }
                        }
                        else
                        {
                            //deposito no existe
                            return 2;
                        }
                    }
                    else
                    {
                        //solicitud de retiro no existe
                        return 3;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                    return 4;
                }
                _dbContex.Dispose();
                return 5;
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
                                 join s in _dbContex.Terceros on p.SraRowidTrnsprtdra equals s.TeRowid into trcroJoin
                                 from s in trcroJoin.DefaultIfEmpty()
                                 where (p.SraRowidSlctudRtro == IdSolicitudRetiro )
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
        #region Consultar solicitud de retiros autorizacion por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroAutorizacion>> ConsultarSolicitudRetiroAutorizacionIdRetiroAutorizacion(int IdSolicitudRetiro)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                List<MdloDtos.SolicitudRetiroAutorizacion> listadoSede = new List<MdloDtos.SolicitudRetiroAutorizacion>();

                var lst = await (from p in _dbContex.SolicitudRetiroAutorizacions
                                 join r in _dbContex.SolicitudRetiros on p.SraRowidSlctudRtro equals r.SrRowid
                                 join s in _dbContex.Terceros on p.SraRowidTrnsprtdra equals s.TeRowid into trcroJoin
                                 from s in trcroJoin.DefaultIfEmpty()
                                 where (p.SraRowid == IdSolicitudRetiro)
                                 select new
                                 {

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

        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Autorizacion.
        public async Task<List<MdloDtos.SolicitudRetiroTransportadora>> ConsultarSolicitudRetiroIdRetiroTrasnportadora(int IdSolicitudRetiro)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                List<MdloDtos.SolicitudRetiroTransportadora> listado = new List<MdloDtos.SolicitudRetiroTransportadora>();
                var lst = await (from p in _dbContex.SolicitudRetiroTransportadoras
                                 join r in _dbContex.Terceros on p.SrtRowidTrnsprtdra equals r.TeRowid
                                 where (p.SrtRowidSlctudRtro == IdSolicitudRetiro && r.TeTrnsprtdra == true)
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


        

       


       

        //no se utilizan
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
        #region Consultar solicitud de retiros  Historial por ID retiros Autorizacion.
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

        public Task<SolicitudRetiroTransportadora> IngresarSolicitudRetiroTrasnportadora(SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
