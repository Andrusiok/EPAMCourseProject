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
    public class CommentRepository : IRepository<DALComment>
    {
        public void Create(DALComment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALComment Get(Expression<DALComment> predicate)
        {
            throw new NotImplementedException();
        }

        public DALComment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALComment> GetAll(Predicate<DALComment> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALComment item)
        {
            throw new NotImplementedException();
        }
    }
}
