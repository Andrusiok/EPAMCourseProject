using DAL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Interfaces
{
    public interface ICommentRepository:IRepository<DALComment>
    {
        int GetCount(int postId);

        IEnumerable<DALComment> GetByPage(int size, int page, int postId);
    }
}
