using QuizApp.Core.Domain;
using QuizApp.Student.Domain.Interfaces;

namespace QuizApp.Student.Domain;

internal class AllOrNothingQuestionScoreStrategy : IQuestionScoreStrategy
{
    /// <summary>
    /// Rewards the user with
    ///     maximum allowed points if they picked all correct answers,
    ///     minimum allowed points if they picked at least one invalid answer,
    ///     zero points if they didn't pick all correct answers or picked none answers.
    /// </summary>
    public int Score(Question question, IReadOnlyList<Answer> userAnswer)
    {
        bool userChoseIncorrectAnswer = userAnswer
            .Any(a => !a.IsCorrect);

        if (userChoseIncorrectAnswer)
        {
            return -question.MinusPoints;
        }

        bool userChoseAllCorrectAnswers = question
            .Answers.Where(a => a.IsCorrect)
            .All(a => userAnswer.Contains(a));

        if (userChoseAllCorrectAnswers)
        {
            return question.PlusPoints;
        }

        return 0;
    }
}
