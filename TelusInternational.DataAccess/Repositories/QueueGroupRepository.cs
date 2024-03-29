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
    public class QueueGroupRepository : IQueueGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QueueGroupRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QueueGroup>> GetAll()
        {
            return await _dbContext.QueueGroups.Include("MonitorData").ToListAsync();
        }
    }
}
