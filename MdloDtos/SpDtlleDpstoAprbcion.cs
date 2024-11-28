using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpDtlleDpstoAprbcion
{
    
    [JsonPropertyName("SituacionPortuaria_Id")]
    public int? SpRowid { get; set; }

    [JsonPropertyName("SituacionPortuaria_FechaArribo")]
    public DateTime? SpFchaArrbo { get; set; }
    [JsonPropertyName("SituacionPortuaria_FechaAtraque")]
    public DateTime? SpFchaAtrque { get; set; }

    [JsonPropertyName("SituacionPortuaria_FechaZarpe")]
    public DateTime? SpFchaZrpe { get; set; }
    [JsonPropertyName("SituacionPortuaria_FechaCreacion")]
    public DateTime? SpFchaCrcion { get; set; }

    [JsonPropertyName("VisitaMotonave_Id")]
    public int? VmRowid { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaCreacion")]
    public DateTime? VmFchaCrcion { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaInicioOperacion")]
    public DateTime? VmFchaIncioOprcion { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaFinOperacion")]
    public DateTime? VmFchaFinOprcion { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaFondeo")]
    public DateTime? VmFchaFndeo { get; set; }

    [JsonPropertyName("VisitaMotonave_Secuencia")]
    public short? VmScncia { get; set; }

    [JsonPropertyName("VisitaMotonave_Descripcion")]
    public string? VmDscrpcion { get; set; } = null!;

    [JsonPropertyName("Motonave_Codigo")]
    public string? MoCdgo { get; set; } = null!;

    [JsonPropertyName("Motonave_Nombre")]
    public string? MoNombre { get; set; } = null!;

    [JsonPropertyName("Tercero_Id")]
    public int? TeRowid { get; set; }

    [JsonPropertyName("Tercero_Codigo")]
    public string? TeCdgo { get; set; } = null!;

    [JsonPropertyName("Tercero_Nombre")]
    public string? TeNmbre { get; set; }

    [JsonPropertyName("Tercero_Identificacion")]
    public string? TeIdntfccion { get; set; }

    [JsonPropertyName("Tercero_TipoIdenticacion")]
    public string? TeTpoIdntfccion { get; set; }

    [JsonPropertyName("Tercero_DigitoVerificacion")]
    public string? TeDv { get; set; }

    [JsonPropertyName("Tercero_Direccion")]
    public string? TeDrccion { get; set; }

    [JsonPropertyName("Tercero_Telefono")]
    public string? TeTlfno { get; set; }

    [JsonPropertyName("Tercero_Email")]
    public string? TeEmail { get; set; }

    [JsonPropertyName("Tercero_Contacto")]
    public string? TeNmbreCntcto { get; set; }

    [JsonPropertyName("Producto_Codigo")]
    public string? PrCdgo { get; set; } = null!;

    [JsonPropertyName("Producto_Nombre")]
    public string? PrNmbre { get; set; }

    [JsonPropertyName("Producto_Estado")]
    public bool? PrActvo { get; set; }

    [JsonPropertyName("Producto_SolicitarEmpaque")]
    public bool? PrSlctarEmpque { get; set; }

    [JsonPropertyName("Producto_CodigoErp")]
    public string? PrCdgoErp { get; set; }

    [JsonPropertyName("Producto_SustanciaControlada")]
    public bool? PrSstnciaCntrlda { get; set; }

    [JsonPropertyName("TerceroCertificado_Id")]
    public int? TcRowid { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaCargue")]
    public DateTime? TcFchaCrgue { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaInicio")]
    public DateTime? TcFchaIncio { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaVencimiento")]
    public DateTime? TcFchaVncmnto { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaAprobacion")]
    public DateTime? TcFchaAprbcion { get; set; }

    [JsonPropertyName("TerceroCertificado_Aprobado")]
    public bool? TcAprbdo { get; set; }

    [JsonPropertyName("Empaque_Id")]
    public int? EmRowid { get; set; }

    [JsonPropertyName("Empaque_Codigo")]
    public string? EmCdgo { get; set; }

    [JsonPropertyName("Empaque_Nombre")]
    public string? EmNmbre { get; set; }

    [JsonPropertyName("Empaque_Tara")]
    public decimal? EmTra { get; set; }

    [JsonPropertyName("Empaque_Activo")]
    public bool? EmActvo { get; set; }

    [Key]
    [JsonPropertyName("Deposito_Id")]
    public int DeRowid { get; set; }

    [JsonPropertyName("Deposito_Codigo")]
    public string? DeCdgo { get; set; } = null!;

    [JsonPropertyName("Deposito_Estado")]
    public string? DeEstdo { get; set; } = null!;

    [JsonPropertyName("Deposito_CodigoCompania")]
    public string? DeCia { get; set; } = null!;

    [JsonPropertyName("Compania_Codigo")]
    public string? CiaCdgo { get; set; }

    [JsonPropertyName("Compania_Identificacion")]
    public string? CiaIdntfccion { get; set; }

    [JsonPropertyName("Compania_Nombre")]
    public string? CiaNmbre { get; set; }

    [JsonPropertyName("CompaniaFacturacion_Codigo")]
    public string? CiaCdgoFacturacion { get; set; }

    [JsonPropertyName("CompaniaFacturacion_Identificacion")]
    public string? CiaIdntfccionFacturacion { get; set; }

    [JsonPropertyName("CompaniaFacturacion_Nombre")]
    public string? CiaNmbreFacturacion { get; set; }

    [JsonPropertyName("Deposito_SedeDespachoId")]
    public int? DeRowidSdeDspcho { get; set; }

    [JsonPropertyName("SedeDespacho_Id")]
    public int? SeRowid { get; set; }

    [JsonPropertyName("SedeDespacho_Codigo")]
    public string? SeCdgo { get; set; }

    [JsonPropertyName("SedeDespacho_CodigoCompania")]
    public string? SeCdgoCia { get; set; }

    [JsonPropertyName("SedeDespacho_Nombre")]
    public string? SeNmbre { get; set; }

    [JsonPropertyName("Deposito_CopiasTiquete")]
    public short? DeCpiasTqte { get; set; }

    [JsonPropertyName("Deposito_FechaAgrupacion")]
    public DateTime? DeFchaAgrpcion { get; set; }

    [JsonPropertyName("Deposito_BLKilosOriginal")]
    public int? DeBlKlosOrgnal { get; set; }

    [JsonPropertyName("Deposito_BLUnidadesOriginal")]
    public int? DeBlUnddesOrgnal { get; set; }

    [JsonPropertyName("Deposito_BLKilos")]
    public int? DeBlKlos { get; set; }

    [JsonPropertyName("Deposito_BLUnidades")]
    public int? DeBlUnddes { get; set; }

    [JsonPropertyName("Deposito_NacionalizadoKilos")]
    public int? DeNcnlzdoKlos { get; set; }

    [JsonPropertyName("Deposito_NacionalizadoUnidades")]
    public int? DeNcnlzdoUnddes { get; set; }

    [JsonPropertyName("Deposito_RetenidoKilos")]
    public int? DeRtndoKlos { get; set; }

    [JsonPropertyName("Deposito_RetenidoUnidades")]
    public string? DeRtndoUnddes { get; set; }

    [JsonPropertyName("Deposito_EntradasKilos")]
    public int? DeEntrdasKlos { get; set; }

    [JsonPropertyName("Deposito_EntradasUnidades")]
    public int? DeEntrdasUnddes { get; set; }

    [JsonPropertyName("Deposito_SalidasKilos")]
    public int? DeSldasKlos { get; set; }

    [JsonPropertyName("Deposito_SalidasUnidades")]
    public int? DeSldasUnddes { get; set; }

    [JsonPropertyName("Deposito_SaldosKilos")]
    public int? DeSldoKlos { get; set; }

    [JsonPropertyName("Deposito_SaldosUnidades")]
    public int? DeSldoUnddes { get; set; }

    [JsonPropertyName("Deposito_Activo")]
    public bool? DeActvo { get; set; }

    [JsonPropertyName("Deposito_Aprobado")]
    public bool? DeAprbdo { get; set; }

    [JsonPropertyName("Deposito_ControlUnidades")]
    public bool? DeCntrolUnddes { get; set; }

    [JsonPropertyName("Deposito_Observaciones")]
    public string? DeObsrvcnes { get; set; }

    [JsonPropertyName("Deposito_Comun")]
    public bool? DeCmun { get; set; }

    [JsonPropertyName("Deposito_Suspendido")]
    public bool? DeSspnddo { get; set; }


}
