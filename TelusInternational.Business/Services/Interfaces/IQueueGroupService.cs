using TelusInternational.Business.Dto;

namespace TelusInternational.Business
{
    public interface IQueueGroupService
    {
        Task<List<QueueGroupDto>> GetAll();
    }
}
