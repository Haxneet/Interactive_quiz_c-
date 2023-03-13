using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Interactive_quiz_by_harneet
{


    public class MultipleChoiceQuestion : Question
    {
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        public MultipleChoiceQuestion(string text, string optionA, string optionB, string optionC, string optionD, string answer)
        {
            QuestionText = text;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
            OptionD = optionD;
            CorrectAnswer = answer;
        }

    }
}