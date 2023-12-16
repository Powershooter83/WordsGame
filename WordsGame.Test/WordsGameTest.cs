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
    
}