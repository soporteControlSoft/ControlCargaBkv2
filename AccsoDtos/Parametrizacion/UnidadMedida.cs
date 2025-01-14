using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
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
    /// CRUD para el manejo de unidades de medidas
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class UnidadMedida : MdloDtos.IModelos.IUnidadMedida
    {
        private readonly IMapper _mapper;

        public UnidadMedida(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region ingreso de datos a la entidad Unidad de medida
        public async Task<dynamic> IngresarUnidadMedida(MdloDtos.DTO.UnidadMedidumDTO _UnidadMedidum)
        {
            var ObjUnidadMedida = new MdloDtos.UnidadMedidum();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var UnidadMedidaExiste = await this.VerificarUnidadMedida(_UnidadMedidum.Codigo);
                    if (UnidadMedidaExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjUnidadMedida.UmCdgo = _UnidadMedidum.Codigo;
                        ObjUnidadMedida.UmNmbre = _UnidadMedidum.Nombre;
                        ObjUnidadMedida.UmGrnel = _UnidadMedidum.EsGranel;
                        ObjUnidadMedida.UmActvo = _UnidadMedidum.Activo;

                        var res = await _dbContex.UnidadMedida.AddAsync(ObjUnidadMedida);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjUnidadMedida;
            }
        }
        #endregion

        #region Consulta los datos de UnidadMedida mediante un parámetro Codigo General
        public async Task<List<MdloDtos.DTO.UnidadMedidumDTO>> FiltrarUnidadMedidaGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.UnidadMedida
                                 where m.UmCdgo.Contains(Codigo) || m.UmNmbre.Contains(Codigo)
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<UnidadMedidumDTO>>(lst) : new List<UnidadMedidumDTO>();
                return result;
            }
        }
        #endregion

        #region Consulta los datos de UnidadMedida mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.DTO.UnidadMedidumDTO>> FiltrarUnidadMedidaEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.UnidadMedida
                                 where m.UmCdgo == Codigo
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<UnidadMedidumDTO>>(lst) : new List<UnidadMedidumDTO>();
                return result;
            }
        }
        #endregion

        #region Actualiza una UnidadMedida pasando un objeto UnidadMedidum
        public async Task<MdloDtos.DTO.UnidadMedidumDTO> EditarUnidadMedida(MdloDtos.DTO.UnidadMedidumDTO _UnidadMedida)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.UnidadMedidum UnidadMedidaExiste = await _dbContex.UnidadMedida.FindAsync(_UnidadMedida.Codigo);
                    if (UnidadMedidaExiste != null)
                    {
                        UnidadMedidaExiste.UmCdgo = _UnidadMedida.Codigo;
                        UnidadMedidaExiste.UmNmbre = _UnidadMedida.Nombre;
                        UnidadMedidaExiste.UmGrnel = _UnidadMedida.EsGranel;
                        UnidadMedidaExiste.UmActvo = _UnidadMedida.Activo;

                        _dbContex.UnidadMedida.Entry(UnidadMedidaExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _UnidadMedida;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de UnidadMedida.
        public async Task<List<MdloDtos.DTO.UnidadMedidumDTO>> ListarUnidadMedida()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.UnidadMedida.ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<UnidadMedidumDTO>>(lst) : new List<UnidadMedidumDTO>();
                return result;
            }
        }
        #endregion

        #region Elimina una UnidadMedida pasando como parámetro Codigo
        public async Task<dynamic> EliminarUnidadMedida(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var UnidadMedidaExiste = await _dbContex.UnidadMedida.FindAsync(Codigo);
                    if (UnidadMedidaExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.UnidadMedida.Remove(UnidadMedidaExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return UnidadMedidaExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar una UnidadMedida
        public async Task<bool> VerificarUnidadMedida(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjUnidadMedida = await _dbContex.UnidadMedida.FindAsync(Codigo);
                    respuesta = (ObjUnidadMedida == null) ? false : true;
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
