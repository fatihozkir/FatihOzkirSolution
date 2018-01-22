using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.Entities.ComplexTypes;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Concrete.Managers
{
    public class UserSkillManager : IUserSkillService
    {
        private IUserSkillDal _skillDal;

        public UserSkillManager(IUserSkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<UserSkill> GetAll()
        {
            return _skillDal.GetList();
        }

        public UserSkill GetById(int? id)
        {
            return _skillDal.GetEntity(x => x.UserSkillId == id);
        }

        public UserSkill Add(UserSkill entity)
        {
            var existUserSkill = _skillDal.GetEntity(x => x.SkillId == entity.SkillId && x.UserId == entity.UserId);
            if (existUserSkill!=null)
            {
                throw new Exception("You Have Already Have That Skill !");
            }
            return _skillDal.Add(entity);
        }

        public UserSkill Update(UserSkill entity)
        {
            return _skillDal.Update(entity);
        }

        public int DeleteById(int? id)
        {
            var userSkill = GetById(id);
            return _skillDal.Delete(userSkill);
        }

        public List<UserSkillsDTO> GetUserSkills(int? userId)
        {
            return _skillDal.GetUserSkills(userId);
        }

        public List<UserSkillsDTO> SkillFilteredUsers(int? skillId)
        {
            if (skillId == null) throw new ArgumentNullException("You Can Not Pass Skill Filter Parameter As An Empty !");
            return _skillDal.SkillFilteredUsers(skillId).OrderByDescending(x=>x.Rate).ToList();
        }

        public int DeleteUserSkill(int? skillId, int? userId)
        {
            var userSkill = _skillDal.GetEntity(x => x.SkillId == skillId && x.UserId == userId);
            if (userSkill == null)
            {
                throw new NullReferenceException("You Do Not Have That Skill Therefore You Can Not Delete It ! ");
            }
            return DeleteById(userSkill.UserSkillId);
        }

        public UserSkill GetUserSkill(int userId, int skillId)
        {
            if(userId==0 || skillId==0)throw  new ArgumentNullException();
            var userSkill = _skillDal.GetEntity(x => x.SkillId == skillId && x.UserId == userId);
            if (userSkill==null)throw new NullReferenceException();
            return userSkill;
        }

    }
}