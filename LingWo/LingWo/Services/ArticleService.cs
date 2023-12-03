using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using LingWo.Services.Abstract;

namespace LingWo.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void Add(Article article) => _articleRepository.Add(article);

        public void Edit(Article article) => _articleRepository.Edit(article);

        public IEnumerable<Article> GetAll() => _articleRepository.GetAll();

        public Article GetById(int id) => _articleRepository.GetById(id);

        public void Remove(int id) => _articleRepository.Delete(id);
    }
}