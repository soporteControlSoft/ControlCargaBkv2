using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpReturnAprbrRchzarDpsto
{
    [Key]
    public bool? respuesta { get; set; }
   
}
