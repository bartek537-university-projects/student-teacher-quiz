using QuizApp.Core.Domain;
using QuizApp.Core.Extensions;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class QuestionView(IHasQuiz hasQuiz, Panel panel) : IQuestionView
{
    public Quiz Quiz
    {
        get => hasQuiz.Quiz;
        set => hasQuiz.Quiz = value;
    }

    public Indexer<int, Panel> PanelIndexer => new(
        getter: i => SegmentByIndex(i).GetPanel(),
        setter: (_, _) => throw new NotSupportedException("Indexer is read-only.")
        );

    public event Action<int>? OnQuestionAdd;
    public event Action<int>? OnQuestionInspireAdd;
    public event Action<int, string>? OnQuestionTitleChange;
    public event Action<int, int>? OnQuestionPlusPointsChange;
    public event Action<int, int>? OnQuestionMinusPointsChange;
    public event Action<int>? OnQuestionRemove;
    public event Action<int>? OnQuestionMoveDown;
    public event Action<int>? OnQuestionMoveUp;

    public void RefreshView()
    {
        var questions = Quiz.Questions;

        HashSet<Guid> inData = GuidsInData();
        HashSet<Guid> inPanel = GuidsInPanel();
        HashSet<Guid> toRemove = [.. inPanel.Except(inData)];

        var segDict = panel.Controls
            .OfType<QuestionSegment>()
            .ToDictionary(s => s.Guid);

        foreach (var guid in toRemove) // remove old
        {
            segDict[guid].Dispose();
        }

        for (int i = 0; i < inData.Count; i++) // add new
        {
            Question question = questions[i];
            if (!segDict.ContainsKey(question.Guid))
            {
                var segment = CreateSegment(question, i);
                segDict.Add(question.Guid, segment);

                panel.Controls.Add(segment);
            }
        }

        for (int i = 0; i < inData.Count; i++) // reorder
        {
            Question question = Quiz.Questions[i];
            var segment = segDict[question.Guid];

            segment.BringToFront();
        }

        for (int i = 0; i < inData.Count; i++) // refresh
        {
            Question question = Quiz.Questions[i];
            var segment = segDict[question.Guid];

            bool isFirst = i == 0;
            bool isLast = i == inData.Count - 1;

            segment.RefreshView(question, isFirst, isLast);
            segment.TabIndex = i;
        }
    }

    public List<Panel> AllPanels()
    {
        return [
            panel,
            .. panel.Controls
                .OfType<QuestionSegment>()
                .Select(s => s.GetPanel())
            ];
    }

    public void CreateQuestionOnTail(bool inspire)
    {
        if (inspire) { OnQuestionInspireAdd?.Invoke(Quiz.Questions.Length); }
        else { OnQuestionAdd?.Invoke(Quiz.Questions.Length); }
    }

    public void HighlightError(int index)
    {
        var segment = SegmentByIndex(index);
        segment.HighlightError();
    }

    private QuestionSegment CreateSegment(Question question, int index)
    {
        Guid guid = question.Guid;

        QuestionSegment result = new()
        {
            Guid = guid,
            Dock = DockStyle.Top,
        };

        result.OnTitleChange += title => OnQuestionTitleChange?.Invoke(IndexByGuid(guid), title);
        result.OnPlusPointsChange += plusPoints => OnQuestionPlusPointsChange?.Invoke(IndexByGuid(guid), plusPoints);
        result.OnMinusPointsChange += minusPoints => OnQuestionMinusPointsChange?.Invoke(IndexByGuid(guid), minusPoints);

        result.OnNew += () => OnQuestionAdd?.Invoke(IndexByGuid(guid) + 1);
        result.OnDelete += () => OnQuestionRemove?.Invoke(IndexByGuid(guid));
        result.OnMoveDown += () => OnQuestionMoveDown?.Invoke(IndexByGuid(guid));
        result.OnMoveUp += () => OnQuestionMoveUp?.Invoke(IndexByGuid(guid));

        return result;
    }
}
