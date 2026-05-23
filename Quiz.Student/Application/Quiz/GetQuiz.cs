using QuizApp.Student.Application.Common;
using QuizApp.Student.Application.Quiz.Abstractions;
using DomainQuiz = QuizApp.Core.Domain.Quiz;

namespace QuizApp.Student.Application.Quiz;

public static class GetQuiz
{
    public record Query(Uri Path) : IRequest<Response>;

    public class Handler(IQuizRepository quizRepository) : IRequestHandler<Query, Response>
    {
        public async Task<Response> HandleAsync(Query request, CancellationToken cancellationToken)
        {
            var quiz = await quizRepository
                .GetSingleAsync(request.Path);

            return new Response(quiz);
        }
    }

    public record Response(DomainQuiz? Quiz);
}
