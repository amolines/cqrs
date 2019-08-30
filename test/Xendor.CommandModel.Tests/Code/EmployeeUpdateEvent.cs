using System;
using Xendor.EventBus;

namespace Xendor.CommandModel.Tests.Code
{
    public class EmployeeUpdateEvent : Event
    {
        public EmployeeUpdateEvent(string firstName, string lastName, DateTime? dateOfBirth, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime? DateOfBirth { get; }
        public string JobTitle { get; }
    }
}