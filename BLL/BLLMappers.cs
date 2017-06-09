using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;
using System.Linq.Expressions;

namespace BLL
{
    public static class BLLMappers
    {
        #region ToBLLEntity

        public static UserEntity ToBLLEntity(this DALUser item)
        {
            return new UserEntity
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                RoleID = item.RoleId,
                Mail = item.Mail
            };
        }

        public static BlogEntity ToBLLEntity(this DALBlog item)
        {
            return new BlogEntity()
            {
                Id = item.Id,
                UserId = item.UserID
            };
        }

        public static CommentEntity ToBLLEntity(this DALComment item)
        {
            return new CommentEntity()
            {
                Id = item.Id,
                Date = item.Date,
                Entity = item.Entity,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static PostEntity ToBLLEntity(this DALPost item)
        {
            return new PostEntity()
            {
                Id = item.Id,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Title = item.Title
            };
        }

        public static LikeEntity ToBLLEntity(this DALLike item)
        {
            return new LikeEntity()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static ImageEntity ToBLLEntity(this DALImage item)
        {
            return new ImageEntity()
            {
                Id = item.Id,
                PostId = item.PostId,
                Path = item.Path
            };
        }
        #endregion

        #region ToDALEntity

        public static DALUser ToDALEntity(this UserEntity item)
        {
            return new DALUser
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                RoleId = item.RoleID,
                Mail = item.Mail
            };
        }

        public static DALBlog ToDALEntity(this BlogEntity item)
        {
            return new DALBlog()
            {
                Id = item.Id,
                UserID = item.UserId
            };
        }

        public static DALComment ToDALEntity(this CommentEntity item)
        {
            return new DALComment()
            {
                Id = item.Id,
                Date = item.Date,
                Entity = item.Entity,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static DALPost ToDALEntity(this PostEntity item)
        {
            return new DALPost()
            {
                Id = item.Id,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Title = item.Title
            };
        }

        public static DALLike ToDALEntity(this LikeEntity item)
        {
            return new DALLike()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static DALImage ToDALEntity(this ImageEntity item)
        {
            return new DALImage()
            {
                Id = item.Id,
                PostId = item.PostId,
                Path = item.Path
            };
        }

        #endregion

        #region ConvertExpression

        public static Expression<Func<DALUser, bool>> ConvertExpression(this Expression<Func<UserEntity, bool>> f)
        {
            Expression<Func<DALUser, UserEntity>> convert =
                bar => bar.ToBLLEntity();

            var param = Expression.Parameter(typeof(DALUser), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALUser, bool>>(body, param);
        }

        public static Expression<Func<DALBlog, bool>> ConvertExpression(this Expression<Func<BlogEntity, bool>> f)
        {
            Expression<Func<DALBlog, BlogEntity>> convert =
                bar => bar.ToBLLEntity();

            var param = Expression.Parameter(typeof(DALBlog), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALBlog, bool>>(body, param);
        }

        public static Expression<Func<DALPost, bool>> ConvertExpression(this Expression<Func<PostEntity, bool>> f)
        {
            Expression<Func<DALPost, PostEntity>> convert =
                bar => bar.ToBLLEntity();

            var param = Expression.Parameter(typeof(DALPost), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALPost, bool>>(body, param);
        }

        public static Expression<Func<DALLike, bool>> ConvertExpression(this Expression<Func<LikeEntity, bool>> f)
        {
            Expression<Func<DALLike, LikeEntity>> convert =
                bar => bar.ToBLLEntity();

            var param = Expression.Parameter(typeof(DALLike), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALLike, bool>>(body, param);
        }

        public static Expression<Func<DALComment, bool>> ConvertExpression(this Expression<Func<CommentEntity, bool>> f)
        {
            Expression<Func<DALComment, CommentEntity>> convert =
                bar => bar.ToBLLEntity();

            var param = Expression.Parameter(typeof(DALComment), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALComment, bool>>(body, param);
        }

        public static Expression<Func<DALImage, bool>> ConvertExpression(this Expression<Func<ImageEntity, bool>> f)
        {
            Expression<Func<DALImage, ImageEntity>> convert =
                bar => bar.ToBLLEntity();

            var param = Expression.Parameter(typeof(DALImage), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALImage, bool>>(body, param);
        }
        #endregion
    }
}
