using System.Collections.ObjectModel;

namespace QuizApp.Core.Domain;

public record Quiz(
    string Title,
    ReadOnlyCollection<Question> Questions
    );
