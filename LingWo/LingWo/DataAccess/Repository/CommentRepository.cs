using LingWo.DataAccess.Data;
using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using Microsoft.EntityFrameworkCore;

namespace LingWo.DataAccess.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Comment> GetAll() => _dbContext.Comments.ToList();

        public void Add(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Comments.Remove(_dbContext.Comments.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
        }

        public void Edit(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }


        public Comment GetById(int id) => _dbContext.Comments.FirstOrDefault(x => x.Id == id);
    }
}