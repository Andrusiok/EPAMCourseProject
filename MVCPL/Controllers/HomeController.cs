using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using System.Web.Mvc;

namespace MVCPL.Controllers
{
    public class HomeController : Controller
    {
        private IService<UserEntity> _userService;

        public HomeController(IService<UserEntity> userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            RestoreUser();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [NonAction]
        private void RestoreUser()
        {
            if (Request.IsAuthenticated && Session.Count == 0)
                Session["UserInfo"] = _userService.Get(user => user.Name == HttpContext.User.Identity.Name).ToPLEntity();
        }
    }
}