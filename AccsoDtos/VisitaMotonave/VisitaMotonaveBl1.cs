using AccsoDtos.AccesoSistema;
using AccsoDtos.Parametrizacion;
using AccsoDtos.SituacionPortuaria;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.VisitaMotonave
{
    public class VisitaMotonaveBl1 : MdloDtos.IModelos.IVisitaMotonaveBl1
    {
        #region Ingreso visita motonave bl 1
        public async Task<MdloDtos.VisitaMotonaveDocumento> IngresarVisitaMotonaveBl1(MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveDocumento_)
        {

            var ObjVisitaMotonaveBl1 = new MdloDtos.VisitaMotonaveBl1();
            MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveImportacion = new MdloDtos.VisitaMotonaveDocumento();
            MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveOrden = new MdloDtos.VisitaMotonaveDocumento();
            var VisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveBl1();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //ingresar bl1 
                    ObjVisitaMotonaveBl1.Vmbl1RowidVstaMtnveBl = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl;
                    ObjVisitaMotonaveBl1.Vmbl1NmroLvnte = ObjVisitaMotonaveDocumento_.lvnte;
                    int numero = 1;
                    int MaximoLista = 1;
                    var maximo = (from p in _dbContex.VisitaMotonaveBl1s select p.Vmbl1Lnea).Max();
                    MaximoLista = Convert.ToInt32(maximo);


                    //ingresar el maximo para la linea.
                    if (MaximoLista == null || MaximoLista == 0)
                    {

                        ObjVisitaMotonaveBl1.Vmbl1Lnea = numero;
                    }
                    else
                    {
                        ObjVisitaMotonaveBl1.Vmbl1Lnea = Convert.ToInt32(MaximoLista) + numero;
                    }
                    var resbl = await _dbContex.VisitaMotonaveBl1s.AddAsync(ObjVisitaMotonaveBl1);
                    await _dbContex.SaveChangesAsync();
                    


                    DateTime hoy = DateTime.Now;
                    int i = 1;

                    //organizar.
                    ///consulta suma de la tabla visita motonave documento los que estan en estado de C y A , 
                    ///esto no deben ser mayor a la cantidad de tonelktas de ka visuta motonave Bl.}
                    ///teniendo en cuenta el filtro VmdoRowidVstaMtnveBl en bl.
                    while (i < 2)
                    {

                        //ingresar en dociumentos (declaracion de importacion)
                        ObjVisitaMotonaveImportacion.VmdoRowidVstaMtnve = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnve;
                        ObjVisitaMotonaveImportacion.VmdoCdgoTpoDcmnto = ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmnto;
                        ObjVisitaMotonaveImportacion.VmdoEstdo = "C";
                        ObjVisitaMotonaveImportacion.VmdoRta = ObjVisitaMotonaveDocumento_.VmdoRta;
                        ObjVisitaMotonaveImportacion.VmdoFchaCrgue = hoy;
                        ObjVisitaMotonaveImportacion.VmdoCdgoUsrioCrgue = ObjVisitaMotonaveDocumento_.VmdoCdgoUsrioCrgue;
                        ObjVisitaMotonaveImportacion.VmdoNmro = ObjVisitaMotonaveDocumento_.VmdoNmro;
                        ObjVisitaMotonaveImportacion.VmdoRowidVstaMtnveBl = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl;
                        ObjVisitaMotonaveImportacion.VmdoLnea = ObjVisitaMotonaveBl1.Vmbl1Lnea;
                       

                        if (ObjVisitaMotonaveDocumento_.VmdoNmroOrden != null || Convert.ToInt32(ObjVisitaMotonaveDocumento_.VmdoNmroOrden) != 0
                            )
                        {
                           
                                //ingresar en dociumentos (orden)
                                ObjVisitaMotonaveOrden.VmdoRowidVstaMtnve = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnve;
                                ObjVisitaMotonaveOrden.VmdoCdgoTpoDcmnto = ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmntoOrden;
                                ObjVisitaMotonaveOrden.VmdoEstdo = "C";
                                ObjVisitaMotonaveOrden.VmdoRta = ObjVisitaMotonaveDocumento_.VmdoRtaOrden;
                                ObjVisitaMotonaveOrden.VmdoFchaCrgue = hoy;
                                ObjVisitaMotonaveOrden.VmdoCdgoUsrioCrgue = ObjVisitaMotonaveDocumento_.VmdoCdgoUsrioCrgue;
                                ObjVisitaMotonaveOrden.VmdoNmro = ObjVisitaMotonaveDocumento_.VmdoNmroOrden;
                                ObjVisitaMotonaveOrden.VmdoRowidVstaMtnveBl = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl;
                                ObjVisitaMotonaveOrden.VmdoLnea = ObjVisitaMotonaveBl1.Vmbl1Lnea;
                               
                                ////validar contidades
                                int? SumaCantidadMotonaveDocumento = (from p in _dbContex.VisitaMotonaveDocumentos
                                                                      where p.VmdoRowidVstaMtnveBl == ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl
                                                                      select p.VmdoCntdad).Sum();
                                int? cantidad=SumaCantidadMotonaveDocumento + ObjVisitaMotonaveDocumento_.VmdoCntdad;
                                ////validar contidades
                                var CantidadToneladas = (from p in _dbContex.VisitaMotonaveBls
                                                                      where p.VmblRowid == ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl
                                                                      select p).ToList();
                                int? cantidadToneladas = 0;
                                foreach (var il in CantidadToneladas) {

                                cantidadToneladas = il.VmblTnldasMtrcas;
                                }

                            if (cantidadToneladas >= cantidad)
                            {
                                ObjVisitaMotonaveOrden.VmdoCntdad = ObjVisitaMotonaveDocumento_.VmdoCntdad;
                                //guarda la declaracion //Cambio paso del almacenamiento arriba aca , para guarde todo o nada.
                                var resdeclaracion = await _dbContex.VisitaMotonaveDocumentos.AddAsync(ObjVisitaMotonaveImportacion);
                                await _dbContex.SaveChangesAsync();

                                //guarda la orden
                                var resorden = await _dbContex.VisitaMotonaveDocumentos.AddAsync(ObjVisitaMotonaveOrden);
                                await _dbContex.SaveChangesAsync();
                                //
                            }
                            else {

                                ObjVisitaMotonaveDocumento_ = null;
                            }
                                 
                            
                        }
                        i = i + 1;

                    }



                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjVisitaMotonaveDocumento_;
            }
        }
        #endregion

        #region Actualizar VisitaMotonave BL1(Levante), DO, DeclaraciónImportación
        public async Task<MdloDtos.VisitaMotonaveDocumento> ActualizarVisitaMotonaveBl1(MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveDocumento_)
        {
            var ObjVisitaMotonaveBl1 = new MdloDtos.VisitaMotonaveBl1();
            MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveImportacion = new MdloDtos.VisitaMotonaveDocumento();
            MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveOrden = new MdloDtos.VisitaMotonaveDocumento();
            var VisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveBl1();
            DateTime fecha = DateTime.Now;
            int contadorInsert = 0;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //actualizar levante
                    var query = (from p in _dbContex.VisitaMotonaveBl1s
                                 where p.Vmbl1Lnea == ObjVisitaMotonaveDocumento_.VmdoLnea
                                 select p).ToList();

                    var mayorQuery = query.Max(x => x.Vmbl1Rowid);

                    var queryMaximo = (from p in _dbContex.VisitaMotonaveBl1s
                                       where p.Vmbl1Lnea == ObjVisitaMotonaveDocumento_.VmdoLnea
                                       && p.Vmbl1Rowid == mayorQuery
                                       select p).ToList();
                    foreach (var item in queryMaximo)
                    {
                        if (item.Vmbl1NmroLvnte != ObjVisitaMotonaveDocumento_.lvnte)
                        {

                            ObjVisitaMotonaveBl1.Vmbl1RowidVstaMtnveBl = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl;
                            ObjVisitaMotonaveBl1.Vmbl1NmroLvnte = ObjVisitaMotonaveDocumento_.lvnte;
                            ObjVisitaMotonaveBl1.Vmbl1Lnea = item.Vmbl1Lnea;
                            var resorden = await _dbContex.VisitaMotonaveBl1s.AddAsync(ObjVisitaMotonaveBl1);
                            await _dbContex.SaveChangesAsync();
                        }
                    }
                    //actualizar orden
                    var queryOrden = (from p in _dbContex.VisitaMotonaveDocumentos
                                      where p.VmdoLnea == ObjVisitaMotonaveDocumento_.VmdoLnea
                                      && p.VmdoCdgoTpoDcmnto == ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmntoOrden
                                      select p).ToList();

                    var mayorQueryOrden = queryOrden.Max(x => x.VmdoRowid);

                    var queryMaximoOrden = (from p in _dbContex.VisitaMotonaveDocumentos
                                            where p.VmdoLnea == ObjVisitaMotonaveDocumento_.VmdoLnea
                                             && p.VmdoCdgoTpoDcmnto == ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmntoOrden
                                             && p.VmdoRowid == mayorQueryOrden
                                            select p).ToList();
                    foreach (var item in queryMaximoOrden)
                    {
                        if (item.VmdoEstdo.ToString() != ObjVisitaMotonaveDocumento_.VmdoEstdoOrden && item.VmdoEstdo.ToString().Equals("R"))
                        {
                            if (ObjVisitaMotonaveDocumento_.VmdoNmroOrden != null || Convert.ToInt32(ObjVisitaMotonaveDocumento_.VmdoNmroOrden) != 0)
                            {
                                ObjVisitaMotonaveOrden.VmdoRowidVstaMtnve = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnve;
                                ObjVisitaMotonaveOrden.VmdoCdgoTpoDcmnto = ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmntoOrden;
                                ObjVisitaMotonaveOrden.VmdoEstdo = "C";
                                ObjVisitaMotonaveOrden.VmdoRta = ObjVisitaMotonaveDocumento_.VmdoRtaOrden;
                                ObjVisitaMotonaveOrden.VmdoFchaCrgue = fecha;
                                ObjVisitaMotonaveOrden.VmdoCdgoUsrioCrgue = ObjVisitaMotonaveDocumento_.VmdoCdgoUsrioCrgue;
                                ObjVisitaMotonaveOrden.VmdoNmro = ObjVisitaMotonaveDocumento_.VmdoNmroOrden;
                                ObjVisitaMotonaveOrden.VmdoRowidVstaMtnveBl = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl;
                                ObjVisitaMotonaveOrden.VmdoLnea = ObjVisitaMotonaveDocumento_.VmdoLnea;
                                ObjVisitaMotonaveOrden.VmdoCntdad = ObjVisitaMotonaveDocumento_.VmdoCntdad;
                              
                                contadorInsert++;
                            }
                        }
                    }
                    //actualizar Declaracion 
                    var querynumeroDeclaracion = (from p in _dbContex.VisitaMotonaveDocumentos
                                                  where p.VmdoLnea == ObjVisitaMotonaveDocumento_.VmdoLnea
                                                  && p.VmdoCdgoTpoDcmnto == ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmnto
                                                  select p).ToList();

                    var mayorQuerynumeroDeclaracion = querynumeroDeclaracion.Max(x => x.VmdoRowid);

                    var queryMaximonumeroDeclaracion = (from p in _dbContex.VisitaMotonaveDocumentos
                                                        where p.VmdoLnea == ObjVisitaMotonaveDocumento_.VmdoLnea
                                                         && p.VmdoCdgoTpoDcmnto == ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmnto
                                                         && p.VmdoRowid == mayorQuerynumeroDeclaracion
                                                        select p).ToList();
                    foreach (var item in queryMaximonumeroDeclaracion)
                    {
                        if (item.VmdoEstdo.ToString() != ObjVisitaMotonaveDocumento_.VmdoEstdo && item.VmdoEstdo.ToString().Equals("R"))
                        {
                            if (ObjVisitaMotonaveDocumento_.VmdoNmro != null || Convert.ToInt32(ObjVisitaMotonaveDocumento_.VmdoNmro) != 0)
                            {
                                ObjVisitaMotonaveImportacion.VmdoRowidVstaMtnve = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnve;
                                ObjVisitaMotonaveImportacion.VmdoCdgoTpoDcmnto = ObjVisitaMotonaveDocumento_.VmdoCdgoTpoDcmnto;
                                ObjVisitaMotonaveImportacion.VmdoEstdo = "C";
                                ObjVisitaMotonaveImportacion.VmdoRta = ObjVisitaMotonaveDocumento_.VmdoRta;
                                ObjVisitaMotonaveImportacion.VmdoFchaCrgue = fecha;
                                ObjVisitaMotonaveImportacion.VmdoCdgoUsrioCrgue = ObjVisitaMotonaveDocumento_.VmdoCdgoUsrioCrgue;
                                ObjVisitaMotonaveImportacion.VmdoNmro = ObjVisitaMotonaveDocumento_.VmdoNmro;
                                ObjVisitaMotonaveImportacion.VmdoRowidVstaMtnveBl = ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl;
                                ObjVisitaMotonaveImportacion.VmdoLnea = ObjVisitaMotonaveDocumento_.VmdoLnea;

                                ////validar contidades
                                int? SumaCantidadMotonaveDocumento = (from p in _dbContex.VisitaMotonaveDocumentos
                                                                      where p.VmdoRowidVstaMtnveBl == ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl
                                                                      select p.VmdoCntdad).Sum();
                                int? cantidad = SumaCantidadMotonaveDocumento + ObjVisitaMotonaveDocumento_.VmdoCntdad;
                                ////validar contidades
                                var CantidadToneladas = (from p in _dbContex.VisitaMotonaveBls
                                                         where p.VmblRowid == ObjVisitaMotonaveDocumento_.VmdoRowidVstaMtnveBl
                                                         select p).ToList();
                                int? cantidadToneladas = 0;
                                foreach (var il in CantidadToneladas)
                                {

                                    cantidadToneladas = il.VmblTnldasMtrcas;
                                }

                                if (cantidadToneladas >= cantidad)
                                {
                                    ObjVisitaMotonaveOrden.VmdoCntdad = ObjVisitaMotonaveDocumento_.VmdoCntdad;
                                    var resdeclaracion = await _dbContex.VisitaMotonaveDocumentos.AddAsync(ObjVisitaMotonaveImportacion);
                                    await _dbContex.SaveChangesAsync();

                                    var resorden = await _dbContex.VisitaMotonaveDocumentos.AddAsync(ObjVisitaMotonaveOrden);
                                    await _dbContex.SaveChangesAsync();

                                    contadorInsert++;
                                }

                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();

                return contadorInsert != 0 ? ObjVisitaMotonaveDocumento_ : null;
               
            }
        }
        #endregion
    }
}
