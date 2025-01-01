using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccsoDtos.DTO;

public partial class ConductorDTO
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Identificacion")]
    public string CnIdntfccion { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Nombre")]
    public string CnNmbre { get; set; } = null!;

    //[JsonPropertyName("Imagen")]
    //public byte[]? CnFeatures { get; set; }

    [JsonPropertyName("Imagen")]
    public string? ImagenBase64 { get; set; }

    [NotMapped]
    public byte[]? CnFeatures
    {
        get
        {
            return string.IsNullOrEmpty(ImagenBase64) ? null : Convert.FromBase64String(ImagenBase64);
        }
    }



    [StringLength(10)]
    [JsonPropertyName("Vehiculo")]
    public string? CnVhclo { get; set; }

    [JsonPropertyName("IdTransportadora")]
    public int? CnRowidTrnsprtdra { get; set; }

    [JsonPropertyName("FechaRegistro")]
    public DateTime CnFchaRgstro { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoUsuarioEnrolo")]
    public string? CnCdgoUsrioEnrlo { get; set; }

    [JsonPropertyName("FechaEnrolamiento")]
    public DateTime? CnFchaEnrlmnto { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Movil")]
    public string? CnMvil { get; set; }

    [StringLength(15)]
    [JsonPropertyName("NumeroLicencia")]
    public string? CnNmroLcncia { get; set; }

    [StringLength(15)]
    [JsonPropertyName("TipoLicencia")]
    public string? CnTpoLcncia { get; set; }

    [JsonPropertyName("FechaVencimientoLcncia")]
    public DateTime? CnFchaVncmntoLcncia { get; set; }

    [JsonPropertyName("Activo")]
    public bool? CnActvo { get; set; }

    [JsonPropertyName("Urbano")]
    public bool? CnUrbno { get; set; }

    [NotMapped]
    public virtual MdloDtos.Tercero? CnRowidTrnsprtdraNavigation { get; set; }
}
