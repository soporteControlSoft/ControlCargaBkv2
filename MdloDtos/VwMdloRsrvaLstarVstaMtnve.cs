using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VwMdloRsrvaLstarVstaMtnve
{
    [Key]
    [JsonPropertyName("IdVisitaMotonave")]
    public int VmRowid { get; set; }

    [JsonPropertyName("CodigoMotonave")]
    public string VmMotonaveCdgo { get; set; } = null!;

    [JsonPropertyName("NombreMotonave")]
    public string? VmMotonaveNmbre { get; set; }

    [JsonPropertyName("Secuencia")]
    public short VmScncia { get; set; }

    [JsonPropertyName("CodigoCompaniaVisitaMotonave")]
    public string VmCdgoCia { get; set; } = null!;
}
