using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<DALUser>
    {
        public void Create(DALUser item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALUser Get(Expression<DALUser> predicate)
        {
            throw new NotImplementedException();
        }

        public DALUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALUser> GetAll(Predicate<DALUser> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALUser item)
        {
            throw new NotImplementedException();
        }
    }
}
