using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwConsultarSubdeposito
{
    public string? CodigoSubdeposito { get; set; } = null!;

    public string? CodigoPadre { get; set; } = null!;

    public int? IdTercero { get; set; }

    public string? NombreTercero { get; set; }

    public int? Cantidad { get; set; }

    public int? Unidades { get; set; }
}
