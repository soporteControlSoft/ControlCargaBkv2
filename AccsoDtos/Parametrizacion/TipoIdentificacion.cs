using AutoMapper;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    public class TipoIdentificacion : MdloDtos.IModelos.ITipoIdentificacion
    {
        private readonly IMapper _mapper;

        public TipoIdentificacion(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Ingresar datos a la entidad Tipo Identificacion
        public async Task<dynamic> IngresarTipoIdentificacion(MdloDtos.DTO.TipoIdentificacionDTO _TipoIdentificacion)
        {
            var ObjTipoIdentificacion = new MdloDtos.TipoIdentificacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TipoIdentificacionExiste = await this.VerificarTipoIdentificacion(_TipoIdentificacion.Codigo);
                    if (TipoIdentificacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjTipoIdentificacion.TiCdgo = _TipoIdentificacion.Codigo;
                        ObjTipoIdentificacion.TiNmbre = _TipoIdentificacion.Nombre;
                        var res = await _dbContex.TipoIdentificacions.AddAsync(ObjTipoIdentificacion);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjTipoIdentificacion;
            }

        }
        #endregion

        #region Consultar todos los datos de Tipo de identificacion mediante un parametro Codigo general
        public async Task<List<MdloDtos.DTO.TipoIdentificacionDTO>> FiltrarTipoIdentificacionGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.TipoIdentificacions
                                 where p.TiCdgo.Contains(Codigo) || p.TiNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoIdentificacionDTO>>(lst) : new List<TipoIdentificacionDTO>();
                return result;
            }

        }
        #endregion

        #region Consultar todos los datos de Tipo de identificacion mediante un parametro Codigo Especifico
        public async Task<List<MdloDtos.DTO.TipoIdentificacionDTO>> FiltrarTipoIdentificacionEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.TipoIdentificacions
                                 where p.TiCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoIdentificacionDTO>>(lst) : new List<TipoIdentificacionDTO>();
                return result;
            }

        }
        #endregion

        #region Actualizar Tipo Identificacion pasando el objeto _TipoIdentificacion
        public async Task<MdloDtos.DTO.TipoIdentificacionDTO> EditarTipoIdentificacion(MdloDtos.DTO.TipoIdentificacionDTO _TipoIdentificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.TipoIdentificacion TipoIdentificacionExiste = await _dbContex.TipoIdentificacions.FindAsync(_TipoIdentificacion.Codigo);
                    if (TipoIdentificacionExiste != null)
                    {
                        TipoIdentificacionExiste.TiCdgo = _TipoIdentificacion.Codigo;
                        TipoIdentificacionExiste.TiNmbre = _TipoIdentificacion.Nombre;
                        _dbContex.Entry(TipoIdentificacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _TipoIdentificacion;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region Consultar todos los datos de Tipo identificacion
        public async Task<List<MdloDtos.DTO.TipoIdentificacionDTO>> ListarTipoIdentificacion()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.TipoIdentificacions.ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoIdentificacionDTO>>(lst) : new List<TipoIdentificacionDTO>();
                return result;
            }

        }

        #endregion

        #region Eliminar tipo Identificacion
        public async Task<dynamic> EliminarTipoIdentificacion(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TipoIdentificacionExiste = await _dbContex.TipoIdentificacions.FindAsync(Codigo);
                    if (TipoIdentificacionExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(TipoIdentificacionExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return TipoIdentificacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

        }

        #endregion

        #region verificar Tipo Identificacion
        public async Task<bool> VerificarTipoIdentificacion(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjTipoIdentificacion = await _dbContex.TipoIdentificacions.FindAsync(Codigo);
                    respuesta = (ObjTipoIdentificacion == null) ? false : true;
                    _dbContex.Dispose();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion
    }
}
