using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using MVCPL.Infrastracture;
using MVCPL.Models;
using MVCPL.Models.PaginationVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCPL.Controllers
{
    public class PostController : Controller
    {
        private const int PageSize = 4;

        private IService<PostEntity> _postService;
        private ICommentService _commentService;
        private IService<LikeEntity> _likeService;
        private IService<UserEntity> _userService;

        public PostController(IService<UserEntity> userService, IService<LikeEntity> likeService, ICommentService commentService, IService<PostEntity> postService)
        {
            _likeService = likeService;
            _postService = postService;
            _commentService = commentService;
            _userService = userService;
        }

        // GET: Post
        public ActionResult Index(int postId)
        {
            RestoreUser();
            IEnumerable<CommentVM> comments = _commentService.GetByPage(PageSize, 1, postId).Select(x => x.ToPLEntity());
            int count = _commentService.GetCount(postId);
            PageVM page = new PageVM { Number = 1, Size = PageSize, TotalItems = count };
            CommentPageVM paging = new CommentPageVM { Page = page, Comments = comments };

            FullPostVM post = new FullPostVM()
                {
                    Post = _postService.Get(x => x.Id == postId).ToPLEntity(),
                    Comments = count,
                    Likes = _likeService.GetAll(x => x.PostId == postId).Select(x => x.ToPLEntity())
            };

            comments = comments.Select(x => 
            {
                x.UserName = _userService.Get(x.UserId).Name;
                return x;
            });

            ViewBag.Owner = _userService.Get(x => x.Id == post.Post.BlogId);
            ViewBag.Post = post.Post.Id;
            ViewBag.User = (UserVM)Session["UserInfo"];
            ViewBag.FullPost = post;
            ViewBag.Paging = paging;

            return View("Post");
        }

        [Authorize]
        public ActionResult CreatePost()
        {
            RestoreUser();
            ViewBag.User = (UserVM)Session["UserInfo"];
            ViewBag.ButtonText = "Create";
            ViewBag.ActionName = "NewPost";

            return View("Edit");
        }

        [Authorize]
        public ActionResult EditPost(int postId)
        {
            RestoreUser();
            PostVM item = _postService.Get(postId).ToPLEntity();

            ViewBag.User = (UserVM)Session["UserInfo"];
            ViewBag.ButtonText = "Submit changes";
            ViewBag.ActionName = "UpdatePost";

            return View("Edit", item);
        }

        [Authorize]
        public ActionResult CreateLike(int postId)
        {
            int userId = ((UserVM)Session["UserInfo"]).Id;

            if (_likeService.Get(x => x.PostId == postId && x.UserId == userId) != null)
                return RedirectToAction("DeleteLike", "Post", new { postId = postId });
            else
                _likeService.Create(new LikeEntity()
                {
                    UserId = userId,
                    PostId = postId
                });

            ViewBag.LikesCount = _likeService.GetAll(x => x.PostId == postId).Count();
            return PartialView("LikePartial");
        }

        [Authorize]
        public ActionResult DeleteLike(int postId)
        {
            int userId = ((UserVM)Session["UserInfo"]).Id;

            LikeEntity item = _likeService.Get(x => x.PostId == postId && x.UserId == userId);
            _likeService.Delete(item.Id);

            ViewBag.LikesCount = _likeService.GetAll(x => x.PostId == postId).Count();
            return PartialView("LikePartial");
        }

        [Authorize]
        public ActionResult GetComments(int postId, int pageNumber = 1)
        {
            IEnumerable<CommentVM> comments = _commentService.GetByPage(PageSize, pageNumber, postId).Select(x=>x.ToPLEntity());
            int count = _commentService.GetCount(postId);
            PageVM page = new PageVM { Number = pageNumber, Size = PageSize, TotalItems = count };
            CommentPageVM paging = new CommentPageVM { Page = page, Comments = comments };

            FullPostVM post = new FullPostVM()
            {
                Post = _postService.Get(x => x.Id == postId).ToPLEntity(),
                Comments = count,
                Likes = _likeService.GetAll(x => x.PostId == postId).Select(x => x.ToPLEntity())
            };

            comments = comments.Select(x =>
            {
                x.UserName = _userService.Get(x.UserId).Name;
                return x;
            });

            ViewBag.User = (UserVM)Session["UserInfo"];
            ViewBag.FullPost = post;
            ViewBag.Paging = paging;

            return PartialView("CommentPartial");
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateComment(CommentVM item, int postId)
        {
            item.PostId = postId;
            item.UserId = ((UserVM)Session["UserInfo"]).Id;
            item.Date = DateTime.Now;
            _commentService.Create(item.ToBLLEntity());

            int count = _commentService.GetCount(postId);
            PageVM page = new PageVM { Size = PageSize, TotalItems = count };

            return GetComments(postId, page.TotalPages);
        }

        [Authorize]
        public ActionResult DeleteComment(int id, int postId)
        {
            _commentService.Delete(id);

            return GetComments(postId);
        }

        [ActionName("NewPost")]
        [HttpPost]
        [Authorize]
        public ActionResult CreatePost(PostVM item)
        {
            ModelState.Remove("Id");
            ModelState.Remove("BlogId");

            if (ModelState.IsValid && item != null)
            {
                item.BlogId = ((UserVM)Session["UserInfo"]).Id;
                _postService.Create(item.ToBLLEntity());
                PostEntity post = _postService.Get(x => x.BlogId == item.BlogId && x.Title == item.Title);

                return RedirectToAction("Index", "Post", new { postId = post.Id });
            }
            else return RedirectToAction("Index", "Blog", new { userId = item.BlogId } );
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdatePost(PostVM item)
        {
            if (ModelState.IsValid && item != null)
            {
                _postService.Update(item.ToBLLEntity());
                return RedirectToAction("Index", "Post", new { postId = item.Id });
            }

            return RedirectToAction("Index", "Blog", new { userId = item.BlogId });
        }

        [Authorize]
        public ActionResult DeletePost(int id, int blogId)
        {
            _postService.Delete(id);
            return RedirectToAction("Index", "Blog", new { userId = blogId });
        }

        [NonAction]
        private void RestoreUser()
        {
            if (Request.IsAuthenticated && Session.Count == 0)
                Session["UserInfo"] = _userService.Get(user => user.Name == HttpContext.User.Identity.Name).ToPLEntity();
        }
    }
}