using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SpDtlleDpstoAprbcionDTO
{
    
    [JsonPropertyName("SituacionPortuaria_Id")]
    public int? SituacionPortuaria_Id { get; set; }

    [JsonPropertyName("SituacionPortuaria_FechaArribo")]
    public DateTime? SituacionPortuaria_FechaArribo { get; set; }

    [JsonPropertyName("SituacionPortuaria_FechaAtraque")]
    public DateTime? SituacionPortuaria_FechaAtraque { get; set; }

    [JsonPropertyName("SituacionPortuaria_FechaZarpe")]
    public DateTime? SituacionPortuaria_FechaZarpe { get; set; }

    [JsonPropertyName("SituacionPortuaria_FechaCreacion")]
    public DateTime? SituacionPortuaria_FechaCreacion { get; set; }

    [JsonPropertyName("VisitaMotonave_Id")]
    public int? VisitaMotonave_Id { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaCreacion")]
    public DateTime? VisitaMotonave_FechaCreacion { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaInicioOperacion")]
    public DateTime? VisitaMotonave_FechaInicioOperacion { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaFinOperacion")]
    public DateTime? VisitaMotonave_FechaFinOperacion { get; set; }

    [JsonPropertyName("VisitaMotonave_FechaFondeo")]
    public DateTime? VisitaMotonave_FechaFondeo { get; set; }

    [JsonPropertyName("VisitaMotonave_Secuencia")]
    public short? VisitaMotonave_Secuencia { get; set; }

    [JsonPropertyName("VisitaMotonave_Descripcion")]
    public string? VisitaMotonave_Descripcion { get; set; } = null!;

    [JsonPropertyName("Motonave_Codigo")]
    public string? Motonave_Codigo { get; set; } = null!;

    [JsonPropertyName("Motonave_Nombre")]
    public string? Motonave_Nombre { get; set; } = null!;

    [JsonPropertyName("Tercero_Id")]
    public int? Tercero_Id { get; set; }

    [JsonPropertyName("Tercero_Codigo")]
    public string? Tercero_Codigo { get; set; } = null!;

    [JsonPropertyName("Tercero_Nombre")]
    public string? Tercero_Nombre { get; set; }

    [JsonPropertyName("Tercero_Identificacion")]
    public string? Tercero_Identificacion { get; set; }

    [JsonPropertyName("Tercero_TipoIdenticacion")]
    public string? Tercero_TipoIdenticacion { get; set; }

    [JsonPropertyName("Tercero_DigitoVerificacion")]
    public string? Tercero_DigitoVerificacion { get; set; }

    [JsonPropertyName("Tercero_Direccion")]
    public string? Tercero_Direccion { get; set; }

    [JsonPropertyName("Tercero_Telefono")]
    public string? Tercero_Telefono { get; set; }

    [JsonPropertyName("Tercero_Email")]
    public string? Tercero_Email { get; set; }

    [JsonPropertyName("Tercero_Contacto")]
    public string? Tercero_Contacto { get; set; }

    [JsonPropertyName("Producto_Codigo")]
    public string? Producto_Codigo { get; set; } = null!;

    [JsonPropertyName("Producto_Nombre")]
    public string? Producto_Nombre { get; set; }

    [JsonPropertyName("Producto_Estado")]
    public bool? Producto_Estado { get; set; }

    [JsonPropertyName("Producto_SolicitarEmpaque")]
    public bool? Producto_SolicitarEmpaque { get; set; }

    [JsonPropertyName("Producto_CodigoErp")]
    public string? Producto_CodigoErp { get; set; }

    [JsonPropertyName("Producto_SustanciaControlada")]
    public bool? Producto_SustanciaControlada { get; set; }

    [JsonPropertyName("TerceroCertificado_Id")]
    public int? TerceroCertificado_Id { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaCargue")]
    public DateTime? TerceroCertificado_FechaCargue { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaInicio")]
    public DateTime? TerceroCertificado_FechaInicio { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaVencimiento")]
    public DateTime? TerceroCertificado_FechaVencimiento { get; set; }

    [JsonPropertyName("TerceroCertificado_FechaAprobacion")]
    public DateTime? TerceroCertificado_FechaAprobacion { get; set; }

    [JsonPropertyName("TerceroCertificado_Aprobado")]
    public bool? TerceroCertificado_Aprobado { get; set; }

    [JsonPropertyName("Empaque_Id")]
    public int? Empaque_Id { get; set; }

    [JsonPropertyName("Empaque_Codigo")]
    public string? Empaque_Codigo { get; set; }

    [JsonPropertyName("Empaque_Nombre")]
    public string? Empaque_Nombre { get; set; }

    [JsonPropertyName("Empaque_Tara")]
    public decimal? Empaque_Tara { get; set; }

    [JsonPropertyName("Empaque_Activo")]
    public bool? Empaque_Activo { get; set; }

    [Key]
    [JsonPropertyName("Deposito_Id")]
    public int Deposito_Id { get; set; }

    [JsonPropertyName("Deposito_Codigo")]
    public string? Deposito_Codigo { get; set; } = null!;

    [JsonPropertyName("Deposito_Estado")]
    public string? Deposito_Estado { get; set; } = null!;

    [JsonPropertyName("Deposito_CodigoCompania")]
    public string? Deposito_CodigoCompania { get; set; } = null!;

    [JsonPropertyName("Compania_Codigo")]
    public string? Compania_Codigo { get; set; }

    [JsonPropertyName("Compania_Identificacion")]
    public string? Compania_Identificacion { get; set; }

    [JsonPropertyName("Compania_Nombre")]
    public string? Compania_Nombre { get; set; }

    [JsonPropertyName("CompaniaFacturacion_Codigo")]
    public string? CompaniaFacturacion_Codigo { get; set; }

    [JsonPropertyName("CompaniaFacturacion_Identificacion")]
    public string? CompaniaFacturacion_Identificacion { get; set; }

    [JsonPropertyName("CompaniaFacturacion_Nombre")]
    public string? CompaniaFacturacion_Nombre { get; set; }

    [JsonPropertyName("Deposito_SedeDespachoId")]
    public int? Deposito_SedeDespachoId { get; set; }

    [JsonPropertyName("SedeDespacho_Id")]
    public int? SedeDespacho_Id { get; set; }

    [JsonPropertyName("SedeDespacho_Codigo")]
    public string? SedeDespacho_Codigo { get; set; }

    [JsonPropertyName("SedeDespacho_CodigoCompania")]
    public string? SedeDespacho_CodigoCompania { get; set; }

    [JsonPropertyName("SedeDespacho_Nombre")]
    public string? SedeDespacho_Nombre { get; set; }

    [JsonPropertyName("Deposito_CopiasTiquete")]
    public short? Deposito_CopiasTiquete { get; set; }

    [JsonPropertyName("Deposito_FechaAgrupacion")]
    public DateTime? Deposito_FechaAgrupacion { get; set; }

    [JsonPropertyName("Deposito_BLKilosOriginal")]
    public int? Deposito_BLKilosOriginal { get; set; }

    [JsonPropertyName("Deposito_BLUnidadesOriginal")]
    public int? Deposito_BLUnidadesOriginal { get; set; }

    [JsonPropertyName("Deposito_BLKilos")]
    public int? Deposito_BLKilos { get; set; }

    [JsonPropertyName("Deposito_BLUnidades")]
    public int? Deposito_BLUnidades { get; set; }

    [JsonPropertyName("Deposito_NacionalizadoKilos")]
    public int? Deposito_NacionalizadoKilos { get; set; }

    [JsonPropertyName("Deposito_NacionalizadoUnidades")]
    public int? Deposito_NacionalizadoUnidades { get; set; }

    [JsonPropertyName("Deposito_RetenidoKilos")]
    public int? Deposito_RetenidoKilos { get; set; }

    [JsonPropertyName("Deposito_RetenidoUnidades")]
    public string? Deposito_RetenidoUnidades { get; set; }

    [JsonPropertyName("Deposito_EntradasKilos")]
    public int? Deposito_EntradasKilos { get; set; }

    [JsonPropertyName("Deposito_EntradasUnidades")]
    public int? Deposito_EntradasUnidades { get; set; }

    [JsonPropertyName("Deposito_SalidasKilos")]
    public int? Deposito_SalidasKilos { get; set; }

    [JsonPropertyName("Deposito_SalidasUnidades")]
    public int? Deposito_SalidasUnidades { get; set; }

    [JsonPropertyName("Deposito_SaldosKilos")]
    public int? Deposito_SaldosKilos { get; set; }

    [JsonPropertyName("Deposito_SaldosUnidades")]
    public int? Deposito_SaldosUnidades { get; set; }

    [JsonPropertyName("Deposito_Activo")]
    public bool? Deposito_Activo { get; set; }

    [JsonPropertyName("Deposito_Aprobado")]
    public bool? Deposito_Aprobado { get; set; }

    [JsonPropertyName("Deposito_ControlUnidades")]
    public bool? Deposito_ControlUnidades { get; set; }

    [JsonPropertyName("Deposito_Observaciones")]
    public string? Deposito_Observaciones { get; set; }

    [JsonPropertyName("Deposito_Comun")]
    public bool? Deposito_Comun { get; set; }

    [JsonPropertyName("Deposito_Suspendido")]
    public bool? Deposito_Suspendido { get; set; }


}
