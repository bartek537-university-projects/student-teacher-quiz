using QuizApp.Core.Domain;

namespace QuizApp.Teacher.View;

internal interface IHasQuiz
{
    Quiz Quiz { get; set; }
}
