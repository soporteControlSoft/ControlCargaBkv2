using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwConsultaCertificado
{
    public int? Id { get; set; }

    public string? IdCompania { get; set; } = null!;

    public string? NombreCompania { get; set; }

    public string? Codigo { get; set; } = null!;

    public int? IdTercero { get; set; }

    public string? NombreTercero { get; set; }

    public string? CodigoProducto { get; set; } = null!;

    public string? NombreProducto { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public DateTime? FechaCargue { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public bool? Aprobo { get; set; }

    public string? CodigoUsuarioAprobo { get; set; }

    public string? NombreUsuarioAprobo { get; set; }

    public DateTime? FechaInicio { get; set; }
}
