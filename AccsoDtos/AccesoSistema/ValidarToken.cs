using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.AccesoSistema
{
    /// <summary>
    /// Clase con el metodo patra validar el Token.
    /// 
    /// </summary>
    public  class ValidarToken
    {
        #region validar tokem , Obtener codigo de Perfil y Permisos.
        public dynamic validarAcceso(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {

                    return new
                    {
                        succes = false,
                        messaje = "verificar el token , es invalido",
                        result = ""
                    };
                }
                //si solo fueramos a tomar el perfil
                var Codperfil=identity.Claims.FirstOrDefault(x=>x.Type== "CodigoPerfil").Value;
                

                return new
                {
                    succes = true,
                    messaje = "exito",
                    result = Codperfil


                };
            }
            catch (Exception e) 
            {
                return new
                {
                    succes = false,
                    messaje = "Error" + e.ToString(),
                    result = ""

                };


            }


        }
        #endregion

        public  List<MdloDtos.PerfilPermiso> ConsultarPermisos(string CodigoPerfil)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = (from p in _dbContex.PerfilPermisos
                           where p.PpCdgoPrfil == CodigoPerfil.ToString()
                           select p).ToList();
                _dbContex.Dispose();
                return lst;
            }

        }

    
    }
}
