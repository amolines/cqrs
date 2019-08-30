using System;
using Xendor.QueryModel;

namespace CitiBank.View.Views.Accounts.Dtos
{
    public class OperationDto : IDto
    {

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}