using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjectTask.Models;
using ProjectTask.Dto;

namespace ProjectTask.App_Start
{
    public class MappingProfile : Profile
    
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();
        }
    }
}