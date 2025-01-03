using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Wilbert Rivas Granados
    /// Fecha: 03/01/2025
    /// Crud Parametros con DTO
    /// </summary>
    public class Parametros:MdloDtos.IModelos.IParametros
    {
        private readonly CcVenturaContext _dbContext;
        private readonly IMapper _mapper;

        public Parametros(IMapper mapper, MdloDtos.CcVenturaContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        #region Consultar todos los datos de Parametros 
        public async Task<List<MdloDtos.DTO.ParametroDTO>> ListarParametro()
        {
            List<MdloDtos.Parametro> listadoParametro = new List<MdloDtos.Parametro>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from prmtros in _dbContex.Parametros
                                 select prmtros).ToListAsync();        
                var result = _mapper.Map<List<ParametroDTO>>(lst);
                return result;
            }
        }
        #endregion

        #region Consultar todos los datos de Parametros 
        public async Task<List<MdloDtos.DTO.ParametroDTO>> ListarParametroTodos()
        {
            List<MdloDtos.Parametro> listadoParametro = new List<MdloDtos.Parametro>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from prmtros in _dbContex.Parametros
                                 select prmtros).ToListAsync();
                var result = _mapper.Map<List<ParametroDTO>>(lst);
                return result;
            }
        }
        #endregion

        #region actualiza los parametros del sistema
        public async Task<MdloDtos.DTO.ParametroDTO> EditarParametro(MdloDtos.DTO.ParametroDTO parametroDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Parametro parametroExiste = await _dbContex.Parametros.FindAsync(parametroDTO.Id);
                    if (parametroExiste != null)
                    {
                        //_mapper.Map(parametroDTO, parametroExiste);
                        parametroExiste.PaId = parametroDTO.Id;
                        parametroExiste.PaEmprsa = parametroDTO.Empresa;
                        parametroExiste.PaDiasVgnciaClveIntrnos = parametroDTO.DiasVigenciaClaveInternos;
                        parametroExiste.PaDiasVgnciaClveExtrnos = parametroDTO.DiasVigenciaClaveExternos;
                        parametroExiste.PaClvesAntrres = parametroDTO.ClavesAnteriores;
                        parametroExiste.PaDiasInctvcionExtrnos = parametroDTO.DiasExternos;
                        parametroExiste.PaCrreoSrvdor = parametroDTO.ServidorCorreo;
                        parametroExiste.PaCrreoUsrio = parametroDTO.CorreoUsuario;
                        parametroExiste.PaCrreoClve = parametroDTO.CorreoClave;
                        parametroExiste.PaCrreoPrto = parametroDTO.CorreoPuerto;
                        parametroExiste.PaCrreoCnxionSgra = parametroDTO.CorreoConexionSegura;
                        parametroExiste.PaUrlPrtalLgstco = parametroDTO.URL;
                        parametroExiste.PaNasRuta = parametroDTO.RutaNas;
                        parametroExiste.PaNasUsuario = parametroDTO.UsuarioNas;
                        parametroExiste.PaNasClave = parametroDTO.ClaveNas;
                        parametroExiste.PaNasPuerto = parametroDTO.PuertoNas;
                        parametroExiste.PaSldoBjoDpsto = parametroDTO.SaldoBajoDeposito;
                        parametroExiste.PaSldoBjoSlctudRtro = parametroDTO.SaldoBajoSolicitudRetiro;
                        parametroExiste.PaPsoMxmoACrgar = parametroDTO.PesoMaximoCargar;
                        parametroExiste.PaMntosVgnviaRsrva = parametroDTO.MinutosVigenciaReserva;

                        _dbContex.Entry(parametroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        await _dbContex.SaveChangesAsync();
                    }

                    return parametroDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region verificar la existencia de un parametro por su ID
        public async Task<bool> VerificarParametroExiste(int IdParametro)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjParametros = await _dbContex.Parametros.FindAsync(IdParametro);
                    respuesta = ObjParametros != null ? true : false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                _dbContex.Dispose();
                return respuesta;
            }
        }
        #endregion
    }
}
