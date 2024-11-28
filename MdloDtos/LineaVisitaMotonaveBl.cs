using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos
{
    public partial class LineaVisitaMotonaveBl
    {
        [NotMapped]
        public MdloDtos.VisitaMotonaveDocumento VisitaMotonaveDocumentoUno { get; set; }

        [NotMapped]
        public MdloDtos.VisitaMotonaveDocumento VisitaMotonaveDocumentoDos {  get; set; }

        [NotMapped]
        public MdloDtos.VisitaMotonaveBl1 VisitaMotonaveBl1 { get; set; }

    }
}
