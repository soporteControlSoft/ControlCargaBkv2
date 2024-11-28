using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class CausalCancelacion
{
    [Key]
    [Required(ErrorMessage = "Codigo de la Causal Cancelacion es requerido")]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string CcCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(100)]
    public string? CcDscrpcion { get; set; }

    [JsonPropertyName("Origen")]
    [StringLength(1)]
    public string? CcOrgen { get; set; }
}
