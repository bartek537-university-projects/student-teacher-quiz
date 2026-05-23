using QuizApp.Student.Application.Common;
using QuizApp.Student.Application.Recents;
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

    private readonly TimeProvider _timeProvider;

    private readonly IRequestHandler<AddRecentFile.Command, AddRecentFile.Response> _addRecentFile;
    private readonly IRequestHandler<GetRecentFiles.Query, GetRecentFiles.Response> _getRecentFiles;

    public event Action? RecentFilesChanged;

    public QuizSelectionPresenter(IQuizSelectionView view,
        TimeProvider timeProvider,
        IRequestHandler<AddRecentFile.Command, AddRecentFile.Response> addRecentFiles,
        IRequestHandler<GetRecentFiles.Query, GetRecentFiles.Response> getRecentFiles)
    {
        _view = view;
        _timeProvider = timeProvider;

        _addRecentFile = addRecentFiles;
        _getRecentFiles = getRecentFiles;

        _view.Ready += () => OnViewReadyAsync(CancellationToken.None).Wait();
        _view.LocalFileSelect += path => OnLocalFileSelectedAsync(path, CancellationToken.None).Wait();
    }

    private async Task OnViewReadyAsync(CancellationToken cancellationToken)
    {
        await UpdateRecentFilesAsync(cancellationToken);
    }

    private async Task OnLocalFileSelectedAsync(Uri path, CancellationToken cancellationToken)
    {
        await AddRecentFileAsync(path, cancellationToken);
        await UpdateRecentFilesAsync(cancellationToken);
    }

    private async Task UpdateRecentFilesAsync(CancellationToken cancellationToken)
    {
        GetRecentFiles.Response recentFiles = await _getRecentFiles
            .HandleAsync(new(), CancellationToken.None);

        RecentFiles = recentFiles.Files;
    }

    private async Task AddRecentFileAsync(Uri path, CancellationToken cancellationToken)
    {
        DateTime now = _timeProvider.GetLocalNow().DateTime;

        _ = await _addRecentFile
            .HandleAsync(new(path, now), cancellationToken);
    }
}
