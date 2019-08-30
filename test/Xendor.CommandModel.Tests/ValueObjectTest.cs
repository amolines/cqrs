using FluentAssertions;
using FluentAssertions.Common;
using Xendor.CommandModel.Tests.Code;
using Xunit;

namespace Xendor.CommandModel.Tests
{
    public class ValueObjectTest
    {
        [Fact]
        public void ValueObject_Equal_ShouldBeTrue()
        {
            //Arrange
            Phone phone =  Phone.New("0212", "5513394");
            Phone phone2 =  Phone.New("0212", "5513394");

            //Act
            var isEqual = phone2.Equals(phone);


            //Assert
            isEqual.Should().BeTrue();
        }

        [Fact]
        public void ValueObject_Equal_ShouldBeFalse()
        {
            //Arrange
            Phone phone =  Phone.New("0212", "5513394");
            Phone phone2 =  Phone.New("0412", "3180023");

            //Act
            var isEqual = phone2.Equals(phone);


            //Assert
            isEqual.Should().BeFalse();
        }

        [Fact]
        public void ValueObject_GetHashCode_IsSameOrEqualTo()
        {
            //Arrange
            Phone phone =  Phone.New("0212", "5513394");
            Phone phone2 =  Phone.New("0212", "5513394");

            //Act
            var phoneHashCode = phone.GetHashCode();
            var phone2HashCode = phone2.GetHashCode();

            //Assert
            phoneHashCode.Should().IsSameOrEqualTo(phone2HashCode);
        }

        [Fact]
        public void ValueObject_GetHashCode_NotBe()
        {
            //Arrange
            Phone phone =  Phone.New("0212", "5513394");
            Phone phone2 =  Phone.New("0412", "3180023");

            //Act
            var phoneHashCode = phone.GetHashCode();
            var phone2HashCode = phone2.GetHashCode();

            //Assert
            phoneHashCode.Should().NotBe(phone2HashCode);
        }
    }
}
