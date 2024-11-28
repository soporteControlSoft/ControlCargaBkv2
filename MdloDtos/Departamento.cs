using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Departamento
{
    [Key]
    [JsonPropertyName("IdDepartamento")]
    public int? DeRowid { get; set; }

    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    [DataType(DataType.Text)]
    public string? DeCdgo { get; set; } = null!;

    [StringLength(40)]
    [JsonPropertyName("Nombre")]
    [DataType(DataType.Text)]
    public string? DeNmbre { get; set; }

    [StringLength(15)]
    [JsonPropertyName("IdPais")]
    [DataType(DataType.Text)]
    public string? DeCdgoPais { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    [JsonIgnore]
    [NotMapped]
    public virtual Pai? DeCdgoPaisNavigation { get; set; }

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? PaisCodigo { get; set; }



    [NotMapped]
    public string? PaisNombre { get; set; }

    public Departamento()
    {

    }

    public Departamento(
                        int? DeRowid,
                        string? DeCdgo,
                        string? DeNmbre,
                        string? DeCdgoPais,

                        string? PaisCodigo,
                        string? PaisNombre
                        )
    {
        this.DeRowid = DeRowid;
        this.DeCdgo = DeCdgo;
        this.DeNmbre = DeNmbre;
        this.DeCdgoPais = DeCdgoPais;
        this.PaisCodigo = PaisCodigo;
        this.PaisNombre = PaisNombre;
    }
}
