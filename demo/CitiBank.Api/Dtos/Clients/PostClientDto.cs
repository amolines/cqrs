using CitiBank.Services.ClientServices.Commands;

namespace CitiBank.Api.Dtos.Clients
{
    public class PostClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static implicit operator CreateClientCommand(PostClientDto clientDto)
        {
           return new CreateClientCommand(clientDto.FirstName,clientDto.LastName, clientDto.Email);
        }


    }
}