using DAL.Interfaces;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;

namespace DAL.Repositories
{
    public class LikeRepository : IRepository<DALLike>
    {
        public void Create(DALLike item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALLike Get(Expression<DALLike> predicate)
        {
            throw new NotImplementedException();
        }

        public DALLike Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALLike> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALLike> GetAll(Predicate<DALLike> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALLike item)
        {
            throw new NotImplementedException();
        }
    }
}
