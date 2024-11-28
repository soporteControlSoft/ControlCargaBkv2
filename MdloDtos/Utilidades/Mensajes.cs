using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.Utilidades
{
    /// <summary>
    /// Clases para manejar el modulo de auditoria.
    /// </summary>
    public static class Mensajes
    {

        //
        public const string Exito = "Exito en el ";
        public const string Error = "Error en el ";

        /// <summary>
        /// Mensaje utilizado para la operacion dentro de la acaptura de errores.
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <returns></returns>
        public static string MensajeOperacion(int Mensaje)
        {
            string respuesta = "";
            switch (Mensaje)
            {
                case 1:
                    respuesta = "El código existe en el sistema de información. ¿verifique el ingreso de los datos?";
                    break;
                case 2:
                    respuesta = "la relacion no existe en el sistema de información. ¿Verifique el ingreso de los datos? ";
                    break;
                case 3:
                    respuesta = "No se aceptan valores nulos.¿Verifique el ingreso de los datos?";
                    break;
                case 4:
                    respuesta = "El tipo de datos ingresado es incorrecto. ¿verifique el ingreso de los datos?";
                    break;
                case 5:
                    respuesta = "Error en la transaccion. ¿verifique la conexion?";
                    break;
                case 6:
                    respuesta = "Transaccion exitosa";
                    break;
                case 7:
                    respuesta = "Nombre existe, verifique.";
                    break;
                case 8:
                    respuesta = "Hay relaciones Foraneas.";
                    break;
                case 9:
                    respuesta = "Ya existe un documento cargado en el sistema.";
                    break;
                case 10:
                    respuesta = "El documento ya cambió de estado, no se encuentra en estado de cargado.";
                    break;
                case 11:
                    respuesta = "Algunos Bls ya están asociado a un deposito, valide datos.";
                    break;
                case 12:
                    respuesta = "Los Bls asociados deben tener el mismo producto, valide datos.";
                    break;
                case 13:
                    respuesta = "El certificado del producto no se encuentra vigente, valide datos.";
                    break;
                default:
                    break;
            }
            return respuesta;
        }

        /// <summary>
        /// Mensaje utilizado para la operacion dentro del metodo.
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static string MensajeRespuesta(int operacion)
        {
            string respuesta = "";
            switch (operacion)
            {
                case 1:
                    respuesta = MdloDtos.Utilidades.Mensajes.Error + "" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString() ;
                    break;
                case 2:
                    respuesta = MdloDtos.Utilidades.Mensajes.Error + "" + MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion.ToString();
                    break;
                case 3:
                    respuesta = MdloDtos.Utilidades.Mensajes.Error + "" + MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta.ToString();
                    break;
                case 4:
                    respuesta = MdloDtos.Utilidades.Mensajes.Error + "" + MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion.ToString();
                    break;

                default:
                    break;
            }
            return respuesta;
        }
    }
}
