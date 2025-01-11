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

            CreateMap<Consecutivo, ConsecutivoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, _) => src.CoRowid))
                .ForMember(dest => dest.CodigoCompania, opt => opt.MapFrom((src, _) => src.CoCdgoCiaNavigation?.CiaCdgo))
                .ForMember(dest => dest.NombreCompania, opt => opt.MapFrom((src, _) => src.CoCdgoCiaNavigation?.CiaNmbre))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.CoCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.CoNmbre))
                .ForMember(dest => dest.Contador, opt => opt.MapFrom((src, _) => src.CoCntdor));

            CreateMap<Parametro, ParametroDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, _) => src.PaId))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom((src, _) => src.PaEmprsa))
                .ForMember(dest => dest.DiasVigenciaClaveInternos, opt => opt.MapFrom((src, _) => src.PaDiasVgnciaClveIntrnos))
                .ForMember(dest => dest.DiasVigenciaClaveExternos, opt => opt.MapFrom((src, _) => src.PaDiasVgnciaClveExtrnos))
                .ForMember(dest => dest.ClavesAnteriores, opt => opt.MapFrom((src, _) => src.PaClvesAntrres))
                .ForMember(dest => dest.DiasExternos, opt => opt.MapFrom((src, _) => src.PaDiasInctvcionExtrnos))
                .ForMember(dest => dest.ServidorCorreo, opt => opt.MapFrom((src, _) => src.PaCrreoSrvdor))
                .ForMember(dest => dest.CorreoUsuario, opt => opt.MapFrom((src, _) => src.PaCrreoUsrio))
                .ForMember(dest => dest.CorreoClave, opt => opt.MapFrom((src, _) => src.PaCrreoClve))
                .ForMember(dest => dest.CorreoPuerto, opt => opt.MapFrom((src, _) => src.PaCrreoPrto))
                .ForMember(dest => dest.CorreoConexionSegura, opt => opt.MapFrom((src, _) => src.PaCrreoCnxionSgra))
                .ForMember(dest => dest.URL, opt => opt.MapFrom((src, _) => src.PaUrlPrtalLgstco))
                .ForMember(dest => dest.RutaNas, opt => opt.MapFrom((src, _) => src.PaNasRuta))
                .ForMember(dest => dest.UsuarioNas, opt => opt.MapFrom((src, _) => src.PaNasUsuario))
                .ForMember(dest => dest.ClaveNas, opt => opt.MapFrom((src, _) => src.PaNasClave))
                .ForMember(dest => dest.PuertoNas, opt => opt.MapFrom((src, _) => src.PaNasPuerto))
                .ForMember(dest => dest.SaldoBajoDeposito, opt => opt.MapFrom((src, _) => src.PaSldoBjoDpsto))
                .ForMember(dest => dest.SaldoBajoSolicitudRetiro, opt => opt.MapFrom((src, _) => src.PaSldoBjoSlctudRtro))
                .ForMember(dest => dest.PesoMaximoCargar, opt => opt.MapFrom((src, _) => src.PaPsoMxmoACrgar))
                .ForMember(dest => dest.MinutosVigenciaReserva, opt => opt.MapFrom((src, _) => src.PaMntosVgnviaRsrva)).ReverseMap();

            CreateMap<Clasificacion, ClasificacionDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom((src, _) => src.ClRowid))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.ClNmbre))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom((src, _) => src.ClDscrpcion))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom((src, _) => src.ClFchaCrcion))
               .ForMember(dest => dest.CodigoUsuario, opt => opt.MapFrom((src, _) => src.ClCdgoUsrio))
               .ForMember(dest => dest.Estado, opt => opt.MapFrom((src, _) => src.ClActvo));

            CreateMap<Motonave, MotonaveDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.MoCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.MoNmbre))
                .ForMember(dest => dest.Eslra, opt => opt.MapFrom((src, _) => src.MoEslra))
                .ForMember(dest => dest.Mtrcla, opt => opt.MapFrom((src, _) => src.MoMtrcla))
                .ForMember(dest => dest.MoBndra, opt => opt.MapFrom((src, _) => src.MoBndra))
                .ForMember(dest => dest.CantidadEscotillas, opt => opt.MapFrom((src, _) => src.MoCntdadEsctllas))
                .ForMember(dest => dest.Calado, opt => opt.MapFrom((src, _) => src.MoCldo))
                .ForMember(dest => dest.SituacionPortuaria, opt => opt.MapFrom((src, _) => src.SituacionPortuaria))
                .ForMember(dest => dest.VisitaMotonaves, opt => opt.MapFrom((src, _) => src.VisitaMotonaves))
                ;

            CreateMap<Ciudad, CiudadDTO>()
                .ForMember(dest => dest.IdCiudad, opt => opt.MapFrom((src, _) => src.CiRowid))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.CiCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.CiNmbre))
                .ForMember(dest => dest.IdDepartamento, opt => opt.MapFrom((src, _) => src.CiRowidDprtmnto))
                .ForMember(dest => dest.CiRowidDprtmntoNavigation, opt => opt.MapFrom((src, _) => src.CiRowidDprtmntoNavigation))
                .ForMember(dest => dest.Ordens, opt => opt.MapFrom((src, _) => src.Ordens))
                .ForMember(dest => dest.SolicitudRetiros, opt => opt.MapFrom((src, _) => src.SolicitudRetiros));

            CreateMap<CondicionFacturacion, CondicionFacturacionDTO>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.CfCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.CfNmbre))
                .ForMember(dest => dest.Base, opt => opt.MapFrom((src, _) => src.CfFchaBse))
                .ForMember(dest => dest.Depositos, opt => opt.MapFrom((src, _) => src.Depositos));

            CreateMap<ConfiguracionVehicular, ConfiguracionVehicularDTO>()
                .ForMember(dest => dest.IdConfiguracionVehicular, opt => opt.MapFrom((src, _) => src.CvRowid))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom((src, _) => src.CvCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.CvNmbre))
                .ForMember(dest => dest.PesoMaximo, opt => opt.MapFrom((src, _) => src.CvPsoMxmo))
                .ForMember(dest => dest.Tolerancia, opt => opt.MapFrom((src, _) => src.CvTlrncia))
                .ForMember(dest => dest.CodigoCompania, opt => opt.MapFrom((src, _) => src.CvCdgoCia))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom((src, _) => src.CvActvo))
                .ForMember(dest => dest.CvCdgoCiaNavigation, opt => opt.MapFrom((src, _) => src.CvCdgoCiaNavigation))
                .ForMember(dest => dest.Ordens, opt => opt.MapFrom((src, _) => src.Ordens))
                .ForMember(dest => dest.Vehiculos, opt => opt.MapFrom((src, _) => src.Vehiculos))
                .ForMember(dest => dest.CompaniaCodigo, opt => opt.MapFrom((src, _) => src.CvCdgoCiaNavigation.CiaCdgo))
                .ForMember(dest => dest.CompaniaNombre, opt => opt.MapFrom((src, _) => src.CvCdgoCiaNavigation.CiaNmbre));

            CreateMap<Equipo, EquipoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, _) => src.EqRowid))
                .ForMember(dest => dest.codigoEquipo, opt => opt.MapFrom((src, _) => src.EqCdgo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.EqNmbre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom((src, _) => src.EqDscrpcion))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom((src, _) => src.EqFchaCrcion))
                .ForMember(dest => dest.CodigoUsuario, opt => opt.MapFrom((src, _) => src.EqCdgoUsrio))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom((src, _) => src.EqActvo));

            CreateMap<Evento, EventoDTO>()
                .ForMember(dest => dest.IdEvento, opt => opt.MapFrom((src, _) => src.EvRowid))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.EvNmbre))
                .ForMember(dest => dest.Observacion, opt => opt.MapFrom((src, _) => src.EvObsrvcion))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom((src, _) => src.EvFchaCrcion))
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom((src, _) => src.EvFchaIncio))
                .ForMember(dest => dest.FechaFin, opt => opt.MapFrom((src, _) => src.EvFchaFin))
                .ForMember(dest => dest.Escotilla, opt => opt.MapFrom((src, _) => src.EvEsctlla))
                .ForMember(dest => dest.CodigoClasificacion, opt => opt.MapFrom((src, _) => src.EvRowidClsfccion))
                .ForMember(dest => dest.CodigoResponsable, opt => opt.MapFrom((src, _) => src.EvRowidRspnsble))
                .ForMember(dest => dest.Equipo, opt => opt.MapFrom((src, _) => src.EvEqpo))
                .ForMember(dest => dest.CodigoUsuario, opt => opt.MapFrom((src, _) => src.EvCdgoUsrio))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom((src, _) => src.EvActvo));

            CreateMap<Responsable, ResponsableDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, _) => src.ReRowid))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom((src, _) => src.ReNmbre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom((src, _) => src.ReDscrpcion))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom((src, _) => src.ReFchaCrcion))
                .ForMember(dest => dest.CodigoUsuario, opt => opt.MapFrom((src, _) => src.ReCdgoUsrio))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom((src, _) => src.ReActvo));

        }
    }
}
