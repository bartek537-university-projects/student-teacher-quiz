namespace QuizApp.Teacher.View;

internal interface IAnswerView : IHasQuiz
{
    event Action<int, int>? OnAnswerAdd;
    event Action<int, int, string>? OnAnswerTitleChange;
    event Action<int, int, bool>? OnAnswerIsCorrectChange;
    event Action<int, int>? OnAnswerRemove;
    event Action<int, int>? OnAnswerMoveDown;
    event Action<int, int>? OnAnswerMoveUp;
}
