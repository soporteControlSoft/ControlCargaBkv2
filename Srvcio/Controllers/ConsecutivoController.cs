using AutoMapper;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using VldcionDtos;

namespace Srvcio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsecutivoController : Controller
    {

        private readonly MdloDtos.IModelos.IConsecutivo _dbContex;
        private readonly IMapper _Mapper;


        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public ConsecutivoController(MdloDtos.IModelos.IConsecutivo dbContex)
        {
            _dbContex = dbContex;

        }

        //validacion de datos.
        VldcionDtos.ValidacionCiudad validacionCiudad = new VldcionDtos.ValidacionCiudad();




        #region Lista de consectivos ( todos)
        [HttpGet("listar-consecutivos")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> ConsultarConsecutivo()
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.ConsecutivoDTO>();

                result = await this._dbContex.ConsultarConsecutivo();

                if (result.Count > 0)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(respuesta);
            }
        }
        #endregion


        #region Lista de consectivos ( todos)
        [HttpGet("buscar-consecutivos-compania")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> FiltrarConsecutivoPorCompania(string CodigoCompania)
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.ConsecutivoDTO>();

                result = await this._dbContex.FiltrarConsecutivoPorCompania(CodigoCompania);

                if (result.Count > 0)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(respuesta);
            }
        }
        #endregion


        #region Lista de consectivos ( todos)
        [HttpGet("buscar-consecutivos-id")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> FiltrarConsecutivoId(int Id)
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.ConsecutivoDTO>();

                result = await this._dbContex.FiltrarConsecutivoId(Id);

                if (result.Count > 0)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(respuesta);
            }
        }
        #endregion


        #region Ingresa consectivo

        [HttpPost("ingresar-consecutivo")]
        public async Task<ActionResult<dynamic>> IngresarConsecutivo([FromBody] ConsecutivoDTO ObjConsecutivo)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = 5;
                if (validacion == 5) //si fue exito)
                {
                    var ObConsecutivo = await this._dbContex.IngresarConsecutivo(ObjConsecutivo);
                    if (ObConsecutivo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "exito en la transaccíon";
                        respuesta.datos = ObConsecutivo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjConsecutivo;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjConsecutivo;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjConsecutivo;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion


        [HttpPut("actualizar-consecutivo")]
        public async Task<ActionResult<dynamic>> EditarConsecutivo([FromBody] ConsecutivoDTO ObjConsecutivo)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = 5;
                if (validacion == 5) //si fue exito)
                {
                    var ObConsecutivo = await this._dbContex.EditarConsecutivo(ObjConsecutivo);
                    if (ObConsecutivo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "exito en la transaccíon";
                        respuesta.datos = ObConsecutivo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjConsecutivo;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjConsecutivo;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjConsecutivo;
                return BadRequest(respuesta);
            }

            return respuesta;
        }


        [HttpDelete("eliminar-consecutivo")]
        public async Task<ActionResult<dynamic>> EliminarConsecutivo([FromBody] MdloDtos.DTO.ConsecutivoDTO ObjConsecutivo)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = 5;
                if (validacion == 5) //si fue exito)
                {
                    var ObConsecutivo = await this._dbContex.EliminarConsecutivo(ObjConsecutivo.Id);
                    if (ObConsecutivo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "exito en la transaccíon";
                        respuesta.datos = ObConsecutivo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjConsecutivo;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjConsecutivo;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjConsecutivo;
                return BadRequest(respuesta);
            }

            return respuesta;
        }




    }
}
