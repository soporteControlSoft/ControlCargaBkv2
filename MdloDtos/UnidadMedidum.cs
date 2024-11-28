using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class UnidadMedidum
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string UmCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(45)]
    public string? UmNmbre { get; set; } = null!;

    [JsonPropertyName("EsGranel")]
    public bool? UmGrnel { get; set; }

    [JsonPropertyName("Activo")]
    public bool? UmActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuariaDetalle> SituacionPortuariaDetalles { get; set; } = new List<SituacionPortuariaDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl> VisitaMotonaveBls { get; set; } = new List<VisitaMotonaveBl>();
}
