using QuizApp.Student.Domain.Entities;

namespace QuizApp.Student.Application.Recents.Abstractions;

public interface IRecentFilesRepository
{
    Task<IReadOnlyList<RecentFile>> GetAllAsync(CancellationToken cancellationToken);

    Task ReplaceAllAsync(IReadOnlyList<RecentFile> files, CancellationToken cancellationToken);
}
