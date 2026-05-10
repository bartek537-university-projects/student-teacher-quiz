using QuizApp.Core.Domain;

namespace QuizApp.Teacher.View;

internal interface IHasQuiz
{
    public Quiz Quiz { get; set; }
}
