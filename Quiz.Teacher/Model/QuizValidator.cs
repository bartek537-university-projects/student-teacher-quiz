using QuizApp.Core.Domain;

namespace QuizApp.Teacher.Model;

internal interface IQuizValidator
{
    bool Validate(Quiz quiz,
        out string errorMessage,
        out int? wrongQuestionIndex
        );
}

internal class QuizValidator : IQuizValidator
{
    public bool Validate(Quiz quiz,
        out string errorMessage,
        out int? wrongQuestionIndex
        )
    {
        int? errorIndex = null;

        string? error = quiz switch
        {
            _ when string.IsNullOrWhiteSpace(quiz.Title)
                => "Tytuł quizu nie może być pusty!",

            _ when quiz.Questions.Length == 0
                => "Quiz musi zawierać co najmniej jedno pytanie!",

            _ when !TestMore(quiz.Questions, q => !string.IsNullOrWhiteSpace(q.Title), out errorIndex)
                => $"Pytanie {errorIndex + 1} nie może być puste!",

            _ when !TestMore(quiz.Questions, q => q.Answers.Any(a => a.IsCorrect), out errorIndex)
                => $"Pytanie {errorIndex + 1} musi zawierać co najmniej jedną poprawną odpowiedź!",

            _ when !TestMore(quiz.Questions, q => q.Answers.All(a => !string.IsNullOrWhiteSpace(a.Title)), out errorIndex)
                => $"Pytanie {errorIndex + 1} nie może zawierać pustych odpowiedzi!",

            _ => null
        };

        wrongQuestionIndex = errorIndex;
        errorMessage = error ?? "Quiz jest poprawny :)";

        return error is null;
    }

    private static bool TestMore<T>(
        IEnumerable<T> collection, Predicate<T> predicate, out int? errorIndex)
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

        errorIndex = null;
        return true;
    }
}
