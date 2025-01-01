using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IReserva
    {
        public Task<List<MdloDtos.VwMdloRsrvaLstarVstaMtnve>> ConsultarVisitaMotonave(String codigoCompania);

        public Task<List<MdloDtos.VwMdloRsrvaLstarDpsto>> ConsultarDeposito(int idVisitaMotonave);

        public Task<List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>> ConsultarSolicitudRetiroModal(int idDeposito, int idTransportadora);

    }
}
