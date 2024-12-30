using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SolicitudRetiroAutorizacion
{
    [Key]
    [JsonPropertyName("IdSolicitudAutorizacion")]
    public int? SraRowid { get; set; }

    [JsonPropertyName("idSolicitudRetiro")]
    public int? SraRowidSlctudRtro { get; set; }

    [JsonPropertyName("IdTransportadora")]
    public int? SraRowidTrnsprtdra { get; set; }

    [JsonPropertyName("Kilos")]
    public int? SraAutrzdoKlos { get; set; }

    [JsonPropertyName("Unidades")]
    public int? SraAutrzdoUnddes { get; set; }

    [JsonPropertyName("fechaAutorizacion")]
    public DateTime? SraFcha { get; set; }

    [JsonPropertyName("CodigoUsuario")]
    public string? SraCdgoUsrio { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SolicitudRetiroAutorizacionHistorial>? SolicitudRetiroAutorizacionHistorials { get; set; } = new List<SolicitudRetiroAutorizacionHistorial>();

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? SraCdgoUsrioNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual SolicitudRetiro? SraRowidSlctudRtroNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Tercero? SraRowidTrnsprtdraNavigation { get; set; } = null!;

    public string? Nombretercero { get; set; }

    public SolicitudRetiroAutorizacion() { }


    public SolicitudRetiroAutorizacion(int? SraRowid, int? SraRowidSlctudRtro, int? SraRowidTrnsprtdra, int? SraAutrzdoKlos, int? SraAutrzdoUnddes, DateTime? SraFcha,
       string? SraCdgoUsrio, string? Nombretercero)
    {

        this.SraRowid = SraRowid;
        this.SraRowidSlctudRtro = SraRowidSlctudRtro;
        this.SraAutrzdoKlos = SraAutrzdoKlos;
        this.SraAutrzdoUnddes = SraAutrzdoUnddes;
        this.SraFcha = SraFcha;
        this.SraCdgoUsrio = SraCdgoUsrio;
        this.Nombretercero = Nombretercero;

    }

}
