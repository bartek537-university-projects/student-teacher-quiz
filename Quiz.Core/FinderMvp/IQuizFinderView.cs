namespace QuizApp.Core.FinderMvp;

internal interface IQuizFinderView
{
    event Action<string>? OnSelected;
    event Action OnDeleteClick;

    void UpdateQuizList(List<string> quizNames);
    void HighlightQuiz(string name);
}
