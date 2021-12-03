using System;
using AutoMapper;
using GB_Shop.Domain.Entities;
using GB_Shop.Domain.Dtos.Responses;

namespace GB_Shop.Applications.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Denuncia, DenunciaResponse>()
            .ForMember(dest => dest.FechaDenuncia, opt => opt.MapFrom(src => src.FechaDen))
            .ForMember(dest => dest.MotivoDenuncia, opt=> opt.MapFrom(src => src.IdMotivo))
            .ForMember(dest => dest.DescripcionLugar, opt=> opt.MapFrom(src => src.DescLugar))
            .ForMember(dest => dest.GeoUbicacion, opt => opt.MapFrom(src => src.GeoUbiDen))
            .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.IdFoto))
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.IdReporte));

            CreateMap<Denuncia, DenunciaFilterResponse>()
            .ForMember(dest => dest.MotivoDenuncia, opt => opt.MapFrom(src => src.IdMotivo))
            .ForMember(dest => dest.FechaDenuncia, opt => opt.MapFrom(src => src.FechaDen));

            CreateMap<Poi, PoiResponse>()
            .ForMember(dest => dest.Distancia, opt => opt.MapFrom(src => src.Rango))
            .ForMember(dest => dest.Geo_Ubicacion, opt => opt.MapFrom(src => src.GeoUbiDen))
            .ForMember(dest => dest.Confirmacion, opt => opt.MapFrom(src => src.Confirmar));

            CreateMap<Evento, EventosResponses>()
            .ForMember(dest => dest.IdEvento, opt => opt.MapFrom(src => src.IdEven))
            .ForMember(dest => dest.UbicacionEvento, opt => opt.MapFrom(src => src.UbicEven))
            .ForMember(dest => dest.GeoUbicacion, opt => opt.MapFrom(src => src.GeoUbiEve))
            .ForMember(dest => dest.CaracteristicasEvento, opt => opt.MapFrom(src => src.CaractEven));


        }
    }
}