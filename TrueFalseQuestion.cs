using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Interactive_quiz_by_harneet
{
    public class TrueFalseQuestion:Question
    {
       
            public TrueFalseQuestion(string text, string answer)
            {
                QuestionText = text;
            CorrectAnswer= answer;
            }

           
        }
}
