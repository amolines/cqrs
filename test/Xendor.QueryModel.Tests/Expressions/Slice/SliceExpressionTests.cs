using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Expressions.Slice;
using Xunit;

namespace Xendor.QueryModel.Tests.Expressions.Slice
{
    public class SliceExpressionTests
    {
        [Fact]
        public void SliceExpression_Start_20_And_End_30()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_start", new StringValues("20")},
                {"_end", new StringValues("30")}
            };
            var query = new QueryCollection(values);



            //Act
            var slice = SliceExpression.Extract(query);
            var text = slice.ToString();



            //Assert
            text.Should().Be("_start=20&_end=30");


        }
        [Fact]
        public void SliceExpression_Start_20()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_start", new StringValues("20")}
            };
            var query = new QueryCollection(values);



            //Act
            var slice = SliceExpression.Extract(query);
            var text = slice.ToString();



            //Assert
            text.Should().Be("_start=20");


        }
        [Fact]
        public void SliceExpression_Slice_Empty()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_start", new StringValues("A")}
            };
            var query = new QueryCollection(values);



            //Act
            var slice = SliceExpression.Extract(query);




            //Assert
            slice.Should().BeNull();


        }

    }
}