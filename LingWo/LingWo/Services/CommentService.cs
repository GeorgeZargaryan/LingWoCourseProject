using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using LingWo.Services.Abstract;

namespace LingWo.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void Add(Comment comment) => _commentRepository.Add(comment);

        public void Edit(Comment comment) => _commentRepository.Edit(comment);

        public IEnumerable<Comment> GetAll() => _commentRepository.GetAll();

        public Comment GetById(int id) => _commentRepository.GetById(id);

        public void Remove(int id) => _commentRepository.Delete(id);
    }
}