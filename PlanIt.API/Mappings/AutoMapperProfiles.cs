using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;

namespace PlanIt.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Dates, DatesDto>().ReverseMap();
            CreateMap<Dates, AddDatesRequestDto>().ReverseMap();
            CreateMap<UserDto, IdentityUser>().ReverseMap()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.Roles, opt => opt.Ignore()); //Handeling seperatly
            CreateMap<Response, AddResponseDto>().ReverseMap();
            CreateMap<Response, ResponseDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ReverseMap();
            CreateMap<DateAnswer, DateAnswerDto>().ReverseMap();

        }
    }
}
