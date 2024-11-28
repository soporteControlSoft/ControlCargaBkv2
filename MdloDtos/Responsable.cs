using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Responsable
{
    //[Required(ErrorMessage = "Codigo de la Auditoria Modulo es requerido")]
    [Key]
    [JsonPropertyName("Id")]
    public int ReRowid { get; set; }

    [StringLength(60)]
    [JsonPropertyName("Nombre")]
    public string? ReNmbre { get; set; } = null!;

    [JsonPropertyName("Descripcion")]
    public string? ReDscrpcion { get; set; } = null!;

    [JsonPropertyName("FechaCreacion")]
    public DateTime ReFchaCrcion { get; set; }

    [JsonPropertyName("CodigoUsuario")]
    public string? ReCdgoUsrio { get; set; }

    [JsonPropertyName("Estado")]
    public bool ReActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? ReCdgoUsrioNavigation { get; set; }
}
