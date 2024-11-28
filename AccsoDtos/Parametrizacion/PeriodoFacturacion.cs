using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// CRUD para el manejo de los periodos de facturación
    /// Wilbert Rivas Granados
    /// Ajuste Daniel Lopez
    /// </summary>
    /// 
    public class PeriodoFacturacion : MdloDtos.IModelos.IPeriodoFacturacion
    {
        #region ingreso de datos a la entidad Periodo Facturacion
        public async Task<MdloDtos.PeriodoFacturacion> IngresarPeriodoFacturacion(MdloDtos.PeriodoFacturacion _PeriodoFacturacion)
        { 
            var ObjPeriodoFacturacion = new MdloDtos.PeriodoFacturacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PeriodoFacturacionExiste = await this.VerificarPeriodoFacturacion(_PeriodoFacturacion.PfCdgo);
                    if (PeriodoFacturacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPeriodoFacturacion.PfCdgo = _PeriodoFacturacion.PfCdgo;
                        ObjPeriodoFacturacion.PfNmbre = _PeriodoFacturacion.PfNmbre;
                        ObjPeriodoFacturacion.PfDias = _PeriodoFacturacion.PfDias;
                        ObjPeriodoFacturacion.PfPrmdio = _PeriodoFacturacion.PfPrmdio;
                        ObjPeriodoFacturacion.PfCdgoErp = _PeriodoFacturacion.PfCdgoErp;
                        var res = await _dbContex.PeriodoFacturacions.AddAsync(ObjPeriodoFacturacion);
                        await _dbContex.SaveChangesAsync();
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjPeriodoFacturacion;
            }
        }
        #endregion

        #region Consulta los datos de Periodo Facturacion mediante un parámetro Codigo General
        public async Task<List<MdloDtos.PeriodoFacturacion>> FiltrarPeriodoFacturacionGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.PeriodoFacturacions
                                 where m.PfCdgo.Contains(Codigo) || m.PfNmbre.Contains(Codigo)
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consulta los datos de Periodo Facturacion mediante un parámetro Codigo Periodo Facturacion
        public async Task<List<MdloDtos.PeriodoFacturacion>> FiltrarPeriodoFacturacionEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.PeriodoFacturacions
                                 where m.PfCdgo == Codigo
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Actualiza un Periodo Facturacion pasando un objeto _PeriodoFacturacion
        public async Task<MdloDtos.PeriodoFacturacion> EditarPeriodoFacturacion(MdloDtos.PeriodoFacturacion _PeriodoFacturacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.PeriodoFacturacion PeriodoFacturacionExiste = await _dbContex.PeriodoFacturacions.FindAsync(_PeriodoFacturacion.PfCdgo);
                    if (PeriodoFacturacionExiste != null)
                    {
                        PeriodoFacturacionExiste.PfNmbre = _PeriodoFacturacion.PfNmbre;
                        PeriodoFacturacionExiste.PfDias = _PeriodoFacturacion.PfDias;
                        PeriodoFacturacionExiste.PfPrmdio = _PeriodoFacturacion.PfPrmdio;
                        PeriodoFacturacionExiste.PfCdgoErp = _PeriodoFacturacion.PfCdgoErp;

                        _dbContex.PeriodoFacturacions.Entry(PeriodoFacturacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return PeriodoFacturacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de PeriodoFacturacion.
        public async Task<List<MdloDtos.PeriodoFacturacion>> ListarPeriodoFacturacion()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.PeriodoFacturacions.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Elimina un Periodo Facturacion pasando como parámetro Codigo
        public async Task<MdloDtos.PeriodoFacturacion> EliminarPeriodoFacturacion(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PeriodoFacturacionExiste = await _dbContex.PeriodoFacturacions.FindAsync(Codigo);
                    if (PeriodoFacturacionExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.PeriodoFacturacions.Remove(PeriodoFacturacionExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return PeriodoFacturacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar un Periodo Facturacion pasando como párametro Codigo
        public async Task<bool> VerificarPeriodoFacturacion(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPeriodoFacturacion = await _dbContex.PeriodoFacturacions.FindAsync(Codigo);
                    if (ObjPeriodoFacturacion == null)
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
