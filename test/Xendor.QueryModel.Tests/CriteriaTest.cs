using System.Linq;
using FluentAssertions;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class CriteriaTest
    {
        [Fact]
        public void Criteria_With_FullTextSearch()
        {
            //Arrange
            var criteria = new Criteria<UserFilter>("/api/users","q=alejandro");

            //Act
            var value = criteria.ToString();


            //Assert
            criteria.FullTextSearch.Name.Count().Should().Be(2);
            value.Should().Be("q=alejandro");

        }


        [Fact]
        public void Criteria_With_Filters()
        {
            //Arrange
            var criteria = new Criteria<UserFilter>("/api/users", "name=alejandro&lastName=molines&address.cp=08204");

            //Act
            var value = criteria.ToString();


            //Assert
            criteria.Filters.Count().Should().Be(3);
            value.Should().Be("name=alejandro&lastName=molines&address.cp=08204");

        }

        [Fact]
        public void Criteria_With_Paginate()
        {
            //Arrange


            //Act
            var criteria = new Criteria<UserFilter>("/api/users", "_page=7&_limit=20");


            //Assert
            criteria.Paginate.Limit.Should().Be(20);
            criteria.Paginate.Page.Should().Be(7);

        }

        [Fact]
        public void Criteria_Sort_IsNull()
        {
            //Arrange


            //Act
            var criteria = new Criteria<UserFilter>("/api/users", "_sort=userf,views&_order=desc,asc");


            //Assert
            criteria.Sort.Should().BeNull();
 
        }

        [Fact]
        public void Criteria_With_Sort()
        {
            //Arrange


            //Act
            var criteria = new Criteria<UserFilter>("/api/users", "_sort=name,lastName&_order=desc,asc");


            //Assert
            criteria.Sort.Fields.Count().Should().Be(2);

        }


        [Fact]
        public void Criteria_With_Slice()
        {
            //Arrange


            //Act
            var criteria = new Criteria<UserFilter>("/api/users", "_start=20&_end=30");


            //Assert
            criteria.Slice.Start.Should().Be(20);
            criteria.Slice.End.Should().Be(30);
        }
    }
}