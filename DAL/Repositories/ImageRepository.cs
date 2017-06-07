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
    public class ImageRepository : IRepository<DALImage>
    {
        public void Create(DALImage item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DALImage Get(Expression<DALImage> predicate)
        {
            throw new NotImplementedException();
        }

        public DALImage Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALImage> GetAll(Predicate<DALImage> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DALImage item)
        {
            throw new NotImplementedException();
        }
    }
}
