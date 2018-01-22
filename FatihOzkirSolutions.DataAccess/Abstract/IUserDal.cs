using FatihOzkirSolutions.Core.DataAccess;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //With this scope I can specify different works for UserDal external CRUD process. (For example joined other tables with User table) 
        User UserLogin(string username,string password);
    }
}
