using QuizApp.Student.Domain.Entities;

namespace QuizApp.Student.Presentation.QuizSelection.Interfaces;

internal interface IQuizSelectionPresenter
{
    IReadOnlyList<RecentFile> RecentFiles { get; }

    event Action RecentFilesChanged;
}
