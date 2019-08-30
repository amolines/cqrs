using System;
using Xendor.QueryModel;

namespace CitiBank.View.Views.Accounts.Dtos
{
    public class ProductDto : IDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}