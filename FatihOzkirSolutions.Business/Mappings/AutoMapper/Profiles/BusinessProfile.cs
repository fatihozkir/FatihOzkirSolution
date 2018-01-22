using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<User, User>();
            CreateMap<Skill, Skill>();
            CreateMap<UserSkill, UserSkill>();
        }
    }
}
