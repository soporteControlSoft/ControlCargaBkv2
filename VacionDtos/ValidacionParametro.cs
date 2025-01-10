using AccsoDtos.Mappings;
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
        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.Parametros ObjParametros;


        public ValidacionParametro()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjParametros = new AccsoDtos.Parametrizacion.Parametros( _mapper, null);
        }
       
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
