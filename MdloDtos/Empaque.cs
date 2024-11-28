using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Empaque
{
    [Key]
    [JsonPropertyName("IdEmpaque")]
    public int? EmRowid { get; set; }

    [JsonPropertyName("CodigoCompania")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? EmCdgoCia { get; set; }

    [JsonPropertyName("Codigo")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? EmCdgo { get; set; } = null!;

    [DataType(DataType.Text)]
    [StringLength(50)]
    [JsonPropertyName("Nombre")]
    public string? EmNmbre { get; set; }

    [JsonPropertyName("EmTra")]
    public decimal? EmTra { get; set; }

    [JsonPropertyName("Estado")]
    public bool? EmActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? EmCdgoCiaNavigation { get; set; }

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? CompaniaCodigo { get; set; }



    [NotMapped]
    public string? CompaniaNombre { get; set; }

    public Empaque()
    {

    }

    public Empaque(
                    int? EmRowid,
                    string? EmCdgoCia,
                    string? EmCdgo,
                    string? EmNmbre,
                    decimal? EmTra,
                    bool? EmActvo,
                    string? CompaniaCodigo,
                    string? CompaniaNombre
                )
    {
        this.EmRowid = EmRowid;
        this.EmCdgoCia = EmCdgoCia;
        this.EmCdgo = EmCdgo;
        this.EmNmbre = EmNmbre;
        this.EmTra = EmTra;
        this.EmActvo = EmActvo;
        this.CompaniaCodigo = CompaniaCodigo;
        this.CompaniaNombre = CompaniaNombre;
    }

}
