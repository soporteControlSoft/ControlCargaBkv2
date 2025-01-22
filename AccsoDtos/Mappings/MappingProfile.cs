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

            CreateMap<VwEstdoHchoLstarVstaMtnve, ListadoEstadoHechosDTO>()
                .ForMember(dest => dest.SpCdgoMtnve, opt => opt.MapFrom((src, _) => src.SpCdgoMtnve))
                .ForMember(dest => dest.SpRowid, opt => opt.MapFrom((src, _) => src.SpRowid))
                .ForMember(dest => dest.SpFchaArrbo, opt => opt.MapFrom((src, _) => src.SpFchaArrbo))
                .ForMember(dest => dest.SpFchaAtrque, opt => opt.MapFrom((src, _) => src.SpFchaAtrque))
                .ForMember(dest => dest.SpFchaZrpe, opt => opt.MapFrom((src, _) => src.SpFchaZrpe))
                .ForMember(dest => dest.SpFchaCrcion, opt => opt.MapFrom((src, _) => src.SpFchaCrcion))
                .ForMember(dest => dest.SpCdgoEstdoMtnve, opt => opt.MapFrom((src, _) => src.SpCdgoEstdoMtnve))
                .ForMember(dest => dest.VmRowid, opt => opt.MapFrom((src, _) => src.VmRowid))
                .ForMember(dest => dest.VmScncia, opt => opt.MapFrom((src, _) => src.VmScncia))
                .ForMember(dest => dest.VmDscrpcion, opt => opt.MapFrom((src, _) => src.VmDscrpcion))
                .ForMember(dest => dest.MoCntdadEsctllas, opt => opt.MapFrom((src, _) => src.MoCntdadEsctllas))
                .ForMember(dest => dest.EmCdgo, opt => opt.MapFrom((src, _) => src.EmCdgo))
                .ForMember(dest => dest.EmNmbre, opt => opt.MapFrom((src, _) => src.EmNmbre));

            CreateMap<Sector, SectorDTO>()
                .ForMember(dest => dest.IdSector, opt => opt.MapFrom((src, _) => src.SeRowid))
                .ForMember(dest => dest.IdCodigoSector, opt => opt.MapFrom((src, _) => src.SeCdgo))
                .ForMember(dest => dest.IdNombreSector, opt => opt.MapFrom((src, _) => src.SeNmbre));

            CreateMap<Companium, companiaDTO>()
                .ForMember(dest => dest.CiaCdgo, opt => opt.MapFrom((src, _) => src.CiaCdgo))
                .ForMember(dest => dest.CiaIdntfccion, opt => opt.MapFrom((src, _) => src.CiaIdntfccion))
                .ForMember(dest => dest.CiaNmbre, opt => opt.MapFrom((src, _) => src.CiaNmbre))
                .ForMember(dest => dest.CiaDrccion, opt => opt.MapFrom((src, _) => src.CiaDrccion))
                .ForMember(dest => dest.CiaNmbreCntcto, opt => opt.MapFrom((src, _) => src.CiaNmbreCntcto))
                .ForMember(dest => dest.CiaEmail, opt => opt.MapFrom((src, _) => src.CiaEmail))
                .ForMember(dest => dest.CiaTlfno, opt => opt.MapFrom((src, _) => src.CiaTlfno))
                .ForMember(dest => dest.CiaIdSstmaEntrnmnto, opt => opt.MapFrom((src, _) => src.CiaIdSstmaEntrnmnto))
                .ForMember(dest => dest.CiaInsideIdUsrio, opt => opt.MapFrom((src, _) => src.CiaInsideIdUsrio))
                .ForMember(dest => dest.CiaInsideClveUsrio, opt => opt.MapFrom((src, _) => src.CiaInsideClveUsrio))
                .ForMember(dest => dest.CiaInsideUrl1, opt => opt.MapFrom((src, _) => src.CiaInsideUrl1))
                .ForMember(dest => dest.CiaInsideUrl2, opt => opt.MapFrom((src, _) => src.CiaInsideUrl2))
                .ForMember(dest => dest.CiaRndcIdUsrio, opt => opt.MapFrom((src, _) => src.CiaRndcIdUsrio))
                .ForMember(dest => dest.CiaRndcClveUsrio, opt => opt.MapFrom((src, _) => src.CiaRndcClveUsrio))
                .ForMember(dest => dest.CiaRndcUrl1, opt => opt.MapFrom((src, _) => src.CiaRndcUrl1))
                .ForMember(dest => dest.CiaRndcUrl2, opt => opt.MapFrom((src, _) => src.CiaRndcUrl2))
                .ForMember(dest => dest.CiaActva, opt => opt.MapFrom((src, _) => src.CiaActva))
                .ForMember(dest => dest.CiaLgo, opt => opt.MapFrom((src, _) => src.CiaLgo))
                .ForMember(dest => dest.ConceptoPesajes, opt => opt.MapFrom((src, _) => src.ConceptoPesajes))
                .ForMember(dest => dest.Auditoria, opt => opt.MapFrom((src, _) => src.Auditoria))
                .ForMember(dest => dest.Consecutivos, opt => opt.MapFrom((src, _) => src.Consecutivos))
                .ForMember(dest => dest.AutorizacionRemota, opt => opt.MapFrom((src, _) => src.AutorizacionRemota))
                .ForMember(dest => dest.ConfiguracionVehiculars, opt => opt.MapFrom((src, _) => src.ConfiguracionVehiculars))
                .ForMember(dest => dest.DepositoDeCiaFctrcionNavigations, opt => opt.MapFrom((src, _) => src.DepositoDeCiaFctrcionNavigations))
                .ForMember(dest => dest.DepositoDeCiaNavigations, opt => opt.MapFrom((src, _) => src.DepositoDeCiaNavigations))
                .ForMember(dest => dest.Empaques, opt => opt.MapFrom((src, _) => src.Empaques))
                .ForMember(dest => dest.PerfilUsuarios, opt => opt.MapFrom((src, _) => src.PerfilUsuarios))
                .ForMember(dest => dest.Sedes, opt => opt.MapFrom((src, _) => src.Sedes))
                .ForMember(dest => dest.TerceroCertificados, opt => opt.MapFrom((src, _) => src.TerceroCertificados))
                .ForMember(dest => dest.Terceros, opt => opt.MapFrom((src, _) => src.Terceros))
                .ForMember(dest => dest.VisitaMotonaves, opt => opt.MapFrom((src, _) => src.VisitaMotonaves));

            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.PrCdgo, opt => opt.MapFrom((src, _) => src.PrCdgo))
                .ForMember(dest => dest.PrNmbre, opt => opt.MapFrom((src, _) => src.PrNmbre))
                .ForMember(dest => dest.PrActvo, opt => opt.MapFrom((src, _) => src.PrActvo))
                .ForMember(dest => dest.PrSlctarEmpque, opt => opt.MapFrom((src, _) => src.PrSlctarEmpque))
                .ForMember(dest => dest.PrCdgoErp, opt => opt.MapFrom((src, _) => src.PrCdgoErp))
                .ForMember(dest => dest.PrSstnciaCntrlda, opt => opt.MapFrom((src, _) => src.PrSstnciaCntrlda))
                .ForMember(dest => dest.Depositos, opt => opt.MapFrom((src, _) => src.Depositos));

            CreateMap<PuertoOrigen, PuertoOrigenDTO>()
                .ForMember(dest => dest.PoCdgo, opt => opt.MapFrom((src, _) => src.PoCdgo))
                .ForMember(dest => dest.PoDscrpcion, opt => opt.MapFrom((src, _) => src.PoDscrpcion))
                .ForMember(dest => dest.PoActvo, opt => opt.MapFrom((src, _) => src.PoActvo));

            CreateMap<Pai, PaisDTO>()
                .ForMember(dest => dest.PaCdgo, opt => opt.MapFrom((src, _) => src.PaCdgo))
                .ForMember(dest => dest.PaNmbre, opt => opt.MapFrom((src, _) => src.PaNmbre))
                .ForMember(dest => dest.Departamentos, opt => opt.MapFrom((src, _) => src.Departamentos))
                .ForMember(dest => dest.SituacionPortuaria, opt => opt.MapFrom((src, _) => src.SituacionPortuaria));

            CreateMap<Empaque, EmpaqueDTO>()
                .ForMember(dest => dest.EmRowid, opt => opt.MapFrom((src, _) => src.EmRowid))
                .ForMember(dest => dest.EmCdgoCia, opt => opt.MapFrom((src, _) => src.EmCdgoCia))
                .ForMember(dest => dest.EmCdgo, opt => opt.MapFrom((src, _) => src.EmCdgo))
                .ForMember(dest => dest.EmNmbre, opt => opt.MapFrom((src, _) => src.EmNmbre))
                .ForMember(dest => dest.EmTra, opt => opt.MapFrom((src, _) => src.EmTra))
                .ForMember(dest => dest.EmActvo, opt => opt.MapFrom((src, _) => src.EmActvo))
                .ForMember(dest => dest.Depositos, opt => opt.MapFrom((src, _) => src.Depositos))
                .ForMember(dest => dest.EmCdgoCiaNavigation, opt => opt.MapFrom((src, _) => src.EmCdgoCiaNavigation));

            CreateMap<Vehiculo, VehiculoDTO>()
                .ForMember(dest => dest.VeMtrcla, opt => opt.MapFrom((src, _) => src.VeMtrcla))
                .ForMember(dest => dest.VeFchaSgro, opt => opt.MapFrom((src, _) => src.VeFchaSgro))
                .ForMember(dest => dest.VeFchaRvsion, opt => opt.MapFrom((src, _) => src.VeFchaRvsion))
                .ForMember(dest => dest.VeFchaRgstro, opt => opt.MapFrom((src, _) => src.VeFchaRgstro))
                .ForMember(dest => dest.VeCdgoUsrioCrea, opt => opt.MapFrom((src, _) => src.VeCdgoUsrioCrea))
                .ForMember(dest => dest.VeRowidCnfgrcionVhclar, opt => opt.MapFrom((src, _) => src.VeRowidCnfgrcionVhclar))
                .ForMember(dest => dest.VeMdlo, opt => opt.MapFrom((src, _) => src.VeMdlo))
                .ForMember(dest => dest.VeCdgoUsrioCreaNavigation, opt => opt.MapFrom((src, _) => src.VeCdgoUsrioCreaNavigation))
                .ForMember(dest => dest.VeRowidCnfgrcionVhclarNavigation, opt => opt.MapFrom((src, _) => src.VeRowidCnfgrcionVhclarNavigation));

            CreateMap<Sede, SedeDTO>()
                .ForMember(dest => dest.SeRowid, opt => opt.MapFrom((src, _) => src.SeRowid))
                .ForMember(dest => dest.SeCdgo, opt => opt.MapFrom((src, _) => src.SeCdgo))
                .ForMember(dest => dest.SeCdgoCia, opt => opt.MapFrom((src, _) => src.SeCdgoCia))
                .ForMember(dest => dest.SeNmbre, opt => opt.MapFrom((src, _) => src.SeNmbre))
                .ForMember(dest => dest.SeActvo, opt => opt.MapFrom((src, _) => src.SeActvo))
                .ForMember(dest => dest.SeDpstoAdnro, opt => opt.MapFrom((src, _) => src.SeDpstoAdnro))
                .ForMember(dest => dest.SeCdgoDpstoAdnro, opt => opt.MapFrom((src, _) => src.SeCdgoDpstoAdnro))
                .ForMember(dest => dest.Depositos, opt => opt.MapFrom((src, _) => src.Depositos))
                .ForMember(dest => dest.SeCdgoCiaNavigation, opt => opt.MapFrom((src, _) => src.SeCdgoCiaNavigation))
                .ForMember(dest => dest.ZonaCds, opt => opt.MapFrom((src, _) => src.ZonaCds));

            CreateMap<Departamento, DepartamentoDTO>()
                .ForMember(dest => dest.DeRowid, opt => opt.MapFrom((src, _) => src.DeRowid))
                .ForMember(dest => dest.DeCdgo, opt => opt.MapFrom((src, _) => src.DeCdgo))
                .ForMember(dest => dest.DeNmbre, opt => opt.MapFrom((src, _) => src.DeNmbre))
                .ForMember(dest => dest.DeCdgoPais, opt => opt.MapFrom((src, _) => src.DeCdgoPais))
                .ForMember(dest => dest.Ciudads, opt => opt.MapFrom((src, _) => src.Ciudads))
                .ForMember(dest => dest.DeCdgoPaisNavigation, opt => opt.MapFrom((src, _) => src.DeCdgoPaisNavigation));

            CreateMap<Tercero, TerceroDTO>()
                .ForMember(dest => dest.TeRowid, opt => opt.MapFrom((src, _) => src.TeRowid))
                .ForMember(dest => dest.TeCdgoCia, opt => opt.MapFrom((src, _) => src.TeCdgoCia))
                .ForMember(dest => dest.TeCdgo, opt => opt.MapFrom((src, _) => src.TeCdgo))
                .ForMember(dest => dest.TeNmbre, opt => opt.MapFrom((src, _) => src.TeNmbre))
                .ForMember(dest => dest.TeIdntfccion, opt => opt.MapFrom((src, _) => src.TeIdntfccion))
                .ForMember(dest => dest.TeTpoIdntfccion, opt => opt.MapFrom((src, _) => src.TeTpoIdntfccion))
                .ForMember(dest => dest.TeDv, opt => opt.MapFrom((src, _) => src.TeDv))
                .ForMember(dest => dest.TeDrccion, opt => opt.MapFrom((src, _) => src.TeDrccion))
                .ForMember(dest => dest.TeTlfno, opt => opt.MapFrom((src, _) => src.TeTlfno))
                .ForMember(dest => dest.TeEmail, opt => opt.MapFrom((src, _) => src.TeEmail))
                .ForMember(dest => dest.TeActvo, opt => opt.MapFrom((src, _) => src.TeActvo))
                .ForMember(dest => dest.TeClnte, opt => opt.MapFrom((src, _) => src.TeClnte))
                .ForMember(dest => dest.TePrtclar, opt => opt.MapFrom((src, _) => src.TePrtclar))
                .ForMember(dest => dest.TeFncnrio, opt => opt.MapFrom((src, _) => src.TeFncnrio))
                .ForMember(dest => dest.TeTrnsprtdra, opt => opt.MapFrom((src, _) => src.TeTrnsprtdra))
                .ForMember(dest => dest.TeAgnteMrtmo, opt => opt.MapFrom((src, _) => src.TeAgnteMrtmo))
                .ForMember(dest => dest.TeVnddor, opt => opt.MapFrom((src, _) => src.TeVnddor))
                .ForMember(dest => dest.TeOprdorPrtrio, opt => opt.MapFrom((src, _) => src.TeOprdorPrtrio))
                .ForMember(dest => dest.TeMnjoPrpio, opt => opt.MapFrom((src, _) => src.TeMnjoPrpio))
                .ForMember(dest => dest.TeNmbreCntcto, opt => opt.MapFrom((src, _) => src.TeNmbreCntcto))
                .ForMember(dest => dest.TeCdgoGrpoTrcro, opt => opt.MapFrom((src, _) => src.TeCdgoGrpoTrcro))
                .ForMember(dest => dest.TeAgnciaAdna, opt => opt.MapFrom((src, _) => src.TeAgnciaAdna))
                .ForMember(dest => dest.TeOprdorScndrio, opt => opt.MapFrom((src, _) => src.TeOprdorScndrio))
                .ForMember(dest => dest.Conductors, opt => opt.MapFrom((src, _) => src.Conductors))
                .ForMember(dest => dest.DepositoDeRowidTrcroFctrcionNavigations, opt => opt.MapFrom((src, _) => src.DepositoDeRowidTrcroFctrcionNavigations))
                .ForMember(dest => dest.DepositoDeRowidTrcroNavigations, opt => opt.MapFrom((src, _) => src.DepositoDeRowidTrcroNavigations))
                .ForMember(dest => dest.Ordens, opt => opt.MapFrom((src, _) => src.Ordens))
                .ForMember(dest => dest.SituacionPortuaria, opt => opt.MapFrom((src, _) => src.SituacionPortuaria))
                .ForMember(dest => dest.SituacionPortuariaDetalleSpdRowidOprdorPrtrioNavigations, opt => opt.MapFrom((src, _) => src.SituacionPortuariaDetalleSpdRowidOprdorPrtrioNavigations))
                .ForMember(dest => dest.SituacionPortuariaDetalleSpdRowidTrcroNavigations, opt => opt.MapFrom((src, _) => src.SituacionPortuariaDetalleSpdRowidTrcroNavigations))
                .ForMember(dest => dest.TeCdgoCiaNavigation, opt => opt.MapFrom((src, _) => src.TeCdgoCiaNavigation))
                .ForMember(dest => dest.TeCdgoGrpoTrcroNavigation, opt => opt.MapFrom((src, _) => src.TeCdgoGrpoTrcroNavigation))
                .ForMember(dest => dest.TeTpoIdntfccionNavigation, opt => opt.MapFrom((src, _) => src.TeTpoIdntfccionNavigation))
                .ForMember(dest => dest.TerceroCertificados, opt => opt.MapFrom((src, _) => src.TerceroCertificados))
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom((src, _) => src.Usuarios))
                .ForMember(dest => dest.VisitaMotonaveDetalles, opt => opt.MapFrom((src, _) => src.VisitaMotonaveDetalles))
                .ForMember(dest => dest.VisitaMotonaves, opt => opt.MapFrom((src, _) => src.VisitaMotonaves))
                .ForMember(dest => dest.SolicitudRetiroAutorizacions, opt => opt.MapFrom((src, _) => src.SolicitudRetiroAutorizacions))
                .ForMember(dest => dest.SolicitudRetiroTransportadoras, opt => opt.MapFrom((src, _) => src.SolicitudRetiroTransportadoras));
        }
    }
}
