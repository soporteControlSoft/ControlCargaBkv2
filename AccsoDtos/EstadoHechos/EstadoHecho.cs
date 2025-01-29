using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AccsoDtos.EstadoHechos
{
    /// <summary>
    /// Clase para el acceso a datos de la clase EstadoHecho
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class EstadoHecho : MdloDtos.IModelos.IEstadoHechos
    {
        private readonly CcVenturaContext _dbContext;
        private readonly IMapper _mapper;

        public EstadoHecho(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Ingresar datos a la entidad EstadoHecho
        public async Task<dynamic> IngresarEstadoHecho(MdloDtos.DTO.EstadoHechoDTO _EstadoHecho)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjEstadoHecho = new MdloDtos.EstadoHecho();
                try
                {
                    var EstadoHechoExiste = await this.VerificarEstadoHecho(_EstadoHecho.EhRowid);

                    if (EstadoHechoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        DateTime fechaSistema = DateTime.Now;

                        ObjEstadoHecho.EhObsrvcion = _EstadoHecho.EhObsrvcion;
                        ObjEstadoHecho.EhFchaCrcion = fechaSistema;
                        ObjEstadoHecho.EhFchaIncio = _EstadoHecho.EhFchaIncio;
                        ObjEstadoHecho.EhFchaFin = string.IsNullOrWhiteSpace(_EstadoHecho.EhFchaFin?.ToString())? (DateTime?)null: _EstadoHecho.EhFchaFin;
                        ObjEstadoHecho.EhEsctlla = _EstadoHecho.EhEsctlla;
                        ObjEstadoHecho.EhRowidEvnto = _EstadoHecho.EhRowidEvnto;
                        ObjEstadoHecho.EhRowidEqpo = _EstadoHecho.EhRowidEqpo;
                        ObjEstadoHecho.EhRowidSctor = _EstadoHecho.EhRowidSctor;
                        ObjEstadoHecho.EhRowidZnaCd = _EstadoHecho.EhRowidZnaCd;
                        ObjEstadoHecho.EhRowidVstaMtnve = _EstadoHecho.EhRowidVstaMtnve;
                        ObjEstadoHecho.EhCdgoUsrio = _EstadoHecho.EhCdgoUsrio;
                        ObjEstadoHecho.EhEstdo = _EstadoHecho.EhEstdo;

                        var res = await _dbContex.EstadoHechos.AddAsync(ObjEstadoHecho);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjEstadoHecho;
            }

        }
        #endregion

        #region Listar todos las EstadoHecho
        public async Task<List<MdloDtos.DTO.EstadoHechoDTO>> ListarEstadoHecho()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query  = await _dbContex.EstadoHechos.ToListAsync();
                _dbContex.Dispose();
               
                var listEstadoHecho = _mapper.Map<List<MdloDtos.DTO.EstadoHechoDTO>>(query);
                return listEstadoHecho;
            }
        }
        #endregion

        #region Actualizar _Clasificacion
        public async Task<MdloDtos.DTO.EstadoHechoDTO> EditarEstadoHecho(MdloDtos.DTO.EstadoHechoDTO _EstadoHecho)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.EstadoHecho EstadoHechoExiste = await _dbContex.EstadoHechos.FindAsync(_EstadoHecho.EhRowid);
                    if (EstadoHechoExiste != null)
                    {

                        EstadoHechoExiste.EhObsrvcion = _EstadoHecho.EhObsrvcion;
                        EstadoHechoExiste.EhFchaCrcion = _EstadoHecho.EhFchaCrcion;
                        EstadoHechoExiste.EhFchaIncio = _EstadoHecho.EhFchaIncio;
                        EstadoHechoExiste.EhFchaFin = _EstadoHecho.EhFchaFin;
                        EstadoHechoExiste.EhEsctlla = _EstadoHecho.EhEsctlla;
                        EstadoHechoExiste.EhRowidEvnto = _EstadoHecho.EhRowidEvnto;
                        EstadoHechoExiste.EhRowidEqpo = _EstadoHecho.EhRowidEqpo;
                        EstadoHechoExiste.EhRowidSctor = _EstadoHecho.EhRowidSctor;
                        EstadoHechoExiste.EhRowidZnaCd = _EstadoHecho.EhRowidZnaCd;
                        EstadoHechoExiste.EhRowidVstaMtnve = _EstadoHecho.EhRowidVstaMtnve;
                        EstadoHechoExiste.EhCdgoUsrio = _EstadoHecho.EhCdgoUsrio;
                        EstadoHechoExiste.EhEstdo= _EstadoHecho.EhCdgoUsrio;
                        _dbContex.Entry(EstadoHechoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();

                    return _mapper.Map<EstadoHechoDTO>(EstadoHechoExiste);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion

        #region Filtrar Clasificacion por codigo general
        public async Task<List<MdloDtos.DTO.EstadoHechoDTO>> FiltrarEstadoHechoGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var query = await (from EstadoHecho in _dbContex.EstadoHechos
                                 where EstadoHecho.EhRowid.ToString().Contains(Codigo) || EstadoHecho.EhObsrvcion.Contains(Codigo)
                                 select EstadoHecho).ToListAsync();
                _dbContex.Dispose();
                var lst = _mapper.Map<List<MdloDtos.DTO.EstadoHechoDTO>>(query);
                return lst;
            }
        }
        #endregion

        #region Filtrar EstadoHecho por codigo Especifico EstadoHecho
        public async Task<List<MdloDtos.DTO.EstadoHechoDTO>> FiltrarEstadoHechoEspecifico(string Codigo)
        {
            int codigoConvet = int.Parse(Codigo);

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var query = await (from EstadoHecho in _dbContex.EstadoHechos
                                 where EstadoHecho.EhRowid == codigoConvet
                                 select EstadoHecho).ToListAsync();
                _dbContex.Dispose();
                var lst = _mapper.Map<List<MdloDtos.DTO.EstadoHechoDTO>>(query);
                return  lst;
            }
        }
        #endregion

        #region Modificar EstadoEstadoHecho EstadoHecho Por codigo.
        public async Task<MdloDtos.DTO.EstadoHechoDTO> ModificarEstadoEstadoHecho(MdloDtos.DTO.EstadoHechoDTO _EstadoHecho)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.EstadoHecho EstadoHechoExiste = await _dbContex.EstadoHechos.FindAsync(_EstadoHecho.EhRowid);
                    if (EstadoHechoExiste != null)
                    {
                        EstadoHechoExiste.EhEstdo = _EstadoHecho.EhEstdo;

                        _dbContex.Entry(EstadoHechoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _EstadoHecho;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion

        #region Modificar EstadoEstadoHecho EstadoHecho Por codigo.
        public async Task<dynamic> CerrarOcancelarEstadoEstadoHecho(MdloDtos.DTO.EstadoHechoDTO _EstadoHecho)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.EstadoHecho EstadoHechoExiste = await _dbContex.EstadoHechos.FindAsync(_EstadoHecho.EhRowid);
                    if (EstadoHechoExiste != null)
                    {
                        DateTime fechaSistema = DateTime.Now;
                        EstadoHechoExiste.EhEstdo = _EstadoHecho.EhEstdo;
                        EstadoHechoExiste.EhFchaFin = fechaSistema;
                        EstadoHechoExiste.EhObsrvcion = _EstadoHecho.EhObsrvcion;

                        _dbContex.Entry(EstadoHechoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _mapper.Map <EstadoHechoDTO> (EstadoHechoExiste);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

        }
        #endregion
        #region verificar clasificacion por RowId.
        public async Task<bool> VerificarEstadoHecho(int Codigo)
        {
            bool respuesta = false;
            if(Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from eh in _dbContex.EstadoHechos
                                   where eh.EhRowid == Codigo
                                   select eh).Count();

                        var ObjEstadoHecho = lst;
                        if (ObjEstadoHecho == null || ObjEstadoHecho == 0)
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
