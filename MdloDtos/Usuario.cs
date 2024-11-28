using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Usuario
{
    [Key]
    [JsonPropertyName("Codigo")]
    public string? UsCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    public string? UsNmbre { get; set; }

    [JsonPropertyName("Identificacion")]
    public string? UsIdntfccion { get; set; }

    [JsonPropertyName("IdTercero")]
    public int? UsRowidTrcro { get; set; }

    [JsonPropertyName("Estado")]
    public bool? UsActvo { get; set; }

    [JsonPropertyName("Sper")]
    public bool? UsSper { get; set; }

    [JsonPropertyName("Incles")]
    public string? UsIncles { get; set; }

    [JsonPropertyName("Correo")]
    public string? UsEmail { get; set; }

    [JsonPropertyName("FechaUltimoCambioClave")]
    [DataType(DataType.Date)]
    public DateTime? UsFchaUltmaClve { get; set; }

    [JsonPropertyName("Clave1")]
    public string? UsClve1 { get; set; }

    [JsonPropertyName("Clave2")]
    public string? UsClve2 { get; set; }

    [JsonPropertyName("Clave3")]
    public string? UsClve3 { get; set; }

    [JsonPropertyName("Clave4")]
    public string? UsClve4 { get; set; }

    [JsonPropertyName("Clave5")]
    public string? UsClve5 { get; set; }

    [JsonPropertyName("EstadoBloqueado")]
    public bool? UsBlqdo { get; set; }

    [JsonPropertyName("DebeCambiarClave")]
    public bool? UsDbeCmbiarClve { get; set; }

    [JsonPropertyName("EsSuper")]
    public string? UsSperVldcion { get; set; }

    [JsonPropertyName("NumeroIntentos")]
    public short? UsNmroIntntos { get; set; }

    [JsonPropertyName("FechaUltimoIngreso")]
    public DateTime? UsFchaUltmoIngso { get; set; }

    [JsonPropertyName("Es2fa")]
    public bool? Us2fa { get; set; }

    [JsonPropertyName("Codigo2fa")]
    public string? UsCdgo2fa { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Auditorium>? AuditoriumAuCdgoUsrioAutrzaNavigations { get; set; } = new List<Auditorium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Auditorium>? AuditoriumAuCdgoUsrioNavigations { get; set; } = new List<Auditorium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AutorizacionRemotum>? AutorizacionRemotumArCdgoUsrioAutrzaNavigations { get; set; } = new List<AutorizacionRemotum>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AutorizacionRemotum>? AutorizacionRemotumArCdgoUsrioSlctaNavigations { get; set; } = new List<AutorizacionRemotum>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito>? DepositoDeCdgoUsrioAprbaNavigations { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito>? DepositoDeCdgoUsrioCreaNavigations { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<PerfilUsuario>? PerfilUsuarios { get; set; } = new List<PerfilUsuario>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium>? SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<TerceroCertificado>? TerceroCertificados { get; set; } = new List<TerceroCertificado>();

    [JsonIgnore]
    [NotMapped]
    public virtual Tercero? UsRowidTrcroNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Vehiculo>? Vehiculos { get; set; } = new List<Vehiculo>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl>? VisitaMotonaveBlVmblCdgoUsrioAprbdoNavigations { get; set; } = new List<VisitaMotonaveBl>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl>? VisitaMotonaveBlVmblCdgoUsrioCrgueNavigations { get; set; } = new List<VisitaMotonaveBl>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveComentario>? VisitaMotonaveComentarios { get; set; } = new List<VisitaMotonaveComentario>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDocumento>? VisitaMotonaveDocumentoVmdoCdgoUsrioAprbdoNavigations { get; set; } = new List<VisitaMotonaveDocumento>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDocumento>? VisitaMotonaveDocumentoVmdoCdgoUsrioCrgueNavigations { get; set; } = new List<VisitaMotonaveDocumento>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave>? VisitaMotonaves { get; set; } = new List<VisitaMotonave>();


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Responsable>? Responsables { get; set; } = new List<Responsable>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Evento>? Eventos { get; set; } = new List<Evento>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Equipo>? Equipos { get; set; } = new List<Equipo>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<EstadoHecho>? EstadoHechoes { get; set; } = new List<EstadoHecho>();


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Clasificacion>? Clasificacions { get; set; } = new List<Clasificacion>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SolicitudRetiroAutorizacion> SolicitudRetiroAutorizacions { get; set; } = new List<SolicitudRetiroAutorizacion>();

}
