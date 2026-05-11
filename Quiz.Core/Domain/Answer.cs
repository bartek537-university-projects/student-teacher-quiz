namespace QuizApp.Core.Domain;

public record Answer(
    string Title,
    bool IsCorrect
    )
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public Answer New() => this with { Guid = Guid.NewGuid() };
}
