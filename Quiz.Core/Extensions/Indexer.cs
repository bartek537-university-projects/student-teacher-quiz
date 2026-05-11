namespace QuizApp.Core.Extensions;

public class Indexer<TIndex, TType>(
    Func<TIndex, TType> getter,
    Action<TIndex, TType> setter
    )
{
    public TType this[TIndex index]
    {
        get => getter(index);
        set => setter(index, value);
    }
}
