using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICertificado
    {
       // public Task<List<dynamic>> ConsultarTerceroCertificado();

        public Task<MdloDtos.TerceroCertificado> IngresarCertificado(MdloDtos.TerceroCertificado _certificado);

    }
}
