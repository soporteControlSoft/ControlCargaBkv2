using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VwMdloRsrvaLstarDpstoDTO
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int IdDeposito { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string CodigoCompania { get; set; } = null!;

    [JsonPropertyName("CodigoDeposito")]
    public string CodigoDeposito { get; set; } = null!;

    [JsonPropertyName("EsSubdeposito")]
    public bool EsSubdeposito { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int IdVisitaMotonave { get; set; }
}
