using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpSubDeposito
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int? De_rowid {  get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? De_cdgo { get; set; }

    [JsonPropertyName("EstadoDeposito")]
    public string? De_estdo { get; set; }

    [JsonPropertyName("IdTercero")]
    public int? Te_rowid { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string? Te_cdgo { get; set; }

    [JsonPropertyName("NombreTercero")]
    public string? Te_nmbre { get; set; }

    [JsonPropertyName("IdenticacionTercero")]
    public string? Te_idntfccion { get; set; }

    [JsonPropertyName("TipoIdenticacionTercero")]
    public string? Te_tpo_idntfccion { get; set; }

    [JsonPropertyName("CodigoDepositoPadre")]
    public string? De_cdgo_dpsto_pdre { get; set; }

    [JsonPropertyName("CodigoProductoDeposito")]
    public string? De_cdgo_prdcto { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? Pr_cdgo { get; set; }

    [JsonPropertyName("NombreProducto")]
    public string? Pr_nmbre { get; set; }

    [JsonPropertyName("EstadoProducto")]
    public bool? Pr_actvo { get; set; }

    [JsonPropertyName("SolicitarEmpaqueProducto")]
    public bool? Pr_slctar_empque { get; set; }

    [JsonPropertyName("CodigoERPProducto")]
    public string? Pr_cdgo_erp { get; set; }

    [JsonPropertyName("SustanciaControladaProducto")]
    public bool? Pr_sstncia_cntrlda { get; set; }

    [JsonPropertyName("ActivoDeposito")]
    public bool? De_actvo { get; set; }

    [JsonPropertyName("AprobadoDeposito")]
    public bool? De_aprbdo { get; set; }

    [JsonPropertyName("EsSubdepositoDeposito")]
    public bool? De_es_subdpsto { get; set; }

    [JsonPropertyName("KilosDeposito")]
    public int? De_klos { get; set; }

    [JsonPropertyName("CantidadDeposito")]
    public int? De_cntdad { get; set; }


}
