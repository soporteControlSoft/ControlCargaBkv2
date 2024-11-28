using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MdloDtos;

public partial class WmDepositosSolicitudRetiro
{
    [Key]
    public int IdDeposito { get; set; }

    public string CodigoDeposito { get; set; } = null!;

    public string? CodigoPadreDeposito { get; set; }

    public string CodigoMotonave { get; set; } = null!;

    public string? NombreMotonave { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string? NombreProducto { get; set; }

    public int? Saldos { get; set; }

    public string CodigoUsuario { get; set; } = null!;

    public int CodigoCliente { get; set; }

    public int IdVisita { get; set; }

    public int IdRetiro { get; set; }

    public int CantidadRetiro { get; set; }

    public string? PlantaDestino { get; set; }

    public int? KilosAutorizado { get; set; }

    public int? Cantidad { get; set; }

    public int? KilosDespachados { get; set; }

    public int? CantidadDespachados { get; set; }

    public bool? EstadoSolicitud { get; set; }

    public bool? SrAbrta { get; set; }

    public bool? SrEntrgaSspndda { get; set; }

    public string? SrObsrvcnes { get; set; }

    public string? SrCmpoPrsnlzdo1 { get; set; }

    public string? SrCmpoPrsnlzdo2 { get; set; }

    public string? SrCmpoPrsnlzdo3 { get; set; }

    public int? ZonaSolicitud { get; set; }

    public bool? PesoExacto { get; set; }

    public DateTime? FechaApertura { get; set; }
}
