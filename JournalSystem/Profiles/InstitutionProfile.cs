using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class InstitutionProfile:Profile
    {
        public InstitutionProfile()
        {
            CreateMap<Institution, InstitutionDto>().ReverseMap();
        }
    }
}
