using QuizApp.Student.Application.Common;
using QuizApp.Student.Application.Recents.Abstractions;
using QuizApp.Student.Domain.Entities;

namespace QuizApp.Student.Application.Recents;

public static class AddRecentFile
{
    public sealed record Command(Uri Path, DateTime OpenedAt) : IRequest<Response>;

    public sealed class Handler(IRecentFilesRepository repository) : IRequestHandler<Command, Response>
    {
        private const int MaxRecentFiles = 5;

        public async Task<Response> HandleAsync(Command request, CancellationToken cancellationToken)
        {
            IReadOnlyList<RecentFile> existingFiles = await repository.GetAllAsync(cancellationToken);

            RecentFile newFile = new(request.Path, request.OpenedAt);

            List<RecentFile> mostRecentFiles = [.. existingFiles
                .Append(newFile)
                .GroupBy(file => file.Path)
                .Select(group => group.MaxBy(file => file.OpenedAt)!)
                .OrderByDescending(file => file.OpenedAt)
                .Take(MaxRecentFiles)];

            await repository.ReplaceAllAsync(mostRecentFiles, cancellationToken);

            return new Response();
        }
    }

    public sealed record Response;
}
