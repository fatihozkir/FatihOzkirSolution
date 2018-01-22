using FatihOzkirSolutions.Core.DataAccess;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.DataAccess.Abstract
{
    public interface ISkillDal : IEntityRepository<Skill>
    {
        //With this scope I can specify different works for SkillDal external CRUD process. (For example joined other tables with Skill table) 

    }
}