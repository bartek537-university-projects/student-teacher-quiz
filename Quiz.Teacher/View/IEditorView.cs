namespace QuizApp.Teacher.View;

internal interface IEditorView : IHasQuiz
{
    event Action? OnLoadRequest;
    event Action? OnSaveRequest;

    void ShowValidationProblems(string message, int? questionIndex);

    string? AskLoadFile();
    string? AskSaveFile();
    string? AskPassword();

    void ShowInfo(string message);
    void ShowWarning(string message);
    void ShowError(string message);
}
