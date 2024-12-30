using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class WvConsultaDepositosSubdeposito
{
    public int IdDeposito { get; set; }

    public string CodigoDeposito { get; set; } = null!;

    public string? CodigoPadreDeposito { get; set; }

    public string? CodigoMotonave { get; set; } = null!;

    public string? NombreMotonave { get; set; }

    public string? CodigoProducto { get; set; } = null!;

    public string? NombreProducto { get; set; }

    public int? SaldosKilos { get; set; }

    public int? SaldosUnidades { get; set; }

    public string? CodigoUsuario { get; set; } = null!;

    public int? CodigoCliente { get; set; }

    public int? IdVisita { get; set; }
}
