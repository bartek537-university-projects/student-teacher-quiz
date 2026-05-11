using QuizApp.Core.Domain;
using QuizApp.Core.Utils;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class AnswerPresenter
{
    private readonly IAnswerView _answerView;

    private Quiz Quiz
    {
        get => _answerView.Quiz;
        set => _answerView.Quiz = value;
    }

    private Indexer<int, Question> Questions { get; }

    public AnswerPresenter(
        IAnswerView answerView
        )
    {
        Questions = new Indexer<int, Question>(
            getter: i => Quiz.Questions[i],
            setter: (i, value) => Quiz = Quiz with
            {
                Questions = Quiz.Questions.SetItem(i, value)
            });

        _answerView = answerView;

        _answerView.OnAnswerAdd += AddEmptyAnswer;
        _answerView.OnAnswerTitleChange += AnswerTitleChange;
        _answerView.OnAnswerIsCorrectChange += AnswerIsCorrectChange;
        _answerView.OnAnswerRemove += AnswerRemove;
        _answerView.OnAnswerMoveDown += (i0, index) => AnswersSwap(i0, index, index + 1);
        _answerView.OnAnswerMoveUp += (i0, index) => AnswersSwap(i0, index, index - 1);
    }

    private void AddEmptyAnswer(int i0, int index, Answer answer)
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
