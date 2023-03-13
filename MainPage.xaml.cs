namespace Interactive_quiz_by_harneet;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		Quiz quiz = new Quiz("Quiz");
       Question question= quiz.GetNextQuestion();
        if (question is TrueFalseQuestion)
        {
            Question.Text = question.QuestionText;
            BTN1.Text = "True";
            BTN2.Text = "False";
            BTN3.IsVisible = false;
            BTN4.IsVisible = false;
        }
        if (question is MultipleChoiceQuestion)
        {MultipleChoiceQuestion mcq= (MultipleChoiceQuestion)question;
            Question.Text = mcq.QuestionText;
            BTN1.Text = mcq.OptionA;
            BTN2.Text = mcq.OptionB;
            BTN3.Text = mcq.OptionC;
            BTN4.Text = mcq.OptionD;

        }

    }

	
}

