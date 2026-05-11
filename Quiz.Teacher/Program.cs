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
        var recordFactory = new RecordFactory();

        // View configuration
        var mainForm = new MainForm(
            out IEditorView editorView,
            out IQuestionView questionView,
            out IAnswerView answerView
            );

        // Presenter configuration
        _ = new MainPresenter(
            editorView, questionView, answerView, // view
            quizAccessor, quizValidator, recordFactory // model
            );

        Application.Run(mainForm);
    }
}