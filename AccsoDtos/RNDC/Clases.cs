using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.ImplementacionRNDC
{
    // Constantes relacionadas con las operaciones del RNDC
    public class TipoOperacionRNDC
    {
        public const string TIPO_OPER_RNDC_REGISTRAR_INFO = "1";
        public const string TIPO_OPER_RNDC_CONSULTAR_MAESTROS = "2";
        public const string TIPO_OPER_RNDC_CONSULTAR_PROCESOS = "3";
        public const string TIPO_OPER_RNDC_CONSULTAR_MANIFIESTO = "8";
    }

    // Constantes relacionadas con los procesos del RNDC
    public class IdProcesoRNDC
    {
        public const string ID_REMESA = "3";
        public const string ID_MANIFIESTO = "4";
    }

    // Modelo para la consulta de manifiestos
    public class ConsultaManifiesto
    {
        public Acceso acceso { get; set; } = new Acceso();
        public Solicitud solicitud { get; set; } = new Solicitud();
        public Documento documento { get; set; } = new Documento();
    }

    // Respuesta de la consulta de manifiestos
    public class ConsultaManifiestoRespuesta
    {
        public string placa { get; set; } = "";
        public string id_Conductor { get; set; } = "";
        public string id_Conductor2 { get; set; } = "";
        public string estado { get; set; } = "";
        // AC : Activo, Manifiesto de carga corresponde a un viaje en proceso
        // CE : Cerrado, Manifiesto de carga corresponde a un viaje terminado, ya se entregó la mercancía.
        // AN : Anulado, Manifiesto de carga no es válido porque se anuló.
    }

    // Datos de acceso
    public class Acceso
    {
        public string usuario { get; set; } = "";
        public string clave { get; set; } = "";
        public string rien { get; set; } = "";
    }

    // Detalles de la solicitud
    public class Solicitud
    {
        public string tipo { get; set; } = "";
        public string procesoid { get; set; } = "";
    }

    // Información del documento
    public class Documento
    {
        public string ingresoid { get; set; } = "";
        public string numNitEmpresaTransporte { get; set; } = "";
    }

}
