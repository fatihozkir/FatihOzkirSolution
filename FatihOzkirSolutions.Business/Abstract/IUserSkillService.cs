using System.Collections.Generic;
using FatihOzkirSolutions.Entities.ComplexTypes;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Abstract
{
    public interface IUserSkillService : IManagerService<UserSkill>
    {
        List<UserSkillsDTO> GetUserSkills(int? userId);
        List<UserSkillsDTO> SkillFilteredUsers(int? skillId);
        int DeleteUserSkill(int? skillId, int? userId);
        UserSkill GetUserSkill(int userId, int skillId);
        
    }
}