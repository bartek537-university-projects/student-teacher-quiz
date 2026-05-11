using System.Collections.Immutable;

namespace QuizApp.Core.Domain;

public record Quiz(
    string Title,
    ImmutableArray<Question> Questions
    )
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public Quiz New() => this with { Guid = Guid.NewGuid() };
}
