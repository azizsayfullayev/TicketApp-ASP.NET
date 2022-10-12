using TicketApp.WebApi.DbContexts;
using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await  _appDbContext.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user is not null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<User> FindByEmailAsync(string email)
        {

            var user =  _appDbContext.Users.FirstOrDefault(x => x.Email == email);
            if (user is not null)
            {
                return user;
            }
            return null;
            
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return _appDbContext.Users;
        }

        public async Task<User?> GetAsync(long id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user is not null)
            {
                return user;
            }
            return null;

        }

        public async Task<User> UpdateAsync(long id, User user)
        {
            user.Id = id;
            _appDbContext.Update(user);

            await _appDbContext.SaveChangesAsync();
            return user;
        }
    }
}
