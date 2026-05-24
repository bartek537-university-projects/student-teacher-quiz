using QuizApp.Core.Domain;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizQuestionPresenter
{
    IReadOnlyList<Question> Questions { get; set; }
    int CurrentQuestionIndex { get; set; }

    Question? CurrentQuestionValue { get; }
    IReadOnlyList<Answer> CurrentQuestionAnswers { get; }

    event Action CurrentQuestionChange;
}
