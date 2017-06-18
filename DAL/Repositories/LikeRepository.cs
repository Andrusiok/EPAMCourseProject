using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using ORM;
using System.Data.Entity;
using LinqKit;

namespace DAL.Repositories
{
    public class LikeRepository : IRepository<DALLike>
    {
        private DbContext _context;

        public LikeRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DALLike item)
        {
            _context.Set<Like>().Add(new Like()
            {
                UserId = item.UserId,
                User = _context.Set<User>().Find(item.PostId),
                PostId = item.PostId,
                Post = _context.Set<Post>().Find(item.PostId)
            });
        }

        public void Delete(int id)
        {
            Like like = _context.Set<Like>().Find(id);

            if (!ReferenceEquals(like, null))
                _context.Set<Like>().Remove(like);
        }

        public DALLike Get(Expression<Func<DALLike, bool>> predicate)
        {
            Expression<Func<Like, bool>> lambda = predicate.ConvertExpression();
            Like ormLike = _context.Set<Like>().AsExpandable().Where(lambda).FirstOrDefault();

            return ormLike?.ToDALEntity();
        }

        public DALLike Get(int id)
        {
            Like ormLikes = _context.Set<Like>().FirstOrDefault(e => e.Id == id);

            return ormLikes?.ToDALEntity();
        }

        public IEnumerable<DALLike> GetAll()
        {
            List<Like> ormLikes = _context.Set<Like>().ToList();

            return RetrieveSet(ormLikes);
        }

        public IEnumerable<DALLike> GetAll(Expression<Func<DALLike, bool>> predicate)
        {
            Expression<Func<Like, bool>> lambda = predicate.ConvertExpression();
            List<Like> ormImages = _context.Set<Like>().AsExpandable().Where(lambda).ToList();

            return RetrieveSet(ormImages);
        }

        public void Update(DALLike item)
        {
            Like like = _context.Set<Like>().Find(item.Id);

            if (!ReferenceEquals(like, null))
            {
                like.UserId = item.UserId;
                like.User = _context.Set<User>().Find(item.PostId);
                like.PostId = item.PostId;
                like.Post = _context.Set<Post>().Find(item.PostId);
            }
        }

        private HashSet<DALLike> RetrieveSet(List<Like> ormLikes)
        {
            HashSet<DALLike> dalImages = new HashSet<DALLike>();

            foreach (var ormImage in ormLikes)
                dalImages.Add(ormImage.ToDALEntity());

            return dalImages;
        }
    }
}
