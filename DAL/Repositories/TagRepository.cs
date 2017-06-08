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
    public class TagRepository : IRepository<DALTag>
    {
        public void Create(DALTag item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALTag Get(Expression<Func<DALTag, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DALTag Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALTag> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALTag> GetAll(Expression<Func<DALTag, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALTag item)
        {
            throw new NotImplementedException();
        }
    }
}
