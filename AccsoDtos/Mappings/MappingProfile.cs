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
               
        }
    }
}
