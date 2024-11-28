using MdloDtos;
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
    /// CRUD para el manejo del Perfil
    /// Daniel Alejandro Lopez
    /// </summary>
    public class Perfil:MdloDtos.IModelos.IPerfil
    {

        #region Ingresar datos a la entidad Perfil
        public async Task<MdloDtos.Perfil> IngresarPerfil(MdloDtos.Perfil _Perfil)
        {
            var ObjPerfil = new MdloDtos.Perfil();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PerfilExiste = await this.VerificarPerfil(_Perfil.PeCdgo);

                    if (PerfilExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPerfil.PeCdgo = _Perfil.PeCdgo;
                        ObjPerfil.PeNmbre = _Perfil.PeNmbre;
                        ObjPerfil.PeActvo = _Perfil.PeActvo;
                        var res = await _dbContex.Perfils.AddAsync(ObjPerfil);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjPerfil;
            }

        }
        #endregion

        #region Consultar todos los datos de Perfil mediante un parametro Codigo general que busque o por codigo o por Nombre
        public async Task<List<MdloDtos.Perfil>> FiltrarPerfilCodigoGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Perfils
                                 where p.PeCdgo.Contains(Codigo) || p.PeNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Perfil mediante un parametro Codigo de Perfil
        public async Task<List<MdloDtos.Perfil>> FiltrarPerfilEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Perfils
                                 where p.PeCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Actualizar Perfil pasando el objeto _Perfil
        public async Task<MdloDtos.Perfil> EditarPerfil(MdloDtos.Perfil _Perfil)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Perfil PerfilExiste = await _dbContex.Perfils.FindAsync(_Perfil.PeCdgo);
                    if (PerfilExiste != null)
                    {

                        PerfilExiste.PeCdgo = _Perfil.PeCdgo;
                        PerfilExiste.PeNmbre = _Perfil.PeNmbre;
                        PerfilExiste.PeActvo = _Perfil.PeActvo;
                        _dbContex.Entry(PerfilExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return PerfilExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }


        }

        #endregion

        #region Consultar todos los datos de Perfil
        public async Task<List<MdloDtos.Perfil>> ListarPerfil()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.Perfils.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        #endregion

        #region Eliminar Perfil
        public async Task<MdloDtos.Perfil> EliminarPerfil(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PerfilExiste = await _dbContex.Perfils.FindAsync(Codigo);
                    if (PerfilExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(PerfilExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return PerfilExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


        }

        #endregion

        #region verificar Perfil
        public async Task<bool> VerificarPerfil(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPerfil = await _dbContex.Perfils.FindAsync(Codigo);
                    if (ObjPerfil == null)
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
                return respuesta;
            }

        }


        #endregion
    }
}
