using AutoMapper;
using Newtonsoft.Json;
using payment_provider_adapter.CustomResponses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace payment_provider_adapter.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<HttpResponseMessage, ErrorResponse>()
            .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => src.StatusCode))
            .ForMember(dest => dest.IsSuccessStatusCode, opt => opt.MapFrom(src => src.IsSuccessStatusCode));

            CreateMap<HttpResponseMessage, CreatePaymentResponse>()
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.IsSuccessStatusCode, opt => opt.MapFrom(src => src.IsSuccessStatusCode));

            CreateMap<HttpResponseMessage, ConfirmPaymentResponse>()
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.IsSuccessStatusCode, opt => opt.MapFrom(src => src.IsSuccessStatusCode));

            CreateMap<HttpResponseMessage, StatusPaymentResponse>()
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.IsSuccessStatusCode, opt => opt.MapFrom(src => src.IsSuccessStatusCode));
        }
    }
}
