using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Expressions.FilterCollection;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests.Expressions.FilterCollection
{
    public class FilterCollectionExpressionTests
    {
        [Fact]
        public void FilterCollectionExpression_With_Multiple_Values()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"name", new StringValues("Alejandro")},
                {"lastName", new StringValues("Molines")}
            };
            var query = new QueryCollection(values);



            //Act
            var filterCollection = FilterCollectionExpression<UserMetaDataCriteria>.Extract(query);
            var text = filterCollection.ToString();



            //Assert
            text.Should().Be("name=Alejandro&lastName=Molines");
            filterCollection.Filters.Should().HaveCount(2);

        }
        [Fact]
        public void FilterCollectionExpression_Filter_Empty()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"names", new StringValues("Alejandro")},
                {"lastName", new StringValues("Molines")}
            };
            var query = new QueryCollection(values);



            //Act
            var filterCollection = FilterCollectionExpression<UserMetaDataCriteria>.Extract(query);




            //Assert
            filterCollection.Should().BeNull();

        }
        [Fact]
        public void FilterCollectionExpression_With_Multiple_Values_A​nd_Same_Names()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"id", new StringValues(new []{"1","2","4"})}
            };
            var query = new QueryCollection(values);



            //Act
            var filterCollection = FilterCollectionExpression<UserMetaDataCriteria>.Extract(query);
            var text = filterCollection.ToString();



            //Assert
            text.Should().Be("id=1&id=2&id=4");
            filterCollection.Filters.Should()
                .NotBeEmpty().And
                .HaveCount(3).And
                .ContainItemsAssignableTo<Filter>().And
                .SatisfyRespectively(
                    first => {
                        first.Name.Should().Be("id");
                        first.Value.Should().Be("1");
                        first.Type.Should().Be<int>();
                    }, second => {
                        second.Name.Should().Be("id");
                        second.Value.Should().Be("2");
                        second.Type.Should().Be<int>();
                    }, third => {
                        third.Name.Should().Be("id");
                        third.Value.Should().Be("4");
                        third.Type.Should().Be<int>();
                    });

          


        }

    }
}
