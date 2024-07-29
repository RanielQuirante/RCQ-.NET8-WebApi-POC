using AutoMapper;
using StradaTechnicalInterview.Models.Dtos.Request;
using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.MappingProfiles
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            CreateMap<AddressEntity, AddressRequestDto>().ReverseMap();
            CreateMap<EmploymentEntity, EmploymentRequestDto>().ReverseMap();
            CreateMap<UserEntity, UserRequestDto>().ReverseMap();
        }
    }
}