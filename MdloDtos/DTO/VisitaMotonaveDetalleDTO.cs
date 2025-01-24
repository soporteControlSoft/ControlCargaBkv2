using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VisitaMotonaveDetalleDTO
{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int? IdVisitaMotonave { get; set; }

    [JsonPropertyName("IdSituacionPortuariaDetalle")]
    public int? IdSituacionPortuariaDetalle { get; set; }

    [JsonPropertyName("CodigoAgenciaAduana")]
    public int? CodigoAgenciaAduana { get; set; }

    [JsonPropertyName("Estado")]
    public bool? Estado { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl> VisitaMotonaveBls { get; set; } = new List<VisitaMotonaveBl>();

    //[JsonIgnore]
    [NotMapped]
    public virtual Tercero? VmdRowidAgnciaAdnaNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual SituacionPortuariaDetalle? VmdRowidStcionPrtriaDtlleNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonave? VmdRowidVstaMtnveNavigation { get; set; } = null!;

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 
    [NotMapped]
    public string? ImportadorRowId { get; set; }

    [NotMapped]
    public string? ImportadorNit { get; set; }

    [NotMapped]
    public string? ImportadorNombre { get; set; }

    [NotMapped]
    public string? ProductoCodigo { get; set; }

    [NotMapped]
    public string? ProductoNombre { get; set; }

    [NotMapped]
    public string? AgenciaAduanaCodigo { get; set; }

    [NotMapped]
    public string? AgenciaAduanaNombre { get; set; }

    public VisitaMotonaveDetalleDTO() { }

    public VisitaMotonaveDetalleDTO(
                                    int VmdRowid,
                                    int? VmdRowidVstaMtnve,
                                    int? VmdRowidStcionPrtriaDtlle,
                                    int? VmdRowidAgnciaAdna,
                                    bool? VmdActvo,
                                    string? AgenciaAduanaCodigo,
                                    string? AgenciaAduanaNombre
                              )
    {
        this.Id = VmdRowid;
        this.IdVisitaMotonave = VmdRowidVstaMtnve;
        this.IdSituacionPortuariaDetalle = VmdRowidStcionPrtriaDtlle;
        this.CodigoAgenciaAduana = VmdRowidAgnciaAdna;
        this.Estado = VmdActvo;
        this.AgenciaAduanaCodigo = AgenciaAduanaCodigo;
        this.AgenciaAduanaNombre = AgenciaAduanaNombre;
    }
}
