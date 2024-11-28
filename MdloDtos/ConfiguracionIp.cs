using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class ConfiguracionIp
{
    public int CiRowid { get; set; }

    public string CiIpPrvdor { get; set; } = null!;

    public int CiPrtoIp { get; set; }

    public string CiDscrpcionPrvdor { get; set; } = null!;

    public short CiTpo { get; set; }

    public string CiDscrpcionTpo { get; set; } = null!;
}
