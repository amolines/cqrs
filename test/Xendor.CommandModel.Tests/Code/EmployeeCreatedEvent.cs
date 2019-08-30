using System;
using Xendor.EventBus;

namespace Xendor.CommandModel.Tests.Code
{
    public class EmployeeCreatedEvent : Event
    {
        public EmployeeCreatedEvent(int employeeId, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }

        public int EmployeeId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public string JobTitle { get; }
    }
}