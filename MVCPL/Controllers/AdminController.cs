using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using MVCPL.Filters;
using MVCPL.Infrastracture;
using MVCPL.Models;

namespace MVCPL.Controllers
{
    [Filters.Authorize]
    public class AdminController : Controller
    {
        // GET: /Admin/
        private IService<BlogEntity> _blogService;
        private IService<PostEntity> _postService;
        private IService<ImageEntity> _imageService;
        private IService<CommentEntity> _commentService;
        private IService<UserEntity> _userService;

        public AdminController(IService<BlogEntity> blogService, IService<UserEntity> userService, IService<ImageEntity> imageService, IService<CommentEntity> commentService, IService<PostEntity> postService)
        {
            _blogService = blogService;
            _userService = userService;
            _postService = postService;
            _imageService = imageService;
            _commentService = commentService;
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Index()
        {
            RestoreUser();
            IEnumerable<UserEntity> users = _userService.GetAll();
            HashSet<UserBlogVM> userList = new HashSet<UserBlogVM>();

            foreach (UserEntity user in users)
            {
                BlogEntity blog = _blogService.Get(x => x.UserId == user.Id);
                IEnumerable<PostEntity> posts = _postService.GetAll(x => x.BlogId == blog.Id);
                List<PostVM> postList = new List<PostVM>();

                foreach (PostEntity post in posts)
                    postList.Add(post.ToPLEntity());

                userList.Add(new UserBlogVM()
                {
                    User = user.ToPLEntity(),
                    Blog = new BlogPostVM()
                    {
                        Blog = blog.ToPLEntity(),
                        Posts = postList
                    }
                });
            }
            return View(userList);
        }

        [NonAction]
        private void RestoreUser()
        {
            if (Request.IsAuthenticated && Session.Count == 0)
                Session["UserInfo"] = _userService.Get(user => user.Name == HttpContext.User.Identity.Name).ToPLEntity();
        }
    }
}