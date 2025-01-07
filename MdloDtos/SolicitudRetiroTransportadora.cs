using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SolicitudRetiroTransportadora
{
    [Key]
    [JsonPropertyName("Id")]
    public int? SrtRowid { get; set; }

    [JsonPropertyName("IdSolicitud")]
    public int? SrtRowidSlctudRtro { get; set; }

    [JsonPropertyName("IdTrasnportadora")]
    public int? SrtRowidTrnsprtdra { get; set; }

    [JsonPropertyName("AutorizaKilos")]
    public int? SrtAutrzdoKlos { get; set; }

    [JsonPropertyName("AutorizaUnidades")]
    public int? SrtAutrzdoUnddes { get; set; }

    [JsonPropertyName("DespachoKilos")]
    public int? SrtDspchdoKlos { get; set; }

    [JsonPropertyName("DespachoUnidades")]
    public int? SrtDspchdoUnddes { get; set; }

    [JsonPropertyName("Activa")]
    public bool? SrtActva { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SolicitudRetiroTransportadoraHistorial>? SolicitudRetiroTransportadoraHistorials { get; set; } = new List<SolicitudRetiroTransportadoraHistorial>();

    [JsonIgnore]
    [NotMapped]
    public virtual SolicitudRetiro? SrtRowidSlctudRtroNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Tercero? SrtRowidTrnsprtdraNavigation { get; set; } = null!;


    public string? TeCdgo { get; set; }
    public string? TeNmbre { get; set; }
    public string? TeIdntfccion { get; set; }

    public SolicitudRetiroTransportadora() { }

    public SolicitudRetiroTransportadora(int? SrtRowid, int? SrtRowidSlctudRtro,
        int? SrtRowidTrnsprtdra, int? SrtAutrzdoKlos, int? SrtAutrzdoUnddes, bool? SrtActva, string? TeCdgo, string? TeNmbre, string? TeIdntfccion,
        int? SrtDspchdoKlos,
        int? SrtDspchdoUnddes) {

        this.SrtRowid = SrtRowid;
        this.SrtRowidSlctudRtro = SrtRowidSlctudRtro;
        this.SrtRowidTrnsprtdra = SrtRowidTrnsprtdra;
        this.SrtAutrzdoKlos = SrtAutrzdoKlos;
        this.SrtAutrzdoUnddes = SrtAutrzdoUnddes;
    
        this.SrtActva = SrtActva;
        this.TeCdgo = TeCdgo;
        this.TeNmbre = TeNmbre;
        this.TeIdntfccion = TeIdntfccion;
        this.SrtDspchdoKlos = SrtDspchdoKlos;
        this.SrtDspchdoUnddes = SrtDspchdoUnddes;


    }
}
