namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizReviewView
{
    event Action Ready;
    event Action NextQuestionClick;
    event Action PreviousQuestionClick;
}