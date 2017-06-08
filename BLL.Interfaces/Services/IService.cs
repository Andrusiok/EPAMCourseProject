using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using System.Linq.Expressions;

namespace BLL.Interfaces.Services
{
    public interface IService<T> where T:IBLLEntity
    {
        T Get();
        T Get(Expression<Func<UserEntity, bool>> predicate);
        T GetAll(Expression<Func<UserEntity, bool>> predicate);
        void Update(T item);
        void Delete(int id);
        void Create(T item);
    }
}
