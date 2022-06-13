using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class FieldProfiles : Profile
    {
        public FieldProfiles()
        {
            CreateMap<Field, FieldDto>().ReverseMap();
        }
    }
}
