using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class CondicionFacturacion
{
    [Key]
    [Required(ErrorMessage = "Codigo Condicion facturacion es requerido")]
    [StringLength(5)]
    [JsonPropertyName("Codigo")]
    public string CfCdgo { get; set; } = null!;

    [StringLength(50)]
    [JsonPropertyName("Nombre")]
    public string? CfNmbre { get; set; }

    [StringLength(3)]
    [JsonPropertyName("Base")]
    public string? CfFchaBse { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();
}
