using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class HopProfile : Profile
    {
        public HopProfile()
        {
            CreateMap<Hop, HopDto>().ReverseMap();
        }
    }
}
