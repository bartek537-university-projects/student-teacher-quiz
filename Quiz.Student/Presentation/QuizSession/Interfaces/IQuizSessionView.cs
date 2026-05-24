namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizSessionView
{
    string Title { set; }

    event Action Ready;
    event Action StartClick;
    event Action StopClick;
}
