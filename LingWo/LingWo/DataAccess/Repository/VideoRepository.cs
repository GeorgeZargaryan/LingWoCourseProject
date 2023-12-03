using LingWo.DataAccess.Data;
using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using Microsoft.EntityFrameworkCore;

namespace LingWo.DataAccess.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VideoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Video> GetAll() => _dbContext.Videos.ToList();

        public void Add(Video video)
        {
            _dbContext.Videos.Add(video);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Videos.Remove(_dbContext.Videos.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
        }

        public void Edit(Video video)
        {
            _dbContext.Videos.Update(video);
            _dbContext.SaveChanges();
        }


        public Video GetById(int id) => _dbContext.Videos.FirstOrDefault(x => x.Id == id);
    }
}