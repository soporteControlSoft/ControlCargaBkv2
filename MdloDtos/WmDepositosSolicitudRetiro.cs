using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class WmDepositosSolicitudRetiro
{
    public int IdDeposito { get; set; }

    public string CodigoDeposito { get; set; } = null!;

    public string? CodigoPadreDeposito { get; set; }

    public string CodigoMotonave { get; set; } = null!;

    public string? NombreMotonave { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string? NombreProducto { get; set; }

    public int SaldosKilos { get; set; }

    public int SaldosUnidades { get; set; }

    public int IdTercero { get; set; }

    public int IdVisita { get; set; }

    public int IdRetiro { get; set; }

    public int Ciudad { get; set; }

    public string? Planta { get; set; }

    public int? KilosAutorizado { get; set; }

    public int? UnidadesAutorizado { get; set; }

    public int? KilosDespachados { get; set; }

    public int? UnidadesDespachadas { get; set; }

    public bool? Activa { get; set; }

    public bool? Abierta { get; set; }

    public bool? EntregaSuspendida { get; set; }

    public string? Observaciones { get; set; }

    public string? SrCmpoPrsnlzdo1 { get; set; }

    public string? SrCmpoPrsnlzdo2 { get; set; }

    public string? SrCmpoPrsnlzdo3 { get; set; }

    public int? ZonaId { get; set; }

    public bool? PesoExacto { get; set; }

    public DateTime? FechaApertura { get; set; }

    public string CodigoTercero { get; set; } = null!;

    public string? NombreCiudad { get; set; }

    public string? NombreZona { get; set; }

    public string? NombreTercero { get; set; }
}
