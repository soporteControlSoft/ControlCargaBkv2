using AccsoDtos.Parametrizacion;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AccsoDtos.AccesoSistema
{
    /// <summary>
    /// Acceso al sistema de informacion , Utilizado para el controlador Login.
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 
    public class LoginSistema : MdloDtos.IModelos.ILoginSistema
    {

        #region validacion del usuario que ingresa al sistema de informacion ( si no necesita codigo enviado al correo)
        public async Task<int> ValidacionUsuario(string UsuarioCodigo, string CompaniaCodigo, string UsuarioClave) {
            int resultado = 0;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    int lengthCompaniaCodigo = CompaniaCodigo.Length;
                    int lengthUsuarioCodigo = UsuarioCodigo.Length;
                    int lengthUsuarioClave = UsuarioClave.Length;

                    DateTime Hoy = DateTime.Today;
                    if ((lengthCompaniaCodigo > 0 & CompaniaCodigo is not null) & (lengthUsuarioCodigo > 0 & UsuarioCodigo is not null) & (lengthUsuarioClave > 0 & UsuarioClave is not null))
                    {
                        var EsCorrecto = (from p in _dbContex.PerfilUsuarios
                                          join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                          join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                          where (p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave)) &&
                                          ((w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true))
                                          select p).Count();

                        var ObjValidacionCorrecta = EsCorrecto;
                        if (ObjValidacionCorrecta > 0)
                        {
                            //Validacion que no este dentro del rango de dias para el cambio de clave
                            var FechaCambioClave = (from p in _dbContex.PerfilUsuarios
                                                    join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                    join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                    where (p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave)) &&
                                                    ((w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true))
                                                    select new
                                                    {
                                                        FechaClave = w.UsFchaUltmaClve
                                                    });
                            DateTime Fecha = DateTime.Now;
                            foreach (var item in FechaCambioClave)
                            {
                                Fecha = Convert.ToDateTime(item.FechaClave);
                            }
                            //Fecha = Convert.ToDateTime(FechaCambioClave);
                            DateTime Actual = DateTime.Now;
                            int difFechas = Math.Abs(Fecha.Day - Actual.Day);
                            if (difFechas <= MdloDtos.Utilidades.Constantes.parametroCambioClave)
                            {
                                //exito.
                                //reiniciamos los intentos.
                                var UsuarioIntentos = await _dbContex.Usuarios.FindAsync(UsuarioCodigo);

                                //todo es correcto.
                                UsuarioIntentos.UsNmroIntntos = 0;
                                UsuarioIntentos.UsFchaUltmoIngso = Hoy;
                                _dbContex.Entry(UsuarioIntentos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                await _dbContex.SaveChangesAsync();

                                return 1;



                            }
                            else
                            {
                                //debe cambiar clave
                                var UsuarioExiste = await _dbContex.Usuarios.FindAsync(UsuarioCodigo);

                                if (UsuarioExiste != null)
                                {
                                    UsuarioExiste.UsDbeCmbiarClve = true;
                                    _dbContex.Entry(UsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    _dbContex.SaveChangesAsync();
                                    return 2;
                                }
                                else
                                {
                                    //error de procesamiento
                                    return 3;
                                }


                            }
                        }
                        //Error el usuario es inactivo
                        else
                        {

                            var UsuarioInactivo = (from p in _dbContex.PerfilUsuarios
                                                   join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                   join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                   where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave) && //"aa47f8215c6f30a0dcdb2a369f416e" &&
                                                   (w.UsActvo == false && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true)
                                                   select p).Count();

                            var ObjUsuarioInactivo = UsuarioInactivo;
                            if (ObjUsuarioInactivo > 0)
                            {
                                //usuario inactivo
                                return 4;
                            }
                            else
                            {

                                //Usuario Bloqueado
                                var UsuarioBloqueado = (from p in _dbContex.PerfilUsuarios
                                                        join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                        join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                        where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave) &&
                                                        (w.UsActvo == true && w.UsBlqdo == true && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true)
                                                        select p).Count();

                                var ObjUsuarioBloqueado = UsuarioBloqueado;
                                if (ObjUsuarioBloqueado > 0)
                                {
                                    //usuario bloqueado
                                    return 5;
                                }
                                else
                                {

                                    //Debe cambiar clave
                                    var UsuarioCambioClave = (from p in _dbContex.PerfilUsuarios
                                                              join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                              join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                              where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave) &&
                                                              (w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == true && p.PuActvo == true && r.CiaActva == true)
                                                              select p).Count();

                                    var ObjUsuarioCambioClave = UsuarioCambioClave;
                                    if (ObjUsuarioCambioClave > 0)
                                    {
                                        //usuario Debe cambiar clave
                                        return 6;
                                    }
                                    else
                                    {

                                        //Perfil Inactivo
                                        var UsuarioPerfilInactivo = (from p in _dbContex.PerfilUsuarios
                                                                     join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                                     join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                                     where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave) &&
                                                                     (w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == false && r.CiaActva == true)
                                                                     select p).Count();

                                        var ObjUsuarioPerfilInactivo = UsuarioPerfilInactivo;
                                        if (ObjUsuarioPerfilInactivo > 0)
                                        {
                                            //usuario Perfil Inactivo
                                            return 7;
                                        }
                                        else
                                        {

                                            //Compañia Inactiva
                                            var UsuarioCompaniaInactiva = (from p in _dbContex.PerfilUsuarios
                                                                           join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                                           join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                                           where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsClve1 == LoginSistema.MD5Hash(UsuarioClave) &&
                                                                           (w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == false)
                                                                           select p).Count();

                                            var ObjUsuarioCompaniaInactiva = UsuarioCompaniaInactiva;
                                            if (ObjUsuarioCompaniaInactiva > 0)
                                            {
                                                //usuario Compañia Inactiva
                                                return 8;
                                            }
                                            else
                                            {
                                                string retorno = "";
                                                short numeroIntentos = 0;
                                                //error datos incrorrectos.
                                                var Usuarios_ = (from p in _dbContex.PerfilUsuarios
                                                                 join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                                 join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                                 where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo
                                                                 select w).ToList();



                                                //conteo de intentos malos
                                                foreach (var p in Usuarios_)
                                                {

                                                    numeroIntentos = await EditarIntentos(p);

                                                }
                                                retorno = "3" + numeroIntentos.ToString();
                                                return Convert.ToInt32(retorno);

                                            }
                                        }
                                    }
                                }
                            }

                        }

                        //Conexiones._dbContex.Database.ExecuteSqlAsync($"EXECUTE dbo.Sp_ValidacionUsuarios @CompaniaCodigo ,  @UsuarioCodigo, @UsuarioClave");
                    }
                    else
                    {
                        //error datos incrorrectos.
                        return 3;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return resultado;
            }
        }
        #endregion

        #region Actualizar Numero de intentos
        public async Task<Int16> EditarIntentos(MdloDtos.Usuario usuario)
        {
            Int16? numeroIntentos = 0;
            using (MdloDtos.CcVenturaContext _dbContexo = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    numeroIntentos = (short?)(usuario.UsNmroIntntos + 1);
                    if (numeroIntentos == 5) {

                        usuario.UsBlqdo = true;

                    }
                    usuario.UsNmroIntntos = numeroIntentos;
                    _dbContexo.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _dbContexo.SaveChangesAsync();


                    _dbContexo.Dispose();

                    return (short)numeroIntentos;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }

            }
        }

        #endregion

        #region traer un nombre de compañia especifico
        public List<MdloDtos.Companium> FiltrarCompaniaEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = (from p in _dbContex.Compania
                           where p.CiaCdgo == Codigo
                           select p).ToList();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion
        #region Consultar un unico usuario para trear el nombre del usuario
        public List<MdloDtos.Usuario> FiltrarUsuarioEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = (from p in _dbContex.Usuarios
                           where p.UsCdgo == Codigo
                           select p).Distinct().ToList();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Obtener el perfil dado su compañia, usuario
        public List<MdloDtos.PerfilUsuario> ObtenerPerfilPorUsuario(string CodigoCompania, string CodigoUsuario)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = (from p in _dbContex.PerfilUsuarios
                           where p.PuCdgoCia == CodigoCompania && p.PuCdgoUsrio == CodigoUsuario
                           select p).ToList();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consultar todos los datos de Perfil Permiso mediante un parametro Codigo de compania y codigo de usuario y codigo de perfil
        public List<string> ObtenerPermisosPousuario(string CompaniaCodigo, string UsuarioCodigo, string CodigoPerfil)
        {
            List<string> ObjPermiso = new List<string>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = (from p in _dbContex.PerfilUsuarios
                           join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                           join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                           join d in _dbContex.PerfilPermisos on p.PuCdgoPrfil equals d.PpCdgoPrfil
                           where d.PpCdgoPrfil == CodigoPerfil
                           select new {

                               Permiso = d.PpPrmso

                           }).ToList();

                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    ObjPermiso.Add(item.Permiso);
                }
                return ObjPermiso;

            }


        }
        #endregion

        #region Consultar todos los datos de Perfil Permiso mediante un parametro Codigo de compania y codigo de usuario y codigo de perfil
        public String ObtenerRutasAccionesPorUsuario(string CompaniaCodigo, string UsuarioCodigo, string CodigoPerfil)
        {
            List<MdloDtos.RutaAccion> ObjRutaAcciones = new List<MdloDtos.RutaAccion>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                String cadenaRutaAcciones = "";
                var lst = (from usrio in _dbContex.Usuarios 
                           join prfil in _dbContex.PerfilUsuarios on usrio.UsCdgo equals prfil.PuCdgoUsrio  
                           join cmpnia in _dbContex.Compania on prfil.PuCdgoCia equals cmpnia.CiaCdgo
                           join prfilPrmsos in _dbContex.PerfilPermisos on prfil.PuCdgoPrfil equals prfilPrmsos.PpCdgoPrfil
                           join rta in _dbContex.Ruta on prfilPrmsos.PpRta equals rta.RuRowid

                           where cmpnia.CiaCdgo.Equals(CompaniaCodigo) && usrio.UsCdgo.Equals(UsuarioCodigo) && prfil.PuCdgoPrfil.Equals(CodigoPerfil)
                           select new
                           {
                               rta.RuRowid,
                               rta.RuNmbre,
                               prfilPrmsos.PpAccnes 
                           }).ToList();

                //Extraemos la lista de acciones del sistema
                var lstAccnes =   (from accnes in _dbContex.Acciones
                           select accnes).ToList();
                foreach (var item in lst)
                {
                    cadenaRutaAcciones = cadenaRutaAcciones+item.RuNmbre+":";
                    String[] acciones = item.PpAccnes.Split(',');
                    foreach (String accion in acciones) 
                    { 
                        foreach(MdloDtos.Accione _acciones in lstAccnes)
                        {
                            if(accion.Equals(""+_acciones.AcRowid))
                            {
                                cadenaRutaAcciones = cadenaRutaAcciones + _acciones.AcNmbre + ",";
                            }
                        }
                    }
                    cadenaRutaAcciones = cadenaRutaAcciones.Remove(cadenaRutaAcciones.Length - 1);
                    cadenaRutaAcciones = cadenaRutaAcciones + "##";
                }
                if(!cadenaRutaAcciones.Equals(""))
                { 
                    cadenaRutaAcciones = cadenaRutaAcciones.Remove(cadenaRutaAcciones.Length - 2); 
                }
                
                _dbContex.Dispose();
                return cadenaRutaAcciones;
            }
        }
        #endregion


        #region Actualizar Usuario Clave
        public async Task<int> ActualizarUsuarioClave(MdloDtos.AutenticacionUsuario ObjautenticacionUsuario)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                int resultado = 0;
                int lengthUsuarioCodigo = ObjautenticacionUsuario.CodigoUsuario.Length;
                int lengthUsuarioClave = ObjautenticacionUsuario.Clave.Length;
                int lengthUsuarioClaveNueva = ObjautenticacionUsuario.ClaveNueva.Length;

                string UsuarioCodigo = ObjautenticacionUsuario.CodigoUsuario;
                string UsuarioClave = LoginSistema.MD5Hash(ObjautenticacionUsuario.Clave);
                string UsuarioClaveNueva = LoginSistema.MD5Hash(ObjautenticacionUsuario.ClaveNueva);
                DateTime Hoy = DateTime.Today;

                var lstConsultaClave = (from usuario in _dbContex.Usuarios where usuario.UsClve1 == UsuarioClave select usuario).Count();

                if (lstConsultaClave > 0)
                {
                    if ((lengthUsuarioCodigo > 0 & UsuarioCodigo is not null) & (lengthUsuarioClave > 0 & UsuarioClave is not null) & (lengthUsuarioClaveNueva > 0 & UsuarioClaveNueva is not null))
                    {
                        var lst = (from p in _dbContex.PerfilUsuarios
                                   join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                   where p.PuCdgoUsrio == UsuarioCodigo
                                   select p).Count();

                        var ObjValidacion = lst;
                        if (ObjValidacion > 0)
                        {
                            //recorremos para que no almacene la misma clave el usuario en los 5 intentos.
                            var lstClaves = (from p in _dbContex.PerfilUsuarios
                                             join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                             where (w.UsClve1 == UsuarioClaveNueva || w.UsClve2 == UsuarioClaveNueva || w.UsClve3 == UsuarioClaveNueva &&
                                             w.UsClve4 == UsuarioClaveNueva | w.UsClve5 == UsuarioClaveNueva) && p.PuCdgoUsrio == UsuarioCodigo
                                             select w).Count();

                            if (lstClaves == 0)
                            {
                                //Actualizar clave.
                                MdloDtos.Usuario UsuarioExiste = await _dbContex.Usuarios.FindAsync(UsuarioCodigo);
                                if (UsuarioExiste != null)
                                {
                                    if (UsuarioExiste.UsClve4 == null)
                                    {

                                        UsuarioExiste.UsClve4 = " ";
                                    }
                                    UsuarioExiste.UsClve5 = UsuarioExiste.UsClve4;
                                    if (UsuarioExiste.UsClve3 == null)
                                    {

                                        UsuarioExiste.UsClve3 = " ";
                                    }
                                    UsuarioExiste.UsClve4 = UsuarioExiste.UsClve3;
                                    if (UsuarioExiste.UsClve2 == null)
                                    {

                                        UsuarioExiste.UsClve2 = " ";
                                    }
                                    UsuarioExiste.UsClve3 = UsuarioExiste.UsClve2;
                                    if (UsuarioExiste.UsClve1 == null)
                                    {

                                        UsuarioExiste.UsClve1 = " ";
                                    }
                                    UsuarioExiste.UsClve2 = UsuarioExiste.UsClve1;

                                    UsuarioExiste.UsClve1 = UsuarioClaveNueva;

                                    UsuarioExiste.UsFchaUltmaClve = Hoy;
                                    UsuarioExiste.UsDbeCmbiarClve = false;
                                    UsuarioExiste.UsBlqdo = false;
                                    UsuarioExiste.UsActvo = true;
                                    UsuarioExiste.UsFchaUltmoIngso = Hoy;
                                    UsuarioExiste.UsNmroIntntos = 0;
                                    _dbContex.Entry(UsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    await _dbContex.SaveChangesAsync();

                                }
                                //exito se pudo cambiar la clave
                                return resultado = 1;
                            }
                            else
                            {
                                //usuario existe con esa clave , no debe ser la misma
                                return resultado = 2;
                            }
                        }
                        else
                        {
                            //Datos incorrectos.
                            return resultado = 3;
                        }

                    }
                    else
                    {
                        //Datos incorrectos.
                        resultado = 3;
                    }

                }
                else 
                {   //Clave anterior no corresponde a la almacenada
                    return resultado = 4;
                }
                
                _dbContex.Dispose();
                return resultado;
            }
        }
        #endregion

        #region encriptar Cadena
        public static string MD5Hash(string cadena)
        {
            /*
            MD(int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta; md(int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta; = MD(int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;CryptoServiceProvider.Create();
            ASCIIEncoding codificacion = new ASCIIEncoding();
            byte[] cadenaEncriptada = null;
            StringBuilder sb = new StringBuilder();
            cadenaEncriptada = md(int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;.ComputeHash(codificacion.GetBytes(cadena));
            for (int i = 0; i < cadenaEncriptada.Length; i++)
            {
                sb.AppendFormat("{0:x2}", cadenaEncriptada[i]);
            }
            return sb.ToString();*/

            {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(cadena));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }

        }


        #endregion

        #region Validar correo del codigo de usuario
        public bool ValidarCorreoUsuario(string UsEmail, string UsCdgo)
        {

            bool Resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var validacion = (from p in _dbContex.Usuarios
                                  where p.UsEmail == UsEmail && p.UsCdgo == UsCdgo
                                  select p).Count();
                if (validacion >= 0)
                {

                    Resultado = true;
                }
            }
            return Resultado;

        }
        #endregion



        
        #region Enviar Correo con clave  es para cambiar clave en usuario
        public bool enviarCorreo(string UsuarioCodigo)
        {

            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                DateTime Hoy = DateTime.Today;
                AccesoSistema.EnvioCorreoElectronico ObjEnvio = new EnvioCorreoElectronico();
                MdloDtos.CorreoElectronico ObjModeloCorreo = new CorreoElectronico();
                AccesoSistema.GeneradorClave ObjGenerado = new GeneradorClave();

                MdloDtos.Usuario UsuarioExiste = _dbContex.Usuarios.Find(UsuarioCodigo);
                int digitosContraseña = 6;

                if (UsuarioExiste != null)
                {
                    if (UsuarioExiste.UsClve4 == null)
                    {

                        UsuarioExiste.UsClve4 = " ";
                    }
                    UsuarioExiste.UsClve5 = UsuarioExiste.UsClve4;
                    if (UsuarioExiste.UsClve3 == null)
                    {

                        UsuarioExiste.UsClve3 = " ";
                    }
                    UsuarioExiste.UsClve4 = UsuarioExiste.UsClve3;
                    if (UsuarioExiste.UsClve2 == null)
                    {

                        UsuarioExiste.UsClve2 = " ";
                    }
                    UsuarioExiste.UsClve3 = UsuarioExiste.UsClve2;
                    if (UsuarioExiste.UsClve1 == null)
                    {

                        UsuarioExiste.UsClve1 = " ";
                    }
                    UsuarioExiste.UsClve2 = UsuarioExiste.UsClve1;
                    String claveEnviada = ObjGenerado.generarContraseñaAleatoria(digitosContraseña);
                    UsuarioExiste.UsClve1 = LoginSistema.MD5Hash(claveEnviada);
                    
                    UsuarioExiste.UsFchaUltmaClve = Hoy;
                    UsuarioExiste.UsDbeCmbiarClve = true;
                    UsuarioExiste.UsBlqdo = false;
                    UsuarioExiste.UsActvo = true;
                    UsuarioExiste.UsFchaUltmoIngso = Hoy;
                    UsuarioExiste.UsNmroIntntos = 0;

                    //enviar correo
                    var correo = (from l in _dbContex.Parametros select l).ToList();

                    if (correo.Count > 0 || correo != null)
                    {

                        foreach (var item in correo)
                        {

                            ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                            ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                            ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                            ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                            ObjModeloCorreo.Para = UsuarioExiste.UsEmail;
                            ObjModeloCorreo.Asunto = "Correo generado de forma automatica , clave temporal OPP Ventura";
                            ObjModeloCorreo.Mensaje = " correo generado para el usuario " + UsuarioCodigo + " clave temporal: " + claveEnviada;
                            ObjModeloCorreo.Nombre_Archivo = "";
                            ObjModeloCorreo.Msg_error = "";
                        }

                    }

                    resultado = ObjEnvio.Enviar_Correo_Directo(ObjModeloCorreo);
                    if (resultado == true) {
                        _dbContex.Entry(UsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _dbContex.SaveChanges();
                        

                    }
                }
                return resultado;
            }
        }
        #endregion

        

        #region validacion del usuario que ingresa al sistema de informacion ( necesita codigo enviado al correo)
        public async Task<int> ValidacionUsuarioCodigoTemporal(string UsuarioCodigo, string CompaniaCodigo, string UsuarioClave)
        {
            int resultado = 0;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    int lengthCompaniaCodigo = CompaniaCodigo.Length;
                    int lengthUsuarioCodigo = UsuarioCodigo.Length;
                    int lengthUsuarioClave = UsuarioClave.Length;

                    DateTime Hoy = DateTime.Today;
                    if ((lengthCompaniaCodigo > 0 & CompaniaCodigo is not null) & (lengthUsuarioCodigo > 0 & UsuarioCodigo is not null) & (lengthUsuarioClave > 0 & UsuarioClave is not null))
                    {
                        var EsCorrecto = (from p in _dbContex.PerfilUsuarios
                                          join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                          join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                          where (p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave) &&
                                          ((w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true))
                                          select p).Count();

                        var ObjValidacionCorrecta = EsCorrecto;
                        if (ObjValidacionCorrecta > 0)
                        {
                            //Validacion que no este dentro del rango de dias para el cambio de clave
                            var FechaCambioClave = (from p in _dbContex.PerfilUsuarios
                                                    join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                    join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                    where (p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave) &&
                                                    ((w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true))
                                                    select new
                                                    {
                                                        FechaClave = w.UsFchaUltmaClve
                                                    });
                            DateTime Fecha = DateTime.Now;
                            foreach (var item in FechaCambioClave)
                            {
                                Fecha = Convert.ToDateTime(item.FechaClave);
                            }
                            //Fecha = Convert.ToDateTime(FechaCambioClave);
                            DateTime Actual = DateTime.Now;
                            int difFechas = Math.Abs(Fecha.Day - Actual.Day);
                            if (difFechas <= MdloDtos.Utilidades.Constantes.parametroCambioClave)
                            {
                                //exito.
                                //reiniciamos los intentos.
                                var UsuarioIntentos = await _dbContex.Usuarios.FindAsync(UsuarioCodigo);

                                //todo es correcto.
                                UsuarioIntentos.UsNmroIntntos = 0;
                                UsuarioIntentos.UsFchaUltmoIngso = Hoy;
                                _dbContex.Entry(UsuarioIntentos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                await _dbContex.SaveChangesAsync();

                                return 1;



                            }
                            else
                            {
                                //debe cambiar clave
                                var UsuarioExiste = await _dbContex.Usuarios.FindAsync(UsuarioCodigo);

                                if (UsuarioExiste != null)
                                {
                                    UsuarioExiste.UsDbeCmbiarClve = true;
                                    _dbContex.Entry(UsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                    _dbContex.SaveChangesAsync();
                                    return 2;
                                }
                                else
                                {
                                    //error de procesamiento
                                    return 3;
                                }


                            }
                        }
                        //Error el usuario es inactivo
                        else
                        {

                            var UsuarioInactivo = (from p in _dbContex.PerfilUsuarios
                                                   join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                   join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                   where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave && //"aa47f8215c6f30a0dcdb2a369f416e" &&
                                                   (w.UsActvo == false && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true)
                                                   select p).Count();

                            var ObjUsuarioInactivo = UsuarioInactivo;
                            if (ObjUsuarioInactivo > 0)
                            {
                                //usuario inactivo
                                return 4;
                            }
                            else
                            {

                                //Usuario Bloqueado
                                var UsuarioBloqueado = (from p in _dbContex.PerfilUsuarios
                                                        join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                        join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                        where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave &&
                                                        (w.UsActvo == true && w.UsBlqdo == true && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == true)
                                                        select p).Count();

                                var ObjUsuarioBloqueado = UsuarioBloqueado;
                                if (ObjUsuarioBloqueado > 0)
                                {
                                    //usuario bloqueado
                                    return 5;
                                }
                                else
                                {

                                    //Debe cambiar clave
                                    var UsuarioCambioClave = (from p in _dbContex.PerfilUsuarios
                                                              join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                              join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                              where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave &&
                                                              (w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == true && p.PuActvo == true && r.CiaActva == true)
                                                              select p).Count();

                                    var ObjUsuarioCambioClave = UsuarioCambioClave;
                                    if (ObjUsuarioCambioClave > 0)
                                    {
                                        //usuario Debe cambiar clave
                                        return 6;
                                    }
                                    else
                                    {

                                        //Perfil Inactivo
                                        var UsuarioPerfilInactivo = (from p in _dbContex.PerfilUsuarios
                                                                     join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                                     join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                                     where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave &&
                                                                     (w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == false && r.CiaActva == true)
                                                                     select p).Count();

                                        var ObjUsuarioPerfilInactivo = UsuarioPerfilInactivo;
                                        if (ObjUsuarioPerfilInactivo > 0)
                                        {
                                            //usuario Perfil Inactivo
                                            return 7;
                                        }
                                        else
                                        {

                                            //Compañia Inactiva
                                            var UsuarioCompaniaInactiva = (from p in _dbContex.PerfilUsuarios
                                                                           join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                                           join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                                           where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo && w.UsCdgo2fa == UsuarioClave &&
                                                                           (w.UsActvo == true && w.UsBlqdo == false && w.UsDbeCmbiarClve == false && p.PuActvo == true && r.CiaActva == false)
                                                                           select p).Count();

                                            var ObjUsuarioCompaniaInactiva = UsuarioCompaniaInactiva;
                                            if (ObjUsuarioCompaniaInactiva > 0)
                                            {
                                                //usuario Compañia Inactiva
                                                return 8;
                                            }
                                            else
                                            {
                                                string retorno = "";
                                                short numeroIntentos = 0;
                                                //error datos incrorrectos.
                                                var Usuarios_ = (from p in _dbContex.PerfilUsuarios
                                                                 join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                                                 join r in _dbContex.Compania on p.PuCdgoCia equals r.CiaCdgo
                                                                 where p.PuCdgoCia == CompaniaCodigo && p.PuCdgoUsrio == UsuarioCodigo
                                                                 select w).ToList();



                                                //conteo de intentos malos
                                                foreach (var p in Usuarios_)
                                                {

                                                    numeroIntentos = await EditarIntentos(p);

                                                }
                                                retorno = "3" + numeroIntentos.ToString();
                                                return Convert.ToInt32(retorno);

                                            }
                                        }
                                    }
                                }
                            }

                        }

                        //Conexiones._dbContex.Database.ExecuteSqlAsync($"EXECUTE dbo.Sp_ValidacionUsuarios @CompaniaCodigo ,  @UsuarioCodigo, @UsuarioClave");
                    }
                    else
                    {
                        //error datos incrorrectos.
                        return 3;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return resultado;
            }
        }
        #endregion

        #region Enviar Correo con clave de codigo para doble autentificacion
        public bool enviarCorreoConCodigo(string UsuarioCodigo)
        {

            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                DateTime Hoy = DateTime.Today;
                AccesoSistema.EnvioCorreoElectronico ObjEnvio = new EnvioCorreoElectronico();
                MdloDtos.CorreoElectronico ObjModeloCorreo = new CorreoElectronico();
                AccesoSistema.GeneradorClave ObjGenerado = new GeneradorClave();
                int digitosContraseña = 6;
                MdloDtos.Usuario UsuarioExiste = _dbContex.Usuarios.Find(UsuarioCodigo);
                if (UsuarioExiste != null)
                {

                    UsuarioExiste.UsFchaUltmaClve = Hoy;
                    UsuarioExiste.UsDbeCmbiarClve = false;
                    UsuarioExiste.UsBlqdo = false;
                    UsuarioExiste.UsActvo = true;
                    UsuarioExiste.UsFchaUltmoIngso = Hoy;
                    UsuarioExiste.UsCdgo2fa = ObjGenerado.generarContraseñaAleatoria(digitosContraseña);

                    //enviar correo
                    var correo = (from l in _dbContex.Parametros select l).ToList();

                    if (correo.Count > 0 || correo != null)
                    {

                        foreach (var item in correo)
                        {

                            ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                            ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                            ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                            ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                            ObjModeloCorreo.Para = UsuarioExiste.UsEmail;
                            ObjModeloCorreo.Asunto = "Correo generado de forma automatica , clave temporal OPP Ventura";
                            ObjModeloCorreo.Mensaje = " correo generado para el usuario " + UsuarioCodigo + " Codigo de validacion: " + UsuarioExiste.UsCdgo2fa;
                            ObjModeloCorreo.Nombre_Archivo = "";
                            ObjModeloCorreo.Msg_error = "";
                           
                        }

                    }
                    //se guarda el codigo temporal.
                    _dbContex.Entry(UsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                     _dbContex.SaveChanges();
                    resultado = ObjEnvio.Enviar_Correo_Directo(ObjModeloCorreo);
                }
                return resultado;
            }
        }
        #endregion

        #region Validar si el usuario tiene doble autentificacion (login)
        public bool NecesitaDobleAututentificacion(string UsuarioCodigo)
        {

            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var codigoUsuario = (from l in _dbContex.Usuarios
                                     where (l.UsCdgo == UsuarioCodigo && l.Us2fa == true)
                                     select l).ToList();
                if (codigoUsuario.Count > 0)
                {
                    resultado = true;
                }
                else {

                    resultado = false;
                }
                return resultado;
            }


        }


        #endregion
        public bool ValidarCodigoEnviadoCorreo(string Codigo, string UsuarioCodigo)
        {
            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var codigoUsuario = (from l in _dbContex.Usuarios
                                     where (l.UsCdgo == UsuarioCodigo && l.UsCdgo2fa== Codigo)
                                     select l).ToList();
                if (codigoUsuario.Count > 0 )
                {
                    resultado = true;
                }
                else
                {

                    resultado = false;
                }
                return resultado;
            }
        }
    }
}
