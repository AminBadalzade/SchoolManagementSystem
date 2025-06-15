using System;
using SchoolManagementSystem;

namespace SchoolManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create teachers
                Teacher t1 = new Teacher("John", "Doe", new DateTime(1980, 4, 15), "Mathematics");
                Teacher t2 = new Teacher("Jane", "Smith", new DateTime(1975, 6, 22), "Physics");
                Teacher t3 = new Teacher("Alice", "Johnson", new DateTime(1985, 9, 12), "Literature");
                Teacher t4 = new Teacher("Mark", "White", new DateTime(1982, 2, 10), "Biology");
                Teacher t5 = new Teacher("Emma", "Taylor", new DateTime(1978, 11, 5), "Chemistry");

                // Create students
                Student s1 = new Student("Tom", "Brown", new DateTime(2005, 1, 10), new DateTime(2022, 9, 1));
                Student s2 = new Student("Lucy", "Miller", new DateTime(2004, 5, 23), new DateTime(2022, 9, 1));
                Student s3 = new Student("Jack", "Wilson", new DateTime(2006, 3, 30), new DateTime(2023, 9, 1));
                Student s4 = new Student("Olivia", "Anderson", new DateTime(2005, 8, 14), new DateTime(2022, 9, 1));
                Student s5 = new Student("Liam", "Scott", new DateTime(2004, 12, 2), new DateTime(2022, 9, 1));

                // Create courses
                Course math = new Course("Advanced Mathematics", 3, t1);
                Course physics = new Course("Modern Physics", 4, t2);
                Course literature = new Course("English Literature", 2, t3);
                Course biology = new Course("Cell Biology", 3, t4);
                Course chemistry = new Course("Organic Chemistry", 3, t5);

                // Enroll students with mixed grades
                math.Enroll(s1, 95);
                math.Enroll(s2, 50);
                math.Enroll(s3, 65);
                math.Enroll(s4, 77);
                math.Enroll(s5, 88);

                physics.Enroll(s1, 40);
                physics.Enroll(s2, 92);
                physics.Enroll(s4, 85);
                physics.Enroll(s5, 58);

                literature.Enroll(s2, 95);
                literature.Enroll(s3, 35);
                literature.Enroll(s5, 79);

                biology.Enroll(s1, 70);
                biology.Enroll(s3, 55);
                biology.Enroll(s4, 90);
                biology.Enroll(s5, 100);

                chemistry.Enroll(s1, 30);
                chemistry.Enroll(s2, 66);
                chemistry.Enroll(s3, 93);
                chemistry.Enroll(s4, 81);

                // Reassign grades to simulate updates
                math.AssignGradeToStudent(s3, 66);
                physics.AssignGradeToStudent(s1, 45);
                literature.AssignGradeToStudent(s3, 42);
                chemistry.AssignGradeToStudent(s1, 33);

                // Print average grades
                Console.WriteLine("Average Grades:");
                foreach (var student in Student.students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}: {student.GetAverageGrade():F2}");
                }

                // Print feedback for all students
                Console.WriteLine("\nFeedback for Students:");
                foreach (var student in Student.students)
                {
                    Console.WriteLine($"\n{student.FirstName} {student.LastName}:");
                    student.PrintAllFeedback();
                }

                // List all teachers
                Console.WriteLine("\nTeachers:");
                Teacher.OurTeachers();

                // List all courses
                Console.WriteLine("\nCourses:");
                Course.CoursesInSchool();

                // Print enrolled students for each course with their scores
                Console.WriteLine("\nCourse Enrollment Details:");
                foreach (var course in Course.courses)
                {
                    Console.WriteLine($"\n{course.Title} - Enrolled Students:");
                    foreach (var student in course.EnrolledStudents)
                    {
                        if (course.GradesOfStudents.TryGetValue(student, out var grade))
                        {
                            Console.WriteLine($"{student.FirstName} {student.LastName} | Grade: {grade.Score}");
                        }
                    }
                }

                // Failing students per course
                Console.WriteLine("\nFailing Students per Course:");
                foreach (var course in Course.courses)
                {
                    var failing = course.GetFailingStudent();
                    Console.WriteLine($"\n{course.Title}:");
                    foreach (var student in failing)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName} - Score: {course.GradesOfStudents[student].Score}");
                    }
                }

                // Top students per course
                Console.WriteLine("\nTop Students per Course:");
                foreach (var course in Course.courses)
                {
                    var topStudent = course.GetTopStudent();
                    if (topStudent != null)
                    {
                        var topScore = course.GradesOfStudents[topStudent].Score;
                        Console.WriteLine($"{course.Title}: {topStudent.FirstName} {topStudent.LastName} - Score: {topScore}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nProgram finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
