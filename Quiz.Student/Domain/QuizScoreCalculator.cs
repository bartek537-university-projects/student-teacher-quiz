using QuizApp.Core.Domain;
using QuizApp.Student.Domain.Interfaces;

namespace QuizApp.Student.Domain;

internal class QuizScoreCalculator(IQuestionScoreStrategy questionScoreStrategy) : IQuizScoreCalculator
{
    public Dictionary<Guid, int> Score(
        IReadOnlyList<Question> questions,
        IReadOnlyDictionary<Guid, IReadOnlyList<Answer>> userAnswers)
    {
        Dictionary<Guid, int> score = [];

        foreach (Question question in questions)
        {
            if (!userAnswers.TryGetValue(question.Guid, out IReadOnlyList<Answer>? userAnswer))
            {
                continue;
            }

            int questionScore = questionScoreStrategy.Score(question, userAnswer);
            score[question.Guid] = questionScore;
        }

        return score;
    }
}
