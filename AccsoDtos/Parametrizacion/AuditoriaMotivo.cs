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
    /// Clase para el acceso a datos de la clase auditoria Motivo.
    /// Daniel Alejandro Lopez
    /// </summary>
    public class AuditoriaMotivo: MdloDtos.IModelos.IAuditoriaMotivo
    {

        #region Ingresar datos a la entidad Auditoria Motivos
        public async Task<MdloDtos.AuditoriaMotivo> IngresarAuditoriaMotivo(MdloDtos.AuditoriaMotivo _AuditoriaMotivo)
    {
        var ObjAuditoriaMotivo = new MdloDtos.AuditoriaMotivo();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var AuditoriaMotivoExiste = await this.VerificarAuditoriaMotivo(_AuditoriaMotivo.AmCdgo);

                    if (AuditoriaMotivoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjAuditoriaMotivo.AmCdgo = _AuditoriaMotivo.AmCdgo;
                        ObjAuditoriaMotivo.AmDscrpcion = _AuditoriaMotivo.AmDscrpcion;
                        ObjAuditoriaMotivo.AmRqrePdirRzon = _AuditoriaMotivo.AmRqrePdirRzon;
                        var res = await _dbContex.AuditoriaMotivos.AddAsync(ObjAuditoriaMotivo);
                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjAuditoriaMotivo;
            }
           
        }
        #endregion

        #region Consultar todos los datos de Auditoria Motivos mediante un parametro Codigo General
        public async Task<List<MdloDtos.AuditoriaMotivo>> FiltrarAuditoriaMotivoGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.AuditoriaMotivos
                                 where p.AmCdgo.Contains(Codigo) || p.AmDscrpcion.Contains(Codigo)
                                 select p).ToListAsync();

                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Auditoria Motivos mediante un parametro Codigo Especifico
        public async Task<List<MdloDtos.AuditoriaMotivo>> FiltrarAuditoriaMotivoEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.AuditoriaMotivos
                                 where p.AmCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Actualizar Auditoria Motivos pasando el objeto _AuditoriaMotivo
        public async Task<MdloDtos.AuditoriaMotivo> EditarAuditoriaMotivo(MdloDtos.AuditoriaMotivo _AuditoriaMotivo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                MdloDtos.AuditoriaMotivo AuditoriaMotivoExiste = await _dbContex.AuditoriaMotivos.FindAsync(_AuditoriaMotivo.AmCdgo);
                if (AuditoriaMotivoExiste != null)
                {

                    AuditoriaMotivoExiste.AmCdgo = _AuditoriaMotivo.AmCdgo;
                    AuditoriaMotivoExiste.AmDscrpcion = _AuditoriaMotivo.AmDscrpcion;
                    AuditoriaMotivoExiste.AmRqrePdirRzon = _AuditoriaMotivo.AmRqrePdirRzon;
                    _dbContex.Entry(AuditoriaMotivoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _dbContex.SaveChangesAsync();

                }
                _dbContex.Dispose();
                return AuditoriaMotivoExiste;
            }
        }

        #endregion

        #region Consultar todos los datos de Auditoria Motivos
        public async Task<List<MdloDtos.AuditoriaMotivo>> ListarAuditoriaMotivo()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.AuditoriaMotivos.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }

        #endregion

        #region Eliminar Auditoria Motivos
        public async Task<MdloDtos.AuditoriaMotivo> EliminarAuditoriaMotivo(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var AuditoriaMotivoExiste = await _dbContex.AuditoriaMotivos.FindAsync(Codigo);
                    if (AuditoriaMotivoExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(AuditoriaMotivoExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return AuditoriaMotivoExiste;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                
            }


        }

        #endregion

        #region verificar Auditoria Motivos
        public async Task<bool> VerificarAuditoriaMotivo(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjAuditoriaMotivo = await _dbContex.AuditoriaMotivos.FindAsync(Codigo);
                    if (ObjAuditoriaMotivo == null)
                    {

                        respuesta = false; ;
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

    
    

    

