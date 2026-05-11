using QuizApp.Core.Domain;
using QuizApp.Core.Extensions;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class AnswerView(IHasQuiz hasQuiz, Indexer<int, Panel> panels) : IAnswerView
{
    public Quiz Quiz
    {
        get => hasQuiz.Quiz;
        set => hasQuiz.Quiz = value;
    }

    public event Action<int, int>? OnAnswerAdd;
    public event Action<int, int, string>? OnAnswerTitleChange;
    public event Action<int, int, bool>? OnAnswerIsCorrectChange;
    public event Action<int, int>? OnAnswerRemove;
    public event Action<int, int>? OnAnswerMoveDown; // never happens (presenter code exists)
    public event Action<int, int>? OnAnswerMoveUp; // never happens (presenter code exists)

    public void RefreshView()
    {
        for (int i = 0; i < Quiz.Questions.Length; i++)
        {
            RefreshPanel(i);
            RefreshTools(i);
        }
    }

    private void RefreshPanel(int i0)
    {
        Panel panel = panels[i0];
        var answers = Quiz.Questions[i0].Answers;

        HashSet<Guid> inData = GuidsInData(i0);
        HashSet<Guid> inPanel = GuidsInPanel(i0);
        HashSet<Guid> toRemove = [.. inPanel.Except(inData)];

        var segDict = panel.Controls
            .OfType<AnswerSegment>()
            .ToDictionary(s => s.Guid);

        foreach (var guid in toRemove) // remove old
        {
            segDict[guid].Dispose();
        }

        for (int i = 0; i < answers.Length; i++) // add new
        {
            Answer answer = answers[i];
            if (!segDict.ContainsKey(answer.Guid))
            {
                var segment = CreateSegment(answer);
                segDict.Add(answer.Guid, segment);

                panel.Controls.Add(segment);
            }
        }

        for (int i = 0; i < answers.Length; i++) // reorder
        {
            Answer answer = answers[i];
            var segment = segDict[answer.Guid];

            segment.BringToFront();
        }

        for (int i = 0; i < answers.Length; i++) // refresh
        {
            Answer answer = answers[i];
            var segment = segDict[answer.Guid];

            segment.RefreshView(answer);
            segment.TabIndex = i;
        }
    }

    private void RefreshTools(int i0)
    {
        Panel panel = panels[i0];

        var tools = panel.Controls
            .OfType<AnswerTools>()
            .First();

        tools.BringToFront();

        if (tools.AllowObservation())
        {
            tools.Guid = Quiz.Questions[i0].Guid;

            tools.OnAdd += () =>
            {
                int i0 = I0ByQuestionGuid(tools.Guid);
                var answers = Quiz.Questions[i0].Answers;
                OnAnswerAdd?.Invoke(i0, answers.Length);
            };

            tools.OnRemove += () =>
            {
                int i0 = I0ByQuestionGuid(tools.Guid);
                var answers = Quiz.Questions[i0].Answers;
                OnAnswerRemove?.Invoke(i0, answers.Length - 1);
            };
        }

        var answers = Quiz.Questions[i0].Answers;

        tools.RefreshView(answers.Length);
        tools.TabIndex = answers.Length;
    }

    private AnswerSegment CreateSegment(Answer answer)
    {
        Guid guid = answer.Guid;

        AnswerSegment result = new()
        {
            Guid = guid,
            Dock = DockStyle.Top,
        };

        result.OnTitleChange += title =>
        {
            int i0 = I0ByGuid(guid);
            int index = IndexByGuid(guid);
            OnAnswerTitleChange?.Invoke(i0, index, title);
        };

        result.OnIsCorrectChange += isChecked =>
        {
            int i0 = I0ByGuid(guid);
            int index = IndexByGuid(guid);
            OnAnswerIsCorrectChange?.Invoke(i0, index, isChecked);
        };

        return result;
    }
}
