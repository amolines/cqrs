using System;
using System.Collections.Generic;
using Xendor.QueryModel;

namespace CitiBank.View.Views.Accounts.Dtos
{
    public class AccountDto : RootDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public ClientDto Client { get; set; }
        public ProductDto Product { get; set; }
        public IEnumerable<OperationDto> Operations { get; set; }

    }
}