using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWatcher.API.Common.Models;
using TheWatcher.API.Common.Models.Contracts;
using TheWatcher.API.Panel.Models;
using TheWatcher.Domain.Core;
using TheWatcher.Domain.Core.QueryModels;

namespace TheWatcher.API.Panel.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PanelController : ControllerBase
    {
        private readonly ILogger<PanelController> _logger;
        private readonly TheWatcherDbContext _dbContext;

        public PanelController(ILogger<PanelController> logger, TheWatcherDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("watcher")]
        [ProducesResponseType(200, Type = typeof(IListResponse<WatcherQueryModel>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetWatchersAsync()
        {
            var model = await _dbContext.GetWatchers().OrderBy(item => item.Name).ToListAsync();

            var response = new ListResponse<WatcherQueryModel>(model);

            return response.ToOkResult();
        }

        [HttpGet("watcher/{id}")]
        [ProducesResponseType(200, Type = typeof(ISingleResponse<WatcherDetailsModel>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetWatcherAsync(short? id)
        {
            var entity = await _dbContext.GetWatcherAsync(id);

            if (entity == null)
                return NotFound();

            var response = new SingleResponse<WatcherDetailsModel>(new(entity));

            return response.ToOkResult();
        }

        [HttpGet("resource")]
        [ProducesResponseType(200, Type = typeof(IListResponse<ResourceQueryModel>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetResourcesAsync()
        {
            var model = await _dbContext.GetResources().ToListAsync();

            var response = new ListResponse<ResourceQueryModel>(model);

            return response.ToOkResult();
        }

        [HttpGet("resource/{id}")]
        [ProducesResponseType(200, Type = typeof(ISingleResponse<ResourceDetailsModel>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetResourceAsync(short? id)
        {
            var entity = await _dbContext.GetResourceAsync(id);

            if (entity == null)
                return NotFound();

            var response = new SingleResponse<ResourceDetailsModel>(new(entity));

            return response.ToOkResult();
        }
    }
}
