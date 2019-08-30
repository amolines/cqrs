using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NSubstitute;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.Tests.Code;
using Xendor.EventBus;
using Xunit;

namespace Xendor.CommandModel.Tests
{
    public class RepositoryTest : IDisposable
    {
        private EventRepository _eventRepository;
        public RepositoryTest()
        {
            EventStorage = Substitute.For<IEventStorage>();
            DomainEventMediator = Substitute.For<IDomainEventMediator>();
            _eventRepository = new EventRepository(EventStorage , DomainEventMediator);
        }
        public void Dispose()
        {
            _eventRepository = null;
        }
        [Fact]
        public void Repository_Constructor_ArgumentNullException()
        {
            //Arrange
            object New() => new EventRepository(null,null);

            //Act
            Assert.Throws<ArgumentNullException>((Func<object>)New);


            //Assert
        }
        [Fact]
        public void Repository_Get()
        {
            //Arrange
            var id = Guid.NewGuid();

            EventStorage.Get(id,-1, "employees")
                .Returns(
                    new List<Event>()
                    {
                        new EmployeeCreatedEvent(55,"Alejandro","Molines",new DateTime(1981,11,28),"Developer" )
                    }
                );

            //Act
            var user = _eventRepository.Get<Employee>(id).Result;


            //Assert
            user.EmployeeId.Should().Be(55);
            user.FirstName.Should().Be("Alejandro");
            user.LastName.Should().Be("Molines");
            user.JobTitle.Should().Be("Developer");
            user.DateOfBirth.Should().Be(28.November(1981));
            EventStorage.Received(1).Get(id, -1, "employees");
        }
        [Fact]
        public  void Repository_Save()
        {
            //Arrange
            var id = Guid.NewGuid();
            EventStorage.Save(Arg.Do<IEnumerable<Event>>(e =>   e.Any(i=>i.Version == 1 && i.AggregateId.Equals(id))), "employees")
                .Returns(Task.CompletedTask);


            var employee = new Employee(id, 55, "Alejandro", "Molines", new DateTime(1981, 11, 28), "Developer");

            //Act
           _eventRepository.Save<Employee>(employee).Wait();


            //Assert
            EventStorage.Received(1).Save(Arg.Do<IEnumerable<Event>>(e => e.Any(i => i.Version == 1 && i.AggregateId.Equals(id))), "employees");
        }


        private IEventStorage EventStorage { get; }
        private IDomainEventMediator DomainEventMediator { get; }

    }
}