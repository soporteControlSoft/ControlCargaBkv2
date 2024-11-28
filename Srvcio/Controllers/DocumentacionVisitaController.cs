using MdloDtos;
using Microsoft.AspNetCore.Mvc;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// fecha:03/04/2024
    /// Consulta de documentos segun visita encabezado
    /// </summary>
    [ApiController]
    public class DocumentacionVisita : Controller
    {

        private readonly MdloDtos.IModelos.IDocumentacionVisita _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public DocumentacionVisita(MdloDtos.IModelos.IDocumentacionVisita dbContext)
        {
            _dbContext = dbContext;
        }

        VldcionDtos.ValidacionDocumentacionVisita ObjValidacionDocumentacionVisita = new VldcionDtos.ValidacionDocumentacionVisita();

        #region Consulta Motonave asociada a la visita motonave encabezado. 
        [HttpGet("consulta-visita-motonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDocumento>>> ListaVisitaMotonave(string CodigoUsuario, string CodigoCompania)
        {
            List<MdloDtos.VisitaMotonaveDocumento> ObjVisitaMotonaveDocumento = new List<MdloDtos.VisitaMotonaveDocumento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDocumentacionVisita.ValidarFiltroBusquedas( CodigoUsuario, CodigoCompania);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjVisitaMotonaveDocumento = await this._dbContext.ListaVisitaMotonave(CodigoUsuario, CodigoCompania);
                    if (ObjVisitaMotonaveDocumento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonaveDocumento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        var respuestaEnvio = new
                        {
                            CodigoUsuario = CodigoUsuario,
                            CodigoCompania = CodigoCompania
                        };
                        respuesta.datos = respuestaEnvio;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    var respuestaEnvio = new
                    {
                        CodigoUsuario = CodigoUsuario,
                        CodigoCompania = CodigoCompania
                    };
                    respuesta.datos = respuestaEnvio;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                var respuestaEnvio = new
                {
                    CodigoUsuario = CodigoUsuario,
                    CodigoCompania = CodigoCompania
                };
                respuesta.datos = respuestaEnvio;
                return BadRequest(respuesta);
            }
            return ObjVisitaMotonaveDocumento;

        }
        #endregion

        #region Consulta Motonave asociada a la visita motonave encabezado. 
        [HttpGet("consulta-visita-motonave-aprobacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDocumento>>> ListaVisitaMotonaveAprobacion(string CodigoCompania)
        {
            List<MdloDtos.VisitaMotonaveDocumento> ObjVisitaMotonaveDocumento = new List<MdloDtos.VisitaMotonaveDocumento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDocumentacionVisita.ValidarFiltroBusquedasPorCompania(CodigoCompania);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjVisitaMotonaveDocumento = await this._dbContext.ListaVisitaMotonavePorCompania(CodigoCompania);
                    if (ObjVisitaMotonaveDocumento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonaveDocumento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        var respuestaEnvio = new
                        {
                            CodigoCompania = CodigoCompania
                        };
                        respuesta.datos = respuestaEnvio;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    var respuestaEnvio = new
                    {
                        CodigoCompania = CodigoCompania
                    };
                    respuesta.datos = respuestaEnvio;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                var respuestaEnvio = new
                {
                    CodigoCompania = CodigoCompania
                };
                respuesta.datos = respuestaEnvio;
                return BadRequest(respuesta);
            }
            return ObjVisitaMotonaveDocumento;

        }
        #endregion

        # region Consultar todos los tipos de documentos donde sea activo=true y que el tipo de origen sea igual a N(Naviera)
        [HttpGet("consultar-tipo-documentos")]
        public async Task<ActionResult<IEnumerable<MdloDtos.TipoDocumento>>> ConsultarTipoDocumentos(int VisitaMotonave)
        {
            List<MdloDtos.TipoDocumento> listaTipoDocumentos = new List<MdloDtos.TipoDocumento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDocumentacionVisita.ValidarIdVisita(VisitaMotonave);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    listaTipoDocumentos = await this._dbContext.ConsultarTipoDocumentos(VisitaMotonave);
                    if (listaTipoDocumentos != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaTipoDocumentos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos= listaTipoDocumentos;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaTipoDocumentos;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaTipoDocumentos;
            }
            return listaTipoDocumentos;

        }
        #endregion

        #region Ingresar visita Motonave Documento.
        [HttpPost("ingresar-visitaMotonave-documento")]
        public async Task<ActionResult<dynamic>> IngresarVisitaMotonaveDocumento([FromBody] MdloDtos.VisitaMotonaveDocumento objVisitaMotonaveDocumento)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionDocumentacionVisita.ValidarIngreso(objVisitaMotonaveDocumento);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var Obvisita = await this._dbContext.IngresarVisitaMotonaveDocumento(objVisitaMotonaveDocumento);
                    if (Obvisita != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = Obvisita;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonaveDocumento;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonaveDocumento;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonaveDocumento;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Ingresar visita Motonave Documento.
        [HttpGet("validar-cargue-archivo-visita-motonave-documento")]
        public async Task<ActionResult<dynamic>> validarPosibilidadSubirArchivo(int IdiVisitaMotonave, String CodigoTipoDocumento)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                if (IdiVisitaMotonave != null && !string.IsNullOrEmpty(CodigoTipoDocumento))
                {
                    MdloDtos.VisitaMotonaveDocumento objVisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveDocumento();
                    objVisitaMotonaveDocumento.VmdoRowidVstaMtnve = IdiVisitaMotonave;
                    objVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto = CodigoTipoDocumento;
                    validacion = await ObjValidacionDocumentacionVisita.ValidarIngresoPorArchivoEspecifico(objVisitaMotonaveDocumento);
                    if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = true;
                    }
                    else
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = false;
                    }
                }
                else 
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = false;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = false;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        # region Consultar documentos asociados a la visita 
        [HttpGet("consultar-documentos-visita")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDocumento>>> ConsultarTipoDocumentosIdVisita(int idVisitaMotonave)
        {
            List<MdloDtos.VisitaMotonaveDocumento> ObjTipoDocumento = new List<MdloDtos.VisitaMotonaveDocumento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDocumentacionVisita.ValidarIdVisita(idVisitaMotonave);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjTipoDocumento = await this._dbContext.ConsultarTipoDocumentosIdVisita(idVisitaMotonave);
                    if (ObjTipoDocumento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjTipoDocumento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjTipoDocumento;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjTipoDocumento;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjTipoDocumento;
            }
            return ObjTipoDocumento;

        }
        #endregion

        #region Actualizar Estado
        [HttpPut("actualizar-estado-documento")]
        public async Task<ActionResult<dynamic>> EditarEstadoDocumentos([FromBody] MdloDtos.VisitaMotonaveDocumento _objVisitaMotonaveDocumento)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionDocumentacionVisita.ValidarActualizarEstadoDocumento(_objVisitaMotonaveDocumento);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObjVehiculo = await this._dbContext.EditarEstadoDocumentos(_objVisitaMotonaveDocumento);
                    if (ObjVehiculo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVehiculo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _objVisitaMotonaveDocumento;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objVisitaMotonaveDocumento;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _objVisitaMotonaveDocumento;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Ingresar visita Motonave Documento.
        [HttpPost("ingresar-comentario-visitaMotonave-documento")]
        public async Task<ActionResult<dynamic>> IngresarComentarioVisitaMotonaveDocumento([FromBody] MdloDtos.Comentario ObjComentario)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionDocumentacionVisita.ValidarIngresoComentario(ObjComentario.CodigoVisitaMotonaveDocumento, ObjComentario.codigoUsuario, ObjComentario.comentario);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListaComentario = await this._dbContext.IngresarComentario((int)ObjComentario.CodigoVisitaMotonaveDocumento, ObjComentario.codigoUsuario, ObjComentario.comentario);
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

        #region Consultar comentario en visita Motonave Documento.
        [HttpGet("consultar-comentario-visitaMotonave-documento")]
        public async Task<ActionResult<dynamic>> ConsultarComentariosVisitaMotonaveDocumento(int CodigoVisitaMotonaveDocumento)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await ObjValidacionDocumentacionVisita.ValidarConsultarComentario(CodigoVisitaMotonaveDocumento);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListaComentario = await this._dbContext.ConsultarComentario(CodigoVisitaMotonaveDocumento);
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

        #region Ingresar documentos asociados a la visita BL
        [HttpPost("ingresar-vista-motonave-BL-levante")]
        public async Task<dynamic> IngresarVisitaMotonaveBl1([FromBody] MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveDocumento_)
        {
            MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonave = new MdloDtos.VisitaMotonaveDocumento();
            AccsoDtos.VisitaMotonave.VisitaMotonaveBl1 VisitaMotonaveBl1_ = new AccsoDtos.VisitaMotonave.VisitaMotonaveBl1();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((!string.IsNullOrEmpty(ObjVisitaMotonaveDocumento_.lvnte))) //si fue exito)
                {
                    ObjVisitaMotonave = await VisitaMotonaveBl1_.IngresarVisitaMotonaveBl1(ObjVisitaMotonaveDocumento_);
                    if (ObjVisitaMotonave != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                        respuesta.datos = ObjVisitaMotonave;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonave;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVisitaMotonave;
            }
            return respuesta;

        }
        #endregion

        #region actualizar documentos asociados a la visita BL Orden
        [HttpPost("actualizar-vista-motonave-BL")]
        public async Task<dynamic> ActualizarVisitaMotonaveBl1([FromBody] MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveDocumento_)
        {
            MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonave = new MdloDtos.VisitaMotonaveDocumento();
            AccsoDtos.VisitaMotonave.VisitaMotonaveBl1 VisitaMotonaveBl1_ = new AccsoDtos.VisitaMotonave.VisitaMotonaveBl1();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((!string.IsNullOrEmpty(ObjVisitaMotonaveDocumento_.VmdoLnea.ToString()))) //si fue exito)
                {
                    ObjVisitaMotonave = await VisitaMotonaveBl1_.ActualizarVisitaMotonaveBl1(ObjVisitaMotonaveDocumento_);
                    if (ObjVisitaMotonave != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                        respuesta.datos = ObjVisitaMotonave;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonave;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVisitaMotonave;
            }
            return respuesta;

        }
        #endregion

        #region Actualizar Estado
        [HttpPut("actualizar-tarifas-visita-motonave-documento")]
        public async Task<ActionResult<dynamic>> ActualizarTarifas([FromBody] List <MdloDtos.VisitaMotonaveDocumento> listado)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; 
            try
            {
                validacion = await ObjValidacionDocumentacionVisita.ValidarActualizarTarifa(listado);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var objListado = await this._dbContext.ActualizarTarifas(listado);
                    if (objListado != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objListado;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listado;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listado;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listado;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion
    }
}
