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
    public class BlogRepository : IRepository<DALBlog>
    {
        public void Create(DALBlog item)
        {
            throw new NotImplementedException();
        }

        public void Create(Blog item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALBlog Get(Expression<DALBlog> predicate)
        {
            throw new NotImplementedException();
        }

        public Blog Get(Expression<Blog> predicate)
        {
            throw new NotImplementedException();
        }

        public Blog Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALBlog> GetAll(Predicate<DALBlog> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog> GetAll(Predicate<Blog> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALBlog item)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog item)
        {
            throw new NotImplementedException();
        }

        DALBlog IRepository<DALBlog>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DALBlog> IRepository<DALBlog>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
