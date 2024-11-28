using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.EstadoHechos
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Clasificacion
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Clasificacion:MdloDtos.IModelos.IClasificacion
    {
        #region Ingresar datos a la entidad Clasificacion
        public async Task<MdloDtos.Clasificacion> IngresarClasificacion(MdloDtos.Clasificacion _Clasificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjClasificacion = new MdloDtos.Clasificacion();
                try
                {
                    var ClasificacionExiste = await this.VerificarClasificacion(_Clasificacion.ClRowid);

                    if (ClasificacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        DateTime fechaSistema = DateTime.Now;

                        ObjClasificacion.ClNmbre = _Clasificacion.ClNmbre;
                        ObjClasificacion.ClDscrpcion = _Clasificacion.ClDscrpcion;
                        ObjClasificacion.ClFchaCrcion = fechaSistema;
                        ObjClasificacion.ClCdgoUsrio = _Clasificacion.ClCdgoUsrio;
                        ObjClasificacion.ClActvo = true;

                        var res = await _dbContex.Clasificacions.AddAsync(ObjClasificacion);


                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjClasificacion;
            }

        }
        #endregion

        #region Listar todos las clasificaciones
        public async Task<List<MdloDtos.Clasificacion>> ListarClasificacion(bool estado = true)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Consulta usando LINQ to SQL
                var query = from clasificacion in _dbContex.Clasificacions
                            where clasificacion.ClActvo == estado
                            select clasificacion;

                // Ejecutar la consulta de manera asíncrona
                var listClasificacion = await query.ToListAsync();

                return listClasificacion;
            }
        }
        #endregion

        #region Actualizar _Clasificacion
        public async Task<MdloDtos.Clasificacion> EditarClasificacion(MdloDtos.Clasificacion _Clasificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Clasificacion ClasificacionExiste = await _dbContex.Clasificacions.FindAsync(_Clasificacion.ClRowid);
                    if (ClasificacionExiste != null)
                    {

                        ClasificacionExiste.ClNmbre = _Clasificacion.ClNmbre;
                        ClasificacionExiste.ClDscrpcion = _Clasificacion.ClDscrpcion;
                        ClasificacionExiste.ClCdgoUsrio = _Clasificacion.ClCdgoUsrio;
                        ClasificacionExiste.ClActvo = _Clasificacion.ClActvo;


                        _dbContex.Entry(ClasificacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return ClasificacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion

        #region Filtrar Clasificacion por codigo general
        public async Task<List<MdloDtos.Clasificacion>> FiltrarClasificacionGeneral(string Codigo, bool estado)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from clasificacion in _dbContex.Clasificacions
                                 where clasificacion.ClActvo == estado // Validar el estado
                                       && (clasificacion.ClRowid.ToString().Contains(Codigo) // Validar ClRowid
                                       || clasificacion.ClNmbre.Contains(Codigo)) // Validar ClNmbre
                                 select clasificacion).ToListAsync();
                return lst;
            }
        }
        #endregion

        #region Filtrar Clasificacion por codigo Especifico clasificacion
        public async Task<List<MdloDtos.Clasificacion>> FiltrarClasificacionEspecifico(string Codigo, bool estado)
        {
            // Intentar convertir el código a entero
            if (!int.TryParse(Codigo, out int codigoConvert))
            {
                throw new ArgumentException("El valor de Código no es un número válido.");
            }

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por el código específico y el estado
                var lst = await (from clasificacion in _dbContex.Clasificacions
                                 where clasificacion.ClRowid == codigoConvert && clasificacion.ClActvo == estado
                                 select clasificacion).ToListAsync();

                return lst;
            }
        }

        #endregion

        #region Inactivar Clasificacion Por codigo.
        public async Task<MdloDtos.Clasificacion> InactivarClasificacion(MdloDtos.Clasificacion _Clasificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Clasificacion ClasificacionExiste = await _dbContex.Clasificacions.FindAsync(_Clasificacion.ClRowid);
                    if (ClasificacionExiste != null)
                    {
                        ClasificacionExiste.ClActvo = _Clasificacion.ClActvo;

                        _dbContex.Entry(ClasificacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return ClasificacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion

        #region verificar clasificacion por RowId.
        public async Task<bool> VerificarClasificacion(int Codigo)
        {
            bool respuesta = false;
            if(Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from c in _dbContex.Clasificacions
                                   where c.ClRowid == Codigo
                                   select c).Count();

                        var ObjClasificacion = lst;
                        if (ObjClasificacion == null || ObjClasificacion == 0)
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
                }
            }
            return respuesta;
        }
        #endregion

    }
}
