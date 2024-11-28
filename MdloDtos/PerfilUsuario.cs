using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class PerfilUsuario
{
    [Key]
    [JsonPropertyName("IdPerfilUsuario")]
    public int? PuRowid { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoCompania")]
    public string PuCdgoCia { get; set; } = null!;

    [StringLength(15)]
    [JsonPropertyName("CodigoPerfil")]
    public string? PuCdgoPrfil { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoUsuario")]
    public string? PuCdgoUsrio { get; set; }

    [JsonPropertyName("Estado")]
    public bool? PuActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? PuCdgoCiaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Perfil? PuCdgoPrfilNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? PuCdgoUsrioNavigation { get; set; }
}
