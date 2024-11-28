using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// CRUD para el manejo de usuarios
    /// Daniel Alejandro Lopez
    /// </summary>
    public class Usuario : MdloDtos.IModelos.IUsuario
    {

        #region Ingresar datos a la entidad Usuario
        public async Task<MdloDtos.Usuario> IngresarUsuario(MdloDtos.Usuario _Usuario)
        {
            var ObjUsuario = new MdloDtos.Usuario();
            DateTime Hoy = DateTime.Today;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
             
                    var UsuarioExiste = await this.VerificarUsuario(_Usuario.UsCdgo);

                    if (UsuarioExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjUsuario.UsCdgo = _Usuario.UsCdgo;
                        ObjUsuario.UsNmbre = _Usuario.UsNmbre;
                        ObjUsuario.UsIdntfccion = _Usuario.UsIdntfccion;
                        ObjUsuario.UsRowidTrcro = _Usuario.UsRowidTrcro;
                        ObjUsuario.UsActvo = _Usuario.UsActvo;
                        ObjUsuario.UsSper = _Usuario.UsSper;
                        ObjUsuario.UsIncles = _Usuario.UsIncles;
                        ObjUsuario.UsEmail = _Usuario.UsEmail;
                        ObjUsuario.UsFchaUltmaClve = _Usuario.UsFchaUltmaClve;   
                        ObjUsuario.UsClve1 = AccesoSistema.LoginSistema.MD5Hash(_Usuario.UsClve1);
                        ObjUsuario.UsClve2 = "";
                        ObjUsuario.UsClve3 = "";
                        ObjUsuario.UsClve4 = "";
                        ObjUsuario.UsClve5 = "";
                        ObjUsuario.UsBlqdo = _Usuario.UsBlqdo;
                        ObjUsuario.UsDbeCmbiarClve = _Usuario.UsDbeCmbiarClve;
                        ObjUsuario.UsSperVldcion = _Usuario.UsSperVldcion;
                        ObjUsuario.UsNmroIntntos = 0;
                        ObjUsuario.UsFchaUltmoIngso= Hoy;
                        ObjUsuario.Us2fa = _Usuario.Us2fa;
                        var res = await _dbContex.Usuarios.AddAsync(ObjUsuario);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjUsuario;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }
        #endregion

        #region Consultar todos los datos de Usuario mediante un parametro Codigo general
        public async Task<List<MdloDtos.Usuario>> FiltrarUsuarioGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Usuarios
                                 where p.UsCdgo.Contains(Codigo) || p.UsNmbre.Contains(Codigo) || p.UsIdntfccion.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Usuario mediante un parametro Codigo especifico
        public async Task<List<MdloDtos.Usuario>> FiltrarUsuarioEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Usuarios
                                 where p.UsCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consulta los datos del usuario mediante un parámetro el Nombre

        public bool ValidacionUsuarioNobre(string Nombre)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Usuarios
                           where e.UsNmbre == Nombre
                           select e).Count();

                if (lst > 0)
                {
                    retorno = true;

                }

                _dbContex.Dispose();
                return retorno;

            }
        }
        #endregion

        #region Actualizar Usuario pasando el objeto _Usuario
        public async Task<MdloDtos.Usuario> EditarUsuario(MdloDtos.Usuario _Usuario)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                DateTime Hoy = DateTime.Today;
                try {
                    MdloDtos.Usuario UsuarioExiste = await _dbContex.Usuarios.FindAsync(_Usuario.UsCdgo);
                    if (UsuarioExiste != null)
                    {

                        UsuarioExiste.UsCdgo = _Usuario.UsCdgo;
                        UsuarioExiste.UsNmbre = _Usuario.UsNmbre;
                        UsuarioExiste.UsIdntfccion = _Usuario.UsIdntfccion;
                        UsuarioExiste.UsRowidTrcro = _Usuario.UsRowidTrcro;
                        UsuarioExiste.UsActvo = _Usuario.UsActvo;
                        UsuarioExiste.UsSper = _Usuario.UsSper;
                        UsuarioExiste.UsIncles = _Usuario.UsIncles;
                        UsuarioExiste.UsEmail = _Usuario.UsEmail;
                        UsuarioExiste.UsFchaUltmaClve = _Usuario.UsFchaUltmaClve;
                        if (UsuarioExiste.UsClve4 == null )
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

                        UsuarioExiste.UsClve1 = AccesoSistema.LoginSistema.MD5Hash(_Usuario.UsClve1);
                        UsuarioExiste.UsBlqdo = _Usuario.UsBlqdo;
                        UsuarioExiste.UsDbeCmbiarClve = _Usuario.UsDbeCmbiarClve;
                        UsuarioExiste.UsSperVldcion = _Usuario.UsSperVldcion;
                        UsuarioExiste.UsNmroIntntos = 0;
                        UsuarioExiste.UsFchaUltmoIngso = Hoy;
                        UsuarioExiste.Us2fa = _Usuario.Us2fa;
                        _dbContex.Entry(UsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return UsuarioExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region Consultar todos los datos de Usuario
        public async Task<List<MdloDtos.Usuario>> ListarUsuario()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.Usuarios.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Eliminar Usuario
        public async Task<MdloDtos.Usuario> EliminarUsuario(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var UsuarioExiste = await _dbContex.Usuarios.FindAsync(Codigo);
                    if (UsuarioExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(UsuarioExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return UsuarioExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }

            }
        }

        #endregion

        #region verificar Usuario
        public async Task<bool> VerificarUsuario(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjUsuario = await _dbContex.Usuarios.FindAsync(Codigo);
                    respuesta = ObjUsuario !=null ? true : false;   
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
