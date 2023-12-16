namespace WordsGame.Test;

public class WordsGameTest
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
    public void Grade_WhenSolutionAndWordIsEqualThenReturnLengthOfWordAsPoints()
    {
        var sut = new WordsGame();
        const string word = "Schule";
        sut.Start(word);

        var actual = sut.Grade(word);
        
        Assert.Equal(word.Length, actual);
    }
    
    [Fact]
    public void Grade_WhenSolutionAndWordIsNotEqualThenReturnZero()
    {
        var sut = new WordsGame();
        const string word = "Schule";
        sut.Start(word);
        
        var actual = sut.Grade("Schule2");
        
        Assert.Equal(0, actual);
    }
    
    
    [Theory]
    [InlineData("Hustensaft", 16)]
    [InlineData("Haus", 7)]
    [InlineData("Rakete", 10)]
    public void GradeWithScrabbleMode_WithFullyCorrectWordReturnsCorrectAmountOfPoints(string word, int expectedPoints)
    {
        var sut = new WordsGame();
        sut.Start(word);
        
        var actual = sut.GradeWithScrabbleMode(word);

        Assert.Equal(expectedPoints, actual);
    }
    
    [Theory]
    [InlineData("Hustensaft", "Hust", 7)] 
    [InlineData("Quarantäne", "Quarentine", 17)]
    [InlineData("Hustensaft", "PeterPan", 0)] 
    [InlineData("Quarantäne", "PeterPan", 0)]
    public void GradeWithScrabbleMode_WithIncorrectWordReturnsCorrectAmountOfPoints(string word, string solution, int expectedPoints)
    {
        var sut = new WordsGame();
        sut.Start(word);
        
        var actual = sut.GradeWithScrabbleMode(solution);

        Assert.Equal(expectedPoints, actual);
    }
}