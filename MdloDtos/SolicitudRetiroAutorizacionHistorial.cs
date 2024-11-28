using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SolicitudRetiroAutorizacionHistorial
{
    [Key]
    [JsonPropertyName("IdSolicitudRetiroAutorizacionHistorial")]
    public int? SrahRowid { get; set; }

    [JsonPropertyName("IdSolicitudRetiroAutorizacion")]
    public int? SrahRowidSlctudRtroAutrzcion { get; set; }

    [JsonPropertyName("AutorizaKilos")]
    public int? SrahAutrzdoKlos { get; set; }

    [JsonPropertyName("AurtorizaUnidades")]
    public int? SrahAutrzdoUnddes { get; set; }

    [JsonPropertyName("Fecha")]
    public DateTime? SrahFcha { get; set; }

    [JsonPropertyName("CodigoUsuario")]
    public string? SraCdgoUsrio { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual SolicitudRetiroAutorizacion? SrahRowidSlctudRtroAutrzcionNavigation { get; set; } = null!;
}
