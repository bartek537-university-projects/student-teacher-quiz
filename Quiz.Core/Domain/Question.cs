using System.Collections.Immutable;

namespace QuizApp.Core.Domain;

public record Question
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public required string Title { get; init; }
    public required int PlusPoints { get; init; }
    public required int MinusPoints { get; init; }
    public required ImmutableArray<Answer> Answers { get; init; }
}
