using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpMdloRsrvaDtlleOrdenDTO
{
    [Key]
    [JsonPropertyName("CodigoOrden")]
    public int CodigoOrden { get; set; }

    [JsonPropertyName("IdentificacionConductorOrden")]
    public string? IdentificacionConductorOrden { get; set; }

    [JsonPropertyName("IdentificacionConductor")]
    public string? IdentificacionConductor { get; set; } 

    [JsonPropertyName("NombreConductor")]
    public string? NombreConductor { get; set; } 

    [JsonPropertyName("MovilConductor")]
    public string? MovilConductor { get; set; }

    [JsonPropertyName("TipoLicenciaConductor")]
    public string? TipoLicenciaConductor { get; set; }

    [JsonPropertyName("NumeroLicenciaConductor")]
    public string? NumeroLicenciaConductor { get; set; }

    [JsonPropertyName("FechaVencimientoLicencia")]
    public DateTime? FechaVencimientoLicencia { get; set; }

    [JsonPropertyName("PlacaOrden")]
    public string? PlacaOrden { get; set; }

    [JsonPropertyName("RemolqueOrden")]
    public string? RemolqueOrden { get; set; }

    [JsonPropertyName("IdConfiguracionVehicularOrden")]
    public int? IdConfiguracionVehicularOrden { get; set; }

    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? IdConfiguracionVehicular { get; set; }

    [JsonPropertyName("CodigoConfiguracionVehicular")]
    public string? CodigoConfiguracionVehicular { get; set; }

    [JsonPropertyName("NombreConfiguracionVehicular")]
    public string? NombreConfiguracionVehicular { get; set; }

    [JsonPropertyName("PesoMaximoConfiguracionVehicular")]
    public int? PesoMaximoConfiguracionVehicular { get; set; }

    [JsonPropertyName("ToleranciaConfiguracionVehicular")]
    public int? ToleranciaConfiguracionVehicular { get; set; }

    [JsonPropertyName("ManifiestoOrden")]
    public string? ManifiestoOrden { get; set; }

    [JsonPropertyName("RemisionOrden")]
    public string? RemisionOrden { get; set; }

    [JsonPropertyName("PesoACargarOrden")]
    public int? PesoACargarOrden { get; set; }

    [JsonPropertyName("IdCiudadOrden")]
    public int? IdCiudadOrden { get; set; }

    [JsonPropertyName("IdCiudad")]
    public int? IdCiudad { get; set; }

    [JsonPropertyName("CodigoCiudad")]
    public string? CodigoCiudad { get; set; }

    [JsonPropertyName("NombreCiudad")]
    public string? NombreCiudad { get; set; }

    [JsonPropertyName("IdZonaCargueDescargueOrden")]
    public int? IdZonaCargueDescargueOrden { get; set; }

    [JsonPropertyName("IdZonaCargueDescargue")]
    public int? IdZonaCargueDescargue { get; set; }

    [JsonPropertyName("CodigoZonaCargueDescargue")]
    public string? CodigoZonaCargueDescargue { get; set; }

    [JsonPropertyName("NombreZonaCargueDescargue")]
    public string? NombreZonaCargueDescargue { get; set; }

    [JsonPropertyName("FechaLimiteSolicitudRetiro")]
    public int? FechaLimiteSolicitudRetiro { get; set; }

    [JsonPropertyName("IdEmpaque")]
    public int? IdEmpaque { get; set; }

    [JsonPropertyName("CodigoEmpaque")]
    public string? CodigoEmpaque { get; set; }

    [JsonPropertyName("NombreEmpaque")]
    public string? NombreEmpaque { get; set; }

    [JsonPropertyName("MinutosVigenciaReserva")]
    public int? MinutosVigenciaReserva { get; set; }

    [JsonPropertyName("IdDeposito")]
    public int? IdDeposito { get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? CodigoDeposito { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int? IdVisitaMotonave { get; set; }

    [JsonPropertyName("DescripcionVisitaMotonave")]
    public string? DescripcionVisitaMotonave { get; set; } 

    [JsonPropertyName("IdTercero")]
    public int? IdTercero { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string? CodigoTercero { get; set; } 

    [JsonPropertyName("NombreTercero")]
    public string? NombreTercero { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? CodigoProducto { get; set; } 

    [JsonPropertyName("NombreProducto")]
    public string? NombreProducto { get; set; }

    [JsonPropertyName("SaldoKilosDeposito")]
    public int? SaldoKilosDeposito { get; set; }

    [JsonPropertyName("SaldoUnidadesDeposito")]
    public int? SaldoUnidadesDeposito { get; set; }

    [JsonPropertyName("CodigoSolicitudRetiro")]
    public string? CodigoSolicitudRetiro { get; set; }

    [JsonPropertyName("PlantaDestinoSolicitudRetiro")]
    public string? PlantaDestinoSolicitudRetiro { get; set; }

    [JsonPropertyName("AutorizadoKilosSolicitudRetiro")]
    public int? AutorizadoKilosSolicitudRetiro { get; set; }

    [JsonPropertyName("AutorizadoCantidadSolicitudRetiro")]
    public int? AutorizadoCantidadSolicitudRetiro { get; set; }

    [JsonPropertyName("LiberadoKilosSolicitudRetiro")]
    public int? LiberadoKilosSolicitudRetiro { get; set; }

    [JsonPropertyName("LiberadoUnidadesSolicitudRetiro")]
    public int? LiberadoUnidadesSolicitudRetiro { get; set; }

    [JsonPropertyName("SaldoKilosSolicitudRetiro")]
    public int? SaldoKilosSolicitudRetiro { get; set; }

    [JsonPropertyName("SaldoUnidadesSolicitudRetiro")]
    public int? SaldoUnidadesSolicitudRetiro { get; set; }

    [JsonPropertyName("TotalAutorizadoKilosTransportadora")]
    public int? TotalAutorizadoKilosTransportadora { get; set; }

    [JsonPropertyName("TotalAutorizadoUnidadesTransportadora")]
    public int? TotalAutorizadoUnidadesTransportadora { get; set; }

    [JsonPropertyName("LiberadoKilosTransportadora")]
    public int? LiberadoKilosTransportadora { get; set; }

    [JsonPropertyName("LiberadoUnidadesTransportadora")]
    public int? LiberadoUnidadesTransportadora { get; set; }

    [JsonPropertyName("RetiradoTransportadora")]
    public int? RetiradoTransportadora { get; set; }

    [JsonPropertyName("SaldoKilosTransportadora")]
    public int? SaldoKilosTransportadora { get; set; }

    [JsonPropertyName("SaldoUnidadesTransportadora")]
    public int? SaldoUnidadesTransportadora { get; set; }

    [JsonPropertyName("ReservaOrden")]
    public string? ReservaOrden { get; set; } 

    [JsonPropertyName("LlamadaOrden")]
    public string? LlamadaOrden { get; set; }

    [JsonPropertyName("RadicadaOrden")]
    public string? RadicadaOrden { get; set; }

    [JsonPropertyName("TransitoOrden")]
    public string? TransitoOrden { get; set; } 

    [JsonPropertyName("FechaReservaOrden")]
    public DateTime? FechaReservaOrden { get; set; }

    [JsonPropertyName("FechaRegistroReservaOrden")]
    public DateTime? FechaRegistroReservaOrden { get; set; }

    [JsonPropertyName("FechaPrimerLlamadoOrden")]
    public DateTime? FechaPrimerLlamadoOrden { get; set; }

    [JsonPropertyName("FechaUltimoLlamadoOrden")]
    public DateTime? FechaUltimoLlamadoOrden { get; set; }

    [JsonPropertyName("FechaRadicacionOrden")]
    public DateTime? FechaRadicacionOrden { get; set; }

    [JsonPropertyName("FechaAnulacionOrden")]
    public DateTime? FechaAnulacionOrden { get; set; }

    [JsonPropertyName("ActivaOrden")]
    public bool? ActivaOrden { get; set; }

    [JsonPropertyName("ObservacionesOrden")]
    public string? ObservacionesOrden { get; set; }
}
