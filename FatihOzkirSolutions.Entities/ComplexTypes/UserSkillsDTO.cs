using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Entities.ComplexTypes
{
    public class UserSkillsDTO
    {
        public User User { get; set; }
        public Skill Skill { get; set; }
        public int UserSkillId { get; set; }
        public int UserId { get; set; }
        public byte Rate { get; set; }
        public int SkillId { get; set; }
    }
}
