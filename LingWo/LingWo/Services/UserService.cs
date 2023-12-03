using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using LingWo.Services.Abstract;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;

namespace LingWo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(ApplicationUser user) => _userRepository.Add(user);

        public void Edit(ApplicationUser user) => _userRepository.Edit(user);

        public IEnumerable<ApplicationUser> GetAll() => _userRepository.GetAll();

        public ApplicationUser GetById(string id) => _userRepository.GetById(id);

        public void Remove(string id) => _userRepository.Delete(id);
    }
}