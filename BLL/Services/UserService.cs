using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using System.Linq.Expressions;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DTO;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IService<UserEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<DALUser> _userRepository;

        public UserService(IUnitOfWork unitOfWork, IRepository<DALUser> repository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = repository;
        }

        public void Create(UserEntity item)
        {
            _userRepository.Create(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public UserEntity Get(int id) => _userRepository.Get(id).ToBLLEntity();

        public UserEntity Get(Expression<Func<UserEntity, bool>> predicate) => _userRepository.Get(predicate.ConvertExpression()).ToBLLEntity();

        public IEnumerable<UserEntity> GetAll() => _userRepository.GetAll().Select(item => item.ToBLLEntity());

        public IEnumerable<UserEntity> GetAll(Expression<Func<UserEntity, bool>> predicate) => _userRepository.GetAll(predicate.ConvertExpression()).Select(item => item.ToBLLEntity());

        public void Update(UserEntity item)
        {
            _userRepository.Update(item.ToDALEntity());
            _unitOfWork.Commit();
        }
    }
}
