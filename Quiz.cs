using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_quiz_by_harneet
{
    public class Quiz : Question
    {
        private List<Question> _questionList;
        private int _currentQuestionIndex = -1;
        private int _score = 0;
        private bool isFirstAttempt;
        public int TotalQuestions;
        public bool LastQuestion;
        public string Title { get; set; }

        public int Score { get { return _score; } private set { _score = value; } }

        public Quiz(string title)
        {
            Title = title;
            _questionList = new List<Question>();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            // Add 5 multiple choice questions
            _questionList.Add(
                new MultipleChoiceQuestion(
                    "Which country is the biggest in size?", "USA", "Canada", "Russia", "China" ,"Russia"
                    ));
            _questionList.Add(
                new MultipleChoiceQuestion(
                    "Which is the largest ocean in the world?",
                     "Atlantic Ocean", "Indian Ocean", "Pacific Ocean", "Arctic Ocean" ,
                    "Pacific Ocean"));
            _questionList.Add(
                new MultipleChoiceQuestion(
                    "Which city is the capital of France?",
                    "Paris", "London", "Madrid", "Rome" ,
                    "Paris"));
            _questionList.Add(
                new MultipleChoiceQuestion(
                    "Which planet in our solar system is known as the Red Planet?",
                    "Mars", "Venus", "Jupiter", "Saturn" ,
                    "Mars"));
            _questionList.Add(
                new MultipleChoiceQuestion(
                    "Which instrument is used to measure air pressure?",
                     "Thermometer", "Barometer", "Hygrometer", "Anemometer" ,
                    "Barometer"));

            // Add 5 true/false questions
            _questionList.Add(new TrueFalseQuestion("The Great Wall of China is the longest wall in the world.", "true"));
            _questionList.Add(new TrueFalseQuestion("The first man to walk on the moon was Neil Armstrong.", "true"));
            _questionList.Add(new TrueFalseQuestion("The tallest mammal in the world is the elephant.", "false"));
            _questionList.Add(new TrueFalseQuestion("The currency of Japan is the yen.", "true"));
            _questionList.Add(new TrueFalseQuestion("The Statue of Liberty was a gift from France to the USA.", "true"));
            TotalQuestions = _questionList.Count;
        }

        private Question GetQuestionWithoutAnswer()
        {
           
                if (_currentQuestionIndex < _questionList.Count)
                {
                    // get the current question
                    Question currentQuestion = _questionList[_currentQuestionIndex];

                    // create a new question object
                    Question questionWithoutAnswer;

                    if (currentQuestion is MultipleChoiceQuestion)
                    {
                    MultipleChoiceQuestion mcq = (MultipleChoiceQuestion)currentQuestion;
                        questionWithoutAnswer = new MultipleChoiceQuestion(mcq.QuestionText, mcq.OptionA, mcq.OptionB, mcq.OptionC, mcq.OptionD, null);
                    }
                    else if (currentQuestion is TrueFalseQuestion)
                    {
                    TrueFalseQuestion tFalse = (TrueFalseQuestion)currentQuestion;
                        questionWithoutAnswer = new TrueFalseQuestion(tFalse.QuestionText,null);
                    }
                    else
                    {
                        // unsupported question type
                        return null;
                    }

                    return questionWithoutAnswer;
                }
                else
                {
                    // current question index is out of range
                    return null;
                }

            }

        
       





        

    public Question GetNextQuestion()
        {
            _currentQuestionIndex++;
            return GetQuestionWithoutAnswer();
        }

        public void CheckUserAnswer(string answer)
        {
            Question currentQuestion = _questionList[_currentQuestionIndex];

            if (answer == currentQuestion.CorrectAnswer)
            {
                if (isFirstAttempt)
                {
                    _score++;
                    isFirstAttempt = false;
                }
            }
            else
            {
                isFirstAttempt = false;
            }
            if (_currentQuestionIndex == _questionList.Count - 1)
                LastQuestion = true;
        }
    }
}

