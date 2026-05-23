namespace QuizApp.Student.Presentation.QuizSelection.Interfaces;

internal interface IQuizSelectionView
{
    event Action Ready;
    event Action<Uri, string?> FileSelect;

    void ShowPasswordPrompt(Uri path);
    void HidePasswordPrompt();
}
