using QuizApp.Core.Domain;

namespace QuizApp.Core.Model;

public interface IQuizValidator
{
    bool Validate(Quiz quiz,
        out string errorMessage,
        out int? wrongQuestionIndex
        );
}

public class QuizValidator : IQuizValidator
{
    public bool Validate(Quiz quiz,
        out string errorMessage,
        out int? wrongQuestionIndex
        )
    {
        (string message, int? errorIndex)? error = quiz switch
        {
            _ when string.IsNullOrWhiteSpace(quiz.Title)
                => ("Tytuł quizu nie może być pusty!", null),

            _ when quiz.Questions.Length == 0
                => ("Quiz musi zawierać co najmniej jedno pytanie!", null),

            _ when !TestMore(quiz.Questions, q => !string.IsNullOrWhiteSpace(q.Title), out var index)
                => ($"Pytanie {index + 1} nie może być puste!", index),

            _ when !TestMore(quiz.Questions, q => q.Answers.Any(a => a.IsCorrect), out var index)
                => ($"Pytanie {index + 1} musi zawierać co najmniej jedną poprawną odpowiedź!", index),

            _ when !TestMore(quiz.Questions, q => q.Answers.All(a => !string.IsNullOrWhiteSpace(a.Title)), out var index)
                => ($"Pytanie {index + 1} nie może zawierać pustych odpowiedzi!", index),

            _ when !TestPairs(quiz.Questions, p => p.Item1.Guid != p.Item2.Guid, out var ind)
                => ($"Pytania {ind.Item1 + 1} oraz {ind.Item2 + 1} zawierają identyczny GUID!", ind.Item1),

            _ when !TestMore(quiz.Questions, q => TestPairs(q.Answers, p => p.Item1.Guid != p.Item2.Guid, out _), out var index)
                => ($"Pytanie {index + 1} zawiera dwie odpowiedzi, zawierające identyczny GUID!", index),

            _ => null
        };

        wrongQuestionIndex = error?.errorIndex;
        errorMessage = error?.message ?? "Everything is fine!";

        return error == null;
    }

    private static bool TestMore<T>(
        IEnumerable<T> collection, Predicate<T> predicate, out int errorIndex)
    {
        T[] array = [.. collection];

        for (int i = 0; i < array.Length; i++)
        {
            if (!predicate(array[i]))
            {
                errorIndex = i;
                return false;
            }
        }

        errorIndex = default;
        return true;
    }

    private static bool TestPairs<T>(
        IEnumerable<T> collection, Predicate<(T, T)> predicate, out (int, int) indexes)
    {
        T[] array = [.. collection];

        for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array.Length; j++)
            {
                if (i == j) continue;
                if (!predicate((array[i], array[j])))
                {
                    indexes = (i, j);
                    return false;
                }
            }

        indexes = default;
        return true;
    }
}
