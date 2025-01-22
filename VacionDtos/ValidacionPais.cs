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
    /// Clase para la validacion de pais
    /// </summary>
    public class ValidacionPais
    {
        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.Pais _ObjPai ;

        public ValidacionPais()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            _ObjPai = new AccsoDtos.Parametrizacion.Pais(_mapper);
        }

        #region Validacion de Pais , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.PaisDTO ObjPai)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjPai.PaCdgo)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var PaisExiste = await _ObjPai.VerificarPais(ObjPai.PaCdgo);
                    if (PaisExiste == true)
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

        #region Validacion de Pais , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Pai ObjPai)
        {
            int resultado = 0;
            try
            {
                string? Id = ObjPai.PaCdgo;
                if (!string.IsNullOrEmpty(Id))
                {
                    //Validar que el codigo/Llave  exista.
                    var DepartamentoExiste = await _ObjPai.VerificarPais(Id);
                    if (DepartamentoExiste == false)
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

        #region Validacion de Pais , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.PaisDTO ObjPai)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(ObjPai.PaCdgo))
                {
                    //Validar que el codigo/Llave  No exista.
                    var PaisExiste = await _ObjPai.VerificarPais(ObjPai.PaCdgo);
                    if (PaisExiste == false)
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

        #region Validacion de País, Validar Busquedas ( Filtros)
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
