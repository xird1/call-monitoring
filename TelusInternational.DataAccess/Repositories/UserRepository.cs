using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelusInternational.DataAccess.Context;
using TelusInternational.DataAccess.Entities;
using TelusInternational.DataAccess.Repositories.Interfaces;

namespace TelusInternational.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.Where(u=>u.Username == username).FirstOrDefaultAsync();
        }
    }
}
