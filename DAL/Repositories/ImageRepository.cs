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
    public class ImageRepository : IRepository<DALImage>
    {
        private DbContext _context;

        public ImageRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DALImage item)
        {
            _context.Set<Image>().Add(new Image()
            {
                ImagePath = item.Path,
                PostId = item.PostId,
                Post = _context.Set<Post>().Find(item.PostId)
            });
        }

        public void Delete(int id)
        {
            Image comment = _context.Set<Image>().Find(id);

            if (comment != null) _context.Set<Image>().Remove(comment);
        }

        public DALImage Get(Expression<Func<DALImage, bool>> predicate)
        {
            Expression<Func<Image, bool>> lambda = predicate.ConvertExpression();
            Image ormImage = _context.Set<Image>().AsExpandable().Where(lambda).FirstOrDefault();

            return ormImage?.ToDALEntity();
        }

        public DALImage Get(int id)
        {
            Image ormImages = _context.Set<Image>().FirstOrDefault(e => e.Id == id);

            return ormImages?.ToDALEntity();
        }

        public IEnumerable<DALImage> GetAll()
        {
            List<Image> ormImages = _context.Set<Image>().ToList();

            return RetrieveSet(ormImages);
        }

        public IEnumerable<DALImage> GetAll(Expression<Func<DALImage, bool>> predicate)
        {
            Expression<Func<Image, bool>> lambda = predicate.ConvertExpression();
            List<Image> ormImages = _context.Set<Image>().AsExpandable().Where(lambda).ToList();

            return RetrieveSet(ormImages);
        }

        public void Update(DALImage item)
        {
            Image image = _context.Set<Image>().Find(item.Id);

            if (image != null)
            {
                image.ImagePath = item.Path;
                image.PostId = item.PostId;
                image.Post = _context.Set<Post>().Find(item.PostId);
            }
        }

        private HashSet<DALImage> RetrieveSet(List<Image> ormImages)
        {
            HashSet<DALImage> dalImages = new HashSet<DALImage>();

            foreach (var ormImage in ormImages)
                dalImages.Add(ormImage.ToDALEntity());

            return dalImages;
        }
    }
}
