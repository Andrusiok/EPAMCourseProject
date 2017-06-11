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
    public class PostController : Controller
    {
        private IService<PostEntity> _postService;
        private IService<ImageEntity> _imageService;
        private IService<CommentEntity> _commentService;
        private IService<LikeEntity> _likeService;
        private IService<UserEntity> _userService;

        public PostController(IService<UserEntity> userService, IService<LikeEntity> likeService, IService<ImageEntity> imageService, IService<CommentEntity> commentService, IService<PostEntity> postService)
        {
            _likeService = likeService;
            _postService = postService;
            _imageService = imageService;
            _commentService = commentService;
            _userService = userService;
        }

        // GET: Post
        public ActionResult Index(int postId)
        {
            RestoreUser();
            FullPostVM post = new FullPostVM()
                {
                    Post = _postService.Get(x => x.Id == postId).ToPLEntity(),
                    Image = _imageService.Get(x => x.PostId == postId).ToPLEntity(),
                    Comments = _commentService.GetAll(x => x.PostId == postId).Select(x => x.ToPLEntity()),
                    Likes = _likeService.GetAll(x => x.PostId == postId).Select(x => x.ToPLEntity())
            };
            return View(post);
        }

        [HttpPut]
        [Authorize]
        public ActionResult CreateLike(LikeVM item)
        {
            _likeService.Create(item.ToBLLEntity());
            return RedirectToAction("Index", item.PostId);
        }

        [HttpDelete]
        [Authorize]
        public ActionResult DeleteLike(LikeVM item)
        {
            _likeService.Delete(item.Id);
            return RedirectToAction("Index", item.PostId);
        }

        [HttpPut]
        [Authorize]
        public ActionResult CreateComment(CommentVM item)
        {
            _commentService.Create(item.ToBLLEntity());
            return RedirectToAction("Index", item.PostId);
        }

        [HttpDelete]
        [Authorize]
        public ActionResult DeleteComment(CommentVM item)
        {
            _commentService.Delete(item.Id);
            return RedirectToAction("Index", item.PostId);
        }

        [HttpPut]
        [Authorize]
        public ActionResult CreatePost(PostVM item)
        {
            _postService.Create(item.ToBLLEntity());
            return RedirectToAction("Index", "Blog", item.BlogId);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdatePost(PostVM item)
        {
            _postService.Update(item.ToBLLEntity());
            return RedirectToAction("Index", "Blog", item.BlogId);
        }

        [HttpDelete]
        [Authorize]
        public ActionResult DeletePost(int id, int blogId)
        {
            _postService.Delete(id);
            return RedirectToAction("Index", "Blog", blogId);
        }

        [NonAction]
        private void RestoreUser()
        {
            if (Request.IsAuthenticated && Session.Count == 0)
                Session["UserInfo"] = _userService.Get(user => user.Name == HttpContext.User.Identity.Name).ToPLEntity();
        }
    }
}