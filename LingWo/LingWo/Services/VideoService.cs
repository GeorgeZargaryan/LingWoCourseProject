using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using LingWo.Services.Abstract;

namespace LingWo.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public void Add(Video video) => _videoRepository.Add(video);

        public void Edit(Video video) => _videoRepository.Edit(video);

        public IEnumerable<Video> GetAll() => _videoRepository.GetAll();

        public Video GetById(int id) => _videoRepository.GetById(id);

        public void Remove(int id) => _videoRepository.Delete(id);
    }
}