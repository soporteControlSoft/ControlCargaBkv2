using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VwMdloRsrvaLstarDpsto
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int DeRowid { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string DeCia { get; set; } = null!;

    [JsonPropertyName("CodigoDeposito")]
    public string DeCdgo { get; set; } = null!;

    [JsonPropertyName("EsSubdeposito")]
    public bool DeEsSubdpsto { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int VmRowid { get; set; }
}
