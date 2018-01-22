using System.Collections.Generic;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Abstract
{
    public interface ISkillService : IManagerService<Skill>
    {
        List<Skill> AutoCompleteSkillList(string skillHeader);
        Skill GetSkillByName(string skillName);
        List<Skill> Last10Skill();
        List<Skill> FilteredSkillList(string searchSkill);

    }
}