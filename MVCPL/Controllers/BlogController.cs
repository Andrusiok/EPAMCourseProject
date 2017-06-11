using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Index(int blogId)
        {
            IEnumerable<PostVM> posts = _postService.GetAll(x => x.BlogId == blogId).Select(x=>x.ToPLEntity());

            return View(posts);
        }

        [HttpGet]
        public int GetBlog(int userId) => _blogService.Get(x => x.UserId == userId).Id;
    }
}