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
    /// CRUD para el manejo de condiciones de facturación
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class CondicionFacturacion : MdloDtos.IModelos.ICondicionFacturacion
    {
        #region ingreso de datos a la entidad Condicion Facturacion
        public async Task<MdloDtos.CondicionFacturacion> IngresarCondicionFacturacion(MdloDtos.CondicionFacturacion _CondicionFacturacion)
        { 
            var ObjCondicionFacturacion = new MdloDtos.CondicionFacturacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var CondicionFacturacionExiste = await this.VerificarCondicionFacturacion(_CondicionFacturacion.CfCdgo);
                    if (CondicionFacturacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjCondicionFacturacion.CfCdgo = _CondicionFacturacion.CfCdgo;
                        ObjCondicionFacturacion.CfNmbre = _CondicionFacturacion.CfNmbre;
                        ObjCondicionFacturacion.CfFchaBse = _CondicionFacturacion.CfFchaBse;
                        var res = await _dbContex.CondicionFacturacions.AddAsync(ObjCondicionFacturacion);
                        await _dbContex.SaveChangesAsync();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjCondicionFacturacion;
            }
           
        }
        #endregion

        #region Consulta todos los datos de condicion facturacion mediante un parámetro Codigo General
        public async Task<List<MdloDtos.CondicionFacturacion>> FiltrarCondicionFacturacionGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from c in _dbContex.CondicionFacturacions
                                 where c.CfCdgo.Contains(Codigo) || c.CfNmbre.Contains(Codigo)
                                 select c
                             ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion


        #region Consulta todos los datos de condicion facturacion mediante un parámetro Codigo Condicion Facturacion
        public async Task<List<MdloDtos.CondicionFacturacion>> FiltrarCondicionFacturacionEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from c in _dbContex.CondicionFacturacions
                                 where c.CfCdgo == Codigo
                                 select c
                             ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Actualiza una Condicion Facturacion pasando un objeto _CondicionFacturacion
        public async Task<MdloDtos.CondicionFacturacion> EditarCondicionFacturacion(MdloDtos.CondicionFacturacion _CondicionFacturacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    MdloDtos.CondicionFacturacion CondicionFacturacionExiste = await _dbContex.CondicionFacturacions.FindAsync(_CondicionFacturacion.CfCdgo);
                    if (CondicionFacturacionExiste != null)
                    {
                        CondicionFacturacionExiste.CfNmbre = _CondicionFacturacion.CfNmbre;
                        CondicionFacturacionExiste.CfFchaBse = _CondicionFacturacion.CfFchaBse;
                        _dbContex.CondicionFacturacions.Entry(CondicionFacturacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return CondicionFacturacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de Condicion de facturacion.
        public async Task<List<MdloDtos.CondicionFacturacion>> ListarCondicionFacturacion()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.CondicionFacturacions.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Elimina una Condicion Facturacion pasando como parametro Codigo
        public async Task<MdloDtos.CondicionFacturacion> EliminarCondicionFacturacion(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var CondicionFacturacionExiste = await _dbContex.CondicionFacturacions.FindAsync(Codigo);
                    if (CondicionFacturacionExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.CondicionFacturacions.Remove(CondicionFacturacionExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return CondicionFacturacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar una Condicion de facturacion
        public async Task<bool> VerificarCondicionFacturacion(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjCondicionFacturacion = await _dbContex.CondicionFacturacions.FindAsync(Codigo);
                    if (ObjCondicionFacturacion == null)
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
