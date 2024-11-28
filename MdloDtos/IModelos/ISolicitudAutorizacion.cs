using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISolicitudAutorizacion
    {
        public Task<MdloDtos.AutorizacionRemotum> IngresarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum _AutorizacionRemotum);
        public Task<MdloDtos.AutorizacionRemotum> EditarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum _AutorizacionRemotum);
        public Task<MdloDtos.AutorizacionRemotum> ConfirmarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum _AutorizacionRemotum);
    }
}
