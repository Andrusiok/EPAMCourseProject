using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface ICommentService:IService<CommentEntity>
    {
        int GetCount(int postId);

        IEnumerable<CommentEntity> GetByPage(int size, int page, int postId);
    }
}
