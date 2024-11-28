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
    public class Pais:MdloDtos.IModelos.IPais
    {
        /// <summary>
        /// CRUD para el manejo del Pais
        /// Daniel Alejandro Lopez
        /// </summary>
        /// 
         #region Ingresar datos a la entidad Pais
        public async Task<MdloDtos.Pai> IngresarPais(MdloDtos.Pai _Pais)
        {
            var ObjPäis= new MdloDtos.Pai();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PäisExiste = await this.VerificarPais(_Pais.PaCdgo);

                    if (PäisExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPäis.PaCdgo = _Pais.PaCdgo;
                        ObjPäis.PaNmbre = _Pais.PaNmbre;
                        var res = await _dbContex.Pais.AddAsync(ObjPäis);
                        await _dbContex.SaveChangesAsync();

                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjPäis;
            }

        }
        #endregion

        #region Consultar todos los datos de Pais mediante un parametro Codigo General
        public async Task<List<MdloDtos.Pai>> FiltrarPaisGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Pais
                                 where p.PaCdgo.Contains(Codigo) || p.PaNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Pais mediante un parametro Codigo Especifico
        public async Task<List<MdloDtos.Pai>> FiltrarPaisEspecifico(String Codigo)
        { 
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {    var lst = await (from p in _dbContex.Pais
                              where p.PaCdgo == Codigo
                              select p).ToListAsync();

                 _dbContex.Dispose();
                 return lst;
            }
        }


        #endregion

        #region Actualizar Pais pasando el objeto _Pais
        public async Task<MdloDtos.Pai> EditarPais(MdloDtos.Pai _Pais)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Pai PäisExiste = await _dbContex.Pais.FindAsync(_Pais.PaCdgo);
                    if (PäisExiste != null)
                    {

                        PäisExiste.PaCdgo = _Pais.PaCdgo;
                        PäisExiste.PaNmbre = _Pais.PaNmbre;
                        _dbContex.Entry(PäisExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return PäisExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                
            }
        }

        #endregion

        #region Consultar todos los datos de Pais
        public async Task<List<MdloDtos.Pai>> ListarPais()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.Pais.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }

        #endregion

        #region Eliminar Pais
        public async Task<MdloDtos.Pai> EliminarPais(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PäisExiste = await _dbContex.Pais.FindAsync(Codigo);
                    if (PäisExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(PäisExiste);
                        await _dbContex.SaveChangesAsync();
                    }

                    _dbContex.Dispose();
                    return PäisExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                
            }


        }

        #endregion


        #region verificar Pais
        public async Task<bool> VerificarPais(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPerfil = await _dbContex.Pais.FindAsync(Codigo);
                    if (ObjPerfil == null)
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
