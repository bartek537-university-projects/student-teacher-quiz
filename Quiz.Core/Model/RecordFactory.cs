using QuizApp.Core.Domain;

namespace QuizApp.Core.Model;

public interface IRecordFactory
{
    Quiz MakeNewQuiz();
    Question MakeNewQuestion();
    Answer MakeNewAnswer();
    Question MakeInspireQuestion();
}

public class RecordFactory : IRecordFactory
{
    public Quiz MakeNewQuiz()
    {
        return new Quiz()
        {
            Title = "Nowy Quiz",
            Questions = [],
        };
    }

    public Question MakeNewQuestion()
    {
        return new Question()
        {
            Title = "",
            PlusPoints = 1,
            MinusPoints = 0,
            Answers = [],
        };
    }

    public Answer MakeNewAnswer()
    {
        return new Answer()
        {
            Title = "",
            IsCorrect = false,
        };
    }

    public Question MakeInspireQuestion()
    {
        Answer[] answers = [
            new() { Title = RandomAnswer(), IsCorrect = false },
            new() { Title = RandomAnswer(), IsCorrect = false },
            new() { Title = RandomAnswer(), IsCorrect = false },
            ];

        Random rng = new();
        int index = rng.Next(answers.Length);
        answers[index] = answers[index] with { IsCorrect = true };

        return new Question()
        {
            Title = RandomQuestion(),
            PlusPoints = 1,
            MinusPoints = 0,
            Answers = [.. answers]
        };
    }

    private static string RandomQuestion()
    {
        Random rng = new();
        int index = rng.Next(Questions.Length);
        return Questions[index];
    }

    private static string RandomAnswer()
    {
        Random rng = new();
        int index = rng.Next(Answers.Length);
        return Answers[index];
    }

    #region Questions

    private static readonly string[] Questions = [
        "Jaki jest wynik działania 2 + 2?",
        "Który z poniższych jest największy?",
        "Na jakim kontynencie znajduje się Egipt?",
        "Który z poniższych jest pierwiastkiem kwadratowym z 16?",
        "Jaki jest symbol chemiczny dla wody?",
        "Który z poniższych jest największym ssakiem?",
        "Kto napisał \"Pana Tadeusza\"?",
        "W którym roku wybuchła II wojna światowa?",
        "Jak nazywa się stolica Francji?",
        "Ile planet jest obecnie w Układzie Słonecznym?",
        "Jaka jest największa rzeka na świecie pod względem objętości wody?",
        "Co jest stolicą Japonii?",
        "Kto jest autorem teorii względności?",
        "W jakim stanie skupienia znajduje się woda w temperaturze 100 stopni Celsjusza?",
        "Jak nazywa się najdłuższa rzeka w Polsce?",
        "Z ilu wierzchołków składa się trójkąt?",
        "Jak ma na imię główny bohater serii gier \"Wiedźmin\"?",
        "Kto oficjalnie odkrył Amerykę w 1492 roku?",
        "Jaka planeta jest potocznie nazywana \"Czerwoną Planetą\"?",
        "Co jest głównym, najliczniejszym składnikiem powietrza?",
        "Ile par odnóży ma pająk?",
        "Jak nazywa się najwyższy szczyt Ziemi?",
        "Kto namalował słynny obraz \"Mona Lisa\"?",
        "Ile kości znajduje się w ciele dorosłego człowieka?",
        "Jak nazywa się waluta obowiązująca w Wielkiej Brytanii?",
        "Co oznacza skrót IT w branży technologicznej?",
        "Jak nazywa się najtwardszy, naturalnie występujący minerał na Ziemi?",
        "Które zwierzę jest powszechnie uznawane za \"króla dżungli\"?",
        "Ile kontynentów wyróżnia się w tradycyjnym podziale geograficznym?",
        "Komu przypisuje się wynalezienie żarówki elektrycznej?",
        "Jak nazywa się największy ocean na Ziemi?",
        "Ile podstawowych kolorów występuje w tęczy?",
        "Jaki jest język urzędowy w Brazylii?",
        "Jakie miasto jest stolicą Włoch?",
        "Który z instrumentów muzycznych ma czarno-białe klawisze?",
        "Jaką jednostką mierzymy natężenie prądu elektrycznego?",
        "Jaki owoc, według legendy, spadł Newtonowi na głowę?",
        "Jak nazywa się polski hymn narodowy?",
        "Ile w przybliżeniu wynosi liczba Pi (do dwóch miejsc po przecinku)?",
        "Kto był pierwszym prezydentem Polski po 1989 roku?",
        "Jaka jest najmniejsza planeta w Układzie Słonecznym?",
        "W którym kraju znajdują się piramidy w Gizie?",
        "Jak nazywa się zielony barwnik występujący w roślinach?",
        "Ile godzin ma jedna pełna doba?",
        "Który narząd człowieka odpowiada za pompowanie krwi?",
        "Jak nazywa się najszybsze zwierzę lądowe na świecie?",
        "Co w ulu produkują pszczoły?",
        "Z jakiego metalu głównie zbudowana jest wieża Eiffla?",
        "Jaka jest najpopularniejsza dyscyplina sportowa na świecie?",
        "Ile wynosi pierwiastek sześcienny z liczby 27?"
        ];

    #endregion

    #region Answers

    private static readonly string[] Answers = [
        "4",
        "16",
        "8",
        "Afryka",
        "Europa",
        "Mars",
        "Jowisz",
        "H2O",
        "CO2",
        "Płetwal błękitny",
        "Słoń afrykański",
        "Adam Mickiewicz",
        "1939",
        "Paryż",
        "8",
        "Amazonka",
        "Tokio",
        "Albert Einstein",
        "Gazowym",
        "Wisła",
        "3",
        "Geralt",
        "Krzysztof Kolumb",
        "Azot",
        "Tlen",
        "Mount Everest",
        "Leonardo da Vinci",
        "206",
        "Funt szterling",
        "Diament",
        "Lew",
        "7",
        "Thomas Edison",
        "Ocean Spokojny",
        "Portugalski",
        "Rzym",
        "Fortepian",
        "Amper",
        "Jabłko",
        "Mazurek Dąbrowskiego",
        "3.14",
        "Lech Wałęsa",
        "Merkury",
        "Egipt",
        "Chlorofil",
        "24",
        "Serce",
        "Gepard",
        "Miód",
        "Żelazo",
        "Piłka nożna",
        "Prawda",
        "Fałsz",
        "Tak",
        "Nie",
        "Brak danych",
        "Wszystkie powyższe",
        "Żadne z powyższych",
        "100",
        "0",
        "-1",
        "42",
        "Księżyc",
        "Słońce",
        "Ziemia",
        "Australia",
        "Antarktyda",
        "Ameryka Północna",
        "Ameryka Południowa",
        "Azja",
        "Warszawa",
        "Kraków",
        "Berlin",
        "Londyn",
        "Madryt",
        "Homer",
        "Juliusz Słowacki",
        "Mikołaj Kopernik",
        "Maria Skłodowska-Curie",
        "1945",
        "1410",
        "Złoto",
        "Srebro",
        "Miedź",
        "Grawitacja",
        "Prędkość światła",
        "Wulkan",
        "Pustynia",
        "Las deszczowy",
        "Góry Skaliste",
        "Jezioro Wiktorii",
        "Oczy",
        "Uszy",
        "Skóra",
        "Mózg",
        "Klawiatura",
        "Monitor",
        "Myszka",
        "Polska",
        "Niemcy"
        ];

    #endregion
}
