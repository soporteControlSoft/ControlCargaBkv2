using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwResumenListadoClientesOld
{
    public string? CodigoProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? Kilos { get; set; }

    public int? Directo { get; set; }

    public int? Almacenar { get; set; }

    public int? Ecotilla { get; set; }

    public int IdVisita { get; set; }
}
