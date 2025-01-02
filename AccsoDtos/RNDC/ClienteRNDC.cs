using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using MdloDtos.RNDC;

namespace AccsoDtos.RNDC
{
    public class ClienteRNDC
    {
        public string URL { get; set; }

        /// <summary>
        /// Consulta un manifiesto en el sistema RNDC.
        /// </summary>
        /// <param name="consulta">Los datos de la consulta a enviar.</param>
        /// <param name="respuesta_Manifiesto">Referencia para almacenar la respuesta del manifiesto.</param>
        /// <returns>ConsultaManifiestoRespuesta</returns>
        public MdloDtos.RNDC.ConsultaManifiestoRespuesta ConsultarManifiesto(
            ConsultaManifiesto consulta,
            ConsultaManifiestoRespuesta respuesta_Manifiesto
            )
        {
            // Serializar el objeto de consulta a JSON
            string cadenaJson = JsonSerializer.Serialize(consulta);
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                // Configurar el contenido de la solicitud
                var requestContent = new StringContent(cadenaJson, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST de manera síncrona
                var postTask = client.PostAsync("rndc", requestContent);
                postTask.Wait();

                var result = postTask.Result;

                // Procesar la respuesta de la solicitud
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    JsonDocument doc = JsonDocument.Parse(readTask.Result);

                    JsonNode respuesta = JsonNode.Parse(readTask.Result)!;

                    // Extraer los datos del nodo "result"
                    JsonArray datos = (JsonArray)respuesta["result"];

                    if (datos.Count == 0)
                    {
                        respuesta_Manifiesto.errorCode = "-1";
                        respuesta_Manifiesto.errorText = "No Encontrado";
                        respuesta_Manifiesto.transaccionExitosa = false;
                    }
                    else
                    {
                        respuesta_Manifiesto.placa = (string)datos[0]["NUMPLACA"];
                        respuesta_Manifiesto.id_Conductor = (string)datos[0]["NUMIDCONDUCTOR"];
                        respuesta_Manifiesto.id_Conductor2 = (string)datos[0]["NUMIDCONDUCTOR2"];
                        respuesta_Manifiesto.estado = (string)datos[0]["ESTADO"];
                        respuesta_Manifiesto.transaccionExitosa = true;
                    }
                }
                else 
                {
                    respuesta_Manifiesto.errorCode = "-1";
                    respuesta_Manifiesto.errorText = "Error al procesar la solicitud";
                    respuesta_Manifiesto.transaccionExitosa = false;
                }
                return respuesta_Manifiesto;
            }
        }
    }
}
