using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class ConductorDTO
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Identificacion")]
    public string Identificacion { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; } = null!;

    [JsonPropertyName("Imagen")]
    public byte[]? Imagen { get; set; }
   
    [StringLength(10)]
    [JsonPropertyName("Vehiculo")]
    public string? Vehiculo { get; set; }

    [JsonPropertyName("IdTransportadora")]
    public int? IdTransportadora { get; set; }

    [JsonPropertyName("FechaRegistro")]
    public DateTime FechaRegistro { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoUsuarioEnrolo")]
    public string? CodigoUsuarioEnrolo { get; set; }

    [JsonPropertyName("FechaEnrolamiento")]
    public DateTime? FechaEnrolamiento { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Movil")]
    public string? Movil { get; set; }

    [StringLength(15)]
    [JsonPropertyName("NumeroLicencia")]
    public string? NumeroLicencia { get; set; }

    [StringLength(15)]
    [JsonPropertyName("TipoLicencia")]
    public string? TipoLicencia { get; set; }

    [JsonPropertyName("FechaVencimientoLcncia")]
    public DateTime? FechaVencimientoLcncia { get; set; }

    [JsonPropertyName("Activo")]
    public bool? Activo { get; set; }

    [JsonPropertyName("Urbano")]
    public bool? Urbano { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual MdloDtos.Tercero? CnRowidTrnsprtdraNavigation { get; set; }


}
