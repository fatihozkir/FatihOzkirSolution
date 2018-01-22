using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.Entities.Concrete;

namespace FatihOzkirSolutions.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        public User Get(int userId)
        {
            return _userService.GetById(userId);
        }

        [HttpDelete]
        public int Delete(int userId)
        {
            return _userService.DeleteById(userId);
        }

        [HttpPut]
        public User Put(User user)
        {
            return _userService.Update(user);
        }

        [HttpPost]
        public User Post(User user)
        {
            return _userService.Add(user);
        }
    }
}
