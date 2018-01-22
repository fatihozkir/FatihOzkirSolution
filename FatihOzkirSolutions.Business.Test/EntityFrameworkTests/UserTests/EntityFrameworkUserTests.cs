using System;
using FatihOzkirSolutions.Business.Concrete.Managers;
using FatihOzkirSolutions.DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FatihOzkirSolutions.Business.Test.EntityFrameworkTests.UserTests
{
    [TestClass]
    public class EntityFrameworkUserTests
    {
        Mock<IUserDal> _mock = new Mock<IUserDal>();
        private UserManager _userManager;
        [TestMethod]
        public void Get_All_UserList_Test()
        {
            _userManager = new UserManager(_mock.Object);
            var userList=_userManager.GetAll();
        }
      
    }
}
