using QuizApp.Student.Domain.Entities;
using QuizApp.Student.Presentation.QuizSelection.Interfaces;
using System.ComponentModel;

namespace QuizApp.Student.Presentation.Main;

internal partial class QuizSelectionView : Form, IQuizSelectionView
{
    public event Action? Ready;
    public event Action<Uri>? LocalFileSelect;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IQuizSelectionPresenter Presenter { get; set { field = value; SetupPresenter(); } } = null!;

    public QuizSelectionView()
    {
        InitializeComponent();
    }

    private void SetupPresenter()
    {
        Presenter.RecentFilesChanged += OnRecentFilesChanged;
    }

    private void OnRecentFilesChanged()
    {
        UpdateRecentFiles(Presenter.RecentFiles);
    }

    private void UpdateRecentFiles(IReadOnlyList<RecentFile> files)
    {
        lvRecentFiles.Items.Clear();

        foreach (RecentFile file in files)
        {
            ListViewItem item = new()
            {
                ImageKey = "Report",
                Tag = file,
                Text = file.Path.AbsolutePath,
            };
            _ = lvRecentFiles.Items.Add(item);
        }
    }

    private void QuizSelectionView_Load(object sender, EventArgs e)
    {
        Ready?.Invoke();
    }

    private void btnOpenFile_Click(object sender, EventArgs e)
    {
        OnOpenFileClicked();
    }

    private void OnOpenFileClicked()
    {
        if (SelectLocalFile() is Uri path)
        {
            LocalFileSelect?.Invoke(path);
        }
    }

    private Uri? SelectLocalFile()
    {
        if (ofdOpenLocalFileDialog.ShowDialog() != DialogResult.OK)
        {
            return null;
        }

        string path = ofdOpenLocalFileDialog.FileName;
        return new Uri(path);
    }

    private void lvRecentFiles_DoubleClick(object sender, EventArgs e)
    {
        OnRecentFileDoubleClicked();
    }

    private void OnRecentFileDoubleClicked()
    {
        if (GetSelectedRecentFile() is Uri path)
        {
            LocalFileSelect?.Invoke(path);
        }
    }

    private Uri? GetSelectedRecentFile()
    {
        if (lvRecentFiles.SelectedIndices.Count < 1)
        {
            return null;
        }
        return lvRecentFiles.Items[0].Tag as Uri;
    }
}
