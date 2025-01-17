using AutoMapper;
using MdloDtos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class ConceptosPesajesController : Controller
    {

        private readonly MdloDtos.IModelos.IConceptosPesajes _dbContex;
        private readonly IMapper _Mapper;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public ConceptosPesajesController(MdloDtos.IModelos.IConceptosPesajes dbContex)
        {
            _dbContex = dbContex;
        }



        //validacion de datos.
        VldcionDtos.ValidacionCiudad validacionCiudad = new VldcionDtos.ValidacionCiudad();

        #region Lista de conceptos de pesaje ( todos)
        [HttpGet("listar-conceptosPesaje")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> ConsultarConceptosPesajes()
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.ConceptoPesajeDTO>();

                result = await this._dbContex.ConsultarConceptosPesajes();

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

        #region Lista de conceptos de pesaje ( por compañia)
        [HttpGet("buscar-conceptosPesaje-compania")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> FiltrarConceptosPesajesPorCompania(string CodigoCompania)
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.ConceptoPesajeDTO>();

                result = await this._dbContex.FiltrarConceptosPesajesPorCompania(CodigoCompania);

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

        #region Lista de conceptos de pesaje  ( por codigo)
        [HttpGet("buscar-conceptosPesaje-codigo")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> FiltrarConceptosPesajesCodigo(string Codigo)
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.ConceptoPesajeDTO>();

                result = await this._dbContex.FiltrarConceptosPesajesCodigo(Codigo);

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

        #region Ingresa conceptos de pesaje

        [HttpPost("ingresar-conceptosPesaje")]
        public async Task<ActionResult<dynamic>> IngresarConceptosPesajes([FromBody] ConceptoPesajeDTO ObjConceptoPesaje)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = 5;
                if (validacion == 5) //si fue exito)
                {
                    var ObConsecutivo = await this._dbContex.IngresarConceptosPesajes(ObjConceptoPesaje);
                    if (ObConsecutivo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "exito en la transaccíon";
                        respuesta.datos = ObjConceptoPesaje;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjConceptoPesaje;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjConceptoPesaje;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjConceptoPesaje;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion


        [HttpPut("actualizar-conceptosPesaje")]
        public async Task<ActionResult<dynamic>> EditarConceptosPesajes([FromBody] ConceptoPesajeDTO ObjConceptosPesajes)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = 5;
                if (validacion == 5) //si fue exito)
                {
                    var ObConsecutivo = await this._dbContex.EditarConceptosPesajes(ObjConceptosPesajes);
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
                        respuesta.datos = ObjConceptosPesajes;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjConceptosPesajes;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjConceptosPesajes;
                return BadRequest(respuesta);
            }

            return respuesta;
        }


        [HttpDelete("eliminar-conceptosPesaje")]
        public async Task<ActionResult<dynamic>> EliminarConceptosPesajes([FromBody] MdloDtos.DTO.ConceptoPesajeDTO ObjConceptosPesajes)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = 5;
                if (validacion == 5) //si fue exito)
                {
                    var ObConsecutivo = await this._dbContex.EliminarConceptosPesajes(ObjConceptosPesajes.CodigoCompania, ObjConceptosPesajes.CodigoConceptoPesaje);
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
                        respuesta.datos = ObjConceptosPesajes;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjConceptosPesajes;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjConceptosPesajes;
                return BadRequest(respuesta);
            }

            return respuesta;
        }

    }
}
