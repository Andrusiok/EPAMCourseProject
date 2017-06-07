﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : IDALEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Predicate<T> predicate);

        T Get(int id);

        T Get(Expression<T> predicate);

        void Create(T item);

        void Delete(int id);

        void Update(T item);
    }
}
