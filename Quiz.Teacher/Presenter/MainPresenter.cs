using QuizApp.Core.Model;
using QuizApp.Teacher.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class MainPresenter
{
    public MainPresenter(
        // --- VIEW ---
        IEditorView editorView,
        IQuizView quizView,
        IQuestionView questionView,
        IAnswerView answerView,
        // --- MODEL ---
        IQuizAccessor quizAccessor,
        IQuizValidator quizValidator
        )
    {
        _ = new EditorPresenter(editorView, quizAccessor, quizValidator);
        _ = new QuizPresenter(quizView);
        _ = new QuestionPresenter(questionView);
        _ = new AnswerPresenter(answerView);
    }
}
