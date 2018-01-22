using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.DataAccess.Concrete.EntityFramework
{
    public class EfSkillDal : EfEntityRepositoryBase<Skill>, ISkillDal
    {
    }
}
