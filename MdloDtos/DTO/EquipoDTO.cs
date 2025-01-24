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
    public class EquipoDTO
    {
        [Key]
        [JsonPropertyName("Id")]
        public int EqRowid { get; set; }

        [StringLength(40)]
        [JsonPropertyName("codigoEquipo")]
        public string? EqCdgo { get; set; } = null!;

        [StringLength(60)]
        [JsonPropertyName("Nombre")]
        public string? EqNmbre { get; set; } = null!;

        [StringLength(255)]
        [JsonPropertyName("Descripcion")]
        public string? EqDscrpcion { get; set; } = null!;

        [JsonPropertyName("FechaCreacion")]
        public DateTime? EqFchaCrcion { get; set; }

        [StringLength(15)]
        [JsonPropertyName("CodigoUsuario")]
        public string? EqCdgoUsrio { get; set; }

        [JsonPropertyName("Estado")]
        public bool EqActvo { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Usuario? EqCdgoUsrioNavigation { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    }
}
