using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpListarEstadosHecho
{
    [Key]
    public int eh_rowid {  get; set; }
    public string? eh_obsrvcion { get; set; }
    public DateTime? eh_fcha_crcion { get; set; }
    public DateTime? eh_fcha_incio { get; set; }
    public DateTime? eh_fcha_fin { get; set; }
    public int? eh_esctlla { get; set; }
    public int? eh_rowid_evnto { get; set; }
    public string? ev_nmbre { get; set; }
    public int? eh_rowid_eqpo { get; set; }
    public string? eq_nmbre { get; set; }
    public int? eh_rowid_sctor { get; set; }
    public string? se_nmbre { get; set; }
    public int? eh_rowid_zna_cd { get; set; }
    public string? zcd_nmbre { get; set; }
    public int? eh_rowid_vsta_mtnve { get; set; }
    public string? vm_dscrpcion { get; set; }
    public string? eh_cdgo_usrio { get; set; }
    public string? us_nmbre { get; set; }
    public string? eh_estdo { get; set; }
}
