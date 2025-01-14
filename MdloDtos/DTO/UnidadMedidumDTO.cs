using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class UnidadMedidumDTO
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string Codigo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(45)]
    public string? Nombre { get; set; } = null!;

    [JsonPropertyName("EsGranel")]
    public bool? EsGranel { get; set; }

    [JsonPropertyName("Activo")]
    public bool? Activo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuariaDetalle> SituacionPortuariaDetalles { get; set; } = new List<SituacionPortuariaDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl> VisitaMotonaveBls { get; set; } = new List<VisitaMotonaveBl>();
}
