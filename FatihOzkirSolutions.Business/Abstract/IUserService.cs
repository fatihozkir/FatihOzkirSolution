using System.Collections.Generic;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Abstract
{
    public interface IUserService : IManagerService<User>
    {
        User UserLogin(string username,string password);
        bool UsernameControl(string username);
        List<User> Last10User();
        List<User> FilteredUserList(string searchUser);
    }
}