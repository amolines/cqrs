using System;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.EventSourcing.SnapShotting;

namespace Xendor.CommandModel.Tests.Code
{
    [CollectionName("employees")]
    public class Employee : SnapshotAggregateRoot<EmployeeSnapshot>
    {
        public Employee()
        { }
        public Employee(Guid id)
            : base(id)
        { }
        public Employee(Guid id, int employeeId, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
            : base(id)
        {
            ApplyChange(new EmployeeCreatedEvent(employeeId, firstName, lastName, dateOfBirth, jobTitle));
        }
        public int EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string JobTitle { get; private set; }
        protected override IApplyHandlerManager CreateEventHandlerManager()
        {
            return new EmployeeApplyHandlerManager(this);
        }
        public void Update(EmployeeUpdateEvent message)
        {
            ApplyChange(message);
        }


        #region EventHandler
        private class EmployeeApplyHandlerManager : ApplyHandlerManager<Employee>,
            IApplyHandler<EmployeeCreatedEvent>,
            IApplyHandler<EmployeeUpdateEvent>
        {
            public EmployeeApplyHandlerManager(Employee aggregate)
                : base(aggregate)
            { }
            public void Handle(EmployeeCreatedEvent message)
            {
                AggregateRoot.EmployeeId = message.EmployeeId;
                AggregateRoot.FirstName = message.FirstName;
                AggregateRoot.LastName = message.LastName;
                AggregateRoot.DateOfBirth = message.DateOfBirth;
                AggregateRoot.JobTitle = message.JobTitle;
            }
            public void Handle(EmployeeUpdateEvent message)
            {
                if (!string.IsNullOrEmpty(message.FirstName))
                    AggregateRoot.FirstName = message.FirstName;
                if (!string.IsNullOrEmpty(message.LastName))
                    AggregateRoot.LastName = message.LastName;
                if (message.DateOfBirth.HasValue)
                    AggregateRoot.DateOfBirth = message.DateOfBirth.Value;
                if (!string.IsNullOrEmpty(message.JobTitle))
                    AggregateRoot.JobTitle = message.JobTitle;
            }

        }

        #endregion

        #region SnapshotAggregateRoot

        protected override EmployeeSnapshot CreateSnapshot()
        {
            return new EmployeeSnapshot(EmployeeId, FirstName, LastName, DateOfBirth, JobTitle);
        }

        protected override void RestoreFromSnapshot(EmployeeSnapshot snapshot)
        {
            EmployeeId = snapshot.EmployeeId;
            FirstName = snapshot.FirstName;
            LastName = snapshot.LastName;
            DateOfBirth = snapshot.DateOfBirth;
            JobTitle = snapshot.JobTitle;
        }

        #endregion
    }
}