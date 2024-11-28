 using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwListadoClientesEncabezado
{
    public int? IdTercero { get; set; }

    public string? NombreVendedor { get; set; }

    public string? CodigoPais { get; set; } = null!;

    public string? NombrePais { get; set; }

    public int? IdAgenteNaviero { get; set; }

    public string? NomnbreAgenteNaviero { get; set; }

    public string? CodigoMotonave { get; set; } = null!;

    public string? NombreMotonave { get; set; }

    public string? MatriculaMotonave { get; set; }

    public decimal? Eslora { get; set; }

    public DateTime? FechaArribo { get; set; }

    public string? CodPrestadoServicio { get; set; }

    public string? CodTerminalMaritimo { get; set; }

    public string? NombreTerminalMaritimo { get; set; }

    public int? IdVisita { get; set; }

    public int? IdSituacion { get; set; }

    public bool? TeMnjoPrpio { get; set; }
}
