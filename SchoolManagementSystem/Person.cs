using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; set; }

        public Person(string firstName, string lastName, DateTime DateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = DateOfBirth;
        }

    }

    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }
        public List<string> CoursesEnrolled = new List<string>();
        public Student(string firstName, string lastName, DateTime DateOfBirth, DateTime enrollDate) : base(firstName, lastName, DateOfBirth)
        {
            this.EnrollmentDate = enrollDate;
        }
    }
}
