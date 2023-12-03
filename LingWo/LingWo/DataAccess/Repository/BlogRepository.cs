using LingWo.DataAccess.Data;
using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LingWo.DataAccess.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Blog> GetAll() => _dbContext.Blogs.ToList();

        public void Add(Blog blog)
        {
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Blogs.Remove(_dbContext.Blogs.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
        }

        public void Edit(Blog blog)
        {
            _dbContext.Blogs.Update(blog);
            _dbContext.SaveChanges();
        }


        public Blog GetById(int id) => _dbContext.Blogs.FirstOrDefault(x => x.Id == id);

        public IEnumerable<SelectListItem> GetDropDown() => _dbContext.Blogs.Select(blog => new SelectListItem
        {
            Text = blog.BlogTitle,
            Value = blog.Id.ToString()
        });
    }
}