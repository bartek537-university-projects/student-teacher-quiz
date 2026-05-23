using QuizApp.Student.Application.Recents.Abstractions;
using QuizApp.Student.Domain.Entities;

namespace QuizApp.Student.Infrastructure.Recents;

internal class InMemoryRecentFilesRepository : IRecentFilesRepository
{
    private IReadOnlyList<RecentFile> _recentFiles = [];

    public Task<IReadOnlyList<RecentFile>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(_recentFiles);
    }

    public Task ReplaceAllAsync(IReadOnlyList<RecentFile> files, CancellationToken cancellationToken)
    {
        _recentFiles = files;
        return Task.CompletedTask;
    }
}
