using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpDepositoDetalleDTO
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int? IdDeposito {  get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? CodigoDeposito { get; set; }

    [JsonPropertyName("VisitaMotonave")]
    public string? VisitaMotonave { get; set; }

    [JsonPropertyName("NombreTercero")]
    public string? NombreTercero { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? CodigoProducto { get; set; }

    [JsonPropertyName("NombreProducto")]
    public string? NombreProducto { get; set; }

}
