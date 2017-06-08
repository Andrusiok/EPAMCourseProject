using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL
{
    public static class DALMapper
    {
        #region toDALEntity
        public static DALUser ToDALEntity(this User item)
        {
            return new DALUser()
            {
                Id = item.UserId,
                BlogId = item.BlogId,
                Name = item.UserName,
                Password = item.Password,
                Mail = item.Email,
                RoleId = item.RoleId
            };
        }

        public static DALBlog ToDALEntity(this Blog item)
        {
            return new DALBlog()
            {
                Id = item.BlogId,
                UserID = item.UserId
            };
        }

        public static DALPost ToDALEntity(this Post item)
        {
            return new DALPost()
            {
                Id = item.PostId,
                Title = item.Title,
                Annotation = item.Annotation,
                BlogId = item.BlogId
            };
        }

        public static DALComment ToDALEntity(this Comment item)
        {
            return new DALComment()
            {
                Id = item.CommentId,
                Date = item.Date,
                Entity = item.Entity,
                UserId = item.UserId,
                PostId = item.PostId
            };
        }

        public static DALLike ToDALEntity(this Like item)
        {
            return new DALLike()
            {
                Id = item.LikeId,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static DALImage ToDALEntity(this Image item)
        {
            return new DALImage()
            {
                Id = item.ImageId,
                PostId = item.PostId,
                Path = item.ImagePath
            };
        }

        public static DALTag ToDALEntity(this Tag item)
        {
            return new DALTag()
            {
                Id = item.TagId,
                Name = item.TagName
            };
        }
        #endregion

        #region ConvertExpression
        public static Expression<Func<User, bool>> ConvertExpression(this Expression<Func<DALUser, bool>> f)
        {
            Expression<Func<User, DALUser>> convert =
                bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Blog), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));
            return Expression.Lambda<Func<User, bool>>(body, param);
        }

        public static Expression<Func<Blog, bool>> ConvertExpression(this Expression<Func<DALBlog, bool>> f)
        {
            Expression<Func<Blog, DALBlog>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Blog), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Blog, bool>>(body, param);
        }

        public static Expression<Func<Post, bool>> ConvertExpression(this Expression<Func<DALPost, bool>> f)
        {
            Expression<Func<Post, DALPost>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Post), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Post, bool>>(body, param);
        }

        public static Expression<Func<Like, bool>> ConvertExpression(this Expression<Func<DALLike, bool>> f)
        {
            Expression<Func<Like, DALLike>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Like), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Like, bool>>(body, param);
        }

        public static Expression<Func<Comment, bool>> ConvertExpression(this Expression<Func<DALComment, bool>> f)
        {
            Expression<Func<Comment, DALComment>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Like), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Comment, bool>>(body, param);
        }

        public static Expression<Func<Image, bool>> ConvertExpression(this Expression<Func<DALImage, bool>> f)
        {
            Expression<Func<Image, DALImage>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Like), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Image, bool>>(body, param);
        }

        public static Expression<Func<Tag, bool>> ConvertExpression(this Expression<Func<DALTag, bool>> f)
        {
            Expression<Func<Image, DALImage>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Like), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Tag, bool>>(body, param);
        }
        #endregion
    }
}
