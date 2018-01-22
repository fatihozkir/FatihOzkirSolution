using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.Entities.Concrete;
namespace FatihOzkirSolutions.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        public User UserLogin(string username,string password)
        {
            using (var dbContext = new ProjectContext())
            {
                var result = dbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
                return result;
            }
            
        }
    }
}