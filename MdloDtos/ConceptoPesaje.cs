using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class ConceptoPesaje
{
    public string CpCia { get; set; } = null!;

    public string CpCdgo { get; set; } = null!;

    public string CpNmbre { get; set; } = null!;

    public string CpDscrpcion { get; set; } = null!;

    public string CpCdgoTpoCncpto { get; set; } = null!;

    public int CpRowidCnsctvo { get; set; }

    public string CpNtrlza { get; set; } = null!;

    public bool? CpPdirMdldadDscrgue { get; set; }

    public bool? CpPdirEsctlla { get; set; }

    public bool? CpPdirIdScdad { get; set; }

    public bool? CpPdirIdntfccionCndctor { get; set; }

    public bool? CpPdirRmlque { get; set; }

    public bool? CpPdirOrdenIntrna { get; set; }

    public bool? CpPdirCnfgrcionVhclar { get; set; }

    public DateTime CpFchaCrcion { get; set; }

    public bool? CpCntrlarSbrepso { get; set; }

    public string? CpFrmtoImprsion { get; set; }

    public bool? CpCnfrmarIdEntrda { get; set; }

    public bool? CpCnfrmarIdSlda { get; set; }

    public bool? CpVldaMnfsto { get; set; }

    public bool? CpRprtaInsde { get; set; }

    public bool? CpCntrlarCrgue { get; set; }

    public bool? CpActvo { get; set; }

    public bool? CpUsoRsrva { get; set; }

    public bool? CpUsoBscla { get; set; }

    public short? CpNmroPsdasTra { get; set; }

    public short? CpNmroCpiasTqte { get; set; }

    public bool? CpCmprtdo { get; set; }

    public bool? CpPdirBdga { get; set; }

    public bool? CpPdirPtio { get; set; }

    public bool? CpPrmtirPrpsje { get; set; }

    public bool? CpDsactvarPrgrmcion { get; set; }

    public string? CpPrmtroGnral { get; set; }

    public virtual TipoConcepto CpCdgoTpoCncptoNavigation { get; set; } = null!;

    public virtual Companium CpCiaNavigation { get; set; } = null!;

    public virtual Consecutivo CpRowidCnsctvoNavigation { get; set; } = null!;
}
