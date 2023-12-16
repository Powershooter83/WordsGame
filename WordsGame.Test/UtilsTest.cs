namespace WordsGame.Test;

public class UtilsTest
{
    [Fact]
    public void Scramble_WhenInputIsEmptyThenReturnEmpty()
    {
        var actual = Utils.Scramble("");
        
        Assert.Empty(actual);
    }
    
    [Fact]
    public void Scramble_WhenInputContainsOneLetterThenReturnSameLetter()
    {
        const string letter = "X";
        
        var actual = Utils.Scramble(letter);
        
        Assert.Equal(letter, actual);
    }
    
    [Fact]
    public void Scramble_WhenInputContainsTwoLetterThenReturnTwistedLetters()
    {
        const string word = "AX";
        
        var actual = Utils.Scramble(word);
        
        Assert.Equal("XA", actual);
    }
    
    [Fact]
    public void Scramble_WhenInputContainsMoreThanTwoLetterThenReturnTwistedLetters()
    {
        const string word = "HALLO";
        
        var actual = Utils.Scramble(word);
        
        Assert.NotEqual(word, actual);
        Assert.Equal(word.Length, actual.Length);
        Assert.True(word.ToCharArray().All(actual.ToCharArray().Contains));
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 3)]
    [InlineData('c', 3)]
    [InlineData('d', 2)]
    [InlineData('e', 1)]
    [InlineData('f', 4)]
    [InlineData('g', 2)]
    [InlineData('h', 4)]
    [InlineData('i', 1)]
    [InlineData('j', 8)]
    [InlineData('k', 5)]
    [InlineData('l', 1)]
    [InlineData('m', 3)]
    [InlineData('n', 1)]
    [InlineData('o', 1)]
    [InlineData('p', 3)]
    [InlineData('q', 10)]
    [InlineData('r', 1)]
    [InlineData('s', 1)]
    [InlineData('t', 1)]
    [InlineData('u', 1)]
    [InlineData('v', 4)]
    [InlineData('w', 4)]
    [InlineData('x', 8)]
    [InlineData('y', 4)]
    [InlineData('z', 10)]
    public void MapCharToPoints_ReturnsCorrectPoints(char letter, int expectedPoints)
    {
        var actual = Utils.MapCharToPoints(letter);

        Assert.Equal(expectedPoints, actual);
    }
    
    [Fact]
    public void IsWithinTimeSpan_WhenTimesAreWithinTimeSpanThenReturnTrue()
    {
        var start = new DateTime(2023, 1, 1, 12, 0, 0);
        var end = new DateTime(2023, 1, 1, 12, 10, 0);
        var timeSpan = new TimeSpan(0, 0, 10, 0);

        var actual = Utils.IsWithinTimeSpan(start, end, timeSpan);

        Assert.True(actual);
    }
    
    [Fact]
    public void IsWithinTimeSpan_WhenTimesAreMotWithinTimeSpanThenReturnFalse()
    {
        var start = new DateTime(2023, 1, 1, 12, 0, 0);
        var end = new DateTime(2023, 1, 1, 12, 11, 0);
        var timeSpan = new TimeSpan(0, 0, 10, 0);

        var actual = Utils.IsWithinTimeSpan(start, end, timeSpan);

        Assert.False(actual);
    }

    [Fact]
    public void CalculatePointsWithTime()
    {
        const int points = 7;
        
        var timeSpan = new TimeSpan(0, 0, 0, 60);
        const double time = 22.1;

        var actual = Utils.CalculatePointsWithTime(timeSpan, time, points);
        
        Assert.Equal(4, actual);
        
    }
    
}