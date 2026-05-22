namespace QuizApp.Student.Presentation.QuizSelection.Interfaces;

internal interface IQuizSelectionView
{
    event Action Ready;
    event Action<Uri> LocalFileSelect;
}
