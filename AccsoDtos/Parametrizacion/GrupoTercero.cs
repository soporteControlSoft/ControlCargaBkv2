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
    /// CRUD para el manejo del grupo de tercero
    /// Daniel Alejandro Lopez
    /// </summary>
    public class GrupoTercero:MdloDtos.IModelos.IGrupoModelo
    {

        #region Ingresar datos a la entidad Grupo Tercero
        public async Task<MdloDtos.GrupoTercero> IngresarGrupoTercero(MdloDtos.GrupoTercero _GrupoTercero)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjGrupoTercero = new MdloDtos.GrupoTercero();
                try
                {
                    var GrupoTerceroExiste = await this.VerificarGrupoTercero(_GrupoTercero.GtCdgo);

                    if (GrupoTerceroExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjGrupoTercero.GtCdgo = _GrupoTercero.GtCdgo;
                        ObjGrupoTercero.GtActvo = _GrupoTercero.GtActvo;
                        ObjGrupoTercero.GtDscrpcion = _GrupoTercero.GtDscrpcion;
                        var res = await _dbContex.GrupoTerceros.AddAsync(ObjGrupoTercero);
                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjGrupoTercero;
            }

        }
        #endregion

        #region Consultar todos los datos de Grupo Tercero mediante un parametro Codigo general
        public async Task<List<MdloDtos.GrupoTercero>> FiltrarGrupoTerceroGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.GrupoTerceros
                                 where p.GtCdgo.Contains(Codigo) || p.GtDscrpcion.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Grupo Tercero mediante un parametro Codigo de grupo tercero
        public async Task<List<MdloDtos.GrupoTercero>> FiltrarGrupoTerceroEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.GrupoTerceros
                             where p.GtCdgo==Codigo
                             select p).ToListAsync();

                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Actualizar grupo Tercero pasando el objeto _GrupoTercero
        public async Task<MdloDtos.GrupoTercero> EditarGrupoTercero(MdloDtos.GrupoTercero _GrupoTercero)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try {
                    MdloDtos.GrupoTercero GrupoTerceroExiste = await _dbContex.GrupoTerceros.FindAsync(_GrupoTercero.GtCdgo);
                    if (GrupoTerceroExiste != null)
                    {

                        GrupoTerceroExiste.GtActvo = _GrupoTercero.GtActvo;
                        GrupoTerceroExiste.GtDscrpcion = _GrupoTercero.GtDscrpcion;
                        _dbContex.Entry(GrupoTerceroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return GrupoTerceroExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }

        #endregion

        #region Consultar todos los datos de Grupo Tercero
        public async Task<List<MdloDtos.GrupoTercero>> ListarGrupoTercero()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.GrupoTerceros.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        

        }

        #endregion

        #region Eliminar Grupo Tercero
        public async Task<MdloDtos.GrupoTercero> EliminarGrupoTercero(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var GrupoTerceroExiste = await _dbContex.GrupoTerceros.FindAsync(Codigo);
                    if (GrupoTerceroExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(GrupoTerceroExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return GrupoTerceroExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


        }

        #endregion

        #region verificar grupo Tercero
        public async Task<bool> VerificarGrupoTercero(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjGrupoTercero = await _dbContex.GrupoTerceros.FindAsync(Codigo);
                    if (ObjGrupoTercero == null)
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
