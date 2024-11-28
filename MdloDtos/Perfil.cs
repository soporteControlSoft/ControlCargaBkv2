using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Perfil
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string PeCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(40)]
    public string? PeNmbre { get; set; }

    public string? PePrmsos { get; set; }

    [JsonPropertyName("Estado")]
    public bool? PeActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<PerfilUsuario> PerfilUsuarios { get; set; } = new List<PerfilUsuario>();
}
