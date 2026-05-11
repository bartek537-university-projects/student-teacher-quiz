using QuizApp.Core.Domain;
using QuizApp.Core.Model;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class EditorPresenter
{
    private const string QUIZ_FILE_EXTENSION = "qz";

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
        static Quiz MakeDefaultQuiz() => new("Nowy Quiz", [
            new Question("Pytanie 1", 1, 0, [
                new Answer("Odpowiedź A", true),
                new Answer("Odpowiedź B", false),
                new Answer("Odpowiedź C", false)
                ])
            ]);

        if (!requireConfirmation || _editorView.AskConfirm(
            "Czy na pewno chcesz wyczyścić quiz? Wszystkie niezapisane zmiany zostaną utracone."
            ))
        {
            Quiz = MakeDefaultQuiz();
        }
    }

    private async Task LoadQuiz()
    {
        try
        {
            string? filepath = _editorView.AskLoadFile(QUIZ_FILE_EXTENSION);
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
        if (!_quizValidator.Validate(Quiz,
            out string errorMessage,
            out int? wrongQuestionIndex
            ))
        {
            _editorView.ShowValidationProblems(errorMessage, wrongQuestionIndex);
            return;
        }

        try
        {
            string? filepath = _editorView.AskSaveFile(QUIZ_FILE_EXTENSION);
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
}
