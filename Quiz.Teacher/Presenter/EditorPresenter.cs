using QuizApp.Core.Domain;
using QuizApp.Core.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class EditorPresenter
{
    private Quiz Quiz
    {
        get => _editorView.Quiz;
        set => _editorView.Quiz = value;
    }

    private readonly IEditorView _editorView;
    private readonly IQuizAccessor _quizAccessor;
    private readonly IQuizValidator _quizValidator;
    private readonly IRecordFactory _recordFactory;

    public EditorPresenter(
        IEditorView editorView,
        IQuizAccessor quizAccessor,
        IQuizValidator quizValidator,
        IRecordFactory recordFactory
        )
    {
        _editorView = editorView;
        _quizAccessor = quizAccessor;
        _quizValidator = quizValidator;
        _recordFactory = recordFactory;

        _editorView.OnTitleChange += QuizTitleChange;

        _editorView.OnClearRequest += () => QuizClear(requireConfirmation: true);
        _editorView.OnClearInstant += () => QuizClear(requireConfirmation: false);

        _editorView.OnLoadRequest += () => _ = LoadQuiz();
        _editorView.OnSaveRequest += () => _ = SaveQuiz();
    }

    private void QuizTitleChange(string title)
    {
        Quiz = Quiz with { Title = title };
    }

    private void QuizClear(bool requireConfirmation)
    {
        if (!requireConfirmation || _editorView.AskConfirm(
            "Czy na pewno chcesz wyczyścić quiz? Wszystkie niezapisane zmiany zostaną utracone."
            ))
        {
            Quiz = _recordFactory.MakeNewQuiz();
        }
    }

    private async Task LoadQuiz()
    {
        _editorView.Lock++;

        try
        {
            string? filepath = _editorView.AskLoadFile("qz");
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
        finally
        {
            _editorView.Lock--;
        }
    }

    private async Task SaveQuiz()
    {
        if (!_quizValidator.Validate(Quiz,
            out string errorMessage,
            out int? wrongQuestionIndex
            ))
        {
            _editorView.ShowValidationProblems(errorMessage, wrongQuestionIndex);
            return;
        }

        _editorView.Lock++;

        try
        {
            string? filepath = _editorView.AskSaveFile("qz");
            if (filepath == null) return;

            string? password = _editorView.AskPassword();
            if (password == null) return;

            await _quizAccessor.SaveToFile(filepath, password, Quiz);
        }
        catch (Exception ex)
        {
            _editorView.ShowError($"Wystąpił błąd przy zapisie quizu: {ex.Message}");
        }
        finally
        {
            _editorView.Lock--;
        }
    }
}
