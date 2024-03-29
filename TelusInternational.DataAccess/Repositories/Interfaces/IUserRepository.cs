using TelusInternational.DataAccess.Entities;

namespace TelusInternational.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
