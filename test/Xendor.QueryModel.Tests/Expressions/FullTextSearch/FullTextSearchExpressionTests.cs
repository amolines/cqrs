using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Expressions.FullTextSearch;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests.Expressions.FullTextSearch
{
    public class FullTextSearchExpressionTests
    {
        [Fact]
        public void FullTextSearchExpression_With_Multiple_Values()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"_q", new StringValues("Alejandro")}
            };
            var query = new QueryCollection(values);



            //Act
            var fullTextSearch = FullTextSearchExpression<UserMetaDataCriteria>.Extract(query);
            var text = fullTextSearch.ToString();



            //Assert
            text.Should().Be("_q=Alejandro");
            fullTextSearch.Name.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.Equal("name","lastName")
                .And.ContainItemsAssignableTo<string>();


        }
        [Fact]
        public void FilterCollectionExpression_Filter_Empty()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"q", new StringValues("Alejandro")}
            };
            var query = new QueryCollection(values);



            //Act
            var fullTextSearch = FullTextSearchExpression<UserMetaDataCriteria>.Extract(query);




            //Assert
            fullTextSearch.Should().BeNull();

        }

    }
}
