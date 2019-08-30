using FluentAssertions;
using Xendor.QueryModel.Expressions;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class SortTest
    {
        [Fact]
        public void Sort_With_One_Property()
        {
            //Arrange
            var sort = new Sort(new Field[]{ new Field("name", Order.Asc) });

            //Act
            var text = sort.ToString();


            //Assert
            text.Should().Be("_sort=name&_order=asc");


        }
        [Fact]
        public void Sort_With_Two_Property()
        {
            //Arrange
            var sort = new Sort(new Field[] { new Field("name", Order.Desc)  , new Field("lastName", Order.Asc) });

            //Act
            var text = sort.ToString();


            //Assert
            text.Should().Be("_sort=name,lastName&_order=desc,asc");


        }
    }
}