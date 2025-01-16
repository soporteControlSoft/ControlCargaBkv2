using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class PeriodoFacturacionDTO
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string? Codigo { get; set; } = null!;

    [StringLength(50)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; }

    [JsonPropertyName("Dias")]
    public short Dias { get; set; }

    [JsonPropertyName("Promedio")]
    public bool? Promedio { get; set; }

    [JsonPropertyName("CodigoErp")]
    [StringLength(20)]
    public string? CodigoErp { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();
}
