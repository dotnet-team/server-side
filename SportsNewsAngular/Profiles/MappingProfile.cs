using AutoMapper;
using SportsNewsAngular.Models;
using SportsNewsAngular.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsNewsAngular.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Article, ArticleModel>();
            CreateMap<Team, TeamModel>();
            CreateMap<SideNav, SideNavModel>();
        }
    }
}
