using CitiBank.Domain.AggregatesModel.ProductAggregate;
using CitiBank.Services.ProductServices.Commands;

namespace CitiBank.Api.Dtos.Products
{
    public class PostProductDto
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public static implicit operator CreateProductCommand(PostProductDto productDto)
        {
            ProductType type;
            switch (productDto.Type)
            {
                case "Checking":
                    type = ProductType.Checking;
                    break;
                default:
                    type = ProductType.Savings;
                    break;
            }

            return new CreateProductCommand(productDto.Name, type);
        }
    }
}