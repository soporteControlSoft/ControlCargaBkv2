using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class EstadoMotonaveDTO
{
    [Key]
    [JsonPropertyName("Codigo")]
    [DataType(DataType.Text)]
    public string? Codigo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [DataType(DataType.Text)]
    public string? Nombre { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();
}
