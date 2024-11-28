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
    /// Clase para el acceso a datos de la clase Sector
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Sector:MdloDtos.IModelos.ISector
    {
        #region Ingresar datos a la entidad sector
        public async Task<MdloDtos.Sector> IngresarSector(MdloDtos.Sector _Sector)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjSector = new MdloDtos.Sector();
                try
                {
                    // Verifica si el sector ya existe
                    var SectorExiste = await this.VerificarSector(_Sector.SeRowid);

                    if (SectorExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        // Busca el último registro en la tabla Sectors basado en SeCdgo
                        var ultimoSector = await _dbContex.Sectors
                            .OrderByDescending(s => s.SeCdgo)  // Ordena por SeCdgo descendente
                            .FirstOrDefaultAsync();

                        // Inicializamos el nuevo código
                        int nuevoCodigo = 1;  // Valor predeterminado si no hay registros

                        // Verificamos si hay un registro y si el código se puede convertir a int
                        if (ultimoSector != null && int.TryParse(ultimoSector.SeCdgo, out int ultimoCodigo))
                        {
                            // Si se pudo convertir a int, sumamos 1
                            nuevoCodigo = ultimoCodigo + 1;
                        }

                        // Asignamos el nuevo código convertido a ObjSector.SeCdgo
                        ObjSector.SeNmbre = _Sector.SeNmbre;
                        ObjSector.SeCdgo = nuevoCodigo.ToString();  // Convertimos de nuevo a string antes de asignarlo

                        // Agregar el nuevo sector y guardar los cambios
                        await _dbContex.Sectors.AddAsync(ObjSector);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    _dbContex.Dispose();
                }
                return ObjSector;
            }

        }
        #endregion


        #region Listar todos las Sector
        public async Task<List<MdloDtos.Sector>> ListarSector()
        {
            List<MdloDtos.Sector> listSector = new List<MdloDtos.Sector>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                listSector = await _dbContex.Sectors.ToListAsync();
                _dbContex.Dispose();
               
            }
            return listSector;
        }
        #endregion

        #region verificar clasificacion por RowId.
        public async Task<bool> VerificarSector(int Codigo)
        {
            bool respuesta = false;
            if (Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from s in _dbContex.Sectors
                                   where s.SeRowid == Codigo
                                   select s).Count();

                        var ObjSector = lst;
                        if (ObjSector == null || ObjSector == 0)
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
