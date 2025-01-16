using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class OrdenDTO
{
    [Key]
    [JsonPropertyName("Codigo")]
    public int Codigo { get; set; }

    [JsonPropertyName("IdTransportadora")]
    public int IdTransportadora { get; set; }

    [JsonPropertyName("Activa")]
    public bool Activa { get; set; }

    [JsonPropertyName("FechaReserva")]
    public DateTime? FechaReserva { get; set; }

    [JsonPropertyName("FechaRegistroReserva")]
    public DateTime? FechaRegistroReserva { get; set; }

    [JsonPropertyName("CodigoUsuarioReserva")]
    public string? CodigoUsuarioReserva { get; set; }

    [JsonPropertyName("Placa")]
    public string? Placa { get; set; }

    [JsonPropertyName("Remolque")]
    public string? Remolque { get; set; }

    [JsonPropertyName("Manifiesto")]
    public string? Manifiesto { get; set; }

    [JsonPropertyName("Remision")]
    public string? Remision { get; set; }

    [JsonPropertyName("IdentificacionConductor")]
    public string? IdentificacionConductor { get; set; }

    [JsonPropertyName("Llamada")]
    public bool? Llamada { get; set; }

    [JsonPropertyName("Radicada")]
    public bool? Radicada { get; set; }

    [JsonPropertyName("FechaRadicacion")]
    public DateTime? FechaRadicacion { get; set; }

    [JsonPropertyName("IdDeposito")]
    public int? IdDeposito { get; set; }

    [JsonPropertyName("IdSolicitudRetiro")]
    public int? IdSolicitudRetiro { get; set; }

    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? IdConfiguracionVehicular { get; set; }

    [JsonPropertyName("IdCiudad")]
    public int? IdCiudad { get; set; }

    [JsonPropertyName("IdZonaCargueDescargue")]
    public int? IdZonaCargueDescargue { get; set; }

    [JsonPropertyName("RadicaccionHuellaValidada")]
    public bool? RadicaccionHuellaValidada { get; set; }

    [JsonPropertyName("CodigoUsuarioRadicaccion")]
    public string? CodigoUsuarioRadicaccion { get; set; }

    [JsonPropertyName("NumeroLLamadas")]
    public short? NumeroLLamadas { get; set; }

    [JsonPropertyName("FechaAnulacion")]
    public DateTime? FechaAnulacion { get; set; }

    [JsonPropertyName("IdSocidad")]
    public string? IdSocidad { get; set; }

    [JsonPropertyName("VigenciaTurno")]
    public short? VigenciaTurno { get; set; }

    [JsonPropertyName("TurnoValidado")]
    public bool? TurnoValidado { get; set; }

    [JsonPropertyName("PesoACargar")]
    public int? PesoACargar { get; set; }

    [JsonPropertyName("Concepto")]
    public string? Concepto { get; set; }

    [JsonPropertyName("CorrigeTurno")]
    public bool? CorrigeTurno { get; set; }

    [JsonPropertyName("CorrigeTurnoFecha")]
    public DateTime? CorrigeTurnoFecha { get; set; }

    [JsonPropertyName("ValidarVigenciaRadicaccion")]
    public bool? ValidarVigenciaRadicaccion { get; set; }

    [JsonPropertyName("FechaEntradaSociedad")]
    public DateTime? FechaEntradaSociedad { get; set; }

    [JsonPropertyName("UsuarioEntradaSociedad")]
    public string? UsuarioEntradaSociedad { get; set; }

    [JsonPropertyName("FechaPrimerLlamado")]
    public DateTime? FechaPrimerLlamado { get; set; }

    [JsonPropertyName("FechaUltimoLlamado")]
    public DateTime? FechaUltimoLlamado { get; set; }

    [JsonPropertyName("Tipo")]
    public string? Tipo { get; set; }

    [JsonPropertyName("Tercero")]
    public string? Tercero { get; set; }

    [JsonPropertyName("TurnoNumero")]
    public int? TurnoNumero { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? Observaciones { get; set; }

    [JsonPropertyName("Articulo")]
    public string? Articulo { get; set; }

    [JsonPropertyName("FechaSalidaSocidad")]
    public DateTime? FechaSalidaSocidad { get; set; }

    [JsonPropertyName("UsuarioSalidaSociada")]
    public string? UsuarioSalidaSociada { get; set; }

    [JsonPropertyName("UbicacionRadicacion")]
    public string? UbicacionRadicacion { get; set; }

    [JsonPropertyName("TipoCarroceria")]
    public string? TipoCarroceria { get; set; }

    [JsonPropertyName("InterfazInside")]
    public bool? InterfazInside { get; set; }

    [JsonPropertyName("InterfazInsideCancelada")]
    public bool? InterfazInsideCancelada { get; set; }

    [JsonPropertyName("CodigoCausalCancelacion")]
    public string? CodigoCausalCancelacion { get; set; }

    [JsonPropertyName("ObservacionesCancelacion")]
    public string? ObservacionesCancelacion { get; set; }

    [JsonPropertyName("InterfazInsideConError")]
    public bool? InterfazInsideConError { get; set; }

    [JsonPropertyName("InterfazInsideCanceladaConError")]
    public bool? InterfazInsideCanceladaConError { get; set; }

    [JsonPropertyName("IngresoIdInside")]
    public string? IngresoIdInside { get; set; }

    [JsonPropertyName("IngresoId2Inside")]
    public string? IngresoId2Inside { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdCiudadNavegacion")]
    public virtual Ciudad? IdCiudadNavegacion { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdConfiguracionVehicularNavegacion")]
    public virtual ConfiguracionVehicular? IdConfiguracionVehicularNavegacion { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdDepositoNavegacion")]
    public virtual Deposito? IdDepositoNavegacion { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdSolicitudRetiroNavegacion")]
    public virtual SolicitudRetiro? IdSolicitudRetiroNavegacion { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdTransportadoraNavegacion")]
    public virtual Tercero? IdTransportadoraNavegacion { get; set; } = null!;

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdZonaCargueDescargueNavegacion")]
    public virtual ZonaCd? IdZonaCargueDescargueNavegacion { get; set; }
}
