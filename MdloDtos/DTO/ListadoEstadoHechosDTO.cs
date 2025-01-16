using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    /// <summary>
    /// DTO Clasificaciom, Estado de hechos
    /// Jesus alberto calzada
    /// </summary>
    public class ListadoEstadoHechosDTO
    {

        public string SpCdgoMtnve { get; set; } = null!;

        public int SpRowid { get; set; }

        public DateTime? SpFchaArrbo { get; set; }

        public DateTime? SpFchaAtrque { get; set; }

        public DateTime? SpFchaZrpe { get; set; }

        public DateTime? SpFchaCrcion { get; set; }

        public string SpCdgoEstdoMtnve { get; set; } = null!;

        public int? VmRowid { get; set; }

        public short VmScncia { get; set; }

        public string VmDscrpcion { get; set; } = null!;

        public short? MoCntdadEsctllas { get; set; }

        public string EmCdgo { get; set; } = null!;

        public string EmNmbre { get; set; } = null!;

    }
}
