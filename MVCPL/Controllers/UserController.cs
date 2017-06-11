using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
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
            }

            return View();
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            if (((UserVM)Session["UserInfo"]).Role == Role.Administrator)
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("LogOut", "Login");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            return View(user.ToPLEntity());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(UserVM user)
        {
            _userService.Update(user.ToBLLEntity());
            if (((UserVM)Session["UserInfo"]).Role == Role.Administrator)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index");
        }

        [NonAction]
        private void RestoreUser()
        {
            if (Request.IsAuthenticated && Session.Count == 0)
                Session["UserInfo"] = _userService.Get(user => user.Name == HttpContext.User.Identity.Name).ToPLEntity();
        }
    }
}