using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class PaperProfile:Profile
    {
        public PaperProfile()
        {
            CreateMap<Paper,PaperDto>().ReverseMap();
        }
    }
}
