using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class EditorProfile : Profile
    {
        public EditorProfile()
        {
            CreateMap<Editor, EditorDto>().ReverseMap();
        } 
    }
}
