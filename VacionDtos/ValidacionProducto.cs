using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los productos
    /// </summary>
    public class ValidacionProducto
    {
        AccsoDtos.Parametrizacion.Producto ObjProducto = new AccsoDtos.Parametrizacion.Producto(null);

        #region Validacion de Producto , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.ProductoDTO objProducto)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objProducto.PrCdgo) && (!string.IsNullOrEmpty(objProducto.PrNmbre)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var ProductoExiste = await ObjProducto.VerificarProducto(objProducto.PrCdgo);
                    if (ProductoExiste == true)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        var NombreExiste = ObjProducto.ValidacionProductoNombreIngresar(objProducto.PrNmbre);
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
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Producto , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Producto objProducto_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objProducto_.PrCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var ProductoExiste = await ObjProducto.VerificarProducto(objProducto_.PrCdgo);
                    if (ProductoExiste == false)
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

        #region Validacion de Producto , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.ProductoDTO objProducto)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objProducto.PrCdgo) && (!string.IsNullOrEmpty(objProducto.PrNmbre)))
                {
                    //Validar que el codigo/Llave No exista.
                    var ProductoExiste = await ObjProducto.VerificarProducto(objProducto.PrCdgo);
                    if (ProductoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        var NombreExiste = ObjProducto.ValidacionProductoNombreActualizar(objProducto);
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

        #region Validacion de Producto Validar Busquedas ( Filtros)
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
