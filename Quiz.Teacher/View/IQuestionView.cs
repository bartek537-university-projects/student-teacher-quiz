namespace QuizApp.Teacher.View;

internal interface IQuestionView : IHasQuiz
{
    event Action<int>? OnQuestionAdd;
    event Action<int, string>? OnQuestionTitleChange;
    event Action<int, int>? OnQuestionPlusPointsChange;
    event Action<int, int>? OnQuestionMinusPointsChange;
    event Action<int>? OnQuestionRemove;
    event Action<int>? OnQuestionMoveDown;
    event Action<int>? OnQuestionMoveUp;
}
