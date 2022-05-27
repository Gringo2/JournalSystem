using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
