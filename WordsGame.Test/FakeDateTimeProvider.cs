namespace WordsGame.Test;

class FakeDateTimeProvider : IDateTimeProvider
{
    private DateTime _time;

    public FakeDateTimeProvider(DateTime time)
    {
        _time = time;
    }

    public DateTime GetCurrentTime()
    {
        return _time;
    }

    public void SetCurrentTime(DateTime time)
    {
        _time = time;
    }
}