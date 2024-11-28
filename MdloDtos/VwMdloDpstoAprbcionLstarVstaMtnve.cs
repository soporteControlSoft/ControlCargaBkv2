using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VwMdloDpstoAprbcionLstarVstaMtnve
{

    [JsonPropertyName("IdVisitaMotonave")]
    public int? VmRowid { get; set; }

    [JsonPropertyName("CodigoMotonave")]
    public string? VmMotonaveCdgo { get; set; } = null!;

    [JsonPropertyName("NombreMotonave")]
    public string? VmMotonaveNmbre { get; set; }

    [JsonPropertyName("Secuencia")]
    public short? VmScncia { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? VmCdgoCia { get; set; } = null!;
}
