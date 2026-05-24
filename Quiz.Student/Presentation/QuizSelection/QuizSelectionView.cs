using QuizApp.Core.Domain;
using QuizApp.Student.Domain;
using QuizApp.Student.Domain.Entities;
using QuizApp.Student.Presentation.QuizSelection;
using QuizApp.Student.Presentation.QuizSelection.Interfaces;
using QuizApp.Student.Presentation.QuizSession;
using System.ComponentModel;

namespace QuizApp.Student.Presentation.Main;

internal partial class QuizSelectionView : Form, IQuizSelectionView
{
    public event Action? Ready;
    public event Action<Uri, string?>? FileSelect;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IQuizSelectionPresenter Presenter
    {
        get;
        set
        {
            field = value;
            SetupPresenter();
        }
    } = null!;

    private readonly PasswordInputView passwordInputView = new();

    public QuizSelectionView()
    {
        InitializeComponent();

        passwordInputView.SubmitClick += PasswordInputView_SubmitClick;
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
            string path = file.Path.AbsolutePath;

            ListViewItem item = new()
            {
                ImageKey = "Report",
                Tag = file,
                Text = path,
                ToolTipText = path,
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
        if (OpenSelectFileDialog() is Uri path)
        {
            OnFileSelected(path);
        }
    }

    private Uri? OpenSelectFileDialog()
    {
        if (ofdOpenFileDialog.ShowDialog() != DialogResult.OK)
        {
            return null;
        }

        string path = ofdOpenFileDialog.FileName;
        return new Uri(path);
    }

    private void lvRecentFiles_DoubleClick(object sender, EventArgs e)
    {
        OnRecentFileDoubleClicked();
    }

    private void OnRecentFileDoubleClicked()
    {
        if (GetSelectedRecentFile() is RecentFile file)
        {
            OnFileSelected(file.Path);
        }
    }

    private RecentFile? GetSelectedRecentFile()
    {
        if (lvRecentFiles.SelectedIndices.Count < 1)
        {
            return null;
        }
        return lvRecentFiles.SelectedItems[0].Tag as RecentFile;
    }

    private void OnFileSelected(Uri path, string? secret = null)
    {
        FileSelect?.Invoke(path, secret);
    }

    public void ShowPasswordPrompt(Uri path)
    {
        bool isRepeated = passwordInputView.Visible && passwordInputView.Path == path;

        passwordInputView.Path = path;
        passwordInputView.IsInvalid = isRepeated;

        if (!passwordInputView.Visible)
        {
            _ = passwordInputView.ShowDialog(this);
        }
    }

    private void PasswordInputView_SubmitClick()
    {
        Uri path = passwordInputView.Path!;
        string secret = passwordInputView.Password;

        OnFileSelected(path, secret);
    }

    public void HidePasswordPrompt()
    {
        passwordInputView.Hide();
        passwordInputView.Path = null;
    }

    public void StartQuizSession(Quiz quiz)
    {
        AllOrNothingQuestionScoreStrategy questionScoreStrategy = new();
        QuizScoreCalculator quizScoreCalculator = new(questionScoreStrategy);

        using QuizSessionView view = new();
        QuizSessionPresenter presenter = new(view, TimeProvider.System, quizScoreCalculator, quiz);
        view.Presenter = presenter;

        _ = view.ShowDialog();
    }
}
