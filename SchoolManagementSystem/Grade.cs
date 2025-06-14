using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class Grade
    {
        public int Score { get; private set; }

        public Grade(int score)
        {
            if (score < 0 || score > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");
            }

            Score = score;
        }

        //Giving feedback based on student's score

        public string GetFeedback()
        {
            return Score switch
            {
                > 90 => "You did a good job",
                >= 80 and <= 90 => "Keep up the good work, you're almost there!",
                >= 70 and <= 80 => "Not bad, but there’s room for improvement",
                >= 60 and < 70 => "Keep pushing, you can do better!",
                < 60 => "Don't give up! Review the material and try again",
            };
        }

    }


    public class Course{
            public string CourseId { get; private set; }
            public string Title { get; private set; }
            public int Credits { get; set; }
            public Teacher teacher { get; set; }
            public List<Student> EnrolledStudents { get; private set; } = new List<Student>();

             public Dictionary<Student, Grade> GradesOfStudents { get; private set; } = new Dictionary<Student, Grade>();

        public Course(string id, string title, int credits)
             {
            CourseId = id;
            Title = title;
            Credits = credits;
            }

        public void Enroll(Student student, int InitialScore = -1)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
                student.CoursesEnrolled.Add(this.Title);
            }

            if(InitialScore >= 0)
            {
                Grade grade = new Grade(InitialScore);
                GradesOfStudents[student] = grade;
                student.GradesWCourses[this] = grade;
            }
        }

        public void AssignGradeToStudent(Student student, int score)
        {
            //Firstly, enroll student if not already enrolled
            if (!EnrolledStudents.Contains(student))
            {
                Enroll(student);
            }

            Grade grade = new Grade(score);

            // Update course's grade dictionary
            GradesOfStudents[student] = grade;

            // Update student's grade dictionary
            student.GradesWCourses[this] = grade;

        }

        public List<Student> GetFailingStudent(int passMark = 60)
        {
            return GradesOfStudents
                .Where(kv => kv.Value.Score < passMark)
                .Select(kv => kv.Key)
                .ToList();
        }

        public Student GetTopStudent()
        {
            return GradesOfStudents
                .OrderByDescending(kv => kv.Value.Score)
                .Select(kv => kv.Key)
                .FirstOrDefault();
        }

    }
}
