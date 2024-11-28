using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class BarcoListadoCliente
{
    public int? Ecotilla { get; set; }

    public string? CodigoProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? IdOperador { get; set; }

    public string? NombreOperador { get; set; }

    public int IdVisita { get; set; }

    public int? Kilos { get; set; }
}
