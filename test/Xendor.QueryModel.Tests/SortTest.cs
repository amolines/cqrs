using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Criteria.OrderBy;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class SortTest
    {

        [Fact]
        public void Sort_With_One_Property()
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
        public void Sort_With_Two_Property()
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
        public void Sort_With_Empty()
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
            sort.Should().BeOfType<OrderByEmptyExpression<UserMetaDataCriteria>>();


        }

    }
}