using System;
using Xendor.QueryModel;

namespace CitiBank.View.Views.Accounts.Dtos
{
    public class ClientDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}