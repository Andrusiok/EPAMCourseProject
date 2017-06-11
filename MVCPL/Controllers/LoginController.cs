using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using MVCPL.Models;

namespace MVCPL.Controllers
{
    public class LoginController : Controller
    {
        private IService<UserEntity> _userService;
        private IService<BlogEntity> _blogService;

        public LoginController(IService<UserEntity> service)
        {
            _userService = service;
        }
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserVM l, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                Expression<Func<UserEntity, bool>> expression = x => x.Name == l.Name && x.Password == l.Password;
                var user = _userService.Get(expression);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Name, false);
                    Session["UserInfo"] = user.ToPLEntity();
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }

            ModelState.Remove("Password");
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [ActionName("NewUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel l)
        {
            if (ModelState.IsValid && l != null)
            {
                l.Role = Role.User;
                l.Password = l.RegisterPassword;
                _userService.Create(l.ToBLLEntity());
                int id = _userService.Get(x => x.Name == l.Name).Id;
                _blogService.Create(new BlogEntity()
                {
                    UserId = id
                });
            }

            return RedirectToAction("Index");
        }
    }
}