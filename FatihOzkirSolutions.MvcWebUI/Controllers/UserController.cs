using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.Entities.Concrete;
using FatihOzkirSolutions.MvcWebUI.Models;

namespace FatihOzkirSolutions.MvcWebUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private IUserService _userService;

        private IUserSkillService _userSkillService;
        public UserController(IUserService userService, IUserSkillService userSkillService)
        {
            _userService = userService;
            _userSkillService = userSkillService;
        }
        public ActionResult Index()
        {
            var model = new UserViewModel
            {
                UserList = _userService.Last10User()
            };
            
            return View(model);
        }
        #region Login-LogoutProcess

        public ActionResult Login()
        {
            if (HttpContext.Cache["loginUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new User());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {

            User result = new User();
            if (ModelState.IsValid)
            {
                result = _userService.UserLogin(username, password);
                if (result == null)
                {
                    ViewBag.LoginMessage = "User Could Not Found ! Please Check Your Username and Password !";
                    return View(result);
                }
                HttpContext.Cache["loginUser"] = result;
                return RedirectToAction("UserProfile", "User");
            }
            return View(result);
        }
        public ActionResult Logout()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Cache.Remove("loginUser");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }

        #endregion

        #region UserDetailProcess

        public ActionResult UserDetail(int? userId)
        {
            if (userId == null) return RedirectToAction("Index", "User");
            UserSkillRateViewModel model = UserSkills(userId);
            return View("_PartialUserDetails", model);
        }
        private UserSkillRateViewModel UserSkills(int? userId)
        {
            var userSkills = _userSkillService.GetUserSkills(userId);
            UserSkillRateViewModel model = new UserSkillRateViewModel();
            if (userSkills.Count == 0)
            {
                model.user = _userService.GetById(userId);
            }
            else
            {
                model.user = userSkills[0].User;
                foreach (var item in userSkills)
                {
                    model.SkillRateList.Add(new SkillRateViewModel { Rate = item.Rate, skill = item.Skill });
                }
            }
            return model;
        }
        public ActionResult UserDetailPartial(UserSkillRateViewModel model)
        {
            return PartialView("_PartialUserDetails", model);
        }
        public ActionResult UserDetailPartialByUserId(int? userId)
        {
            if (userId == null) return RedirectToAction("Index", "User");
            UserSkillRateViewModel model = UserSkills(userId);
            return PartialView("_PartialUserDetails", model);
        }

        #endregion

        #region RegisterProcess
        public ActionResult Register()
        {
            if (HttpContext.Cache["loginUser"] != null)
            {
                return RedirectToAction("Index", "User");
            }
            return View(new User());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Add(user);
                    return RedirectToAction("Login", "User");
                }
            }
            catch (Exception e)
            {
                ViewData["exception"] = e.Message;
            }
            return View(user);
        }


        #endregion

        #region UserUpdateProcess

        public ActionResult UpdateUser()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("Index", "User");
            }

            User loginUser = (User)HttpContext.Cache["loginUser"];
            return View(loginUser);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = _userService.Update(user);
                HttpContext.Cache["loginUser"] = updatedUser;
                return RedirectToAction("Index", "User");
            }
            return View(user);
        }

        #endregion

        #region GetUserProcess

        public ActionResult GetAllUsers()
        {
            var model = new UserViewModel
            {
                UserList = _userService.GetAll()
            };
            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetAllUsers(string searchUser)
        {
            var result = new UserViewModel
            {
                UserList = _userService.FilteredUserList(searchUser)
            };
            return View(result);
        }

        #endregion

        #region UserDeleteProcess

        public ActionResult UserDelete()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User loginUser = (User)HttpContext.Cache["loginUser"];
            _userService.DeleteById(loginUser.UserId);
            HttpContext.Cache.Remove("loginUser");
            return RedirectToAction("Index", "User");
        }

        #endregion

        #region OtherProcess
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UserControl(string Username)
        {
            bool result = _userService.UsernameControl(Username);
            if (string.IsNullOrEmpty(Username))
            {
                return Json(true);
            }
            return Json(result);
        }
        public ActionResult UserProfile()
        {
            if (HttpContext.Cache["loginUser"] == null) return RedirectToAction("Index", "Home");
            return View();
        }
        #endregion

    }
}