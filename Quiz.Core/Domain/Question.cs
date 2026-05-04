using System.Collections.ObjectModel;

namespace QuizApp.Core.Domain;

public record Question(
    string Text,
    ReadOnlyCollection<Answer> Answers
    );
