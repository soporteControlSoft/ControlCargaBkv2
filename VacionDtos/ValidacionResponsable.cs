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
    public class ValidacionResponsable
    {

       
        AccsoDtos.EstadoHechos.Responsable ObjResponsable = new AccsoDtos.EstadoHechos.Responsable(null, null);
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de Responsable , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.ResponsableDTO objResponsable) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objResponsable.Nombre) &&
                    !string.IsNullOrEmpty(objResponsable.Descripcion)
                   )
                {
                    //Validar la llave relacional.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objResponsable.CodigoUsuario);
                    if (UsuarioExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        //Retorna valor del TipoMensaje: RelacionNoExiste
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
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Responsable , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.ResponsableDTO objResponsable)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                var ResponsableExiste = await ObjResponsable.VerificarResponsable(objResponsable.Id);
                if (ResponsableExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                       objResponsable.Estado == true || objResponsable.Estado == false
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
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
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

        #region Validacion de Ciudad , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.ResponsableDTO objResponsable)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                var ResponsableExiste = await ObjResponsable.VerificarResponsable(objResponsable.Id);
                if (ResponsableExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                    !string.IsNullOrEmpty(objResponsable.Nombre) &&
                    !string.IsNullOrEmpty(objResponsable.Descripcion)
                   )
                    {
                        //Validar la llave relacional.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objResponsable.CodigoUsuario);
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
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
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

        #region Validacion de Ciudad, Validar Busquedas por IdDepartamento ( Filtros)
        //public async Task<int> ValidarFiltroBusquedasPorIdDepartamento(int IdDepartamento)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        if (IdDepartamento  != null && IdDepartamento > 0)
        //        {
        //            //Retorna valor del TipoMensaje: TransaccionExitosa
        //            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        //        }
        //        else
        //        {
        //            //Retorna valor del TipoMensaje: NoAceptaValoresNull
        //            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //Retorna valor del TipoMensaje: TransaccionIncorrecta
        //        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
        //    }
        //    return resultado;
        //}
        #endregion
    }
}
