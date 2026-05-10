namespace QuizApp.Teacher.View;

internal interface IQuizView : IHasQuiz
{
    event Action<string>? OnQuizTitleChange;
    event Action? OnClear;
}
