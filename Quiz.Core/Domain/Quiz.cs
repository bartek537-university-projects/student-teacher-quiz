using System.Collections.Immutable;

namespace QuizApp.Core.Domain;

public record Quiz
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public required string Title { get; init; }
    public required ImmutableArray<Question> Questions { get; init; }
}
