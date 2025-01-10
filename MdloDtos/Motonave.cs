using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Motonave
{
    [Key]
    [Required(ErrorMessage = "Codigo de la motonave es requerido")]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string MoCdgo { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Nombre")]
    public string? MoNmbre { get; set; }

    [JsonPropertyName("Eslra")]
    public decimal? MoEslra { get; set; }

    [StringLength(10)]
    [JsonPropertyName("Mtrcla")]
    public string? MoMtrcla { get; set; }

    [JsonPropertyName("MoBndra")]
    [StringLength(20)]
    public string? MoBndra { get; set; }

    [JsonPropertyName("CantidadEscotillas")]
    public short? MoCntdadEsctllas { get; set; }

    [JsonPropertyName("Calado")]
    public decimal? MoCldo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();
}
