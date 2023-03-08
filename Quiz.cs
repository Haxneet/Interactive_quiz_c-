using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_quiz_by_harneet
{
    public class Quiz:Question
    {
        private List<Question> _questionList;
        private int _currentQuestionIndex = -1;
        private int _score = 0;

        public string Title { get; set; }

        public int Score
        {
            get { return _score; }
            private set { _score = value; }
        }

        public Quiz(string title)
        {
            Title = title;
            _questionList = new List<Question>();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            // Add 5 multiple choice questions
            _questionList.Add(new MultipleChoiceQuestion("Which country is the biggest in size?", new List<string>() { "USA", "Canada", "Russia", "China" }, "Russia"));
            _questionList.Add(new MultipleChoiceQuestion("Which is the largest ocean in the world?", new List<string>() { "Atlantic Ocean", "Indian Ocean", "Pacific Ocean", "Arctic Ocean" }, "Pacific Ocean"));
            _questionList.Add(new MultipleChoiceQuestion("Which city is the capital of France?", new List<string>() { "Paris", "London", "Madrid", "Rome" }, "Paris"));
            _questionList.Add(new MultipleChoiceQuestion("Which planet in our solar system is known as the Red Planet?", new List<string>() { "Mars", "Venus", "Jupiter", "Saturn" }, "Mars"));
            _questionList.Add(new MultipleChoiceQuestion("Which instrument is used to measure air pressure?", new List<string>() { "Thermometer", "Barometer", "Hygrometer", "Anemometer" }, "Barometer"));

            // Add 5 true/false questions
            _questionList.Add(new TrueFalseQuestion("The Great Wall of China is the longest wall in the world.", true));
            _questionList.Add(new TrueFalseQuestion("The first man to walk on the moon was Neil Armstrong.", true));
            _questionList.Add(new TrueFalseQuestion("The tallest mammal in the world is the elephant.", false));
            _questionList.Add(new TrueFalseQuestion("The currency of Japan is the yen.", true));
            _questionList.Add(new TrueFalseQuestion("The Statue of Liberty was a gift from France to the USA.", true));
        }

        private Question GetQuestionWithoutAnswer()
        {
            if (_currentQuestionIndex >= 0 && _currentQuestionIndex < _questionList.Count)
            {
                Question q = _questionList[_currentQuestionIndex].CloneWithoutAnswer();
                return q;
            }
            else
            {
                throw new InvalidOperationException("No more questions available.");
            }
        }

        public Question GetNextQuestion()
        {
            _currentQuestionIndex++;
            return GetQuestionWithoutAnswer();
        }

        public bool CheckUserAnswer(string userAnswer)
        {
            if (_currentQuestionIndex >= 0 && _currentQuestionIndex < _questionList.Count)
            {
                bool isCorrect = _questionList[_currentQuestionIndex].CheckAnswer(userAnswer);
                if (isCorrect)
                {
                    if (!_questionList[_currentQuestionIndex].IsAnsweredCorrectly)
                    {
                        Score++;
                        _questionList[_currentQuestionIndex].IsAnsweredCorrectly = true;
                    }
                    return true;
                }
            }
            return false;
        }
    }

}
}
