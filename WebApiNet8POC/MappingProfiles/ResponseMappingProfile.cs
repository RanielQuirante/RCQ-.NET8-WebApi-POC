using AutoMapper;
using WebApiNet8POC.Models.Dtos.Response;
using WebApiNet8POC.Models.Entities;

namespace WebApiNet8POC.MappingProfiles
{
    public class ResponseMappingProfile : Profile
    {
        public ResponseMappingProfile()
        {
            CreateMap<UserEntity, UserResponseDto>();
            CreateMap<AddressEntity, AddressResponseDto>();
            CreateMap<EmploymentEntity, EmploymentResponseDto>();
        }
    }
}