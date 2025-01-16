using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class PuertoOrigenDTO
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string PoCdgo { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Descripcion")]
    public string? PoDscrpcion { get; set; }

    [JsonPropertyName("Estado")]
    public bool? PoActvo { get; set; }
}
