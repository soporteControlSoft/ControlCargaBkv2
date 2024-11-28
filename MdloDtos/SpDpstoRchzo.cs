using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpDpstoRchzo
{
    [Key]
   [JsonPropertyName("IdDeposito")]
    public int rowIdDpsto { get; set; }

    [JsonPropertyName("CodigoUsuarioQueRechaza")]
    public string? cdgoUsrioRchza { get; set; }

    [JsonPropertyName("ComentarioRechazo")]
    public string? cmntrioRchzo { get; set; }

   

}
