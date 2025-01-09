using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class MotonaveDTO
{
    [Key]
    [Required(ErrorMessage = "Codigo de la motonave es requerido")]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string Codigo { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; }

    [JsonPropertyName("Eslra")]
    public decimal? Eslra { get; set; }

    [StringLength(10)]
    [JsonPropertyName("Mtrcla")]
    public string? Mtrcla { get; set; }

    [StringLength(20)]
    [JsonPropertyName("MoBndra")]
    public string? MoBndra { get; set; }

    [JsonPropertyName("CantidadEscotillas")]
    public short? CantidadEscotillas { get; set; }

    [JsonPropertyName("Calado")]
    public decimal? Calado { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();
}
