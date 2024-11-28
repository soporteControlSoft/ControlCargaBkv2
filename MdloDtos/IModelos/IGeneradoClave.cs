using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IGeneradoClave
    {
        public string generarContraseñaAleatoria(int digitos);
    }
}
