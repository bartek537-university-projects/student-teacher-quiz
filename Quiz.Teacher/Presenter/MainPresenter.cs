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
        IQuizValidator quizValidator
        )
    {
        _ = new EditorPresenter(editorView, quizAccessor, quizValidator);
        _ = new QuestionPresenter(questionView);
        _ = new AnswerPresenter(answerView);
    }
}
