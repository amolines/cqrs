using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Xendor.QueryModel.Expressions.FilterCollection;
using Xendor.QueryModel.Expressions.OperatorCollection;
using Xendor.QueryModel.Tests.Code;
using Xunit;

namespace Xendor.QueryModel.Tests.Expressions.OperatorCollection
{
    public class OperatorCollectionExpressionTests
    {
        [Fact]
        public void OperatorCollectionExpression_With_gt_lt()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"age_gt", new StringValues("25")},
                {"age_lt", new StringValues("20")}
            };
            var query = new QueryCollection(values);



            //Act
            var operatorCollection = OperatorCollectionExpression<UserMetaDataCriteria>.Extract(query);
            var text = operatorCollection.ToString();



            //Assert
            text.Should().Be("age_gt=25&age_lt=20");
            operatorCollection.Operators.Should().HaveCount(2);

        }

        [Fact]
        public void OperatorCollectionExpression_With_gte_lte()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"age_gte", new StringValues("25")},
                {"age_lte", new StringValues("20")}
            };
            var query = new QueryCollection(values);



            //Act
            var operatorCollection = OperatorCollectionExpression<UserMetaDataCriteria>.Extract(query);
            var text = operatorCollection.ToString();



            //Assert
            text.Should().Be("age_gte=25&age_lte=20");
            operatorCollection.Operators.Should().HaveCount(2);

        }

        [Fact]
        public void OperatorCollectionExpression_With_like()
        {
            //Arrange
            var values = new Dictionary<string, StringValues>
            {
                {"name_like", new StringValues("Ale")}
              
            };
            var query = new QueryCollection(values);



            //Act
            var operatorCollection = OperatorCollectionExpression<UserMetaDataCriteria>.Extract(query);
            var text = operatorCollection.ToString();



            //Assert
            text.Should().Be("name_like=Ale");
            operatorCollection.Operators.Should().HaveCount(1);

        }

    }
}
