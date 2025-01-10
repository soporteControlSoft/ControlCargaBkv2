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
    /// Clase para Validar las Condiciones de Facturacion
    /// </summary>
    public class ValidacionCondicionFacturacion
    {
        private readonly IMapper _mapper; 
        AccsoDtos.Parametrizacion.CondicionFacturacion ObjCondicionFacturacion;

        public ValidacionCondicionFacturacion()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjCondicionFacturacion = new AccsoDtos.Parametrizacion.CondicionFacturacion(_mapper);
        }

        #region Validacion de CondicionFacturacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.CondicionFacturacionDTO objCondicionFacturacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objCondicionFacturacion.Codigo) && (!string.IsNullOrEmpty(objCondicionFacturacion.Nombre)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var CondicionFacturacionExiste = await ObjCondicionFacturacion.VerificarCondicionFacturacion(objCondicionFacturacion.Codigo);
                    if (CondicionFacturacionExiste == true)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
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

        #region Validacion de CondicionFacturacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.CondicionFacturacionDTO objCondicionFacturacion_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objCondicionFacturacion_.Codigo))
                {
                    //Validar que el codigo/Llave exista.
                    var CondicionFacturacionExiste = await ObjCondicionFacturacion.VerificarCondicionFacturacion(objCondicionFacturacion_.Codigo);
                    if (CondicionFacturacionExiste == false)
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

        #region Validacion de CondicionFacturacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.CondicionFacturacionDTO objCondicionFacturacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCondicionFacturacion.Codigo)) && (!string.IsNullOrEmpty(objCondicionFacturacion.Nombre)))
                {
                    //Validar que el codigo/Llave No exista.
                    var CondicionFacturacionExiste = await ObjCondicionFacturacion.VerificarCondicionFacturacion(objCondicionFacturacion.Codigo);
                    if (CondicionFacturacionExiste == false)
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

        #region Validacion de CondicionFacturacion Validar Busquedas ( Filtros)
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
