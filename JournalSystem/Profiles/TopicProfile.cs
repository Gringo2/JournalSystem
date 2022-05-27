using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class TopicProfile: Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic,TopicDto>().ReverseMap();
        }
    }
}
