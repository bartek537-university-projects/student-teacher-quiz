using QuizApp.Core.Domain;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizQuestionView
{
    public event Action Ready;
    public event Action<IReadOnlyList<Answer>> AnswerSelectionChange;
}
