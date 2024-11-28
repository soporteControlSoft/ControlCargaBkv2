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
    /// Clase para el acceso a datos de la clase equipo
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Equipo:MdloDtos.IModelos.IEquipo
    {
        #region Ingresar datos a la entidad Equipo
        public async Task<MdloDtos.Equipo> IngresarEquipo(MdloDtos.Equipo _Equipo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjEquipo = new MdloDtos.Equipo();
                try
                {
                    var EquipoExiste = await this.VerificarEquipo(_Equipo.EqRowid);

                    if (EquipoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {

                        DateTime fechaSistema = DateTime.Now;

                        ObjEquipo.EqNmbre = _Equipo.EqNmbre;
                        ObjEquipo.EqDscrpcion = _Equipo.EqDscrpcion;
                        ObjEquipo.EqFchaCrcion = fechaSistema;
                        ObjEquipo.EqCdgoUsrio = _Equipo.EqCdgoUsrio;
                        ObjEquipo.EqCdgo = _Equipo.EqCdgo;
                        ObjEquipo.EqActvo = true;


                        var res = await _dbContex.Equipos.AddAsync(ObjEquipo);

                        await _dbContex.SaveChangesAsync();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjEquipo;
            }

        }
        #endregion

        #region Listar todos las equipo
        public async Task<List<MdloDtos.Equipo>> ListarEquipo(bool estado = true)
        {
            List<MdloDtos.Equipo > listEquipo = new List<MdloDtos.Equipo>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = from equipo in _dbContex.Equipos
                            where equipo.EqActvo == estado
                            select equipo;
                listEquipo = await query.ToListAsync();
                _dbContex.Dispose();
               
            }
            return listEquipo;
        }
        #endregion

        #region Actualizar departamentos por el objeto _Equipo
        public async Task<MdloDtos.Equipo> EditarEquipo(MdloDtos.Equipo _Equipo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Equipo EquipoExiste = await _dbContex.Equipos.FindAsync(_Equipo.EqRowid);
                    if (EquipoExiste != null)
                    {
                        EquipoExiste.EqNmbre = _Equipo.EqNmbre;
                        EquipoExiste.EqDscrpcion = _Equipo.EqDscrpcion;
                        EquipoExiste.EqCdgoUsrio = _Equipo.EqCdgoUsrio;
                        EquipoExiste.EqCdgo = _Equipo.EqCdgo;
                        EquipoExiste.EqActvo = _Equipo.EqActvo;
              
                        _dbContex.Entry(EquipoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return EquipoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
               
            }
            
        }
        #endregion

        #region Filtrar Equipo por codigo general
        public async Task<List<MdloDtos.Equipo>> FiltrarEquipoGeneral(string Codigo, bool estado)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código (RowID o nombre) y el estado
                var lst = await (from eq in _dbContex.Equipos
                                 where (eq.EqRowid.ToString().Contains(Codigo) || eq.EqNmbre.Contains(Codigo))
                                       && eq.EqActvo == estado // Validar el estado
                                 select eq).ToListAsync();

                return lst;
            }
        }
        #endregion

        #region Filtrar Equipo por codigo Especifico 
        public async Task<List<MdloDtos.Equipo>> FiltrarEquipoEspecifico(string Codigo, bool estado)
        {
            // Convertir el código a entero
            int codigoConvert = int.Parse(Codigo);

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código específico y estado
                var lst = await (from eq in _dbContex.Equipos
                                 where eq.EqRowid == codigoConvert && eq.EqActvo == estado
                                 select eq).ToListAsync();

                return lst;
            }
        }
        #endregion

        #region inactivar Equipo Por codigo.
        public async Task<MdloDtos.Equipo> InactivarEquipo(MdloDtos.Equipo _Equipo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Equipo EquipoExiste = await _dbContex.Equipos.FindAsync(_Equipo.EqRowid);
                    if (EquipoExiste != null)
                    {
                        EquipoExiste.EqActvo = _Equipo.EqActvo;

                        _dbContex.Entry(EquipoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return EquipoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }
        }
        #endregion

        #region verificar Equipo por RowId.
        public async Task<bool> VerificarEquipo(int Codigo)
        {
            bool respuesta = false;
            if(Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from e in _dbContex.Equipos
                                   where e.EqRowid == Codigo
                                   select e).Count();

                        var ObjEquipo = lst;
                        if (ObjEquipo == null || ObjEquipo == 0)
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
