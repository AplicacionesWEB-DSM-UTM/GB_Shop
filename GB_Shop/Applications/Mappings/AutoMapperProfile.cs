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
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.IdReporte)).ReverseMap();

            CreateMap<Denuncia, DenunciaFilter>()
            .ForMember(dest => dest.MotivoDenuncia, opt => opt.MapFrom(src => src.IdMotivo))
            .ForMember(dest => dest.FechaDenuncia, opt => opt.MapFrom(src => src.FechaDen)).ReverseMap();

            CreateMap<Poi, PoiResponse>()
            .ForMember(dest => dest.Distancia, opt => opt.MapFrom(src => src.Rango))
            .ForMember(dest => dest.GeoUbicacion, opt => opt.MapFrom(src => src.GeoUbiDen))
            .ForMember(dest => dest.Confirmaciones, opt => opt.MapFrom(src => src.Confirmar)).ReverseMap();

            CreateMap<Poi, PoiFilter>()
            .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.IdMotivo))
            .ForMember(dest => dest.Confirmacion, opt => opt.MapFrom(src => src.Confirmar))
            .ForMember(dest => dest.Rechazos, opt => opt.MapFrom(src => src.Rechazar));

            CreateMap<PoiFilter, Poi>()
            .ForMember(dest => dest.IdMotivo, opt => opt.MapFrom(src => src.Motivo))
            .ForMember(dest => dest.Confirmar, opt => opt.MapFrom(src => src.Confirmacion))
            .ForMember(dest => dest.Rechazar, opt => opt.MapFrom(src => src.Rechazos));

            CreateMap<Evento, EventosResponses>()
            .ForMember(dest => dest.IdEvento, opt => opt.MapFrom(src => src.IdEven))
            .ForMember(dest => dest.UbicacionEvento, opt => opt.MapFrom(src => src.UbicEven))
            .ForMember(dest => dest.GeoUbicacion, opt => opt.MapFrom(src => src.GeoUbiEve))
            .ForMember(dest => dest.CaracteristicasEvento, opt => opt.MapFrom(src => src.CaractEven)).ReverseMap();


        }
    }
}