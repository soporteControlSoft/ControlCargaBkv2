using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AccsoDtos.EstadoHechos
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Evento
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Evento:MdloDtos.IModelos.IEventos
    {
        private readonly CcVenturaContext _dbContext;
        private readonly IMapper _mapper;

        public Evento(IMapper mapper, MdloDtos.CcVenturaContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        #region Ingresar datos a la entidad Evento
        public async Task<MdloDtos.DTO.EventoDTO> IngresarEvento(MdloDtos.DTO.EventoDTO _EventoDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjEvento = new MdloDtos.Evento();
                try
                {
                    var EvntoExiste = await this.VerificarEvento(_EventoDTO.IdEvento);

                    if (EvntoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        DateTime fechaSistema = DateTime.Now;

                        ObjEvento.EvNmbre = _EventoDTO.Nombre;
                        ObjEvento.EvObsrvcion = _EventoDTO.Observacion;
                        ObjEvento.EvFchaCrcion = fechaSistema;
                        ObjEvento.EvFchaIncio = _EventoDTO.FechaInicio;
                        ObjEvento.EvFchaFin = _EventoDTO.FechaFin;
                        ObjEvento.EvEsctlla = _EventoDTO.Escotilla;
                        ObjEvento.EvRowidClsfccion = _EventoDTO.CodigoClasificacion;
                        ObjEvento.EvRowidRspnsble = _EventoDTO.CodigoResponsable;
                        ObjEvento.EvEqpo = _EventoDTO.Equipo;
                        ObjEvento.EvCdgoUsrio = _EventoDTO.CodigoUsuario;
                        ObjEvento.EvActvo = true;

                        var res = await _dbContex.Eventos.AddAsync(ObjEvento);


                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _EventoDTO;
            }

        }
        #endregion

        #region Listar todos las Evento
        public async Task<List<MdloDtos.DTO.EventoDTO>> ListarEvento(bool estado = true)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from eventos in _dbContex.Eventos
                            where eventos.EvActvo == estado
                            select eventos).ToListAsync();
            
                // Ejecutar la consulta de manera asíncrona
                var list = _mapper.Map<List<EventoDTO>>(query);
                return list;
            }
        }
        #endregion

        #region Actualizar Eventos por el objeto Evento
        public async Task<MdloDtos.DTO.EventoDTO> EditarEvento(MdloDtos.DTO.EventoDTO _EventoDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Evento EventoExiste = await _dbContex.Eventos.FindAsync(_EventoDTO.IdEvento);
                    if (EventoExiste != null)
                    {

                        EventoExiste.EvNmbre = _EventoDTO.Nombre;
                        EventoExiste.EvObsrvcion = _EventoDTO.Observacion;
                        EventoExiste.EvFchaIncio = _EventoDTO.FechaInicio;
                        EventoExiste.EvFchaFin = _EventoDTO.FechaFin;
                        EventoExiste.EvEsctlla = _EventoDTO.Escotilla;
                        EventoExiste.EvRowidClsfccion = _EventoDTO.CodigoClasificacion;
                        EventoExiste.EvRowidRspnsble = _EventoDTO.CodigoResponsable;
                        EventoExiste.EvEqpo = _EventoDTO.Equipo;
                        EventoExiste.EvCdgoUsrio = _EventoDTO.CodigoUsuario;
                        EventoExiste.EvActvo = _EventoDTO.Estado;

                        _dbContex.Entry(EventoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _EventoDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
               
            }
            
        }
        #endregion

        #region Filtrar eventos por codigo general
        public async Task<List<MdloDtos.DTO.EventoDTO>> FiltrarEventoGeneral(string Codigo, bool estado)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código (RowID o nombre) y estado
                var query = await (from ev in _dbContex.Eventos
                                 where (ev.EvRowid.ToString().Contains(Codigo) || ev.EvNmbre.Contains(Codigo))
                                       && ev.EvActvo == estado // Validar el estado
                                 select ev).ToListAsync();

                // Ejecutar la consulta de manera asíncrona
                var list = _mapper.Map<List<EventoDTO>>(query);
                return list;
            }
        }
        #endregion

        #region Filtrar evento por codigo Especifico clasificacion
        public async Task<List<MdloDtos.DTO.EventoDTO>> FiltrarEventoEspecifico(string Codigo, bool estado)
        {
            // Convertir el código a entero
            int codigoConvert = int.Parse(Codigo);

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código específico y estado
                var query = await (from ev in _dbContex.Eventos
                                 where ev.EvRowid == codigoConvert && ev.EvActvo == estado
                                 select ev).ToListAsync();

                // Ejecutar la consulta de manera asíncrona
                var list = _mapper.Map<List<EventoDTO>>(query);
                return list;
            }
        }
        #endregion

        #region Inactivar Evento Por codigo.
        public async Task<MdloDtos.DTO.EventoDTO> InactivarEvento(MdloDtos.DTO.EventoDTO _EventoDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Evento EventoExiste = await _dbContex.Eventos.FindAsync(_EventoDTO.IdEvento);
                    if (EventoExiste != null)
                    {
                        EventoExiste.EvActvo = _EventoDTO.Estado;

                        _dbContex.Entry(EventoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _EventoDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }
        }
        #endregion

        #region verificar Ciudad por RowId.
        public async Task<bool> VerificarEvento(int Codigo)
        {
            bool respuesta = false;
            if(Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from e in _dbContex.Eventos
                                   where e.EvRowid == Codigo
                                   select e).Count();

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
