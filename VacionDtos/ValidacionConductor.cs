using AccsoDtos.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los conductores.
    /// </summary>
    public class ValidacionConductor
    {
        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.Conductor ObjConductor;
        public ValidacionConductor()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjConductor = new AccsoDtos.Parametrizacion.Conductor(_mapper);
        }

        #region Validacion de Conductor , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.ConductorDTO objConductor) {
            int resultado = 0;
            try 
            {
                if ((!string.IsNullOrEmpty(objConductor.Identificacion)) && (!string.IsNullOrEmpty(objConductor.Nombre)))
                {
                        bool ConductorExiste = await ObjConductor.VerificarExistenciaConductor(objConductor.Identificacion);
                        resultado = ConductorExiste ?  (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste :
                                                    (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch(Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Conductor , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.ConductorDTO objConductor)
        {
            int resultado = 0;
            try
            {
                if(objConductor.Identificacion != null)
                {
                    bool ConductorExiste = await ObjConductor.VerificarExistenciaConductor(objConductor.Identificacion);
                    resultado = ConductorExiste ?  (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa :
                                                    (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Conductor , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.ConductorDTO objConductor)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(objConductor.Identificacion)) && (!string.IsNullOrEmpty(objConductor.Nombre)))
                {
                    bool ConductorExiste = await ObjConductor.VerificarExistenciaConductor(objConductor.Identificacion);
                    resultado = !ConductorExiste ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste :
                                                (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Conductor Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            int resultado = 0;
            try
            {
                resultado= (!string.IsNullOrEmpty(Busqueda)) ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa:
                                                               (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

    }
}
