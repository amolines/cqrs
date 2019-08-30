using FluentAssertions;
using Xendor.QueryModel.Expressions;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class PaginateTest
    {
        [Fact]
        public void Paginate_Page_7_And_Limit_20()
        {
            //Arrange
            var paginate = new Paginate(7, 20);

            //Act
            var text = paginate.ToString();


            //Assert
            text.Should().Be("_page=7&_limit=20");


        }
        [Fact]
        public void Paginate_Page_1_With_Default_Limit()
        {
            //Arrange
            var paginate = new Paginate(1 );

            //Act
            var text = paginate.ToString();


            //Assert
            text.Should().Be("_page=1&_limit=10");


        }
    }
}
