using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DTO;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class BlogService : IService<BlogEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<DALBlog> _blogRepository;

        public BlogService(IUnitOfWork unitOfWork, IRepository<DALBlog> repository)
        {
            _unitOfWork = unitOfWork;
            _blogRepository = repository;
        }

        public void Create(BlogEntity item)
        {
            _blogRepository.Create(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _blogRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public BlogEntity Get(int id) => _blogRepository.Get(id).ToBLLEntity();

        public BlogEntity Get(Expression<Func<BlogEntity, bool>> predicate) => _blogRepository.Get(predicate.ConvertExpression()).ToBLLEntity();

        public IEnumerable<BlogEntity> GetAll() => _blogRepository.GetAll().Select(item => item.ToBLLEntity());

        public IEnumerable<BlogEntity> GetAll(Expression<Func<BlogEntity, bool>> predicate) => _blogRepository.GetAll(predicate.ConvertExpression()).Select(item => item.ToBLLEntity());

        public void Update(BlogEntity item)
        {
            _blogRepository.Update(item.ToDALEntity());
            _unitOfWork.Commit();
        }
    }
}
