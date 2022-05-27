using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class EditDecisionsProfile: Profile
    {
        public EditDecisionsProfile()
        {
            CreateMap<EditDecisions, EditDecisionsDto>().ReverseMap();
        }
    }
}
