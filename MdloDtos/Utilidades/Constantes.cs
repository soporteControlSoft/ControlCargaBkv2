using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.Utilidades
{
    /// <summary>
    /// Clase para el manejo de los permisos del Back.
    /// </summary>
    public static class Constantes
    {
        //Constantes para los Catalogos.
        public const string id_Catalogo_Tercero= "catTercero";
        public const string id_Catalogo_PuertoOrigen = "catPuertoOrigen";
        public const string id_Catalogo_TipoIdentificacion = "catTipoIdentificacion";
        public const string id_Catalogo_Pais = "catPais";
        //Constantes para los menus.
        //por definir menus. menTercero




        //Enum para el mensaje de retorno de los servicios. CRUD (Operaciones) 
        public enum TipoOperacion
        {
            Ingreso=1,
            Actualizacion=2,
            Consulta=3,
            Eliminacion=4,
            Inactivar=5
        }

        /// <summary>
        /// Enum para CRUD  , se utiliza para las validaciones antes del consumo de c/u de los servicios
        /// </summary>
        public enum TipoMensaje
        {
            CodigoExiste = 1,
            RelacionNoExiste = 2,
            NoAceptaValoresNull = 3,
            TipoDatoIncorrecto = 4,
            TransaccionIncorrecta = 5,
            TransaccionExitosa = 6,
            NombreExiste=7,
            HayRelacionesForaneas = 8,
            DocumentoExistente =9,
            DocumentoAprobado = 10,
            BLsNoDisponible = 11,
            BLsProductosDiferentes = 12,
            CertificadoTerceroNoVigente = 13

        }


        //párametro para los dias de cambio de la clave
        public const int parametroCambioClave = 30;
        public const int CambioClave = 5;
        //se utiliza para el retorno de los mensajes de c/u de los servicios
        public const int RetornoExito = 1;
        public const int RetornoError = 0;

        /*public enum TipoTercero
        {
            Cliente=1,
            Particular=2,

        }*/

    }
}
