namespace Shopbridge.Inventory.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Shopbridge.Inventory.Api.Expressions;
    using Shopbridge.Inventory.Api.Models;
    using Shopbridge.Inventory.Api.Service;
    using Shopbridge.Framework.AspNetCore;
    using Shopbridge.Framework.CQRS;
    using Shopbridge.Framework.Utils.Grid;
    using Shopbridge.Inventory.Api.Validations;
    using Shopbridge.Framework.CQRS.Validation;

    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _service;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService service, IMediator mediator)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public Task<IActionResult> AddAsync(InventoryModel model)
        {
            var validation = new AddInventoryModelValidator().ValidationAsync(model);

            return validation.Result.Succeeded ? _service.AddAsync(model.ToDomain()).ResultAsync() : validation.ResultAsync();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(int id) => _service.DeleteAsync(id).ResultAsync();

        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(int id) => _service.GetAsync(id).ResultAsync();

        [HttpGet("grid")]
        public Task<IActionResult> GridAsync([FromQuery] GridParameters parameters) => _service.GridAsync(parameters).ResultAsync();

        [HttpPatch("{id}/deactivate")]
        public Task DeactivateAsync(int id) => _service.DeactivateAsync(id);

        [HttpGet]
        public Task<IActionResult> ListAsync() => _service.ListAsync().ResultAsync();

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(InventoryModel model) => _service.UpdateAsync(model.ToDomain()).ResultAsync();
    }
}