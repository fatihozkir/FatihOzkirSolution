using AutoMapper;
using Ninject.Modules;

namespace FatihOzkirSolutions.Business.DependencyResolver.AutoMapper
{
    public class AutoMapperModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config=new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(GetType().Assembly);
            });
            return config;
        }
    }
}
