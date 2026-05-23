using QuizApp.Student.Application.Recents.Abstractions;
using QuizApp.Student.Domain.Entities;
using System.Text.Json;

namespace QuizApp.Student.Infrastructure.Recents;

internal class FileSystemRecentFilesRepository(string path) : IRecentFilesRepository
{
    public async Task<IReadOnlyList<RecentFile>> GetAllAsync(CancellationToken cancellationToken)
    {
        Aggregates.Recents? recents = ReadRecents(path);
        return recents?.Files ?? [];
    }

    private static Aggregates.Recents? ReadRecents(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Aggregates.Recents>(json);
        }
        catch
        {
            return null;
        }
    }

    public Task ReplaceAllAsync(IReadOnlyList<RecentFile> files, CancellationToken cancellationToken)
    {
        Aggregates.Recents recents = new(files);
        WriteRecents(path, recents);

        return Task.CompletedTask;
    }

    private static void WriteRecents(string path, Aggregates.Recents recents)
    {
        string json = JsonSerializer.Serialize(recents);
        File.WriteAllText(path, json);
    }
}
