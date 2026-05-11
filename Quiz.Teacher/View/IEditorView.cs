namespace QuizApp.Teacher.View;

internal interface IEditorView : IHasQuiz
{
    int Lock { get; set; }

    event Action<string>? OnTitleChange;

    event Action? OnClearRequest;
    event Action? OnClearInstant;

    event Action? OnLoadRequest;
    event Action? OnSaveRequest;

    void ShowValidationProblems(string message, int? questionIndex);

    string? AskLoadFile(params string[] extensions);
    string? AskSaveFile(params string[] extensions);
    string? AskPassword();

    void ShowInfo(string message);
    void ShowWarning(string message);
    void ShowError(string message);
    bool AskConfirm(string message);
}
