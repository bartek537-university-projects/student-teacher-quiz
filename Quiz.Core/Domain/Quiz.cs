using System.Collections.Immutable;

namespace QuizApp.Core.Domain;

public record Quiz(
    string Title,
    ImmutableArray<Question> Questions
    );
