using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class PeriodoFacturacion
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string? PfCdgo { get; set; } = null!;

    [StringLength(50)]
    [JsonPropertyName("Nombre")]
    public string? PfNmbre { get; set; }

    [JsonPropertyName("Dias")]
    public short PfDias { get; set; }

    [JsonPropertyName("Promedio")]
    public bool? PfPrmdio { get; set; }

    [JsonPropertyName("CodigoErp")]
    [StringLength(20)]
    public string? PfCdgoErp { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();
}
