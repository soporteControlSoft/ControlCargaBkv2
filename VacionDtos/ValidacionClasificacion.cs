﻿using MdloDtos.DTO;
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
    public class ValidacionClasificacion
    {
        AccsoDtos.EstadoHechos.Clasificacion ObjClasificacion = new AccsoDtos.EstadoHechos.Clasificacion(null, null);
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de Clasificacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.ClasificacionDTO objClasificacion)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objClasificacion.Nombre) &&
                    !string.IsNullOrEmpty(objClasificacion.Descripcion)
                   )
                {
                    //Validar la llave relacional.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objClasificacion.CodigoUsuario);
                    if (UsuarioExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
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

        #region Validacion de Ciudad , metodo Inactivar
        public async Task<int> ValidarEliminar(ClasificacionDTO objClasificacionDTO)
        {
            int resultado = 0;
            try
            {
                var ClasificacionExiste = await ObjClasificacion.VerificarClasificacion(objClasificacionDTO.Id);
                if (ClasificacionExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                        objClasificacionDTO.Estado == true || objClasificacionDTO.Estado == false
                       )
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: NoAceptaValoresNull
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
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

        #region Validacion de Clasificacion, metodo Actualizar
        public async Task<int> ValidarActualizacion(ClasificacionDTO objClasificacionDTO)
        {
            int resultado = 0;
            try
            {
                var ClasificacionExiste = await ObjClasificacion.VerificarClasificacion(objClasificacionDTO.Id);
                if (ClasificacionExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                        !string.IsNullOrEmpty(objClasificacionDTO.Nombre) &&
                        !string.IsNullOrEmpty(objClasificacionDTO.Descripcion)
                       )
                    {
                        //Validar la llave relacional.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objClasificacionDTO.CodigoUsuario);
                        if (UsuarioExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            //Validar que el codigo/Llave  No exista.
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: NoAceptaValoresNull
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
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

        #region Validacion de clasificacion Validar Busquedas ( Filtros)
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
