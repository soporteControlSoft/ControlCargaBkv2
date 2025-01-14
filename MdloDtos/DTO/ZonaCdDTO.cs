using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class ZonaCdDTO
{
    [JsonPropertyName("IdZona")]
    public int? IdZona { get; set; }

    [JsonPropertyName("Codigo")]
    public string? Codigo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; }

    [JsonPropertyName("Estado")]
    public bool? Estado { get; set; }

    [JsonPropertyName("IdSede")]
    public int? IdSede { get; set; }

    [JsonPropertyName("Bodega")]
    public bool? Bodega { get; set; }

    [JsonPropertyName("Slo")]
    public bool? Slo { get; set; }

    [JsonPropertyName("Muelle")]
    public bool? Muelle { get; set; }

    [JsonPropertyName("Patio")]
    public bool? Patio { get; set; }

    [JsonPropertyName("Capacidad")]
    public int? Capacidad { get; set; }

    [JsonPropertyName("Planta")]
    public string? Planta { get; set; }

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

    public ZonaCdDTO()
    {

    }

    public ZonaCdDTO(
                    int? IdZona,
                    string? Codigo,
                    string? Nombre,
                    bool? Estado,
                    int? IdSede,
                    bool? Bodega,
                    bool? Slo,
                    bool? Muelle,
                    bool? Patio,
                    int? Capacidad,
                    string? Planta,

                    string? SedeRowId,
                    string? SedeCodigo,
                    string? SedeNombre
                )
    {
        //Atributos ZonaCargueDescargue
        this.IdZona = IdZona;
        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.Estado = Estado;
        this.IdSede = IdSede;
        this.Bodega = Bodega;
        this.Slo = Slo;
        this.Muelle = Muelle;
        this.Patio = Patio;
        this.Capacidad = Capacidad;
        this.Planta = Planta;

        //Atributos Sede
        this.SedeRowId = SedeRowId;
        this.SedeCodigo = SedeCodigo;
        this.SedeNombre = SedeNombre;
    }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();


}
