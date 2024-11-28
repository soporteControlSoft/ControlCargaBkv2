using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SolicitudRetiroTransportadoraHistorial
{
    [Key]
    [JsonPropertyName("Id")]
    public int? SrthRowid { get; set; }

    [JsonPropertyName("Fecha")]
    public DateTime? SrthFcha { get; set; }

    [JsonPropertyName("SolicitudRetiroTrasnportadora")]
    public int? SrthRowidSlctudRtroTrnsprtdra { get; set; }

    [JsonPropertyName("Autorizakilos")]
    public int? SrthAutrzdoKlos { get; set; }

    [JsonPropertyName("AutorizaUnidades")]
    public int? SrthAutrzdoUnddes { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual SolicitudRetiroTransportadora? SrthRowidSlctudRtroTrnsprtdraNavigation { get; set; } = null!;
}
