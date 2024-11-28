using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Pai
{
    [Key]
    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string PaCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(30)]
    public string? PaNmbre { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    public Pai()
    {

        //  this.PaCdgo = PaCdgo;

    }
}
