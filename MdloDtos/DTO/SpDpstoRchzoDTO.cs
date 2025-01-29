using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpDpstoRchzoDTO
{
    [Key]
   [JsonPropertyName("IdDeposito")]
    public int IdDeposito { get; set; }

    [JsonPropertyName("CodigoUsuarioQueRechaza")]
    public string? CodigoUsuarioQueRechaza { get; set; }

    [JsonPropertyName("ComentarioRechazo")]
    public string? ComentarioRechazo { get; set; }

   

}
