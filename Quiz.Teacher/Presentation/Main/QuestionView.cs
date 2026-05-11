using QuizApp.Core.Domain;
using QuizApp.Core.Utils;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal class QuestionView(IHasQuiz hasQuiz, Panel panel) : IQuestionView
{
    public Quiz Quiz
    {
        get => hasQuiz.Quiz;
        set => hasQuiz.Quiz = value;
    }

    public Indexer<int, Panel> PanelIndexer => new(
        getter: i => SegmentByIndex(i).Panel,
        setter: (_, _) => throw new NotSupportedException("Indexer is read-only.")
        );

    public event Action<int, Question>? OnQuestionAdd;
    public event Action<int, string>? OnQuestionTitleChange;
    public event Action<int, int>? OnQuestionPlusPointsChange;
    public event Action<int, int>? OnQuestionMinusPointsChange;
    public event Action<int>? OnQuestionRemove;
    public event Action<int>? OnQuestionMoveDown;
    public event Action<int>? OnQuestionMoveUp;

    public void RefreshView()
    {
        HashSet<Guid> inPanel = [..
            panel.Controls
                .OfType<QuestionSegment>()
                .Select(s => s.Guid)
            ];

        HashSet<Guid> inData = [..
            Quiz.Questions
                .Select(q => q.Guid)
            ];

        HashSet<Guid> toKeep = [.. inPanel.Intersect(inData)];
        HashSet<Guid> toKill = [.. inPanel.Except(toKeep)];

        Dictionary<Guid, QuestionSegment> segmentsByGuid = panel.Controls
            .OfType<QuestionSegment>()
            .ToDictionary(s => s.Guid);

        panel.Controls.Clear();

        foreach (Guid guid in toKill)
        {
            segmentsByGuid[guid].Dispose();
        }
        
        for (int i = 0; i < Quiz.Questions.Length; i++)
        {
            Question question = Quiz.Questions[i];

            Guid guid = question.Guid;
            if (!segmentsByGuid.TryGetValue(guid, out var segment))
            {
                segment = CreateSegment(question);
            }

            panel.Controls.Add(segment);

            segment.RefreshView(question, i);
        }
    }

    public void HighlightError(int index)
    {
        QuestionSegment segment = SegmentByIndex(index);
        segment.HighlightError();
    }

    private QuestionSegment CreateSegment(Question question)
    {
        Guid guid = question.Guid;

        QuestionSegment result = new()
        {
            Guid = guid,
            Dock = DockStyle.Top,
        };

        int IndexOf(Guid guid)
        {
            int lngt = Quiz.Questions.Length;
            for (int i = 0; i < lngt; i++)
            {
                if (Quiz.Questions[i].Guid == guid)
                    return i;
            }
            throw new InvalidOperationException($"Question with guid {guid} not found in quiz.");
        }

        Question InstanceOf(Guid guid)
        {
            int index = IndexOf(guid);
            return Quiz.Questions[index];
        }

        result.OnTitleChange += title => OnQuestionTitleChange?.Invoke(IndexOf(guid), title);
        result.OnPlusPointsChange += plusPoints => OnQuestionPlusPointsChange?.Invoke(IndexOf(guid), plusPoints);
        result.OnMinusPointsChange += minusPoints => OnQuestionMinusPointsChange?.Invoke(IndexOf(guid), minusPoints);

        result.OnCopy += () => OnQuestionAdd?.Invoke(IndexOf(guid) + 1, InstanceOf(guid).New());
        result.OnDelete += () => OnQuestionRemove?.Invoke(IndexOf(guid));
        result.OnMoveDown += () => OnQuestionMoveDown?.Invoke(IndexOf(guid));
        result.OnMoveUp += () => OnQuestionMoveUp?.Invoke(IndexOf(guid));

        return result;
    }

    private QuestionSegment SegmentByIndex(int index)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Quiz.Questions.Length);

        QuestionSegment segment = panel.Controls
            .OfType<QuestionSegment>()
            .First(s => s.Guid == Quiz.Questions[index].Guid);

        return segment;
    }
}
