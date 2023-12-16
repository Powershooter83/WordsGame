namespace WordsGame.Test;

public class WordsGameAlternativeTest
{
    [Theory]
    [InlineData("Hustensaft", 16)]
    [InlineData("Haus", 7)]
    [InlineData("Rakete", 10)]
    public void Grade_WithFullyCorrectWordReturnsCorrectAmountOfPoints(string word, int expectedPoints)
    {
        var sut = new WordsGameAlternative();
        sut.Start(word);
        
        var actual = sut.Grade(word);

        Assert.Equal(expectedPoints, actual);
    }
    
    [Theory]
    [InlineData("Hustensaft", "Hust", 7)] 
    [InlineData("Quarantäne", "Quarentine", 17)]
    [InlineData("Hustensaft", "PeterPan", 0)] 
    [InlineData("Quarantäne", "PeterPan", 0)]
    public void Grade_WithIncorrectWordReturnsCorrectAmountOfPoints(string word, string solution, int expectedPoints)
    {
        var sut = new WordsGameAlternative();
        sut.Start(word);
        
        var actual = sut.Grade(solution);

        Assert.Equal(expectedPoints, actual);
    }
}