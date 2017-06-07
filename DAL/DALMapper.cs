using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL
{
    public static class DALMapper
    {
        #region toDALEntity
        public static DALUser toDALEntity(this User item)
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

        public static DALBlog toDALEntity(this Blog item)
        {
            return new DALBlog()
            {
                Id = item.BlogId,
                UserID = item.UserId
            };
        }

        public static DALPost toDALEntity(this Post item)
        {
            return new DALPost()
            {
                Id = item.PostId,
                Title = item.Title,
                Annotation = item.Annotation,
                BlogId = item.BlogId
            };
        }

        public static DALComment toDALEntity(this Comment item)
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

        public static DALLike toDALEntity(this Like item)
        {
            return new DALLike()
            {
                Id = item.LikeId,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static DALImage toDALEntity(this Image item)
        {
            return new DALImage()
            {
                Id = item.ImageId,
                PostId = item.PostId,
                Path = item.ImagePath
            };
        }

        public static DALTag toDALEntity(this Tag item)
        {
            return new DALTag()
            {
                Id = item.TagId,
                Name = item.TagName
            };
        }
        #endregion


    }
}
