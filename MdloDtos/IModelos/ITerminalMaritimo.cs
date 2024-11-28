using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITerminalMaritimo
    {
        public Task<List<MdloDtos.TerminalMaritimo>> ListarTerminalMaritimo();

        public Task<List<MdloDtos.TerminalMaritimo>> FiltrarTerminalMaritimoGeneral(String Codigo);
        public Task<List<MdloDtos.TerminalMaritimo>> FiltrarTerminalMaritimoEspecifico(String Codigo);

        public Task<MdloDtos.TerminalMaritimo> IngresarTerminalMaritimo(MdloDtos.TerminalMaritimo ObjTipoIdentificacion);

        public Task<MdloDtos.TerminalMaritimo> EditarTerminalMaritimo(MdloDtos.TerminalMaritimo ObjTipoIdentificacion);

        public Task<MdloDtos.TerminalMaritimo> EliminarTerminalMaritimo(String Codigo);
    }
}
