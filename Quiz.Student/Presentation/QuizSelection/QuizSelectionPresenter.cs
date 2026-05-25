using QuizApp.Student.Application.Common;
using QuizApp.Student.Application.Quiz;
using QuizApp.Student.Application.Recents;
using QuizApp.Student.Domain.Entities;
using QuizApp.Student.Presentation.QuizSelection.Interfaces;
using DomainQuiz = QuizApp.Core.Domain.Quiz;

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

    private readonly IRequestHandler<GetQuiz.Query, GetQuiz.Response> _getQuiz;
    private readonly IRequestHandler<AddRecentFile.Command, AddRecentFile.Response> _addRecentFile;
    private readonly IRequestHandler<GetRecentFiles.Query, GetRecentFiles.Response> _getRecentFiles;

    public event Action? RecentFilesChanged;

    public QuizSelectionPresenter(IQuizSelectionView view,
        TimeProvider timeProvider,
        IRequestHandler<GetQuiz.Query, GetQuiz.Response> getQuiz,
        IRequestHandler<AddRecentFile.Command, AddRecentFile.Response> addRecentFiles,
        IRequestHandler<GetRecentFiles.Query, GetRecentFiles.Response> getRecentFiles)
    {
        _view = view;
        _timeProvider = timeProvider;

        _getQuiz = getQuiz;
        _addRecentFile = addRecentFiles;
        _getRecentFiles = getRecentFiles;

        _view.Ready += async () =>
        {
            await OnViewReadyAsync(CancellationToken.None);
        };

        _view.FileSelect += async (path, secret) =>
        {
            await OnLocalFileSelectedAsync(
                path,
                secret ?? string.Empty,
                CancellationToken.None);
        };
    }

    private async Task OnViewReadyAsync(CancellationToken cancellationToken)
    {
        await UpdateRecentFilesAsync(cancellationToken);
    }

    private async Task OnLocalFileSelectedAsync(Uri path, string secret, CancellationToken cancellationToken)
    {
        DomainQuiz? quiz = await GetQuizAsync(path, secret, cancellationToken);

        if (quiz is null)
        {
            _view.ShowPasswordPrompt(path);
            return;
        }

        _view.HidePasswordPrompt();
        await AddRecentFileAsync(path, cancellationToken);
        await UpdateRecentFilesAsync(cancellationToken);
        _view.StartQuizSession(quiz);
    }

    private async Task<DomainQuiz?> GetQuizAsync(Uri path, string secret, CancellationToken cancellationToken)
    {
        GetQuiz.Response response = await _getQuiz
            .HandleAsync(new(path, secret), cancellationToken);

        return response.Quiz;
    }

    private async Task UpdateRecentFilesAsync(CancellationToken cancellationToken)
    {
        GetRecentFiles.Response recentFiles = await _getRecentFiles
            .HandleAsync(new(), CancellationToken.None);

        RecentFiles = recentFiles.Files;
    }

    private async Task AddRecentFileAsync(Uri path, CancellationToken cancellationToken)
    {
        DateTime now = _timeProvider.GetUtcNow().DateTime;

        _ = await _addRecentFile
            .HandleAsync(new(path, now), cancellationToken);
    }
}
