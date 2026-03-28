using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWatcher.API.Common.Models;
using TheWatcher.API.Common.Models.Contracts;
using TheWatcher.Domain.Core;
using TheWatcher.Domain.Core.QueryModels;

namespace TheWatcher.API.Monitor.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class MonitorController : ControllerBase
    {
        private readonly ILogger<MonitorController> _logger;
        private readonly TheWatcherDbContext _dbContext;

        public MonitorController(ILogger<MonitorController> logger, TheWatcherDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("monitor")]
        [ProducesResponseType(200, Type = typeof(IListResponse<ResourceWatchQueryModel>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMonitorAsync()
        {
            var model = await _dbContext.GetResourceWatchItems().ToListAsync();

            var response = new ListResponse<ResourceWatchQueryModel>(model);

            return response.ToOkResult();
        }
    }
}
