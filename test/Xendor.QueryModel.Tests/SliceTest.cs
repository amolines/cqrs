using FluentAssertions;
using Xendor.QueryModel.Expressions;
using Xunit;

namespace Xendor.QueryModel.Tests
{
    public class SliceTest
    {
        [Fact]
        public void Slice_Start_20_And_End_30()
        {
            //Arrange
            var slice = new Slice(20, 30);

            //Act
            var text = slice.ToString();


            //Assert
            text.Should().Be("_start=20&_end=30");


        }

        [Fact]
        public void Slice_Start_20()
        {
            //Arrange
            var slice = new Slice(20, null);

            //Act
            var text = slice.ToString();


            //Assert
            text.Should().Be("_start=20");


        }
    }
}