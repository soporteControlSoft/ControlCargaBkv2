using AutoMapper;
using MdloDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los parametros.
    /// </summary>
    public class ValidacionParametro
    {
        
        AccsoDtos.Parametrizacion.Parametros ObjParametros = new AccsoDtos.Parametrizacion.Parametros(null  , null); 

        #region valida si existe un parametro por medio de su ID.
        public async Task<int> VerificarParametroExiste(int IdParametro)
        {
            try
            {  
                if (IdParametro > 0)
                {
                    bool parametroExiste = await ObjParametros.VerificarParametroExiste(IdParametro);
                    return parametroExiste ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                                         : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion
    }
}
