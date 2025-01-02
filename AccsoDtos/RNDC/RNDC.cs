using MdloDtos.RNDC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.RNDC
{
    public class RNDC : MdloDtos.IModelos.IRNDC
    {
        public async Task<MdloDtos.RNDC.ConsultaManifiestoRespuesta> validarManifiesto(string idManifiesto, string nitEmpresaTransporte) {

            // Credenciales de acceso
            string usuario = "WEB_SERVICEINSIDE@6155";
            string clave = "Web_Services23";

            // Respuesta del manifiesto
            MdloDtos.RNDC.ConsultaManifiestoRespuesta manifiesto_Respuesta = new MdloDtos.RNDC.ConsultaManifiestoRespuesta();

            // Configuración de acceso
            Acceso acceso = new Acceso()
            {
                usuario = usuario,
                clave = clave
            };

            // Configuración de la solicitud
            Solicitud solicitud = new Solicitud(){
                tipo = TipoOperacionRNDC.TIPO_OPER_RNDC_CONSULTAR_MANIFIESTO,
                procesoid = IdProcesoRNDC.ID_MANIFIESTO
            };

            // Documento del manifiesto
            Documento manifiesto = new Documento()
            {
                ingresoid = idManifiesto,
                numNitEmpresaTransporte = nitEmpresaTransporte
            };

            // Creación de la consulta del manifiesto
            ConsultaManifiesto cmanifiesto = new ConsultaManifiesto()
            {
                acceso = acceso,
                solicitud = solicitud,
                documento = manifiesto
            };

            // Configuración del cliente RNDC
            ClienteRNDC rNDC = new ClienteRNDC();
            rNDC.URL = "https://rndcws2.mintransporte.gov.co/rest/";

            // Ejecución de la consulta
            ConsultaManifiestoRespuesta consultaManifiestoRespuesta = rNDC.ConsultarManifiesto(cmanifiesto, manifiesto_Respuesta);
            return consultaManifiestoRespuesta;
        }
    }
}
