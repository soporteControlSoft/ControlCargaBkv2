using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class TerceroCertificado
{
    public int? TcRowid { get; set; }

    public string? TcCia { get; set; } = null!;

    public string? TcCdgo { get; set; } = null!;

    public int? TcRowidTrcro { get; set; }

    public string? TcCdgoPrdcto { get; set; } = null!;

    public DateTime? TcFchaVncmnto { get; set; }

    public DateTime? TcFchaCrgue { get; set; }

    public DateTime? TcFchaAprbcion { get; set; }

    public bool? TcAprbdo { get; set; }

    public string? TcCdgoUsrioAprbdo { get; set; }

    public DateTime? TcFchaIncio { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Producto? TcCdgoPrdctoNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? TcCdgoUsrioAprbdoNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? TcCiaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Tercero? TcRowidTrcroNavigation { get; set; } = null!;

    public TerceroCertificado() 
    { 
    
    }



}
