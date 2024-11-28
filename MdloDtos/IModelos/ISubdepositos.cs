using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISubdepositos
    {
        public Task<List<MdloDtos.WvConsultaDepositosSubdeposito>> ConsultarDepositosSegunSubDeposito(int Visita,string CodigoProducto);

        public Task<List<MdloDtos.VwConsultarProductosSubdeposito>> ConsultarProductoSubDeposito(int idvisita);

        public Task<List<MdloDtos.VwConsultarSubdeposito>> ConsultarSubDeposito(string codigoDepositoPadre);

        public Task<MdloDtos.Deposito> IngresarSubDeposito(MdloDtos.Deposito _subdeposito);
    }
}
