using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Criteria.Paginate;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class PaginateTest
    {
        [Fact]
        public void Paginate_Page_Empty()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_pages", new StringValues("7")}
            };
            var query = new QueryCollection(values);



            //Act
            var paginate = PaginateExpression.Extract(query);


            //Assert
            paginate.Should().BeOfType<PaginateEmptyExpression>();


        }
        [Fact]
        public void Paginate_Page_7_And_Limit_20()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_page", new StringValues("7")}, {"_limit", new StringValues("20")}
            };
            var query = new QueryCollection(values);



            //Act
            var paginate = PaginateExpression.Extract(query);
            var text = paginate.ToString();

            //Assert
            text.Should().Be("_page=7&_limit=20");


        }
        [Fact]
        public void Paginate_Page_1_With_Default_Limit()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_page", new StringValues("7")}
            };
            var query = new QueryCollection(values);



            //Act
            var paginate = PaginateExpression.Extract(query);
            var text = paginate.ToString();

            //Assert
            text.Should().Be("_page=7&_limit=10");


        }
    }
}
