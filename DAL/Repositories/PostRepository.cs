using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using ORM;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LinqKit;

namespace DAL.Repositories
{
    public class PostRepository : IRepository<DALPost>
    {
        private DbContext _context;

        public PostRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DALPost item)
        {
            _context.Set<Post>().Add(new Post()
            {
                Title = item.Title,
                Annotation = item.Annotation,
                Text = item.Text,
                BlogId = item.BlogId,
                Blog = _context.Set<Blog>().Find(item.BlogId),
            });
        }

        public void Delete(int id)
        {
            Post post = _context.Set<Post>().Find(id);

            if (post != null) _context.Set<Post>().Remove(post);
        }

        public DALPost Get(Expression<Func<DALPost, bool>> predicate)
        {
            Expression<Func<Post, bool>> lambda = predicate.ConvertExpression();
            Post ormPost = _context.Set<Post>().AsExpandable().Where(lambda).FirstOrDefault();

            return ormPost?.ToDALEntity();
        }

        public DALPost Get(int id)
        {
            Post ormPost = _context.Set<Post>().FirstOrDefault(e => e.Id == id);

            return ormPost?.ToDALEntity();
        }

        public IEnumerable<DALPost> GetAll()
        {
            List<Post> ormComments = _context.Set<Post>().ToList();

            return RetrieveSet(ormComments);
        }

        public IEnumerable<DALPost> GetAll(Expression<Func<DALPost, bool>> predicate)
        {
            Expression<Func<Post, bool>> lambda = predicate.ConvertExpression();
            List<Post> ormComments = _context.Set<Post>().AsExpandable().Where(lambda).ToList();

            return RetrieveSet(ormComments);
        }

        public void Update(DALPost item)
        {
            Post post = _context.Set<Post>().Find(item.Id);

            if (post != null)
            {
                post.Title = item.Title;
                post.Annotation = item.Annotation;
                post.BlogId = item.BlogId;
                post.Text = item.Text;
                post.Blog = _context.Set<Blog>().Find(item.BlogId);
            }
        }

        private HashSet<DALPost> RetrieveSet(List<Post> ormPosts)
        {
            HashSet<DALPost> dalPosts = new HashSet<DALPost>();

            foreach (var ormPost in ormPosts)
                dalPosts.Add(ormPost.ToDALEntity());

            return dalPosts;
        }
    }
}
