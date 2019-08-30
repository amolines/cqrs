using System;
using System.Threading.Tasks;
using CitiBank.Api.Dtos.Products;
using CitiBank.Services.ProductServices.Commands;
using Microsoft.AspNetCore.Mvc;
using Xendor.CommandModel.Command;

namespace CitiBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public ProductsController(ICommandBus commandBus)
        {
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        // POST api/services
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] PostProductDto productDto)
        {
            CreateProductCommand cmd = productDto;
            var commandResult = await _commandBus.Submit(cmd);
            return commandResult;
        }

    }
  
}
