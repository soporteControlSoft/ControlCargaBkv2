using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccsoDtos.ImplementacionRNDC
{
    public class ClienteRNDC
    {
        public string URL { get; set; }

        /// <summary>
        /// Consulta un manifiesto en el sistema RNDC.
        /// </summary>
        /// <param name="consulta">Los datos de la consulta a enviar.</param>
        /// <param name="respuesta_Manifiesto">Referencia para almacenar la respuesta del manifiesto.</param>
        /// <param name="errorCode">Código de error en caso de fallo.</param>
        /// <param name="errorText">Texto descriptivo del error en caso de fallo.</param>
        /// <returns>True si la consulta es exitosa, de lo contrario False.</returns>
        public bool ConsultarManifiesto(
            ConsultaManifiesto consulta,
            ref ConsultaManifiestoRespuesta respuesta_Manifiesto,
            ref string errorCode,
            ref string errorText)
        {
            // Serializar el objeto de consulta a JSON
            string cadenaJson = JsonSerializer.Serialize(consulta);
            Console.WriteLine(cadenaJson);
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
                        errorCode = "-1";
                        errorText = "No Encontrado";
                        return false;
                    }

                    // Mapear los datos al objeto respuesta
                    respuesta_Manifiesto.placa = (string)datos[0]["NUMPLACA"];
                    respuesta_Manifiesto.id_Conductor = (string)datos[0]["NUMIDCONDUCTOR"];
                    respuesta_Manifiesto.id_Conductor2 = (string)datos[0]["NUMIDCONDUCTOR2"];
                    respuesta_Manifiesto.estado = (string)datos[0]["ESTADO"];
                    return true;
                }

                // Manejo de error si la solicitud falla
                errorCode = "-1";
                errorText = "Error al procesar la solicitud";
                return false;
            }
        }
    }
}
