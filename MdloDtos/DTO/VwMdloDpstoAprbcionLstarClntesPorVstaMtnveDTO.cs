using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VwMdloDpstoAprbcionLstarClntesPorVstaMtnveDTO
{
    [JsonPropertyName("IdVisitaMotonave")]
    public int IdVisitaMotonave { get; set; }

    [JsonPropertyName("IdTercero")]
    public int IdTercero { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string CodigoTercero { get; set; } = null!;

    [JsonPropertyName("NombreTercero")]
    public string? NombreTercero { get; set; }
}
