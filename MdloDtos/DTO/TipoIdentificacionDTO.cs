using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class TipoIdentificacionDTO
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string Codigo { get; set; } = null!;

    [StringLength(30)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();
}
