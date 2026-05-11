using QuizApp.Core.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class MainPresenter
{
    public MainPresenter(

        // --- VIEW ---
        IEditorView editorView,
        IQuestionView questionView,
        IAnswerView answerView,

        // --- MODEL ---
        IQuizAccessor quizAccessor,
        IQuizValidator quizValidator,
        IRecordFactory recordFactory
        )
    {
        _ = new EditorPresenter(editorView, quizAccessor, quizValidator, recordFactory);
        _ = new QuestionPresenter(questionView, recordFactory);
        _ = new AnswerPresenter(answerView, recordFactory);
    }
}
