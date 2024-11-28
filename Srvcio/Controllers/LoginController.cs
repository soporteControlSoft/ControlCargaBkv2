using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Api para acceso al sistema de informacion , Creacion del Token.
    /// Daniel Alejandro Lopez.
    /// </summary>
 
    public class LoginController : Controller
    {
        private readonly MdloDtos.IModelos.ILoginSistema _dbContex;
        public IConfiguration _config;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public LoginController(MdloDtos.IModelos.ILoginSistema dbContex,IConfiguration config)
        {
            _dbContex = dbContex;
            _config = config;
        }


        #region Actualizacion Clave de usuarios
        [HttpPost("actualizar-clave")]
        public async Task<dynamic> ActualizarUsuarioClave([FromBody] MdloDtos.AutenticacionUsuario ObjautenticacionUsuario)
        {
            var ObActualizarUsuarioClave = await this._dbContex.ActualizarUsuarioClave(ObjautenticacionUsuario);
            try
            {
                if (ObActualizarUsuarioClave ==1)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje= "Se cambio la clave";
                    respuesta.datos = ObjautenticacionUsuario;
                }
                if (ObActualizarUsuarioClave == 2)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = "Clave ya utilizada , debe cambiarla";
                    respuesta.datos = ObjautenticacionUsuario;
                }
                if (ObActualizarUsuarioClave == 3)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = "Datos Incorrectos de Compañia y Usuario";
                    respuesta.datos = ObjautenticacionUsuario;
                }
                if (ObActualizarUsuarioClave == 4)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = "Datos Incorrectos la clave anterior no es valida";
                    respuesta.datos = ObjautenticacionUsuario;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Error;
                respuesta.datos = ex.ToString() + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta;
                return BadRequest(respuesta);
            }

            return respuesta ;

        }
        #endregion

        #region Inicio de sesion , creacion del Token con clave, (si no necesita codigo temporal , pero se valida si lo necesita y envia correo)
        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion([FromBody] MdloDtos.AutenticacionUsuario ObjautenticacionUsuario) {

            //var data = JsonConvert.DeserializeObject<dynamic>(ObjautenticacionUsuario.ToString());
            string user = ObjautenticacionUsuario.CodigoUsuario.ToString();
            string compania = ObjautenticacionUsuario.CodigoEmpresa.ToString();
            string clave = ObjautenticacionUsuario.Clave.ToString();

            try
            {
                
                bool EnviarCorreoDobleAutenticacion=false;
                //validacion del  codigo enviado al correo
                bool validacionAutentificacion = this._dbContex.NecesitaDobleAututentificacion(user);
                if (validacionAutentificacion == true)
                {

                    // se envia correo con codigo temporal.
                  
                  /*  if (EnviarCorreoDobleAutenticacion == true)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = " Usuario Necesita doble validacion";
                        var respuestaEnvio = new
                        {
                            NecesitaDobleValidacion = "true"
                        };
                        respuesta.datos = respuestaEnvio;
                    }*/

                }
                //no necesita doble validacion

                var CodigoPerfil = "";
                var NombreEmpresa = "";
                var NombreUsuario = "";
                List<string> permisos = new List<string>();
                //Llamamos al metodo de consulta de usuario.
                Task<int> resultado = this._dbContex.ValidacionUsuario(user, compania, clave);
                int respuestServicio = Convert.ToInt32(resultado.Result);
                //Es Correcto el inicio de sesion.?
                if (respuestServicio == 1)
                {
                    // Obtener Perfil del usuario.
                    var ObjPerfil = this._dbContex.ObtenerPerfilPorUsuario(compania, user);
                    foreach (var item in ObjPerfil)
                    {
                        CodigoPerfil = item.PuCdgoPrfil;
                    }
                    //Obtener nombre de la empresa
                    var NombreEmpresa_ = this._dbContex.FiltrarCompaniaEspecifico(compania);
                    foreach (var item in NombreEmpresa_)
                    {
                        NombreEmpresa = item.CiaNmbre;
                    }

                    //Obtener nombre del usuario
                    var NombreUsuario_ = this._dbContex.FiltrarUsuarioEspecifico(user);
                    foreach (var item in NombreUsuario_)
                    {
                        NombreUsuario = item.UsNmbre;
                    }

                    //Obtener el permiso
                    //var ObPermisos = this._dbContex.ObtenerPermisosPousuario(compania, user, CodigoPerfil);
                    var ObRutaAccnes = this._dbContex.ObtenerRutasAccionesPorUsuario(compania, user, CodigoPerfil);

                    var accionesUsuario = ObRutaAccnes.ToList();
                    /*foreach (var i in ObPermisos)
                    {
                        permisos.Add(i);
                    }*/

                    var jwt = _config.GetSection("Jwt").Get<MdloDtos.TokenJwt>();
                    //organizar los permisos.
                    /*StringBuilder sb = new StringBuilder();
                    char delim = ',';
                    for (int i = 0; i < permisos.Count; i++)
                    {
                        sb.Append(permisos[i]);
                        if (i < permisos.Count - 1)
                        {
                            sb.Append(delim);
                        }
                    }*/

                    //string str = sb.ToString();

                    var claims = new[] {

                    new Claim(JwtRegisteredClaimNames.Sub,jwt.Subjet),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim("CodigoUsuario",user),
                    new Claim("CodigoEmpresa",compania),
                    new Claim("CodigoPerfil",CodigoPerfil),
                    new Claim("NombreEmpresa",NombreEmpresa),
                    new Claim("NombreUsuario",NombreUsuario),
                    new Claim("NecesitaDobleValidacion",validacionAutentificacion.ToString()),// si necesita doble autenticacion
                    new Claim("permisos",ObRutaAccnes),
                };
                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var sigIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var Toke = new JwtSecurityToken(

                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: sigIn

                        );
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = " incio de sesion correcto";
                    respuesta.datos = new JwtSecurityTokenHandler().WriteToken(Toke);
                    if(validacionAutentificacion)//Si tiene activo us_2fa envía correo
                    {
                        //enviar correo con codigo temporal
                        EnviarCorreoDobleAutenticacion = this._dbContex.enviarCorreoConCodigo(user);
                    } 
                }
                else
                {
                    if (respuestServicio == 2)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "Error en el inicio de sesion" + "El usuario debe cambiar la clave";
                        var respuestaEnvio = new
                        {
                            DebeCambiarClave = "true"
                        };
                        respuesta.datos = respuestaEnvio;

                    }
                    else
                    {
                        //Usuario Inactivo
                        if (respuestServicio == 4)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "Error en el inicio de sesion" + "El usuario esta inactivo";
                            var respuestaEnvio = new
                            {
                                UsuarioInactivo = "true"
                            };
                            respuesta.datos = respuestaEnvio;
                        }
                        else
                        {
                            //Usuario Bloqueado
                            if (respuestServicio == 5)
                            {
                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "Error en el inicio de sesion" + "El usuario esta bloqueado por el administrador";
                                var respuestaEnvio = new
                                {
                                    UsuarioBloqueadoPorAdmin = "true"
                                };
                                respuesta.datos = respuestaEnvio;
                            }
                            else
                            {

                                //Usuario debe cambiar clave
                                if (respuestServicio == 6)
                                {
                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = "Error en el inicio de sesion" + "El usuario debe cambiar clave";
                                    var respuestaEnvio = new
                                    {
                                        DebeCambiarClave = "true"
                                    };
                                    respuesta.datos = respuestaEnvio;
                                }
                                else
                                {
                                    //Usuario tiene el perfil inactivo
                                    if (respuestServicio == 7)
                                    {
                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = "Error en el inicio de sesion" + "El usuario tiene el perfil inactivo";
                                        var respuestaEnvio = new
                                        {
                                            UsuarioTienePerfilInactivo = "true"
                                        };
                                        respuesta.datos = respuestaEnvio;
                                    }
                                    else
                                    {
                                        //usuario con la compañia inactiva
                                        if (respuestServicio == 8)
                                        {
                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                            respuesta.mensaje = "Error en el inicio de sesion" + "El usuario tiene la compañia inactiva";
                                            var respuestaEnvio = new
                                            {
                                                UsuarioTieneCompaniaInactiva = "true"
                                            };
                                            respuesta.datos = respuestaEnvio;
                                        }
                                        else
                                        {
                                            //error de procesamiento de datos, datos incorrectos
                                            string respuestServicio_ = respuestServicio.ToString().Substring(0, 1);
                                            if (respuestServicio_ == "3")
                                            {
                                                string connteo = respuestServicio.ToString().Substring(1, 1);
                                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                                if (connteo == "5")
                                                {

                                                    respuesta.mensaje = "Supero el numero de intentos de acceso, Usuario Bloqueado";
                                                }
                                                else
                                                {
                                                    respuesta.mensaje = "El usuario tiene los datos incorrectos";

                                                }

                                                // respuesta.datos = "{\"NumeroIntentosIncorrectos\":" + "  " + connteo + "}";
                                                var respuestaEnvio = new
                                                {
                                                    UsuarioTieneCompaniaInactiva = "true",
                                                    NumeroIntentosIncorrectos = connteo
                                                };
                                                respuesta.datos = respuestaEnvio;

                                            }
                                        }
                                    }
                                }
                            }
                            

                    }

                }
            }
            }

            catch(Exception ex){

                respuesta.exito = 10;
                respuesta.mensaje = ex.Message + " " + MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion.ToString();
                respuesta.datos = respuesta.mensaje;
            }
            return respuesta;
        }
        #endregion

        //cambio planteado 23/04/2024 , el codigo temporal va dentro del token.
        /*
        #region Inicio de sesion , creacion del Token , con el codigo temporal que se envio al correo.
        [HttpPost]
        [Route("login-codigoTemporal")]
        public dynamic IniciarSesionCodigoTemporal([FromBody] MdloDtos.AutenticacionUsuario ObjautenticacionUsuario)
        {

            //var data = JsonConvert.DeserializeObject<dynamic>(ObjautenticacionUsuario.ToString());
            string user = ObjautenticacionUsuario.CodigoUsuario.ToString();
            string compania = ObjautenticacionUsuario.CodigoEmpresa.ToString();
            string clave = ObjautenticacionUsuario.Clave.ToString();
            try
            {
                var CodigoPerfil = "";
                var NombreEmpresa = "";
                var NombreUsuario = "";
                List<string> permisos = new List<string>();
                //Llamamos al metodo de consulta de usuario.
                Task<int> resultado = this._dbContex.ValidacionUsuarioCodigoTemporal(user, compania, clave);
                int respuestServicio = Convert.ToInt32(resultado.Result);
                //Es Correcto el inicio de sesion.?
                if (respuestServicio == 1)
                {
                    // Obtener Perfil del usuario.
                    var ObjPerfil = this._dbContex.ObtenerPerfilPorUsuario(compania, user);
                    foreach (var item in ObjPerfil)
                    {
                        CodigoPerfil = item.PuCdgoPrfil;
                    }
                    //Obtener nombre de la empresa
                    var NombreEmpresa_ = this._dbContex.FiltrarCompaniaEspecifico(compania);
                    foreach (var item in NombreEmpresa_)
                    {
                        NombreEmpresa = item.CiaNmbre;
                    }

                    //Obtener nombre del usuario
                    var NombreUsuario_ = this._dbContex.FiltrarUsuarioEspecifico(user);
                    foreach (var item in NombreEmpresa_)
                    {
                        NombreUsuario = item.CiaNmbre;
                    }

                    //Obtener el permiso
                    var ObPermisos = this._dbContex.ObtenerPermisosPousuario(compania, user, CodigoPerfil);

                    foreach (var i in ObPermisos)
                    {
                        permisos.Add(i);
                    }

                    var jwt = _config.GetSection("Jwt").Get<MdloDtos.TokenJwt>();
                    //organizar los permisos.
                    StringBuilder sb = new StringBuilder();
                    char delim = ',';
                    for (int i = 0; i < permisos.Count; i++)
                    {
                        sb.Append(permisos[i]);
                        if (i < permisos.Count - 1)
                        {
                            sb.Append(delim);
                        }
                    }

                    string str = sb.ToString();

                    var claims = new[] {

                    new Claim(JwtRegisteredClaimNames.Sub,jwt.Subjet),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim("CodigoUsuario",user),
                    new Claim("CodigoEmpresa",compania),
                    new Claim("CodigoPerfil",CodigoPerfil),
                    new Claim("NombreEmpresa",NombreEmpresa),
                    new Claim("NombreUsuario",NombreUsuario),
                    new Claim("permisos",str),
                };
                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var sigIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var Toke = new JwtSecurityToken(

                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: sigIn

                     );
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = " incio de sesion correcto";
                    respuesta.datos = new JwtSecurityTokenHandler().WriteToken(Toke);
                }
                else
                {
                    if (respuestServicio == 2)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "Error en el inicio de sesion" + "El usuario debe cambiar la clave";
                        var respuestaEnvio = new
                        {
                            DebeCambiarClave = "true"
                        };
                        respuesta.datos = respuestaEnvio;

                    }
                    else
                    {
                        //Usuario Inactivo
                        if (respuestServicio == 4)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "Error en el inicio de sesion" + "El usuario esta inactivo";
                            var respuestaEnvio = new
                            {
                                UsuarioInactivo = "true"
                            };
                            respuesta.datos = respuestaEnvio;
                        }
                        else
                        {
                            //Usuario Bloqueado
                            if (respuestServicio == 5)
                            {
                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "Error en el inicio de sesion" + "El usuario esta bloqueado por el administrador";
                                var respuestaEnvio = new
                                {
                                    UsuarioBloqueadoPorAdmin = "true"
                                };
                                respuesta.datos = respuestaEnvio;
                            }
                            else
                            {

                                //Usuario debe cambiar clave
                                if (respuestServicio == 6)
                                {
                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = "Error en el inicio de sesion" + "El usuario debe cambiar clave";
                                    var respuestaEnvio = new
                                    {
                                        DebeCambiarClave = "true"
                                    };
                                    respuesta.datos = respuestaEnvio;
                                }
                                else
                                {
                                    //Usuario tiene el perfil inactivo
                                    if (respuestServicio == 7)
                                    {
                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = "Error en el inicio de sesion" + "El usuario tiene el perfil inactivo";
                                        var respuestaEnvio = new
                                        {
                                            UsuarioTienePerfilInactivo = "true"
                                        };
                                        respuesta.datos = respuestaEnvio;
                                    }
                                    else
                                    {
                                        //usuario con la compañia inactiva
                                        if (respuestServicio == 8)
                                        {
                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                            respuesta.mensaje = "Error en el inicio de sesion" + "El usuario tiene la compañia inactiva";
                                            var respuestaEnvio = new
                                            {
                                                UsuarioTieneCompaniaInactiva = "true"
                                            };
                                            respuesta.datos = respuestaEnvio;
                                        }
                                        else
                                        {
                                            //error de procesamiento de datos, datos incorrectos
                                            string respuestServicio_ = respuestServicio.ToString().Substring(0, 1);
                                            if (respuestServicio_ == "3")
                                            {
                                                string connteo = respuestServicio.ToString().Substring(1, 1);
                                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                                if (connteo == "5")
                                                {

                                                    respuesta.mensaje = "Supero el numero de intentos de acceso, Usuario Bloqueado";
                                                }
                                                else
                                                {
                                                    respuesta.mensaje = "El usuario tiene los datos incorrectos";

                                                }

                                                // respuesta.datos = "{\"NumeroIntentosIncorrectos\":" + "  " + connteo + "}";
                                                var respuestaEnvio = new
                                                {
                                                    UsuarioTieneCompaniaInactiva = "true",
                                                    NumeroIntentosIncorrectos = connteo
                                                };
                                                respuesta.datos = respuestaEnvio;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }


                }
            }

            catch (Exception ex)
            {

                respuesta.exito = 0;
                respuesta.mensaje = ex.Message + " " + MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion.ToString();
                respuesta.datos = respuesta.mensaje;
            }
            return respuesta;
        }
        #endregion
        */
        #region enviar correo electronico  con nueva clave temporal
        [HttpPost("restablecer-clave")]
        public dynamic enviarCorreo([FromBody] MdloDtos.AutenticacionUsuario ObjautenticacionUsuario)
        {
            bool resultado = true;
            if ((!string.IsNullOrEmpty(ObjautenticacionUsuario.CodigoUsuario)) && ObjautenticacionUsuario.CodigoUsuario.Length > 0)
            {

                try
                {
                    resultado = this._dbContex.enviarCorreo(ObjautenticacionUsuario.CodigoUsuario);
                    if (resultado == true)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "Clave temporal enviado al correo electronico";
                        respuesta.datos = resultado;
                    }
                    else
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "no se pudo enviar correo electronico conm clave temporal";
                        respuesta.datos = resultado;
                    }
                }

                catch (Exception ex)
                {
                    respuesta.exito = 0;
                    respuesta.mensaje = "no se pudo enviar correo electronico conm clave temporal";
                    respuesta.datos = resultado;
                }

            }
            return respuesta;
        }
        #endregion

        #region validar si el correo ingresado corresponde al usuario que se ingreso
        [HttpGet("validar-CorreoUsuario")]
        public bool ValidarCorreoUsuario(string UsEmail, string UsCdgo)
        {
            bool resultado = true;
            if (((!string.IsNullOrEmpty(UsEmail)) && UsEmail.Length > 0) && ((!string.IsNullOrEmpty(UsCdgo)) && UsCdgo.Length > 0))
            {
               
                try
                {
                    resultado = this._dbContex.ValidarCorreoUsuario(UsEmail, UsCdgo);
                    if (resultado==true) {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "correo electronico  corresponde al usuario";
                        respuesta.datos = resultado.ToString();
                    }
                    else
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "correo electronico no corresponde al usuario";
                        respuesta.datos = resultado.ToString();
                    }
                }

                catch (Exception ex)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = "correo electronico no corresponde al codigo de usuario ingresado";
                    respuesta.datos = resultado.ToString();
                }
                
            }
            return resultado;
        }
        #endregion


        
        
        #region Validacion codigo temporal que fue enviado desde en el token
        [HttpPost("validar-otp")]
        public dynamic enviarCorreoConCodigo( [FromBody] MdloDtos.AutenticacionUsuario ObjautenticacionUsuario)
        {
            bool resultado = true;
            if ((!string.IsNullOrEmpty(ObjautenticacionUsuario.CodigoUsuario)) && ObjautenticacionUsuario.CodigoUsuario.Length > 0)
            {

                try
                {
                    resultado = this._dbContex.ValidarCodigoEnviadoCorreo(ObjautenticacionUsuario.CodigoCorreo, ObjautenticacionUsuario.CodigoUsuario);
                    if (resultado == true)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "Usuario inicio en el sistema de informacion";
                        var DobleAutenticacion = new
                        {

                            DobleAutenticacion = "True"
                        };
                        respuesta.datos = DobleAutenticacion;
                    }
                    else
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "Usuario no puede acceder en el sistema de informacion";
                        var DobleAutenticacion = new
                        {

                            DobleAutenticacion = "False"
                        };
                        respuesta.datos = DobleAutenticacion;
                    }
                }

                catch (Exception ex)
                {
                    respuesta.exito = 0;
                    respuesta.mensaje = "no se puedo enviar correo electronico con Codigo de verificacion";
                    respuesta.mensaje = "Usuario no puede acceder en el sistema de informacion";
                    var DobleAutenticacion = new
                    {

                        DobleAutenticacion = "False"
                    };
                    respuesta.datos = DobleAutenticacion;
                }

            }
            return respuesta;
        }
        #endregion


        


        


    }
}
