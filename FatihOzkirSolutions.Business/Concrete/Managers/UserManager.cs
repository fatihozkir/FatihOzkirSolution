using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.Core.Utilities.Mappings;
using FatihOzkirSolutions.DataAccess.Abstract;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<User> GetAll()
        {
            return _mapper.Map<List<User>>(_userDal.GetList());
        }

        public User GetById(int? id)
        {
            return _mapper.Map<User>( _userDal.GetEntity(x => x.UserId == id));
        }
        
        public User Add(User user)
        {
            var userControl = _userDal.GetEntity(x => x.Username == user.Username);
            if (userControl!=null)
            {
                throw new Exception("This username is reserved.Please change that username.");
            }
            return _mapper.Map<User>(_userDal.Add(user));
        }

        public User Update(User user)
        {
            return _mapper.Map<User>(_userDal.Update(user));
        }

        public int DeleteById(int? id)
        {
            User usr = GetById(id);
            return _mapper.Map<int>(_userDal.Delete(usr));
        }
        
        public User UserLogin(string username,string password)
        {
            return _userDal.UserLogin(username,password);
        }

        public bool UsernameControl(string username)
        {
            bool status = false;
            var user = _userDal.GetEntity(x => x.Username == username);
            if (user!=null)
            {
                status = true;
            }
            return status;
        }

        public List<User> Last10User()
        {
            return _userDal.GetList().OrderByDescending(x => x.UserId).Take(10).ToList();
        }

        public List<User> FilteredUserList(string searchUser)
        {
            
            return _userDal.GetList().Where(x =>
                x.Username.ToLower().Contains(searchUser) || x.Name.ToLower().Contains(searchUser) ||
                x.Surname.ToLower().Contains(searchUser)).ToList();
        }
    }
}