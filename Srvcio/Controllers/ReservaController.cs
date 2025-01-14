using AccsoDtos.AccesoSistema;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Claims;
using VldcionDtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para las reservas
    ///   Wilbert Rivas Granados
    /// </summary>
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly MdloDtos.IModelos.IReserva _dbContex;
        private readonly IMapper _mapper;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

     
        VldcionDtos.ValidacionCompania validacionCompania = new VldcionDtos.ValidacionCompania();
        VldcionDtos.ValidacionDeposito validacionDeposito= new VldcionDtos.ValidacionDeposito();
        VldcionDtos.ValidacionTercero validacionTercero = new VldcionDtos.ValidacionTercero();
        VldcionDtos.ValidacionVisitaMotonave validacionVisitaMotonave = new VldcionDtos.ValidacionVisitaMotonave();
        VldcionDtos.ValidacionReserva validacionReserva = new VldcionDtos.ValidacionReserva();

        public ReservaController(MdloDtos.IModelos.IReserva dbContex, IMapper mapper)
        {
            _dbContex = dbContex;
            _mapper = mapper;
        }



        #region consultar las visitas de motonaves para una compañia en particular
        [HttpGet("listar-visita-motonave-reserva")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.VwMdloRsrvaLstarVstaMtnveDTO>>> ConsultarVisitaMotonave(string codigoCompania)
        {
            var lista = new List<MdloDtos.DTO.VwMdloRsrvaLstarVstaMtnveDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; 
            try
            {
                validacion = await validacionCompania.ValidarFiltroBusquedas(codigoCompania);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    lista = await this._dbContex.ConsultarVisitaMotonave(codigoCompania);
                    if (lista != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = lista;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = lista;
                return BadRequest(respuesta);
            }
            return lista;
        }
        #endregion

        #region consultar las visitas de motonaves para una compañia en particular
        [HttpGet("listar-deposito-reserva")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.VwMdloRsrvaLstarDpstoDTO>>> ConsultarDeposito(int idVisitaMotonave)
        {
            var lista = new List<MdloDtos.DTO.VwMdloRsrvaLstarDpstoDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0;
            try
            {
                validacion = await validacionVisitaMotonave.ValidarExistenciaVisitaMotonave(idVisitaMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    lista = await this._dbContex.ConsultarDeposito(idVisitaMotonave);
                    if (lista != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = lista;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = lista;
                return BadRequest(respuesta);
            }
            return lista;
        }
        #endregion


        #region consultar todas las solicitudes de retiro que pertenecen a un deposito particula y una transportadora particular.
        [HttpGet("listar-solicitud-retiro-reserva")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>>> ConsultarSolicitudRetiroModal(int idDeposito, int idTransportadora)
        {
            var lista = new List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0;
            try
            {
                validacion = await validacionDeposito.ValidarExistenciaDeposito(idDeposito);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    validacion = 0;
                    validacion = await validacionTercero.ValidarExistenciaTercero(idTransportadora);
                    if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                    {
                        lista = await this._dbContex.ConsultarSolicitudRetiroModal(idDeposito, idTransportadora);
                        if (lista != null)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = lista;
                        }
                        else
                        {
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = lista;
                        }
                    }
                    else 
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = lista;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = lista;
                return BadRequest(respuesta);
            }
            return lista;
        }
        #endregion

        #region consultar todas las solicitudes de retiro que pertenecen a un deposito particula y una transportadora particular.
        [HttpGet("listar-detalle-solicitud-retiro-reserva")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.SpMdloRsrvaDtlleSlctudRtroDTO>>> ListarDetalleSolicitudRetiro(int IdSolicitudRetiro, int idTransportadora)
        {
            var lista = new List<MdloDtos.DTO.SpMdloRsrvaDtlleSlctudRtroDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0;
            try
            {
                validacion = await validacionReserva.ValidarExistenciaSolicitudRetiro(IdSolicitudRetiro);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    validacion = 0;
                    validacion = await validacionTercero.ValidarExistenciaTercero(idTransportadora);
                    if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                    {
                        lista = await this._dbContex.ListarDetalleSolicitudRetiro(IdSolicitudRetiro, idTransportadora);
                        if (lista != null)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = lista;
                        }
                        else
                        {
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = lista;
                        }
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = lista;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = lista;
                return BadRequest(respuesta);
            }
            return lista;
        }
        #endregion

        #region consultar todas las solicitudes de retiro que pertenecen a un deposito particula y una transportadora particular.
        [HttpGet("listar-detalle-orden-reserva")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.SpMdloRsrvaDtlleOrdenDTO>>> ListarDetalleOrden(int CodigoOrden)
        {
            var lista = new List<MdloDtos.DTO.SpMdloRsrvaDtlleOrdenDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0;
            try
            {
                validacion = await validacionReserva.ValidarExistenciaOrden(CodigoOrden);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    lista = await this._dbContex.ListarDetalleOrden(CodigoOrden);
                    if (lista != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = lista;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = lista;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = lista;
                return BadRequest(respuesta);
            }
            return lista;
        }
        #endregion
        #region Ingresa una reserva
        [HttpPost("ingresar-reserva")]
        public async Task<ActionResult<dynamic>> RegistrarOrden([FromBody] MdloDtos.DTO.OrdenDTO _Orden)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0;
            try
            {
                String respuestaValidacionManifiesto = await validacionReserva.ValidarManifiesto(_Orden);
                if (respuestaValidacionManifiesto.Equals("OK"))
                {
                    validacion = await validacionTercero.ValidarExistenciaTercero(_Orden.IdTransportadora);

                    if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                    {
                        DateTime hoy = DateTime.Now;
                        _Orden.FechaReserva = hoy;
                        _Orden.FechaRegistroReserva = hoy;
                        _Orden.Observaciones = null;
                        string response = await this._dbContex.RegistrarOrden(_Orden);
                        if (response.Equals("OK"))
                        {
                            int codigoOrden = await _dbContex.ConsultarOrdenEspecifica(_Orden.IdTransportadora, (DateTime)_Orden.FechaReserva, (DateTime)_Orden.FechaRegistroReserva, _Orden.Placa, _Orden.Manifiesto);
                            if (codigoOrden != -1)
                            {
                                List<MdloDtos.DTO.SpMdloRsrvaDtlleOrdenDTO> detalleOrden = await _dbContex.ListarDetalleOrden(codigoOrden);
                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                respuesta.datos = detalleOrden;
                            }
                            else
                            {
                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                respuesta.datos = null;
                            }
                        }
                        else
                        {
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = response;// MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = null;
                        }
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else 
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = respuestaValidacionManifiesto;
                    respuesta.datos = null;
                }  
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = null;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Ingresar una observación a una orden en particular
        [HttpPost("ingresar-observacion-orden")]
        public async Task<ActionResult<dynamic>> IngresarObservacion([FromBody] MdloDtos.Mensaje ObjMensaje)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0;
            try
            {
                validacion = await validacionReserva.ValidarIngresoObservacion(ObjMensaje.Codigo, ObjMensaje.codigoUsuario, ObjMensaje.comentario);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListaObservacion = await this._dbContex.IngresarObservacion((int)ObjMensaje.Codigo, ObjMensaje.codigoUsuario, ObjMensaje.comentario);
                    if (ObListaObservacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListaObservacion;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = null;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = null;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Consultar las observaciones ingresadas a una orden en particular
        [HttpGet("consultar-observaciones-orden")]
        public async Task<ActionResult<dynamic>> ConsultarObservaciones(int CodigoOrden)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0;
            try
            {

                validacion = await validacionReserva.ValidarExistenciaOrden(CodigoOrden);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ListaObservaciones = await this._dbContex.ConsultarObservaciones(CodigoOrden);
                    if (ListaObservaciones != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ListaObservaciones;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = null;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = null;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion
    }
}
