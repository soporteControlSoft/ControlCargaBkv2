using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpDepositoDTO
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int? IdDeposito {  get; set; }
    [JsonPropertyName("CodigoCompania")]
    public string? CodigoCompania { get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? CodigoDeposito { get; set; }
   
}
