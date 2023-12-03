using LingWo.DataAccess.Data;
using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using Microsoft.EntityFrameworkCore;

namespace LingWo.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ApplicationUser> GetAll() => _dbContext.Users.ToList();

        public void Add(ApplicationUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            _dbContext.Users.Remove(_dbContext.Users.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
        }

        public void Edit(ApplicationUser user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }


        public ApplicationUser GetById(string id) => _dbContext.Users.FirstOrDefault(x => x.Id == id);
    }
}