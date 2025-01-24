using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpSubDepositoDTO
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int? IdDeposito {  get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? CodigoDeposito { get; set; }

    [JsonPropertyName("EstadoDeposito")]
    public string? EstadoDeposito { get; set; }

    [JsonPropertyName("IdTercero")]
    public int? IdTercero { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string? CodigoTercero { get; set; }

    [JsonPropertyName("NombreTercero")]
    public string? NombreTercero { get; set; }

    [JsonPropertyName("IdenticacionTercero")]
    public string? IdenticacionTercero { get; set; }

    [JsonPropertyName("TipoIdenticacionTercero")]
    public string? TipoIdenticacionTercero { get; set; }

    [JsonPropertyName("CodigoDepositoPadre")]
    public string? CodigoDepositoPadre { get; set; }

    [JsonPropertyName("CodigoProductoDeposito")]
    public string? CodigoProductoDeposito { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? CodigoProducto { get; set; }

    [JsonPropertyName("NombreProducto")]
    public string? NombreProducto { get; set; }

    [JsonPropertyName("EstadoProducto")]
    public bool? EstadoProducto { get; set; }

    [JsonPropertyName("SolicitarEmpaqueProducto")]
    public bool? SolicitarEmpaqueProducto { get; set; }

    [JsonPropertyName("CodigoERPProducto")]
    public string? CodigoERPProducto { get; set; }

    [JsonPropertyName("SustanciaControladaProducto")]
    public bool? SustanciaControladaProducto { get; set; }

    [JsonPropertyName("ActivoDeposito")]
    public bool? ActivoDeposito { get; set; }

    [JsonPropertyName("AprobadoDeposito")]
    public bool? AprobadoDeposito { get; set; }

    [JsonPropertyName("EsSubdepositoDeposito")]
    public bool? EsSubdepositoDeposito { get; set; }

    [JsonPropertyName("KilosDeposito")]
    public int? KilosDeposito { get; set; }

    [JsonPropertyName("CantidadDeposito")]
    public int? CantidadDeposito { get; set; }


}
