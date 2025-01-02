using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpMdloRsrvaDtlleOrden
{
    [Key]
    [JsonPropertyName("CodigoOrden")]
    public int or_cdgo { get; set; }

    [JsonPropertyName("IdentificacionConductorOrden")]
    public string? or_idntfccion_cndctor { get; set; }

    [JsonPropertyName("IdentificacionConductor")]
    public string? cn_idntfccion { get; set; } 

    [JsonPropertyName("NombreConductor")]
    public string? cn_nmbre { get; set; } 

    [JsonPropertyName("MovilConductor")]
    public string? cn_mvil { get; set; }

    [JsonPropertyName("TipoLicenciaConductor")]
    public string? cn_tpo_lcncia { get; set; }

    [JsonPropertyName("NumeroLicenciaConductor")]
    public string? cn_nmro_lcncia { get; set; }

    [JsonPropertyName("FechaVencimientoLicencia")]
    public DateTime? cn_fcha_vncmnto_lcncia { get; set; }

    [JsonPropertyName("PlacaOrden")]
    public string? or_plca { get; set; }

    [JsonPropertyName("RemolqueOrden")]
    public string? or_rmlque { get; set; }

    [JsonPropertyName("IdConfiguracionVehicularOrden")]
    public int? or_rowid_cnfgrcion_vhclar { get; set; }

    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? cv_rowid { get; set; }

    [JsonPropertyName("CodigoConfiguracionVehicular")]
    public string? cv_cdgo { get; set; }

    [JsonPropertyName("NombreConfiguracionVehicular")]
    public string? cv_nmbre { get; set; }

    [JsonPropertyName("PesoMaximoConfiguracionVehicular")]
    public int? cv_pso_mxmo { get; set; }

    [JsonPropertyName("ToleranciaConfiguracionVehicular")]
    public int? cv_tlrncia { get; set; }

    [JsonPropertyName("ManifiestoOrden")]
    public string? or_mnfsto { get; set; }

    [JsonPropertyName("RemisionOrden")]
    public string? or_rmsion { get; set; }

    [JsonPropertyName("PesoACargarOrden")]
    public int? or_pso_a_crgar { get; set; }

    [JsonPropertyName("IdCiudadOrden")]
    public int? or_rowid_cdad { get; set; }

    [JsonPropertyName("IdCiudad")]
    public int? ci_rowid { get; set; }

    [JsonPropertyName("CodigoCiudad")]
    public string? ci_cdgo { get; set; }

    [JsonPropertyName("NombreCiudad")]
    public string? ci_nmbre { get; set; }

    [JsonPropertyName("IdZonaCargueDescargueOrden")]
    public int? or_rowid_zna_cd { get; set; }

    [JsonPropertyName("IdZonaCargueDescargue")]
    public int? zcd_rowid { get; set; }

    [JsonPropertyName("CodigoZonaCargueDescargue")]
    public string? zcd_cdgo { get; set; }

    [JsonPropertyName("NombreZonaCargueDescargue")]
    public string? zcd_nmbre { get; set; }

    [JsonPropertyName("FechaLimiteSolicitudRetiro")]
    public int? fcha_lmte_slctud_rtro { get; set; }

    [JsonPropertyName("IdEmpaque")]
    public int? em_rowid { get; set; }

    [JsonPropertyName("CodigoEmpaque")]
    public string? em_cdgo { get; set; }

    [JsonPropertyName("NombreEmpaque")]
    public string? em_nmbre { get; set; }

    [JsonPropertyName("MinutosVigenciaReserva")]
    public int? pa_mntos_vgnvia_rsrva { get; set; }

    [JsonPropertyName("IdDeposito")]
    public int? de_rowid { get; set; }

    [JsonPropertyName("CodigoDeposito")]
    public string? de_cdgo { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int? vm_rowid { get; set; }

    [JsonPropertyName("DescripcionVisitaMotonave")]
    public string? vm_dscrpcion { get; set; } 

    [JsonPropertyName("IdTercero")]
    public int? te_rowid { get; set; }

    [JsonPropertyName("CodigoTercero")]
    public string? te_cdgo { get; set; } 

    [JsonPropertyName("NombreTercero")]
    public string? te_nmbre { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? pr_cdgo { get; set; } 

    [JsonPropertyName("NombreProducto")]
    public string? pr_nmbre { get; set; }

    [JsonPropertyName("SaldoKilosDeposito")]
    public int? sldo_klos_dpsto { get; set; }

    [JsonPropertyName("SaldoUnidadesDeposito")]
    public int? sldo_unddes_dpsto { get; set; }

    [JsonPropertyName("CodigoSolicitudRetiro")]
    public string? sr_cdgo { get; set; }

    [JsonPropertyName("PlantaDestinoSolicitudRetiro")]
    public string? sr_plnta_dstno { get; set; }

    [JsonPropertyName("AutorizadoKilosSolicitudRetiro")]
    public int? sr_autrzdo_klos { get; set; }

    [JsonPropertyName("AutorizadoCantidadSolicitudRetiro")]
    public int? sr_autrzdo_cntdad { get; set; }

    [JsonPropertyName("LiberadoKilosSolicitudRetiro")]
    public int? lbrdo_klos_slctud_rtro { get; set; }

    [JsonPropertyName("LiberadoUnidadesSolicitudRetiro")]
    public int? lbrdo_unddes_slctud_rtro { get; set; }

    [JsonPropertyName("SaldoKilosSolicitudRetiro")]
    public int? sldo_klos_slctud_rtro { get; set; }

    [JsonPropertyName("SaldoUnidadesSolicitudRetiro")]
    public int? sldo_unddes_slctud_rtro { get; set; }

    [JsonPropertyName("TotalAutorizadoKilosTransportadora")]
    public int? ttal_autrzdo_klos_trnsprtdra { get; set; }

    [JsonPropertyName("TotalAutorizadoUnidadesTransportadora")]
    public int? ttal_autrzdo_unddes_trnsprtdra { get; set; }

    [JsonPropertyName("LiberadoKilosTransportadora")]
    public int? lbrdo_klos_trnsprtdra { get; set; }

    [JsonPropertyName("LiberadoUnidadesTransportadora")]
    public int? lbrdo_unddes_trnsprtdra { get; set; }

    [JsonPropertyName("RetiradoTransportadora")]
    public int? rtrdo_trnsprtdra { get; set; }

    [JsonPropertyName("SaldoKilosTransportadora")]
    public int? sldo_klos_trnsprtdra { get; set; }

    [JsonPropertyName("SaldoUnidadesTransportadora")]
    public int? sldo_unddes_trnsprtdra { get; set; }

    [JsonPropertyName("ReservaOrden")]
    public string? or_rsrva { get; set; } 

    [JsonPropertyName("LlamadaOrden")]
    public string? or_llmda { get; set; }

    [JsonPropertyName("RadicadaOrden")]
    public string? or_rdcda { get; set; }

    [JsonPropertyName("TransitoOrden")]
    public string? or_trnsto { get; set; } 

    [JsonPropertyName("FechaReservaOrden")]
    public DateTime? or_fcha_rsrva { get; set; }

    [JsonPropertyName("FechaRegistroReservaOrden")]
    public DateTime? or_fcha_rgstro_rsrva { get; set; }

    [JsonPropertyName("FechaPrimerLlamadoOrden")]
    public DateTime? or_fcha_prmer_llmdo { get; set; }

    [JsonPropertyName("FechaUltimoLlamadoOrden")]
    public DateTime? or_fcha_ultmo_llmdo { get; set; }

    [JsonPropertyName("FechaRadicacionOrden")]
    public DateTime? or_fcha_rdccion { get; set; }

    [JsonPropertyName("FechaAnulacionOrden")]
    public DateTime? or_fcha_anlcion { get; set; }

    [JsonPropertyName("ActivaOrden")]
    public bool? or_actva { get; set; }

    [JsonPropertyName("ObservacionesOrden")]
    public string? or_obsrvcnes { get; set; }
}
