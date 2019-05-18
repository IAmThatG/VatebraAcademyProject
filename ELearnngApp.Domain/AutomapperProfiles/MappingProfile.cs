using System;
using AutoMapper;
using ElearningApp.Data.Entities;
using ELearnngApp.Domain.ApiRequestModels;
using Microsoft.AspNetCore.Identity;

namespace ELearnngApp.Domain.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentRequest, Student>()
                .ForMember(des => des.MaticNumber, opt => opt.MapFrom(src => src.MatricNumber));
            CreateMap<SignUpRequest, BaseUser>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.Username));
            CreateMap<SignInRequest, BaseUser>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.Username));
        }
    }
}
