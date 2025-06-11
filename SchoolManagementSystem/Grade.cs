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
            if(score <0 || score > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");
            }

            Score = score;
        }

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
}
