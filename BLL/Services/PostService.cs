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
    public class PostService:IService<PostEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<DALPost> _postRepository;

        public PostService(IUnitOfWork unitOfWork, IRepository<DALPost> repository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = repository;
        }

        public void Create(PostEntity item)
        {
            _postRepository.Create(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public PostEntity Get(int id) => _postRepository.Get(id).ToBLLEntity();

        public PostEntity Get(Expression<Func<PostEntity, bool>> predicate) => _postRepository.Get(predicate.ConvertExpression()).ToBLLEntity();

        public IEnumerable<PostEntity> GetAll() => _postRepository.GetAll().Select(item => item.ToBLLEntity());

        public IEnumerable<PostEntity> GetAll(Expression<Func<PostEntity, bool>> predicate) => _postRepository.GetAll(predicate.ConvertExpression()).Select(item => item.ToBLLEntity());

        public void Update(PostEntity item)
        {
            _postRepository.Update(item.ToDALEntity());
            _unitOfWork.Commit();
        }
    }
}
