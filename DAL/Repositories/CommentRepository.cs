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
    public class CommentRepository : IRepository<DALComment>
    {
        private DbContext _context;

        public CommentRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DALComment item)
        {
            _context.Set<Comment>().Add(new Comment()
            {
                Date = DateTime.Now,
                Entity = item.Entity,
                PostId = item.PostId,
                Post = _context.Set<Post>().Find(item.PostId),
                UserId = item.UserId,
                User = _context.Set<User>().Find(item.UserId)               
            });
        }

        public void Delete(int id)
        {
            Comment comment = _context.Set<Comment>().Find(id);

            if (comment != null) _context.Set<Comment>().Remove(comment);
        }

        public DALComment Get(Expression<Func<DALComment, bool>> predicate)
        {
            Expression<Func<Comment, bool>> lambda = predicate.ConvertExpression();
            Comment ormComment = _context.Set<Comment>().AsExpandable().Where(lambda).FirstOrDefault();

            return ormComment?.ToDALEntity();
        }

        public DALComment Get(int id)
        {
            Comment ormUser = _context.Set<Comment>().FirstOrDefault(e => e.Id == id);

            return ormUser?.ToDALEntity();
        }

        public IEnumerable<DALComment> GetAll()
        {
            List<Comment> ormComments = _context.Set<Comment>().ToList();

            return RetrieveSet(ormComments);
        }

        public IEnumerable<DALComment> GetAll(Expression<Func<DALComment, bool>> predicate)
        {
            Expression<Func<Comment, bool>> lambda = predicate.ConvertExpression();
            List<Comment> ormComments = _context.Set<Comment>().AsExpandable().Where(lambda).ToList();

            return RetrieveSet(ormComments);
        }

        public void Update(DALComment item)
        {
            Comment comment = _context.Set<Comment>().Find(item.Id);

            if (comment != null)
            {
                comment.Date = new DateTime();
                comment.Entity = item.Entity;
                comment.PostId = item.PostId;
                comment.Post = _context.Set<Post>().Find(item.PostId);
                comment.UserId = item.UserId;
                comment.User = _context.Set<User>().Find(item.UserId);
            }
        }

        private HashSet<DALComment> RetrieveSet(List<Comment> ormComments)
        {
            HashSet<DALComment> dalComments = new HashSet<DALComment>();

            foreach (var ormUser in ormComments)
                dalComments.Add(ormUser.ToDALEntity());

            return dalComments;
        }
    }
}
