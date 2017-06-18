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
            if (ReferenceEquals(item, null)) return null;

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
            if (ReferenceEquals(item, null)) return null;

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
            if (ReferenceEquals(item, null)) return null;

            return new PostEntity()
            {
                Id = item.Id,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Title = item.Title,
                Text = item.Text
            };
        }

        public static LikeEntity ToBLLEntity(this DALLike item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new LikeEntity()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static ImageEntity ToBLLEntity(this DALImage item)
        {
            if (ReferenceEquals(item, null)) return null;

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
            if (ReferenceEquals(item, null)) return null;

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
            if (ReferenceEquals(item, null)) return null;

            return new DALBlog()
            {
                Id = item.Id,
                UserID = item.UserId
            };
        }

        public static DALComment ToDALEntity(this CommentEntity item)
        {
            if (ReferenceEquals(item, null)) return null;

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
            if (ReferenceEquals(item, null)) return null;

            return new DALPost()
            {
                Id = item.Id,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Title = item.Title,
                Text = item.Text
            };
        }

        public static DALLike ToDALEntity(this LikeEntity item)
        {
            if (ReferenceEquals(item, null)) return null;

            return new DALLike()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static DALImage ToDALEntity(this ImageEntity item)
        {
            if (ReferenceEquals(item, null)) return null;

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
                bar => new UserEntity
                {
                    Id = bar.Id,
                    Name = bar.Name,
                    Password = bar.Password,
                    RoleID = bar.RoleId,
                    Mail = bar.Mail
                };

            var param = Expression.Parameter(typeof(DALUser), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALUser, bool>>(body, param);
        }

        public static Expression<Func<DALBlog, bool>> ConvertExpression(this Expression<Func<BlogEntity, bool>> f)
        {
            Expression<Func<DALBlog, BlogEntity>> convert =
                bar => new BlogEntity()
                {
                    Id = bar.Id,
                    UserId = bar.UserID
                };

            var param = Expression.Parameter(typeof(DALBlog), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALBlog, bool>>(body, param);
        }

        public static Expression<Func<DALPost, bool>> ConvertExpression(this Expression<Func<PostEntity, bool>> f)
        {
            Expression<Func<DALPost, PostEntity>> convert =
                bar => new PostEntity()
                {
                    Id = bar.Id,
                    Annotation = bar.Annotation,
                    BlogId = bar.BlogId,
                    Title = bar.Title,
                    Text = bar.Text
                };

            var param = Expression.Parameter(typeof(DALPost), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALPost, bool>>(body, param);
        }

        public static Expression<Func<DALLike, bool>> ConvertExpression(this Expression<Func<LikeEntity, bool>> f)
        {
            Expression<Func<DALLike, LikeEntity>> convert =
                bar => new LikeEntity()
                {
                    Id = bar.Id,
                    PostId = bar.PostId,
                    UserId = bar.UserId
                };

            var param = Expression.Parameter(typeof(DALLike), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALLike, bool>>(body, param);
        }

        public static Expression<Func<DALComment, bool>> ConvertExpression(this Expression<Func<CommentEntity, bool>> f)
        {
            Expression<Func<DALComment, CommentEntity>> convert =
                bar => new CommentEntity()
                {
                    Id = bar.Id,
                    Date = bar.Date,
                    Entity = bar.Entity,
                    PostId = bar.PostId,
                    UserId = bar.UserId
                };

            var param = Expression.Parameter(typeof(DALComment), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALComment, bool>>(body, param);
        }

        public static Expression<Func<DALImage, bool>> ConvertExpression(this Expression<Func<ImageEntity, bool>> f)
        {
            Expression<Func<DALImage, ImageEntity>> convert =
                bar => new ImageEntity()
                {
                    Id = bar.Id,
                    PostId = bar.PostId,
                    Path = bar.Path
                };

            var param = Expression.Parameter(typeof(DALImage), "bar");
            var body = Expression.Invoke(f, Expression.Invoke(convert, param));

            return Expression.Lambda<Func<DALImage, bool>>(body, param);
        }
        #endregion
    }
}
