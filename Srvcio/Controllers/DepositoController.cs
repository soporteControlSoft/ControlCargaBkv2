using AccsoDtos.Parametrizacion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using VldcionDtos;

namespace Srvcio.Controllers
{
    public class DepositoController : Controller
    {
        private readonly MdloDtos.IModelos.IDeposito _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public DepositoController(MdloDtos.IModelos.IDeposito dbContex)
        {
            _dbContex = dbContex;
        }
        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        
        VldcionDtos.ValidacionVisitaMotonave ObjValidacionVisitaMotonave = new VldcionDtos.ValidacionVisitaMotonave();
        VldcionDtos.ValidacionVisitaMotonaveBl ObjvalidacionVisitaMotonaveBl = new VldcionDtos.ValidacionVisitaMotonaveBl();
        VldcionDtos.ValidacionDeposito ObjValidacionDeposito = new VldcionDtos.ValidacionDeposito();

        #region Consultar todos los productos asociados a una visitaMotonave por RowId
        [HttpGet("listar-productos-visitaMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwMdloDpstoLstarPrdctoPorVstaMtnve>>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave)
        {
            List<MdloDtos.VwMdloDpstoLstarPrdctoPorVstaMtnve> listaDatos = null;

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                if ((!string.IsNullOrEmpty(IdVisitaMotonave.ToString())) && (IdVisitaMotonave > 0))
                {
                    listaDatos = await this._dbContex.ConsultarProductosPorVisitaMotonave(IdVisitaMotonave);
                    if (listaDatos != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }
            return listaDatos;
        }
        #endregion

        #region Consultar  VisitaMotonaveBl pasando como parámetro un IdVisitaMotonaveDetalle, codigoUsuario
        [HttpGet("filtrar-visitaMotonaveBl-crearDeposito")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlCrearDeposito(int IdVisitaMotonave, string codigoUsuario, string codigoProducto)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjvalidacionVisitaMotonaveBl.ValidarFiltroBusquedasPorIdVisitaMotonave(IdVisitaMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContex.FiltrarVisitaMotonaveBlCrearDeposito(IdVisitaMotonave, codigoUsuario,codigoProducto);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        listaDatos = ObjVisitaMotonaveBl;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }
            return listaDatos;
        }
        #endregion

        #region Ingresa un deposito

        [HttpPost("ingresar-deposito")]
        public async Task<ActionResult<dynamic>> Ingresar([FromBody] MdloDtos.Deposito _objDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionDeposito.ValidarIngreso(_objDeposito);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var objDeposito = await this._dbContex.IngresarDeposito(_objDeposito);
                    if (objDeposito != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objDeposito;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objDeposito;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objDeposito;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _objDeposito;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion


        #region Consultar todos los clientes asociados a una visitaMotonave por RowId
        [HttpGet("listar-clientes-visitaMotonave-aprobacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwMdloDpstoAprbcionLstarClntesPorVstaMtnve>>> ConsultarClientesPorVisitaMotonave(int IdVisitaMotonave)
        {
            List<MdloDtos.VwMdloDpstoAprbcionLstarClntesPorVstaMtnve> listaDatos = null;

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                if ((!string.IsNullOrEmpty(IdVisitaMotonave.ToString())) && (IdVisitaMotonave > 0))
                {
                    listaDatos = await this._dbContex.ConsultarClientesPorVisitaMotonave(IdVisitaMotonave);
                    if (listaDatos != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }
            return listaDatos;
        }
        #endregion

        #region Ingresar un comentario a un deposito en particular
        [HttpPost("ingresar-comentario-deposito-aprobacion")]
        public async Task<ActionResult<dynamic>> IngresarComentario([FromBody] MdloDtos.Mensaje ObjMensaje)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionDeposito.ValidarIngresoComentario(ObjMensaje.Codigo, ObjMensaje.codigoUsuario, ObjMensaje.comentario);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListaComentario = await this._dbContex.IngresarComentario((int)ObjMensaje.Codigo, ObjMensaje.codigoUsuario, ObjMensaje.comentario);
                    if (ObListaComentario != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListaComentario;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    //regresa el error
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

        #region Consultar los comentarios de un deposito en particular
        [HttpGet("consultar-comentario-deposito")]
        public async Task<ActionResult<dynamic>> ConsultarComentariosVisitaMotonaveDocumento(int CodigoDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDeposito.ValidarConsultarComentario(CodigoDeposito);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListaComentario = await this._dbContex.ConsultarComentario(CodigoDeposito);
                    if (ObListaComentario != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListaComentario;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    //regresa el error
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


        #region Consultar todos los depositos pendiente por aprobación asociados a una visitaMotonave
        [HttpGet("listar-depositos-aprobacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Deposito>>> FiltrarDepositosPendienteAprobacion(int IdVisitaMotonave, int? idCliente)
        {
            List<MdloDtos.Deposito> listaDatos = null;

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                if ((!string.IsNullOrEmpty(IdVisitaMotonave.ToString())) && (IdVisitaMotonave > 0))
                {
                    listaDatos = await this._dbContex.FiltrarDepositosPendienteAprobacion(IdVisitaMotonave, idCliente);
                    if (listaDatos != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }
            return listaDatos;
        }
        #endregion


        #region Consulta todo el detalle de un deposito particular por medio de su RowId
        [HttpGet("listar-detalle-depositos-aprobacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpDtlleDpstoAprbcion>>> ListarDetalleDepositoAprobacion(int IdDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            int existeDepsto;
            List<MdloDtos.SpDtlleDpstoAprbcion> listado = null;
            try
            {
                if (IdDeposito > 0)
                {
                    MdloDtos.Deposito deposito = new MdloDtos.Deposito { DeRowid = IdDeposito };
                    //validacion = await ObjValidacionDeposito.ValidarIngreso(_objDeposito);
                    existeDepsto = await ObjValidacionDeposito.VerificarExistenciaDeposito(deposito);
                    if (existeDepsto == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                    {
                        listado = await this._dbContex.ListarDetalleDepositoAprobacion(IdDeposito);
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        if (listado != null)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = listado;
                        }
                        else
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = null;
                        }
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(operacion);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listado;
                return BadRequest(respuesta);
            }
            return listado;
        }
        #endregion


        #region Aprueba un deposito en particular en estado de Creacion B
        [HttpPut("aprobar-deposito")]
        public async Task<ActionResult<dynamic>> AprobacionDeposito([FromBody] MdloDtos.SpDpstoAprbcion spDpstoAprbcion)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                MdloDtos.Deposito dpsto = new MdloDtos.Deposito { DeRowid = spDpstoAprbcion.rowIdDpsto };

                validacion = await ObjValidacionDeposito.ValidarEstadoDeposito(dpsto);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    bool retorno = await this._dbContex.AprobacionDeposito(spDpstoAprbcion);
                    if (retorno)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = spDpstoAprbcion;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = spDpstoAprbcion;
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


        #region Rechaza un deposito en particular en estado de Creacion B
        [HttpPut("rechazar-deposito")]
        public async Task<ActionResult<dynamic>> RechazarDeposito([FromBody] MdloDtos.SpDpstoRchzo spDpstoRchzo)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                MdloDtos.Deposito dpsto = new MdloDtos.Deposito { DeRowid = spDpstoRchzo.rowIdDpsto };

                validacion = await ObjValidacionDeposito.ValidarEstadoDeposito(dpsto);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    bool retorno = await this._dbContex.RechazarDeposito(spDpstoRchzo);
                    if (retorno)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = spDpstoRchzo;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = spDpstoRchzo;
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


        #region genera una lista de numeros para la cantidades de impresiones de tiquetes
        [HttpGet("listar-cantidad-tiquete-impresion")]
        public async Task<ActionResult<dynamic>> CantidadCopiasImpresion()
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            List<int> listadoCantidadTiquete = await this._dbContex.CantidadCopiasImpresion();
            try
            {
                if (listadoCantidadTiquete != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listadoCantidadTiquete;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
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

        #region Consultar visita motonave aduanas, Por usuario y empresa.
        [HttpGet("consulta-productos-deposito-creacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> ConsultarProductosPorVisitaMotonave(int IdVisitaMotonave, int? idCliente)
        {
            if (IdVisitaMotonave <= 0 || idCliente <= 0)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaProductos = await this._dbContex.ConsultarProductosPorVisitaMotonave(IdVisitaMotonave, idCliente);
                if (listaProductos != null && listaProductos.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaProductos;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.Producto>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

        #region Ingresa un deposito colaborador interno
        [HttpPost("ingresar-deposito-colaborador-interno")]
        public async Task<ActionResult<dynamic>> IngresarDepositoColaboradorInterno([FromBody] MdloDtos.Deposito _objDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = (_objDeposito.DeCmun == true) ? await ObjValidacionDeposito.ValidarIngresoDpstoCmun(_objDeposito) 
                                                            : await ObjValidacionDeposito.ValidarIngreso(_objDeposito);
                
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var objDetalleDeposito = await this._dbContex.IngresarDepositoColaboradorInterno(_objDeposito);
                    if (objDetalleDeposito != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objDetalleDeposito;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objDetalleDeposito;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objDeposito;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _objDeposito;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Ingresar un comentario a un deposito en particular
        [HttpPost("ingresar-observacion-deposito")]
        public async Task<ActionResult<dynamic>> IngresarObservaciones([FromBody] MdloDtos.Mensaje ObjMensaje)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionDeposito.ValidarIngresoObservacion(ObjMensaje.Codigo, ObjMensaje.codigoUsuario, ObjMensaje.comentario);
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
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    //regresa el error
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

        #region Consultar los comentarios de un deposito en particular
        [HttpGet("consultar-observaciones-deposito")]
        public async Task<ActionResult<dynamic>> ConsultarObservaciones(int CodigoDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDeposito.ValidarExistenciaDeposito(CodigoDeposito);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListaObservaciones = await this._dbContex.ConsultarObservaciones(CodigoDeposito);
                    if (ObListaObservaciones != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListaObservaciones;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    //regresa el error
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

        #region Consultar una lista de depositos
        [HttpGet("listar-deposito-administracion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpDeposito>>> ListarDepositosAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia)
        {
            if (rowIdVisitaMotonave <= 0)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaDeposito = await this._dbContex.ListarDepositosAdministracion(rowIdVisitaMotonave, rowIdTercero, cdgoProducto, cdgoCmpnia);
                if (listaDeposito != null && listaDeposito.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaDeposito;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.Deposito>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

        #region Consultar una lista de depositos
        [HttpGet("listar-deposito-detalle-modal-administracion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpDepositoDetalle>>> ListarDepositosDetalleAdministracion(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia, bool estadoDeposito)
        {
            if (rowIdVisitaMotonave <= 0)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaDeposito = await this._dbContex.ListarDepositosDetalleAdministracion(rowIdVisitaMotonave, rowIdTercero, cdgoProducto, cdgoCmpnia, estadoDeposito);
                if (listaDeposito != null && listaDeposito.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaDeposito;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.Deposito>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion


        #region Consultar una lista de depositos
        [HttpGet("listar-subdeposito-administracion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpSubDeposito>>> ListarSubDepositosAdministracion( string cdgoDpstoPdre)
        {
            if (String.IsNullOrEmpty(cdgoDpstoPdre))
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }
            try
            {
                var listaDeposito = await this._dbContex.ListarSubDepositosAdministracion(cdgoDpstoPdre);
                if (listaDeposito != null && listaDeposito.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaDeposito;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.SpSubDeposito>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion


        #region Consulta todo el detalle de un deposito particular por medio de su RowId
        [HttpGet("listar-detalle-depositos-administracion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Deposito>>> ListarDetalleDepositoAdministracion(int IdDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            int existeDepsto;
            List<MdloDtos.SpDtlleDpstoAprbcion> listado = null;
            try
            {
                if (IdDeposito > 0)
                {
                     MdloDtos.Deposito deposito = new MdloDtos.Deposito { DeRowid = IdDeposito };
                    //validacion = await ObjValidacionDeposito.ValidarIngreso(_objDeposito);
                    existeDepsto = await ObjValidacionDeposito.VerificarExistenciaDeposito(deposito);
                    if (existeDepsto == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                    {
                        MdloDtos.Deposito depositoTemp = await this._dbContex.ListarDetalleDepositoAdministracion(IdDeposito);
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        if (depositoTemp != null)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = depositoTemp;
                        }
                        else
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = null;
                        }
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(operacion);
                        respuesta.datos = null;
                    }
                }
                else {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = null;
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listado;
                return BadRequest(respuesta);
            }
     
        }
        #endregion

        #region Actualizar Deposito
        [HttpPut("actualizar-deposito-administracion")]
        public async Task<ActionResult<dynamic>> ActualizarDeposito([FromBody] MdloDtos.Deposito deposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; 
            try
            {
                validacion = await ObjValidacionDeposito.ValidarExistenciaDeposito((int)deposito.DeRowid);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObDeposito = await this._dbContex.ActualizarDeposito(deposito);
                    if (ObDeposito != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObDeposito;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = deposito;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = deposito;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = deposito;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Consulta todo el detalle de un deposito particular por medio de su RowId para condiciones de facturacion
        [HttpGet("listar-detalle-depositos-facturacion-administracion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Deposito>>> ListarDetalleDepositoFacturacion(int IdDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            int existeDepsto;
            List<MdloDtos.SpDtlleDpstoAprbcion> listado = null;
            try
            {
                if (IdDeposito > 0)
                {
                    MdloDtos.Deposito deposito = new MdloDtos.Deposito { DeRowid = IdDeposito };
                    existeDepsto = await ObjValidacionDeposito.VerificarExistenciaDeposito(deposito);
                    if (existeDepsto == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                    {
                        MdloDtos.Deposito depositoTemp = await this._dbContex.ListarDetalleDepositoFacturacion(IdDeposito);
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        if (depositoTemp != null)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = depositoTemp;
                        }
                        else
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = null;
                        }
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(operacion);
                        respuesta.datos = null;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = null;
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listado;
                return BadRequest(respuesta);
            }

        }
        #endregion

        #region Actualizar condiciones facturacion deposito 
        [HttpPut("actualizar-deposito-facturacion-administracion")]
        public async Task<ActionResult<dynamic>> ActualizarCondicionesFacturacion([FromBody] MdloDtos.Deposito deposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0;
            try
            {
                validacion = await ObjValidacionDeposito.ValidarExistenciaDeposito((int)deposito.DeRowid);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObDeposito = await this._dbContex.ActualizarCondicionesFacturacion(deposito);
                    if (ObDeposito != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObDeposito;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = deposito;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = deposito;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = deposito;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Actualizar condiciones facturacion deposito 
        [HttpPut("procesar-valores-cif-deposito-administracion")]
        public async Task<ActionResult<dynamic>> ProcesarValoresCif(int IdDeposito)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0;
            try
            {
                validacion = await ObjValidacionDeposito.ValidarExistenciaDeposito(IdDeposito);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObDeposito = await this._dbContex.ProcesarValoresCif(IdDeposito);
                    if (ObDeposito != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObDeposito;
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
