using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.Business.Concrete.Managers;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.DataAccess.Concrete.EntityFramework;
using FatihOzkirSolutions.Entities.Concrete;
using Ninject.Modules;

namespace FatihOzkirSolutions.Business.DependencyResolver.Ninject
{
    public class BusinessModule:NinjectModule
    {
        //With InSingletonScope we saved performance for creating UserManager Methods.
        public override void Load()
        {
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IManagerService<User>>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>();

            Bind<ISkillService>().To<SkillManager>().InSingletonScope();
            Bind<IManagerService<Skill>>().To<SkillManager>().InSingletonScope();
            Bind<ISkillDal>().To<EfSkillDal>();

            Bind<IUserSkillService>().To<UserSkillManager>().InSingletonScope();
            Bind<IManagerService<UserSkill>>().To<UserSkillManager>().InSingletonScope();
            Bind<IUserSkillDal>().To<EfUserSkillDal>();

           
            Bind<DbContext>().To<ProjectContext>().InSingletonScope();
        }
    }
}
