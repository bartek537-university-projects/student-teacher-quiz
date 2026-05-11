using QuizApp.Core.Domain;
using QuizApp.Core.Extensions;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class AnswerView
{
    private int I0ByQuestionGuid(Guid guid)
    {
        return Quiz.Questions
            .FindIndexOf(q => q.Guid == guid);
    }

    private int I0ByGuid(Guid guid)
    {
        return Quiz.Questions
            .FindIndexOf(q => q.Answers
            .FindIndexOf(a => a.Guid == guid) != -1);
    }

    private int IndexByGuid(Guid guid)
    {
        int i0 = I0ByGuid(guid);
        return Quiz.Questions[i0].Answers
            .FindIndexOf(a => a.Guid == guid);
    }

    private HashSet<Guid> GuidsInData(int i0)
    {
        return [.. Quiz.Questions[i0].Answers
            .Select(a => a.Guid)];
    }

    private HashSet<Guid> GuidsInPanel(int i0)
    {
        return [.. panels[i0].Controls
            .OfType<AnswerSegment>()
            .Select(s => s.Guid)];
    }
}
