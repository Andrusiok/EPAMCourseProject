using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using ORM;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LinqKit;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class BlogRepository : IRepository<DALBlog>
    {
        private readonly DbContext _context;

        public BlogRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DALBlog item)
        {
            _context.Set<Blog>().Add(new Blog()
            {
                Id = item.UserID,
                User = _context.Set<User>().Find(item.UserID)
            });
        }

        public void Delete(int id)
        {
            Blog blog = _context.Set<Blog>().Find(id);

            if (blog != null) _context.Set<Blog>().Remove(blog);
        }

        public DALBlog Get(Expression<Func<DALBlog, bool>> predicate)
        {
            Expression<Func<Blog, bool>> lambda = predicate.ConvertExpression();
            Blog ormBlog = _context.Set<Blog>().AsExpandable().Where(lambda).FirstOrDefault();

            return ormBlog?.ToDALEntity();
        }

        public DALBlog Get(int id)
        {
            Blog ormBlog = _context.Set<Blog>().FirstOrDefault(e => e.Id == id);

            return ormBlog?.ToDALEntity();
        }

        public IEnumerable<DALBlog> GetAll()
        {
            List<Blog> ormBlogs = _context.Set<Blog>().ToList();

            return RetrieveSet(ormBlogs);
        }

        public IEnumerable<DALBlog> GetAll(Expression<Func<DALBlog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALBlog item)
        {
            Blog blog = _context.Set<Blog>().Find(item.Id);

            if (blog != null)
            {
                blog.Id = item.UserID;
                blog.User = _context.Set<User>().Find(item.UserID);
            }
        }

        private HashSet<DALBlog> RetrieveSet(List<Blog> ormBlogs)
        {
            HashSet<DALBlog> dalBlogs = new HashSet<DALBlog>();

            foreach (Blog ormBlog in ormBlogs)
                dalBlogs.Add(ormBlog.ToDALEntity());

            return dalBlogs;
        }
    }
}
