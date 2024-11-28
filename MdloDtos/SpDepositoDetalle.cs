using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpDepositoDetalle
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int? De_rowid {  get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? De_cdgo { get; set; }

    [JsonPropertyName("VisitaMotonave")]
    public string? Vm_dscrpcion { get; set; }

    [JsonPropertyName("NombreTercero")]
    public string? Te_nmbre { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? Pr_cdgo { get; set; }

    [JsonPropertyName("NombreProducto")]
    public string? Pr_nmbre { get; set; }

}
