using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;



namespace Interactive_quiz_by_harneet;

public partial class MainPage : ContentPage
{
    private Quiz quiz;
    private Question question;
    private bool userAttempt;
    public MainPage()
    {
        InitializeComponent();
         quiz = new Quiz("Quiz");
        Title.Text = quiz.Title;
        question = quiz.GetNextQuestion();
       Display(question);
    }

    private void CheckAnswer(string answer, Button button)
    {
        quiz.CheckUserAnswer(answer);

        if (quiz.LastQuestion == true)
        {
            Question.Text = "End of the quiz. Start a new session to restart again !";
            DisplayAlert("Results", $"You got {quiz.Score} correct answers out of {quiz.TotalQuestions}.", "Ok");


            // Hide all answer buttons
            BTN1.IsVisible = false;
            BTN2.IsVisible = false;
            BTN3.IsVisible = false;
            BTN4.IsVisible = false;


            // Hide the next question button and show the quit button instead
            Next.IsVisible = false;
            Quit.IsVisible = true;
        }
        //else
        //{
        //    // Show the next question
        //    quiz.GetNextQuestion();
        //}

        // Change the button background color based on the correctness of the answer
        if (answer == question.CorrectAnswer)
        {
            button.BackgroundColor = Colors.Green;
           
        }
        else
        {
            button.BackgroundColor = Colors.OrangeRed;
            
        }
        
    }
    private void CheckUserOption(Button button)
    {
        
        
             userAttempt = false; // to keep track if the code has been executed

            
                if (!userAttempt)
                {
                    CheckAnswer(button.Text, button);
                    userAttempt = true; 
                }
            
            
        
    }

    private void BTN1_Clicked(object sender, EventArgs e)
    {
        OnlyOnetry();
        if (!userAttempt) { CheckUserOption(BTN1); }
         }
    private void BTN2_Clicked(object sender, EventArgs e)
    {
        OnlyOnetry();
        if (!userAttempt) { CheckUserOption(BTN2); }
    }
    private void BTN3_Clicked(object sender, EventArgs e)
    {
        OnlyOnetry();
        if (!userAttempt) { CheckUserOption(BTN3); }
    }
    private void BTN4_Clicked(object sender, EventArgs e)
    {
        OnlyOnetry();
        if (!userAttempt) { CheckUserOption(BTN4); }
    }


    private void Next_Clicked(object sender, EventArgs e)
    {
        
        question = quiz.GetNextQuestion();
        userAttempt = false;
        BTN1.BackgroundColor = Colors.White;
        BTN2.BackgroundColor = Colors.White;
            BTN3.BackgroundColor = Colors.White;
        BTN4.BackgroundColor = Colors.White;
        Display(question);
        //CleanUI(Next);
        //BTN1.BackgroundColor = default(Color);
        //BTN2.BackgroundColor = default(Color);
        //BTN3.BackgroundColor = default(Color);
        //BTN4.BackgroundColor = default(Color);

    }

    private void QuitButton_Clicked(object sender, EventArgs e)
    {
        // Do something
        DisplayAlert("Results", $"You got {quiz.Score} correct answers out of {quiz.TotalQuestions}.", "Ok");
    }
    private void Display(Question question)
    {
        if (question is TrueFalseQuestion)
        {
            Question.Text = question.QuestionText;
            BTN1.Text = "True";
            BTN2.Text = "False";
            BTN3.IsVisible = false;
            BTN4.IsVisible = false;
        }
        if (question is MultipleChoiceQuestion)
        {
            MultipleChoiceQuestion mcq = (MultipleChoiceQuestion)question;
            Question.Text = mcq.QuestionText;
            BTN1.Text = mcq.OptionA;
            BTN2.Text = mcq.OptionB;
            BTN3.Text = mcq.OptionC;
            BTN4.Text = mcq.OptionD;

        }
        
    }
    private void OnlyOnetry()
    {if (userAttempt)
        {
            DisplayAlert("Warning !", $"You can only try once. Click on 'Next' to go to Next question", "Ok");
        }
    }
}

