using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using FatihOzkirSolutions.DataAccess.Concrete.EntityFramework;
using FatihOzkirSolutions.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatihOzkirSolutions.DataAccess.Test
{
    [TestClass]
    public class EntityFrameworkTests
    {
        EfUserDal _userDal = new EfUserDal();
        [TestMethod]
        public void Get_All_UserList_Tests()
        {
            var result = _userDal.GetList();
            Assert.AreEqual(8,result.Count);
        }

        [TestMethod]
        public void Add_User_Test()
        {
            var resultUser=_userDal.Add(new User
            {
                Username = FakeData.NameData.GetCompanyName(),
                Name = FakeData.NameData.GetFirstName(),
                Surname = FakeData.NameData.GetSurname(),
                Password = FakeData.NumberData.GetNumber(1000, 1453).ToString()
            });
        }
        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Add_User_Validation_Test()
        {
            var resultUser = _userDal.Add(new User
            {
                Username = FakeData.NameData.GetCompanyName(),
                Password = FakeData.NumberData.GetNumber(1000, 1453).ToString()
            });
        }

        [TestMethod]
        public void Delete_User_Test()
        {
            var user = _userDal.GetEntity(x => x.UserId == 1004);
            int result = _userDal.Delete(user);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Update_User_Test()
        {
            var user = _userDal.GetEntity(x => x.UserId == 1002);
            user.Username = FakeData.NameData.GetFullName().Trim();
            _userDal.Update(user);
        }

     
        [TestMethod]
        public void Get_User_Skills()
        {
            EfUserSkillDal _userSkillDal=new EfUserSkillDal();
            var x = _userSkillDal.GetUserSkills(1);
        }
        [TestMethod]
        public void Get_Skill_Filtered_UserList()
        {
            EfUserSkillDal _userSkillDal=new EfUserSkillDal();
            var x = _userSkillDal.SkillFilteredUsers(1);
            Assert.AreEqual(2,x.Count);
        }
    }
}
