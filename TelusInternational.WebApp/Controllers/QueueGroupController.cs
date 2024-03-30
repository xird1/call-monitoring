using Microsoft.AspNetCore.Mvc;
using TelusInternational.Business;

namespace TelusInternational.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueueGroupController : ControllerBase
    {
        private readonly IQueueGroupService _queueGroupService;
        private readonly ILogger<QueueGroupController> _logger;

        public QueueGroupController(ILogger<QueueGroupController> logger, IQueueGroupService queueGroupService)
        {
            _logger = logger;
            _queueGroupService = queueGroupService;
        }

        [Route("data")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queueGroups = await _queueGroupService.GetAll();

            // uncomment this to demonstrate refresh interval every 10 sec visually, assuming data is saved in database and then changes
            // because right now data is just stored in a json file in memory and modifying records requires app relaunch to be read by context
            queueGroups.Where(q => q.Name == "Audi").ToList().ForEach(f => {
                 f.MonitorData.TalkTime = new Random().Next(1, 500);
                 f.MonitorData.Offered = new Random().Next(1, 40);
             });

            return Ok(queueGroups);
        }
    }
}