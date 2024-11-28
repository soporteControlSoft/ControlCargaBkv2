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
    /// Clase para el acceso a datos de la clase Responsable
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Responsable : MdloDtos.IModelos.IResponsable
    {
        #region Ingresar datos a la entidad Responsable
        public async Task<MdloDtos.Responsable> IngresarResponsable(MdloDtos.Responsable _Responsable)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjResponsable = new MdloDtos.Responsable();
                try
                {
                    var ResponsableExiste = await this.VerificarResponsable(_Responsable.ReRowid);

                    if (ResponsableExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {

                        DateTime fechaSistema = DateTime.Now;

                        ObjResponsable.ReNmbre = _Responsable.ReNmbre;
                        ObjResponsable.ReDscrpcion = _Responsable.ReDscrpcion;
                        ObjResponsable.ReFchaCrcion = fechaSistema;
                        ObjResponsable.ReCdgoUsrio = _Responsable.ReCdgoUsrio;
                        ObjResponsable.ReActvo = true;


                        var res = await _dbContex.Responsables.AddAsync(ObjResponsable);


                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjResponsable;
            }

        }
        #endregion

        #region Listar todos las clasificaciones
        public async Task<List<MdloDtos.Responsable>> ListarResponsable(bool estado = true)
        {
            
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = from responsable in _dbContex.Responsables
                            where responsable.ReActvo == estado
                            select responsable;



                var listResponsable = await query.ToListAsync();

                return listResponsable;
               
            }
        }
        #endregion

        #region Actualizar  por el objeto Responsable
        public async Task<MdloDtos.Responsable> EditarResponsable(MdloDtos.Responsable _Responsable)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Responsable ResponsableExiste = await _dbContex.Responsables.FindAsync(_Responsable.ReRowid);
                    if (ResponsableExiste != null)
                    {
                        ResponsableExiste.ReNmbre = _Responsable.ReNmbre;
                        ResponsableExiste.ReDscrpcion = _Responsable.ReDscrpcion;
                        ResponsableExiste.ReCdgoUsrio = _Responsable.ReCdgoUsrio;
                        ResponsableExiste.ReActvo = _Responsable.ReActvo;


                        _dbContex.Entry(ResponsableExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ResponsableExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion

        #region Filtrar responsable por codigo general
        public async Task<List<MdloDtos.Responsable>> FiltrarResponsableGeneral(string Codigo, bool estado)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por RowID o nombre y el estado
                var lst = await (from responsable in _dbContex.Responsables
                                 where (responsable.ReRowid.ToString().Contains(Codigo) || responsable.ReNmbre.Contains(Codigo))
                                       && responsable.ReActvo == estado // Validar el estado
                                 select responsable).ToListAsync();

                return lst;
            }
        }

        #endregion

        #region Filtrar Responsable por codigo Especifico Responsable
        public async Task<List<MdloDtos.Responsable>> FiltrarResponsableEspecifico(string Codigo, bool estado)
        {
            // Convertir el código a entero
            int codigoConvert = int.Parse(Codigo);

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código específico y estado
                var lst = await (from responsable in _dbContex.Responsables
                                 where responsable.ReRowid == codigoConvert && responsable.ReActvo == estado
                                 select responsable).ToListAsync();

                return lst;
            }
        }
        #endregion

        #region Inactivar Responsable Por codigo.
        public async Task<MdloDtos.Responsable> InactivarResponsable(MdloDtos.Responsable _Responsable)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Responsable ResponsableExiste = await _dbContex.Responsables.FindAsync(_Responsable.ReRowid);
                    if (ResponsableExiste != null)
                    {
                        ResponsableExiste.ReActvo = _Responsable.ReActvo;
                        _dbContex.Entry(ResponsableExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ResponsableExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion

        #region verificar responsable por RowId.
        public async Task<bool> VerificarResponsable(int? RowId)
        {
            bool respuesta = false;
            if(RowId != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from R in _dbContex.Responsables
                                   where R.ReRowid == RowId
                                   select R).Count();

                        var ObjResponsable = lst;
                        if (ObjResponsable == null || ObjResponsable == 0)
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
