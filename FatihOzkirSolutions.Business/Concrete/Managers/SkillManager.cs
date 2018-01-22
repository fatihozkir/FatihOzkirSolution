using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Concrete.Managers
{
    public class SkillManager : ISkillService
    {
        private ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetAll()
        {
            return _skillDal.GetList();
        }

        public Skill GetById(int? id)
        {
            var skill= _skillDal.GetEntity(x => x.SkillId == id);
            if(skill==null)throw new NullReferenceException("This skill could not found !");
            return skill;
        }

        public Skill Add(Skill entity)
        {
            var existSkill = _skillDal.GetEntity(x => x.SkillHeader.ToLower().Equals(entity.SkillHeader));
            if (existSkill!=null)
            {
                throw new Exception("This Skill Has Already Exist In Skill List !");
            }
            return _skillDal.Add(entity);
        }

        public Skill Update(Skill entity)
        {
            return _skillDal.Update(entity);
        }

        public int DeleteById(int? id)
        {
            var skill = GetById(id);
            return _skillDal.Delete(skill);
        }

        public List<Skill> AutoCompleteSkillList(string skillHeader)
        {
            return _skillDal.GetList(x => x.SkillHeader.ToLower().Contains(skillHeader));
        }

        public Skill GetSkillByName(string skillName)
        {
            if(string.IsNullOrEmpty(skillName))throw  new ArgumentNullException("You Can Not Pass Skill Header As Empty !");
            var skill = _skillDal.GetEntity(x => x.SkillHeader.ToLower().Equals(skillName));
            return skill;
        }

        public List<Skill> Last10Skill()
        {
            return _skillDal.GetList().OrderByDescending(x => x.SkillId).Take(10).ToList();
        }

        public List<Skill> FilteredSkillList(string searchSkill)
        {
            if(string.IsNullOrEmpty(searchSkill)) throw  new ArgumentNullException("You Can Not Pass Skill Header As Empty !");
            var skill = _skillDal.GetList(x => x.SkillHeader.ToLower().Contains(searchSkill));
            return skill;
        }
    }
}
