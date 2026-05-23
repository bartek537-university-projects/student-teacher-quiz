using QuizApp.Student.Application.Common;
using QuizApp.Student.Application.Recents.Abstractions;
using QuizApp.Student.Domain.Entities;

namespace QuizApp.Student.Application.Recents;

public static class GetRecentFiles
{
    public sealed record Query : IRequest<Response>;

    internal sealed class Handler(IRecentFilesRepository repository) : IRequestHandler<Query, Response>
    {
        public async Task<Response> HandleAsync(Query request, CancellationToken cancellationToken)
        {
            IReadOnlyList<RecentFile> files = await repository.GetAllAsync(cancellationToken);
            return new Response(files);
        }
    }

    public sealed record Response(IReadOnlyList<RecentFile> Files);
}
