using QuizApp.Core.Domain;
using QuizApp.Core.Domain.Extensions;
using QuizApp.Core.Domain.Objects;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class QuestionPresenter
{
    private const string DEFAULT_QUESTION_TITLE = "";

    private readonly IQuestionView _questionView;

    private Quiz Quiz
    {
        get => _questionView.Quiz;
        set => _questionView.Quiz = value;
    }

    private Indexer<int, Question> Questions { get; }

    public QuestionPresenter(
        IQuestionView questionView
        )
    {
        Questions = new Indexer<int, Question>(
            getter: i => Quiz.Questions[i],
            setter: (i, value) => Quiz = Quiz with
            {
                Questions = Quiz.Questions.SetItem(i, value)
            });

        _questionView = questionView;

        _questionView.OnQuestionAdd += AddEmptyQuestion;
        _questionView.OnQuestionTitleChange += QuestionTitleChange;
        _questionView.OnQuestionPlusPointsChange += QuestionPlusPointsChange;
        _questionView.OnQuestionMinusPointsChange += QuestionMinusPointsChange;
        _questionView.OnQuestionRemove += QuestionRemove;
        _questionView.OnQuestionMoveDown += index => QuestionsSwap(index, index + 1);
        _questionView.OnQuestionMoveUp += index => QuestionsSwap(index, index - 1);
    }

    private void AddEmptyQuestion(int index)
    {
        Quiz = Quiz with
        {
            Questions = Quiz.Questions.Insert(
                index,
                new Question(DEFAULT_QUESTION_TITLE, 0, 0, [])
                )
        };
    }

    private void QuestionTitleChange(int index, string title)
    {
        Questions[index] = Questions[index] with { Title = title };
    }

    private void QuestionPlusPointsChange(int index, int plusPoints)
    {
        Questions[index] = Questions[index] with { PlusPoints = plusPoints };
    }

    private void QuestionMinusPointsChange(int index, int minusPoints)
    {
        Questions[index] = Questions[index] with { MinusPoints = minusPoints };
    }

    private void QuestionRemove(int index)
    {
        Quiz = Quiz with
        {
            Questions = Quiz.Questions.RemoveAt(index)
        };
    }

    private void QuestionsSwap(int index1, int index2)
    {
        Quiz = Quiz with
        {
            Questions = Quiz.Questions.SwapAt(index1, index2)
        };
    }
}
