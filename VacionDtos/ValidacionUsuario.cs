using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionUsuario
    {

        AccsoDtos.Parametrizacion.Usuario ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de Usuario , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Usuario _Objusuario)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(_Objusuario.UsCdgo)) && (_Objusuario.UsCdgo.Length > 0)  && (_Objusuario.UsCdgo != "")
                    )
                {
                    //Validar que el codigo/Llave  No exista.
                    var TipouIdentificacionExiste = await ObjUsuario.VerificarUsuario(_Objusuario.UsCdgo);
                    if (TipouIdentificacionExiste == true)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        /* var NombreExiste = ObjUsuario.ValidacionUsuarioNonbre(_Objusuario.UsNmbre);
                        //validar si el nombre existe
                        if (NombreExiste == true)
                        {
                            //Retorna el valor del tipo de mensaje: Nombre existe
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                        }
                        else {*/
                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;

                        //}      
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

        #region Validacion de Usuario , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Usuario _Objusuario)
        {

            int resultado = 0;
            try
            {
                string? Id = _Objusuario.UsCdgo;
                if ((!string.IsNullOrEmpty(_Objusuario.UsCdgo)) && (_Objusuario.UsCdgo.Length > 0) && (_Objusuario.UsCdgo != "")
                    )
                {
                    //Validar que el codigo/Llave  exista.
                    var TipoIdentificacionExiste = await ObjUsuario.VerificarUsuario(Id);
                    if (TipoIdentificacionExiste == false)
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

        #region Validacion de tipo de identificacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Usuario _Objusuario)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(_Objusuario.UsCdgo)) && (_Objusuario.UsCdgo.Length > 0) && (_Objusuario.UsCdgo != "")
                     )
                {


                    //Validar que el codigo/Llave  No exista.
                    var TipoIdentificacionExiste = await ObjUsuario.VerificarUsuario(_Objusuario.UsCdgo);
                    if (TipoIdentificacionExiste == false)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        /*var NombreExiste = ObjUsuario.ValidacionUsuarioNonbre(_Objusuario.UsNmbre);
                        //validar si el nombre existe
                        if (NombreExiste == true)
                        {
                            //Retorna el valor del tipo de mensaje: Nombre existe
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                        }
                        else
                        {*/
                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        //}
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

        #region Validacion de Usuario,  Validar Busquedas ( Filtros)
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
