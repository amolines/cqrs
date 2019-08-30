using System;
using Xendor.CommandModel.Command;

namespace CitiBank.Services.ClientServices.Commands
{
    public class UpdateClientCommand : ICommand
    {
        public UpdateClientCommand(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;

        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}