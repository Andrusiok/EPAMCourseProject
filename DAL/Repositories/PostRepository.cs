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
    public class PostRepository : IRepository<DALPost>
    {
        public void Create(DALPost item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALPost Get(Expression<Func<DALPost, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DALPost Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALPost> GetAll(Expression<Func<DALPost, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALPost item)
        {
            throw new NotImplementedException();
        }
    }
}
