using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_quiz_by_harneet
{
    public class Question
    {
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public bool CorrectAnswer { get; set; }


        public Question(string questiontext, bool correctanswer)
        {
            QuestionText = questiontext;
            CorrectAnswer = correctanswer;

        }
    }
}
