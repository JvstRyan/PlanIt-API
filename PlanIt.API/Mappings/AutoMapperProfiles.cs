using AutoMapper;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;

namespace PlanIt.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Dates, DatesDto>().ReverseMap();
        }
    }
}
