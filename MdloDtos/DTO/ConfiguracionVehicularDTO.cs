using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class ConfiguracionVehicularDTO
{
    [Key]
    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? IdConfiguracionVehicular { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string? Codigo { get; set; } = null!;

    [StringLength(60)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; } = null!;

    [JsonPropertyName("PesoMaximo")]
    public int? PesoMaximo { get; set; }

    [JsonPropertyName("Tolerancia")]
    public int? Tolerancia { get; set; }

    [JsonPropertyName("CodigoCompania")]
    [StringLength(15)]
    public string? CodigoCompania { get; set; } = null!;

    [JsonPropertyName("Estado")]
    public bool? Estado { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? CvCdgoCiaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    [JsonPropertyName("CompaniaCodigo")]
    public string? CompaniaCodigo { get; set; }



    [NotMapped]
    [JsonPropertyName("CompaniaNombre")]
    public string? CompaniaNombre { get; set; }

    public ConfiguracionVehicularDTO()
    {

    }

    public ConfiguracionVehicularDTO(
                    int? IdConfiguracionVehicular,
                    string? Codigo,
                    string? Nombre,
                    int? PesoMaximo,
                    int? Tolerancia,
                    string? CodigoCompania,
                    bool? Estado,
                    string? CompaniaCodigo,
                    string? CompaniaNombre
                )
    {
        this.IdConfiguracionVehicular = IdConfiguracionVehicular;
        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.PesoMaximo = PesoMaximo;
        this.Tolerancia = Tolerancia;
        this.CodigoCompania = CodigoCompania;
        this.Estado = Estado;
        this.CompaniaCodigo = CompaniaCodigo;
        this.CompaniaNombre = CompaniaNombre;
    }
}
