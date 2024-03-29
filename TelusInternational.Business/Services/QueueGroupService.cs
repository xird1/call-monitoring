using AutoMapper;
using TelusInternational.Business.Dto;
using TelusInternational.DataAccess.Entities;
using TelusInternational.DataAccess.Repositories.Interfaces;

namespace TelusInternational.Business.Services
{
    public class QueueGroupService : IQueueGroupService
    {
        private readonly IQueueGroupRepository _queueGroupRepository;
        private Mapper _queueGroupMapper;

        public QueueGroupService(IQueueGroupRepository queueGroupRepository)
        {
            _queueGroupRepository = queueGroupRepository;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MonitorData, MonitorDataDto>().ReverseMap();
                cfg.CreateMap<QueueGroup, QueueGroupDto>()
                .ReverseMap();
            });
            _queueGroupMapper = new Mapper(mapperConfig);
        }

        public async Task<List<QueueGroupDto>> GetAll()
        {
            var queueGroups = await _queueGroupRepository.GetAll();
            return _queueGroupMapper.Map<List<QueueGroup>, List<QueueGroupDto>>(queueGroups);
        }
    }
}
