using QuizApp.Core.Domain;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizReviewPresenter
{
    IReadOnlyList<Question> Questions { get; }
    int CurrentQuestionIndex { get; set; }

    Question? CurrentQuestionValue { get; }
    IReadOnlyList<Answer> CurrentQuestionSelectedAnswers { get; }

    event Action CurrentQuestionChange;
}
