using CitiBank.Domain.AggregatesModel.ProductAggregate;
using Xendor.CommandModel.Command;

namespace CitiBank.Services.ProductServices.Commands
{
    public class CreateProductCommand : ICommand
    {
        public CreateProductCommand(string name , ProductType productType)
        {
            Name = name;
            ProductType = productType;
        }
        public string Name { get; }
        public ProductType ProductType { get; }

    }
}