using System;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.Business.Concrete.Managers;
using FatihOzkirSolutions.DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FatihOzkirSolutions.Business.Test.EntityFrameworkTests.UserSkillTests
{
    [TestClass]
    public class EntityFrameworkUserSkillTest
    {
        Mock<IUserSkillDal> _mock = new Mock<IUserSkillDal>();
        [TestMethod]
        public void Get_User_Skills_Tests()
        {
            UserSkillManager _userSkillManager=new UserSkillManager(_mock.Object);
            var userSkills=_userSkillManager.GetUserSkills(1);

        }
       
    }
}
