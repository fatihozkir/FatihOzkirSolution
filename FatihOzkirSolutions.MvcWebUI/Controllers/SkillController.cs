using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using FatihOzkirSolutions.Business.Abstract;
using FatihOzkirSolutions.Entities.ComplexTypes;
using FatihOzkirSolutions.Entities.Concrete;
using FatihOzkirSolutions.MvcWebUI.Models;

namespace FatihOzkirSolutions.MvcWebUI.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        private ISkillService _skillService;
        private IUserSkillService _userSkillService;
        public SkillController(ISkillService userService, IUserSkillService userSkillService)
        {
            _skillService = userService;
            _userSkillService = userSkillService;
        }

        #region ListProcess

        public ActionResult AllSkills()
        {
            var model = new SkillViewModel
            {
                SkillList = _skillService.GetAll()
            };
            return PartialView("AllSkills", model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AllSkills(string searchSkill)
        {
            try
            {
                var model = new SkillViewModel
                {
                    SkillList = _skillService.FilteredSkillList(searchSkill)
                };
                return PartialView("AllSkills", model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "User");
            }
            
        }
        public ActionResult LastAddedSkills()
        {
            var model = new SkillViewModel
            {
                SkillList = _skillService.Last10Skill()
            };
            return PartialView(model);
        }

        public ActionResult UserSkillList()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("UserProfile", "User");
            }
            User user = HttpContext.Cache["loginUser"] as User;
            var userSkills = _userSkillService.GetUserSkills(user.UserId);
            UserSkillRateViewModel model = new UserSkillRateViewModel();
            if (userSkills.Count == 0)
            {
                model.user = user;
            }
            else
            {
                model.user = userSkills[0].User;
                foreach (var item in userSkills)
                {
                    model.SkillRateList.Add(new SkillRateViewModel { Rate = item.Rate, skill = item.Skill });
                }
            }
            return View(model);

        }

        public ActionResult SkillFilteredUsers(int? skillId)
        {
            try
            {
                if (skillId == null) return RedirectToAction("Index", "User");
                var result = _userSkillService.SkillFilteredUsers(skillId);
                if (result.Count==0)
                {
                    TempData["Exception"] = "We Could Not Found Any User For Interested In That Skill...";
                }
                return View(result);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "User");
            }
            
        }

        #endregion

        #region OtherProcess

        [ActionName("SkillComplete")]
        public PartialViewResult _PartialSkillComplete()
        {
            return PartialView("_PartialSkillComplete");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CompleteSkill(string skillHeader)
        {
            List<Skill> skillList = _skillService.AutoCompleteSkillList(skillHeader);
            return Json(skillList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MySkills()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("UserProfile", "User");
            }
            return View("MySkills");
        }

        #endregion

        #region InsertProcess

        public ActionResult AddSkill()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("UserProfile", "User");
            }
            return View();
        }
        public ActionResult AddNewSkill()
        {
            if (HttpContext.Cache["loginUser"] == null)
            {
                return RedirectToAction("Index", "User");
            }

            UserSkillViewModel userSkillModel = new UserSkillViewModel();
            userSkillModel.SkillList = _skillService.GetAll();

            User focusedUser = HttpContext.Cache["loginUser"] as User;
            var userSkills = _userSkillService.GetUserSkills(focusedUser.UserId);
            UserSkillRateViewModel userSkillRateViewmodel = new UserSkillRateViewModel();
            if (userSkills.Count == 0)
            {
                userSkillRateViewmodel.user = focusedUser;
            }
            else
            {
                userSkillRateViewmodel.user = userSkills[0].User;
                foreach (var item in userSkills)
                {
                    userSkillRateViewmodel.SkillRateList.Add(new SkillRateViewModel { Rate = item.Rate, skill = item.Skill });
                }
            }

            userSkillModel.UserSkillsRates = userSkillRateViewmodel;
            return View(userSkillModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddNewSkill(string header, byte Rate = 1)
        {
            UserSkillViewModel model = new UserSkillViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = HttpContext.Cache["loginUser"] as User;
                    model.userSkill = new UserSkillsDTO();
                    model.userSkill.Rate = Rate;
                    Skill getSkill = _skillService.GetSkillByName(header);
                    UserSkill newUserSkill = new UserSkill();
                    newUserSkill.UserId = currentUser.UserId;
                    newUserSkill.Rate = Rate;
                    if (getSkill == null)
                    {
                        getSkill = _skillService.Add(new Skill { SkillHeader = header });
                    }
                    newUserSkill.SkillId = getSkill.SkillId;
                    _userSkillService.Add(newUserSkill);
                }
                catch (Exception e)
                {
                    TempData["Exception"] = e.Message;
                }
            }
            return View(model);
        }

        #endregion

        #region EditProcess

        public ActionResult EditMySkill(int? skillId)
        {
            if (HttpContext.Cache["loginUser"] == null || skillId == null)
            {
                return RedirectToAction("UserProfile", "User");
            }
            try
            {
                var currentUser = HttpContext.Cache["loginUser"] as User;
                var getSkill = _skillService.GetById(skillId);
                Session["skill"] = getSkill;
                UserSkill currentUserSkill = _userSkillService.GetUserSkill(currentUser.UserId, getSkill.SkillId);
                currentUserSkill.Skill = getSkill;
                return View(currentUserSkill);
            }
            catch (Exception e)
            {
                TempData["Exception"] = e.Message;
                return RedirectToAction("UserProfile", "User");
            }


        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditMySkill(UserSkill model)
        {
            var result = _userSkillService.Update(model);
            result.Skill = Session["skill"] as Skill;
            TempData["Exception"] = "Update Succesfully !";
            return View(result);
        }

        #endregion

        #region DeleteProcess

        public ActionResult DeleteSkill(int? skillId)
        {
            if (HttpContext.Cache["loginUser"] == null || skillId == null) return RedirectToAction("Index", "Home");
            try
            {
                var user = HttpContext.Cache["loginUser"] as User;
                _userSkillService.DeleteUserSkill(skillId, user.UserId);
                return RedirectToAction("AddSkill", "Skill");
            }
            catch (Exception e)
            {
                TempData["Exception"] = e.Message;
            }
            return RedirectToAction("AddSkill", "Skill");
        }

        #endregion

    }
}