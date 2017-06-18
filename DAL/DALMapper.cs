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
            if (ReferenceEquals(item, null)) return null;

            return new DALUser()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Mail = item.Email,
                RoleId = item.RoleId
            };
        }

        public static DALBlog ToDALEntity(this Blog item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new DALBlog()
            {
                Id = item.Id,
                UserID = item.Id
            };
        }

        public static DALPost ToDALEntity(this Post item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new DALPost()
            {
                Id = item.Id,
                Title = item.Title,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Text = item.Text
            };
        }

        public static DALComment ToDALEntity(this Comment item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new DALComment()
            {
                Id = item.Id,
                Date = item.Date,
                Entity = item.Entity,
                UserId = item.UserId,
                PostId = item.PostId
            };
        }

        public static DALLike ToDALEntity(this Like item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new DALLike()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static DALImage ToDALEntity(this Image item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new DALImage()
            {
                Id = item.Id,
                PostId = item.PostId,
                Path = item.ImagePath
            };
        }

        public static DALTag ToDALEntity(this Tag item)
        {
            if (ReferenceEquals(item, null)) return null;

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
                bar => new DALUser()
                {
                    Id = bar.Id,
                    Name = bar.Name,
                    Password = bar.Password,
                    Mail = bar.Email,
                    RoleId = bar.RoleId
                };

            var param = Expression.Parameter(typeof(User), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));
            return Expression.Lambda<Func<User, bool>>(body, param);
        }

        public static Expression<Func<Blog, bool>> ConvertExpression(this Expression<Func<DALBlog, bool>> f)
        {
            Expression<Func<Blog, DALBlog>> convert = bar => new DALBlog()
            {
                Id = bar.Id,
                UserID = bar.Id
            };

            var param = Expression.Parameter(typeof(Blog), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Blog, bool>>(body, param);
        }

        public static Expression<Func<Post, bool>> ConvertExpression(this Expression<Func<DALPost, bool>> f)
        {
            Expression<Func<Post, DALPost>> convert = bar => new DALPost()
            {
                Id = bar.Id,
                Title = bar.Title,
                Annotation = bar.Annotation,
                BlogId = bar.BlogId,
                Text = bar.Text
            };

            var param = Expression.Parameter(typeof(Post), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Post, bool>>(body, param);
        }

        public static Expression<Func<Like, bool>> ConvertExpression(this Expression<Func<DALLike, bool>> f)
        {
            Expression<Func<Like, DALLike>> convert = bar => new DALLike()
            {
                Id = bar.Id,
                PostId = bar.PostId,
                UserId = bar.UserId
            };

            var param = Expression.Parameter(typeof(Like), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Like, bool>>(body, param);
        }

        public static Expression<Func<Comment, bool>> ConvertExpression(this Expression<Func<DALComment, bool>> f)
        {
            Expression<Func<Comment, DALComment>> convert = bar => new DALComment()
            {
                Id = bar.Id,
                Date = bar.Date,
                Entity = bar.Entity,
                UserId = bar.UserId,
                PostId = bar.PostId
            };

            var param = Expression.Parameter(typeof(Comment), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Comment, bool>>(body, param);
        }

        public static Expression<Func<Image, bool>> ConvertExpression(this Expression<Func<DALImage, bool>> f)
        {
            Expression<Func<Image, DALImage>> convert = bar => new DALImage()
            {
                Id = bar.Id,
                PostId = bar.PostId,
                Path = bar.ImagePath
            };

            var param = Expression.Parameter(typeof(Image), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Image, bool>>(body, param);
        }

        /*public static Expression<Func<Tag, bool>> ConvertExpression(this Expression<Func<DALTag, bool>> f)
        {
            Expression<Func<Image, DALImage>> convert = bar => bar.ToDALEntity();

            var param = Expression.Parameter(typeof(Like), "bar");
            var body = Expression.Invoke(f,
                Expression.Invoke(convert, param));

            return Expression.Lambda<Func<Tag, bool>>(body, param);
        }*/
        #endregion
    }
}
