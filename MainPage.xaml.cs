using System.Drawing;
using UIKit;


namespace Interactive_quiz_by_harneet;

public partial class MainPage : ContentPage
{
    private Quiz quiz;

    public MainPage()
    {
        InitializeComponent();
        Quiz quiz = new Quiz("Quiz");
        Question question = quiz.GetNextQuestion();
        if (question is TrueFalseQuestion)
        {
            Question.Text = question.QuestionText;
            BTN1.Text = "True";
            BTN2.Text = "False";
            BTN3.IsVisible = false;
            BTN4.IsVisible = false;
        }
        if (question is MultipleChoiceQuestion)
        { MultipleChoiceQuestion mcq = (MultipleChoiceQuestion)question;
            Question.Text = mcq.QuestionText;
            BTN1.Text = mcq.OptionA;
            BTN2.Text = mcq.OptionB;
            BTN3.Text = mcq.OptionC;
            BTN4.Text = mcq.OptionD;

        }
    }
    
    private void CheckAnswer(string answer, Button button)
    {
        quiz.CheckUserAnswer(answer);

        if (quiz.LastQuestion==true)
        {
            // Show the final score
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
        else
        {
            // Show the next question
            quiz.GetNextQuestion();
        }

        // Change the button background color based on the correctness of the answer
        if (answer == quiz.CorrectAnswer)
        {
            button.BackgroundColor = Color.Green;
        }
        else
        {
            button.BackgroundColor = Color.Red;
        }
    }

    private void BTN1_Clicked(object sender, EventArgs e)
    {
        CheckAnswer(BTN1.Text, BTN1);
    }

    private void BTN2_Clicked(object sender, EventArgs e)
    {
        CheckAnswer(BTN2.Text, BTN2);
    }
    private void BTN3_Clicked(object sender, EventArgs e)
    {
        CheckAnswer(BTN3.Text, BTN3);
    }
    private void BTN4_Clicked(object sender, EventArgs e)
    {
        CheckAnswer(BTN4.Text, BTN4);
    }



    private void Next_Clicked(object sender, EventArgs e)
    {
        // Show the next question
        quiz.GetNextQuestion();

        // Reset the button background colors
        BTN1.BackgroundColor = Color.Empty;
        BTN2.BackgroundColor = Color.Empty;
        BTN3.BackgroundColor = Color.Empty;
        BTN4.BackgroundColor = Color.Empty;
        
    }

    private void QuitButton_Clicked(object sender, EventArgs e)
    {
        // Do something

    }

