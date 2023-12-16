namespace WordsGame;

public class WordsGameTimed : IWordsGame
{
    private string word;

    private readonly TimeSpan _timeSpan;
    private DateTime _startTime;
    
    private IDateTimeProvider _dateTimeProvider;
    
    public WordsGameTimed(IDateTimeProvider dateTimeProvider, TimeSpan timeSpan)
    {
        _dateTimeProvider = dateTimeProvider;
        _timeSpan = timeSpan;
    }
    
    public string Start(string word)
    {
        this.word = word;
        _startTime =_dateTimeProvider.GetCurrentTime();
        return Utils.Scramble(word);
    }

    public int Grade(string solution)
    {
        var end = _dateTimeProvider.GetCurrentTime();
        if (!Utils.IsWithinTimeSpan(_startTime, end, _timeSpan))
        {
            return 0;
        }
        var timeAsSeconds = ((end - DateTime.MinValue).TotalSeconds - (_startTime - DateTime.MinValue).TotalSeconds);
        return Utils.CalculatePointsWithTime(_timeSpan, timeAsSeconds, word.Length);
    }
    
}