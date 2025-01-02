using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpMdloRsrvaDtlleSlctudRtro
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int de_rowid { get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string de_cdgo { get; set; } = null!;

    [JsonPropertyName("IdVisitaMotonave")]
    public int vm_rowid { get; set; }

    [JsonPropertyName("DescripcionVisitaMotonave")]
    public string vm_dscrpcion { get; set; } = null!;

    [JsonPropertyName("IdTercero")]
    public int te_rowid { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string te_cdgo { get; set; } = null!;

    [JsonPropertyName("NombreTercero")]
    public string? te_nmbre { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string pr_cdgo { get; set; } = null!;

    [JsonPropertyName("NombreProducto")]
    public string? pr_nmbre { get; set; }

    [JsonPropertyName("SaldoKilosDeposito")]
    public int? sldo_klos_dpsto { get; set; }

    [JsonPropertyName("SaldoUnidadesDeposito")]
    public int? sldo_unddes_dpsto { get; set; }

    [JsonPropertyName("CodigoSolicitudRetiro")]
    public string sr_cdgo { get; set; } = null!;

    [JsonPropertyName("PlantaDestinoSolicitudRetiro")]
    public string? sr_plnta_dstno { get; set; }

    [JsonPropertyName("IdCiudad")]
    public int ci_rowid { get; set; }

    [JsonPropertyName("CodigoCiudad")]
    public string ci_cdgo { get; set; } = null!;

    [JsonPropertyName("NombreCiudad")]
    public string? ci_nmbre { get; set; }

    [JsonPropertyName("AutorizadoKilosSolicitudRetiro")]
    public int? sr_autrzdo_klos { get; set; }

    [JsonPropertyName("AutorizadoCantidadSolicitudRetiro")]
    public int? sr_autrzdo_cntdad { get; set; }

    [JsonPropertyName("LiberadoKilosSolicitudRetiro")]
    public int lbrdo_klos_slctud_rtro { get; set; }

    [JsonPropertyName("LiberadoUnidadesSolicitudRetiro")]
    public int lbrdo_unddes_slctud_rtro { get; set; }

    [JsonPropertyName("SaldoKilosSolicitudRetiro")]
    public int? sldo_klos_slctud_rtro { get; set; }

    [JsonPropertyName("SaldoUnidadesSolicitudRetiro")]
    public int? sldo_unddes_slctud_rtro { get; set; }

    [JsonPropertyName("TotalAutorizadoKilosTransportadora")]
    public int? ttal_autrzdo_klos_trnsprtdra { get; set; }

    [JsonPropertyName("TotalAutorizadoUnidadesTransportadora")]
    public int? ttal_autrzdo_unddes_trnsprtdra { get; set; }

    [JsonPropertyName("LiberadoKilosTransportadora")]
    public int lbrdo_klos_trnsprtdra { get; set; }

    [JsonPropertyName("LiberadoUnidadesTransportadora")]
    public int lbrdo_unddes_trnsprtdra { get; set; }

    [JsonPropertyName("RetiradoTransportadora")]
    public int rtrdo_trnsprtdra { get; set; }

    [JsonPropertyName("SaldoKilosTransportadora")]
    public int? sldo_klos_trnsprtdra { get; set; }

    [JsonPropertyName("SaldoUnidadesTransportadora")]
    public int? sldo_unddes_trnsprtdra { get; set; }
}
