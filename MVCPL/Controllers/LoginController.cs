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
using System.Text;
using System.Security.Cryptography;

namespace MVCPL.Controllers
{
    public class LoginController : Controller
    {
        private IService<UserEntity> _userService;
        private IService<BlogEntity> _blogService;

        public LoginController(IService<UserEntity> service, IService<BlogEntity> blogService)
        {
            _userService = service;
            _blogService = blogService;
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
                l.Password = sha256_hash(l.Password);

                Expression<Func<UserEntity, bool>> expression = x => x.Name == l.Name && x.Password == l.Password;
                UserEntity user;

                try
                {
                    user = _userService.Get(expression);
                }
                catch (Exception e)
                {
                    return View("Error");
                }
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [ActionName("NewUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM l)
        {
            ModelState.Remove("Password");

            if (ModelState.IsValid && l != null)
            {
                l.Role = Role.User;
                l.Password = sha256_hash(l.RegisterPassword);
                try
                {
                    _userService.Create(l.ToBLLEntity());
                    _blogService.Create(new BlogEntity
                    {
                        UserId = _userService.Get(x => x.Name == l.Name).Id
                    });
                }
                catch (Exception e)
                {
                    return View("Error");
                }
            }

            return RedirectToAction("Index", "Login");
        }

        [NonAction]
        public static String sha256_hash(String value)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return string.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }

        }
    }
}