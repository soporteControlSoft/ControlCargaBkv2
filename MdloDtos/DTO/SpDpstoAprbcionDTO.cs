using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpDpstoAprbcionDTO
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int IdDeposito { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? CodigoCompania { get; set; }

    [JsonPropertyName("IdSede")]
    public int? IdSede { get; set; }

    [JsonPropertyName("CodigoUsuarioQueAprueba")]
    public string? CodigoUsuarioQueAprueba { get; set; }

    [JsonPropertyName("CantidadImpresionTiquete")]
    public int? CantidadImpresionTiquete { get; set; }

    [JsonPropertyName("EstadoDeposito")]
    public bool? EstadoDeposito { get; set; }

    [JsonPropertyName("ControlUnidades")]
    public bool? ControlUnidades { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? Observaciones { get; set; }

    [JsonPropertyName("DepositoComun")]
    public bool? DepositoComun { get; set; }

    [JsonPropertyName("IdEmpaque")]
    public int? IdEmpaque { get; set; }

    [JsonPropertyName("UsuarioObservacion")]
    public string? UsuarioObservacion { get; set; }

    [JsonPropertyName("CodigoCompaniaFacturacion")]
    public string? CodigoCompaniaFacturacion { get; set; }


}
