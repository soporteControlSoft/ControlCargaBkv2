using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public  interface IVisitaMotonaveBl1
    {
        public Task<MdloDtos.VisitaMotonaveDocumento> IngresarVisitaMotonaveBl1(MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveDocumento_);
        public Task<MdloDtos.VisitaMotonaveDocumento> ActualizarVisitaMotonaveBl1(MdloDtos.VisitaMotonaveDocumento ObjVisitaMotonaveDocumento_);
    }
}
