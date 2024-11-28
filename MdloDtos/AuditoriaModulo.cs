using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class AuditoriaModulo
{
    [Key]
    [Required(ErrorMessage = "Codigo de la Auditoria Modulo es requerido")]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string AmCdgo { get; set; } = null!;

    [StringLength(30)]
    [JsonPropertyName("Nombre")]
    public string? AmNmbre { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();
}
