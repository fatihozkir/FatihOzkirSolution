using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FatihOzkirSolutions.Entities.ComplexTypes;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.MvcWebUI.Models
{
    public class UserSkillViewModel
    {
        public UserSkillViewModel()
        {
            SkillList=new List<Skill>();
        }
        public List<Skill> SkillList { get; set; }
        public UserSkillRateViewModel UserSkillsRates { get; set; }
        public UserSkillsDTO userSkill { get; set; }
    }
}