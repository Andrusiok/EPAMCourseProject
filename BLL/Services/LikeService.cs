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
    public class LikeService : IService<LikeEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<DALLike> _likeRepository;

        public LikeService(IUnitOfWork unitOfWork, IRepository<DALLike> repository)
        {
            _unitOfWork = unitOfWork;
            _likeRepository = repository;
        }

        public void Create(LikeEntity item)
        {
            _likeRepository.Create(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _likeRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public LikeEntity Get(int id) => _likeRepository.Get(id).ToBLLEntity();

        public LikeEntity Get(Expression<Func<LikeEntity, bool>> predicate) => _likeRepository.Get(predicate.ConvertExpression()).ToBLLEntity();

        public IEnumerable<LikeEntity> GetAll() => _likeRepository.GetAll().Select(item => item.ToBLLEntity());

        public IEnumerable<LikeEntity> GetAll(Expression<Func<LikeEntity, bool>> predicate) => _likeRepository.GetAll(predicate.ConvertExpression()).Select(item => item.ToBLLEntity());

        public void Update(LikeEntity item)
        {
            _likeRepository.Update(item.ToDALEntity());
            _unitOfWork.Commit();
        }
    }
}
