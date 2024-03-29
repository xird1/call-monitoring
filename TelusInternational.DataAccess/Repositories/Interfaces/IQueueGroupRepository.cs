using TelusInternational.DataAccess.Entities;

namespace TelusInternational.DataAccess.Repositories.Interfaces
{
    public interface IQueueGroupRepository
    {
        Task<List<QueueGroup>> GetAll();
    }
}
