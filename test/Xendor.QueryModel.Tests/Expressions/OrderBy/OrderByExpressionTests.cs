using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Expressions.OrderBy;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests.Expressions.OrderBy
{
    public class OrderByExpressionTests
    {

        [Fact]
        public void OrderByExpression_With_One_Property()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_sort", new StringValues("name")},
                {"_order", new StringValues("asc")}
            };
            var query = new QueryCollection(values);



            //Act
            var sort = OrderByExpression<UserMetaDataCriteria>.Extract(query);
            var text = sort.ToString();



            //Assert
            text.Should().Be("_sort=name&_order=asc");


        }

        [Fact]
        public void OrderByExpression_With_Two_Property()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_sort", new StringValues("name,lastName")},
                {"_order", new StringValues("asc,asc")}
            };
            var query = new QueryCollection(values);



            //Act
            var sort = OrderByExpression<UserMetaDataCriteria>.Extract(query);
            var text = sort.ToString();



            //Assert
            text.Should().Be("_sort=name,lastName&_order=asc,asc");


        }
        [Fact]
        public void OrderByExpression_OrderBy_Empty()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_sort", new StringValues("namee,lastName")},
                {"_order", new StringValues("asc,asc")}
            };
            var query = new QueryCollection(values);



            //Act
            var sort = OrderByExpression<UserMetaDataCriteria>.Extract(query);




            //Assert
            sort.Should().BeNull();


        }

    }
}