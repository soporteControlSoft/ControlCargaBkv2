using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpInvntrioBdgaDpsto
{
    [Key]
    public int IdBodega { get; set; }
    public String? Bodega {  get; set; }
    public int? KilosEntradas { get; set; }
    public int? kilosSalidas { get; set; }
    public int? UnidadesEntradas { get; set; }
    public int? UnidadesSalidas { get; set; }
}
