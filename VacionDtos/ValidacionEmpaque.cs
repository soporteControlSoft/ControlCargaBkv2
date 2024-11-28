using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Empaques.
    /// </summary>
    public class ValidacionEmpaque
    {

        AccsoDtos.Parametrizacion.Compania ObjCompania = new AccsoDtos.Parametrizacion.Compania();
        AccsoDtos.Parametrizacion.Empaque ObjEmpaque = new AccsoDtos.Parametrizacion.Empaque();

        #region Validacion de Empaque , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Empaque objEmpaque) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objEmpaque.EmCdgo) && (!string.IsNullOrEmpty(objEmpaque.EmNmbre)) && (!string.IsNullOrEmpty(objEmpaque.EmCdgoCia)))
                {
                    //Validar la llave relacional.
                    var ListaCompania = await ObjCompania.FiltrarCompaniaEspecifico(objEmpaque.EmCdgoCia.ToString());
                    if (ListaCompania == null || ListaCompania.Count==0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var EmpaqueExiste = await ObjEmpaque.VerificarEmpaque(objEmpaque.EmCdgo);
                        if (EmpaqueExiste == true)
                        {
                            //Retorna valor del TipoMensaje: CodigoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjEmpaque.ValidacionEmpaqueNombreIngresar(objEmpaque);
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

        #region Validacion de Empaque , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Empaque objEmpaque_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objEmpaque_.EmCdgo))
                {
                    //Validar que el codigo/Llave  exista.
                    var EmpaqueExiste = await ObjEmpaque.VerificarEmpaque(objEmpaque_.EmCdgo);
                    if (EmpaqueExiste == false)
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

        #region Validacion de Empaque , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Empaque objEmpaque)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objEmpaque.EmCdgo) && (!string.IsNullOrEmpty(objEmpaque.EmNmbre)) && (!string.IsNullOrEmpty(objEmpaque.EmCdgoCia)))
                {
                    //Validar la llave relacional.
                    var ListaCompania = await ObjCompania.FiltrarCompaniaEspecifico(objEmpaque.EmCdgoCia.ToString());
                    if (ListaCompania == null || ListaCompania.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var EmpaqueExiste = await ObjEmpaque.VerificarEmpaque(objEmpaque.EmCdgo);
                        if (EmpaqueExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjEmpaque.ValidacionEmpaqueNombreActualizar(objEmpaque);
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

        #region Validacion de Empaque Validar Busquedas ( Filtros)
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
