using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwListadoClientesDetalle
{
    public int? IdImportador { get; set; }

    public string? NombreImportador { get; set; }

    public string? CodigoProducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? NroBl { get; set; }

    public int? Kilos { get; set; }

    public int? Directo { get; set; }

    public int? Almacenar { get; set; }

    public int? Ecotilla { get; set; }

    public string? RequisitoCliente { get; set; }

    public string? Localizacion { get; set; }

    public int? IdOperador { get; set; }

    public string? NombreOperador { get; set; }

    public int? IdVisita { get; set; }

    public int? IdSituacion { get; set; }

    public int? IdSituacionDetalle { get; set; }

    public int? IdVisitaBl { get; set; }

    public VwListadoClientesDetalle() { }
}
