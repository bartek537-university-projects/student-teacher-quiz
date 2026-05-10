using QuizApp.Core.Domain;
using QuizApp.Core.Model;
using QuizApp.Teacher.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class EditorPresenter
{
    private readonly IEditorView _editorView;
    private readonly IQuizAccessor _quizAccessor;
    private readonly IQuizValidator _quizValidator;

    private Quiz Quiz
    {
        get => _editorView.Quiz;
        set => _editorView.Quiz = value;
    }

    public EditorPresenter(
        IEditorView editorView,
        IQuizAccessor quizAccessor,
        IQuizValidator quizValidator
        )
    {
        _editorView = editorView;
        _quizAccessor = quizAccessor;
        _quizValidator = quizValidator;

        _editorView.OnLoadRequest += () => _ = LoadQuiz();
        _editorView.OnSaveRequest += () => _ = SaveQuiz();
    }

    private async Task LoadQuiz()
    {
        try
        {
            string? filepath = _editorView.AskLoadFile();
            if (filepath == null) return;

            string? password = _editorView.AskPassword();
            if (password == null) return;

            Quiz quiz = await _quizAccessor.LoadFromFile(filepath, password);

            if (!_quizValidator.Validate(quiz, out _, out _))
            {
                throw new InvalidDataException("Dane są niepoprawne!");
            }

            Quiz = quiz;
        }
        catch (Exception ex)
        {
            _editorView.ShowError($"Wystąpił błąd przy wczytywaniu quizu: {ex.Message}");
        }
    }

    private async Task SaveQuiz()
    {
        ValidateCurrentQuiz();

        try
        {
            string? filepath = _editorView.AskSaveFile();
            if (filepath == null) return;

            string? password = _editorView.AskPassword();
            if (password == null) return;

            await _quizAccessor.SaveToFile(filepath, password, Quiz);
        }
        catch (Exception ex)
        {
            _editorView.ShowError($"Wystąpił błąd przy zapisie quizu: {ex.Message}");
        }
    }

    private void ValidateCurrentQuiz()
    {
        if (!_quizValidator.Validate(Quiz,
            out string errorMessage,
            out int? wrongQuestionIndex
            ))
        {
            _editorView.ShowValidationProblems(errorMessage, wrongQuestionIndex);
            return;
        }
    }
}
