using QuizApp.Core.Domain;
using QuizApp.Core.Extensions;
using QuizApp.Core.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class AnswerPresenter
{
    private Quiz Quiz
    {
        get => _answerView.Quiz;
        set => _answerView.Quiz = value;
    }

    private Indexer<int, Question> Questions { get; }

    private readonly IAnswerView _answerView;
    private readonly IRecordFactory _recordFactory;

    public AnswerPresenter(
        IAnswerView answerView,
        IRecordFactory recordFactory
        )
    {
        Questions = new Indexer<int, Question>(
            getter: i => Quiz.Questions[i],
            setter: (i, value) => Quiz = Quiz with
            {
                Questions = Quiz.Questions.SetItem(i, value)
            });

        _answerView = answerView;
        _recordFactory = recordFactory;

        _answerView.OnAnswerAdd += (i0, index) => AddAnswer(i0, index, _recordFactory.MakeNewAnswer());
        _answerView.OnAnswerTitleChange += AnswerTitleChange;
        _answerView.OnAnswerIsCorrectChange += AnswerIsCorrectChange;
        _answerView.OnAnswerRemove += AnswerRemove;
        _answerView.OnAnswerMoveDown += (i0, index) => AnswersSwap(i0, index, index + 1);
        _answerView.OnAnswerMoveUp += (i0, index) => AnswersSwap(i0, index, index - 1);
    }

    private void AddAnswer(int i0, int index, Answer answer)
    {
        Questions[i0] = Questions[i0] with
        {
            Answers = Questions[i0].Answers.Insert(index, answer)
        };
    }

    private void AnswerTitleChange(int i0, int index, string title)
    {
        Questions[i0] = Questions[i0] with
        {
            Answers = Questions[i0].Answers.SetItem(
                index,
                Questions[i0].Answers[index] with { Title = title }
                )
        };
    }

    private void AnswerIsCorrectChange(int i0, int index, bool isCorrect)
    {
        Questions[i0] = Questions[i0] with
        {
            Answers = Questions[i0].Answers.SetItem(
                index,
                Questions[i0].Answers[index] with { IsCorrect = isCorrect }
                )
        };
    }

    private void AnswerRemove(int i0, int index)
    {
        Questions[i0] = Questions[i0] with
        {
            Answers = Questions[i0].Answers.RemoveAt(index)
        };
    }

    private void AnswersSwap(int i0, int index1, int index2)
    {
        Questions[i0] = Questions[i0] with
        {
            Answers = Questions[i0].Answers.SwapAt(index1, index2)
        };
    }
}
