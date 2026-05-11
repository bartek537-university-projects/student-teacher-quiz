using QuizApp.Core.Domain;
using QuizApp.Core.Utils;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal class AnswerView(IHasQuiz hasQuiz, Indexer<int, Panel> panels) : IAnswerView
{
    public Quiz Quiz
    {
        get => hasQuiz.Quiz;
        set => hasQuiz.Quiz = value;
    }

    public event Action<int, int, Answer>? OnAnswerAdd;
    public event Action<int, int, string>? OnAnswerTitleChange;
    public event Action<int, int, bool>? OnAnswerIsCorrectChange;
    public event Action<int, int>? OnAnswerRemove;
    public event Action<int, int>? OnAnswerMoveDown;
    public event Action<int, int>? OnAnswerMoveUp;

    public void RefreshView()
    {
        // TODO: implement
    }
}
