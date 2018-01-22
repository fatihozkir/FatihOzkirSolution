using System.Collections.Generic;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.Entities.Concrete;
using System.Linq;
using FatihOzkirSolutions.Entities.ComplexTypes;

namespace FatihOzkirSolutions.DataAccess.Concrete.EntityFramework
{
    public class EfUserSkillDal : EfEntityRepositoryBase<UserSkill>, IUserSkillDal
    {
        public List<UserSkillsDTO> GetUserSkills(int? userId)
        {
            using (var context=new ProjectContext())
            {
                var result = from us in context.UserSkills
                    where us.UserId == userId
                    join u in context.Users on us.UserId equals u.UserId
                    join s in context.Skills on us.SkillId equals s.SkillId
                    select new UserSkillsDTO()
                    {
                        User = u,
                        Skill = s,
                        UserSkillId = us.UserSkillId,
                        UserId = us.UserId,
                        Rate = us.Rate,
                        SkillId = us.SkillId
                    };
                return result.ToList();
            }
        }

        public List<UserSkillsDTO> SkillFilteredUsers(int? skillId)
        {
            using (var context = new ProjectContext())
            {
                var result = from us in context.UserSkills
                    where us.SkillId == skillId
                    join u in context.Users on us.UserId equals u.UserId
                    join s in context.Skills on us.SkillId equals s.SkillId
                    select new UserSkillsDTO()
                    {
                        User = u,
                        Skill = s,
                        UserSkillId = us.UserSkillId,
                        UserId = us.UserId,
                        Rate = us.Rate,
                        SkillId = us.SkillId
                    };
                return result.ToList();
            }
        }
    }
}