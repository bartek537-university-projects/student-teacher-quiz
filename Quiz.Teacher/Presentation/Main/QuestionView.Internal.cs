using QuizApp.Core.Domain;
using QuizApp.Core.Extensions;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class QuestionView
{
    private int IndexByGuid(Guid guid)
    {
        return Quiz.Questions
            .FindIndexOf(q => q.Guid == guid);
    }

    private HashSet<Guid> GuidsInData()
    {
        return [.. Quiz.Questions
            .Select(q => q.Guid)];
    }

    private HashSet<Guid> GuidsInPanel()
    {
        return [.. panel.Controls
            .OfType<AnswerSegment>()
            .Select(s => s.Guid)];
    }

    private QuestionSegment SegmentByIndex(int index)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Quiz.Questions.Length);

        var segment = panel.Controls
            .OfType<QuestionSegment>()
            .First(s => s.Guid == Quiz.Questions[index].Guid);

        return segment;
    }
}
