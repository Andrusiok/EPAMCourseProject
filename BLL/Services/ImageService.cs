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
    public class ImageService : IService<ImageEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<DALImage> _imageRepository;

        public ImageService(IUnitOfWork unitOfWork, IRepository<DALImage> repository)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = repository;
        }

        public void Create(ImageEntity item)
        {
            _imageRepository.Create(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _imageRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public ImageEntity Get(int id) => _imageRepository.Get(id).ToBLLEntity();

        public ImageEntity Get(Expression<Func<ImageEntity, bool>> predicate) => _imageRepository.Get(predicate.ConvertExpression()).ToBLLEntity();

        public IEnumerable<ImageEntity> GetAll() => _imageRepository.GetAll().Select(item => item.ToBLLEntity());

        public IEnumerable<ImageEntity> GetAll(Expression<Func<ImageEntity, bool>> predicate) => _imageRepository.GetAll(predicate.ConvertExpression()).Select(item => item.ToBLLEntity());

        public void Update(ImageEntity item)
        {
            _imageRepository.Update(item.ToDALEntity());
            _unitOfWork.Commit();
        }
    }
}

