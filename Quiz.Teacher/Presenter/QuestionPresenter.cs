using QuizApp.Core.Domain;
using QuizApp.Core.Extensions;
using QuizApp.Core.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class QuestionPresenter
{
    private Quiz Quiz
    {
        get => _questionView.Quiz;
        set => _questionView.Quiz = value;
    }

    private Indexer<int, Question> Questions { get; }

    private readonly IQuestionView _questionView;
    private readonly IRecordFactory _recordFactory;

    public QuestionPresenter(
        IQuestionView questionView,
        IRecordFactory recordFactory
        )
    {
        Questions = new Indexer<int, Question>(
            getter: i => Quiz.Questions[i],
            setter: (i, value) => Quiz = Quiz with
            {
                Questions = Quiz.Questions.SetItem(i, value)
            });

        _questionView = questionView;
        _recordFactory = recordFactory;

        _questionView.OnQuestionAdd += index => QuestionAdd(index, _recordFactory.MakeNewQuestion());
        _questionView.OnQuestionInspireAdd += index => QuestionAdd(index, _recordFactory.MakeInspireQuestion());
        _questionView.OnQuestionTitleChange += QuestionTitleChange;
        _questionView.OnQuestionPlusPointsChange += QuestionPlusPointsChange;
        _questionView.OnQuestionMinusPointsChange += QuestionMinusPointsChange;
        _questionView.OnQuestionRemove += QuestionRemove;
        _questionView.OnQuestionMoveDown += index => QuestionsSwap(index, index + 1);
        _questionView.OnQuestionMoveUp += index => QuestionsSwap(index, index - 1);
    }

    private void QuestionAdd(int index, Question question)
    {
        Quiz = Quiz with
        {
            Questions = Quiz.Questions.Insert(index, question)
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
