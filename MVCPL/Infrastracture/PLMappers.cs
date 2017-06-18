using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPL.Models;
using BLL.Interfaces.Entities;

namespace MVCPL.Infrastracture
{
    public static class PLMappers
    {
        #region ToPLEntity

        public static UserVM ToPLEntity(this UserEntity item)
        {
            return new UserVM()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Role = (Role)item.RoleID,
            };
        }

        public static BlogVM ToPLEntity(this BlogEntity item)
        {
            return new BlogVM()
            {
                Id = item.Id,
                UserId = item.UserId
            };
        }

        public static CommentVM ToPLEntity(this CommentEntity item)
        {
            return new CommentVM()
            {
                Id = item.Id,
                Date = item.Date,
                Entity = item.Entity,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static PostVM ToPLEntity(this PostEntity item)
        {
            return new PostVM()
            {
                Id = item.Id,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Title = item.Title,
                Text = item.Text
            };
        }

        public static LikeVM ToPLEntity(this LikeEntity item)
        {
            return new LikeVM()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static ImageVM ToPLEntity(this ImageEntity item)
        {
            return new ImageVM()
            {
                Id = item.Id,
                PostId = item.PostId,
                Path = item.Path
            };
        }
        #endregion

        #region ToBLLEntity

        public static UserEntity ToBLLEntity(this UserVM item)
        {
            return new UserEntity
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                RoleID = (int)item.Role,
                Mail = "mail"
            };
        }

        public static BlogEntity ToBLLEntity(this BlogVM item)
        {
            return new BlogEntity()
            {
                Id = item.Id,
                UserId = item.UserId
            };
        }

        public static CommentEntity ToBLLEntity(this CommentVM item)
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

        public static PostEntity ToBLLEntity(this PostVM item)
        {
            return new PostEntity()
            {
                Id = item.Id,
                Annotation = item.Annotation,
                BlogId = item.BlogId,
                Title = item.Title,
                Text = item.Text
            };
        }

        public static LikeEntity ToBLLEntity(this LikeVM item)
        {
            return new LikeEntity()
            {
                Id = item.Id,
                PostId = item.PostId,
                UserId = item.UserId
            };
        }

        public static ImageEntity ToBLLEntity(this ImageVM item)
        {
            return new ImageEntity()
            {
                Id = item.Id,
                PostId = item.PostId,
                Path = item.Path
            };
        }
        #endregion
    }
}