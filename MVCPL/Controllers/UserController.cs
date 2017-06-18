using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MVCPL.Controllers
{
    public class UserController : Controller
    {
        private IService<UserEntity> _userService;

        // GET: User
        public UserController(IService<UserEntity> userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                RestoreUser();
                string userName = ((UserVM)Session["UserInfo"]).Name;
                Expression<Func<UserEntity, bool>> expression = x => x.Name == userName;
                UserVM userEntity = _userService.Get(expression).ToPLEntity();
                ViewBag.Users = _userService.GetAll().Select(x => x.ToPLEntity());
                return View(userEntity);
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id)
        {
            UserVM item = _userService.Get(id).ToPLEntity();
            int adminCount = _userService.GetAll(x => x.RoleID == (int)Role.Administrator).Count();
            bool isDeleted = false;

            if (((UserVM)Session["UserInfo"]).Role == Role.Administrator)
            {
                if ((item.Role == Role.Administrator && adminCount > 1) || item.Role == Role.User)
                {
                    _userService.Delete(id);
                    isDeleted = true;
                }

                if (((UserVM)Session["UserInfo"]).Id == item.Id && isDeleted) return RedirectToAction("LogOut", "Login");

                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("LogOut", "Login");
        }

        [Authorize]
        public ActionResult Get(int id)
        {
            var user = _userService.Get(id);
            return View(user.ToPLEntity());
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangeRole(int id, int roleId)
        {
            UserEntity item = _userService.Get(id);
            item.RoleID = roleId;

            if (((UserVM)Session["UserInfo"]).Id != id)_userService.Update(item);

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(UserVM user)
        {
            _userService.Update(user.ToBLLEntity());
            return RedirectToAction("Index", "User");
        }

        [NonAction]
        private void RestoreUser()
        {
            if (Request.IsAuthenticated && Session.Count == 0)
                Session["UserInfo"] = _userService.Get(user => user.Name == HttpContext.User.Identity.Name).ToPLEntity();
        }
    }
}