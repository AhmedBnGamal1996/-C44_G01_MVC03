using AutoMapper;
using Demo.BusinessLogic.DTOS.EmployeeDTOS;
using Demo.DataAccess.Models.EmployeeModule;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Mappings
{
    public class MappingProfile : Profile
    {


        public MappingProfile()
        {




            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
            .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType));


            CreateMap<Employee, EmployeeDetailsDto>()
            .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
            .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
            .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));



            CreateMap<CreatedEmployeeDto, Employee>()
            .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue))); 



            CreateMap<UpdatedEmployeeDto , Employee>()
           .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));




            // CreateMap<CreatedEmployeeDto, Employee>();


        }
    }
}
