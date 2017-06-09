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
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Update(T item);
        void Delete(int id);
        void Create(T item);
    }
}
