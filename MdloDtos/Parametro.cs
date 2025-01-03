using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Parametro
{
    [Key]
    public int PaId { get; set; }

    public string? PaEmprsa { get; set; }

    public int? PaDiasVgnciaClveIntrnos { get; set; }

    public int? PaDiasVgnciaClveExtrnos { get; set; }

    public int? PaClvesAntrres { get; set; }

    public int? PaDiasInctvcionExtrnos { get; set; }

    public string? PaCrreoSrvdor { get; set; }

    public string? PaCrreoUsrio { get; set; }

    public string? PaCrreoClve { get; set; }

    public short? PaCrreoPrto { get; set; }

    public bool? PaCrreoCnxionSgra { get; set; }

    public string? PaUrlPrtalLgstco { get; set; }

    public string? PaNasRuta { get; set; }

    public string? PaNasUsuario { get; set; }
    public string? PaNasClave { get; set; }

    public int? PaNasPuerto { get; set; }

    public int? PaSldoBjoDpsto { get; set; }

    public int? PaSldoBjoSlctudRtro { get; set; }

    public int? PaPsoMxmoACrgar { get; set; }

    public int? PaMntosVgnviaRsrva { get; set; }

    public Parametro() { }

    public Parametro(string PaNasRuta, string PaNasUsuario, string PaNasClave, int? PaNasPuerto)
    {
        this.PaNasRuta = PaNasRuta;
        this.PaNasUsuario = PaNasUsuario;
        this.PaNasClave = PaNasClave;
        this.PaNasPuerto = PaNasPuerto;
    }
}
