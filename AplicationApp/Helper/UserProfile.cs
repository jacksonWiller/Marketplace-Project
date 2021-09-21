using AplicationApp.Dtos;
using AutoMapper;
using Domain.Entity;
using Domain.Identity;

namespace AplicationApp.Helper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            //  CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}