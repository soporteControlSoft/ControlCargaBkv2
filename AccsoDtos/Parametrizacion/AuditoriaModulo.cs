using MdloDtos.Utilidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Clase para el acceso a datos de la clase auditoria Modulo.
    /// Daniel Alejandro Lopez
    /// </summary>
    public class AuditoriaModulo : MdloDtos.IModelos.IAuditoriaModulo
    {

        #region Ingresar datos a la entidad Auditoria Modulo
        public async Task<MdloDtos.AuditoriaModulo> IngresarAuditoriaModulo(MdloDtos.AuditoriaModulo _AuditoriaModulo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext()) {

                var ObjAuditoriaModulo = new MdloDtos.AuditoriaModulo();
                try
                {
                    var AuditoriaModuloExiste = await this.VerificarAuditoriaModulo(_AuditoriaModulo.AmCdgo);
                    if (AuditoriaModuloExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjAuditoriaModulo.AmCdgo = _AuditoriaModulo.AmCdgo;
                        ObjAuditoriaModulo.AmNmbre = _AuditoriaModulo.AmNmbre;
                        var res = await _dbContex.AuditoriaModulos.AddAsync(ObjAuditoriaModulo);
                        await _dbContex.SaveChangesAsync();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjAuditoriaModulo;
                
            }
           
        }
        #endregion

        #region Consultar todos los datos de Auditoria Modulo mediante un parametro Codigo General
        public async Task<List<MdloDtos.AuditoriaModulo>> FiltrarAuditoriaModuloGeneral(String Codigo)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.AuditoriaModulos
                                 where (p.AmCdgo.Contains(Codigo) || p.AmNmbre.Contains(Codigo))
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Auditoria Modulo mediante un parametro Codigo Especifico
        public async Task<List<MdloDtos.AuditoriaModulo>> FiltrarAuditoriaModuloEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.AuditoriaModulos
                                 where (p.AmCdgo == Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Actualizar grupo Auditoria Modulo el objeto _AuditoriaModulo
        public async Task<MdloDtos.AuditoriaModulo> EditarAuditoriaModulo(MdloDtos.AuditoriaModulo _AuditoriaModulo)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                MdloDtos.AuditoriaModulo AuditoriaModuloExiste = await _dbContex.AuditoriaModulos.FindAsync(_AuditoriaModulo.AmCdgo);
                if (AuditoriaModuloExiste != null)
                {

                    AuditoriaModuloExiste.AmCdgo = _AuditoriaModulo.AmCdgo;
                    AuditoriaModuloExiste.AmNmbre = _AuditoriaModulo.AmNmbre;
                    _dbContex.Entry(AuditoriaModuloExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _dbContex.SaveChangesAsync();

                }
                _dbContex.Dispose();
                return AuditoriaModuloExiste;

            }
               
        }

        #endregion

        #region Consultar todos los datos de Auditoria Modulo
        public async Task<List<MdloDtos.AuditoriaModulo>> ListarAuditoriaModulo()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.AuditoriaModulos.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
               

        }

        #endregion

        #region Eliminar Auditoria Modulo
        public async Task<MdloDtos.AuditoriaModulo> EliminarAuditoriaModulo(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var AuditoriaModuloExiste =new MdloDtos.AuditoriaModulo();
                try
                {
                    AuditoriaModuloExiste = await _dbContex.AuditoriaModulos.FindAsync(Codigo);
                    if (AuditoriaModuloExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(AuditoriaModuloExiste);
                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                _dbContex.Dispose();
                return AuditoriaModuloExiste;
            }
               


        }

        #endregion

        #region verificar Auditoria Modulo
        public async Task<bool> VerificarAuditoriaModulo(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                bool respuesta = false;
                try
                {
                    var ObjAuditoriaModulo = await _dbContex.AuditoriaModulos.FindAsync(Codigo);
                    if (ObjAuditoriaModulo == null)
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
                return respuesta;
            }

        }


        #endregion
    }
}
