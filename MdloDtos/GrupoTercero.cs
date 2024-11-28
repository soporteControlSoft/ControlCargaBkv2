using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class GrupoTercero
{
    [Key]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string GtCdgo { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Descripcion")]
    public string? GtDscrpcion { get; set; }

    [JsonPropertyName("Estado")]
    public bool? GtActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();
}
