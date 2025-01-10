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
    public class EventoDTO
    {
        [Key]
        public int IdEvento { get; set; }

        [StringLength(60)]
        public string? Nombre { get; set; } = null!;

        [StringLength(2)]
        public string? Observacion { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }

        [StringLength(2)]
        public string? FechaInicio { get; set; } = null!;

        [StringLength(2)]
        public string? FechaFin { get; set; } = null!;

        [StringLength(2)]
        public string? Escotilla { get; set; } = null!;
        public int CodigoClasificacion { get; set; }

        public int CodigoResponsable { get; set; }

        [StringLength(2)]
        public string? Equipo { get; set; } = null!;

        [StringLength(15)]
        public string? CodigoUsuario { get; set; }

        public bool? Estado { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();

        [JsonIgnore]
        [NotMapped]
        public virtual Usuario? EvCdgoUsrioNavigation { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Clasificacion? EvRowidClsfccionNavigation { get; set; } = null!;

        [JsonIgnore]
        [NotMapped]
        public virtual Responsable? EvRowidRspnsbleNavigation { get; set; } = null!;

    }
}
