using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IAuditoria
    {
        public Task<MdloDtos.Auditorium> IngresarAuditoria(MdloDtos.Auditorium _Auditorium);

    }
}
