using System;
using CitiBank.Services.ClientServices.Commands;

namespace CitiBank.Api.Dtos.Clients
{
    public class PostProductDto 
    {
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public string Number { get; set; }

        public static implicit operator SubscribeProductCommand(PostProductDto productDto)
        {
            return new SubscribeProductCommand(productDto.ProductId, productDto.Number,productDto.ClientId);
        }

    }
}