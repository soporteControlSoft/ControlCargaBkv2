using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Clasificacion
{
    [Key]
    [JsonPropertyName("Id")]
    public int ClRowid { get; set; }

    [StringLength(60)]
    [JsonPropertyName("Nombre")]
    public string? ClNmbre { get; set; } = null!;

    [StringLength(255)]
    [JsonPropertyName("Descripcion")]
    public string? ClDscrpcion { get; set; } = null!;

    [JsonPropertyName("FechaCreacion")]
    public DateTime? ClFchaCrcion { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoUsuario")]
    public string? ClCdgoUsrio { get; set; }

    [JsonPropertyName("Estado")]
    public bool ClActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? ClCdgoUsrioNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
