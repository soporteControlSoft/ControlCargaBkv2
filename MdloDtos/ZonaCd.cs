using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class ZonaCd
{
    [JsonPropertyName("IdZona")]
    public int? ZcdRowid { get; set; }

    [JsonPropertyName("Codigo")]
    public string? ZcdCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    public string? ZcdNmbre { get; set; }

    [JsonPropertyName("Estado")]
    public bool? ZcdActvo { get; set; }

    [JsonPropertyName("IdSede")]
    public int? ZcdRowidSde { get; set; }

    [JsonPropertyName("Bodega")]
    public bool? ZcdBdga { get; set; }

    [JsonPropertyName("Slo")]
    public bool? ZcdSlo { get; set; }

    [JsonPropertyName("Muelle")]
    public bool? ZcdMlle { get; set; }

    [JsonPropertyName("Patio")]
    public bool? ZcdPtio { get; set; }

    [JsonPropertyName("Capacidad")]
    public int? ZcdCpcdad { get; set; }

    [JsonPropertyName("Planta")]
    public string? ZcdPlnta { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();


    [JsonIgnore]
    [NotMapped]
    public virtual Sede? ZcdRowidSdeNavigation { get; set; } = null!;

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? SedeRowId { get; set; }

    [NotMapped]
    public string? SedeCodigo { get; set; }

    [NotMapped]
    public string? SedeNombre { get; set; }

    public ZonaCd()
    {

    }

    public ZonaCd(
                    int? ZcdRowid,
                    string? ZcdCdgo,
                    string? ZcdNmbre,
                    bool? ZcdActvo,
                    int? ZcdRowidSde,
                    bool? ZcdBdga,
                    bool? ZcdSlo,
                    bool? ZcdMlle,
                    bool? ZcdPtio,
                    int? ZcdCpcdad,
                    string? ZcdPlnta,

                    string? SedeRowId,
                    string? SedeCodigo,
                    string? SedeNombre
                )
    {
        //Atributos ZonaCargueDescargue
        this.ZcdRowid = ZcdRowid;
        this.ZcdCdgo = ZcdCdgo;
        this.ZcdNmbre = ZcdNmbre;
        this.ZcdActvo = ZcdActvo;
        this.ZcdRowidSde = ZcdRowidSde;
        this.ZcdBdga = ZcdBdga;
        this.ZcdSlo = ZcdSlo;
        this.ZcdMlle = ZcdMlle;
        this.ZcdPtio = ZcdPtio;
        this.ZcdCpcdad = ZcdCpcdad;
        this.ZcdPlnta = ZcdPlnta;

        //Atributos Sede
        this.SedeRowId = SedeRowId;
        this.SedeCodigo = SedeCodigo;
        this.SedeNombre = SedeNombre;
    }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();

}
