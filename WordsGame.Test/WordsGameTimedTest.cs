namespace WordsGame.Test;

public class WordsGameTimedTest
{
    [Fact]
    public void Start_ReturnWord()
    {
        var sut = new WordsGame();
        const string word = "HALLO";

        var actual = sut.Start(word);

        Assert.NotEmpty(actual);
    }

    [Fact]
    public void Grade_WhenSolutionAndWordIsEqualAndWithinTimeSpanThenReturnCorrectPoints()
    {
        var dateTime = new DateTime(2023, 1, 1, 0, 0, 0);
        var fake = new FakeDateTimeProvider(dateTime);
        var sut = new WordsGameTimed(fake, new TimeSpan(0, 0, 30));
        const string word = "Schuleee";
        sut.Start(word);

        fake.SetCurrentTime(dateTime.Add(new TimeSpan(0,0,0, 0,25300)));
        var actual = sut.Grade(word);

        Assert.Equal(1, actual);
    }
    
    [Fact]
    public void Grade_WhenSolutionIsNotWithinTimeSpanThenReturnZero()
    {
        var dateTime = new DateTime(2023, 1, 1, 0, 0, 0);
        var fake = new FakeDateTimeProvider(dateTime);
        var sut = new WordsGameTimed(fake, new TimeSpan(0, 0, 30));
        const string word = "Schuleee";
        sut.Start(word);

        fake.SetCurrentTime(dateTime.Add(new TimeSpan(0,0,0, 31)));
        var actual = sut.Grade(word);

        Assert.Equal(0, actual);
    }
}