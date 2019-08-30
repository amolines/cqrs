using System;
using CitiBank.Services.ClientServices.Commands;

namespace CitiBank.Api.Dtos.Clients
{
    public class PutClientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public static implicit operator UpdateClientCommand(PutClientDto clientDto)
        {
            return new UpdateClientCommand(clientDto.Id , clientDto.FirstName, clientDto.LastName, clientDto.Email);
        }
    }
}