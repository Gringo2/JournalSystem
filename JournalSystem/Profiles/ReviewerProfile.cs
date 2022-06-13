using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class ReviewerProfile : Profile
    {
        public ReviewerProfile()
        {
            CreateMap<Reviewer, ReviewerDto>().ReverseMap();
        }
    }
}
