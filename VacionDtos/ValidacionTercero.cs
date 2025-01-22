using AccsoDtos.Mappings;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los terceros
    /// </summary>
    public class ValidacionTercero
    {
        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.Tercero ObjTercero ;
        AccsoDtos.Parametrizacion.Compania ObjCompania ;

        public ValidacionTercero()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjCompania = new AccsoDtos.Parametrizacion.Compania(_mapper);
        }


        #region Validacion de Tercero , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Tercero objTercero) {
            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objTercero.TeCdgo) && (!string.IsNullOrEmpty(objTercero.TeCdgoCia)))
                {
                    //Validar la llave relacional.
                    var ListaCompania = await ObjCompania.FiltrarCompaniaEspecifico(objTercero.TeCdgoCia);
                    if (ListaCompania == null || ListaCompania.Count==0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        var NombreExiste = ObjTercero.ValidacionTerceroNombreIngresar(objTercero);
                        //validar si el nombre existe
                        if (NombreExiste == true)
                        {
                            //Retorna el valor del tipo de mensaje: Nombre existe
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                        }
                        else {

                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
                        
                    }
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Tercero , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Tercero objTercero)
        {
            int resultado = 0;
            try
            {
                if (objTercero.TeRowid != null)
                {
                    //Validar que el codigo/Llave  exista.
                    var TerceroExiste = await ObjTercero.VerificarTerceroPorId(objTercero.TeRowid);
                    if (TerceroExiste == false)
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

        #region Validacion de Tercero , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Tercero objTercero)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objTercero.TeCdgo) && (!string.IsNullOrEmpty(objTercero.TeCdgoCia)))
                { 
                    //Validar la llave relacional.
                    var ListaCompania = await ObjCompania.FiltrarCompaniaEspecifico(objTercero.TeCdgoCia);
                    if (ListaCompania == null || ListaCompania.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var TerceroExiste = await ObjTercero.VerificarTercero(objTercero.TeCdgo);
                        if (TerceroExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjTercero.ValidacionTerceroNombreActualizar(objTercero);
                            //validar si el nombre existe
                            if (NombreExiste == true)
                            {
                                //Retorna el valor del tipo de mensaje: Nombre existe
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                            }
                            else
                            {
                                //Retorna valor del TipoMensaje: TransaccionExitosa
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                            }
                        }
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

        #region Validacion de Tercero Validar Busquedas ( Filtros)
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

        #region Validacion de Tercero Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorTipo(int? tipo)
        {
            int resultado = 0;
            try
            {
                if (tipo != null  && tipo > 0)
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

        #region verifica que un tercero exista
        public async Task<int> ValidarExistenciaTercero(int codigo)
        {
            try
            {
                if (codigo > 0)
                {
                    bool TerceroExiste = await ObjTercero.VerificarTerceroPorId(codigo);
                    return  !TerceroExiste ?
                                    (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste :
                                    (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
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

        #region verifica que un tercero exista
        public async Task<MdloDtos.Tercero> ConsultarTerceroPorId(int IdTercero)
        {
            try
            {
                List<MdloDtos.Tercero> lista= await ObjTercero.FiltrarTerceroEspecificoPorId(IdTercero);
                return (lista != null && lista.Count() > 0) ? 
                      lista.First() : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
