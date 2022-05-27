using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Profiles
{
    public class ArticleTemplateProfile: Profile
    {
        public ArticleTemplateProfile()
        {
            CreateMap<ArticleTemplate, ArticleTemplateDto>().ReverseMap();
        }
    }
}
