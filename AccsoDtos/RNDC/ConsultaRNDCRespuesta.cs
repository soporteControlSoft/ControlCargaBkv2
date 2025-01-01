using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.ImplementacionRNDC
{
    public class ConsultaRNDCRespuesta
    {
        public Resultmd[] resultMD { get; set; }
        public Result[] result { get; set; }
    }

    public class Resultmd
    {
        public string name { get; set; }
        public int type { get; set; }
        public int size { get; set; }
    }

    public class Result
    {
        public string NUMPLACA { get; set; }
        public string NUMPLACAREMOLQUE { get; set; }
        public string NUMIDCONDUCTOR { get; set; }
        public object NUMIDCONDUCTOR2 { get; set; }
        public string ESTADO { get; set; }
        public string FECHAEXPEDICIONMANIFIESTO { get; set; }
        public string NUMNITEMPRESATRANSPORTE { get; set; }
        public string ORIGEN { get; set; }
        public string MANORIGEN { get; set; }
        public string DESTINO { get; set; }
        public string MANDESTINO { get; set; }
        public string CODOPERACIONTRANSPORTE { get; set; }
        public string NOMOPERACIONTRANSPORTE { get; set; }
        public string DESCRIPCIONCORTAPRODUCTO { get; set; }
    }
}
