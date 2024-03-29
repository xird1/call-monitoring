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
            return Ok(queueGroups);
        }
    }
}