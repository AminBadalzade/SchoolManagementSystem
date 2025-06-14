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
        public static List<Student> students = new List<Student>();
        public DateTime EnrollmentDate { get; set; }
        public List<string> CoursesEnrolled { get; private set; } = new List<string>();
        public Dictionary<Course, Grade> GradesWCourses { get; private set; } = new Dictionary<Course, Grade>();

        public Student(string firstName, string lastName, DateTime DateOfBirth, DateTime enrollDate) 
            : base(firstName, lastName, DateOfBirth)
        {
            if (DateOfBirth > enrollDate)
            {
                throw new ArgumentException("Enrollment date cannot be before birth date");
            }

            this.EnrollmentDate = enrollDate;
            students.Add(this);
        }

        public double GetAverageGrade()
        {
            if (GradesWCourses.Count == 0) return 0;
            return GradesWCourses.Values.Average(g => g.Score);
        }

        public void PrintAllFeedback()
        {
            foreach(var entry in GradesWCourses)
            {
                Console.WriteLine($"{entry.Key.Title}: {entry.Value.GetFeedback()}");
            }
        }
       

    }
}
