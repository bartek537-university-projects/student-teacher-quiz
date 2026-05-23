using QuizApp.Student.Application.Quiz;
using QuizApp.Student.Application.Recents;
using QuizApp.Student.Infrastructure.Quiz;
using QuizApp.Student.Infrastructure.Recents;
using QuizApp.Student.Presentation.Main;
using QuizApp.Student.Presentation.QuizSelection;
using QuizApp.Student.Presentation.QuizSession;

namespace QuizApp.Student;

internal static class Program
{
    private const string _appMutexId = "QuizApp.Student.Mutex";

    [STAThread]
    private static void Main()
    {
        using Mutex mutex = new(false, _appMutexId, out bool isOnlyAppInstance);

        if (!isOnlyAppInstance)
        {
            _ = MessageBox.Show("The app is already running.");
            return;
        }

        //FileSystemQuizRepository quizRepository = new();
        //FileSystemRecentFilesRepository recentFilesRepository = new(@".\recents.json");

        //GetQuiz.Handler getQuizHandler = new(quizRepository);
        //GetRecentFiles.Handler getRecentFilesHandler = new(recentFilesRepository);
        //AddRecentFile.Handler addRecentFileHandler = new(recentFilesRepository);

        ApplicationConfiguration.Initialize();

        //QuizSelectionView view = new();
        //QuizSelectionPresenter presenter = new(view, TimeProvider.System, getQuizHandler, addRecentFileHandler, getRecentFilesHandler);
        //view.Presenter = presenter;

        QuizSessionView view = new();
        QuizSessionPresenter presenter = new(view);
        view.Presenter = presenter;

        System.Windows.Forms.Application.Run(view);
    }
}