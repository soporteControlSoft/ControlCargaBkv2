using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class TipoIdentificacion
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string TiCdgo { get; set; } = null!;

    [StringLength(30)]
    [JsonPropertyName("Nombre")]
    public string? TiNmbre { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();
}
