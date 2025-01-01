using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VwMdloRsrvaLstarSlctudRtroMdal
{
    [Key]
    [JsonPropertyName("IdSolicitdRetiro")]
    public int SrRowid { get; set; }

    [JsonPropertyName("CodigoCompaniaSolicitdRetiro")]
    public string SrCia { get; set; } = null!;

    [JsonPropertyName("CodigoSolicitudRetiro")]
    public string SrCdgo { get; set; } = null!;

    [JsonPropertyName("IdDeposito")]
    public int DeRowid { get; set; }

    [JsonPropertyName("CodigoCompaniaDeposito")]
    public string DeCia { get; set; } = null!;

    [JsonPropertyName("CodigoDeposito")]
    public string DeCdgo { get; set; } = null!;

    [JsonPropertyName("Estado")]
    public string DeEstdo { get; set; } = null!;

    [JsonPropertyName("IdTransportadora")]
    public int SrtRowidTrnsprtdra { get; set; }

    [JsonPropertyName("AutorizadoKilos")]
    public int? SrtAutrzdoKlos { get; set; }

    [JsonPropertyName("AutorizadoUnidades")]
    public int? SrtAutrzdoUnddes { get; set; }

    [JsonPropertyName("DespachadoKilos")]
    public int? SrtDspchdoKlos { get; set; }

    [JsonPropertyName("DespachadoUnidades")]
    public int? SrtDspchdoUnddes { get; set; }

    [JsonPropertyName("EstadoSolicitudRetiro")]
    public bool? SrtActva { get; set; }
}
