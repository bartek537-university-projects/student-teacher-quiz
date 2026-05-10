using System.Collections.Immutable;

namespace QuizApp.Core.Domain;

public record Question(
    string Title,
    int PlusPoints, // Points for correct answer
    int MinusPoints, // Points for incorrect answer
    ImmutableArray<Answer> Answers
    );
