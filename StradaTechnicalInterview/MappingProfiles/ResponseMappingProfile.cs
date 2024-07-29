using AutoMapper;
using StradaTechnicalInterview.Models.Dtos.Response;
using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.MappingProfiles
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