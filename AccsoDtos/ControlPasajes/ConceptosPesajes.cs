using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.ControlPasajes
{
    public class ConceptosPesajes : MdloDtos.IModelos.IConceptosPesajes
    {
        /// <summary>
        /// Acceso a Datos Tabla Conceptos de Pesajes
        /// Daniel Alejandro Lopez.
        /// </summary>
        private readonly CcVenturaContext _dbContext;
        private readonly IMapper _mapper;
        public ConceptosPesajes(IMapper mapper, MdloDtos.CcVenturaContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        //Consultar toda la tabla 
        public async Task<List<ConceptoPesajeDTO>> ConsultarConceptosPesajes()
        {
            try
            {
                var consecutivoLst = await _dbContext.ConceptoPesajes
                    .Include(p => p.CpRowidCnsctvoNavigation)
                    .Include(p => p.CpCdgoTpoCncptoNavigation)
                    .Include(p => p.CpCiaNavigation)
                    .ToListAsync();

                var result = _mapper.Map<List<ConceptoPesajeDTO>>(consecutivoLst);

                return result;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        //Filtrar un consecutivo por el codigo de la compañia
        public async Task<List<ConceptoPesajeDTO>> FiltrarConceptosPesajesPorCompania(string CodigoCompania)
        {
            try
            {
                var consecutivoLst = await _dbContext.ConceptoPesajes
                    .Include(p => p.CpRowidCnsctvoNavigation)
                    .Include(p => p.CpCdgoTpoCncptoNavigation)
                    .Include(p => p.CpCiaNavigation)
                    .Where(p => p.CpCia == CodigoCompania)
                    .ToListAsync();

                var result = _mapper.Map<List<ConceptoPesajeDTO>>(consecutivoLst);

                return result;
            }
            catch (Exception ex)
            {
                return [];
            }
        }


        //Filtrar consectivo por el codigo
        public async Task<List<ConceptoPesajeDTO>> FiltrarConceptosPesajesCodigo(string CodigoConceptos)
        {
            try
            {
                var consecutivoLst = await _dbContext.ConceptoPesajes
                    .Include(p => p.CpRowidCnsctvoNavigation)
                    .Include(p => p.CpCdgoTpoCncptoNavigation)
                    .Include(p => p.CpCiaNavigation)
                    .Where(p => p.CpCdgo == CodigoConceptos)
                    .ToListAsync();

                var result = _mapper.Map<List<ConceptoPesajeDTO>>(consecutivoLst);

                return result;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        //ingresar datos conceptos de pesajes
        public async Task<dynamic> IngresarConceptosPesajes(ConceptoPesajeDTO ObjConceptosPesajes)
        {

            var ObjConceptosIng = new MdloDtos.ConceptoPesaje();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ConsecutivoExiste = await this.VerificarConsecutivo(ObjConceptosIng.CpCdgo, ObjConceptosIng.CpCia);

                    if (ConsecutivoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        DateTime dat = DateTime.Today;
                        ObjConceptosIng.CpCia = ObjConceptosPesajes.CodigoCompania;
                        ObjConceptosIng.CpCdgo = ObjConceptosPesajes.CodigoConceptoPesaje;
                        ObjConceptosIng.CpNmbre = ObjConceptosPesajes.NombreConceptoPesaje;
                        ObjConceptosIng.CpDscrpcion = ObjConceptosPesajes.Descripcion;
                        ObjConceptosIng.CpCdgoTpoCncpto = ObjConceptosPesajes.CodigoTipoConcepto;
                        ObjConceptosIng.CpRowidCnsctvo = ObjConceptosPesajes.IdConsectivo;
                        ObjConceptosIng.CpNtrlza = ObjConceptosPesajes.NaturalezaConceptoPesaje;
                        ObjConceptosIng.CpPdirMdldadDscrgue = ObjConceptosPesajes.ModalidadDescargue;
                        ObjConceptosIng.CpPdirEsctlla = ObjConceptosPesajes.PedirEscotilla;
                        ObjConceptosIng.CpPdirIdScdad = ObjConceptosPesajes.IdSociedad;
                        ObjConceptosIng.CpPdirIdntfccionCndctor = ObjConceptosPesajes.IdentificacionConductor;
                        ObjConceptosIng.CpPdirRmlque = ObjConceptosPesajes.PedirRemolque;
                        ObjConceptosIng.CpPdirOrdenIntrna = ObjConceptosPesajes.OrdenInterna;
                        ObjConceptosIng.CpPdirCnfgrcionVhclar = ObjConceptosPesajes.ConfiguracionVehicular;
                        ObjConceptosIng.CpFchaCrcion = dat;
                        ObjConceptosIng.CpCntrlarSbrepso = ObjConceptosPesajes.ControlSobrePeso;
                        ObjConceptosIng.CpFrmtoImprsion = ObjConceptosPesajes.FormatoImpresion;
                        ObjConceptosIng.CpCnfrmarIdEntrda = ObjConceptosPesajes.ConfirmarEntreada;
                        ObjConceptosIng.CpCnfrmarIdSlda = ObjConceptosPesajes.ConfirmarSalida;
                        ObjConceptosIng.CpVldaMnfsto = ObjConceptosPesajes.ValidaManifiesto;
                        ObjConceptosIng.CpRprtaInsde = ObjConceptosPesajes.ReportaInside;
                        ObjConceptosIng.CpCntrlarCrgue = ObjConceptosPesajes.ControlCargue;
                        ObjConceptosIng.CpActvo = ObjConceptosPesajes.Activo;
                        ObjConceptosIng.CpUsoRsrva = ObjConceptosPesajes.UsoReserva;
                        ObjConceptosIng.CpNmroPsdasTra = ObjConceptosPesajes.NumerosPesadasTra;
                        ObjConceptosIng.CpNmroCpiasTqte = ObjConceptosPesajes.NumeroCopiasTiquete;
                        ObjConceptosIng.CpCmprtdo = ObjConceptosPesajes.Compartido;
                        ObjConceptosIng.CpPdirBdga = ObjConceptosPesajes.PedirBodega;
                        ObjConceptosIng.CpPdirPtio = ObjConceptosPesajes.PedirPatio;
                        ObjConceptosIng.CpPrmtirPrpsje = ObjConceptosPesajes.PermitirPesaje;
                        ObjConceptosIng.CpDsactvarPrgrmcion = ObjConceptosPesajes.DesactivarProgramacion;
                        ObjConceptosIng.CpPrmtroGnral = ObjConceptosPesajes.ParametroGeneral;

                        var res = await _dbContex.ConceptoPesajes.AddAsync(ObjConceptosIng);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjConceptosIng;
            }
        }


        // verifica la existencia de un consecutivo
        public async Task<bool> VerificarConsecutivo(String Codigo , String CodigoEmpresa)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjConsecutivo = await _dbContex.ConceptoPesajes.FindAsync(Codigo, CodigoEmpresa);
                    if (ObjConsecutivo == null)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                _dbContex.Dispose();
                return respuesta;

            }
        }


        //Actualizar consecutivo
        public async Task<dynamic> EditarConceptosPesajes(ConceptoPesajeDTO ObjConceptosPesajes)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjConceptosIng = await _dbContex.ConceptoPesajes.FindAsync(ObjConceptosPesajes.CodigoCompania,ObjConceptosPesajes.CodigoConceptoPesaje);
                    if (ObjConceptosIng != null)
                    {
                        DateTime dat = DateTime.Today;
                        ObjConceptosIng.CpCia = ObjConceptosPesajes.CodigoCompania;
                        ObjConceptosIng.CpCdgo = ObjConceptosPesajes.CodigoConceptoPesaje;
                        ObjConceptosIng.CpNmbre = ObjConceptosPesajes.NombreConceptoPesaje;
                        ObjConceptosIng.CpDscrpcion = ObjConceptosPesajes.Descripcion;
                        ObjConceptosIng.CpCdgoTpoCncpto = ObjConceptosPesajes.CodigoTipoConcepto;
                        ObjConceptosIng.CpRowidCnsctvo = ObjConceptosPesajes.IdConsectivo;
                        ObjConceptosIng.CpNtrlza = ObjConceptosPesajes.NaturalezaConceptoPesaje;
                        ObjConceptosIng.CpPdirMdldadDscrgue = ObjConceptosPesajes.ModalidadDescargue;
                        ObjConceptosIng.CpPdirEsctlla = ObjConceptosPesajes.PedirEscotilla;
                        ObjConceptosIng.CpPdirIdScdad = ObjConceptosPesajes.IdSociedad;
                        ObjConceptosIng.CpPdirIdntfccionCndctor = ObjConceptosPesajes.IdentificacionConductor;
                        ObjConceptosIng.CpPdirRmlque = ObjConceptosPesajes.PedirRemolque;
                        ObjConceptosIng.CpPdirOrdenIntrna = ObjConceptosPesajes.OrdenInterna;
                        ObjConceptosIng.CpPdirCnfgrcionVhclar = ObjConceptosPesajes.ConfiguracionVehicular;
                        ObjConceptosIng.CpFchaCrcion = dat;
                        ObjConceptosIng.CpCntrlarSbrepso = ObjConceptosPesajes.ControlSobrePeso;
                        ObjConceptosIng.CpFrmtoImprsion = ObjConceptosPesajes.FormatoImpresion;
                        ObjConceptosIng.CpCnfrmarIdEntrda = ObjConceptosPesajes.ConfirmarEntreada;
                        ObjConceptosIng.CpCnfrmarIdSlda = ObjConceptosPesajes.ConfirmarSalida;
                        ObjConceptosIng.CpVldaMnfsto = ObjConceptosPesajes.ValidaManifiesto;
                        ObjConceptosIng.CpRprtaInsde = ObjConceptosPesajes.ReportaInside;
                        ObjConceptosIng.CpCntrlarCrgue = ObjConceptosPesajes.ControlCargue;
                        ObjConceptosIng.CpActvo = ObjConceptosPesajes.Activo;
                        ObjConceptosIng.CpUsoRsrva = ObjConceptosPesajes.UsoReserva;
                        ObjConceptosIng.CpNmroPsdasTra = ObjConceptosPesajes.NumerosPesadasTra;
                        ObjConceptosIng.CpNmroCpiasTqte = ObjConceptosPesajes.NumeroCopiasTiquete;
                        ObjConceptosIng.CpCmprtdo = ObjConceptosPesajes.Compartido;
                        ObjConceptosIng.CpPdirBdga = ObjConceptosPesajes.PedirBodega;
                        ObjConceptosIng.CpPdirPtio = ObjConceptosPesajes.PedirPatio;
                        ObjConceptosIng.CpPrmtirPrpsje = ObjConceptosPesajes.PermitirPesaje;
                        ObjConceptosIng.CpDsactvarPrgrmcion = ObjConceptosPesajes.DesactivarProgramacion;
                        ObjConceptosIng.CpPrmtroGnral = ObjConceptosPesajes.ParametroGeneral;

                        _dbContex.ConceptoPesajes.Update(ObjConceptosIng).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjConceptosIng;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }


        /// Elimina un consecutivo
        public async Task<dynamic> EliminarConceptosPesajes(string CodigoEmpresa, string CodigoConceptos)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var consecutivoExiste = await _dbContex.ConceptoPesajes.FindAsync(CodigoEmpresa, CodigoConceptos);
                    if (consecutivoExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(consecutivoExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return consecutivoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
