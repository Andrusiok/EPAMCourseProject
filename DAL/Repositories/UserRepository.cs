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
    public class UserRepository : IRepository<DALUser>
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DALUser item)
        {
            if (item.RoleId == default(int))
            {
                item.RoleId = 2;
            }

            _context.Set<User>().Add(new User()
            {
                Name = item.Name,
                RoleId = item.RoleId,
                Password = item.Password,
                Email = item.Mail,
                
            });
        }

        public void Delete(int id)
        {
            User user = _context.Set<User>().Find(id);
            IEnumerable<Like> likes = _context.Set<Like>().AsExpandable().Where(x=>x.UserId == id).ToList();
            IEnumerable<Comment> comments = _context.Set<Comment>().AsExpandable().Where(x => x.UserId == id).ToList();

            if (user != null)
            {
                _context.Set<Like>().RemoveRange(likes);
                _context.Set<Comment>().RemoveRange(comments);
                _context.Set<User>().Remove(user);
            }
        }

        public DALUser Get(Expression<Func<DALUser, bool>> predicate)
        {
            Expression<Func<User, bool>> lambda = predicate.ConvertExpression();
            User ormUser = _context.Set<User>().AsExpandable().Where(lambda).FirstOrDefault();

            return ormUser?.ToDALEntity();
        }

        public DALUser Get(int id)
        {
            User ormUser = _context.Set<User>().FirstOrDefault(e => e.Id == id);

            return ormUser?.ToDALEntity();
        }

        public IEnumerable<DALUser> GetAll()
        {
            List<User> ormUsers = _context.Set<User>().ToList();

            return RetrieveSet(ormUsers);
        }

        public IEnumerable<DALUser> GetAll(Expression<Func<DALUser, bool>> predicate)
        {
            Expression<Func<User, bool>> lambda = predicate.ConvertExpression();
            List<User> ormUsers = _context.Set<User>().AsExpandable().Where(lambda).ToList();

            return RetrieveSet(ormUsers);
        }

        public void Update(DALUser item)
        {
            User user = _context.Set<User>().Find(item.Id);

            if (user != null)
            {
                user.Name = item.Name;
                user.Password = item.Password;
                user.RoleId = item.RoleId;
                user.Role = _context.Set<Role>().Find(item.RoleId);
                user.Email = item.Mail;
            }
        }

        private HashSet<DALUser> RetrieveSet(List<User> ormUsers)
        {
            HashSet<DALUser> dalUsers = new HashSet<DALUser>();

            foreach (var ormUser in ormUsers)
                dalUsers.Add(ormUser.ToDALEntity());

            return dalUsers;
        }
    }
}
