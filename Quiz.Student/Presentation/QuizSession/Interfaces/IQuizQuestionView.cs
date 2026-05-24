using QuizApp.Core.Domain;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizQuestionView
{
    event Action Ready;
    event Action<IReadOnlyList<Answer>> AnswerSelectionChange;
    event Action NextQuestionClick;
    event Action PreviousQuestionClick;
}
