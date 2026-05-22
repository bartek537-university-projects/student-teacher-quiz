using QuizApp.Student.Domain.Entities;
using QuizApp.Student.Presentation.QuizSelection.Interfaces;

namespace QuizApp.Student.Presentation.QuizSelection;

internal class QuizSelectionPresenter : IQuizSelectionPresenter
{
    private readonly IQuizSelectionView _view;

    public IReadOnlyList<RecentFile> RecentFiles
    {
        get;
        private set
        {
            field = value;
            RecentFilesChanged?.Invoke();
        }
    } = [];

    public event Action? RecentFilesChanged;

    public QuizSelectionPresenter(IQuizSelectionView view)
    {
        _view = view;

        _view.Ready += () => OnViewReadyAsync().Wait();
        _view.LocalFileSelect += path => OnLocalFileSelectedAsync(path, CancellationToken.None).Wait();
    }

    private async Task OnViewReadyAsync()
    {
        RecentFiles = [];
    }

    private async Task OnLocalFileSelectedAsync(Uri path, CancellationToken ct)
    {

    }
}
