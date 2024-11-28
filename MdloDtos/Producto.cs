using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Producto
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string PrCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(40)]
    public string? PrNmbre { get; set; }

    [JsonPropertyName("Estado")]
    public bool? PrActvo { get; set; }

    [JsonPropertyName("Empaque")]
    public bool? PrSlctarEmpque { get; set; }

    [JsonPropertyName("CodigoErp")]
    [StringLength(20)]
    public string? PrCdgoErp { get; set; }

    [JsonPropertyName("EsSustanciaControlada")]
    public bool? PrSstnciaCntrlda { get; set; }

    [JsonPropertyName("DepositoNavegacion")]
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();

    [JsonPropertyName("SituacionPortuariaDetallesNavegacion")]
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuariaDetalle> SituacionPortuariaDetalles { get; set; } = new List<SituacionPortuariaDetalle>();

    [JsonPropertyName("TerceroCertificadoNavegacion")]
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<TerceroCertificado> TerceroCertificados { get; set; } = new List<TerceroCertificado>();
}
