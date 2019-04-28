using System;
using AutoMapper;
using ElearningApp.Data.Entities;
using ELearnngApp.Domain.ApiRequestModels;

namespace ELearnngApp.Domain.AutomapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentRequest, Student>();
        }
    }
}
