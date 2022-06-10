using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusDto>().ReverseMap();
        }

    }
}
