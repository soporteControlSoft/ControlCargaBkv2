using AutoMapper;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Conductor
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Conductor : MdloDtos.IModelos.IConductor
    {
        /* #region Ingresar datos a la entidad Conductor
         public async Task<MdloDtos.Conductor> IngresarConductor(MdloDtos.Conductor conductor)
         {
             using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
             {
                 var ObjConductor = new MdloDtos.Conductor();
                 try
                 {
                     /*var ObjConductor = await this.VerificarConductor(conductor.CnIdntfccion);

                      if (ObjConductor == true)
                      {
                          throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                      }
                      else
                          {

                         ObjConductor.CnIdntfccion = conductor.CnIdntfccion;
                         ObjConductor.CnNmbre = conductor.CnNmbre;
                         ObjConductor.CnFeatures = conductor.CnFeatures;
                         ObjConductor.CnVhclo = conductor.CnVhclo;
                         ObjConductor.CnRowidTrnsprtdra = conductor.CnRowidTrnsprtdra;
                         ObjConductor.CnFchaRgstro = conductor.CnFchaRgstro;
                         ObjConductor.CnCdgoUsrioEnrlo = conductor.CnCdgoUsrioEnrlo;
                         ObjConductor.CnFchaEnrlmnto = conductor.CnFchaEnrlmnto;
                         ObjConductor.CnMvil = conductor.CnMvil;
                         ObjConductor.CnNmroLcncia = conductor.CnNmroLcncia;
                         ObjConductor.CnTpoLcncia = conductor.CnTpoLcncia;
                         ObjConductor.CnFchaVncmntoLcncia = conductor.CnFchaVncmntoLcncia;
                         ObjConductor.CnActvo = conductor.CnActvo;
                         ObjConductor.CnUrbno = conductor.CnUrbno;


                         var res = await _dbContex.Conductors.AddAsync(ObjConductor);
                         await _dbContex.SaveChangesAsync();
                     //}


                 }
                 catch (Exception ex)
                 {
                     throw new Exception(ex.ToString());
                 }
                 _dbContex.Dispose();
                 return ObjConductor;
             }


         }
         #endregion*/

        #region Ingresar datos a la entidad Conductor
        public async Task<MdloDtos.Conductor> IngresarConductor(MdloDtos.Conductor conductor)       {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjConductor = new MdloDtos.Conductor();
                try
                {
                    bool conductorExiste = await this.VerificarExistenciaConductor(conductor.CnIdntfccion);
                    if (conductorExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjConductor.CnIdntfccion = conductor.CnIdntfccion;
                        ObjConductor.CnNmbre = conductor.CnNmbre;
                        ObjConductor.CnFeatures = conductor.CnFeatures;
                        ObjConductor.CnVhclo = conductor.CnVhclo;
                        ObjConductor.CnRowidTrnsprtdra = conductor.CnRowidTrnsprtdra;
                        ObjConductor.CnFchaRgstro = conductor.CnFchaRgstro;
                        ObjConductor.CnCdgoUsrioEnrlo = conductor.CnCdgoUsrioEnrlo;
                        ObjConductor.CnFchaEnrlmnto = conductor.CnFchaEnrlmnto;
                        ObjConductor.CnMvil = conductor.CnMvil;
                        ObjConductor.CnNmroLcncia = conductor.CnNmroLcncia;
                        ObjConductor.CnTpoLcncia = conductor.CnTpoLcncia;
                        ObjConductor.CnFchaVncmntoLcncia = conductor.CnFchaVncmntoLcncia;
                        ObjConductor.CnActvo = conductor.CnActvo;
                        ObjConductor.CnUrbno = conductor.CnUrbno;
                        var res = await _dbContex.Conductors.AddAsync(ObjConductor);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjConductor;
            }
        }
        #endregion

        #region Listar todos los Conductores
        public async Task<List<MdloDtos.VwCndctorLstar>> ListarConductor()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lts = await (from vwCndctorLsta in _dbContex.VwCndctorLstars
                                 select vwCndctorLsta
                               ).ToListAsync();
                _dbContex.Dispose();     
                return lts;
            }
        }
        #endregion

        #region Actualizar Un conductor
        public async Task<MdloDtos.Conductor> EditarConductor(MdloDtos.Conductor _Conductor)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Conductor ConductorExiste = await _dbContex.Conductors.FindAsync(_Conductor.CnIdntfccion);
                    if (ConductorExiste != null)
                    {
                        ConductorExiste.CnIdntfccion = _Conductor.CnIdntfccion;
                        ConductorExiste.CnNmbre = _Conductor.CnNmbre;
                        ConductorExiste.CnFeatures = _Conductor.CnFeatures;
                        ConductorExiste.CnVhclo = _Conductor.CnVhclo;
                        ConductorExiste.CnRowidTrnsprtdra = _Conductor.CnRowidTrnsprtdra;
                        ConductorExiste.CnFchaRgstro = _Conductor.CnFchaRgstro;
                        ConductorExiste.CnCdgoUsrioEnrlo = _Conductor.CnCdgoUsrioEnrlo;
                        ConductorExiste.CnFchaEnrlmnto = _Conductor.CnFchaEnrlmnto;
                        ConductorExiste.CnMvil = _Conductor.CnMvil;
                        ConductorExiste.CnNmroLcncia = _Conductor.CnNmroLcncia;
                        ConductorExiste.CnTpoLcncia = _Conductor.CnTpoLcncia;
                        ConductorExiste.CnFchaVncmntoLcncia = _Conductor.CnFchaVncmntoLcncia;
                        ConductorExiste.CnActvo = _Conductor.CnActvo;
                        ConductorExiste.CnUrbno = _Conductor.CnUrbno;

                        _dbContex.Entry(ConductorExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ConductorExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Filtrar Conductor por codigo general
        public async Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lts = await (from vwCndctorLsta in _dbContex.VwCndctorLstars
                                 where vwCndctorLsta.CnIdntfccion.Contains(Codigo) || vwCndctorLsta.CnNmbre.Contains(Codigo)
                                 select vwCndctorLsta
                               ).ToListAsync();
                _dbContex.Dispose();
                return lts;
            }
        }
        #endregion

        #region Filtrar Conductor por una identificacion Especifica
        public async Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorEspecifico(string Identificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from vwCndctorLsta in _dbContex.VwCndctorLstars
                                 where vwCndctorLsta.CnIdntfccion.Equals(Identificacion.ToString())
                                 select vwCndctorLsta
                               ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Eliminar Conductor Por Identificacion.
        public async Task<MdloDtos.Conductor> EliminarConductor(string Identificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ConductorExiste = await _dbContex.Conductors.FindAsync(Identificacion);
                    if (ConductorExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(ConductorExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ConductorExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar Un conductor a partir de su Identificación .
        public async Task<bool> VerificarExistenciaConductor(string Identificacion)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.VwCndctorLstars
                               where p.CnIdntfccion.Equals(Identificacion)
                               select p).Count();
                    respuesta = (lst == null || lst == 0) ? false : true;                
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
    }             
}
