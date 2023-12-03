using LingWo.DataAccess.Data;
using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using Microsoft.EntityFrameworkCore;

namespace LingWo.DataAccess.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ArticleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Article> GetAll() => _dbContext.News.ToList();

        public void Add(Article article)
        {
            _dbContext.News.Add(article);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.News.Remove(_dbContext.News.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
        }

        public void Edit(Article article)
        {
            _dbContext.News.Update(article);
            _dbContext.SaveChanges();
        }


        public Article GetById(int id) => _dbContext.News.FirstOrDefault(x => x.Id == id);
    }
}