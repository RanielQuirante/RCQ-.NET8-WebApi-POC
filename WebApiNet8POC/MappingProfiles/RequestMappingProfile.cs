using AutoMapper;
using WebApiNet8POC.Models.Dtos.Request;
using WebApiNet8POC.Models.Entities;

namespace WebApiNet8POC.MappingProfiles
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