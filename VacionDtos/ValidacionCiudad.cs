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
    /// Clase para Validar las ciudades.
    /// </summary>
    public class ValidacionCiudad
    {
        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.Departamento ObjDepartamento = new AccsoDtos.Parametrizacion.Departamento();
        AccsoDtos.Parametrizacion.Ciudad ObjCiudad;

        public ValidacionCiudad()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjCiudad = new AccsoDtos.Parametrizacion.Ciudad(_mapper);
        }




        #region Validacion de Ciudad , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.CiudadDTO objCiudad) {

            int resultado = 0;
            try {
                if ((!string.IsNullOrEmpty(objCiudad.Codigo) && (objCiudad.Codigo.Length > 0)) && ((!string.IsNullOrEmpty(objCiudad.Nombre) && ((objCiudad.Nombre.Length > 0)))) &&
                   ((objCiudad.IdDepartamento > 0)))
                {
                    var departamentoExiste = await ObjDepartamento.VerificarDepartamentoId(objCiudad.IdDepartamento);
                    if (departamentoExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        var CiudadExiste = await ObjCiudad.VerificarCiudad(objCiudad.Codigo);
                        if (CiudadExiste == true)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
                    }
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

        #region Validacion de Ciudad , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.CiudadDTO objCiudad_)
        {
            int resultado = 0;
            try
            {
                if(objCiudad_.IdCiudad != null)
                {
                    var CiudadExiste = await ObjCiudad.VerificarCiudadPorRowId((int)objCiudad_.IdCiudad);
                    if (CiudadExiste == false)
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

        #region Validacion de Ciudad , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.CiudadDTO objCiudad)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(objCiudad.Codigo) && (objCiudad.Codigo.Length > 0)) && ((!string.IsNullOrEmpty(objCiudad.Nombre) && ((objCiudad.Nombre.Length > 0)))) &&
                   ((objCiudad.IdDepartamento > 0)))
                {
                    var DepartamentoExiste = await ObjDepartamento.VerificarDepartamentoId(objCiudad.IdDepartamento);
                    if (DepartamentoExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        var CiudadExiste = await ObjCiudad.VerificarCiudad(objCiudad.Codigo);
                        if (CiudadExiste == false)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
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

        #region Validacion de Ciudad Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            try
            {
                return ((!string.IsNullOrEmpty(Busqueda)) || Busqueda.Length > 0) ? 
                            (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa :
                            (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }
            catch (Exception e)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de Ciudad, Validar Busquedas por IdDepartamento ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdDepartamento(int IdDepartamento)
        {
            try
            {
                return (IdDepartamento > 0) ? 
                            (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa :
                            (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }
            catch (Exception e)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion
    }
}
