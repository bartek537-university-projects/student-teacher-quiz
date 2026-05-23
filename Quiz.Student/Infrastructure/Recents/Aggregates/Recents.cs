using QuizApp.Student.Domain.Entities;
using System.Text.Json.Serialization;

namespace QuizApp.Student.Infrastructure.Recents.Aggregates;

internal record Recents(
    [property:JsonPropertyName("files")]
    IReadOnlyList<RecentFile> Files
);
