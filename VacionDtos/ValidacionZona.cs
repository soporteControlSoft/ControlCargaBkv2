using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para validacion de la zona
    /// </summary>
    public  class ValidacionZona
    {
        AccsoDtos.Parametrizacion.ZonaCd ObjZonaCd = new AccsoDtos.Parametrizacion.ZonaCd();
        AccsoDtos.Parametrizacion.Sede ObjSede = new AccsoDtos.Parametrizacion.Sede();

        #region Validacion de zonas , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.ZonaCd objZonaCd)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objZonaCd.ZcdCdgo)) && (objZonaCd.ZcdRowidSde>0) 
                    )
                {
                    //Validar la llave relacional.
                    var ListaSede = await ObjSede.FiltrarSedeId(Convert.ToInt32(objZonaCd.ZcdRowidSde));

                    if (ListaSede == null || ListaSede.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {

                        //Validar que el codigo/Llave  No exista.
                        var ZonaCodigo = await ObjZonaCd.VerificarZonaCodigo(objZonaCd.ZcdCdgo);
                        if (ZonaCodigo == true)
                        {
                            //Retorna valor del TipoMensaje: CodigoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjZonaCd.ValidacionZonaNombreIngresar(objZonaCd);
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

        #region Validacion de zonas , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.ZonaCd objZonaCd)
        {

            int resultado = 0;
            try
            {
                int? Id = objZonaCd.ZcdRowid;
                if (Id > 0)
                {
                    //Validar que el codigo/Llave  exista.
                    var ZonaExiste = await ObjZonaCd.VerificarZonaId(objZonaCd.ZcdRowid);
                    if (ZonaExiste == false)
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

        #region Validacion de zonas , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.ZonaCd objZonaCd)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objZonaCd.ZcdCdgo)) && (objZonaCd.ZcdRowidSde > 0)
                    )
                {
                    //Validar la llave relacional.

                    var ZonaExiste = await ObjZonaCd.VerificarZonaId(objZonaCd.ZcdRowid);
                    if (ZonaExiste == false)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {

                        //Validar que el codigo/Llave  No exista.
                        var SedeExiste = await ObjSede.FiltrarSedeId(Convert.ToInt32(objZonaCd.ZcdRowidSde));
                        if (SedeExiste ==null || SedeExiste.Count==0)
                        {
                            //Retorna valor del TipoMensaje: CodigoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjZonaCd.ValidacionZonaNombreActualizar(objZonaCd);
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

        #region Validacion de zonas,  Validar Busquedas ( Filtros)
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

        #region Validacion de Zona, Validar Busquedas por IdSede ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdSede(int IdSede)
        {
            int resultado = 0;
            try
            {
                if (IdSede != null && IdSede > 0)
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
