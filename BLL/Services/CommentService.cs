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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICommentRepository _commentRepository;

        public CommentService(IUnitOfWork unitOfWork, ICommentRepository repository)
        {
            _unitOfWork = unitOfWork;
            _commentRepository = repository;
        }

        public void Create(CommentEntity item)
        {
            _commentRepository.Create(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public CommentEntity Get(int id) => _commentRepository.Get(id).ToBLLEntity();

        public CommentEntity Get(Expression<Func<CommentEntity, bool>> predicate) => _commentRepository.Get(predicate.ConvertExpression()).ToBLLEntity();

        public IEnumerable<CommentEntity> GetAll() => _commentRepository.GetAll().Select(item => item.ToBLLEntity());

        public IEnumerable<CommentEntity> GetAll(Expression<Func<CommentEntity, bool>> predicate) => _commentRepository.GetAll(predicate.ConvertExpression()).Select(item => item.ToBLLEntity());

        public void Update(CommentEntity item)
        {
            _commentRepository.Update(item.ToDALEntity());
            _unitOfWork.Commit();
        }

        public int GetCount(int postId) => _commentRepository.GetCount(postId);

        public IEnumerable<CommentEntity> GetByPage(int size, int page, int postId) => _commentRepository.GetByPage(size, page, postId).Select(x => x.ToBLLEntity());
    }
}
