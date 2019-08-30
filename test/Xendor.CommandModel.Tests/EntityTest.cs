using System;
using FluentAssertions;
using Xendor.CommandModel.Tests.Code;
using Xunit;

namespace Xendor.CommandModel.Tests
{
    public class EntityTest
    {
        [Fact]
        public void Entity_Equals_BeTrue()
        {
            //Arrange
            var id = Guid.NewGuid();
            Telephone telephone = new Telephone(id, "212","5513394","home");
            Telephone telephone2 = new Telephone(id, "212", "5513394", "home");

            //Act
            var isEqual = telephone.Equals(telephone2);


            //Assert
            isEqual.Should().BeTrue();
        }

        [Fact]
        public void Entity_GetHashCode_BeTrue()
        {
            //Arrange
            var id = Guid.NewGuid();
            Telephone telephone = new Telephone(id, "212", "5513394", "home");
            Telephone telephone2 = new Telephone(id, "212", "5513394", "home");

            //Act
            var telephoneHashCode = telephone.GetHashCode();
            var telephone2HashCode = telephone2.GetHashCode();

            //Assert
            telephoneHashCode.Should().Be(telephone2HashCode);
        }
    }
}