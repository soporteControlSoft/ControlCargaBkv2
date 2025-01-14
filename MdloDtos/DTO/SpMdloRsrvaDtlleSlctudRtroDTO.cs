using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpMdloRsrvaDtlleSlctudRtroDTO
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int IdDeposito { get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string CodigoDeposito { get; set; } = null!;

    [JsonPropertyName("IdVisitaMotonave")]
    public int IdVisitaMotonave { get; set; }

    [JsonPropertyName("DescripcionVisitaMotonave")]
    public string DescripcionVisitaMotonave { get; set; } = null!;

    [JsonPropertyName("IdTercero")]
    public int IdTercero { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string CodigoTercero { get; set; } = null!;

    [JsonPropertyName("NombreTercero")]
    public string? NombreTercero { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string CodigoProducto { get; set; } = null!;

    [JsonPropertyName("NombreProducto")]
    public string? NombreProducto { get; set; }

    [JsonPropertyName("SaldoKilosDeposito")]
    public int? SaldoKilosDeposito { get; set; }

    [JsonPropertyName("SaldoUnidadesDeposito")]
    public int? SaldoUnidadesDeposito { get; set; }

    [JsonPropertyName("CodigoSolicitudRetiro")]
    public string CodigoSolicitudRetiro { get; set; } = null!;

    [JsonPropertyName("PlantaDestinoSolicitudRetiro")]
    public string? PlantaDestinoSolicitudRetiro { get; set; }

    [JsonPropertyName("IdCiudad")]
    public int IdCiudad { get; set; }

    [JsonPropertyName("CodigoCiudad")]
    public string CodigoCiudad { get; set; } = null!;

    [JsonPropertyName("NombreCiudad")]
    public string? NombreCiudad { get; set; }

    [JsonPropertyName("AutorizadoKilosSolicitudRetiro")]
    public int? AutorizadoKilosSolicitudRetiro { get; set; }

    [JsonPropertyName("AutorizadoCantidadSolicitudRetiro")]
    public int? AutorizadoCantidadSolicitudRetiro { get; set; }

    [JsonPropertyName("LiberadoKilosSolicitudRetiro")]
    public int LiberadoKilosSolicitudRetiro { get; set; }

    [JsonPropertyName("LiberadoUnidadesSolicitudRetiro")]
    public int LiberadoUnidadesSolicitudRetiro { get; set; }

    [JsonPropertyName("SaldoKilosSolicitudRetiro")]
    public int? SaldoKilosSolicitudRetiro { get; set; }

    [JsonPropertyName("SaldoUnidadesSolicitudRetiro")]
    public int? SaldoUnidadesSolicitudRetiro { get; set; }

    [JsonPropertyName("TotalAutorizadoKilosTransportadora")]
    public int? TotalAutorizadoKilosTransportadora { get; set; }

    [JsonPropertyName("TotalAutorizadoUnidadesTransportadora")]
    public int? TotalAutorizadoUnidadesTransportadora { get; set; }

    [JsonPropertyName("LiberadoKilosTransportadora")]
    public int LiberadoKilosTransportadora { get; set; }

    [JsonPropertyName("LiberadoUnidadesTransportadora")]
    public int LiberadoUnidadesTransportadora { get; set; }

    [JsonPropertyName("RetiradoTransportadora")]
    public int RetiradoTransportadora { get; set; }

    [JsonPropertyName("SaldoKilosTransportadora")]
    public int? SaldoKilosTransportadora { get; set; }

    [JsonPropertyName("SaldoUnidadesTransportadora")]
    public int? SaldoUnidadesTransportadora { get; set; }
}
