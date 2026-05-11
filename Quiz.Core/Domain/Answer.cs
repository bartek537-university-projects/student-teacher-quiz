namespace QuizApp.Core.Domain;

public record Answer
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public required string Title { get; init; }
    public required bool IsCorrect { get; init; }
}
