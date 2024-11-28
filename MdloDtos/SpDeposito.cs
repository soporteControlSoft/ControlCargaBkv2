using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpDeposito
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int? De_rowid {  get; set; }
    [JsonPropertyName("CodigoCompania")]
    public string? De_cia { get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? De_cdgo { get; set; }
   
}
