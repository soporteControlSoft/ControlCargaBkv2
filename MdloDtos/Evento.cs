using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Evento
{
    [Key]
    [JsonPropertyName("IdEvento")]
    public int EvRowid { get; set; }

    [JsonPropertyName("Nombre")]
    [StringLength(60)]
    public string? EvNmbre { get; set; } = null!;

    [JsonPropertyName("Observacion")]
    [StringLength(2)]
    public string? EvObsrvcion { get; set; } = null!;

    [JsonPropertyName("FechaCreacion")]
    public DateTime? EvFchaCrcion { get; set; }

    [JsonPropertyName("FechaInicio")]
    [StringLength(2)]
    public string? EvFchaIncio { get; set; } = null!;

    [JsonPropertyName("FechaFin")]
    [StringLength(2)]
    public string? EvFchaFin { get; set; } = null!;

    [JsonPropertyName("Escotilla")]
    [StringLength(2)]
    public string? EvEsctlla { get; set; } = null!;

    [JsonPropertyName("CodigoClasificacion")]
    public int EvRowidClsfccion { get; set; }

    [JsonPropertyName("CodigoResponsable")]
    public int EvRowidRspnsble { get; set; }

    [JsonPropertyName("Equipo")]
    [StringLength(2)]
    public string? EvEqpo { get; set; } = null!;

    [StringLength(15)]
    [JsonPropertyName("CodigoUsuario")]
    public string? EvCdgoUsrio { get; set; }

    [JsonPropertyName("Estado")]
    public bool? EvActvo { get; set; }

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
