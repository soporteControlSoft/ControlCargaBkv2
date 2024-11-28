using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpListaBls
{
    [Key]
    public int Secuencia {  get; set; }
    public int? Vmbl_rowid { get; set; }
    public int? Vmdo_rowid { get; set; }
    public int? Vmd_rowid { get; set; }
    public int? Te_rowid { get; set; }
    public string? Te_cdgo_cia { get; set; }
    public string? Te_cdgo { get; set; }
    public string? Te_nmbre { get; set; }
    public string? Pr_cdgo { get; set; }
    public string? Pr_nmbre { get; set; }
    public string? Vmbl_nmro { get; set; }
    public string? Vmbl_rta { get; set; }
    public string? Vmbl_estdo { get; set; }
    public string? Um_cdgo { get; set; }
    public string? Um_nmbre { get; set; }
    public bool? Um_grnel { get; set; }
    public bool? Um_actvo { get; set; }
    public int? Vmbl_cntdad { get; set; }
    public int? Vmbl_tnldas_mtrcas { get; set; }
    public int? Lvnte_vmbl1_rowid { get; set; }
    public string? Lvnte_vmbl1_nmro_lvnte { get; set; }
    public string? Vmdo_nmro { get; set; }
    public string? Vmdo_cdgo_tpo_dcmnto { get; set; }
    public string? Td_nmbre { get; set; }
    public string? Vmdo_rta { get; set; }
    public string? Vmdo_estdo { get; set; }
    public int? Vmdo_lnea { get; set; }
    public int? Vmdo_cntdad { get; set; }
    public bool? Vmd_dpsto_ascdo { get; set; }

}
