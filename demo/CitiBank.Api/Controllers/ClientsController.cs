using System;
using System.Threading.Tasks;
using CitiBank.Api.Dtos.Clients;
using CitiBank.Services.ClientServices.Commands;
using Microsoft.AspNetCore.Mvc;
using Xendor.CommandModel.Command;

namespace CitiBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public ClientsController(ICommandBus commandBus)
        {
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        // POST api/clients
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] PostClientDto clientDto)
        {
            CreateClientCommand cmd = clientDto;
            var commandResult = await _commandBus.Submit(cmd);
            return commandResult;
        }

        // Put api/clients/{id}
        [HttpPut("{id}")]
        public async Task<ICommandResult>  Put( Guid id , [FromBody] PutClientDto clientDto)
        {
            clientDto.Id = id;
            UpdateClientCommand cmd = clientDto;
            var commandResult = await _commandBus.Submit(cmd);
            return  commandResult;
        }

        // POST api/clients/{id}/products
        [HttpPost("{id}/products")]
        public async Task<ICommandResult> Post(Guid id , [FromBody] PostProductDto productDto)
        {
            productDto.ClientId = id;
            SubscribeProductCommand cmd = productDto;
            var commandResult = await _commandBus.Submit(cmd);
            return commandResult;
        }

    }
}
