using System;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Domain.Entities;

namespace HSE.Business.MapConfig
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<GoogleRespondDto, GoogleRespond>().ReverseMap();
            CreateMap<GoogleRespond, Object>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<AuthenticateDto, Authenticate>().ReverseMap();
            CreateMap<InstructionTypeDto, InstructionType>().ReverseMap();
            CreateMap<InstructionFormDto, InstructionForm>().ReverseMap();
            CreateMap<EmployeeFormDto, EmployeeForm>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<UserRoleDto, UserRole>().ReverseMap();
            CreateMap<OrganizationBasePermitionMapDto, OrganizationBasePermitionMap>().ReverseMap();
            CreateMap<StructureDto, Structure>().ReverseMap();
            CreateMap<FormShortContentDto, FormShortContent>().ReverseMap();
            CreateMap<LoginLogDto, LoginLog>()
                .ForMember(
                    d => d.CreateDate,
                    opt => opt.MapFrom(src => DateTime.Now + string.Empty)
                ).ReverseMap();
        }
    }
}
