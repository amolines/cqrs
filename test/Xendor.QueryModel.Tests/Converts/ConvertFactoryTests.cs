using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Xendor.QueryModel.Converts;
using Xendor.QueryModel.Converts.Exceptions;
using Xunit;

namespace Xendor.QueryModel.Tests.Converts
{
    public class ConvertFactoryTests
    {
        [Fact]
        public void ConvertFactory_NotFoundConvert()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            Assert.Throws<NotFoundConvertException>(() => convertFactory.GetConvert(typeof(float)));


            //Assert

        }
        [Fact]
        public void ConvertFactory_byte()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(byte), "255");


            //Assert
            value.Should().BeAssignableTo<byte>().And.Be(255);
        }
        [Fact]
        public void ConvertFactory_byte_InvalidCast()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            Assert.Throws<InvalidCastConvertException>(() => convertFactory.Parse(typeof(byte), "2555"));


            //Assert

        }
        [Fact]
        public void ConvertFactory_short()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(short), "32767");


            //Assert
            value.Should().BeAssignableTo<short>().And.Be(32767);
        }
        [Fact]
        public void ConvertFactory_short_InvalidCast()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            Assert.Throws<InvalidCastConvertException>(() => convertFactory.Parse(typeof(short), "327676"));


            //Assert

        }
        [Fact]
        public void ConvertFactory_int()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(int), "2147483647");


            //Assert
            value.Should().BeAssignableTo<int>().And.Be(2147483647);
        }
        [Fact]
        public void ConvertFactory_int_InvalidCast()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            Assert.Throws<InvalidCastConvertException>(() => convertFactory.Parse(typeof(int), "21474836478"));


            //Assert

        }
        [Fact]
        public void ConvertFactory_long()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(long), "9223372036854775807");


            //Assert
            value.Should().BeAssignableTo<long>().And.Be(9223372036854775807);
        }
        [Fact]
        public void ConvertFactory_long_InvalidCast()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            Assert.Throws<InvalidCastConvertException>(() => convertFactory.Parse(typeof(long), "9223372036854775809"));


            //Assert

        }
        [Fact]
        public void ConvertFactory_ulong()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(ulong), "18446744073709551615");


            //Assert
            value.Should().BeAssignableTo<ulong>().And.Be(18446744073709551615);
        }
        [Fact]
        public void ConvertFactory_ulong_InvalidCast()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            Assert.Throws<InvalidCastConvertException>(() => convertFactory.Parse(typeof(ulong), "18446744073709551619"));


            //Assert

        }
        [Fact]
        public void ConvertFactory_double()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(double), "1.0");


            //Assert
            value.Should().BeAssignableTo<double>().And.Be(1.0);
        }
        [Fact]
        public void ConvertFactory_decimal()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(decimal), "2.1");


            //Assert
            value.Should().BeAssignableTo<decimal>().And.Be(2.1m);
        }
        [Fact]
        public void ConvertFactory_DateTime()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(DateTime), "19811128");


            //Assert
            value.Should().BeAssignableTo<DateTime>().And.Be(new DateTime(1981,11,28));
        }
        [Fact]
        public void ConvertFactory_string()
        {
            //Arrange
            var convertFactory = new ConvertFactory();

            //Act
            var value = convertFactory.Parse(typeof(string), "Alejandro Molines");


            //Assert
            value.Should().BeAssignableTo<string>().And.Be("Alejandro Molines");
        }
    }
}
