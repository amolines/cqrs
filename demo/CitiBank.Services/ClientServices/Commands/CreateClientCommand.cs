using Xendor.CommandModel.Command;

namespace CitiBank.Services.ClientServices.Commands
{
    public class CreateClientCommand : ICommand
    {
        public CreateClientCommand( string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

        }


        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

    }
}