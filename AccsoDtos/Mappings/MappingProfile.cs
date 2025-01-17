using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;

namespace AccsoDtos.Mappings
{
    /// <summary>
    /// Daniel Lopez
    /// Mapper para la tabla consectivo.
    /// </summary>
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Consecutivo 
            CreateMap<Consecutivo, ConsecutivoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, _) => src.CoRowid))
                .ForMember(dest => dest.CodigoCompania, opt => opt.MapFrom((src, _) => src.CoCdgoCiaNavigation?.CiaCdgo))
                .ForMember(dest => dest.NombreCompania, opt => opt.MapFrom((src, _) => src.CoCdgoCiaNavigation?.CiaNmbre))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.CoCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.CoNmbre))
                .ForMember(dest => dest.Contador, opt => opt.MapFrom((src, _) => src.CoCntdor));

            ///Tipo de Concepto
            CreateMap<TipoConcepto, TipoConceptoDTO>()
               .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.TcCdgo))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.TcNmbre))
               .ForMember(dest => dest.Naturaleza, opt => opt.MapFrom((src, _) => src.TcNtrlza));

            //Concepto Pejsaje
            CreateMap<ConceptoPesaje, ConceptoPesajeDTO>()
                .ForMember(dest => dest.CodigoCompania, opt => opt.MapFrom((src, _) => src.CpCia))
                .ForMember(dest => dest.CodigoConceptoPesaje, opt => opt.MapFrom((src, _) => src.CpCdgo))
                .ForMember(dest => dest.NombreConceptoPesaje, opt => opt.MapFrom((src, _) => src.CpNmbre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom((src, _) => src.CpDscrpcion))
                .ForMember(dest => dest.CodigoTipoConcepto, opt => opt.MapFrom((src, _) => src.CpCdgoTpoCncpto))
                .ForMember(dest => dest.IdConsectivo, opt => opt.MapFrom((src, _) => src.CpRowidCnsctvo))
                .ForMember(dest => dest.NaturalezaConceptoPesaje, opt => opt.MapFrom((src, _) => src.CpNtrlza))
                .ForMember(dest => dest.ModalidadDescargue, opt => opt.MapFrom((src, _) => src.CpPdirMdldadDscrgue))
                .ForMember(dest => dest.PedirEscotilla, opt => opt.MapFrom((src, _) => src.CpPdirEsctlla))
                .ForMember(dest => dest.IdSociedad, opt => opt.MapFrom((src, _) => src.CpPdirIdScdad))
                .ForMember(dest => dest.IdentificacionConductor, opt => opt.MapFrom((src, _) => src.CpPdirIdntfccionCndctor))
                .ForMember(dest => dest.PedirRemolque, opt => opt.MapFrom((src, _) => src.CpPdirRmlque))
                .ForMember(dest => dest.OrdenInterna, opt => opt.MapFrom((src, _) => src.CpPdirOrdenIntrna))
                .ForMember(dest => dest.ConfiguracionVehicular, opt => opt.MapFrom((src, _) => src.CpPdirCnfgrcionVhclar))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom((src, _) => src.CpFchaCrcion))
                .ForMember(dest => dest.ControlSobrePeso, opt => opt.MapFrom((src, _) => src.CpCntrlarSbrepso))
                .ForMember(dest => dest.FormatoImpresion, opt => opt.MapFrom((src, _) => src.CpFrmtoImprsion))
                .ForMember(dest => dest.ConfirmarEntreada, opt => opt.MapFrom((src, _) => src.CpCnfrmarIdEntrda))
                .ForMember(dest => dest.ConfirmarSalida, opt => opt.MapFrom((src, _) => src.CpCnfrmarIdSlda))
                .ForMember(dest => dest.ValidaManifiesto, opt => opt.MapFrom((src, _) => src.CpVldaMnfsto))
                .ForMember(dest => dest.ReportaInside, opt => opt.MapFrom((src, _) => src.CpRprtaInsde))
                .ForMember(dest => dest.ControlCargue, opt => opt.MapFrom((src, _) => src.CpCntrlarCrgue))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom((src, _) => src.CpActvo))
                .ForMember(dest => dest.UsoReserva, opt => opt.MapFrom((src, _) => src.CpUsoRsrva))
                .ForMember(dest => dest.NumerosPesadasTra, opt => opt.MapFrom((src, _) => src.CpNmroPsdasTra))
                .ForMember(dest => dest.NumeroCopiasTiquete, opt => opt.MapFrom((src, _) => src.CpNmroCpiasTqte))
                .ForMember(dest => dest.Compartido, opt => opt.MapFrom((src, _) => src.CpCmprtdo))
                .ForMember(dest => dest.PedirBodega, opt => opt.MapFrom((src, _) => src.CpPdirBdga))
                .ForMember(dest => dest.PedirPatio, opt => opt.MapFrom((src, _) => src.CpPdirPtio))
                .ForMember(dest => dest.PermitirPesaje, opt => opt.MapFrom((src, _) => src.CpPrmtirPrpsje))
                .ForMember(dest => dest.DesactivarProgramacion, opt => opt.MapFrom((src, _) => src.CpDsactvarPrgrmcion))
                .ForMember(dest => dest.ParametroGeneral, opt => opt.MapFrom((src, _) => src.CpPrmtroGnral))
                .ForMember(dest => dest.NombreConsecutivo, opt => opt.MapFrom((src, _) => src.CpRowidCnsctvoNavigation?.CoNmbre))
                .ForMember(dest => dest.CodigoConsecutivo, opt => opt.MapFrom((src, _) => src.CpRowidCnsctvoNavigation?.CoCdgo))
                .ForMember(dest => dest.Contador, opt => opt.MapFrom((src, _) => src.CpRowidCnsctvoNavigation?.CoCntdor))
                .ForMember(dest => dest.NombreTipoConsecutivo, opt => opt.MapFrom((src, _) => src.CpCdgoTpoCncptoNavigation?.TcNmbre))
                .ForMember(dest => dest.NaturalezaTipoConsecutivo, opt => opt.MapFrom((src, _) => src.CpCdgoTpoCncptoNavigation?.TcNtrlza))
                .ForMember(dest => dest.NombreEmpresa, opt => opt.MapFrom((src, _) => src.CpRowidCnsctvoNavigation?.CoNmbre));


        }
    }
}
