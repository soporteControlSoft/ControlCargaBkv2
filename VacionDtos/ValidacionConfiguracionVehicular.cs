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
    /// Clase para Validar las Configuraciones Vehicular
    /// </summary>
    public class ValidacionConfiguracionVehicular
    {
        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.ConfiguracionVehicular ObjConfiguracionVehicular;

        public ValidacionConfiguracionVehicular()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjConfiguracionVehicular = new AccsoDtos.Parametrizacion.ConfiguracionVehicular(_mapper);
        }

        #region Validacion de ConfiguracionVehicular , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.ConfiguracionVehicularDTO objConfiguracionVehicular)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(objConfiguracionVehicular.Codigo) && ((objConfiguracionVehicular.Codigo.Length > 0))) &&
                   ((!string.IsNullOrEmpty(objConfiguracionVehicular.Nombre) && ((objConfiguracionVehicular.Nombre.Length > 0)))) &&
                    ((!string.IsNullOrEmpty(objConfiguracionVehicular.CodigoCompania) && ((objConfiguracionVehicular.CodigoCompania.Length > 0)))))
                {                     
                    var ConfiguracionVehicularExiste = await ObjConfiguracionVehicular.VerificarConfiguracionVehicular(objConfiguracionVehicular.Codigo);
                    if (ConfiguracionVehicularExiste == true)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
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

        #region Validacion de ConfiguracionVehicular , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.ConfiguracionVehicularDTO objConfiguracionVehicular_)
        {
            int resultado = 0;
            try
            {
                if (objConfiguracionVehicular_.IdConfiguracionVehicular != null)
                {
                    var ConfiguracionVehicularExiste = await ObjConfiguracionVehicular.VerificarConfiguracionVehicularPorRowdId((int)objConfiguracionVehicular_.IdConfiguracionVehicular);
                    if (ConfiguracionVehicularExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de ConfiguracionVehicular , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.ConfiguracionVehicularDTO objConfiguracionVehicular)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objConfiguracionVehicular.Codigo) && ((objConfiguracionVehicular.Codigo.Length > 0))) &&
                  ((!string.IsNullOrEmpty(objConfiguracionVehicular.Nombre) && ((objConfiguracionVehicular.Nombre.Length > 0)))) &&
                   ((!string.IsNullOrEmpty(objConfiguracionVehicular.CodigoCompania) && ((objConfiguracionVehicular.CodigoCompania.Length > 0)))))
                {
                    //Validar que el codigo/Llave No exista.
                    var ConfiguracionVehicularExiste = await ObjConfiguracionVehicular.VerificarConfiguracionVehicular(objConfiguracionVehicular.Codigo);
                    if (ConfiguracionVehicularExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }

            return resultado;
        }
        #endregion

        #region Validacion de ConfiguracionVehicular Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(Busqueda)) || Busqueda.Length > 0)
                {
                    //Retorna valor del TipoMensaje: TransaccionExitosa
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
    }
}
