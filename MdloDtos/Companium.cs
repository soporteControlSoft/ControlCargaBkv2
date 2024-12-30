using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Companium
{
    [Key]
    [Required(ErrorMessage = "Codigo de la compañia es requerido")]
    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string CiaCdgo { get; set; } = null!;

    [StringLength(15)]
    [JsonPropertyName("Identificacion")]
    public string? CiaIdntfccion { get; set; } = null!;

    [StringLength(80)]
    [JsonPropertyName("Nombre")]
    public string? CiaNmbre { get; set; }

    [StringLength(100)]
    [DataType(DataType.MultilineText)]
    [JsonPropertyName("Direccion")]
    public string? CiaDrccion { get; set; }

    [StringLength(60)]
    [JsonPropertyName("NombreContacto")]
    public string? CiaNmbreCntcto { get; set; }

    [DataType(DataType.EmailAddress)]
    [StringLength(60)]
    [JsonPropertyName("Correo")]
    public string? CiaEmail { get; set; }

    [DataType(DataType.PhoneNumber)]
    [StringLength(60)]
    [JsonPropertyName("Telefono")]
    public string? CiaTlfno { get; set; }

    [StringLength(60)]
    public string? CiaIdSstmaEntrnmnto { get; set; }

    [StringLength(60)]
    [JsonPropertyName("CiaInsideIdUsrio")]
    public string? CiaInsideIdUsrio { get; set; }

    [JsonPropertyName("InsideClave")]
    [DataType(DataType.Text)]
    [StringLength(60)]
    public string? CiaInsideClveUsrio { get; set; }

    [JsonPropertyName("InsideUrl1")]
    [DataType(DataType.Url)]
    [StringLength(100)]
    public string? CiaInsideUrl1 { get; set; }

    [JsonPropertyName("InsideUrl2")]
    [DataType(DataType.Url)]
    [StringLength(100)]
    public string? CiaInsideUrl2 { get; set; }

    [JsonPropertyName("RndUsuario")]
    [StringLength(60)]
    public string? CiaRndcIdUsrio { get; set; }

    [JsonPropertyName("RndClave")]
    [DataType(DataType.Text)]
    [StringLength(60)]
    public string? CiaRndcClveUsrio { get; set; }

    [JsonPropertyName("RndUrl1")]
    [DataType(DataType.Url)]
    [StringLength(100)]
    public string? CiaRndcUrl1 { get; set; }

    [JsonPropertyName("RndUrl2")]
    [DataType(DataType.Url)]
    [StringLength(100)]
    public string? CiaRndcUrl2 { get; set; }

    [JsonPropertyName("Estado")]
    public bool? CiaActva { get; set; }

    [JsonPropertyName("Logo")]
    public byte[]? CiaLgo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<ConceptoPesaje>? ConceptoPesajes { get; set; } = new List<ConceptoPesaje>();
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Auditorium>? Auditoria { get; set; } = new List<Auditorium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Consecutivo>? Consecutivos { get; set; } = new List<Consecutivo>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<AutorizacionRemotum>? AutorizacionRemota { get; set; } = new List<AutorizacionRemotum>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<ConfiguracionVehicular>? ConfiguracionVehiculars { get; set; } = new List<ConfiguracionVehicular>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito>? DepositoDeCiaFctrcionNavigations { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito>? DepositoDeCiaNavigations { get; set; } = new List<Deposito>();

    //public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Empaque> Empaques { get; set; } = new List<Empaque>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<PerfilUsuario> PerfilUsuarios { get; set; } = new List<PerfilUsuario>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<TerceroCertificado> TerceroCertificados { get; set; } = new List<TerceroCertificado>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();

}
