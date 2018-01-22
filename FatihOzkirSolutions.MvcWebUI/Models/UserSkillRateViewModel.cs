using System.Collections.Generic;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.MvcWebUI.Models
{
    public class UserSkillRateViewModel
    {
        public UserSkillRateViewModel()
        {
            this.SkillRateList=new List<SkillRateViewModel>();
        }
        public User user { get; set; }
        public List<SkillRateViewModel> SkillRateList { get; set; }
    }
}