using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos
{
    public partial class Comentario
    {
        public DateTime? fechaHoraIngreso { set; get; }

        public MdloDtos.Usuario? usuario { set; get; } = null!;

        public string? comentario { set; get; } = null!;

        public string? codigoUsuario { set; get; }

        public int? CodigoVisitaMotonaveDocumento {set; get; }   
    }
}
