using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class EstadoMotonave
{
    [Key]
    [JsonPropertyName("Codigo")]
    [DataType(DataType.Text)]
    public string? EmCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [DataType(DataType.Text)]
    public string? EmNmbre { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();
}
