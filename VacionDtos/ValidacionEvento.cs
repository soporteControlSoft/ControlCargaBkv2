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
    public class ValidacionEvento
    {

       
        AccsoDtos.EstadoHechos.Evento ObjEvento = new AccsoDtos.EstadoHechos.Evento();
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();
        AccsoDtos.EstadoHechos.Clasificacion _ObjClasificacion = new AccsoDtos.EstadoHechos.Clasificacion();
        AccsoDtos.EstadoHechos.Responsable _ObjResponsable = new AccsoDtos.EstadoHechos.Responsable();
        AccsoDtos.EstadoHechos.Equipo _ObjEquipo = new AccsoDtos.EstadoHechos.Equipo();


        #region Validacion de Evento , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Evento objEvento) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objEvento.EvNmbre) &&
                    !string.IsNullOrEmpty(objEvento.EvObsrvcion) &&
                    !string.IsNullOrEmpty(objEvento.EvFchaIncio)
                   )
                {
                    //Validar la llave relacional con el usuario.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objEvento.EvCdgoUsrio);
                    if (UsuarioExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {   //Validar la llave relacional con la clasificacion.
                        var ClasificacionExiste = await _ObjClasificacion.VerificarClasificacion(objEvento.EvRowidClsfccion);
                        if (ClasificacionExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {   //Validar la llave relacional con la Responsable.
                            var ResponsableExiste = await _ObjResponsable.VerificarResponsable(objEvento.EvRowidRspnsble);
                            if (ResponsableExiste == false)
                            {
                                //Retorna valor del TipoMensaje: RelacionNoExiste
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            }
                            else
                            {   //Validar la llave relacional con la Responsable.
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
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de evento , metodo inacvtivar
        public async Task<int> ValidarInactivar(MdloDtos.Evento objEvento)
        {
            int resultado = 0;
            try
            {
                var EventoExiste = await ObjEvento.VerificarEvento (objEvento.EvRowid);
                if (EventoExiste == true)
                {
                    if (
                        objEvento.EvActvo == true || objEvento.EvActvo == false
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
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
                }
                //Validar los campos Obligatorios.

            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de evento , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Evento objEvento)
        {
            int resultado = 0;
            try
            {
                var EventoExiste = await ObjEvento.VerificarEvento(objEvento.EvRowid);
                if (EventoExiste == true)
                {
                    if (
                        !string.IsNullOrEmpty(objEvento.EvNmbre) &&
                        !string.IsNullOrEmpty(objEvento.EvObsrvcion) &&
                        !string.IsNullOrEmpty(objEvento.EvFchaIncio) 
                   )
                    {
                        //Validar la llave relacional con el usuario.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objEvento.EvCdgoUsrio);
                        if (UsuarioExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {   //Validar la llave relacional con la clasificacion.
                            var ClasificacionExiste = await _ObjClasificacion.VerificarClasificacion(objEvento.EvRowidClsfccion);
                            if (ClasificacionExiste == false)
                            {
                                //Retorna valor del TipoMensaje: RelacionNoExiste
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            }
                            else
                            {   //Validar la llave relacional con la Responsable.
                                var ResponsableExiste = await _ObjResponsable.VerificarResponsable(objEvento.EvRowidRspnsble);
                                if (ResponsableExiste == false)
                                {
                                    //Retorna valor del TipoMensaje: RelacionNoExiste
                                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                                }
                                else
                                {   //Validar la llave relacional con la Responsable.
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
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
                }
                //Validar los campos Obligatorios.

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
