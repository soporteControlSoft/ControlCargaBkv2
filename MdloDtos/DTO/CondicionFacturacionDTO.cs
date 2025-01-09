using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class CondicionFacturacionDTO
{
    [Key]
    [Required(ErrorMessage = "Codigo Condicion facturacion es requerido")]
    [StringLength(5)]
    [JsonPropertyName("Codigo")]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; }

    [StringLength(3)]
    [JsonPropertyName("Base")]
    public string? Base { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();
}
