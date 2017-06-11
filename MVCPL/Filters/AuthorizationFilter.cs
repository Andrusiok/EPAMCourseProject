using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using MVCPL.Infrastracture;
using MVCPL.Models;

namespace MVCPL.Filters
{
    public class AuthorizeAttribute : FilterAttribute { }

    public class AuthorizeFilter : IAuthorizationFilter
    {
        private readonly IService<UserEntity> _userService;

        public AuthorizeFilter(IService<UserEntity> userService)
        {
            _userService = userService;
        }


        public void OnAuthorization(AuthorizationContext filterContext)
         {
            var validUser = _userService.Get(x => x.Name == filterContext.HttpContext.User.Identity.Name).ToPLEntity().Role == Role.Administrator;
            if (validUser)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Admin" } });
            }

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "User" } }); 
        } 
    } 
}