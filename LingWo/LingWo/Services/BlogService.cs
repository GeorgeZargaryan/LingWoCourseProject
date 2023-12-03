using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using LingWo.Services.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LingWo.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public void Add(Blog blog) => _blogRepository.Add(blog);

        public void Edit(Blog blog) => _blogRepository.Edit(blog);

        public IEnumerable<Blog> GetAll() => _blogRepository.GetAll();

        public Blog GetById(int id) => _blogRepository.GetById(id);

        public IEnumerable<SelectListItem> GetDropDown() => _blogRepository.GetDropDown();

        public void Remove(int id) => _blogRepository.Delete(id);
    }
}