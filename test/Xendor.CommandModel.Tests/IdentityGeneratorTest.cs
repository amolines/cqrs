using System;
using FluentAssertions;
using Xunit;

namespace Xendor.CommandModel.Tests
{
    public class IdentityGeneratorTest
    {
        [Fact]
        public void IdentityGenerator_NewSequentialGuid_SequentialAsBinary()
        {
            //Arrange
           

            //Act
            var id = IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsBinary);


            //Assert
            id.Should().As<Guid>();
            id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void IdentityGenerator_NewSequentialGuid_SequentialAsString()
        {
            //Arrange


            //Act
            var id = IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString);


            //Assert
            id.Should().As<Guid>();
            id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void IdentityGenerator_NewSequentialGuid_SequentialAtEnd()
        {
            //Arrange


            //Act
            var id = IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAtEnd);


            //Assert
            id.Should().As<Guid>();
            id.Should().NotBe(Guid.Empty);
        }
    }
}