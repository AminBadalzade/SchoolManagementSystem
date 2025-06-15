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

    public class Teacher : Person
    {
        public string Specialization { get;  set; }
        public string DefaultEmail { get; private set; }

        public static List<Teacher> teachers = new List<Teacher>();

        public Teacher(string firstName, string lastName, DateTime DateOfBirth, string specialization) : base(firstName, lastName, DateOfBirth)
        {
  
            Specialization = specialization;

            DefaultEmail = GenerateEmail(firstName, lastName);

            teachers.Add(this);
        }

        private string GenerateEmail(string firstName, string lastName)
        {
            string baseEmail = $"{firstName.ToLower()}.{lastName.ToLower()}@gmail.com";
            int suffix = 1;
            string emailToCheck = baseEmail;

            while(teachers.Any(t => t.DefaultEmail == emailToCheck)){
                suffix++;
                emailToCheck = $"{firstName.ToLower()}.{lastName.ToLower()}{suffix}@gmail.com";
            }

            return emailToCheck;
        }

        public static void OurTeachers()
        {
            Console.WriteLine("List of all teachers:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.FirstName} {teacher.LastName} - Specialization: {teacher.Specialization}, Email: {teacher.DefaultEmail}");
            }
        }

        //When you reference {course.Teacher} inside the Console.WriteLine, it automatically calls
        //the ToString() method of the Teacher class

        public override string ToString() //public override string ToString() => $"{FirstName} {LastName}";
        {
            return $"{FirstName} {LastName}";
        }


    }
}
