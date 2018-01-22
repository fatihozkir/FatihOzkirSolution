using System.Collections.Generic;
using FatihOzkirSolutions.Core.DataAccess;
using FatihOzkirSolutions.Entities.ComplexTypes;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.DataAccess.Abstract
{
    public interface IUserSkillDal : IEntityRepository<UserSkill>
    {
        //With this scope I can specify different works for UserSkillDal external CRUD process. (For example joined other tables with UserSkill table) 
        List<UserSkillsDTO> GetUserSkills(int? userId);
        List<UserSkillsDTO> SkillFilteredUsers(int? skillId);
    }
}