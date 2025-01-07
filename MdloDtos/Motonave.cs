﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Motonave
{
    public string MoCdgo { get; set; } = null!;

    public string? MoNmbre { get; set; }

    public decimal? MoEslra { get; set; }

    public string? MoMtrcla { get; set; }

    public string? MoBndra { get; set; }

    public short? MoCntdadEsctllas { get; set; }

    public decimal? MoCldo { get; set; }

    public virtual ICollection<SituacionPortuarium> SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();
}
