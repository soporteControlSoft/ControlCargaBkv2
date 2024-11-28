using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class TerminalMaritimo
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string TmCdgo { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Descripcion")]
    public string? TmDscrpcion { get; set; }

    [JsonPropertyName("Estado")]
    public bool? TmActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();
}
