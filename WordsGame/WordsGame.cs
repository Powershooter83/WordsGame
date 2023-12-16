namespace WordsGame;

public class WordsGame : IWordsGame
{
    private string word;

    public string Start(string word)
    {
        this.word = word;
        return Utils.Scramble(word);
    }

    public int Grade(string solution)
    {
        return solution.Equals(word) ? solution.Length : 0;
    }
    
}