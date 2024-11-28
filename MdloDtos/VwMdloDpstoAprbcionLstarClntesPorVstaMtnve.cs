using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VwMdloDpstoAprbcionLstarClntesPorVstaMtnve
{
    [JsonPropertyName("IdVisitaMotonave")]
    public int VmRowid { get; set; }

    [JsonPropertyName("IdTercero")]
    public int TeRowid { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string TeCdgo { get; set; } = null!;

    [JsonPropertyName("NombreTercero")]
    public string? TeNmbre { get; set; }
}
