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
    public class SectorDTO
    {
        [Key]
        [JsonPropertyName("IdSector")]
        public int SeRowid { get; set; }

        [JsonPropertyName("IdCodigoSector")]
        [StringLength(15)]
        public string SeCdgo { get; set; } = null!;

        [JsonPropertyName("IdNombreSector")]
        [StringLength(20)]
        public string SeNmbre { get; set; } = null!;

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<SectorEvento> SectorEventos { get; set; } = new List<SectorEvento>();
    }
}
