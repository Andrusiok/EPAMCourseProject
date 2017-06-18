using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MVCPL.Controllers
{
    public class BlogController : Controller
    {
        private IService<BlogEntity> _blogService;
        private IService<PostEntity> _postService;
        private IService<UserEntity> _userService;

        // GET: Blog
        public BlogController(IService<UserEntity> userService, IService<PostEntity> postService, IService<BlogEntity> blogService)
        {
            _postService = postService;
            _userService = userService;
            _blogService = blogService;
        }

        public ActionResult Index(int userId)
        {
            RestoreUser();
            BlogVM blog = _blogService.Get(x => x.UserId == userId).ToPLEntity();
            IEnumerable<PostVM> posts = _postService.GetAll(x => x.BlogId == blog.Id).Select(x=>x.ToPLEntity());

            ViewBag.User = (UserVM)Session["UserInfo"];

            return View("Blog", new BlogPostVM() {
                Blog = blog,
                Posts = posts
            });
        }

        public ActionResult FindBlogs(string searchPattern)
        {
            if (Request.IsAuthenticated)
            {
                RestoreUser();
                string userName = ((UserVM)Session["UserInfo"]).Name;
                Expression<Func<UserEntity, bool>> expression = x => x.Name == userName;
                UserVM userEntity = _userService.Get(expression).ToPLEntity();
                ViewBag.Users = _userService.GetAll()
                    .Where(x=>Regex.IsMatch(x.Name, searchPattern, RegexOptions.IgnoreCase))
                    .Select(x => x.ToPLEntity());

                return View("/Views/User/Index.cshtml", userEntity);
            }

            return View();
        }

        public ActionResult FindPosts(string searchPattern, int userId)
        {
            if (Request.IsAuthenticated)
            {
                RestoreUser();
                IEnumerable<PostVM> posts = _postService.GetAll()
                    .Where(x => Regex.IsMatch($"{x.Title} {x.Annotation}", searchPattern, RegexOptions.IgnoreCase))
                    .Select(x => x.ToPLEntity());

                ViewBag.User = (UserVM)Session["UserInfo"];

                return View("Blog", new BlogPostVM()
                {
                    Blog = new BlogVM() { Id = userId},
                    Posts = posts
                });
            }

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