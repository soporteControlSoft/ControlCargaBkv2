using MdloDtos;
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
    /// Clase para el acceso a datos de la clase Causal cancelacion
    /// Daniel Alejandro Lopez
    /// </summary>
    public class CausalCancelacion : MdloDtos.IModelos.ICausalCancelacion
    {
        #region Ingresar datos a la entidad Causal Cancelacion
        public async Task<MdloDtos.CausalCancelacion> IngresarCausalCancelacion(MdloDtos.CausalCancelacion _CausalCancelacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjCausalCancelacion = new MdloDtos.CausalCancelacion();
                try
                {
                    var CausalCancelacionExiste = await this.VerificarCausalCancelacion(_CausalCancelacion.CcCdgo);

                    if (CausalCancelacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjCausalCancelacion.CcCdgo = _CausalCancelacion.CcCdgo;
                        ObjCausalCancelacion.CcDscrpcion = _CausalCancelacion.CcDscrpcion;
                        ObjCausalCancelacion.CcOrgen = _CausalCancelacion.CcOrgen;
                        var res = await _dbContex.CausalCancelacions.AddAsync(ObjCausalCancelacion);
                        await _dbContex.SaveChangesAsync();
                    }

                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjCausalCancelacion;
            }

        }
        #endregion

        #region Consultar todos los datos de Causal Cancelacion mediante un parametro Codigo General
        public async Task<List<MdloDtos.CausalCancelacion>> FiltrarCausalCancelacionGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.CausalCancelacions
                                 where p.CcCdgo.Contains(Codigo) || p.CcDscrpcion.Contains(Codigo)
                                 select p).ToListAsync();
                
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consultar todos los datos de Causal Cancelacion mediante un parametro Codigo Causal
        public async Task<List<MdloDtos.CausalCancelacion>> FiltrarCausalCancelacionEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.CausalCancelacions
                                 where p.CcCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Actualizar Causal Cancelacion pasando el objeto _TipoIdentificacion
        public async Task<MdloDtos.CausalCancelacion> EditarCausalCancelacion(MdloDtos.CausalCancelacion _CausalCancelacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.CausalCancelacion CausalCancelacionExiste = await _dbContex.CausalCancelacions.FindAsync(_CausalCancelacion.CcCdgo);
                    if (CausalCancelacionExiste != null)
                    {

                        CausalCancelacionExiste.CcCdgo = _CausalCancelacion.CcCdgo;
                        CausalCancelacionExiste.CcOrgen = _CausalCancelacion.CcOrgen;
                        CausalCancelacionExiste.CcDscrpcion = _CausalCancelacion.CcDscrpcion;
                        _dbContex.Entry(CausalCancelacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return CausalCancelacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }
        }

        #endregion

        #region Consultar todos los datos de Causal Cancelacion
        public async Task<List<MdloDtos.CausalCancelacion>> ListarCausalCancelacion()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                
                var lst = await _dbContex.CausalCancelacions.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }

        #endregion

        #region Eliminar Causal Cancelacion
        public async Task<MdloDtos.CausalCancelacion> EliminarCausalCancelacion(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var CausalCancelacionExiste = await _dbContex.CausalCancelacions.FindAsync(Codigo);
                    if (CausalCancelacionExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(CausalCancelacionExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return CausalCancelacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                
            }


        }

        #endregion

        #region verificar Causal Cancelacion
        public async Task<bool> VerificarCausalCancelacion(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    var ObjCausalCancelacion = await _dbContex.CausalCancelacions.FindAsync(Codigo);
                    if (ObjCausalCancelacion == null)
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

    }
}
