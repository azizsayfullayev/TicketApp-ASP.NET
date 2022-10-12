using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllAsync();

        Task<User> CreateAsync(User user);

        Task<User> FindByEmailAsync(string email);

        Task<User?> GetAsync(long id);

        Task<bool> DeleteAsync(long id);

        Task<User> UpdateAsync(long id, User user);
    }
}
