namespace FatihOzkirSolutions.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSkill
    {
        public int UserSkillId { get; set; }
        
        public int UserId { get; set; }
        
        public int SkillId { get; set; }
        
        public byte Rate { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual User User { get; set; }
    }
}
