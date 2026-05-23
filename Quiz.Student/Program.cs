using QuizApp.Student.Application.Recents;
using QuizApp.Student.Infrastructure.Recents;
using QuizApp.Student.Presentation.Main;
using QuizApp.Student.Presentation.QuizSelection;

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

        InMemoryRecentFilesRepository recentFilesRepository = new();
        GetRecentFiles.Handler getRecentFilesHandler = new(recentFilesRepository);
        AddRecentFile.Handler addRecentFileHandler = new(recentFilesRepository);

        ApplicationConfiguration.Initialize();

        QuizSelectionView view = new();
        QuizSelectionPresenter presenter = new(view, TimeProvider.System, addRecentFileHandler, getRecentFilesHandler);
        view.Presenter = presenter;

        System.Windows.Forms.Application.Run(view);
    }
}