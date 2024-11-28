using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class AuditoriaMotivo
{
    [Key]
    [Required(ErrorMessage = "Codigo de la Auditoria Motivo es requerido")]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string AmCdgo { get; set; } = null!;

    [StringLength(15)]
    [JsonPropertyName("Nombre")]
    public string AmDscrpcion { get; set; } = null!;

    [JsonPropertyName("RequierePedirRazon")]
    public bool? AmRqrePdirRzon { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();
}
