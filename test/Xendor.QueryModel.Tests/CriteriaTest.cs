using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Expressions.OrderBy;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class CriteriaTest
    {
        [Fact]
        public void Criteria_With_Filters_In()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"id",new StringValues(new string[]{"1","2","4"})}
            });
            var criteria = new Criteria<UserFilter>("/api/users", query);

            //Act
            var value = criteria.ToString();


            //Assert
            criteria.Filters.Filters.Count().Should().Be(3);
            value.Should().Be("id=1&id=2&id=4");

        }



        [Fact]
        public void Criteria_With_Operators_gt_and_lt()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"age_gt", new StringValues("25")},
                {"age_lt", new StringValues("20")}
            });
            var criteria = new Criteria<UserFilter>("/api/users", query);

            //Act
            var value = criteria.ToString();


            //Assert
            criteria.Operators.Operators.Count().Should().Be(2);
            value.Should().Be("age_gt=25&age_lt=20");

        }

        [Fact]
        public void Criteria_With_FullTextSearch()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_q",new StringValues( "alejandro")}
            });
            var criteria = new Criteria<UserFilter>("/api/users", query);

            //Act
            var value = criteria.ToString();


            //Assert
            criteria.FullTextSearch.Name.Count().Should().Be(2);
            value.Should().Be("_q=alejandro");

        }


        [Fact]
        public void Criteria_With_Filters()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"name",new StringValues( "alejandro")},
                {"lastName",new StringValues( "molines")},
                {"address.cp",new StringValues( "08204")}
            });
            var criteria = new Criteria<UserFilter>("/api/users", query);

            //Act
            var value = criteria.ToString();


            //Assert
            criteria.Filters.Filters.Count().Should().Be(3);
            value.Should().Be("name=alejandro&lastName=molines&address.cp=08204");

        }

        [Fact]
        public void Criteria_With_Paginate()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_page",new StringValues( "7")}
            });

            //Act
            var criteria = new Criteria<UserFilter>("/api/users", query);


            //Assert
            criteria.Paginate.Limit.Should().Be(10);
            criteria.Paginate.Page.Should().Be(7);

        }
        [Fact]
        public void Criteria_With_Paginate_Limit()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_page",new StringValues( "7")},
                {"_limit",new StringValues( "20")}
            });

            //Act
            var criteria = new Criteria<UserFilter>("/api/users", query);


            //Assert
            criteria.Paginate.Limit.Should().Be(20);
            criteria.Paginate.Page.Should().Be(7);

        }
    
      

        [Fact]
        public void Criteria_With_Sort()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_sort",new StringValues( "name,lastName")},
                {"_order",new StringValues( "desc,asc")}
            });

            //Act
            var criteria = new Criteria<UserFilter>("/api/users", query);


            //Assert
            criteria.Sort.Fields.Count().Should().Be(2);

        }
        [Fact]
        public void Criteria_With_Sort_Null()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_sort",new StringValues( "namer,lastName")},
                {"_order",new StringValues( "desc,asc")}
            });

            //Act
            var criteria = new Criteria<UserFilter>("/api/users", query);


            //Assert
            criteria.Sort.Should().BeNull();

        }
        [Fact]
        public void Criteria_With_Slice_End()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_start",new StringValues( "20")},
                {"_end",new StringValues( "30")}
            });

            //Act
            var criteria = new Criteria<UserFilter>("/api/users", query);


            //Assert
            criteria.Slice.Start.Should().Be(20);
            criteria.Slice.End.Should().Be(30);
        }
        [Fact]
        public void Criteria_With_Slice()
        {
            //Arrange
            var query = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {"_start",new StringValues( "20")}
            });

            //Act
            var criteria = new Criteria<UserFilter>("/api/users", query);


            //Assert
            criteria.Slice.Start.Should().Be(20);
            criteria.Slice.End.Should().Be(null);
        }
    }
}