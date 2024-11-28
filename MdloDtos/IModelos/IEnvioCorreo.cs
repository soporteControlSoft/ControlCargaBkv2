using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEnvioCorreo
    {
        public bool Enviar_Correo_Directo(MdloDtos.CorreoElectronico ObjcorreoElectronico);
    }
}
