using AutoMapper;
using SimhapuriServices.WebApi.Models;

namespace SimhapuriServices.WebApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<FeeDto, Fee>(); // means you want to map from User to UserDTO
        }
    }
}