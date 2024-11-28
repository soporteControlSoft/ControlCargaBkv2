using Azure;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.AccesoSistema
{
    /// <summary>
    /// Metodos para el almacenamiento de los permisos de los perfiles.
    /// Daniel Alejandro Lopez
    /// </summary>
    public class PerfilPermiso:MdloDtos.IModelos.IPerfilPermisos
    {
       
        #region Listar todos los PerfilesPermisos
        public async Task<List<MdloDtos.PerfilPermiso>> ListarPerfilPermiso()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.PerfilPermisos
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Ingresar datos a la entidad Perfil Permiso cuando es Catalogo.No enviar el Id ya que es Autoincrement en la bd
        public async Task<MdloDtos.PerfilPermiso> IngresarPerfilPermisoCatalogo(MdloDtos.PerfilPermiso _PerfilPermiso)
        {
            var ObjPerfilPermiso = new MdloDtos.PerfilPermiso();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PerfilPermisoExiste = await this.VerificarPerfilPermiso(_PerfilPermiso.PpCdgoPrfil);

                    if (PerfilPermisoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {

                        ObjPerfilPermiso.PpCdgoPrfil = _PerfilPermiso.PpCdgoPrfil;
                        ObjPerfilPermiso.PpPrmso = PermisoEncriptacionCatalogo(_PerfilPermiso.PpPrmso, _PerfilPermiso.Operacion);
                        var res = await _dbContex.PerfilPermisos.AddAsync(ObjPerfilPermiso);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjPerfilPermiso;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }
        #endregion

        #region Encriptar el permiso ingresado o actualizado al perfil cuando es catalogo
        private string PermisoEncriptacionCatalogo(string Permiso,string operacion) {

            string resultado = "";
            var Ingreso = Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 1);
            var Actualizacion = Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 2);
            var Eliminacion = Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 4);
            var Consulta = Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 3);

            //codigo para encriptar Permisos.

            if (operacion == Ingreso)
            {
                resultado = LoginSistema.MD5Hash(Permiso +"."+Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 1));
            }
            if (operacion == Actualizacion)
            {

                resultado = LoginSistema.MD5Hash(Permiso + "." + Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 2));
            }
            if (operacion == Eliminacion)
            {

                resultado = LoginSistema.MD5Hash(Permiso + "." + Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 4));
            }
            if (operacion == Consulta)
            {

                resultado = LoginSistema.MD5Hash(Permiso + "." + Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 3));
            }
            return resultado;

        }
        #endregion

        #region Actualizar Perfil Permiso  por el objeto _PerfilPermisoExiste y la constante cuando es catalogo
        public async Task<MdloDtos.PerfilPermiso> EditarPerfilPermisoCatalogo(MdloDtos.PerfilPermiso _PerfilPermiso)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try {
                    MdloDtos.PerfilPermiso PerfilPermisoExiste = await _dbContex.PerfilPermisos.FindAsync(_PerfilPermiso.PpRowid);

                    if (PerfilPermisoExiste != null)
                    {
                        //codigo de encriptacion
                        PerfilPermisoExiste.PpCdgoPrfil = _PerfilPermiso.PpCdgoPrfil;
                        PerfilPermisoExiste.PpPrmso = PermisoEncriptacionCatalogo(_PerfilPermiso.PpPrmso, _PerfilPermiso.Operacion); ;
                        _dbContex.Entry(PerfilPermisoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return PerfilPermisoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion
      
        #region Ingresar datos a la entidad Perfil Permiso cuando es menu.
        public async Task<MdloDtos.PerfilPermiso> IngresarPerfilPermisoMenu(MdloDtos.PerfilPermiso _PerfilPermiso)
        {
            var ObjPerfilPermiso = new MdloDtos.PerfilPermiso();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PerfilPermisoExiste = await this.VerificarPerfilPermiso(_PerfilPermiso.PpCdgoPrfil);

                    if (PerfilPermisoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPerfilPermiso.PpCdgoPrfil = _PerfilPermiso.PpCdgoPrfil;
                        ObjPerfilPermiso.PpPrmso = LoginSistema.MD5Hash(_PerfilPermiso.PpPrmso);
                        var res = await  _dbContex.PerfilPermisos.AddAsync(ObjPerfilPermiso);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjPerfilPermiso;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }
        #endregion

        #region Actualizar Perfil Permiso  por el objeto _PerfilPermisoExiste y la constante cuando es catalogo
        public async Task<MdloDtos.PerfilPermiso> EditarPerfilPermisoMenu(MdloDtos.PerfilPermiso _PerfilPermiso)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try {
                    MdloDtos.PerfilPermiso PerfilPermisoExiste = await _dbContex.PerfilPermisos.FindAsync(_PerfilPermiso.PpRowid);

                    if (PerfilPermisoExiste != null)
                    {
                        //codigo de encriptacion
                        PerfilPermisoExiste.PpCdgoPrfil = _PerfilPermiso.PpCdgoPrfil;
                        PerfilPermisoExiste.PpPrmso = LoginSistema.MD5Hash(_PerfilPermiso.PpPrmso);

                        _dbContex.Entry(PerfilPermisoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return PerfilPermisoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Eliminar Perfil Permiso Por codigo, se borran todos los registros del perfil
        public async Task<bool> EliminarPerfilPermiso(string CodigoPerfil)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //borramos los permisos del perfil antes de ingresar los nuevos.
                    var resultado = (from p in _dbContex.PerfilPermisos
                                     where p.PpCdgoPrfil == CodigoPerfil
                                     select p).Count();
                    if (resultado > 0)
                    {
                        var PerfilPermisoExiste_ = (from p in _dbContex.PerfilPermisos
                                                    where p.PpCdgoPrfil == CodigoPerfil
                                                    select p).ToList();

                        foreach (var item in PerfilPermisoExiste_)
                        {
                            _dbContex.Remove(item);
                            await _dbContex.SaveChangesAsync();
                        }

                        respuesta = true;
                    }
                    _dbContex.Dispose();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }
        #endregion

        #region verificar Departamento por codigo.
        private async Task<bool> VerificarPerfilPermiso(string CodigoPerfil)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPerfilPermiso = (from p in _dbContex.PerfilPermisos
                                            where p.PpCdgoPrfil == CodigoPerfil.ToString()
                                            select p).Distinct();

                    if (ObjPerfilPermiso != null || Convert.ToInt32(ObjPerfilPermiso.Distinct()) > 0)
                    {

                        respuesta = false; ;
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
                return respuesta;
            }

        }

        


        #endregion

    }
}
