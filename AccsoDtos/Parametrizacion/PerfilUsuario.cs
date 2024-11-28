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
    /// CRUD para el manejo del perfil y usuario
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 
    public class PerfilUsuario : MdloDtos.IModelos.IPerfilUsuario
    {


        /// <summary>
        /// Cambios solicitado el dia 02-02-2024  Crear Endpoint para perfil Usuario
        /// </summary>
        /// <param name="_PerfilUsuario"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        #region Ingresar Perfil usuario
        public async Task<MdloDtos.PerfilUsuario> IngresarPerfilUsuario(List<MdloDtos.PerfilUsuario> _PerfilUsuario)
        {
            var ObjPerfilUsuario = new MdloDtos.PerfilUsuario(); // para el insert

            List<MdloDtos.PerfilUsuario> PerfilUsuarioEliminacion = new List<MdloDtos.PerfilUsuario>();//para la eliminacion

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //Eliminar perfiles de usuario.
                    foreach (var item in _PerfilUsuario)
                    {
       
                        
                        PerfilUsuarioEliminacion = await (from p in _dbContex.PerfilUsuarios
                                                          where p.PuCdgoCia == item.PuCdgoCia && p.PuCdgoUsrio == item.PuCdgoUsrio
                                                          select p).ToListAsync();

                        if (PerfilUsuarioEliminacion.Count >= 1)
                        {
                            foreach (var o in PerfilUsuarioEliminacion)
                            {
                                _dbContex.Remove(o);
                                await _dbContex.SaveChangesAsync();
                            }

                        }
                    }
                        //ingresar
                        foreach (var i in _PerfilUsuario)
                        {
                            ObjPerfilUsuario.PuCdgoCia = i.PuCdgoCia;
                            ObjPerfilUsuario.PuCdgoPrfil = i.PuCdgoPrfil;
                            ObjPerfilUsuario.PuCdgoUsrio = i.PuCdgoUsrio;
                            ObjPerfilUsuario.PuActvo = i.PuActvo;
                            ObjPerfilUsuario.PuRowid = null;
                            var res = await _dbContex.PerfilUsuarios.AddAsync(ObjPerfilUsuario);
                            await _dbContex.SaveChangesAsync();
                           
                            }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                
                return ObjPerfilUsuario;
            }
        }
        #endregion

        /*

        /// <summary>
        /// Cambio solictado el dia 03 de febrero del 2023 , Crear Endpoint para perfil Usuario
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        
        #region Actualizar Perfil Usuario por _Perfilusuario
        public async Task<MdloDtos.PerfilUsuario> EditarPerfilUsuario(List<MdloDtos.PerfilUsuario> _PerfilUsuario)
        {
            try
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    MdloDtos.PerfilUsuario PerfilUsuarioExiste = new MdloDtos.PerfilUsuario();
                    int? Id = 0;
                    foreach (var i in _PerfilUsuario)
                    {
                        //Eliminar perfiles de usuario.
                        Id = i.PuRowid;
                        if (Id > 0 && Id != null)
                        {
                            var PerfilUsuarioEliminacion = this.EliminarPerfilUsuario(Id);
                            //Ingreso de los nuevos perfiles del usuario
                            PerfilUsuarioExiste = await _dbContex.PerfilUsuarios.FindAsync(Id);
                            if (PerfilUsuarioExiste != null)
                            {

                                PerfilUsuarioExiste.PuCdgoCia = i.PuCdgoCia;
                                PerfilUsuarioExiste.PuCdgoPrfil = i.PuCdgoPrfil;
                                PerfilUsuarioExiste.PuCdgoUsrio = i.PuCdgoUsrio;
                                PerfilUsuarioExiste.PuActvo = i.PuActvo;
                                _dbContex.Entry(PerfilUsuarioExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                await _dbContex.SaveChangesAsync();

                            }


                        }
                    }
                    _dbContex.Dispose();
                    return PerfilUsuarioExiste;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        #endregion

        */

        #region Eliminar Perfil Usuarios por ID 
        public async Task<bool> EliminarPerfilUsuario(string  codigoCompania,string codigoPerfil,string codigoUsuario)
        {
            List<MdloDtos.PerfilUsuario> PerfilUsuarioExiste = new List<MdloDtos.PerfilUsuario>();
            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    PerfilUsuarioExiste = await (from p in _dbContex.PerfilUsuarios
                                                      where p.PuCdgoPrfil == codigoPerfil && p.PuCdgoCia== codigoCompania && p.PuCdgoUsrio==codigoUsuario
                                                     select p).ToListAsync();
                    
                    if (PerfilUsuarioExiste.Count>=1)
                    {
                        
                        foreach (var i in PerfilUsuarioExiste)
                        {
                            _dbContex.Remove(i);
                            await _dbContex.SaveChangesAsync();
                            resultado = true;
                        }

                    }
                    _dbContex.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }
        #endregion

        #region Consulta Perfil Usuario por codigo de Perfil
        public async Task<List<MdloDtos.PerfilUsuario>> FiltrarPerfilUsuarioPorPerfil(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.PerfilUsuarios
                                 join w in _dbContex.Perfils on p.PuCdgoPrfil equals w.PeCdgo
                                 where w.PeCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion


        #region Consulta Perfil usuarios por codigo de usuario
        public async Task<List<MdloDtos.PerfilUsuario>> FiltrarPerfilUsuarioPorUsuario(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.PerfilUsuarios
                                 join w in _dbContex.Usuarios on p.PuCdgoUsrio equals w.UsCdgo
                                 where w.UsCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        /// <summary>
        /// Cambio solictado el dia 03 de febrero del 2023 , Crear Endpoint para perfil Usuario
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        #region Listar todos los perfiles por Codigo de Compañia
        public async Task<List<string>> FiltrarPerfilUsuarioPorCompania(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<string> ObjPerfilUsuario = new List<string>();
                var lst = await (from p in _dbContex.PerfilUsuarios
                                 join w in _dbContex.Compania on p.PuCdgoCia equals w.CiaCdgo
                                 join e in _dbContex.Perfils on p.PuCdgoPrfil equals e.PeCdgo
                                 where w.CiaCdgo == Codigo
                                 select new { 
                                 
                                     codigoUsuario=p.PuCdgoUsrio,
                                     codigoCompania=p.PuCdgoCia,
                                     nombreCompania=w.CiaNmbre,
                                     codigoPerfil=p.PuCdgoPrfil,
                                     nombrePerfil=e.PeNmbre,
                                     estado=p.PuActvo


                                 }).ToListAsync();

                foreach (var item in lst)
                {
                    ObjPerfilUsuario.Add(item.codigoUsuario);
                    ObjPerfilUsuario.Add(item.codigoCompania);
                    ObjPerfilUsuario.Add(item.nombreCompania);
                    ObjPerfilUsuario.Add(item.nombreCompania);
                    ObjPerfilUsuario.Add(item.codigoPerfil);
                    ObjPerfilUsuario.Add(item.nombrePerfil);
                    ObjPerfilUsuario.Add(item.estado.ToString());
                }
                
                _dbContex.Dispose();

                return ObjPerfilUsuario;
            }
        }

        #endregion

        #region Listar todos los perfiles de todas las compañias y todos los usuarios
        public async Task<List<MdloDtos.PerfilUsuario>> ListarPerfilUsuario()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.PerfilUsuarios
                                 join
                                 t in _dbContex.Compania on p.PuCdgoCia equals t.CiaCdgo
                                 join w in _dbContex.Perfils on p.PuCdgoPrfil equals w.PeCdgo
                                 join k in _dbContex.Usuarios on p.PuCdgoUsrio equals k.UsCdgo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion


       

        #region verificar Perfil Usuario por codigo de usuario , codigo de compañia y codigo de perfil
        public async Task<bool> VerificarPerfilUsuario(string PuCdgoPrfil,string PuCdgoCia,string PuCdgoUsrio)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.PerfilUsuarios
                               where p.PuCdgoPrfil == PuCdgoPrfil &&
                               p.PuCdgoCia == PuCdgoCia &&
                               p.PuCdgoUsrio == PuCdgoUsrio
                               select p).Count();

                    var ObjPerfilUsuario = lst;
                    if (ObjPerfilUsuario == null || ObjPerfilUsuario == 0)
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
