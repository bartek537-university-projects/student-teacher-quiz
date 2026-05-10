using QuizApp.Core.Model;
using QuizApp.Teacher.Model;
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
            out var editorView,
            out var quizView,
            out var questionView,
            out var answerView
            );

        // Presenter configuration
        var presenter = new MainPresenter(
            editorView, quizView, questionView, answerView, // view
            quizAccessor, quizValidator // model
            );

        Application.Run(mainForm);
    }
}