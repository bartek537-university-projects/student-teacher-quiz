using QuizApp.Core.Model;
using QuizApp.Teacher.Presentation.Main;
using QuizApp.Teacher.Presenter;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Model configuration
        var quizAccessor = new QuizAccessor();
        var quizValidator = new QuizValidator();

        // View configuration
        var mainForm = new MainForm(
            out IEditorView editorView,
            out IQuestionView questionView,
            out IAnswerView answerView
            );

        // Presenter configuration
        _ = new MainPresenter(
            editorView, questionView, answerView, // view
            quizAccessor, quizValidator // model
            );

        Application.Run(mainForm);
    }
}