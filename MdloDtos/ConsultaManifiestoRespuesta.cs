using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.RNDC
{
    public class ConsultaManifiestoRespuesta
    {
        public string placa { get; set; } = "";
        public string id_Conductor { get; set; } = "";
        public string id_Conductor2 { get; set; } = "";
        public string estado { get; set; } = "";
        // AC : Activo, Manifiesto de carga corresponde a un viaje en proceso
        // CE : Cerrado, Manifiesto de carga corresponde a un viaje terminado, ya se entregó la mercancía.
        // AN : Anulado, Manifiesto de carga no es válido porque se anuló.

        public string errorCode { get; set; } = "";

        public string errorText { get; set; } = "";

        public bool transaccionExitosa { get; set; } = false;
    }
}
