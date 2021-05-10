using AutoMapper;
using RegisterLogin.Api.Data.Entities;
using RegisterLogin.Api.Domain.Models.Request;
using RegisterLogin.Api.Domain.Models.Response;

namespace RegisterLogin.Api.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginRequest, LoginEntity>().ReverseMap(); //Mapeamento entre duas classes, pois podem ter Parametros da entity que não tem na request
            CreateMap<LoginEntity, LoginResponse>().ReverseMap();
            CreateMap<LoginUpdateRequest, LoginEntity>().ReverseMap();
        }
       
    }
}

